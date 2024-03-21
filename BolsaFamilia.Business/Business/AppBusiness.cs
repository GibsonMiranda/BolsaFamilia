using BolsaFamilia.Shared.Entity.Entity;
using BolsaFamilia.Shared.Infra;

namespace BolsaFamilia.Business.Business;

public abstract class AppBusiness<T> where T : class, IEntity
{

    protected AppRepository<T> Repository;
    protected AppBusiness(AppRepository<T> appRepository)
    {
        Repository = appRepository;
    }
    //public T? RecuperarEntidade(T entidade)
    //{          
    //    var result = Repository.RecuperarUmPor(p => p.Id == entidade.Id);
    //    return result;
    //}
    public T? RecuperarPorId(int id)
    {
        var objeto = Repository.RecuperarUmPor(p => p.Id == id);
        return objeto;
    }

    public T? RecuperarPorCondicao(Func<T, bool> condicao)
    {
        var objeto = Repository.RecuperarUmPor(condicao);
        return objeto;
    }

    public IEnumerable<T>? RecuperarListaPorCondicao (Func<T, bool> condicao) 
    {
        var result = Repository.RecuperarListaPor(condicao);
        return result;
    }
}

