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

using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Services.BecCatClientes
{
    public class FicSrvBecCatClientesNew : IFicSrvBecCatClientesNew
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private  FicDBContext FicLoBDContext;

        public FicSrvBecCatClientesNew()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR


        public async Task<IEnumerable<rh_cat_grupos>> FicMetGetListRhCatGenerales(int id)
        {
            var generales = await (from gen in FicLoBDContext.rh_cat_grupos where gen.IdTipoGrupo == id select gen).AsNoTracking().ToListAsync();
            return generales;
        }

        public async Task FicMetGetNewRhCatEmpleados(bec_cat_clientes item)
        {
            var cliente_exist = await (from cat in FicLoBDContext.bec_cat_clientes where cat.IdCliente == item.IdCliente select cat).AsNoTracking().ToListAsync();
            if (cliente_exist.Count != 0)
            {
                await new Page().DisplayAlert("ALERTA", "Ya se ha registrado a este cliente", "OK");
            }
            else
            {
                FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
                using (await ficMutex.LockAsync().ConfigureAwait(false))
                {
                    FicLoBDContext.bec_cat_clientes.Add(item);
                    FicLoBDContext.SaveChanges();
                }
            }
        }
    }
}

