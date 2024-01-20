using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public interface ITicketRegistration
    {
        public void Insert(Registration Register);
        public IEnumerable<Registration> GetAllRegistration(Registration value);
        public bool Login(Registration check);
        public bool Security(Registration value);
        public void Update(long id, Registration register);
        public IEnumerable<Registration> GetAllRegistration();
        public Registration ReadbyID(long Registrationid);
        public void Delete(long id);
    }
}
