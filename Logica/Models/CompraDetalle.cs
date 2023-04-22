using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class CompraDetalle
    {
        public decimal Cantidad { get; set; }

        public decimal PresioUnitario { get;set; }


        //composición

        public Producto MiProducto { get; set; }

        public CompraDetalle()
        {
            MiProducto = new Producto();
        }
    }
}
