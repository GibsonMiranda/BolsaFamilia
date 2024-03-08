using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaFamilia.Modelos
{
    internal class Pessoa
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(11)]
        public string Cpf { get; set; }       
        public DateTime DataNascimento { get; set; }
    }
}
