using BolsaFamilia.Business.Business;
using BolsaFamilia.Infra;
using BolsaFamilia.Modelos;
using BolsaFamilia.Modelos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaFamilia.Business
{
    public class PessoaFamiliaBusiness : AppBusiness<PessoaFamilia>
    {
        public PessoaFamiliaBusiness(AppRepository<PessoaFamilia> pessoaFamiliaRepository,
        AppRepository<Pessoa> pessoaRepository, AppRepository<Familia> familiaRepository) : base (pessoaFamiliaRepository)
        {
            
        }

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

        

        private void ValidarDados(Pessoa pessoa, Familia familia, ETipoVinculo vinculo)
        {
            var titularExistente = Repository.RecuperarUmPor(p => p.TipoVinculo.Equals(ETipoVinculo.TITULAR)
                                                                        && p.Familia.Id == familia.Id);
            if (!vinculo.Equals(ETipoVinculo.TITULAR) && titularExistente is null) 
            {
                throw new Exception("primeiro informe o titular");
            }
            var pessoaAtiva = Repository.RecuperarUmPor(p => p.DataDesvinculo is null && p.Pessoa.Id == pessoa.Id);
            if (pessoaAtiva is not null) 
            {
                var mensagem = pessoaAtiva.Familia.Id.Equals(familia.Id) ? "Pessoa já adicionada à familia" : "Pessoa já possui vínculo com outra família";
                throw new Exception(mensagem);
            }
        }
    }
}
