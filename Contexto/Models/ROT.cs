using System;
using System.Collections.Generic;

namespace Contexto.Models
{
    public partial class ROT
    {
        public ROT()
        {
            this.MOVs = new List<MOV>();
        }

        public int CODIGO { get; set; }
        public string NOME { get; set; }
        public string MOTBOY { get; set; }
        public virtual ICollection<MOV> MOVs { get; set; }
    }
}
