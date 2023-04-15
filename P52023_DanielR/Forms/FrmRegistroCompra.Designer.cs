namespace P52023_DanielR.Forms
{
    partial class FrmRegistroCompra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistroCompra));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtProveedorNombre = new System.Windows.Forms.TextBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CbTipoCompra = new System.Windows.Forms.ComboBox();
            this.TxtNotas = new System.Windows.Forms.TextBox();
            this.Notas = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnProducoAgregar = new System.Windows.Forms.ToolStripButton();
            this.BtnEditarProducto = new System.Windows.Forms.ToolStripButton();
            this.BtnEliminar = new System.Windows.Forms.ToolStripButton();
            this.DgvLista = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCantidadProductos = new System.Windows.Forms.TextBox();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnCompra = new System.Windows.Forms.Button();
            this.CProductoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CProductoCodigoBarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CProductoNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPrecioVentaUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Notas);
            this.groupBox1.Controls.Add(this.TxtNotas);
            this.groupBox1.Controls.Add(this.CbTipoCompra);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.BtnBuscar);
            this.groupBox1.Controls.Add(this.TxtProveedorNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(21, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(970, 232);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compra";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DgvLista);
            this.groupBox2.Controls.Add(this.toolStrip1);
            this.groupBox2.Location = new System.Drawing.Point(21, 271);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(969, 247);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Compra Detalle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedor";
            // 
            // TxtProveedorNombre
            // 
            this.TxtProveedorNombre.Location = new System.Drawing.Point(99, 36);
            this.TxtProveedorNombre.Name = "TxtProveedorNombre";
            this.TxtProveedorNombre.Size = new System.Drawing.Size(466, 22);
            this.TxtProveedorNombre.TabIndex = 1;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(571, 35);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(75, 23);
            this.BtnBuscar.TabIndex = 2;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tipo de Compra:";
            // 
            // CbTipoCompra
            // 
            this.CbTipoCompra.FormattingEnabled = true;
            this.CbTipoCompra.Location = new System.Drawing.Point(137, 76);
            this.CbTipoCompra.Name = "CbTipoCompra";
            this.CbTipoCompra.Size = new System.Drawing.Size(235, 24);
            this.CbTipoCompra.TabIndex = 4;
            // 
            // TxtNotas
            // 
            this.TxtNotas.Location = new System.Drawing.Point(137, 121);
            this.TxtNotas.Multiline = true;
            this.TxtNotas.Name = "TxtNotas";
            this.TxtNotas.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtNotas.Size = new System.Drawing.Size(435, 81);
            this.TxtNotas.TabIndex = 5;
            // 
            // Notas
            // 
            this.Notas.AutoSize = true;
            this.Notas.Location = new System.Drawing.Point(23, 121);
            this.Notas.Name = "Notas";
            this.Notas.Size = new System.Drawing.Size(43, 16);
            this.Notas.TabIndex = 6;
            this.Notas.Text = "Notas";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnProducoAgregar,
            this.BtnEditarProducto,
            this.BtnEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 18);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1204, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnProducoAgregar
            // 
            this.BtnProducoAgregar.BackColor = System.Drawing.Color.LimeGreen;
            this.BtnProducoAgregar.Image = ((System.Drawing.Image)(resources.GetObject("BtnProducoAgregar.Image")));
            this.BtnProducoAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnProducoAgregar.Name = "BtnProducoAgregar";
            this.BtnProducoAgregar.Size = new System.Drawing.Size(151, 36);
            this.BtnProducoAgregar.Text = "Agregar Producto";
            // 
            // BtnEditarProducto
            // 
            this.BtnEditarProducto.Image = ((System.Drawing.Image)(resources.GetObject("BtnEditarProducto.Image")));
            this.BtnEditarProducto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnEditarProducto.Name = "BtnEditarProducto";
            this.BtnEditarProducto.Size = new System.Drawing.Size(136, 36);
            this.BtnEditarProducto.Text = "Editar Producto";
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("BtnEliminar.Image")));
            this.BtnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(151, 36);
            this.BtnEliminar.Text = "Eliminar Producto";
            // 
            // DgvLista
            // 
            this.DgvLista.AllowUserToAddRows = false;
            this.DgvLista.AllowUserToDeleteRows = false;
            this.DgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CProductoID,
            this.CProductoCodigoBarras,
            this.CProductoNombre,
            this.CCantidad,
            this.CPrecioVentaUnitario});
            this.DgvLista.Location = new System.Drawing.Point(6, 61);
            this.DgvLista.Name = "DgvLista";
            this.DgvLista.ReadOnly = true;
            this.DgvLista.RowHeadersVisible = false;
            this.DgvLista.RowHeadersWidth = 51;
            this.DgvLista.RowTemplate.Height = 24;
            this.DgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvLista.Size = new System.Drawing.Size(943, 177);
            this.DgvLista.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtTotal);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.TxtCantidadProductos);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(27, 524);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(960, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Totales";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(126, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(301, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "CANTIDAD DE PRODUCTOS";
            // 
            // TxtCantidadProductos
            // 
            this.TxtCantidadProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCantidadProductos.Location = new System.Drawing.Point(168, 28);
            this.TxtCantidadProductos.Name = "TxtCantidadProductos";
            this.TxtCantidadProductos.Size = new System.Drawing.Size(230, 34);
            this.TxtCantidadProductos.TabIndex = 1;
            this.TxtCantidadProductos.Text = "0";
            this.TxtCantidadProductos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtTotal
            // 
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.Location = new System.Drawing.Point(629, 28);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.Size = new System.Drawing.Size(230, 34);
            this.TxtTotal.TabIndex = 3;
            this.TxtTotal.Text = "0";
            this.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(701, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "TOTAL";
            // 
            // BtnCompra
            // 
            this.BtnCompra.BackColor = System.Drawing.Color.LimeGreen;
            this.BtnCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCompra.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnCompra.Location = new System.Drawing.Point(388, 630);
            this.BtnCompra.Name = "BtnCompra";
            this.BtnCompra.Size = new System.Drawing.Size(303, 43);
            this.BtnCompra.TabIndex = 3;
            this.BtnCompra.Text = "Crear Compra";
            this.BtnCompra.UseVisualStyleBackColor = false;
            // 
            // CProductoID
            // 
            this.CProductoID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CProductoID.DataPropertyName = "ProductoID";
            this.CProductoID.HeaderText = "Cód. Producto";
            this.CProductoID.MinimumWidth = 6;
            this.CProductoID.Name = "CProductoID";
            this.CProductoID.ReadOnly = true;
            this.CProductoID.Width = 125;
            // 
            // CProductoCodigoBarras
            // 
            this.CProductoCodigoBarras.DataPropertyName = "ProductoCodigoBarras";
            this.CProductoCodigoBarras.HeaderText = "Código de barra";
            this.CProductoCodigoBarras.MinimumWidth = 6;
            this.CProductoCodigoBarras.Name = "CProductoCodigoBarras";
            this.CProductoCodigoBarras.ReadOnly = true;
            this.CProductoCodigoBarras.Width = 200;
            // 
            // CProductoNombre
            // 
            this.CProductoNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CProductoNombre.DataPropertyName = "ProductoNombre";
            this.CProductoNombre.HeaderText = "Producto";
            this.CProductoNombre.MinimumWidth = 6;
            this.CProductoNombre.Name = "CProductoNombre";
            this.CProductoNombre.ReadOnly = true;
            // 
            // CCantidad
            // 
            this.CCantidad.DataPropertyName = "Cantidad";
            this.CCantidad.HeaderText = "Cantidad";
            this.CCantidad.MinimumWidth = 6;
            this.CCantidad.Name = "CCantidad";
            this.CCantidad.ReadOnly = true;
            this.CCantidad.Width = 125;
            // 
            // CPrecioVentaUnitario
            // 
            this.CPrecioVentaUnitario.DataPropertyName = "PrecioVentaUnitario";
            this.CPrecioVentaUnitario.HeaderText = "Precio Unitario";
            this.CPrecioVentaUnitario.MinimumWidth = 6;
            this.CPrecioVentaUnitario.Name = "CPrecioVentaUnitario";
            this.CPrecioVentaUnitario.ReadOnly = true;
            this.CPrecioVentaUnitario.Width = 125;
            // 
            // FrmRegistroCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 688);
            this.Controls.Add(this.BtnCompra);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRegistroCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Compra";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtProveedorNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Notas;
        private System.Windows.Forms.TextBox TxtNotas;
        private System.Windows.Forms.ComboBox CbTipoCompra;
        private System.Windows.Forms.DataGridView DgvLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProductoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProductoCodigoBarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProductoNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPrecioVentaUnitario;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnProducoAgregar;
        private System.Windows.Forms.ToolStripButton BtnEditarProducto;
        private System.Windows.Forms.ToolStripButton BtnEliminar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtCantidadProductos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnCompra;
    }
}