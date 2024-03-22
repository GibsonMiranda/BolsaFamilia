using BolsaFamilia.Shared.Entity.Entity;
using BolsaFamilia.Shared.Entity.Entity.Enum;
using BolsaFamilia.Shared.Infra;

namespace BolsaFamilia.Business.Business;

public class AliquotaTipoBeneficioBusiness : AppBusiness<AliquotaTipoBeneficio>
{
    public AliquotaTipoBeneficioBusiness(AppRepository<AliquotaTipoBeneficio> aliquotaTipoBeneficioReoository) : base(aliquotaTipoBeneficioReoository) { }
       
    public void CadastrarAliquotaTipoBeneficio(double valor, ETipoBeneficio tipoBeneficio)
    {
        AliquotaTipoBeneficio aliquotaTipoBeneficio = new AliquotaTipoBeneficio() 
        { 
            Valor = valor, 
            TipoBeneficio = tipoBeneficio, 
            Data = DateTime.Now
        };
        Repository.Adicionar(aliquotaTipoBeneficio);
        Console.WriteLine($"aliquota cadastrada com sucesso! Aliquota: {tipoBeneficio}");
    }

    public double ObterAliquotaVigente (ETipoBeneficio eTipoBeneficio)
    {
        return Repository.RecuperarListaPor(a => a.TipoBeneficio.Equals(eTipoBeneficio))
                         .OrderBy(a => a.Data)
                         .FirstOrDefault()!.Valor;
    }

}
