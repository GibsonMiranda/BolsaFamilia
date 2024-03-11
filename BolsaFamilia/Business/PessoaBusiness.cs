using BolsaFamilia.Business.Validacao;
using BolsaFamilia.Infra;
using BolsaFamilia.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaFamilia.Business
{
    internal class PessoaBusiness (AppRepository<Pessoa> pessoaRepository, AppRepository<RendaPessoa> rendaPessoa)
    {
        
        public void CadastrarPessoa(string nome, string cpf, DateTime nascimento)
        {
            Pessoa pessoa;
            ValidarDadosNulos(nome, cpf, nascimento);
            var cpfValido = ValidacaoCpf.ValidarCpf(cpf);
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpfValido)
            {
                pessoa = new Pessoa() { Nome = nome, Cpf = cpf, DataNascimento = nascimento};
                pessoaRepository.Adicionar(pessoa);
                Console.WriteLine("sucesso");
            }          
        }

        public void CadastrarRenda(int idPessoa, double valor)
        {
            if (idPessoa == null || valor == null ) 
            {
                throw new ArgumentNullException("valor nulo");
            }
            var pessoaExistente = pessoaRepository.RecuperarUmPor(p => p.Id == idPessoa);
            if (pessoaExistente is not null)
            {
                RendaPessoa cadastroRenda = new RendaPessoa() { DataRegistro = DateTime.Now, Valor = valor, Pessoa = pessoaExistente};
                rendaPessoa.Adicionar(cadastroRenda);
                Console.WriteLine("sucesso");
            }
        }


        public void ValidarDadosNulos(string nome, string cpf, DateTime nascimento)
        {
            if (nome == null || cpf == null || nascimento == null) 
            {
                throw new Exception("valor nulo");
            }
        }
    }
}
