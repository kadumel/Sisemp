using System;
using System.Collections.Generic;

namespace Contexto.Models
{
    public partial class EMP
    {
        public EMP()
        {
            this.APLs = new List<APL>();
        }

        public int CODIGO { get; set; }
        public string NOME { get; set; }
        public string RAZAOSOCIAL { get; set; }
        public virtual ICollection<APL> APLs { get; set; }
    }
}
