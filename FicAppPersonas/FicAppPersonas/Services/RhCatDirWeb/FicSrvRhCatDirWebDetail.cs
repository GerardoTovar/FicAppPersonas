using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.RhCatDirWeb;
using FicAppPersonas.Interfaces.SQLite;

using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

using System.Linq;
using Microsoft.EntityFrameworkCore;



namespace FicAppPersonas.Services.RhCatDirWeb
{
    public class FicSrvRhCatDirWebDetail : IFicSrvRhCatDirWebDetail
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private readonly FicDBContext FicLoBDContext;

        public FicSrvRhCatDirWebDetail()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public Task FicMetGetDetailRhCatDirWeb(rh_cat_dir_web item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<cat_generales>> FicMetGetListRhCatGenerales(int id)
        {
            var generales = await (from gen in FicLoBDContext.cat_generales where gen.IdTipoGeneral == id select gen).AsNoTracking().ToListAsync();
            return generales;
        }

    }
}
