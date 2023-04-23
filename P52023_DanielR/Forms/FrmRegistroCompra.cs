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

            CargarTiposDeCompra();

            LimpiarForm();
        }


        private void CargarTiposDeCompra() 
        {
            DataTable dt = new DataTable();
            dt = MiCompraLocal.MiTipoCompra.Listar();

            CbTipoCompra.ValueMember = "ID";
            CbTipoCompra.DisplayMember = "descripcion";

            CbTipoCompra.DataSource = dt;

            CbTipoCompra.SelectedIndex = -1;
        }

        private void LimpiarForm() 
        {
            TxtProveedorNombre.Clear();
            TxtNotas.Clear();
            TxtTotal.Text = "0";
            TxtCantidadProductos.Text = "0";
            CbTipoCompra.SelectedIndex = -1;

            ListaProductos = new DataTable();

            ListaProductos = MiCompraLocal.CargarEsquemaDetalle();

            DgvLista.DataSource = ListaProductos;
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

                Totalizar();
            }
        }


        private void Totalizar() 
        {
            if (ListaProductos.Rows.Count > 0)
            {

                decimal totalItems = 0;
                decimal totalMonto = 0;

                foreach (DataRow row in ListaProductos.Rows) 
                {
                    totalItems += Convert.ToDecimal(row["Cantidad"]);
                    
                    totalMonto += Convert.ToDecimal(row["PrecioVentaUnitario"]) * Convert.ToDecimal(row["Cantidad"]);
                }

                TxtCantidadProductos.Text = totalItems.ToString();

                TxtTotal.Text = string.Format("{0:C2}",totalMonto);


            }

        }

        private void BtnCompra_Click(object sender, EventArgs e)
        {
            //primero se valida que se haya selecionado un proveedor, tipo de compra
            //y que se haya como minimo una linea en el detale


            if (ValidarCompra())
            {
                //los pasos para agregar un encabezado-detalle son:
                //1. realizar inert en el encabezado y recolectar el id recién creado,

                MiCompraLocal.MiTipoCompra.TipoID = Convert.ToInt32(CbTipoCompra.SelectedValue);

                MiCompraLocal.CompraNotas = TxtNotas.Text.Trim();

                MiCompraLocal.MiUsuario.UsuarioID = 1;

                TrasladoListaVisualAObjectoCompra();

                if (MiCompraLocal.Agregar()) 
                {
                    MessageBox.Show("Compra creada correctamente", ":)", MessageBoxButtons.OK);

                    LimpiarForm();
                }

            }

        }

        private void TrasladoListaVisualAObjectoCompra() 
        {
            //pasamos los datos del datatable que se usa graficmente a la list<> del objecto MiCOmpraLocal

            foreach (DataRow fila in ListaProductos.Rows)
            {
                CompraDetalle nuevoDetalle = new CompraDetalle();

                nuevoDetalle.MiProducto.ProductoID = Convert.ToInt32(fila["ProductoID"]);
                nuevoDetalle.Cantidad = Convert.ToDecimal(fila["Cantidad"]);
                nuevoDetalle.PresioUnitario = Convert.ToDecimal(fila["PrecioVentaUnitario"]);


                MiCompraLocal.ListaDetalles.Add(nuevoDetalle);

            }

        }

        private bool ValidarCompra() 
        {
            bool R = false;

            if (!string.IsNullOrEmpty(TxtProveedorNombre.Text.Trim()) &&
                CbTipoCompra.SelectedIndex >= 0 &&
                ListaProductos.Rows.Count > 0)
            {
                R = true;

            }
            else 
            {
                if (string.IsNullOrEmpty(TxtProveedorNombre.Text.Trim())) 
                {
                    MessageBox.Show("Se debe seleccionar un proveedor", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }

                if (CbTipoCompra.SelectedIndex == -1) 
                {
                    MessageBox.Show("Se debe seleccionar un tipo de Compra", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }

                if (ListaProductos.Rows.Count == 0) 
                {
                    MessageBox.Show("Debe de haber un articulo", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
            }


            return R;
        }


    }
}
