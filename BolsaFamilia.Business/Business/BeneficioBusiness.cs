using BolsaFamilia.Shared.Entity.Entity;
using BolsaFamilia.Shared.Entity.Entity.Enum;
using BolsaFamilia.Shared.Infra;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace BolsaFamilia.Business.Business;

public class BeneficioBusiness : AppBusiness<Beneficio> 
{
    private PessoaFamiliaBusiness pessoaFamiliaBusiness;
    private RendaPessoaBusiness rendaPessoaBusiness;
    private AliquotaTipoBeneficioBusiness aliquotaTipoBeneficioBusiness;
    
    public BeneficioBusiness(AppRepository<Beneficio> beneficioRepository, PessoaFamiliaBusiness pessoaFamiliaBusiness, RendaPessoaBusiness rendaPessoaBusiness, AliquotaTipoBeneficioBusiness aliquotaTipoBeneficioBusiness) : base (beneficioRepository)
    {
        this.pessoaFamiliaBusiness = pessoaFamiliaBusiness;
        this.rendaPessoaBusiness = rendaPessoaBusiness;
        this.aliquotaTipoBeneficioBusiness = aliquotaTipoBeneficioBusiness;
    }
    public void CalcularBeneficio(int familiaId)
    {
        ValidacaoBeneficio(familiaId);
        ValidarRendaPerCapta(familiaId);
        var totalIntegrantesFamilia = pessoaFamiliaBusiness.RecuperarListaPorCondicao(p => p.Familia.Id == familiaId && p.DataDesvinculo is null)!.Count();
        var valorAliquota = aliquotaTipoBeneficioBusiness.ObterAliquotaVigente(ETipoBeneficio.BRC);
        
        var valorTotalBrc = totalIntegrantesFamilia * valorAliquota;
        valorTotalBrc = valorTotalBrc < 600 ? 600 : valorTotalBrc;

        var criancasDe0A6Anos = pessoaFamiliaBusiness.RecuperarListaPorCondicao(p => p.Familia.Id == familiaId && p.DataDesvinculo is null)
                                                      .Where(p => p);


    }

    

    public void ValidarRendaPerCapta (int familiaId) 
    {
        DateTime dataAtual = DateTime.Now;
        var listaPessoaFamilia = pessoaFamiliaBusiness.RecuperarListaPorCondicao(f => f.Familia.Id == familiaId && f.DataDesvinculo is null);
        double rendaFamilia = 0;
        int qtdIntegrantesFamilia = listaPessoaFamilia.Count();

        foreach (var pessoaFamilia in listaPessoaFamilia)
        {
            var rendaPessoa = rendaPessoaBusiness.RecuperarListaPorCondicao(r => r.Pessoa.Id == pessoaFamilia.Pessoa.Id)!.OrderBy(r => r.DataRegistro).FirstOrDefault();
            rendaFamilia += rendaPessoa.Valor; 
        }
        double rendaPerCapta = rendaFamilia / qtdIntegrantesFamilia;
        if (rendaPerCapta > 218)
        {
            DateTime dataCalculoRejeicao = DateTime.Now;
            Beneficio beneficio = new Beneficio { FamiliaId = familiaId, MotivoRejeicao = EMotivoRejeicao.RENDA_INCOMPATIVEL, DataCalculoRejeicao = dataCalculoRejeicao };
            Repository.Adicionar(beneficio);
            throw new Exception("benefício rejeitado por incompatibilidade de renda");
        }
    }

    private void ValidacaoBeneficio(int familiaId)
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

