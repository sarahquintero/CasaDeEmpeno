using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Text;
using LabBasesII.Utils;

namespace LabBasesII.Data
{
    public class PersonaDAO
    {
        /// <summary>
        /// Obtiene los datos de una persona y su información específica de rol.
        /// </summary>
        /// <param name="id">ID de la persona/rol.</param>
        /// <param name="rol">Rol seleccionado (Asesor, Administrador, Cliente).</param>
        /// <returns>Una cadena con los datos consultados o un mensaje de error.</returns>
        public static string ObtenerDatosPorRol(int id, string rol)
        {
            var resultado = new StringBuilder();
            string sqlQuery = "";

            using (var con = DBConnection.GetConnection())
            {
                if (con == null) return "❌ Error al conectar a la Base de Datos. Revise el servicio Oracle.";

                if (rol == "Asesor")
                {
                    sqlQuery = @"
                        SELECT P.NOMBRE_COMPLETO, A.FECHA_CONTRATACION
                        FROM PERSONA P JOIN ASESOR A ON P.ID_PERSONA = A.ID_ASESOR
                        WHERE P.ID_PERSONA = :id";
                }
                else if (rol == "Administrador")
                {
                    sqlQuery = @"SELECT NOMBRE_COMPLETO FROM PERSONA WHERE ID_PERSONA = :idUsuario";
                }
                else if (rol == "Cliente")
                {
                    sqlQuery = @"
                        SELECT P.NOMBRE_COMPLETO, COUNT(PR.ID_PRESTAMO) AS TOTAL_PRESTAMOS
                        FROM PERSONA P 
                        LEFT JOIN CLIENTE C ON P.ID_PERSONA = C.ID_CLIENTE
                        LEFT JOIN PRESTAMO PR ON C.ID_CLIENTE = PR.ID_CLIENTE
                        WHERE P.ID_PERSONA = :id AND C.ID_CLIENTE IS NOT NULL
                        GROUP BY P.NOMBRE_COMPLETO";
                }
                else
                {
                    return "❌ Error: Rol no reconocido.";
                }

                using (var cmd = new OracleCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("id", OracleDbType.Int32, id, ParameterDirection.Input);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            resultado.AppendLine($"--- Información de {rol} (ID: {id}) ---");
                            resultado.AppendLine($"Nombre: {reader["NOMBRE_COMPLETO"]}");

                            if (rol == "Asesor" && reader["FECHA_CONTRATACION"] != DBNull.Value)
                            {
                                resultado.AppendLine($"Contratado desde: {reader.GetDateTime(reader.GetOrdinal("FECHA_CONTRATACION")).ToShortDateString()}");
                            }
                            else if (rol == "Cliente" && reader["TOTAL_PRESTAMOS"] != DBNull.Value)
                            {
                                resultado.AppendLine($"Total Préstamos (Activos/Devueltos): {reader["TOTAL_PRESTAMOS"]}");
                            }
                        }
                        else
                        {
                            resultado.AppendLine($"❌ Error: ID {id} no encontrado o no está registrado como {rol}.");
                        }
                    }
                }
            }
            return resultado.ToString();
        }

        public static string ObtenerNombreUsuario(int id, string rol)
        {
            string tablaRol = "";
            string columnaID = "";

            // 1. Determinar la tabla y columna basadas en el rol
            if (rol == "Cliente")
            {
                tablaRol = "CLIENTE";
                columnaID = "ID_CLIENTE";
            }
            else if (rol == "Administrador")
            {
                tablaRol = "ADMINISTRADOR";
                columnaID = "ID_ADMINISTRADOR";
            }
            else if (rol == "Asesor")
            {
                tablaRol = "ASESOR";
                columnaID = "ID_ASESOR";
            }
            else
            {
                return "❌ Error: Rol seleccionado no válido.";
            }
            string sqlQuery = $@"
    SELECT P.NOMBRE_COMPLETO 
    FROM PERSONA P
    JOIN {tablaRol} R ON P.ID_PERSONA = R.{columnaID}
    WHERE P.ID_PERSONA = :idUsuario";

            using (var con = DBConnection.GetConnection())
            {
                if (con == null) return "❌ Error al conectar a la Base de Datos.";

                using (var cmd = new OracleCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("idUsuario", OracleDbType.Int32, id, ParameterDirection.Input);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null && resultado != DBNull.Value)
                    {
                        return resultado.ToString(); // Éxito: retorna el nombre
                    }
                    else
                    {
                        return $"❌ Error: ID {id} no registrado como {rol}.";
                    }
                }
            }
        }




        // Dentro de Data/PersonaDAO.cs (Renombrar y modificar este método)

        public static DataTable ObtenerArticulosYPrestamosPorCliente(int idCliente)
        {
            // Modificamos la consulta: La tabla principal es ARTICULO (A).
            // Usamos LEFT JOIN para incluir artículos que NO están en PRESTAMO (P) ni en TASACION (T).
            string sqlQuery = @"
        SELECT 
            A.ID_ARTICULO,             -- ID del Artículo
            A.NOMBRE_ARTICULO,         -- Nombre del Artículo
            A.TIPO_PRODUCTO,           -- Tipo del Artículo
            A.ESTADO AS ESTADO_ARTICULO, -- Estado del Artículo
            
            P.ID_PRESTAMO,             -- Clave del Préstamo (NULL si no está prestado)
            P.MONTO AS MONTO_PRESTAMO, 
            P.ESTADO_PRESTAMO,         
            T.VALOR_TASADO             -- Valor de Tasación (NULL si no ha sido tasado)
            
        FROM ARTICULO A
        LEFT JOIN PRESTAMO P ON A.ID_ARTICULO = P.ID_ARTICULO
        LEFT JOIN TASACION T ON A.ID_ARTICULO = T.ID_ARTICULO 
        
        WHERE A.ID_CLIENTE = :idCliente
        ORDER BY A.ID_ARTICULO DESC";

            DataTable dtArticulos = new DataTable();

            using (var con = DBConnection.GetConnection())
            {
                if (con == null) throw new Exception("Error al conectar a la Base de Datos.");

                using (var cmd = new OracleCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("idCliente", OracleDbType.Int32, idCliente, ParameterDirection.Input);

                    using (var adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(dtArticulos);
                    }
                }
            }
            return dtArticulos;
        }
    }
}