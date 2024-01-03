using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
    
namespace DapperDataAccessLayer
{
    public class TicketBooking : ITicketBooking

    {
        public string connectionString;
        public TicketBooking(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DbConnection");
        }
        /*public bool ValidateUser(string email, string password)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", email);
                    command.Parameters.AddWithValue("@Password", password); // Note: You should hash the password before comparing in a real scenario

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    return count > 0; // If count is greater than zero, the user with provided credentials exists
                }
            }
        }*/
    



public void InsertSP(TicketModel Details)
        {
            try
            {
                var con = new SqlConnection(connectionString);
                con.Open();
                var insertQuery = $"exec insertsp '{ Details.TicketNumber}','{Details.PassengerName}' ,{ Details.PHNumber} ,'{ Details.EmailID}' ,'{Details.JourneyDate}'";
                con.Execute(insertQuery);
                con.Close();

            }
            catch (SqlException sql)
            {
                throw;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteSP(long PassengerID)
        {
            try
            {
                var con = new SqlConnection(connectionString);
                con.Open();
                var deleteQuery = $"exec deletesp {PassengerID}";
                con.Execute(deleteQuery);
                con.Close();

            }
            catch (SqlException sql)
            {
                throw;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<TicketModel> ReadSP()
        {
            try
            { 
                var con = new SqlConnection(connectionString);
                con.Open();
                var selectQuery = $"exec selectsp";
                var ticket = con.Query<TicketModel>(selectQuery);

                con.Close();

                return ticket.ToList();
            }

            catch (SqlException sql)
            {
                throw;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public TicketModel ReadbyIDSP(long PassengerID)
        {
            try
            {
                var con = new SqlConnection(connectionString);
                con.Open();
                var selectQuery = $"exec selectidsp  {PassengerID} ";
                var result = con.QueryFirstOrDefault<TicketModel>(selectQuery);

                con.Close();

                return result;
            }

            catch (SqlException sql)
            {
                throw;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void UpdateSP(int ticupd, TicketModel Details)
        {
            try
            {
                var con = new SqlConnection(connectionString);
                con.Open();
                var updateQuery = $"exec updatesp  {ticupd} ,'{ Details.TicketNumber}','{Details.PassengerName}' ,{ Details.PHNumber} ,'{ Details.EmailID}' ,'{Details.JourneyDate}'";
                con.Execute(updateQuery);

            }
            catch (SqlException sql)
            {
                throw;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
