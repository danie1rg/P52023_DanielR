﻿using System;
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
    public partial class FrmCompraAgregarProducto : Form
    {
        public FrmCompraAgregarProducto()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.Cancel;
        }

        private void BtnAcceptar_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.OK;
        }
    }
}
