let Json;
let formRegistro = document.querySelector("#form-registro");

//Consumo Api al momento de iniciar la app
document.addEventListener("DOMContentLoaded", getProductos());

async function getProductos() {

    setTimeout(async () => {
        return await fetch('https://localhost:44335/Productos')
            .then(request => {
                if (request.ok)
                    return request.json();
            })
            .then(data => {
                PintarTargetas(data);
            })
    }, 1000)

}

async function PintarTargetas(data) {
    Json = await data;
    //console.log(Json);
    var table = document.querySelector('#cuerpo');
    let card = document.querySelector("#card")
    card.innerHTML = "";
    //Itero sobre las targetas 
    Json.forEach(element => {
        //Dibujado de la tarjetas
        if (Number(element.cantidadExistencia) != 0) {
            card.innerHTML += `<div class="card my-2 my-md-2" style="width: 18rem;">
            <div class="card-body">
              <h5 class="card-title">${element.nombreProducto}</h5>
              <h6 class="card-subtitle mb-2 text-muted">$ ${Number(element.precio)} MXN</h6>
              <p class="card-text">${element.nombreProductoLargo}</p>
              <a class="card-link" onclick="Borrar(${element.idProductos});">Borrar</a>
              <a class="card-link" onclick="Editar(${element.idProductos});">Editar</a>
              <a class="card-link">Comprar</a>
            </div>
            </div>`
        } else {
            card.innerHTML += `<div class="card my-2 my-md-2 bg-light" style="width: 18rem;">
            <div class="card-body">
              <h5 class="card-title">${element.nombreProducto} <em> Agotada</em></h5>
              <h6 class="card-subtitle mb-2 text-muted">$ ${Number(element.precio)} MXN</h6>
              <p class="card-text">${element.nombreProductoLargo}</p>
              <a class="card-link" onclick="Borrar(${element.idProductos});">Borrar</a>
              <a class="card-link" onclick="Editar(${element.idProductos});">Editar</a>
              <a class="card-link">Comprar</a>
            </div>
            </div>`
        }

    });
}

//Registro Productos en base al formulario 
formRegistro.addEventListener("submit", e => {
    e.preventDefault();
    let datosformulario = new FormData(formRegistro);

    var data = {
        "NombreProducto": datosformulario.get('NombreProducto'),
        "NombreProductoLargo": datosformulario.get('NombreProductoLargo'),
        "Precio": Number(datosformulario.get('Precio')),
        "Cantidad": Number(datosformulario.get('Cantidad'))
    }
    //Creo es no es lo mas limpio :D
    fetch("https://localhost:44335/productos/create", {

        method: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(request => {
            if (request.ok) {
                getProductos();
                Swal.fire(
                    'Producto Registrado',
                    'Realiza un pequeño Scroll para ver el producto',
                    'success'
                );
            }
            else
                throw ("Error en la inserción!")

        })
        .then(response => console.log(response))
        .catch(error => console.log(error));

    formRegistro.reset();

});

//Operaciones Crud
function Borrar(id) {

    Swal.fire({
        title: '¿Esta seguro de querer borrar el producto?',
        text: "No se puede deshacer este cambio",
        icon: 'info',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'SI',
        cancelButtonText: 'NO',
    }).then((result) => {
        if (result.isConfirmed) {
            fetch("https://localhost:44335/productos/delete", {
                method: "DELETE",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    "idProducto": id
                })

            })
                .then(request => {
                    if (request.ok) {
                        getProductos();
                    } else
                        throw ("Error con la comunicacíon")
                });

        }
    });
}


function Editar(id) {

    let nombre = document.getElementById("NombreProducto");
    let NombreProductoLargo = document.getElementById("NombreProductoLargo");
    let Precio = document.getElementById("Precio");
    let Cantidad = document.getElementById("Cantidad");
    let bntRegistrar = document.querySelector("#bnt-Registrar");
    let bntSave = document.querySelector("#bnt-Save");

    var data = { "idProducto": Number(id) }

    //Creo es no es lo mas limpio :D
    fetch("https://localhost:44335/Productos/product", {

        method: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(request => {
            if (request.ok) {
                return request.json();
            }
            else
                throw ("Error en la inserción!")

        })
        .then(data => {
            data.forEach(producto => {
                nombre.value = producto.nombreProducto;
                NombreProductoLargo.value = producto.nombreProductoLargo;
                Precio.value = producto.precio;
                Cantidad.value = producto.cantidadExistencia;
            })
        })
        .catch(error => console.log(error));

        bntSave.addEventListener("click", e => {

            var data = {
                "IdProducto": Number(id),
                "NombreProducto": nombre.value,
                "NombreProductoLargo": NombreProductoLargo.value,
                "Precio": Number(Precio.value),
                "Cantidad": Number(Cantidad.value)
            }
            //Creo es no es lo mas limpio :D
            fetch("https://localhost:44335/productos/edit", {
        
                method: "PUT",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            })
                .then(request => {
                    if (request.ok) {
                        getProductos();
                        Swal.fire(
                            'Producto Registrado',
                            'Realiza un pequeño Scroll para ver el producto',
                            'success'
                        );
                    }
                    else
                        throw ("Error en la inserción!")
        
                })
                .then(response => console.log(response))
                .catch(error => console.log(error));
        
            formRegistro.reset();
        });
}



