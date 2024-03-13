using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaFamilia.Modelos
{
    public class HistoricoBeneficio
    {
        public int Id { get; set; }
        public virtual Beneficio Beneficio { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
