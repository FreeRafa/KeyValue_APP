using System;
using System.Collections.Generic;
using System.Text;

namespace KeyValue_APP.Infraestrutura
{
    public class AppConfig
    {
        public static string GetConnectionString()
        {
            // Retorna a string de conexão para o banco de dados
            return @"Server=(localdb)\MSSQLLocalDB;Database=KeyValueDB;Trusted_Connection=True;TrustServerCertificate=True;";
        }
    }
}
