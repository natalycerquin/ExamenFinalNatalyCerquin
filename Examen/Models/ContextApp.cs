using Examen.Models.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models
{
    public class ContextApp : DbContext
    {
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<Gastos> Gastos { get; set; }

        public ContextApp(DbContextOptions<ContextApp> options)
          : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MapCuenta());
            modelBuilder.ApplyConfiguration(new MapGasto());
        }
    }
}
