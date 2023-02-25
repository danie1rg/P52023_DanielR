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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            //close form or app
            Application.Exit();
        }

        private void BtnVer_MouseDown(object sender, MouseEventArgs e)
        {
            TxtContra.UseSystemPasswordChar = false;
        }

        private void BtnVer_MouseUp(object sender, MouseEventArgs e)
        {
            TxtContra.UseSystemPasswordChar = true;
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            Globales.MiFormPrincipal.Show();
            this.Hide();
        }
    }
}
