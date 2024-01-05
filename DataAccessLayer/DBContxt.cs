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
        public DBContxt(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Locations> Locations { get; set; }
        public DbSet<Registration> Registration { get; set; }
    }
}
