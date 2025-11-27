namespace LabBasesII
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelCasaDeEmpeno = new Label();
            labelSeleccionRol = new Label();
            cmbRol = new ComboBox();
            labelIngreseID = new Label();
            txtIdLogin = new TextBox();
            btnIngresar = new Button();
            SuspendLayout();
            // 
            // labelCasaDeEmpeno
            // 
            labelCasaDeEmpeno.AutoSize = true;
            labelCasaDeEmpeno.Location = new Point(129, 55);
            labelCasaDeEmpeno.Name = "labelCasaDeEmpeno";
            labelCasaDeEmpeno.Size = new Size(96, 15);
            labelCasaDeEmpeno.TabIndex = 0;
            labelCasaDeEmpeno.Text = "Casa De Empeño";
            // 
            // labelSeleccionRol
            // 
            labelSeleccionRol.AutoSize = true;
            labelSeleccionRol.Location = new Point(47, 118);
            labelSeleccionRol.Name = "labelSeleccionRol";
            labelSeleccionRol.Size = new Size(101, 15);
            labelSeleccionRol.TabIndex = 1;
            labelSeleccionRol.Text = "Seleccione su Rol:";
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "Administrador", "Asesor", "Cliente" });
            cmbRol.Location = new Point(47, 136);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(121, 23);
            cmbRol.TabIndex = 2;
            cmbRol.SelectedIndexChanged += cmbRol_SelectedIndexChanged;
            // 
            // labelIngreseID
            // 
            labelIngreseID.AutoSize = true;
            labelIngreseID.Location = new Point(47, 183);
            labelIngreseID.Name = "labelIngreseID";
            labelIngreseID.Size = new Size(77, 15);
            labelIngreseID.TabIndex = 3;
            labelIngreseID.Text = "Ingrese su ID:";
            // 
            // txtIdLogin
            // 
            txtIdLogin.Location = new Point(47, 201);
            txtIdLogin.Name = "txtIdLogin";
            txtIdLogin.Size = new Size(100, 23);
            txtIdLogin.TabIndex = 4;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(47, 241);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(75, 23);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 317);
            Controls.Add(btnIngresar);
            Controls.Add(txtIdLogin);
            Controls.Add(labelIngreseID);
            Controls.Add(cmbRol);
            Controls.Add(labelSeleccionRol);
            Controls.Add(labelCasaDeEmpeno);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelCasaDeEmpeno;
        private Label labelSeleccionRol;
        private ComboBox cmbRol;
        private Label labelIngreseID;
        private TextBox txtIdLogin;
        private Button btnIngresar;
    }
}
