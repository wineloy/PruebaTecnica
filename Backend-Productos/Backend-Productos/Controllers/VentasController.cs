using Backend_Productos.models;
using Backend_Productos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Productos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentasController : Controller
    {
        public IActionResult Index()
        {
            using (ProductosContext db = new ProductosContext())
            {
                //El filtro lo hice en JS 
                var query = from a in db.Productos
                            join s in db.Ventas on a.IdProductos equals s.IdProductos
                            select new VentasProductos
                            {
                                Nombre = a.NombreProducto,
                                NombreLargo = a.NombreProducto,
                                Precio = a.Precio,
                                CantidadProductos = a.CantidadExistencia,
                                Fecha = s.Fecha,
                                CantidadVentas = s.Cantidad
                            };
                           
                return Ok(query.ToList());
            }
        }
        [Route("intervalo")]
        [HttpPost()]
        public IActionResult IntervalosFecha()
        {
            //Me falto esta parte, hace tiempo que no usaba Net Core :( 
            //ahora se llama Net 5!
            //Pero en teoria solo seria realizar un beetween entre las fechas y pintarlas en el la interfaz 

            return Ok();
        }
    }
}
