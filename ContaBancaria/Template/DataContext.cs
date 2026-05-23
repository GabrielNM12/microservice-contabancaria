using System.Collections.Generic;
using System.Reflection.Emit;
using ContaBancaria;
using ContaBancaria.Servicos;
using Microsoft.EntityFrameworkCore;

namespace Exemplo
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>().HasKey(p => p.Id);


            base.OnModelCreating(modelBuilder);
        }
    }
}
