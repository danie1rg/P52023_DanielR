using Logica.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Compra
    {
        public int CompraId { get; set; }

        public DateTime CompraFecha { get; set; }

        public int CompraNumero { get; set; }
        public string CompraNotas { get; set;}

        public bool Activo { get; set; }

        //composiciones simples


        public Usuario MiUsuario { get; set; }

        public Proveedor MiProveedor { get; set; }

        public TipoCompra MiTipoCompra { get; set; }


        //composiciones listas o complejas

        public List<CompraDetalle> ListaDetalles { get; set; }


        //constructor

        public Compra() 
        {
            MiUsuario= new Usuario();
            MiProveedor = new Proveedor();
            MiTipoCompra = new TipoCompra();
            ListaDetalles= new List<CompraDetalle>();
        }


        //funciones


        public DataTable CargarEsquemaDetalle() 
        {
            DataTable dt = new DataTable();

            Conexion MiCnn = new Conexion();

            dt = MiCnn.EjecutarSELECT("SPCompraDetalleEsquema", true);

            //como estamos cargando el esquema, tambien viene la indicación del pk
            //se debe anular esa opcion

            dt.PrimaryKey = null;

            return dt;
        }

        public bool Agregar() 
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDProveedor", this.MiProveedor.ProveedorID));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDTipoCompra", this.MiTipoCompra.TipoID));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDUsuario", this.MiUsuario.UsuarioID));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Notas", this.CompraNotas));

            Object retorno = MiCnn.EjecutarSELECTEscalar("SPCompraAgregar");


            int IDCreada;

            if (retorno != null) 
            {
                try
                {
                    IDCreada = Convert.ToInt32(retorno.ToString());

                    this.CompraId = IDCreada;

                    //hasta este punto se puede asegurar que el insert en el encabezado salió correctamente

                    foreach  (CompraDetalle item in ListaDetalles)
                    {
                        Conexion MiCnnDetalle = new Conexion();

                        MiCnnDetalle.ListaDeParametros.Add(new SqlParameter("@CompraID", this.CompraId));

                        MiCnnDetalle.ListaDeParametros.Add(new SqlParameter("@ProductoID", item.MiProducto.ProductoID));

                        MiCnnDetalle.ListaDeParametros.Add(new SqlParameter("@Cantidad", item.Cantidad));

                        MiCnnDetalle.ListaDeParametros.Add(new SqlParameter("@Precio", item.PresioUnitario));

                        MiCnnDetalle.EjecutarInsertUpdateDelete("SPCompraDetalleAgregar");

                    }

                    R = true;

                }
                catch (Exception)
                {

                    throw;
                }

            }


            return R;

        }


    }
}
