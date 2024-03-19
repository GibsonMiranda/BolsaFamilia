using BolsaFamilia.Shared.Entity.Entity.Enum;

namespace BolsaFamilia.Shared.Entity.Entity;

public class PessoaFamilia : IEntity
{
    public int Id { get; set; }
    public virtual Pessoa Pessoa { get; set; }
    public virtual Familia Familia { get; set; }
    public ETipoVinculo TipoVinculo { get; set; }
    public DateTime DataVinculo { get; set; }
    public DateTime? DataDesvinculo { get; set; }
    public ETipoDesvinculo? MotivoDesvinculo { get; set; }
}
