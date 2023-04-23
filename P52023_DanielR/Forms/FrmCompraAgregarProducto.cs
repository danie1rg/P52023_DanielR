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
    public partial class FrmCompraAgregarProducto : Form
    {

        DataTable ListaProductos { get; set; }

        Producto MiProductoLocal { get; set; }




        public FrmCompraAgregarProducto()
        {
            InitializeComponent();

            ListaProductos= new DataTable();

            MiProductoLocal= new Producto();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.Cancel;
        }

        private void BtnAcceptar_Click(object sender, EventArgs e)
        {
            if (DgvLista.SelectedRows.Count == 1) 
            {
                DataGridViewRow row = DgvLista.SelectedRows[0];

                int IdProducto = Convert.ToInt32(row.Cells["CProductoID"].Value);

                string NombreProducto = Convert.ToString(row.Cells["CProductoNombre"].Value);

                string CodigoBarras = Convert.ToString(row.Cells["CProductoCodigoBarras"].Value);

                decimal Precio = Convert.ToDecimal(row.Cells["CPrecioVentaUnitario"].Value);

                decimal Cantidad = NumUDCantidad.Value;

                DataRow MiFila = Globales.MiFormRegistroCompra.ListaProductos.NewRow();

                MiFila["ProductoID"] = IdProducto;
                MiFila["Cantidad"] = Cantidad;
                MiFila["PrecioVentaUnitario"] = Precio;
                MiFila["ProductoNombre"] = NombreProducto;
                MiFila["ProductoCodigoBarras"] = CodigoBarras;

                Globales.MiFormRegistroCompra.ListaProductos.Rows.Add(MiFila);

                DialogResult = DialogResult.OK;

            }

        }

        private void FrmCompraAgregarProducto_Load(object sender, EventArgs e)
        {
            LlenarLista();
        }

        private void LlenarLista() 
        {
            ListaProductos = new DataTable();

            ListaProductos = MiProductoLocal.ListarEnBusqueda();

            DgvLista.DataSource = ListaProductos;

            DgvLista.ClearSelection();
        }


    }
}
