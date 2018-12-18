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

using Microsoft.EntityFrameworkCore;

using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Services.RhCatDirWeb
{
    public class FicSrvRhCatDirWebNew : IFicSrvRhCatDirWebNew
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        public FicDBContext FicLoBDContext;

        public FicSrvRhCatDirWebNew()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task<IEnumerable<cat_generales>> FicMetGetListRhCatGenerales(int id)
        {
            var generales = await (from gen in FicLoBDContext.cat_generales where gen.IdTipoGeneral == id select gen).AsNoTracking().ToListAsync();
            return generales;
        }

        public async Task<IEnumerable<cat_institutos>> FicMetGetListRhCatGenDirWeb()
        {
            var institutos = await (from inst in FicLoBDContext.cat_institutos select inst).AsNoTracking().ToListAsync();
            return institutos;
        }

        public async Task FicMetGetNewRhCatDirWeb(rh_cat_dir_web DirWeb)
        {

            if (DirWeb.Principal == "S")
            {
                using (await ficMutex.LockAsync().ConfigureAwait(false))
                {
                    var dirs_list = FicLoBDContext.rh_cat_dir_web.Where(c =>
                    //c.IdTelefono == telefono.IdTelefono &&
                    int.Parse(c.ClaveReferencia) == int.Parse(DirWeb.ClaveReferencia))
                    .ToList();
                    if (dirs_list.Count != 0)
                    {                        
                        foreach (rh_cat_dir_web tel in dirs_list)
                        {
                            tel.Principal = "N";
                            FicLoBDContext.Entry(tel).State = EntityState.Modified;
                            FicLoBDContext.SaveChanges();
                        }

                    }
                }
            }

            var per = await (from inst in FicLoBDContext.rh_cat_dir_web select inst).AsNoTracking().ToListAsync();
            DirWeb.IdDirWeb = 1;
            if (per.Count != 0)
            {
                var mx_id = per.Max(x => x.IdDirWeb);
                DirWeb.IdDirWeb += mx_id;
            }

            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.rh_cat_dir_web.Add(DirWeb);
                FicLoBDContext.SaveChanges();
            }
        }
    }
}
