using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLocadoraDeCarros.Domain.Aggregates.CarroAggregate;
using TesteLocadoraDeCarros.Domain.Aggregates.UserProfileAggregate;

namespace TesteLocadoraDeCarros.Dal.Configurations
{
    internal class CarroAluguelConfiguration : IEntityTypeConfiguration<CarroAluguel>
    {
        public void Configure(EntityTypeBuilder<CarroAluguel> builder)
        {
            builder.HasKey(ca => ca.AluguelId);

            builder.HasOne<UserProfile>()
                .WithMany()
                .HasForeignKey(ca => ca.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
