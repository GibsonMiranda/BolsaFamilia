using BolsaFamilia.Business;
using BolsaFamilia.Business.Business;
using BolsaFamilia.Shared.Entity.Entity;
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
        var rendaPessoaBusiness = serviceProvider.GetService<RendaPessoaBusiness>();
        var beneficioBusiness = serviceProvider.GetService<BeneficioBusiness>();

        //var katia = pessoaBussiness.RecuperarPorId(1002);
        //var familia = familiaBusiness.RecuperarPorId(1002);
        //Pessoa gibson = new Pessoa {Cpf = "004.186.902-86", DataNascimento = new DateTime(1997/10/06), Nome = "Gibson Carvalho de Miranda" };
        //Pessoa katia = new Pessoa { Cpf = "513.067.002-72", DataNascimento = new DateTime(1979 / 08 / 27), Nome = "Ana Katia de Sousa Carvalho" };
        //pessoaBussiness.CadastrarPessoa(gibson);
        //pessoaBussiness.CadastrarPessoa(katia);
        //pessoaFamiliaBusiness.VincularMembroFamilia(katia, familia , ETipoVinculo.DEPENDENTE);
        //Familia familia = new Familia { Cep = "68515-000", Cidade = "Parauapebas", Complemento = "apto", Logradouro = "av f qd 57", Estado = "Pará", Numero = "s/n" };
        //familiaBusiness.CadastrarFamilia(familia);
        var familia = familiaBusiness.RecuperarPorId(1);
        var gibson = pessoaBussiness.RecuperarPorId(1);
        var katia = pessoaBussiness.RecuperarPorId(2);
        //pessoaFamiliaBusiness.VincularMembroFamilia(gibson, familia, ETipoVinculo.TITULAR);
        //pessoaFamiliaBusiness.VincularMembroFamilia(katia, familia, ETipoVinculo.DEPENDENTE);
        //rendaPessoaBusiness.CadastrarRenda(gibson, 200.00);
        //rendaPessoaBusiness.CadastrarRenda(katia, 100.00);
        //aliquotaTipoBeneficioBusiness.CadastrarAliquotaTipoBeneficio(142.00, ETipoBeneficio.BRC);
        //aliquotaTipoBeneficioBusiness.CadastrarAliquotaTipoBeneficio(150.00, ETipoBeneficio.BPI);
        //aliquotaTipoBeneficioBusiness.CadastrarAliquotaTipoBeneficio(50.00, ETipoBeneficio.BVF);
        //aliquotaTipoBeneficioBusiness.CadastrarAliquotaTipoBeneficio(50.00, ETipoBeneficio.BVFN);


        beneficioBusiness.CalcularBeneficio(1);
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>()
        .AddScoped(typeof(AppRepository<>))
        .AddScoped<PessoaBusiness>()
        .AddScoped<FamiliaBusiness>()
        .AddScoped<PessoaFamiliaBusiness>()
        .AddScoped<BeneficioBusiness>()
        .AddScoped<AliquotaTipoBeneficioBusiness>()
        .AddScoped<RendaPessoaBusiness>()
        .AddScoped<HistoricoBeneficioBusiness>()
        .AddScoped<BeneficioBusiness>();
    }    
}   
