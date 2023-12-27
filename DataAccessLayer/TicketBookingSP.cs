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
    public class TicketBookingSP : ITicketSP

    {
        public string connectionString;
        public TicketBookingSP(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DbConnection");
        }

        public void InsertSP(TicketModelSP Details)
        {
            try
            {
                var con = new SqlConnection(connectionString);
                con.Open();
                var insertQuery = $"exec insertsp { Details.TICKETNUMBER},'{Details.PASSENGERNAME}' ,{ Details.PHNUMBER} ,'{ Details.EMAILID}' ,'{Details.JOURNEYDATE}'";
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

        public void DeleteSP(long PASSENGERID)
        {
            try
            {
                var con = new SqlConnection(connectionString);
                con.Open();
                var deleteQuery = $"exec deletesp {PASSENGERID}";
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
        public List<TicketModelSP> ReadSP()
        {
            try
            { 
                var con = new SqlConnection(connectionString);
                con.Open();
                var selectQuery = $"exec selectsp";
                var ticket = con.Query<TicketModelSP>(selectQuery);

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
        public TicketModelSP ReadbyIDSP(long PASSENGERID)
        {
            try
            {
                var con = new SqlConnection(connectionString);
                con.Open();
                var selectQuery = $"exec selectidsp  {PASSENGERID} ";
                var result = con.QueryFirstOrDefault<TicketModelSP>(selectQuery);

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
        public void UpdateSP(int ticupd, TicketModelSP Details)
        {
            try
            {
                var con = new SqlConnection(connectionString);
                con.Open();
                var updateQuery = $"exec updatesp  {ticupd} ,{ Details.TICKETNUMBER},'{Details.PASSENGERNAME}' ,{ Details.PHNUMBER} ,'{ Details.EMAILID}' ,'{Details.JOURNEYDATE}'";
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
