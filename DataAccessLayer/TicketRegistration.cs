using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDataAccessLayer
{
    public class TicketRegistration :ITicketRegistration
    {
        private readonly DBContxt _contxt;
        public TicketRegistration(DBContxt contxt)
        {
            _contxt = contxt;
        }

        public Registration ReadbyIDSP(long PassengerID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Registration> GetAllRegistration()
        {
            throw new NotImplementedException();
        }

        public void Insert(Registration register)
        {
            try
            {
                _contxt.Database.ExecuteSqlRaw($"exec insertregister '{register.UserName}','{register.Password}'");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Login(string email, string password)
        {
            try
            {
                var result = _contxt.Registration.FromSqlRaw<Registration>("").ToList();

                if (result != null || result.Count > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(Registration product)
        {
            try
            {
                _contxt.Database.ExecuteSqlRaw("sp");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }   
}

