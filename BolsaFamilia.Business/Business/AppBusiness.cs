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
    public T? Recuperar(T entidade)
    {          
        var result = Repository.RecuperarUmPor(p => p.Id == entidade.Id);
        return result;
    }
    public T? RecuperarPorId(int id)
    {
        var objeto = Repository.RecuperarUmPor(p => p.Id == id);
        return objeto;
    }

    public IEnumerable<T>? RecuperarListaPorId (int id) 
    {
        var result = Repository.RecuperarListaPor(p => p.Id == id);
        return result;
    }
}

