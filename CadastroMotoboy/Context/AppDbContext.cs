using CadastroMotoboy.Model;
using Microsoft.EntityFrameworkCore;

namespace CadastroMotoboy.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>().HasData(
            new Funcionario
            { 
                Id = 1,
                Nome = "Sandro Gonçalves",
                Cpf = "123.456.123-12",
                CategoriaDaCarteiraDeMotorista = "AB"
            });
        }
    }
}
