using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    public class Dbcontext:DbContext
    {
        public Dbcontext(DbContextOptions<Dbcontext> options) : base(options)
        {

        }
        public DbSet<Registration> Registration { get; set; }
    }
}