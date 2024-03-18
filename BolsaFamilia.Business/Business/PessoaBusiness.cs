using BolsaFamilia.Business.Validacao;
using BolsaFamilia.Infra;
using BolsaFamilia.Modelos;

namespace BolsaFamilia.Business
{
    public class PessoaBusiness (AppRepository<Pessoa> pessoaRepository, AppRepository<RendaPessoa> rendaPessoa)
    {
        public Pessoa RecuperarPessoaPorId(Pessoa pessoa) 
        {
            ValidarDadosNulos(pessoa);
            var pessoaExistente = pessoaRepository.RecuperarUmPor(p => p.Id == pessoa.Id);
            return pessoaExistente;
        }

        public void CadastrarPessoa(Pessoa pessoa) // objeto pessoa vindo do front end
        {
            
            ValidarDadosNulos(pessoa);
            var validarCpf = ValidacaoCpf.ValidarCpf(pessoa.Cpf);
            pessoa.Cpf = validarCpf.Item2;

            var pessoaExistente = pessoaRepository.RecuperarUmPor(p => p.Cpf.Equals(pessoa.Cpf));
            if (pessoaExistente is not null ) 
            {
                throw new Exception("CPF já está cadastro na base de dados");
            }
            if (validarCpf.Item1)
            {
                pessoaRepository.Adicionar(pessoa);
                Console.WriteLine("Cadastro Realizado Com Sucesso!");
            }          
        }

        public void AtualizarDadosCadastrais(Pessoa pessoa)
        {
            ValidarDadosNulos(pessoa);
            var pessoaExistente = pessoaRepository.RecuperarUmPor(p => p.Id == pessoa.Id);

            if (!pessoaExistente.Cpf.Equals(pessoa.Cpf))
            {
                throw new Exception("O campo CPF não pode ser alterado");
            }
            pessoaExistente.Nome = pessoa.Nome;
            pessoaExistente.DataNascimento = pessoa.DataNascimento;
            pessoaRepository.Atualizar(pessoaExistente);
            Console.WriteLine("alteração realizada com sucesso");
        }
        public void ValidarDadosNulos(Pessoa pessoa)
        {
            if (pessoa is null)
            {
                throw new Exception("informe a pessoa para atualização");
            }
            if (pessoa.Nome is null || pessoa.Cpf is null) 
            {
                throw new Exception("Nome ou Cpf Inválidos!");
            }
        }
    }
}
