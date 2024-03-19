using System.ComponentModel.DataAnnotations;

namespace BolsaFamilia.Shared.Entity.Entity;

public class Pessoa : IEntity
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Nome { get; set; }

    [MaxLength(11)]
    public string Cpf { get; set; }       
    public DateTime DataNascimento { get; set; }
}
