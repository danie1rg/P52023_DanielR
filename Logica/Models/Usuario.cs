using Logica.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Logica.Models
{
    public class Usuario
    {
        //propiedades simples
        public int UsuarioID { get; set; }

        public string UsuarioCorreo { get; set; }

        public string UsuarioContrasennia { get; set; }

        public string UsuarioNombre { get; set; }
        public string UsuarioCedula { get; set; }

        public string UsuarioTelefono { get; set; }

        public string UsuarioDireccion { get; set; }

        public bool Activo { get; set; }


        //propiedades compuestas

        public Usuario_Rol MiRolTipo { get; set; }

        //normalmente cuando tenemos propiedades compuestas con tipos que hemos programado nosotros mismo, debemos
        //instanciar dichas propiedades ya que on objectos. Para esto recomienda hacerlo en el contructor de la clase

        public Usuario() {
            //al crear una nueva instancia de la clase usuario, se ejecuta el código de este contructor, y tambien 
            //se crea una nueva instacia de la clase usuario_rol para el objecto para el objecto MiRolTipo
            MiRolTipo = new Usuario_Rol();
        }

        //funciones y metodos

        public bool Agregar() {

            //cuando la función devuelve un bool me gusta inicializar la variable de retorno en false (tienede a negativo el resultado)
            //y SOLO si la operación (en este caso Insert) sale correcta
            //se cambia el valor de R a true
            bool R = false;

            Conexion MiCnn = new Conexion();

            Crypto MiEncrip = new Crypto();

            string ContrasenniaEncriptada = MiEncrip.EncriptarEnUnSentido(this.UsuarioContrasennia);
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Contrasennia", ContrasenniaEncriptada));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.UsuarioCedula));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.UsuarioNombre));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Telefono", this.UsuarioTelefono));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", this.UsuarioCorreo));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Direccion", this.UsuarioDireccion));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDRol", this.MiRolTipo.UsuarioRolID));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPUsuariosAgregar");

            if (resultado > 0) 
            {
                R = true;
            }



            return R;
        }

        public bool Editar() {
            bool R = false;

            Conexion MiCnn = new Conexion();

            Crypto MiEncrip = new Crypto();

            string ContrasenniaEncriptada = MiEncrip.EncriptarEnUnSentido(this.UsuarioContrasennia);
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Contrasennia", ContrasenniaEncriptada));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.UsuarioCedula));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.UsuarioNombre));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Telefono", this.UsuarioTelefono));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", this.UsuarioCorreo));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Direccion", this.UsuarioDireccion));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDRol", this.MiRolTipo.UsuarioRolID));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.UsuarioID));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPUsuariosModificar");

            if (resultado > 0)
            {
                R = true;
            }

            return R;
        }

        public bool Eliminar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.UsuarioID));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPUsuarioDesactivar");

            if (resultado > 0)
            {
                R = true;
            }
            return R;
        }


        public bool ConsultarPorID()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("ID", this.UsuarioID));


            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPUsuarioConsultarPorID");

            if (dt != null && dt.Rows.Count > 0)
            {
                R = true;

            }

            return R;
        }

        public Usuario ConsultarPorIDRetornaUsuario()
        {
            Usuario R = new Usuario();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("ID", this.UsuarioID));

            //necesito un datable

            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPUsuarioConsultarPorID");

            if (dt != null && dt.Rows.Count > 0) 
            { 
                //esta consulta deberia tener solo un registro por dt [0]
                DataRow dr = dt.Rows[0];

                
                R.UsuarioID = Convert.ToInt32(dr["UsuarioID"]);
                R.UsuarioCedula = Convert.ToString(dr["UsuarioCedula"]);
                R.UsuarioNombre = Convert.ToString(dr["UsuarioNombre"]);
                R.UsuarioCorreo = Convert.ToString(dr["UsuarioCorreo"]);
                R.UsuarioTelefono = Convert.ToString(dr["UsuarioTelefono"]);
                R.UsuarioDireccion = Convert.ToString(dr["UsuarioDireccion"]);

                R.UsuarioContrasennia = string.Empty;

                //composiciones
                R.MiRolTipo.UsuarioRolID = Convert.ToInt32(dr["UsuarioRolID"]);
                R.MiRolTipo.UsuarioRolDescripcion = Convert.ToString(dr["UsuarioRolDescripcion"]);


            }

            return R;
        }

        public bool ConsultarPorCedula()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@cedula", this.UsuarioCedula));

            DataTable consulta = new DataTable();
            consulta = MiCnn.EjecutarSELECT("SPConsultarPorCedula");

            if (consulta != null && consulta.Rows.Count > 0) {
                R = true;
            }

            return R;
        }

        public bool ConsultarPorEmail()
        {
            bool R = false;
            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@email", this.UsuarioCorreo));

            DataTable consulta = new DataTable();
            consulta = MiCnn.EjecutarSELECT("SPConsultarPorEmail");

            if (consulta != null && consulta.Rows.Count > 0)
            {
                R = true;
            }
            return R;
        }

        public DataTable ListarActivos(string pFiltroBusqueda) { 
            DataTable R = new DataTable();

            Conexion Micnn = new Conexion();

            //en este caso como el SP tiene un parametro, debemos por lo tanto definir ese pa´rametro
            //en la lista de párametros  en la lista de parametros del objecto de conexión

            Micnn.ListaDeParametros.Add(new SqlParameter("@VerActivos", true));
            Micnn.ListaDeParametros.Add(new SqlParameter("@FiltroBusqueda", pFiltroBusqueda));

            R = Micnn.EjecutarSELECT("SPUsuarioListar");

            return R;
        }

        public DataTable ListarInactivos(string pFiltroBusqueda)
        {
            DataTable R = new DataTable();

            Conexion Micnn = new Conexion();

            Micnn.ListaDeParametros.Add(new SqlParameter("@VerActivos", false));
            Micnn.ListaDeParametros.Add(new SqlParameter("@FiltroBusqueda", pFiltroBusqueda));

            R = Micnn.EjecutarSELECT("SPUsuarioListar");

            return R;
        }

        public Usuario ValidarUsuario(string pEmail, string pContrasennia) 
        {

            Usuario R = new Usuario();

            Conexion MiCnn = new Conexion();

            Crypto crypto = new Crypto();
            string ContrasenniaEncriptada = crypto.EncriptarEnUnSentido(pContrasennia);

            MiCnn.ListaDeParametros.Add(new SqlParameter("@usuario", pEmail));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@password", ContrasenniaEncriptada));

            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPUsuarioValidarIngreso");

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                R.UsuarioID = Convert.ToInt32(dr["UsuarioID"]);
                R.UsuarioNombre = Convert.ToString(dr["UsuarioNombre"]);

                R.UsuarioCedula = Convert.ToString(dr["UsuarioCedula"]);
                R.UsuarioCorreo = Convert.ToString(dr["UsuarioCorreo"]);
                R.UsuarioTelefono = Convert.ToString(dr["UsuarioTelefono"]);
                R.UsuarioDireccion = Convert.ToString(dr["UsuarioDireccion"]);

                R.UsuarioContrasennia = string.Empty;

                //composiciones
                R.MiRolTipo.UsuarioRolID = Convert.ToInt32(dr["UsuarioRolID"]);
                R.MiRolTipo.UsuarioRolDescripcion = Convert.ToString(dr["UsuarioRolDescripcion"]);

            }

            return R;
        }

        public bool ActivarUsuario() 
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.UsuarioID));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPUsuarioActivar");

            if (resultado > 0)
            {
                R = true;
            }
            return R;
        }













    }
}
