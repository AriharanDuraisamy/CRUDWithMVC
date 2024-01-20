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
        
        private readonly Dbcontxt _contxt;
        public TicketRegistration(Dbcontxt contxt)
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
        public bool Security(Registration value)
        {
            var final = _contxt.Registration.FromSqlRaw<Registration>($"select * from Registration where emailid='{value.Emailid}' and password='{value.Password}'").ToList();
            if(final.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Update(long id, Registration register)
        {
            try
            {
                 var result= _contxt.Database.ExecuteSqlRaw($" update Registration set Emailid='{register.Emailid}',Password='{register.Password}' where RegistrationId={id} ");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Registration> GetAllRegistration()
        {
            try
            {
                var result=_contxt.Registration.FromSqlRaw("select * from Registration").ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Registration> GetAllRegistration(Registration value)
        {
            throw new NotImplementedException();
        }
        public Registration ReadbyID(long Registrationid)
        {
            try
            {
                var result = _contxt.Registration.FromSqlRaw<Registration>($"select * from Registration where RegistrationId={Registrationid}");
                return result.ToList().FirstOrDefault();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void Delete(long Registrationid)
        {
            _contxt.Database.ExecuteSqlRaw($"delete Registration where RegistrationId={Registrationid}");
        }

        
    }
}

