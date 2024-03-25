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
    private HistoricoBeneficioBusiness historicoBeneficioBusiness;

    public BeneficioBusiness(AppRepository<Beneficio> beneficioRepository, PessoaFamiliaBusiness pessoaFamiliaBusiness, 
                            RendaPessoaBusiness rendaPessoaBusiness, AliquotaTipoBeneficioBusiness aliquotaTipoBeneficioBusiness, 
                            HistoricoBeneficioBusiness historicoBeneficioBusiness) : base(beneficioRepository)
    {
        this.pessoaFamiliaBusiness = pessoaFamiliaBusiness;
        this.rendaPessoaBusiness = rendaPessoaBusiness;
        this.aliquotaTipoBeneficioBusiness = aliquotaTipoBeneficioBusiness;
        this.historicoBeneficioBusiness = historicoBeneficioBusiness;
    }
    public void CalcularBeneficio(int familiaId)
    {
        ValidacaoBeneficio(familiaId);
        ValidarRendaPerCapta(familiaId);
        var valorBrc = ObterBrc(familiaId);
        var valorBpi = ObterBpi(familiaId);
        var valorBvfn = ObterBvfn(familiaId);
        var valorBvf = ObterBvf(familiaId);
        var valorTotal = valorBrc + valorBpi + valorBvfn + valorBvf;
        Beneficio beneficio = new Beneficio {FamiliaId = familiaId, Aprovado = true};
        Repository.Adicionar(beneficio);
        historicoBeneficioBusiness.SalvarHistoricoBeneficio(beneficio, valorTotal);     
    }

    public double ObterBrc(int familiaId)
    {
        var totalIntegrantesFamilia = pessoaFamiliaBusiness.RecuperarListaPorCondicao(p => p.Familia.Id == familiaId && p.DataDesvinculo is null)!.Count();
        var valorAliquotaBrc = aliquotaTipoBeneficioBusiness.ObterAliquotaVigente(ETipoBeneficio.BRC);
        var valorTotalBrc = totalIntegrantesFamilia * valorAliquotaBrc;
        return valorTotalBrc = valorTotalBrc < 600 ? 600 : valorTotalBrc;
    }

    public double ObterBpi( int familiaId)
    {
        var dataAtual = DateTime.Now;
        var criancasDe0A6Anos = pessoaFamiliaBusiness.RecuperarListaPorCondicao(p => p.Familia.Id == familiaId && p.DataDesvinculo is null)!
                                                     .Where(p => dataAtual.AddYears(-6) <= p.Pessoa.DataNascimento)
                                                     .Count();
        var valorAliquotaBpi = aliquotaTipoBeneficioBusiness.ObterAliquotaVigente(ETipoBeneficio.BPI);
        return criancasDe0A6Anos * valorAliquotaBpi;
    }

    public double ObterBvf(int familiaId)
    {
        var dataAtual = DateTime.Now;
        var criancasDe7A18Anos = pessoaFamiliaBusiness.RecuperarListaPorCondicao(p => p.Familia.Id == familiaId && p.DataDesvinculo is null)!
                                                      .Where(p => (dataAtual.AddYears(-7) >= p.Pessoa.DataNascimento) && (dataAtual <= p.Pessoa.DataNascimento.AddYears(18)))
                                                      .Count();
        var valorAliquotaBvf = aliquotaTipoBeneficioBusiness.ObterAliquotaVigente(ETipoBeneficio.BVF);
        return criancasDe7A18Anos * valorAliquotaBvf;

    }

    public double ObterBvfn(int familiaId)
    {
        var dataAtual = DateTime.Now;
        var bebes0A6Meses = pessoaFamiliaBusiness.RecuperarListaPorCondicao(p => p.Familia.Id == familiaId && p.DataDesvinculo is null)!
                                                 .Where(p => dataAtual <= p.Pessoa.DataNascimento.AddMonths(6))
                                                 .Count();
        var valorAliquotaBvfn = aliquotaTipoBeneficioBusiness.ObterAliquotaVigente(ETipoBeneficio.BVFN);
        return bebes0A6Meses * valorAliquotaBvfn;
    }
    private void ValidarRendaPerCapta(int familiaId)
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
        var familiaRecuperada = pessoaFamiliaBusiness.RecuperarListaPorCondicao(p => p.Familia.Id == familiaId && p.DataDesvinculo is null);
        var titularAtivo = familiaRecuperada?.Where(f => f.TipoVinculo.Equals(ETipoVinculo.TITULAR)).FirstOrDefault();

        if (titularAtivo is null)
        {
            throw new Exception("impossível prosseguir sem um titular ativo");
        }

        DateTime dataAtual = DateTime.Now;

        var pessoasMaioresDe16 = familiaRecuperada?.Where(p => dataAtual >= p.Pessoa.DataNascimento.AddYears(16));


        foreach (var pessoaFamilia in pessoasMaioresDe16)
        {
            var rendaPessoa = rendaPessoaBusiness.RecuperarListaPorCondicao(r => r.Pessoa.Id == pessoaFamilia.Pessoa.Id)!.OrderBy(r => r.DataRegistro).FirstOrDefault(); // o orderby em data ordena da mais recente para a mais antiga
            if (dataAtual.AddDays(-180) > rendaPessoa?.DataRegistro)
            {
                Beneficio beneficio = new Beneficio { FamiliaId = familiaId, DataBloqueio = dataAtual, MotivoBloqueio = EMotivoBloqueio.CADASTRO_DESATUALIZADO};                       
                Repository.Adicionar(beneficio);
                historicoBeneficioBusiness.SalvarHistoricoBeneficio(beneficio, 0);
                throw new Exception("Benefício bloqueado em decorrência de cadastro desatualizado");
            }
        }
    }
}
