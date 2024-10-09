using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLocadoraDeCarros.Dal.Configurations;
using TesteLocadoraDeCarros.Domain.Aggregates.CarroAggregate;
using TesteLocadoraDeCarros.Domain.Aggregates.UserProfileAggregate;


namespace TesteLocadoraDeCarros.Dal
{
    public class DataContext : IdentityDbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base (options) 
        {
        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarroConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());
            modelBuilder.ApplyConfiguration(new CarroAluguelConfiguration());
            modelBuilder.ApplyConfiguration(new IdentityUserLoginConfiguration());
            modelBuilder.ApplyConfiguration(new IdentityUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new IdentityUserTokenConfiguration());
        }

    }
}
