using BolsaFamilia.Shared.Entity.Entity.Enum;


namespace BolsaFamilia.Shared.Entity.Entity;
public class Beneficio : IEntity
{
    public int Id { get; set; }
    public virtual Familia Familia { get; set; }
    public int FamiliaId { get; set; }
    public bool Aprovado { get; set; }
    public EMotivoRejeicao? MotivoRejeicao { get; set; }
    public  DateTime? DataBloqueio { get; set; }
    public EMotivoBloqueio? MotivoBloqueio { get; set; }

}

