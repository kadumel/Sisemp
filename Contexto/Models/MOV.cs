using System;
using System.Collections.Generic;

namespace Contexto.Models
{
    public partial class MOV
    {
        public MOV()
        {
            this.RDMs = new List<RDM>();
        }

        public int CODIGO { get; set; }
        public int SEQUENCIAL { get; set; }
        public int APL_CODIGO { get; set; }
        public Nullable<int> ROT_CODIGO { get; set; }
        public System.DateTime DATA { get; set; }
        public double VALOR_TOTAL { get; set; }
        public Nullable<double> VALOR_REC { get; set; }
        public string OBS { get; set; }
        public virtual APL APL { get; set; }
        public virtual ROT ROT { get; set; }
        public virtual ICollection<RDM> RDMs { get; set; }
    }
}
