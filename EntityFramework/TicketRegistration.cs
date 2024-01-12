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
                _contxt.Database.ExecuteSqlRaw($"exec insertregister '{register.Emailid}','{register.Password}'");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Login(Registration check)
        {
            try
            {
                var result = _contxt.Registration.FromSqlRaw<Registration>($"select * from Registration where Emailid='{check.Emailid}'").ToList();

                if (result == null || result.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
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

