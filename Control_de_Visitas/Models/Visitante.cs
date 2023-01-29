using System;
using System.Collections.Generic;



namespace Control_de_Visitas.Models
{
    public partial class Visitante
    {
        public Visitante()
        {
            Porteros = new HashSet<Portero>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdVisitante { get; set; }
        public string NombreV { get; set; }
        public string ApellidoV { get; set; }
        public string Cedula { get; set; }
        public int IdTipo { get; set; }
        public DateTime FechaHora { get; set; }
        public int StatusVisita { get; set; }

        public virtual TipoVisitante IdTipoNavigation { get; set; }
        public virtual Estatus StatusVisitaNavigation { get; set; }
        public virtual ICollection<Portero> Porteros { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
