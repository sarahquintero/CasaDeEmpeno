using System;
using System.Data;
using System.Windows.Forms;
using LabBasesII.Data;

namespace LabBasesII
{
    public partial class FormReportes : Form
    {
        private readonly int _idUsuario;
        private readonly string _rol;

        public FormReportes(int idUsuario, string nombreUsuario, string rol)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
            _rol = rol;
            this.Text = $"{rol} Panel de Gestión";
            lblBienvenidaAsesor.Text = $"Bienvenido {_rol}: {nombreUsuario} (ID: {idUsuario})";
            lblTituloReporte.Text = "Reporte de Artículos: Conteo por Tipo y Valor Máximo";

            CargarDatosPorRol();
        }

        private void CargarDatosPorRol()
        {
            if (_rol == "Asesor")
            {
                CargarPrestamosDelAsesor();
            }
            else if (_rol == "Administrador")
            {
                lblTituloReporte.Text = "Reporte de Artículos: Conteo por Tipo y Valor Máximo";
                CargarReporteConteo();
            }
        }

        private void CargarPrestamosDelAsesor()
        {
            try
            {
                lblTituloReporte.Text = "Préstamos Gestionados"; // Cambiar el título

                DataTable reportePrestamos = AsesorDAO.ObtenerPrestamosPorAsesor(_idUsuario);

                dgvReporte2.DataSource = reportePrestamos;
                dgvReporte2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvReporte2.Columns["ID_PRESTAMO"].HeaderText = "ID Préstamo";
                dgvReporte2.Columns["MONTO"].HeaderText = "Monto";
                dgvReporte2.Columns["ESTADO_PRESTAMO"].HeaderText = "Estado";
                dgvReporte2.Columns["NOMBRE_ARTICULO"].HeaderText = "Artículo";
                dgvReporte2.Columns["FECHA_INICIO"].HeaderText = "Inicio";
                dgvReporte2.Columns["NOMBRE_CLIENTE"].HeaderText = "Cliente";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al cargar Préstamos del Asesor: {ex.Message}", "Error de Reporte");
            }
        }




        private void CargarReporteConteo()
        {
            try
            {
                DataTable reporte = ArticuloDAO.ObtenerConteoArticulosPorTipo();

                dgvReporte2.DataSource = reporte;
                dgvReporte2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Renombrar columnas para la visualización
                dgvReporte2.Columns["TIPO_PRODUCTO"].HeaderText = "Tipo de Artículo";
                dgvReporte2.Columns["TOTAL_ARTICULOS"].HeaderText = "Total de Activos";
                dgvReporte2.Columns["MAX_VALOR_TASADO"].HeaderText = "Máximo Valor Tasado";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al cargar el Reporte de Conteo: {ex.Message}", "Error de Reporte");
            }
        }

        private void btnCargarReporte2_Click(object sender, EventArgs e)
        {
            CargarDatosPorRol();
        }
        
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}