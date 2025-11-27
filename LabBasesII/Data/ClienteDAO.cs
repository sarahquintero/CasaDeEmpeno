using LabBasesII.Utils;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Text;

namespace LabBasesII.Data
{
    public class ClienteDAO
    {
        /// <summary>
        /// Agrega un nuevo registro de Cliente llamando al procedimiento almacenado
        /// PKG_CLIENTE.AGREGAR_CLIENTE.
        /// </summary>
        /// <param name="idCliente">El ID de la persona que se registrará como cliente.</param>
        public static void AgregarCliente(int idCliente)
        {
            using (var con = DBConnection.GetConnection())
            {
                if (con == null)
                {
                    throw new Exception("Error al establecer la conexión con la base de datos.");
                }
                using (var cmd = new OracleCommand("PKG_CLIENTE.AGREGAR_CLIENTE", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("P_ID_CLIENTE", OracleDbType.Int32, idCliente, ParameterDirection.Input);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (OracleException ex)
                    {
                        throw ex;
                    }
                }
            }
        }
    }
}