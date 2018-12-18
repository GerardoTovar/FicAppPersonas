using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.RhCatPersonasPerfiles;
using FicAppPersonas.Interfaces.SQLite;
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
    public class FicSrvRhCatPersonasPerfilesDetail : IFicSrvRhCatPersonasPerfilesDetail
    {

        private FicDBContext FicLoBDContext;
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        public FicSrvRhCatPersonasPerfilesDetail()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task FicMetDetalleEdificio(rh_cat_personas_datos_adicionales personadatoadicional)
        {
            /* FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
             using (await ficMutex.LockAsync().ConfigureAwait(false))
             {
                 FicLoBDContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                 FicLoBDContext.SaveChanges();
             }*/
        }
        public async Task<IEnumerable<rh_cat_perfiles>> FicMetGetListRhCatGenerales()
        {
            var generales = await (from gen in FicLoBDContext.rh_cat_perfiles select gen).AsNoTracking().ToListAsync();
            return generales;
        }

    }
}
