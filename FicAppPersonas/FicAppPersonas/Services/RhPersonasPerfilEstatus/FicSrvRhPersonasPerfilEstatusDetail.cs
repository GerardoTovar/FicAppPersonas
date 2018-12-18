using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.RhPersonasPerfilEstatus;
using FicAppPersonas.Interfaces.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FicAppPersonas.Services.RhPersonasPerfilEstatus
{
    public class FicSrvRhPersonasPerfilEstatusDetail : IFicSrvRhPersonasPerfilEstatusDetail
    {

        private FicDBContext FicLoBDContext;
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        public FicSrvRhPersonasPerfilEstatusDetail()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task FicMetDetalleEdificio(rh_personas_perfil_estatus item)
        {
            /* FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
             using (await ficMutex.LockAsync().ConfigureAwait(false))
             {
                 FicLoBDContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                 FicLoBDContext.SaveChanges();
             }*/
        }
        public async Task<IEnumerable<cat_estatus>> FicMetGetListRhCatGenerales(int id)
        {
            var generales = await (from gen in FicLoBDContext.cat_estatus where gen.IdTipoEstatus == id select gen).AsNoTracking().ToListAsync();
            return generales;
        }

    }
}