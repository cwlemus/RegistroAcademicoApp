using Microsoft.AspNetCore.Mvc;
using RegistroAcademicoApp.Server.Models;
using RegistroAcademicoApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroAcademicoApp.Server.Controllers
{
    [ApiController]
    public class RegistroAcademicoController : Controller
    {
       [HttpPost]
       [Route("api/RegistroAcad/Guardar/{data?}")]
       public int Guardar(EncRegistroAcademico reg)
        {
            int regId = 0;

            using (var db=new RegistroAcademicoContext())
            {
                db.Estudiante.Attach(reg.EstudianteReg);
                EncRegistroAcademico ec = new EncRegistroAcademico()
                {
                    Fecha = DateTime.Now,                    
                    EstudianteReg = reg.EstudianteReg

                };
                ec.DetRegistroAcademicosDet = new List<DetRegistroAcademico>();
                DetRegistroAcademico dt = new DetRegistroAcademico();
                foreach (var item in reg.DetRegistroAcademicosDet)
                {
                    item.CursoEstudiante.CursoId = item.CursoEstudiante.CursoId;
                    db.Cursos.Attach(item.CursoEstudiante);
                    dt.CursoEstudiante = item.CursoEstudiante;
                    dt.CursosId = item.CursosId;
                    dt.EncRegistroAcademicoId = ec.EstudianteId;
                    dt.EncRegroAcademicoEnc = ec;
                    ec.DetRegId = dt.DetRegistroIdAcad;
                    ec.DetRegistroAcademicosDet.Add(dt);
                }
                
                db.EncRegistroAcademcico.Add(ec);
                db.SaveChanges();
            }

            return regId;
        }

    }
}
