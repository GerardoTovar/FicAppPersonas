using FicAppPersonas.Interfaces.RhCatTelefonos;
using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using FicAppPersonas.Data;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Interfaces.SQLite;
using FicAppPersonas.Helpers;
using FicAppPersonas.Models.Asistencia;

namespace FicAppPersonas.Services.RhCatTelefonos
{
    public class FicSrvRhCatTelefonosDetail : IFicSrvRhCatTelefonosDetail
    {
        private FicDBContext FicLoBDContext;
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        public FicSrvRhCatTelefonosDetail()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task<IEnumerable<cat_generales>> FicMetGetListRhCatGenerales(int id)
        {
            var generales = await (from gen in FicLoBDContext.cat_generales where gen.IdTipoGeneral == id select gen).AsNoTracking().ToListAsync();
            return generales;
        }

        public Task FicMetUpdateEdificio(rh_cat_telefonos ficPa_eva_Cat_Edificios)
        {
            throw new NotImplementedException();
        }
    }

}
