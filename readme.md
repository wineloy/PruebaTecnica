# Prueba Técnica Residencias

Prueba realizada por Eloy Garcia Ceja, en este apartado te comento los detalles de esta solución

## Diagrama General Solución
![Diagrama General Proyecto](https://github.com/wineloy/PruebaTecnica/blob/main/views/img/diagrama.png?raw=true)

## Tecnologías empleadas
 - Framework NET 5.0
 - SQL SERVER EXPRESS EDITION 
 - Entity Framework Core
 - Lenguaje C#
 ## Entorno de desarrollo
 
 - Visual Studio community 2019
 - SQL Server Management Studio
 - Visual Studio Code (Edición para vistas)
 - Postman (Para consultas a la API) 
 ## Estructura de la aplicación
 En este repositorio encontrara 3 carpetas:

     Backend-Productos: Proyecto WebAPI Net 5.0
     views: documentos HTML, CSS y JS
     Database Script: El script de la base de datos (Perdon por lo sencillo 😅)
  ## Operaciones 

 - La aplicación cuenta con un CRUD completo para la gestion de productos 
 - La aplicación permite filtrar los mas vendidos y menos vendidos  

 ## End Points
Esta API hace uso de los métodos HTTP para realizar determinadas acciones a continuación se en listan:

    www.yourdomain/Productos -> GET {Muestra Productos}
    www.yourdomain/create -> POST {Registro de Productos}
    www.yourdomain/edit -> PUT {Edición de Productos}
    www.yourdomain/delete -> DELETE {Eliminación de Productos}
    www.yourdomain/produc -> POST {Búsqueda de productos por ID }
    www.yourdomain/busquedas -> POST {Búsquedas por nombres }
    www.yourdomain/Ventas -> GET {Muestra las ventas de productos}

 - GET: Para consultas de información y en donde no sea necesario enviar algún parámetro en la solicitud.
 - POST: Para todas aquellas inserciones que estén enfocadas principalmente en la creación de registros
 - PUT: Para acciones de modificación 
 - DELETE: Como su nombre lo indica es para eliminación de registros 

## Limitaciones 

 - Esta aplicación no puede generar ventas 
 - Esta aplicación no puede modificar tabla de ventas 
 - Hay un boton que dice comprar, pero no hace nada mas que mandar una alerta 😞
 - quedo pendiente sobre las existencias (aunque si tiene curiosidad si edita uno y lo pone en cero la tarjeta cambia y se agrega mensaje agotado) y sobre los intervalos
## Agregados 
 - La aplicación esta validada para evitar nulos tanto en el frontend como en el backend 
 - cuenta con algunas animaciones en las alertas de acción 

## Vistas de aplicación

![Home App](https://github.com/wineloy/PruebaTecnica/blob/main/views/img/foto%20home.png?raw=true)

![Logo](https://github.com/wineloy/PruebaTecnica/blob/main/views/img/foto%20registro.png?raw=true)



 
 
