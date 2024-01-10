using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class TicketRegistration: ITicketRegistration
    {
        
        private readonly Dbcontext _contxt;
        public TicketRegistration(Dbcontext contxt)
        {
            _contxt = contxt;
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

        public void Update(Registration register)
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

