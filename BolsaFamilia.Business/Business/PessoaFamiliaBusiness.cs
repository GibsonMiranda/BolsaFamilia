using BolsaFamilia.Business.Business;
using BolsaFamilia.Shared.Entity.Entity;
using BolsaFamilia.Shared.Entity.Entity.Enum;
using BolsaFamilia.Shared.Infra;

namespace BolsaFamilia.Business;

public class PessoaFamiliaBusiness : AppBusiness<PessoaFamilia>
{
    public PessoaFamiliaBusiness(AppRepository<PessoaFamilia> pessoaFamiliaRepository) : base(pessoaFamiliaRepository) { }
   
    
    public void VincularMembroFamilia(Pessoa pessoa, Familia familia, ETipoVinculo vinculo)
    {
        ValidarDados(pessoa, familia, vinculo);
        PessoaFamilia pessoaFamilia = new PessoaFamilia 
        {
            Pessoa = pessoa,
            Familia = familia,
            TipoVinculo = vinculo
        };
        Repository.Adicionar(pessoaFamilia);

    }

    public void RemoverMembroFamilia(PessoaFamilia pessoaFamilia, ETipoDesvinculo motivoDesvinculo)
    {
           
        if (pessoaFamilia.TipoVinculo.Equals(ETipoVinculo.TITULAR))
        {
            pessoaFamilia.Familia.Beneficio.DataBloqueio = DateTime.Now;
            pessoaFamilia.Familia.Beneficio.MotivoBloqueio = EMotivoBloqueio.REMOCAO_TITULAR;
        }
        pessoaFamilia.MotivoDesvinculo = motivoDesvinculo;
        pessoaFamilia.DataDesvinculo = DateTime.Now;
        Repository.Atualizar(pessoaFamilia);
        Console.WriteLine("alteração realizada com sucesso!");
    }

    private void ValidarDados(Pessoa pessoa, Familia familia, ETipoVinculo vinculo)
    {
        var titularExistente = Repository.RecuperarUmPor(p => p.TipoVinculo.Equals(ETipoVinculo.TITULAR)
                                                         && p.Familia.Id == familia.Id && p.DataDesvinculo is null);      
        if (!vinculo.Equals(ETipoVinculo.TITULAR) && titularExistente is null)
        {
            throw new Exception("primeiro informe o titular");
        } 
        else if (vinculo.Equals(ETipoVinculo.TITULAR) && titularExistente is not null)
        {
            throw new Exception("nao é possível cadastrar mais de um titular");
        }
        
        var conjugeExistente = Repository.RecuperarUmPor(p => p.TipoVinculo.Equals(ETipoVinculo.CONJUGE)
                                                                    && p.Familia.Id == familia.Id && p.DataDesvinculo is null);
        if (vinculo.Equals(ETipoVinculo.CONJUGE) && conjugeExistente is not null)
        {
            throw new Exception("não é possível cadastrar mais de um cônjuge");
        }
        var pessoaAtiva = Repository.RecuperarUmPor(p => p.DataDesvinculo is null && p.Pessoa.Id == pessoa.Id);
        if (pessoaAtiva is not null) 
        {
            var mensagem = pessoaAtiva.Familia.Id.Equals(familia.Id) ? "Pessoa já adicionada à familia" : "Pessoa já possui vínculo com outra família";
            throw new Exception(mensagem);
        }
    }
}

