using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroAcademicoApp.Server.Models
{
    public partial class Perfiles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPerfil { get; set; }
        public int? UsuarioIdMenu { get; set; }
        public int? UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Menu UsuarioIdMenuNavigation { get; set; }
    }
}
