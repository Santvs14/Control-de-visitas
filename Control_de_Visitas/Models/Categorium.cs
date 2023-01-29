using System;
using System.Collections.Generic;



namespace Control_de_Visitas.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdCategoria { get; set; }
        public string NombreCa { get; set; }
        public int Estatus { get; set; }

        public virtual Estatus EstatusNavigation { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
