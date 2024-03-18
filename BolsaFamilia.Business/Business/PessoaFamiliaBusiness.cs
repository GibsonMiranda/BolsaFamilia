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
    public class PessoaFamiliaBusiness(AppRepository<PessoaFamilia> pessoaFamiliaRepository, 
        AppRepository<Pessoa> pessoaRepository, AppRepository<Familia> familiaRepository, PessoaFamilia pessoaFamilia)
    {
        public void VincularMembroFamilia(Pessoa pessoa, Familia familia, ETipoVinculo vinculo)
        {
            ValidarDados(pessoa, familia, vinculo);
            var titularExistente = pessoaFamiliaRepository.RecuperarUmPor(p => p.TipoVinculo.Equals(ETipoVinculo.TITULAR)
                                                                        && p.Familia.Id == familia.Id);
            
            pessoaFamilia.Familia = familia;
            pessoaFamilia.Pessoa = pessoa;
            pessoaFamilia.TipoVinculo = vinculo;
            pessoaFamiliaRepository.Adicionar(pessoaFamilia);

        }

        public void ValidarDados(Pessoa pessoa, Familia familia, ETipoVinculo vinculo)
        {
            var titularExistente = pessoaFamiliaRepository.RecuperarUmPor(p => p.TipoVinculo.Equals(ETipoVinculo.TITULAR)
                                                                        && p.Familia.Id == familia.Id);
            if (!vinculo.Equals(ETipoVinculo.TITULAR) && titularExistente is null) 
            {
                throw new Exception("primeiro informe o titular");
            }
            var pessoaAtiva = pessoaFamiliaRepository.RecuperarUmPor(p => p.DataDesvinculo is null && p.Pessoa.Id == pessoa.Id);
            if (pessoaAtiva is not null) 
            {
                var mensagem = pessoaAtiva.Familia.Id.Equals(familia.Id) ? "Pessoa já adicionada à familia" : "Pessoa já possui vínculo com outra família";
                throw new Exception(mensagem);
            }
        }
    }
}
