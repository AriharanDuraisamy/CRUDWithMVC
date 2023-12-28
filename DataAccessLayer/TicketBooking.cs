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

        public void InsertSP(TicketModel Details)
        {
            try
            {
                var con = new SqlConnection(connectionString);
                con.Open();
                var insertQuery = $"exec insertsp '{ Details.TicketNumber}','{Details.PassengerName}' ,{ Details.PhoneNumber} ,'{ Details.EmailID}' ,'{Details.JourneyDate}'";
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
                var updateQuery = $"exec updatesp  {ticupd} ,'{ Details.TicketNumber}','{Details.PassengerName}' ,{ Details.PhoneNumber} ,'{ Details.EmailID}' ,'{Details.JourneyDate}'";
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
