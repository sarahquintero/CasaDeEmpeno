// Data/ArticuloDAO.cs
using LabBasesII.Utils;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Data;

namespace LabBasesII.Data
{
    public class ArticuloDAO
    {
        public static void AgregarArticulo(string nombre, string tipo, string estado, int idCliente)
        {
            const string sqlProcedure = "PKG_ARTICULO.AGREGAR_REGISTRO";

            using (var con = DBConnection.GetConnection())
            {
                if (con == null) throw new Exception("Error al conectar a la Base de Datos.");

                using (var cmd = new OracleCommand(sqlProcedure, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2, nombre, ParameterDirection.Input);
                    cmd.Parameters.Add("P_TIPO", OracleDbType.Varchar2, tipo, ParameterDirection.Input);
                    cmd.Parameters.Add("P_ESTADO", OracleDbType.Varchar2, estado, ParameterDirection.Input);
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

        // Dentro de Data/ArticuloDAO.cs (Añadir este método)

        public static void EliminarArticulo(int idArticulo)
        {
            // Llama al procedimiento almacenado de Oracle que ya compilamos
            const string sqlProcedure = "PKG_ARTICULO.ELIMINAR_REGISTRO";

            using (var con = DBConnection.GetConnection())
            {
                if (con == null) throw new Exception("Error al conectar a la Base de Datos. Revise DBConnection.");

                using (var cmd = new OracleCommand(sqlProcedure, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Definición del Parámetro de Entrada (P_ID_ARTICULO)
                    // Asegúrate que el nombre del parámetro coincida exactamente con el Header del paquete en Oracle.
                    cmd.Parameters.Add("P_ID_ARTICULO", OracleDbType.Int32, idArticulo, ParameterDirection.Input);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Oracle.ManagedDataAccess.Client.OracleException ex)
                    {
                        // Re-lanza la excepción. En FormCliente.cs la capturamos para verificar ORA-02292 (integridad) o los errores de negocio (ORA-20xxx)
                        throw ex;
                    }
                }
            }
        }

        // Dentro de Data/ArticuloDAO.cs (Añadir este método)

        // Dentro de Data/ArticuloDAO.cs

        public static DataTable ObtenerConteoArticulosPorTipo()
        {
            const string sqlFunction = "BEGIN :cursor := PKG_ARTICULO.REPORT_CONTEO_POR_TIPO; END;";

            DataTable dtReporte = new DataTable();

            using (var con = DBConnection.GetConnection())
            {
                if (con == null) throw new Exception("Error al conectar a la Base de Datos.");

                using (var cmd = new OracleCommand(sqlFunction, con))
                {
                    cmd.CommandType = CommandType.Text;

                    // 1. Parámetro de Retorno (REF CURSOR)
                    OracleParameter refCursor = new OracleParameter("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                    cmd.Parameters.Add(refCursor);

                    try
                    {
                        // 2. Ejecutar el bloque PL/SQL (llena el parámetro refCursor)
                        cmd.ExecuteNonQuery();

                        // 3. Crear un adaptador para leer el cursor devuelto
                        using (OracleDataAdapter adapter = new OracleDataAdapter())
                        {
                            // Obtener el valor del cursor (que ahora contiene el resultado)
                            OracleRefCursor cursor = refCursor.Value as OracleRefCursor;

                            if (cursor != null)
                            {
                                // 4. Llenar el DataTable usando el cursor
                                // Esta es la forma correcta de usar Fill con un RefCursor en C# ODP.NET
                                adapter.Fill(dtReporte, cursor); // <--- CORRECCIÓN CLAVE: Pasar el OracleRefCursor
                            }
                        }
                    }
                    catch (Oracle.ManagedDataAccess.Client.OracleException ex)
                    {
                        throw new Exception($"Error al ejecutar reporte PL/SQL: ORA-{ex.Number} - {ex.Message}");
                    }
                }
            }
            return dtReporte;
        }




    }
}