using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLocadoraDeCarros.Domain.Aggregates.CarroAggregate;

namespace TesteLocadoraDeCarros.Dal.Configurations
{
    public class CarroConfiguration : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.Marca).IsRequired().HasMaxLength(50);


            builder.Property(c => c.Modelo).IsRequired().HasMaxLength(50);

            builder.Property(c => c.Ano).IsRequired().HasColumnType("int");

            builder.Property(c => c.TaxaDiaria).IsRequired().HasColumnType("decimal(18,2)");

            builder.Property(c => c.TaxaAtraso).IsRequired().HasColumnType("decimal(18,2)");
        }

    }
}
