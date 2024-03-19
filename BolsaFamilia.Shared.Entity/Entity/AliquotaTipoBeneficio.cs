using BolsaFamilia.Shared.Entity.Entity.Enum;

namespace BolsaFamilia.Shared.Entity.Entity;

public class AliquotaTipoBeneficio : IEntity
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public double Valor { get; set; }
    public ETipoBeneficio TipoBeneficio { get; set; }
}

