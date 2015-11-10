using System;
using System.Collections.Generic;

namespace Contexto.Models
{
    public partial class CLI
    {
        public CLI()
        {
            this.APLs = new List<APL>();
        }

        public int CODIGO { get; set; }
        public Nullable<int> EMP_CODIGO { get; set; }
        public string NOME { get; set; }
        public string RAZAOSOCIAL { get; set; }
        public string CPF_CNPJ { get; set; }
        public string END { get; set; }
        public string COMP { get; set; }
        public string CEP { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }
        public string UF { get; set; }
        public string TEL { get; set; }
        public string CEL { get; set; }
        public string OBS { get; set; }
        public virtual ICollection<APL> APLs { get; set; }
    }
}
