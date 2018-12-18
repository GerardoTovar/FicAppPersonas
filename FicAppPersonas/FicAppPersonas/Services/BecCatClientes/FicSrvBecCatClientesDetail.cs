using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.BecCatClientes;
using FicAppPersonas.Interfaces.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace FicAppPersonas.Services.BecCatClientes
{
    public class FicSrvBecCatClientesDetail : IFicSrvBecCatClientesDetail
    {

        private FicDBContext FicLoBDContext;
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        public FicSrvBecCatClientesDetail()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR
        public async Task<IEnumerable<rh_cat_grupos>> FicMetGetListRhCatGenerales(int id)
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            var generales = await (from gen in FicLoBDContext.rh_cat_grupos where gen.IdTipoGrupo == id select gen).AsNoTracking().ToListAsync();
            return generales;
        }

        public async Task FicMetDetalleEdificio(bec_cat_clientes item)
        {
            /* FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
             using (await ficMutex.LockAsync().ConfigureAwait(false))
             {
                 FicLoBDContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                 FicLoBDContext.SaveChanges();
             }*/
        }

    }
}