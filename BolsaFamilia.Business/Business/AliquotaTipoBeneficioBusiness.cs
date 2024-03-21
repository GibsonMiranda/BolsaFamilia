using BolsaFamilia.Shared.Entity.Entity;
using BolsaFamilia.Shared.Entity.Entity.Enum;
using BolsaFamilia.Shared.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaFamilia.Business.Business
{
    public class AliquotaTipoBeneficioBusiness : AppBusiness<AliquotaTipoBeneficio>
    {
        public AliquotaTipoBeneficioBusiness(AppRepository<AliquotaTipoBeneficio> aliquotaTipoBeneficioReoository) : base(aliquotaTipoBeneficioReoository) { }
           
        public void CadastrarAliquotaTipoBeneficio(double valor, ETipoBeneficio tipoBeneficio)
        {
            AliquotaTipoBeneficio aliquotaTipoBeneficio = new AliquotaTipoBeneficio();
            aliquotaTipoBeneficio.Valor = valor;
            aliquotaTipoBeneficio.TipoBeneficio.Equals(tipoBeneficio);
            aliquotaTipoBeneficio.Data = DateTime.Now;
            Repository.Adicionar(aliquotaTipoBeneficio);
           
        }

    }
}
