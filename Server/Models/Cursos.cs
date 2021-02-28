using System;
using System.Collections.Generic;

namespace RegistroAcademicoApp.Server.Models
{
    public partial class Cursos
    {
        public Cursos()
        {
            Estudiante = new HashSet<Estudiante>();
        }

        public int CursoId { get; set; }
        public string NombreCurso { get; set; }
        public string Descripcion { get; set; }
        public int? OnLineMaestrosId { get; set; }
        public int? PresencialMaestrosId { get; set; }

        public virtual Maestros OnLineMaestros { get; set; }
        public virtual Maestros PresencialMaestros { get; set; }
        public virtual ICollection<Estudiante> Estudiante { get; set; }
    }
}
