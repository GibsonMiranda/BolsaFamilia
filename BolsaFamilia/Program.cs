using BolsaFamilia.Business;
using BolsaFamilia.Business.Validacao;
using BolsaFamilia.Infra;
using BolsaFamilia.Modelos;
using Microsoft.Extensions.DependencyInjection;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var pessoaBussiness = serviceProvider.GetService<PessoaBusiness>();
            //pessoaBussiness.CadastrarPessoa("gibson", "004.186.902-86", DateTime.Parse("10, 06, 1997"));
            pessoaBussiness.CadastrarRenda(2, 2500);
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>()
                .AddScoped(typeof(AppRepository<>))
                .AddScoped<PessoaBusiness>();
        }

        

    }
}