using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.RhCatPersonasPerfiles;
using FicAppPersonas.Interfaces.SQLite;
using FicAppPersonas.Models.Asistencia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FicAppPersonas.Services.RhCatPersonasPerfiles
{
    public class FicSrvRhCatPersonasPerfilesUpdate : IFicSrvRhCatPersonasPerfilesUpdate
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private  FicDBContext FicLoBDContext;

        public FicSrvRhCatPersonasPerfilesUpdate()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTO


        public async Task FicMetGetUpdateRhCatPersonasPerfiles(rh_cat_personas_perfiles item)
        {
            await FicMet();
            //FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                FicLoBDContext.SaveChanges();
            }
        }
        public async Task<IEnumerable<rh_cat_perfiles>> FicMetGetListRhCatGenerales()
        {
            var generales = await (from gen in FicLoBDContext.rh_cat_perfiles select gen).AsNoTracking().ToListAsync();
            return generales;
        }
        public async Task FicMet()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }



    }
}
