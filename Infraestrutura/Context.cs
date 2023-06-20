using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Dominio.Entidades;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;

namespace Infraestrutura
{
    public class Context : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<NotaFiscal> NotaFiscal { get; set; }
    
        public Context()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            string connectionString = "Data Source=localhost; Initial Catalog=HomeManage; User ID=USUARIO; password=NEILSANTOS; language=Portuguese; trusted_connection=true; encrypt=false;";

            optionBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                 .HasOne(e => e.Marca)
                 .WithMany(e => e.Produtos)
                 .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Produto>()
                 .HasOne(e => e.ProdutoPai)
                 .WithMany(e => e.Acessorios)
                 .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Produto>()
                 .HasOne(e => e.Categoria)
                 .WithMany(e => e.Produtos)
                 .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<NotaFiscal>()
                 .HasOne(e => e.Produto)
                 .WithOne(e => e.NotaFiscal)
                 .HasForeignKey<Produto>(e=>e.NotaFiscalId)
                 .OnDelete(DeleteBehavior.ClientCascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
