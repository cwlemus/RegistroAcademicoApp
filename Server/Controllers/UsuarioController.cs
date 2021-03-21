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
  
    public class UsuarioController : Controller
    {
        [HttpPost]
        [Route("api/Usuario/login")]
        public int login([FromBody] UsuarioCls oUsuario)
        {
            int rpta = 0;
            try
            {
                using (RegistroAcademicoContext cn = new RegistroAcademicoContext())
                {
                    string clave = oUsuario.pass;
                    /* SHA256Managed sha = new SHA256Managed();
                     byte[] buffer = Encoding.Default.GetBytes(clave);
                     byte[] dataCifrada = sha.ComputeHash(buffer);
                     string dataCifradaCadena = BitConverter.ToString(dataCifrada);*/


                    int nveces = cn.Usuarios.Where(p => p.nombre == oUsuario.nombre && p.pass == oUsuario.pass).Count();
                    if (nveces == 0)
                    {
                        rpta = 0;
                    }
                    else
                    {
                        rpta = cn.Usuarios.Where(p => p.nombre == oUsuario.nombre && p.pass == oUsuario.pass).First().idUsuario;
                    }
                }
            }
            catch (Exception)
            {

                rpta = 0;
            }
            return rpta;
        }


        [HttpGet]
        [Route("api/Usuario/Get")]
        public List<UsuarioCls> Get()
        {
            List<UsuarioCls> lista = new List<UsuarioCls>();
            using (RegistroAcademicoContext db = new RegistroAcademicoContext())
            {
                lista = (from u in db.Usuarios
                         select new UsuarioCls
                         {                             
                                 idUsuario = u.idUsuario,
                                 nombre = u.nombre,
                                 pass =u.pass
                           
                         }).ToList();
            }
            return lista;

        }

    }
}
