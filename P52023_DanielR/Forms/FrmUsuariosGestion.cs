using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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

            ActivarAgregar();
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


        private void ActivarAgregar() 
        {
            BtnAgregar.Enabled = true;
            BtnModificar.Enabled = false;
            BtnEliminar.Enabled = false;
        }

        private void ActivarEditarEliminar()
        {
            BtnAgregar.Enabled = false;
            BtnModificar.Enabled = true;
            BtnEliminar.Enabled = true;
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
                    ActivarEditarEliminar();



                }

            }

        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarForm();

            DtVista.ClearSelection();

            ActivarAgregar();

        }

        private void LimpiarForm() {
            TxtUsuarioCedula.Clear();
            TxtUsuarioID.Clear();
            TxtUsuarioNombre.Clear();
            TxtUsuarioTelefono.Clear();
            TxtUsuarioCorreo.Clear();
            TxtUsuarioContrasennia.Clear();
            CbRolesUsuario.SelectedIndex = -1;
            TxtUsuarioDireccion.Clear();
            
        }

        private bool ValidarDatosDigitados(bool OmitirPassword = false) 
        {
            bool r = false;

            if (!string.IsNullOrEmpty(TxtUsuarioNombre.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUsuarioCedula.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUsuarioCorreo.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUsuarioTelefono.Text.Trim()) &&
                CbRolesUsuario.SelectedIndex > -1
                )
            {
                if (OmitirPassword) 
                {
                    r = true;
                }
                else 
                {
                    if (!string.IsNullOrEmpty(TxtUsuarioContrasennia.Text.Trim()))
                    {
                        r = true;
                    }
                    else 
                    {
                        if (string.IsNullOrEmpty(TxtUsuarioContrasennia.Text.Trim()))
                        {
                            MessageBox.Show("Debe de digitar una contraseña para el usuario", "Error de validación", MessageBoxButtons.OK);
                            TxtUsuarioContrasennia.Focus();
                            return false;
                        }
                    }
                }
               
            
            } else 
            {
                if (string.IsNullOrEmpty(TxtUsuarioNombre.Text.Trim())) 
                {
                    MessageBox.Show("Debe de digitar un nombre para el usuario", "Error de validación", MessageBoxButtons.OK);
                    TxtUsuarioNombre.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(TxtUsuarioCedula.Text.Trim())) 
                {
                    MessageBox.Show("Debe de digitar una cédula para el usuario", "Error de validación", MessageBoxButtons.OK);
                    TxtUsuarioCedula.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(TxtUsuarioCorreo.Text.Trim())) 
                {
                    MessageBox.Show("Debe de digitar un correo para el usuario", "Error de validación", MessageBoxButtons.OK);
                    TxtUsuarioCorreo.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(TxtUsuarioTelefono.Text.Trim())) 
                {
                    MessageBox.Show("Debe de digitar un télefono para el usuario", "Error de validación", MessageBoxButtons.OK);
                    TxtUsuarioTelefono.Focus();
                    return false;
                }

                if (CbRolesUsuario.SelectedIndex ==-1) 
                {
                    MessageBox.Show("Debe de digitar un rol para el usuario", "Error de validación", MessageBoxButtons.OK);
                    CbRolesUsuario.Focus();
                    return false;
                }
            }

            return r;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosDigitados())
            {

                bool cedulaOk;
                bool EmailOk;

                MiUsuarioLocal = new Logica.Models.Usuario();


                MiUsuarioLocal.UsuarioNombre = TxtUsuarioNombre.Text.Trim();
                MiUsuarioLocal.UsuarioCedula = TxtUsuarioCedula.Text.Trim();
                MiUsuarioLocal.UsuarioCorreo = TxtUsuarioCorreo.Text.Trim();
                MiUsuarioLocal.UsuarioTelefono = TxtUsuarioTelefono.Text.Trim();
                MiUsuarioLocal.UsuarioContrasennia = TxtUsuarioContrasennia.Text.Trim();
                MiUsuarioLocal.MiRolTipo.UsuarioRolID = Convert.ToInt32(CbRolesUsuario.SelectedValue);
                MiUsuarioLocal.UsuarioDireccion = TxtUsuarioDireccion.Text.Trim();


                //realizar las consultas por email y cedula

                cedulaOk = MiUsuarioLocal.ConsultarPorCedula();

                EmailOk = MiUsuarioLocal.ConsultarPorEmail();

                if (cedulaOk == false && EmailOk == false)
                {
                    //se solicita confirmación que si quiere agregar el usuario

                    string msg = string.Format("¿Está seguro que desea agregar al usuario {0}?", MiUsuarioLocal.UsuarioNombre);

                    DialogResult respuesta = MessageBox.Show(msg, "???", MessageBoxButtons.YesNo);

                    if (respuesta == DialogResult.Yes)
                    {
                        bool ok = MiUsuarioLocal.Agregar();

                        if (ok)
                        {
                            MessageBox.Show("Usuario guardado correctamente!", ":)", MessageBoxButtons.OK);

                            LimpiarForm();

                            CargarListaDeUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("Usuario no se pudo guardar correctamente!", ":(", MessageBoxButtons.OK);
                        }


                    }

                }
                else
                {
                    if (cedulaOk)
                    {
                        MessageBox.Show("Ya existe un usuario con la cédula digitada", "Error de validación", MessageBoxButtons.OK);
                        return;
                    }

                    if (EmailOk)
                    {
                        MessageBox.Show("Ya existe un usuario con el correo digitada", "Error de validación", MessageBoxButtons.OK);
                        return;
                    }

                }


            }



        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosDigitados(true)) 
            {
                // no es necesario capturar el ID desde el cuadro de texto ya que al consultarlo (al seleccionarlo el usuario en el data grid)
                //ya tenemos datos en el id

                MiUsuarioLocal.UsuarioNombre = TxtUsuarioNombre.Text.Trim();
                MiUsuarioLocal.UsuarioCedula = TxtUsuarioCedula.Text.Trim();
                MiUsuarioLocal.UsuarioCorreo = TxtUsuarioCorreo.Text.Trim();
                MiUsuarioLocal.UsuarioTelefono = TxtUsuarioTelefono.Text.Trim();
                MiUsuarioLocal.UsuarioContrasennia = TxtUsuarioContrasennia.Text.Trim();
                MiUsuarioLocal.MiRolTipo.UsuarioRolID = Convert.ToInt32(CbRolesUsuario.SelectedValue);
                MiUsuarioLocal.UsuarioDireccion = TxtUsuarioDireccion.Text.Trim();

                if (MiUsuarioLocal.ConsultarPorID()) 
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro de modificar el usuario?", "???", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes) 
                    {
                        if (MiUsuarioLocal.Editar()) 
                        {
                            MessageBox.Show("Usuario ha sido modificado correctamente!", ":)", MessageBoxButtons.OK);

                            LimpiarForm();
                            CargarListaDeUsuarios();
                        }
                    }
                }
                
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (MiUsuarioLocal.UsuarioID > 0 && MiUsuarioLocal.ConsultarPorID()) 
            {
                if (CboxVerActivos.Checked)
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar al usuario?", "???",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        if (MiUsuarioLocal.Eliminar())
                        {
                            MessageBox.Show("Usuario ha sido eliminado correctamente!", ":)", MessageBoxButtons.OK);

                            LimpiarForm();
                            CargarListaDeUsuarios();
                        }
                    }
                }
                else 
                {

                }

            }
        }
    }
}
