using System;
using System.Collections.Generic;



namespace Control_de_Visitas.Models
{
    public partial class Portero
    {
        public int IdPortero { get; set; }
        public string NombreP { get; set; }
        public string ApellidoO { get; set; }
        public int? IdVisitante { get; set; }
        public int? IdUsuario { get; set; }
        public int Estatus { get; set; }

        public virtual Estatus EstatusNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual Visitante IdVisitanteNavigation { get; set; }
    }
}
