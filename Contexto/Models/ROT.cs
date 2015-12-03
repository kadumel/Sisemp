using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contexto.Models
{
    public partial class ROT
    {
        public ROT()
        {
            this.CLIs = new List<CLI>();
            this.RDMs = new List<RDM>();
        }

        public int CODIGO { get; set; }
        [Required(ErrorMessage = "Rota deve ser informado!!!")]
        public string NOME { get; set; }
        [Required(ErrorMessage = "Informe os bairros pertencentes a rota!!!")]
        public string OBS { get; set; }
        public virtual ICollection<CLI> CLIs { get; set; }
        public virtual ICollection<RDM> RDMs { get; set; }
    }
}
