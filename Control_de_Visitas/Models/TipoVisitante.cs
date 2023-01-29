using System;
using System.Collections.Generic;



namespace Control_de_Visitas.Models
{
    public partial class TipoVisitante
    {
        public TipoVisitante()
        {
            Visitantes = new HashSet<Visitante>();
        }

        public int IdTipo { get; set; }
        public string DetalleTipo { get; set; }
        public int StatusTipo { get; set; }

        public virtual Estatus StatusTipoNavigation { get; set; }
        public virtual ICollection<Visitante> Visitantes { get; set; }
    }
}
