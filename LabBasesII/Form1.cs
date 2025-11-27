// Asegúrate de que estos 'using' existan en la parte superior del archivo
using System.Windows.Forms;
using System;
using LabBasesII.Data;
using LabBasesII.Utils;
using Oracle.ManagedDataAccess.Client;

namespace LabBasesII
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Casa de Empeño";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            int idUsuario;
            string nombreUsuario = string.Empty;

            string rolSeleccionado = cmbRol.SelectedItem.ToString();
            if (!int.TryParse(txtIdLogin.Text, out idUsuario))
            {
                MessageBox.Show("❌ Debe ingresar un ID de usuario válido.", "Error de Entrada");
                return;
            }
            try
            {
                nombreUsuario = PersonaDAO.ObtenerDatosPorRol(idUsuario, rolSeleccionado);

                if (nombreUsuario.StartsWith("❌ Error"))
                {
                    MessageBox.Show(nombreUsuario, "Error de Login");
                    return;
                }
                if (rolSeleccionado == "Cliente")
                {
                    this.Hide();
                    var formCliente = new FormCliente(idUsuario, nombreUsuario);
                    formCliente.Closed += (s, args) => this.Show();
                    formCliente.Show();
                }
                else if (rolSeleccionado == "Administrador" || rolSeleccionado == "Asesor")
                {
                    this.Hide();
                    var formReportes = new FormReportes(idUsuario, nombreUsuario, rolSeleccionado);
                    formReportes.Closed += (s, args) => this.Show();
                    formReportes.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error Fatal: {ex.Message}", "Error");
            }
        }

        private void labelCasaDeEmpeno_Click(object sender, EventArgs e)
        {

        }
    }
}
