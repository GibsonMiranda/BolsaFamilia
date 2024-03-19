namespace BolsaFamilia.Shared.Entity.Entity;

public class Familia : IEntity
{
    public int Id { get; set; }
    public virtual Beneficio Beneficio { get; set; }        
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Cep { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Complemento { get; set; }

}
