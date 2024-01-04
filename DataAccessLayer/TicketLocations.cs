using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DapperDataAccessLayer
{
    public class TicketLocations:ITicketLocations
    {
        public string connectionString;
        public TicketLocations(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DbConnection");
        }
        public IEnumerable<Locations> GetAllLocations()
        {
            try
            {
               
                var con = new SqlConnection(connectionString);
                con.Open();
                var selectQuery = $"exec selectsp ";
                var products = con.Query<Locations>(selectQuery);

                con.Close();

                return products.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}

