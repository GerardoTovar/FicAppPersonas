using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using Microsoft.EntityFrameworkCore;
using FicAppPersonas.Interfaces.RhCatPersonas;
using System.Linq;


namespace FicAppPersonas.Services.RhCatPersonas
{
    public class FicSrvRhCatPersonasDetail : IFicSrvRhCatPersonasDetail
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private readonly FicDBContext FicLoBDContext;

        public FicSrvRhCatPersonasDetail()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

             

        public async Task FicMetGetDetailRhCatPersonas(rh_cat_personas persona)
        {
            //var per = await (from inst in FicLoBDContext.rh_cat_personas select inst).AsNoTracking().ToListAsync();
            //persona.IdPersona = 1;
            //if (per.Count != 0)
            //{
            //    var mx_id = per.Max(x => x.IdPersona);
            //    persona.IdPersona += mx_id;
            //}

            //using (await ficMutex.LockAsync().ConfigureAwait(false))
            //{
            //    FicLoBDContext.rh_cat_personas.Add(persona);
            //    FicLoBDContext.SaveChanges();
            //}
        }

        public async Task<IEnumerable<cat_generales>> FicMetGetListRhCatGenerales(int id)
        {
            var generales = await (from gen in FicLoBDContext.cat_generales where gen.IdTipoGeneral == id select gen).AsNoTracking().ToListAsync();
            return generales;
        }

        public async Task<IEnumerable<cat_institutos>> FicMetGetListRhCatInstitutos()
        {
            var institutos = await (from inst in FicLoBDContext.cat_institutos select inst).AsNoTracking().ToListAsync();
            return institutos;
        }
    }
}
