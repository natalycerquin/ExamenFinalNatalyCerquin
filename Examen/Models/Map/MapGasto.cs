using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models.Map
{
    public class MapGasto : IEntityTypeConfiguration<Gastos>
    {
        public void Configure(EntityTypeBuilder<Gastos> builder)
        {
            builder.ToTable("Gastos");
            builder.HasKey(o => o.Id);
            builder.HasOne(o => o.Cuenta)
            .WithMany()
            .HasForeignKey(o => o.CuentaId);
        }
    }
}
