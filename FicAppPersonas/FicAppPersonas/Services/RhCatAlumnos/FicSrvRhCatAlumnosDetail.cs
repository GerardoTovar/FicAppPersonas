using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.RhCatAlumnos;
using System.Linq;
using FicAppPersonas.Interfaces.SQLite;
using FicAppPersonas.Models.Asistencia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using Microsoft.EntityFrameworkCore;

namespace FicAppPersonas.Services.RhCatAlumnos
{
    public class FicSrvRhCatAlumnosDetail : IFicSrvRhCatAlumnosDetail
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private readonly FicDBContext FicLoBDContext;

        public FicSrvRhCatAlumnosDetail()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public Task FicMetGetDetailRhCatAlumnos(rh_cat_alumnos item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<eva_cat_carreras>> FicMetGetListRhCaCarreras()
        {
            var institutos = await (from inst in FicLoBDContext.eva_cat_carreras select inst).AsNoTracking().ToListAsync();
            return institutos;
        }
    }
}