using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rev.Models;

namespace Rev.Data
{
    public class RevContext : DbContext
    {
        public RevContext (DbContextOptions<RevContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Fonte> Fonte { get; set; }
        public DbSet<Registro> Registro { get; set; }
        public DbSet<Tipo> Tipo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
