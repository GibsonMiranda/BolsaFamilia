using BolsaFamilia.Business.Business;
using BolsaFamilia.Business.Validacao;
using BolsaFamilia.Shared.Entity.Entity;
using BolsaFamilia.Shared.Infra;

namespace BolsaFamilia.Business;

public class PessoaBusiness : AppBusiness<Pessoa>
{
    public PessoaBusiness(AppRepository<Pessoa> pessoaRepository) : base(pessoaRepository) { }
        
    public void CadastrarPessoa(Pessoa pessoa) // objeto pessoa vindo do front end
    {           
        ValidarDadosNulos(pessoa);
        var validarCpf = ValidacaoCpf.ValidarCpf(pessoa.Cpf);
        pessoa.Cpf = validarCpf.Item2;

        var pessoaExistente = Repository.RecuperarUmPor(p => p.Cpf.Equals(pessoa.Cpf));
        if (pessoaExistente is not null ) 
        {
            throw new Exception("CPF já está cadastro na base de dados");
        }
        if (validarCpf.Item1)
        {
            Repository.Adicionar(pessoa);
            Console.WriteLine("Cadastro Realizado Com Sucesso!");
        }          
    }

    public void AtualizarDadosCadastrais(Pessoa pessoa)
    {
        ValidarDadosNulos(pessoa);
        var pessoaExistente = Repository.RecuperarUmPor(p => p.Id == pessoa.Id);
        var cpf = ValidacaoCpf.ValidarCpf(pessoa.Cpf).Item2;
        if (!pessoaExistente!.Cpf.Equals(cpf))
        {
            throw new Exception("O campo CPF não pode ser alterado");
        }
        pessoaExistente.Nome = pessoa.Nome;
        pessoaExistente.DataNascimento = pessoa.DataNascimento;
        Repository.Atualizar(pessoaExistente);
        Console.WriteLine("alteração realizada com sucesso");
    }
    private void ValidarDadosNulos(Pessoa pessoa)
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

