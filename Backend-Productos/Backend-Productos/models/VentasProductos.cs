using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Productos.models
{
    public class VentasProductos
    {
        public String Nombre { get; set; }
        public String NombreLargo { get; set; }
        public decimal?  Precio { get; set; }
        public int? CantidadProductos { get; set; }
        //ventas
        public DateTime? Fecha { get; set; }
        public int? CantidadVentas { get; set; }
    }
}
