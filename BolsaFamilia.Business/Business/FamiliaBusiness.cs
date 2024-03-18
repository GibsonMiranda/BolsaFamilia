using BolsaFamilia.Infra;
using BolsaFamilia.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaFamilia.Business
{
    public class FamiliaBusiness (AppRepository<Familia> familiaRepository)
    {
        public void CadastrarFamilia(Familia familia) 
        {
            ValidarDados(familia);
            familiaRepository.Adicionar(familia);
        }

        private void ValidarDados(Familia familia)
        {
            if (familia.Estado is null || familia.Logradouro is null || familia.Numero is null
                || familia.Cep is null || familia.Cidade is null || familia.Complemento is null || familia.Beneficio is null)
            {
                throw new Exception("valores nulos. Tente novamente");
            }
        }
    }
}
