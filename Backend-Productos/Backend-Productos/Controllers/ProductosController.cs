﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_Productos.Models;

//Controlador encargado de CRUD Productos
namespace Backend_Productos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : Controller
    {
        //Muestra la data de la base de datos
        [HttpGet]
        public IActionResult Index()
       {
            using (ProductosContext db = new ProductosContext())
            {
                var listaProductos = (from prod in db.Productos
                                      select prod).ToList();
                    
                return Ok(listaProductos);
            }
                
        }
        [Route("product")]
        [HttpPost]
        public IActionResult product([FromBody] models.request.ProductosDelete modelo)
        {
            using (ProductosContext db = new ProductosContext())
            {
                var listaProductos = (from prod in db.Productos
                                      select prod)
                                     .Where(s => s.IdProductos == modelo.IdProducto)
                                      .ToList();

                return Ok(listaProductos);
            }

        }

        [Route("busqueda")]
        [HttpPost]
        public IActionResult busqueda([FromBody] models.request.Busquedas modelo)
        {
            using (ProductosContext db = new ProductosContext())
            {
                var busqueda = (from prod in db.Productos
                                      select prod)
                                     .Where(s => s.NombreProducto.Contains(modelo.NombreProductoLargo.ToUpper())) 
                                     .ToList();
                if (busqueda== null)
                {
                    Index();
                }

                return Ok(busqueda);
            }

        }


        [Route("create")]
        [HttpPost()]
        public IActionResult create([FromBody] models.request.ProductosCreate modelo)
        {
            //Valido que no existan datos vacios
            if(!(modelo.Cantidad==0 && modelo.Precio==0 && String.IsNullOrEmpty(modelo.NombreProductoLargo) && String.IsNullOrEmpty(modelo.NombreProducto)))
            {
                using (ProductosContext db = new ProductosContext())
                {
                    Producto oProducto = new Producto();
                    oProducto.NombreProducto = modelo.NombreProducto.ToUpper();
                    oProducto.NombreProductoLargo = modelo.NombreProductoLargo.ToUpper();
                    oProducto.Precio =modelo.Precio;
                    oProducto.CantidadExistencia = modelo.Cantidad;

                    db.Add(oProducto);
                    db.SaveChanges();
                    return Ok();
                }
            }else
                return NotFound();           
        }

        [Route("edit")]
        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] models.request.ProductosEdit modelo)
        {
            using (ProductosContext db = new ProductosContext())
            {

                try
                {
                    var oProducto = db.Productos.Find(modelo.IdProducto);
                    oProducto.NombreProducto = modelo.NombreProducto.ToUpper();
                    oProducto.NombreProductoLargo = modelo.NombreProductoLargo.ToUpper();
                    oProducto.Precio = modelo.Precio;
                    oProducto.CantidadExistencia = modelo.Cantidad;
                    db.Entry(oProducto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChangesAsync();
                    return Ok();
                }
                catch(Exception e)
                {
                    return NotFound();
                }
                
            }
           
        }

        [Route("delete")]
        [HttpDelete()]
        public IActionResult delete([FromBody] models.request.ProductosDelete modelo)
        {
            using (ProductosContext db = new ProductosContext())
            {
                try
                {
                    var oProducto = db.Productos.Find(modelo.IdProducto);
                    db.Remove(oProducto);
                    db.SaveChanges();
                    return Ok();
                }
                catch(ArgumentNullException e)
                {
                    return NotFound();
                }
            }
        }
    }
}
