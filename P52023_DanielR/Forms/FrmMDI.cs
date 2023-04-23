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
    public partial class FrmMDI : Form
    {
        public FrmMDI()
        {
            InitializeComponent();
        }

        private void FrmMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void gestiónDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void gestiónDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //control para que el formulario de gestión de usuarios se muestre
            //sola una vez

            if (!Globales.MiFormGestionUsuarios.Visible)
            {
                Globales.MiFormGestionUsuarios = new FrmUsuariosGestion();

                Globales.MiFormGestionUsuarios.Show();
            }
        }

        private void FrmMDI_Load(object sender, EventArgs e)
        {
            //Mostrar el Usuario loqueado
            string InfoUsuario = string.Format("{0}-{1}({2})",
                                               Globales.MiUsuarioGlobal.UsuarioNombre,
                                               Globales.MiUsuarioGlobal.UsuarioCorreo,
                                               Globales.MiUsuarioGlobal.MiRolTipo.UsuarioRolDescripcion);

            LblUsuario.Text = InfoUsuario;

            switch (Globales.MiUsuarioGlobal.MiRolTipo.UsuarioRolID)
            {
                case 1:
                    //sería admin, no se oculta nada
                    break;
                case 2:
                    //sería usuario normal, se deben ocultar algunas opciones de menú 
                    BtnGestiónDeUsuario.Visible = false;
                    rolesDeUsuarioToolStripMenuItem.Visible = false;
                    tiposDeProveedorToolStripMenuItem.Visible = false;
                    tiposDeCompraToolStripMenuItem.Visible = false;
                    break;
            }
        }

        private void rEGISTRODECOMPRASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Globales.MiFormRegistroCompra.Visible)
            {
                Globales.MiFormRegistroCompra = new FrmRegistroCompra();

                Globales.MiFormRegistroCompra.Show();
            }

        }
    }
}
