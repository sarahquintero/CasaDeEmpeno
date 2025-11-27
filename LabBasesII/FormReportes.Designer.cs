namespace LabBasesII
{
    partial class FormReportes
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
            lblTituloReporte = new Label();
            lblBienvenidaAsesor = new Label();
            dgvReporte2 = new DataGridView();
            btnCargarReporte2 = new Button();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReporte2).BeginInit();
            SuspendLayout();
            // 
            // lblTituloReporte
            // 
            lblTituloReporte.AutoSize = true;
            lblTituloReporte.Location = new Point(42, 42);
            lblTituloReporte.Name = "lblTituloReporte";
            lblTituloReporte.Size = new Size(219, 15);
            lblTituloReporte.TabIndex = 0;
            lblTituloReporte.Text = "Reporte de Conteo de Artículos por Tipo";
            // 
            // lblBienvenidaAsesor
            // 
            lblBienvenidaAsesor.AutoSize = true;
            lblBienvenidaAsesor.Location = new Point(42, 68);
            lblBienvenidaAsesor.Name = "lblBienvenidaAsesor";
            lblBienvenidaAsesor.Size = new Size(38, 15);
            lblBienvenidaAsesor.TabIndex = 1;
            lblBienvenidaAsesor.Text = "label1";
            // 
            // dgvReporte2
            // 
            dgvReporte2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte2.Location = new Point(42, 113);
            dgvReporte2.Name = "dgvReporte2";
            dgvReporte2.Size = new Size(770, 150);
            dgvReporte2.TabIndex = 2;
            // 
            // btnCargarReporte2
            // 
            btnCargarReporte2.Location = new Point(42, 306);
            btnCargarReporte2.Name = "btnCargarReporte2";
            btnCargarReporte2.Size = new Size(75, 23);
            btnCargarReporte2.TabIndex = 3;
            btnCargarReporte2.Text = "Cargar Reporte";
            btnCargarReporte2.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(42, 376);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 4;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // FormReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(873, 450);
            Controls.Add(btnVolver);
            Controls.Add(btnCargarReporte2);
            Controls.Add(dgvReporte2);
            Controls.Add(lblBienvenidaAsesor);
            Controls.Add(lblTituloReporte);
            Name = "FormReportes";
            Text = "FormReportes";
            ((System.ComponentModel.ISupportInitialize)dgvReporte2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloReporte;
        private Label lblBienvenidaAsesor;
        private DataGridView dgvReporte2;
        private Button btnCargarReporte2;
        private Button btnVolver;
    }
}