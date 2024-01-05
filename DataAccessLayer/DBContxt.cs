using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DapperDataAccessLayer
{
    public class DBContxt:DbContext
    {
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Registration> Registrations { get; set; }
    }
}
