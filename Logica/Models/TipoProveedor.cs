using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
   public class TipoProveedor
    {
        public int ProveedorTipo { get; set; }
        public string ProvedorTipoDescripcion { get; set;}

        public DataTable Listar()
        {
            DataTable R = new DataTable();

            //código funcional

            return R;
        }
    }
}
