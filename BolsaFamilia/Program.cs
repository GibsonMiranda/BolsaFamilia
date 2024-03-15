using BolsaFamilia;
using BolsaFamilia.Business;
using BolsaFamilia.Infra;
using BolsaFamilia.Modelos;
using Microsoft.Extensions.DependencyInjection;




namespace BolsaFamilia
{
    class Program
    {
        public static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var pessoaBussiness = serviceProvider.GetService<PessoaBusiness>();
            var pessoa = serviceProvider.GetService<AppRepository<Pessoa>>();
            //pessoaBussiness.CadastrarPessoa("gibson", "004.186.902-86", DateTime.Parse("10, 06, 1997"));
            //pessoaBussiness.CadastrarPessoa(, "004.186.902-86", DateTime.Parse("06/10/1997"));
            var gibson = new Pessoa {Id = 2, Cpf = "00418690286", Nome = "Mario Alberto", DataNascimento = DateTime.Now};
            
            pessoaBussiness.AtualizarDadosCadastrais(gibson);
           
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>()
                .AddScoped(typeof(AppRepository<>))
                .AddScoped<PessoaBusiness>();
        }

        

    }
}