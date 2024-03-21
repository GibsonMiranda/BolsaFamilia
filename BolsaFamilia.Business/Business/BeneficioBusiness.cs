using BolsaFamilia.Shared.Entity.Entity;
using BolsaFamilia.Shared.Entity.Entity.Enum;
using BolsaFamilia.Shared.Infra;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace BolsaFamilia.Business.Business;

public class BeneficioBusiness : AppBusiness<Beneficio> 
{
    private PessoaFamiliaBusiness pessoaFamiliaBusiness;
    private RendaPessoaBusiness rendaPessoaBusiness;
    
    public BeneficioBusiness(AppRepository<Beneficio> beneficioRepository, PessoaFamiliaBusiness pessoaFamiliaBusiness, RendaPessoaBusiness rendaPessoaBusiness) : base (beneficioRepository)
    {
        this.pessoaFamiliaBusiness = pessoaFamiliaBusiness;
        this.rendaPessoaBusiness = rendaPessoaBusiness;
    }
    public void CalcularBeneficio(int familiaId)
    {
        Validacao(familiaId);
        DateTime dataAtual = DateTime.Now;


    }

    private void Validacao(int familiaId)
    {
        var familiaRecuperada = pessoaFamiliaBusiness.RecuperarListaPorCondicao( p => p.Familia.Id == familiaId && p.DataDesvinculo is null);
        var titularAtivo = familiaRecuperada?.Where(f => f.TipoVinculo.Equals(ETipoVinculo.TITULAR)).FirstOrDefault();
        
        if (titularAtivo is null)
        {
            throw new Exception("impossível prosseguir sem um titular ativo");
        }

        DateTime dataAtual = DateTime.Now;

        var pessoasMaioresDe16 = familiaRecuperada?.Where(p => dataAtual >= p.Pessoa.DataNascimento.AddYears(16));
          

        foreach(var pessoa in pessoasMaioresDe16)
        {
            var rendaPessoa = rendaPessoaBusiness.RecuperarListaPorCondicao(r => r.Pessoa.Id == pessoa.Pessoa.Id).OrderBy(r => r.DataRegistro).FirstOrDefault(); // o orderby em data ordena da mais recente para a mais antiga
            if (dataAtual.AddDays(-180) > rendaPessoa.DataRegistro)
            {
                var beneficio = pessoa.Familia.Beneficio;
                beneficio.DataBloqueio = dataAtual;
                beneficio.Equals(EMotivoBloqueio.CADASTRO_DESATUALIZADO);
                Repository.Atualizar(beneficio);
                Console.WriteLine("Benefício bloqueado em decorrência de cadastro desatualizado");
            }
        }
    }
}

