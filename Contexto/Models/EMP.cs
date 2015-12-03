using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contexto.Models
{
    public partial class EMP
    {
        public EMP()
        {
            this.APLs = new List<APL>();
        }

        public int CODIGO { get; set; }
        [Required(ErrorMessage = "Preenchimento obrigatorio!!!")]
        public string NOME { get; set; }
        [Required(ErrorMessage = "Preenchimento obrigatorio!!!")]
        public string RAZAOSOCIAL { get; set; }
        public virtual ICollection<APL> APLs { get; set; }
    }
}
