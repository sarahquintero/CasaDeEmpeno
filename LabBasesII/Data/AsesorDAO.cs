using LabBasesII.Utils;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LabBasesII.Data
{
    public class AsesorDAO
    {
        public static DataTable ObtenerPrestamosPorAsesor(int idAsesor)
        {
            string sqlQuery = @"
        SELECT 
            P.ID_PRESTAMO, P.MONTO, P.ESTADO_PRESTAMO, 
            A.NOMBRE_ARTICULO, P.FECHA_INICIO, PE.NOMBRE_COMPLETO AS NOMBRE_CLIENTE 
        FROM 
            PRESTAMO P
        JOIN 
            ARTICULO A ON P.ID_ARTICULO = A.ID_ARTICULO
        JOIN 
            CLIENTE C ON P.ID_CLIENTE = C.ID_CLIENTE
        JOIN 
            PERSONA PE ON C.ID_CLIENTE = PE.ID_PERSONA
        WHERE 
            P.ID_ASESOR = :idAsesor";

            DataTable dtPrestamos = new DataTable();

            try
            {
                using (var con = DBConnection.GetConnection())
                {
                    if (con == null) throw new Exception("Error al obtener la conexión.");

                    // Asegurar que la conexión está abierta, aunque el using debería manejarlo.
                    //if (con.State != ConnectionState.Open) con.Open();

                    using (var cmd = new OracleCommand(sqlQuery, con))
                    {
                        cmd.Parameters.Add("idAsesor", OracleDbType.Decimal, idAsesor, ParameterDirection.Input);

                        using (var adapter = new OracleDataAdapter(cmd))
                        {
                            adapter.Fill(dtPrestamos);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Si hay un error, lo verás en un MessageBox al iniciar sesión.
                MessageBox.Show("Error en DAO: " + ex.Message, "Error de Datos");
                // Devuelve una tabla vacía si hay un error
                return new DataTable();
            }
            return dtPrestamos;
        }
    }
}
