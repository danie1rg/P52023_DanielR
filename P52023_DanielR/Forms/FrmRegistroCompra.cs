using Logica.Models;
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
    public partial class FrmRegistroCompra : Form
    {

       
        ///Crear el objecto de compra local
       public Compra MiCompraLocal { get; set; }

        public DataTable ListaProductos { get; set; }


        public FrmRegistroCompra()
        {
            InitializeComponent();

            MiCompraLocal= new Compra();
            ListaProductos= new DataTable();
        }

        private void FrmRegistroCompra_Load(object sender, EventArgs e)
        {
            MdiParent = Globales.MiFormPrincipal;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            ///

            Form FormProveedorBuscar = new FrmProveedorBuscar();

            DialogResult respuesta = FormProveedorBuscar.ShowDialog();


            if (respuesta == DialogResult.OK)
            {
                
                TxtProveedorNombre.Text = MiCompraLocal.MiProveedor.ProveedorNombre;

            }
        }

        private void BtnProducoAgregar_Click(object sender, EventArgs e)
        {
            Form FrmAgregarProducto = new FrmCompraAgregarProducto();

            DialogResult respuesta = FrmAgregarProducto.ShowDialog();

            if(respuesta == DialogResult.OK) 
            {
                DgvLista.DataSource = ListaProductos;
            }
        }
    }
}
