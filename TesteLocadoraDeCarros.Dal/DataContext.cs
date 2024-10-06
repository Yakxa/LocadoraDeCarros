using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLocadoraDeCarros.Domain.Aggregates;


namespace TesteLocadoraDeCarros.Dal
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) 
        {
        }

        public DbSet<Aluguel> Alugueis { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contrato> Contratos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração para a entidade Carro
            modelBuilder.Entity<Carro>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Marca).IsRequired();
                entity.Property(c => c.Modelo).IsRequired();
                entity.Property(c => c.Ano).IsRequired();
                entity.Property(c => c.Disponivel).IsRequired();
                entity.Property(c => c.TaxaDiaria).IsRequired();
                entity.Property(c => c.TaxaAtraso).IsRequired();
            });

            // Configuração para a entidade Aluguel
            modelBuilder.Entity<Aluguel>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Status).IsRequired();
                entity.HasOne(a => a.Cliente).WithMany(c => c.Alugueis).HasForeignKey(a => a.ClienteId); // Relacionamento com Cliente
                entity.HasOne(a => a.Contrato).WithOne(c => c.Aluguel).HasForeignKey<Aluguel>(a => a.ContratoId); // Um Contrato tem um Aluguel
                entity.HasMany(a => a.Carros).WithMany(c => c.Alugueis); // Muitos para muitos entre Alugueis e Carros
            });

            // Configuração para a entidade Cliente
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Nome).IsRequired();
                entity.Property(c => c.Documento).IsRequired();
                entity.HasMany(c => c.Alugueis).WithOne(a => a.Cliente); // Relação de um Cliente com muitos Alugueis
            });

            // Configuração para a entidade Contrato
            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.DataInicio).IsRequired();
                entity.Property(c => c.DataFim).IsRequired();
                entity.HasOne(c => c.Aluguel).WithOne(a => a.Contrato); // Um Contrato tem um Aluguel
            });
        }

    }
}
