using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDataAccessLayer
{
    public interface ITicketRegistration
    {
        public void Insert(Registration product);

        public Registration ReadbyIDSP(long PassngerID);
        public IEnumerable<Registration> GetAllRegistration();

        public bool Login(string username, string password);
    }
}
