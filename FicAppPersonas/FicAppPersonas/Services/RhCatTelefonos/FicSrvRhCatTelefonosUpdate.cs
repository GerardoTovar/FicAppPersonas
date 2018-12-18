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
    public class FicSrvRhCatTelefonosUpdate : IFicSrvRhCatTelefonosUpdate
    {
        private FicDBContext FicLoBDContext;
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        public FicSrvRhCatTelefonosUpdate()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task FicMetUpdateEdificio(rh_cat_telefonos item)
        {
            if (item.Principal == "S")
            {
                using (await ficMutex.LockAsync().ConfigureAwait(false))
                {
                    var tels_list = FicLoBDContext.rh_cat_telefonos.Where(c =>
                    //c.IdTelefono == telefono.IdTelefono &&
                    int.Parse(c.ClaveReferencia) == int.Parse(item.ClaveReferencia))
                    .ToList();
                    if (tels_list.Count != 0)
                    {                        
                        foreach (rh_cat_telefonos tel in tels_list)
                        {
                            tel.Principal = "N";
                            FicLoBDContext.Entry(tel).State = EntityState.Modified;
                            FicLoBDContext.SaveChanges();
                        }

                    }
                }
            }

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
