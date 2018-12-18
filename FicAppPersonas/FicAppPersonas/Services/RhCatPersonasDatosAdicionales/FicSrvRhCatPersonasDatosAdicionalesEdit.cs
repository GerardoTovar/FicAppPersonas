using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.RhCatPersonasDatosAdicionales;
using FicAppPersonas.Interfaces.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FicAppPersonas.Services.RhCatPersonasDatosAdicionales
{
    public class FicSrvRhCatPersonasDatosAdicionalesEdit : IFicSrvRhCatPersonasDatosAdicionalesEdit
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private  FicDBContext FicLoBDContext;

        public FicSrvRhCatPersonasDatosAdicionalesEdit()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR


        public async Task FicMetGetEditRhCatEmpleados(rh_cat_personas_datos_adicionales item)
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
    }
}