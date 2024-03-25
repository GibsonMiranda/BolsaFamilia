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

        var katia = pessoaBussiness.RecuperarPorId(1002);
        var familia = familiaBusiness.RecuperarPorId(1002);

        pessoaFamiliaBusiness.VincularMembroFamilia(katia, familia , ETipoVinculo.DEPENDENTE);
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
