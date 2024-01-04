using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDataAccessLayer
{
    public interface ITicketLocations
    {
        public IEnumerable<Locations> GetAllLocations();
    }
}
