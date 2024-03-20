using BolsaFamilia.Shared.Entity.Entity;
using BolsaFamilia.Shared.Entity.Entity.Enum;
using BolsaFamilia.Shared.Infra;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace BolsaFamilia.Business.Business;

public class BeneficioBusiness : AppBusiness<Beneficio> 
{
    private PessoaFamiliaBusiness pessoaFamiliaBusiness;
    
    public BeneficioBusiness(AppRepository<Beneficio> beneficioRepository, PessoaFamiliaBusiness pessoaFamiliaBusiness) : base (beneficioRepository)
    {
        this.pessoaFamiliaBusiness = pessoaFamiliaBusiness;
        
    }
    public void CalcularBeneficio(int familiaId)
    {
        var familiaRecuperada = pessoaFamiliaBusiness.RecuperarFamiliaPorId(familiaId);
        var titularAtivo = familiaRecuperada?.TipoVinculo.Equals(ETipoVinculo.TITULAR);
        if (titularAtivo is null || (titularAtivo is not null && familiaRecuperada?.DataDesvinculo is not null))
        {
            throw new Exception("impossível prosseguir sem um titular ativo");
        }

    }

    public void Validacao(int familiaId)
    {
        var familiaRecuperada = pessoaFamiliaBusiness.RecuperarFamiliaPorId(familiaId);
        var titularAtivo = familiaRecuperada?.TipoVinculo.Equals(ETipoVinculo.TITULAR);
        if (titularAtivo is null || (titularAtivo is not null && familiaRecuperada?.DataDesvinculo is not null))
        {
            throw new Exception("impossível prosseguir sem um titular ativo");
        }

        DateTime dataAtual = DateTime.Now;
        var listaPessoaFamilia = pessoaFamiliaBusiness.RecuperarListaPorId(familiaId);
        var idadePessoaLista = listaPessoaFamilia?.Select(p => p.Pessoa.DataNascimento).ToList();

        foreach( var nascimento in idadePessoaLista ) 
        {
            if (nascimento.Year) { }
        }
        
        if (diferenca > 17)
        {

        }

    }
}
