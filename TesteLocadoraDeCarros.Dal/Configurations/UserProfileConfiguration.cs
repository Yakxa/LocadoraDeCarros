using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLocadoraDeCarros.Domain.Aggregates.UserProfileAggregate;

namespace TesteLocadoraDeCarros.Dal.Configurations
{
    public class UserProfileConfiguration :IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Documento).IsRequired().HasMaxLength(50);
            
        }
    }
}
