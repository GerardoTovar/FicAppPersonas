using FicAppPersonas.Data;
using FicAppPersonas.Interfaces.RhCatAlumnos;
using FicAppPersonas.Interfaces.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;

using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Services.RhCatAlumnos
{
    public class FicSrvRhCatAlumnosList : IFicSrvRhCatAlumnosList
    {
        private readonly FicDBContext FicLoBDContext;

        public FicSrvRhCatAlumnosList()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task<IEnumerable<rh_cat_alumnos>> FicMetGetListRhCatAlumnos(int id)
        {
            return await (from inv in FicLoBDContext.rh_cat_alumnos where inv.IdAlumno == id select inv).AsNoTracking().ToListAsync();
        }

    }
}