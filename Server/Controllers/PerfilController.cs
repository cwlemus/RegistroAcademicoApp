using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroAcademicoApp.Server.Models;
using RegistroAcademicoApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroAcademicoApp.Server.Controllers
{   
    

    [ApiController]
    public class PerfilController : Controller
    {
        [HttpGet]
        [Route("api/Perfil/GetPerfiles/{nombreUsuario}")]
        public List<MenuCls> GetPerfiles(string nombreUsuario)
        {
            List<MenuCls> lstMenu = new List<MenuCls>();
            using (RegistroAcademicoContext db = new RegistroAcademicoContext())
            {
                var listaSegunPerfil = db.Perfiles.Include(p => p.UsuarioIdMenuNavigation).
                    Include(p => p.Usuario).Where(p => p.Usuario.nombre == nombreUsuario).ToList();

                if (listaSegunPerfil != null)
                {
                    foreach (var op in listaSegunPerfil)
                    {
                        MenuCls menu = new MenuCls()
                        {
                            IdMenu = op.UsuarioIdMenuNavigation.IdMenu,
                            OpcionMenu = op.UsuarioIdMenuNavigation.OpcionMenu,
                            NombreMenu = op.UsuarioIdMenuNavigation.NombreMenu,
                            Icono = op.UsuarioIdMenuNavigation.Icono
                        };
                        lstMenu.Add(menu);
                    }
                }
            }
            return lstMenu;
        }
    }


    /*
    [ApiController]
    public class PerfilController : Controller
    {
        [HttpGet]
        [Route("api/Perfil/obtenerPerfil/{idPerfil}")]
        public PerfilCls obtenerPerfil(int idPerfil)
        {
            PerfilCls clteCls = new PerfilCls();
            using (RegistroAcademicoContext db = new RegistroAcademicoContext())
            {
                clteCls = (from perfil in db.Perfiles
                           where perfil.IdPerfil == idPerfil
                           select new PerfilCls
                           {
                               IdPerfil = perfil.IdPerfil,                               
                               UsuarioPerfil = new UsuarioCls()
                               {
                                   idUsuario= perfil.Usuario.idUsuario,
                                   nombre= perfil.Usuario.nombre,
                                   pass= perfil.Usuario.pass
                               }

                           }).First();

            }
            return clteCls;
        }

        [HttpPost]
        [Route("api/Perfil/Guardar")]
        public async Task<ActionResult<int>> Guardar(PerfilCls pefilCls)
        {

            int rpta = 0;
            try
            {

                using (RegistroAcademicoContext db = new RegistroAcademicoContext())
                {
                    Perfiles oPerfil = new Perfiles();
                    if (pefilCls.IdPerfil == 0)
                    {
                        oPerfil.IdPerfil = pefilCls.IdPerfil;
                        oPerfil.UsuarioIdMenuNavigation = new Menu()
                        {
                            Icono = pefilCls.UsuarioIdMenuNavigation.Icono,
                            NombreMenu = pefilCls.UsuarioIdMenuNavigation.NombreMenu,
                            OpcionMenu = pefilCls.UsuarioIdMenuNavigation.OpcionMenu
                        };
                        oPerfil.Usuario = new Usuario()
                        {
                            idUsuario = pefilCls.UsuarioPerfil.idUsuario,
                            nombre = pefilCls.UsuarioPerfil.nombre,
                            pass = pefilCls.UsuarioPerfil.pass
                        };
                        db.Usuarios.Attach(oPerfil.Usuario);
                        db.Perfiles.Add(oPerfil);
                    }
                    else
                    {
                        Perfiles p = db.Perfiles.Where(g => g.IdPerfil == pefilCls.IdPerfil).FirstOrDefault();
                        p.UsuarioIdMenuNavigation = new Menu()
                        {
                            Icono = pefilCls.UsuarioIdMenuNavigation.Icono,
                            NombreMenu = pefilCls.UsuarioIdMenuNavigation.NombreMenu,
                            OpcionMenu = pefilCls.UsuarioIdMenuNavigation.OpcionMenu
                        };
                        p.Usuario = new Usuario()
                        {
                            idUsuario = pefilCls.UsuarioPerfil.idUsuario,
                            nombre = pefilCls.UsuarioPerfil.nombre,
                            pass = pefilCls.UsuarioPerfil.pass
                        };
                    }
                    await db.SaveChangesAsync();
                    rpta = 1;
                }


            }
            catch (Exception)
            {
                rpta = 0;
            }
            return rpta;
        }





        [HttpGet]
        [Route("api/Perfil/EliminarPerfil/{data?}")]
        public int eliminarPerfil(string data)
        {
            int rpta = 0;
            try
            {
                using (RegistroAcademicoContext db = new RegistroAcademicoContext())
                {
                    int idPerfil = int.Parse(data);
                    Perfiles perfil = db.Perfiles.Where(p => p.IdPerfil == idPerfil).First();
                    db.Attach(perfil);
                    db.Remove(perfil);
                    db.SaveChanges();
                    rpta = 1;
                }
            }
            catch (Exception)
            {

                rpta = 0;
            }
            return rpta;
        }




        [HttpGet]
        [Route("api/Perfil/Filtrar/{data?}")]
        public List<PerfilCls> Filtrar(string data)
        {
            List<PerfilCls> lista = new List<PerfilCls>();
            using (RegistroAcademicoContext db = new RegistroAcademicoContext())
            {
                if (data == null)
                {
                    lista = (from p in db.Perfiles
                             select new PerfilCls
                             {
                                 IdPerfil = p.IdPerfil,
                                 UsuarioIdMenuNavigation = new MenuCls()
                                 {
                                     Icono = p.UsuarioIdMenuNavigation.Icono,
                                     NombreMenu = p.UsuarioIdMenuNavigation.NombreMenu,
                                     OpcionMenu = p.UsuarioIdMenuNavigation.OpcionMenu
                                 },
                    UsuarioPerfil = new UsuarioCls()
                                 {
                                     idUsuario = p.Usuario.idUsuario,
                                     nombre = p.Usuario.nombre
                                 }
                             }).ToList();
                }

                else
                {
                    lista = (from p in db.Perfiles
                             where p.IdPerfil.ToString().Contains(data) || p.UsuarioIdMenuNavigation.OpcionMenu.Contains(data) 
                             select new PerfilCls
                             {
                                 IdPerfil = p.IdPerfil,
                                 UsuarioIdMenuNavigation = new MenuCls()
                                 {
                                     Icono = p.UsuarioIdMenuNavigation.Icono,
                                     NombreMenu = p.UsuarioIdMenuNavigation.NombreMenu,
                                     OpcionMenu = p.UsuarioIdMenuNavigation.OpcionMenu
                                 },
                                 UsuarioPerfil = new UsuarioCls()
                                 {
                                     idUsuario = p.Usuario.idUsuario,
                                     nombre = p.Usuario.nombre
                                 }
                             }).ToList();

                }
            }
            return lista;

        }


        [HttpGet]
        [Route("api/Perfil/Get")]
        public List<PerfilCls> Get()
        {
            List<PerfilCls> lista = new List<PerfilCls>();
            using (RegistroAcademicoContext db = new RegistroAcademicoContext())
            {

                var lstA = db.Perfiles.ToList(); 
                   lista = (from p in db.Perfiles.Include(per=>per.Usuario).Include(m=>m.UsuarioIdMenuNavigation)
                         select new PerfilCls
                         {
                             IdPerfil = p.IdPerfil,
                            UsuarioIdMenuNavigation = new MenuCls()
                             {
                                 Icono = p.UsuarioIdMenuNavigation.Icono,
                                 NombreMenu = p.UsuarioIdMenuNavigation.NombreMenu,
                                 OpcionMenu = p.UsuarioIdMenuNavigation.OpcionMenu
                             },
                             UsuarioPerfil = new UsuarioCls()
                             {
                                 idUsuario= p.Usuario.idUsuario,
                                 nombre= p.Usuario.nombre
                             }
                         }).ToList();
            }
            return lista;

        }

    }*/
}
