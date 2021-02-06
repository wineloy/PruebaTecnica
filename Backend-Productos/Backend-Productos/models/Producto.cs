using System;
using System.Collections.Generic;

#nullable disable

namespace Backend_Productos.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Venta = new HashSet<Venta>();
        }

        public int IdProductos { get; set; }
        public string NombreProducto { get; set; }
        public string NombreProductoLargo { get; set; }
        public decimal? Precio { get; set; }
        public int? CantidadExistencia { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
