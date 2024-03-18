using BolsaFamilia;
using BolsaFamilia.Business;
using BolsaFamilia.Infra;
using BolsaFamilia.Modelos;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;
using BolsaFamilia.Modelos.Enum;




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
            var familiaBusiness = serviceProvider.GetService<FamiliaBusiness>();
           
            var pessoaFamiliaBusiness = serviceProvider.GetService<PessoaFamiliaBusiness>();

            //pessoaBussiness.CadastrarPessoa("gibson", "004.186.902-86", DateTime.Parse("10, 06, 1997"));
            //pessoaBussiness.CadastrarPessoa(, "004.186.902-86", DateTime.Parse("06/10/1997"));
            //var gibson = new Pessoa {Id = 2, Cpf = "00418690286", Nome = "Mario Alberto", DataNascimento = DateTime.Now};
            var gibson = pessoaBussiness.RecuperarPorId(2);
            var familia = familiaBusiness.RecuperarPorId(1);
            //pessoaBussiness.AtualizarDadosCadastrais(gibson);
           

            //var familia = new Familia {Cep = "000", Beneficio = beneficio, Cidade = "belem", Complemento = "ALTOS", Estado = "pará", Logradouro = "rua tanana", Numero = "13" };
            //familiaBusiness.CadastrarFamilia(familia);

            pessoaFamiliaBusiness.VincularMembroFamilia(gibson, familia, ETipoVinculo.TITULAR);
           
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>()
                .AddScoped(typeof(AppRepository<>))
                .AddScoped<PessoaBusiness>()
                .AddScoped<FamiliaBusiness>()
                .AddScoped<PessoaFamiliaBusiness>();
        }

        

    }
}