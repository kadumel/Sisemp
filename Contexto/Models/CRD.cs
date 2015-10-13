using System;
using System.Collections.Generic;

namespace Contexto.Models
{
    public partial class CRD
    {
        public CRD()
        {
            this.RDMs = new List<RDM>();
        }

        public int CODIGO { get; set; }
        public int CODIGO_PAI { get; set; }
        public string NOME { get; set; }
        public virtual ICollection<RDM> RDMs { get; set; }
    }
}
