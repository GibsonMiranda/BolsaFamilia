﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaFamilia.Modelos
{
    public class RendaPessoa
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
}