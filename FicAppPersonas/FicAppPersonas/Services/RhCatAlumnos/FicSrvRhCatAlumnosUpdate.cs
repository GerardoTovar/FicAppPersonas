using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.RhCatAlumnos;
using FicAppPersonas.Interfaces.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FicAppPersonas.Services.RhCatAlumnos
{
    public class FicSrvRhCatAlumnosUpdate : IFicSrvRhCatAlumnosUpdate
    {
        private FicDBContext FicLoBDContext;
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        public FicSrvRhCatAlumnosUpdate()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task FicMetUpdateAlumnos(rh_cat_alumnos item)
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
                FicLoBDContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                FicLoBDContext.SaveChanges();
            }
        }
        public async Task<IEnumerable<eva_cat_carreras>> FicMetGetListRhCaCarreras()
        {
            var institutos = await (from inst in FicLoBDContext.eva_cat_carreras select inst).AsNoTracking().ToListAsync();
            return institutos;
        }

    }
}
