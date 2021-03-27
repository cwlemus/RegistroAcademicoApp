using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroAcademicoApp.Server.Models
{
    public class Perfiles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPerfil { get; set; }
        public int? UsuarioIdMenu { get; set; }
        public int? UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Menu UsuarioIdMenuNavigation { get; set; }

        //public int IdPerfil { get; set; }
        //public string OpcionMenu { get; set; }

        //public int? UsuarioId { get; set; }

        //public virtual Usuario UsuarioPerfil { get; set; }
    }
}
