using BolsaFamilia.Modelos.Enum;
using BolsaFamilia.Shared.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaFamilia.Modelos
{
    public class AliquotaTipoBeneficio : IEntity
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public ETipoBeneficio TipoBeneficio { get; set; }
    }
}
