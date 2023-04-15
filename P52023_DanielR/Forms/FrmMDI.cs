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


            string InfoUsuario = string.Format("{0}-{1}({2})");
        }
    }
}
