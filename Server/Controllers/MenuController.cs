using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroAcademicoApp.Shared;
using RegistroAcademicoApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace RegistroAcademicoApp.Server.Controllers
{   
    [ApiController]
    public class MenuController : Controller
    {
      [HttpGet]
      [Route("api/Menu/GetMenUsuario/{usuario}")]
      public MenuCls[] GetMenUsuario(string usuario)
        {
            List<MenuCls> lst = new List<MenuCls>();
            using (RegistroAcademicoContext db = new RegistroAcademicoContext())
            {
                Menu menu = new Menu();
                var lista = db.Perfiles.Include(u => u.Usuario).Include(m => m.UsuarioIdMenuNavigation).Where(p => p.Usuario.nombre == usuario).ToList();
                foreach(Perfiles per in lista)
                {
                    menu = per.UsuarioIdMenuNavigation;
                }
            }
         
            return lst.ToArray();    
        }
    }
}
