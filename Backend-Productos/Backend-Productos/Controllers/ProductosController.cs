using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Controlador encargado de la gestion de productos
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
            return Ok("Te he enviado una respuesta");
        }

        [Route("delete")]
        [HttpDelete()]
        public IActionResult delete()
        {
            return Ok("Te he enviado una respuesta desde Borrado");
        }

        [Route("edit")]
        [HttpPut()]
        public IActionResult Update()
        {
            return Ok("Te he enviado una respuesta desde Actualización");
        }

        [Route("create")]
        [HttpPost()]
        public IActionResult create()
        {
            return Ok("Te he enviado una respuesta desde creacion");
        }

    }
}
