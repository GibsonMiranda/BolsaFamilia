using BolsaFamilia.Shared.Entity.Entity;
using BolsaFamilia.Shared.Infra;

namespace BolsaFamilia.Business.Business;
public class RendaPessoaBusiness : AppBusiness<RendaPessoa>
{
    private PessoaBusiness pessoaBusiness;
    public RendaPessoaBusiness(AppRepository<RendaPessoa> rendaPessoaRepository, PessoaBusiness pessoaBusiness) : base(rendaPessoaRepository) 
    {
        this.pessoaBusiness = pessoaBusiness; 
    }
    public void CadastrarRenda(Pessoa pessoa, double valor)
    {

        if (pessoa.Id == 0 || valor == 0)
        {
            throw new Exception("valor inválido, tente novamente");
        }
        var pessoaExistente = pessoaBusiness.Recuperar(pessoa);
        if (pessoaExistente is not null)
        {
            RendaPessoa cadastroRenda = new RendaPessoa() { DataRegistro = DateTime.Now, Valor = valor, Pessoa = pessoaExistente };
            Repository.Adicionar(cadastroRenda);
            Console.WriteLine("Renda Cadastrada Com Sucesso!");
        }
    }
}
    
