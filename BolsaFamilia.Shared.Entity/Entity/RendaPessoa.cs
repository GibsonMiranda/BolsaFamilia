namespace BolsaFamilia.Shared.Entity.Entity;

public class RendaPessoa : IEntity
{ 
    public int Id { get; set; }
    public virtual Pessoa Pessoa { get; set; }
    public DateTime DataRegistro { get; set; }
    public double Valor { get; set; }

    public RendaPessoa()
    {
        DataRegistro = DateTime.Now;
    }
}
