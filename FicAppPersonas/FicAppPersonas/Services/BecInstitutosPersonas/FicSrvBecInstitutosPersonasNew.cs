using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.BecInstitutosPersonas;
using FicAppPersonas.Interfaces.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;


using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Services.BecInstitutosPersonas
{
    public class FicSrvBecInstitutosPersonasNew : IFicSrvBecInstitutosPersonasNew
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private  FicDBContext FicLoBDContext;

        public FicSrvBecInstitutosPersonasNew()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task<IEnumerable<rh_cat_perfiles>> FicMetGetList()
        {
            var generales = await (from gen in FicLoBDContext.rh_cat_perfiles select gen).AsNoTracking().ToListAsync();
            return generales;
        }
        public async Task<IEnumerable<cat_institutos>> FicMetGetListRhCatInstitutos()
        {
            var institutos = await (from inst in FicLoBDContext.cat_institutos select inst).AsNoTracking().ToListAsync();
            return institutos;
        }

        public async Task<IEnumerable<bec_institutos_personas>> FicMetGetListBecInstitutosPersonas(int IdPersona)
        {
            return await (from inv in FicLoBDContext.bec_institutos_personas where inv.IdPersona == IdPersona select inv).AsNoTracking().ToListAsync();
        }



        public async Task FicMetGetNewBecInstitutosPersonas(bec_institutos_personas persona)
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            var per = await (from inst in FicLoBDContext.bec_institutos_personas select inst).AsNoTracking().ToListAsync();

            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.bec_institutos_personas.Add(persona);
                FicLoBDContext.SaveChanges();
            }
        }
    }
}
