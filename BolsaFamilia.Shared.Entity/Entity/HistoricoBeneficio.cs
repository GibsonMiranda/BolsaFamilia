namespace BolsaFamilia.Shared.Entity.Entity;

public class HistoricoBeneficio : IEntity
{
    public int Id { get; set; }
    public virtual Beneficio Beneficio { get; set; }
    public double Valor { get; set; }
    public DateTime Data { get; set; }
}
