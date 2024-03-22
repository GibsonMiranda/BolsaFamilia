using BolsaFamilia.Business;
using BolsaFamilia.Business.Business;
using BolsaFamilia.Shared.Entity.Entity.Enum;
using BolsaFamilia.Shared.Infra;
using Microsoft.Extensions.DependencyInjection;

namespace BolsaFamilia;

    class Program
{
        public static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var pessoaBussiness = serviceProvider.GetService<PessoaBusiness>();
            var familiaBusiness = serviceProvider.GetService<FamiliaBusiness>();
            var aliquotaTipoBeneficioBusiness = serviceProvider.GetService<AliquotaTipoBeneficioBusiness>();
            var pessoaFamiliaBusiness = serviceProvider.GetService<PessoaFamiliaBusiness>();

            //pessoaBussiness.CadastrarPessoa("gibson", "004.186.902-86", DateTime.Parse("10, 06, 1997"));
            //pessoaBussiness.CadastrarPessoa(, "004.186.902-86", DateTime.Parse("06/10/1997"));
            //var gibson = new Pessoa {Id = 2, Cpf = "00418690286", Nome = "Mario Alberto", DataNascimento = DateTime.Now};
            var gibson = pessoaBussiness.RecuperarPorId(2);
            var familia = familiaBusiness.RecuperarPorId(1);
            //pessoaBussiness.AtualizarDadosCadastrais(gibson);
            var pessoaFamilia = pessoaFamiliaBusiness.RecuperarPorId(2);

        //var familia = new Familia {Cep = "000", Beneficio = beneficio, Cidade = "belem", Complemento = "ALTOS", Estado = "pará", Logradouro = "rua tanana", Numero = "13" };
        //familiaBusiness.CadastrarFamilia(familia);

        //pessoaFamiliaBusiness.RemoverMembroFamilia(pessoaFamilia, ETipoDesvinculo.MORTE);
        aliquotaTipoBeneficioBusiness.CadastrarAliquotaTipoBeneficio(50.00, ETipoBeneficio.BVFN);
     
        }

        public static void ConfigureServices(IServiceCollection services)
        {
        services.AddDbContext<AppDbContext>()
            .AddScoped(typeof(AppRepository<>))
            .AddScoped<PessoaBusiness>()
            .AddScoped<FamiliaBusiness>()
            .AddScoped<PessoaFamiliaBusiness>()
            .AddScoped<BeneficioBusiness>()
            .AddScoped<AliquotaTipoBeneficioBusiness>();
        }    
}
