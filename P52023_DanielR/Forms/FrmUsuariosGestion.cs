using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P52023_DanielR.Forms
{
    public partial class FrmUsuariosGestion : Form
    {

        //por orden es mejor crear objectos locales que permitan 
        //la gestión del tema que estamos tratando
        //usar objectos individuales en las facturas en las función puede provocar desorden
        //y complicar más la lectura del código fuente

        // objecto local para usuario
        private Logica.Models.Usuario MiUsuarioLocal { get; set; }

        //lista, local de usuarios que se visualizan en el datagrid

        private DataTable ListaUsuarios { get; set; }


        public FrmUsuariosGestion()
        {
            InitializeComponent();

            MiUsuarioLocal = new Logica.Models.Usuario();
            ListaUsuarios = new DataTable();
        }

        private void FrmUsuariosGestion_Load(object sender, EventArgs e)
        {
            // definimos el padre mdi
            MdiParent = Globales.MiFormPrincipal;

            CargarListaRoles();
            CargarListaDeUsuarios();
        }


        private void CargarListaDeUsuarios() 
        {
            ListaUsuarios = new DataTable();

            if (CboxVerActivos.Checked) {
                ListaUsuarios = MiUsuarioLocal.ListarActivos();
            } else {
                ListaUsuarios = MiUsuarioLocal.ListarInactivos();
            }

            DtVista.DataSource = ListaUsuarios;
        
        }

        private void CargarListaRoles()
        { 
            Logica.Models.Usuario_Rol MiRol = new Logica.Models.Usuario_Rol();

            DataTable dt = new DataTable();
            dt = MiRol.Listar();

            if (dt != null && dt.Rows.Count > 0)
            {
                CbRolesUsuario.ValueMember = "ID";
                CbRolesUsuario.DisplayMember= "Descrip";
                CbRolesUsuario.DataSource = dt;
                CbRolesUsuario.SelectedIndex = -1;
            }
        
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void DtVista_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DtVista.ClearSelection();
        }

        private void DtVista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //cuando seleccionamos una fla del datagrid se debe cargar la info de dicho usuario
            // en el usuario local y luego dibujar en info en los controles graficos

            if (DtVista.SelectedRows.Count ==1) 
            {
                //limpiar el form



                DataGridViewRow Mifila = DtVista.SelectedRows[0];

                //lo que necesito es el id del usuario para realizar la consulta
                //y traer todos los datos para llenar el objecto de usuario local

                int IdUsuario = Convert.ToInt32(Mifila.Cells["CUsuarioID"].Value);

                //para no asumir riegos se reistancia el usuario local
                MiUsuarioLocal = new Logica.Models.Usuario();

                //ahora le agregamos el valor obtenido por la fila al ID del usuario local
                MiUsuarioLocal.UsuarioID = IdUsuario;

                MiUsuarioLocal = MiUsuarioLocal.ConsultarPorIDRetornaUsuario();

                //validar que el usuario local tenga datos

                if (MiUsuarioLocal != null && MiUsuarioLocal.UsuarioID > 0) 
                {
                    //SI CARGAMOS CORRECTAMENTE EL USUARIO LOCAL LLENAMOS LOS CONTROLES
                    TxtUsuarioID.Text = Convert.ToString(MiUsuarioLocal.UsuarioID);
                    TxtUsuarioNombre.Text = MiUsuarioLocal.UsuarioNombre;
                    TxtUsuarioCedula.Text = MiUsuarioLocal.UsuarioCedula;
                    TxtUsuarioTelefono.Text = MiUsuarioLocal.UsuarioTelefono;
                    TxtUsuarioCorreo.Text = MiUsuarioLocal.UsuarioCorreo;
                    TxtUsuarioDireccion.Text = MiUsuarioLocal.UsuarioDireccion;

                    //con los combobox

                    CbRolesUsuario.SelectedValue = MiUsuarioLocal.MiRolTipo.UsuarioRolID;

                    //todo: desactivar botones 

                
                }

            }

        }
    }
}
