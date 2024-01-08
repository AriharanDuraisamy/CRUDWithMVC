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
        public IEnumerable<Registration> GetAllRegistration();
        public bool Login(string username, string password);
        public void Update(Registration register);
    }
}
