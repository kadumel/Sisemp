using System;
using System.Collections.Generic;

namespace Contexto.Models
{
    public partial class APL
    {
        public APL()
        {
            this.MOVs = new List<MOV>();
        }

        public int CODIGO { get; set; }
        public int CLI_CODIGO { get; set; }
        public int EMP_CODIGO { get; set; }
        public Nullable<System.DateTime> DATA { get; set; }
        public Nullable<double> TAXA { get; set; }
        public Nullable<double> VALOR { get; set; }
        public Nullable<int> QTDE { get; set; }
        public Nullable<System.DateTime> DTBASE { get; set; }
        public virtual CLI CLI { get; set; }
        public virtual EMP EMP { get; set; }
        public virtual ICollection<MOV> MOVs { get; set; }
    }
}
