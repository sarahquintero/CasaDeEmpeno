using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace LabBasesII.Utils
{
    public static class DBConnection
    {
        private const string DB_USER = "LABBASES";
        private const string DB_PASSWORD = "123456";
        private const string DB_SERVICE_NAME = "FREE";
        private const string DB_HOST = "localhost"; 
        private const string DB_PORT = "1521"; 

        public static string ConnectionString = 
            $"DATA SOURCE={DB_HOST}:{DB_PORT}/{DB_SERVICE_NAME};USER ID={DB_USER};PASSWORD={DB_PASSWORD};";

        public static OracleConnection GetConnection()
        {
            Console.WriteLine($"Intentando conectar a: {DB_HOST}:{DB_PORT}/{DB_SERVICE_NAME}...");
            OracleConnection con = null;
            try
            {
                con = new OracleConnection(ConnectionString);
                con.Open(); 
                Console.WriteLine("✅ Conexión establecida con éxito.");
                return con;
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"❌ ERROR de Oracle al conectar (ORA-{ex.Number}): {ex.Message}");
                con?.Dispose(); 
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ ERROR General al conectar: {ex.Message}");
                con?.Dispose();
                return null;
            }
        }
    }
}