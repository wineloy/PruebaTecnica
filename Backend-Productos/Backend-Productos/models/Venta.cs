using System;
using System.Collections.Generic;

#nullable disable

namespace Backend_Productos.Models
{
    public partial class Venta
    {
        public int IdVenta { get; set; }
        public int? IdProductos { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? PrecioVenta { get; set; }
        public int? Cantidad { get; set; }
        public virtual Producto IdProductosNavigation { get; set; }

    }
}
