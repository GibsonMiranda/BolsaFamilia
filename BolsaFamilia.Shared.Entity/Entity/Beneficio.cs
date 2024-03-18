﻿using BolsaFamilia.Modelos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaFamilia.Modelos
{
    public class Beneficio
    {
        public int Id { get; set; }
        public virtual Familia Familia { get; set; }
        public int FamiliaId { get; set; }
        public bool Aprovado { get; set; }
        public EMotivoRejeicao MotivoRejeicao { get; set; }
    }
}