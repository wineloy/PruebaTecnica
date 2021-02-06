using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Productos.models.request
{
    public class ProductosCreate
    {
        public string NombreProducto { get; set; }
        public string NombreProductoLargo { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
