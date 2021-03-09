using Dapper;
using DemoDapper.Modelo;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace DemoDapper.Repositorio
{
    public class ClienteRepositorio
    {

        public IEnumerable<Cliente> SelectClientes()
        {
            IEnumerable<Cliente> clientes;
            
            using (var connection = new SqlConnection(GetDbConnection()))
            {
                clientes = connection.Query<Cliente>(@"SELECT * FROM Cliente order by nome");
            }

            return clientes;
        }

        private string GetDbConnection()
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true);

            string strConnection = builder.Build().GetConnectionString("DefaultConnection");

            return strConnection;
        }
    }
}
