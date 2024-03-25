using BolsaFamilia.Shared.Entity.Entity;
using BolsaFamilia.Shared.Infra;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaFamilia.Business.Business;

public class HistoricoBeneficioBusiness : AppBusiness<HistoricoBeneficio>
{
    private AppRepository<HistoricoBeneficio> appRepository;
    public HistoricoBeneficioBusiness(AppRepository<HistoricoBeneficio> historicoRepository, AppRepository<HistoricoBeneficio> appRepository) : base(historicoRepository) 
    {
        this.appRepository = appRepository;
    }
    
    public void SalvarHistoricoBeneficio(Beneficio beneficio, double valor)
    {
        HistoricoBeneficio historicoBeneficio = new HistoricoBeneficio { Beneficio = beneficio, Valor = valor, Data = DateTime.Now};
        appRepository.Adicionar(historicoBeneficio);
    }

}
