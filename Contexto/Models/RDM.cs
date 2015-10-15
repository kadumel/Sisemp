using System;
using System.Collections.Generic;

namespace Contexto.Models
{
    public partial class RDM
    {
        public int CODIGO { get; set; }
        public int MOV_CODIGO { get; set; }
        public int CRD_CODIGO { get; set; }
        public double VALOR { get; set; }
        public virtual CRD CRD { get; set; }
        public virtual MOV MOV { get; set; }
    }
}
