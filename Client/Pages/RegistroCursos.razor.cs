using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using RegistroAcademicoApp.Shared;


namespace RegistroAcademicoApp.Client.Pages
{
    public partial class RegistroCursos
    {
        private int cbxMaestro;
        private CursoCls CursoSelected;
        public MaestrosCls[] LstMaestros { get; set; } = null;
        public List<CursoCls> LstCursos { get; set; } = null;

            public void BuscarCursoPorMaestro()
        {
            LstCursos = null;
            MaestrosCls maestroSelected = new MaestrosCls();
            maestroSelected = LstMaestros.Where(c=>c.MaestroId == cbxMaestro).First();
            LstCursos = maestroSelected.CursosPresencialMaestros;
        }

        private async Task <IEnumerable<CursoCls>> buscarCursos(string seachText)
        {
            if (!seachText.Equals(""))
            {
                return await Task.FromResult(LstCursos.Where(x => x.NombreCurso.ToLower().Contains(seachText.ToLower())).ToList());
            }
            else
            {
                return await Task.FromResult(LstCursos);
            }
        }
    }
}
