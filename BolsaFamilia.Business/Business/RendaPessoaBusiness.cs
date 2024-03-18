using BolsaFamilia.Infra;
using BolsaFamilia.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaFamilia.Business.Business
{
    public class RendaPessoaBusiness (AppRepository<RendaPessoa> rendaPessoaRepository, PessoaBusiness pessoaBusiness)
    {
        public void CadastrarRenda(Pessoa pessoa, double valor)
        {
             
            if (pessoa.Id == 0 || valor == 0)
            {
                throw new Exception("valor inválido, tente novamente");
            }
            var pessoaExistente = pessoaBusiness.RecuperarPessoaPorId(pessoa);
            if (pessoaExistente is not null)
            {
                RendaPessoa cadastroRenda = new RendaPessoa() { DataRegistro = DateTime.Now, Valor = valor, Pessoa = pessoaExistente };
                rendaPessoaRepository.Adicionar(cadastroRenda);
                Console.WriteLine("Renda Cadastrada Com Sucesso!");
            }
        }
    }
}
