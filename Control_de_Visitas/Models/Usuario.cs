using System;
using System.Collections.Generic;


namespace Control_de_Visitas.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Porteros = new HashSet<Portero>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdCategoria { get; set; }
        public int? IdVisitante { get; set; }
        public int Estatus { get; set; }

        public virtual Estatus EstatusNavigation { get; set; }
        public virtual Categorium IdCategoriaNavigation { get; set; }
        public virtual Visitante IdVisitanteNavigation { get; set; }
        public virtual ICollection<Portero> Porteros { get; set; }
    }
}
