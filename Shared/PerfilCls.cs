using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAcademicoApp.Shared
{
    public class PerfilCls
    {
        public int IdPerfil { get; set; }   

        public int? UsuarioId { get; set; }
        public int? UsuarioIdMenu { get; set; }

        public virtual UsuarioCls UsuarioPerfil { get; set; }
        public virtual MenuCls UsuarioIdMenuNavigation { get; set; }
    }
}
