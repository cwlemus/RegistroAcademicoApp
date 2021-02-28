using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroAcademicoApp.Shared;
using RegistroAcademicoApp.Server.Models;

namespace RegistroAcademicoApp.Server.Controllers
{
    [ApiController]
    
    public class MaestroController : Controller
    {
        [HttpGet]
        [Route("api/Maestro/GetMaestros")]
        public List<Maestros> GetMaestros()
        {
            List<Maestros> lst = new List<Maestros>();
            using(RegistroAcademicoContext db = new RegistroAcademicoContext())
            {
                lst = (from maestro in db.Maestros
                             select new Maestros()
                             {
                                 MaestroId=maestro.MaestroId,
                                 Nombre = maestro.Nombre,
                                 CursosPresencialMaestros=maestro.CursosPresencialMaestros
                             }).ToList();
                
            }
            return lst;
        }
    }
}
