using BolsaFamilia.Modelos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaFamilia.Modelos
{
    public class PessoaFamilia
    {
        public int Id { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual Familia Familia { get; set; }
        public ETipoVinculo TipoVinculo { get; set; }
        public DateTime DataVinculo { get; set; }
        public DateTime DataDesvinculo { get; set; }
        public ETipoDesvinculo MotivoDesvinculo { get; set; }
    }
}
