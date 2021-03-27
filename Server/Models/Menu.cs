using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroAcademicoApp.Server.Models
{
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMenu { get; set; }
        public string OpcionMenu { get; set; }
        public string NombreMenu { get; set; }
        public string Icono { get; set; }

        public virtual ICollection<Perfiles> Perfiles { get; set; }
    }
}
