namespace LabBasesII
{
    partial class FormCliente
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
            dgvPrestamos = new DataGridView();
            lblBienvenidaCliente = new Label();
            labelNuevoArticulo = new Label();
            txtNombreArticulo = new TextBox();
            labelTipoArticulo = new Label();
            labelEstado = new Label();
            cmbEstadoArticulo = new ComboBox();
            label1 = new Label();
            btnAgregarArticulo = new Button();
            cmbTipoArticulo = new ComboBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).BeginInit();
            SuspendLayout();
            // 
            // dgvPrestamos
            // 
            dgvPrestamos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrestamos.Location = new Point(21, 119);
            dgvPrestamos.Name = "dgvPrestamos";
            dgvPrestamos.Size = new Size(831, 163);
            dgvPrestamos.TabIndex = 0;
            // 
            // lblBienvenidaCliente
            // 
            lblBienvenidaCliente.AutoSize = true;
            lblBienvenidaCliente.Location = new Point(21, 42);
            lblBienvenidaCliente.Name = "lblBienvenidaCliente";
            lblBienvenidaCliente.Size = new Size(106, 15);
            lblBienvenidaCliente.TabIndex = 1;
            lblBienvenidaCliente.Text = "Bienvenido Cliente";
            // 
            // labelNuevoArticulo
            // 
            labelNuevoArticulo.AutoSize = true;
            labelNuevoArticulo.Location = new Point(21, 285);
            labelNuevoArticulo.Name = "labelNuevoArticulo";
            labelNuevoArticulo.Size = new Size(87, 15);
            labelNuevoArticulo.TabIndex = 2;
            labelNuevoArticulo.Text = "Nuevo Artículo";
            // 
            // txtNombreArticulo
            // 
            txtNombreArticulo.Location = new Point(137, 330);
            txtNombreArticulo.Name = "txtNombreArticulo";
            txtNombreArticulo.Size = new Size(121, 23);
            txtNombreArticulo.TabIndex = 3;
            // 
            // labelTipoArticulo
            // 
            labelTipoArticulo.AutoSize = true;
            labelTipoArticulo.Location = new Point(21, 362);
            labelTipoArticulo.Name = "labelTipoArticulo";
            labelTipoArticulo.Size = new Size(78, 15);
            labelTipoArticulo.TabIndex = 5;
            labelTipoArticulo.Text = "Tipo Artículo:";
            // 
            // labelEstado
            // 
            labelEstado.AutoSize = true;
            labelEstado.Location = new Point(21, 391);
            labelEstado.Name = "labelEstado";
            labelEstado.Size = new Size(45, 15);
            labelEstado.TabIndex = 6;
            labelEstado.Text = "Estado:";
            // 
            // cmbEstadoArticulo
            // 
            cmbEstadoArticulo.AutoCompleteCustomSource.AddRange(new string[] { "optimo", "funcional", "defectuoso" });
            cmbEstadoArticulo.FormattingEnabled = true;
            cmbEstadoArticulo.Items.AddRange(new object[] { "optimo", "funcional", "defectuoso" });
            cmbEstadoArticulo.Location = new Point(137, 388);
            cmbEstadoArticulo.Name = "cmbEstadoArticulo";
            cmbEstadoArticulo.Size = new Size(121, 23);
            cmbEstadoArticulo.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 333);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 8;
            label1.Text = "Nombre Artículo:";
            // 
            // btnAgregarArticulo
            // 
            btnAgregarArticulo.Location = new Point(291, 388);
            btnAgregarArticulo.Name = "btnAgregarArticulo";
            btnAgregarArticulo.Size = new Size(75, 23);
            btnAgregarArticulo.TabIndex = 9;
            btnAgregarArticulo.Text = "Agregar";
            btnAgregarArticulo.UseVisualStyleBackColor = true;
            btnAgregarArticulo.Click += btnAgregarArticulo_Click;
            // 
            // cmbTipoArticulo
            // 
            cmbTipoArticulo.FormattingEnabled = true;
            cmbTipoArticulo.Items.AddRange(new object[] { "electrodomestico", "joya", "herramienta", "vehiculo" });
            cmbTipoArticulo.Location = new Point(137, 359);
            cmbTipoArticulo.Name = "cmbTipoArticulo";
            cmbTipoArticulo.Size = new Size(121, 23);
            cmbTipoArticulo.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(466, 396);
            label2.Name = "label2";
            label2.Size = new Size(226, 15);
            label2.TabIndex = 11;
            label2.Text = "*Doble click en el artículo para eliminarlo.";
            // 
            // FormCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(877, 450);
            Controls.Add(label2);
            Controls.Add(cmbTipoArticulo);
            Controls.Add(btnAgregarArticulo);
            Controls.Add(label1);
            Controls.Add(cmbEstadoArticulo);
            Controls.Add(labelEstado);
            Controls.Add(labelTipoArticulo);
            Controls.Add(txtNombreArticulo);
            Controls.Add(labelNuevoArticulo);
            Controls.Add(lblBienvenidaCliente);
            Controls.Add(dgvPrestamos);
            Name = "FormCliente";
            Text = "FormCliente";
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPrestamos;
        private Label lblBienvenidaCliente;
        private Label labelNuevoArticulo;
        private TextBox txtNombreArticulo;
        private Label labelTipoArticulo;
        private Label labelEstado;
        private ComboBox cmbEstadoArticulo;
        private Label label1;
        private Button btnAgregarArticulo;
        private ComboBox cmbTipoArticulo;
        private Label label2;
    }
}