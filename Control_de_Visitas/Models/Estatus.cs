using System;
using System.Collections.Generic;



namespace Control_de_Visitas.Models
{
    public partial class Estatus
    {
        public Estatus()
        {
            Categoria = new HashSet<Categorium>();
            Porteros = new HashSet<Portero>();
            TipoVisitantes = new HashSet<TipoVisitante>();
            Usuarios = new HashSet<Usuario>();
            Visitantes = new HashSet<Visitante>();
        }

        public int Estatus1 { get; set; }
        public string DetalleEstatus { get; set; }

        public virtual ICollection<Categorium> Categoria { get; set; }
        public virtual ICollection<Portero> Porteros { get; set; }
        public virtual ICollection<TipoVisitante> TipoVisitantes { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Visitante> Visitantes { get; set; }
    }
}
