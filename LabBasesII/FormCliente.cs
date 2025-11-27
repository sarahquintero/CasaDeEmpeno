// FormCliente.cs
using System;
using System.Data;
using System.Windows.Forms;
using LabBasesII.Data; // Acceso a los DAOs
using Oracle.ManagedDataAccess.Client;

namespace LabBasesII
{
    public partial class FormCliente : Form
    {
        private readonly int _idCliente;

        public FormCliente(int idCliente, string nombreCliente)
        {
            InitializeComponent();
            _idCliente = idCliente;
            lblBienvenidaCliente.Text = $"Bienvenido Cliente: {nombreCliente} (ID: {idCliente})";
            this.Text = "Panel de Cliente";
            this.dgvPrestamos.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvPrestamos_CellDoubleClick);
            CargarDatosPrestamos();
        }

        private void CargarDatosPrestamos()
        {
            try
            {
                // Llamar al nuevo método que retorna Artículos Y Préstamos
                DataTable articulos = PersonaDAO.ObtenerArticulosYPrestamosPorCliente(_idCliente);

                dgvPrestamos.DataSource = articulos;
                dgvPrestamos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                // El error de VALOR_TAZADO ya fue resuelto
                MessageBox.Show($"Error al cargar Artículos y Préstamos: {ex.Message}", "Error de BD");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreArticulo.Text.Trim();
            string tipo = cmbTipoArticulo.SelectedItem?.ToString();
            string estado = cmbEstadoArticulo.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(tipo) || string.IsNullOrEmpty(estado))
            {
                MessageBox.Show("❌ Todos los campos de Artículo son obligatorios.", "Error de Entrada");
                return;
            }

            try
            {
                LabBasesII.Data.ArticuloDAO.AgregarArticulo(nombre, tipo, estado, _idCliente);

                MessageBox.Show($"✅ Artículo '{nombre}' ingresado con éxito para el Cliente {_idCliente}.\n¡Se activó el Trigger de Auditoría!", "Éxito");

                txtNombreArticulo.Clear();
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                if (ex.Number >= 20000 && ex.Number <= 20999)
                {
                    MessageBox.Show($"❌ Error de Negocio (PL/SQL): {ex.Message}", "Error BD");
                }
                else
                {
                    MessageBox.Show($"❌ Error de Base de Datos (ORA-{ex.Number}): {ex.Message}", "Error Fatal");
                }
            }
        }

        private void dgvPrestamos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (!int.TryParse(dgvPrestamos.Rows[e.RowIndex].Cells["ID_ARTICULO"].Value?.ToString(), out int idArticulo))
            {
                MessageBox.Show("❌ No se pudo obtener el ID del Artículo seleccionado.", "Error de Selección");
                return;
            }

            string nombreArticulo = dgvPrestamos.Rows[e.RowIndex].Cells["NOMBRE_ARTICULO"].Value?.ToString();

            var resultado = MessageBox.Show(
                $"¿Está seguro que desea eliminar el Artículo ID {idArticulo} ({nombreArticulo})? Esta acción es permanente.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    LabBasesII.Data.ArticuloDAO.EliminarArticulo(idArticulo);

                    MessageBox.Show($"✅ Artículo ID {idArticulo} eliminado con éxito.\n¡Se disparó el Trigger de Auditoría (DELETE)! ", "Éxito");

                    CargarDatosPrestamos();
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException ex)
                {
                    if (ex.Number == 2292)
                    {
                        MessageBox.Show($"❌ Error de Integridad: No puede eliminar este artículo porque está asociado a un préstamo o tasación activo.", "Error de Integridad");
                    }
                    else if (ex.Number >= 20000 && ex.Number <= 20999)
                    {
                        MessageBox.Show($"❌ Error de Negocio: {ex.Message}", "Error BD");
                    }
                    else
                    {
                        MessageBox.Show($"❌ Error de Base de Datos: ORA-{ex.Number} - {ex.Message}", "Error Fatal");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Error General: {ex.Message}", "Error");
                }
            }
        }
    }
}