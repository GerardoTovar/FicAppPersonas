using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.RhCatPersonas;
using FicAppPersonas.Interfaces.SQLite;
using FicAppPersonas.Models.Asistencia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using System.Threading.Tasks;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using Microsoft.EntityFrameworkCore;


namespace FicAppPersonas.Services.RhCatPersonas
{
    public class FicSrvRhCatPersonasEdit : IFicSrvRhCatPersonasEdit
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private  FicDBContext FicLoBDContext;

        public FicSrvRhCatPersonasEdit()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task FicMetGetEditRhCatPersonas(rh_cat_personas item)
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                FicLoBDContext.SaveChanges();
            }
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

        public async Task FicMetGetNewRhCatPersonas(rh_cat_personas persona)
        {
            var per = await (from inst in FicLoBDContext.rh_cat_personas select inst).AsNoTracking().ToListAsync();
            persona.IdPersona = 1;
            if (per.Count != 0)
            {
                var mx_id = per.Max(x => x.IdPersona);
                persona.IdPersona += mx_id;
            }

            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.rh_cat_personas.Add(persona);
                FicLoBDContext.SaveChanges();
            }
        }
    }
}
