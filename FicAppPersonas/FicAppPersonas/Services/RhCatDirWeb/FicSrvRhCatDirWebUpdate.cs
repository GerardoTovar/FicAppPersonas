using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.RhCatDirWeb;
using FicAppPersonas.Interfaces.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using Microsoft.EntityFrameworkCore;

namespace FicAppPersonas.Services.RhCatDirWeb
{
    public class FicSrvRhCatDirWebUpdate : IFicSrvRhCatDirWebUpdate
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private  FicDBContext FicLoBDContext;

        public FicSrvRhCatDirWebUpdate()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task<IEnumerable<cat_generales>> FicMetGetListRhCatGenerales(int id)
        {
            var generales = await (from gen in FicLoBDContext.cat_generales where gen.IdTipoGeneral == id select gen).AsNoTracking().ToListAsync();
            return generales;
        }


        public async Task FicMetGetUpdateRhCatDirWeb(rh_cat_dir_web DirWeb)
        {
            if (DirWeb.Principal == "S")
            {
                using (await ficMutex.LockAsync().ConfigureAwait(false))
                {
                    var tels_list = FicLoBDContext.rh_cat_dir_web.Where(c =>
                    //c.IdTelefono == telefono.IdTelefono &&
                    int.Parse(c.ClaveReferencia) == int.Parse(DirWeb.ClaveReferencia))
                    .ToList();
                    if (tels_list.Count != 0)
                    {                        
                        tels_list.ForEach(a => a.Principal = "N");
                        FicLoBDContext.SaveChanges();
                    }
                }
            }

            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.Entry(DirWeb).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                FicLoBDContext.SaveChanges();
            }
        }

    }
}
