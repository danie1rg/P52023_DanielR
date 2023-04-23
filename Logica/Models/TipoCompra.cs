using Logica.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class TipoCompra
    {
        public int TipoID { get; set; }
        public string CompraTipoDescricion { get; set;}

        public DataTable Listar()
        {
            DataTable R = new DataTable();

            Conexion MiCcn = new Conexion();

            R = MiCcn.EjecutarSELECT("SPTipoCompraListar");

            return R;
        }

    }
}
