using BolsaFamilia.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaFamilia.Infra
{
    internal class AppDbContext : DbContext
    {
        DbSet<Pessoa> Pessoa { get; set; }
        DbSet<Familia> Familia { get; set; }
        DbSet<PessoaFamilia> PessoaFamilia { get; set; }
        DbSet<RendaPessoa> RendaPessoa { get; set; }
        DbSet<Beneficio> Beneficio { get; set; }
        DbSet<HistoricoBeneficio> HistoricoBeneficio { get; set; }
        DbSet<AliquotaTipoBeneficio> AliquotaTipoBeneficio { get; set; }

        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BolsaFamilia;Integrated Security=True;MultipleActiveResultSets=True;" +
            "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
        }
       
    }
}
