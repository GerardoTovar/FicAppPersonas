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
using FicAppPersonas.Interfaces.RhCatTelefonos;

namespace FicAppPersonas.Services.RhCatTelefonos
{
    public class FicSrvRhCatTelefonosNew : IFicSrvRhCatTelefonosNew
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private FicDBContext FicLoBDContext;

        public FicSrvRhCatTelefonosNew()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task FicMetGetNewRhCatTelefonos(rh_cat_telefonos telefono)
        {
            try
            {

                if (telefono.Principal == "S")
                {
                    using (await ficMutex.LockAsync().ConfigureAwait(false))
                    {                        
                        var tels_list = FicLoBDContext.rh_cat_telefonos.Where(c => 
                        //c.IdTelefono == telefono.IdTelefono &&
                        int.Parse(c.ClaveReferencia) == int.Parse(telefono.ClaveReferencia))
                        .ToList();
                        if (tels_list.Count != 0)
                        {
                            //FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());                            
                            foreach (rh_cat_telefonos tel in tels_list) {
                                tel.Principal = "N";
                                FicLoBDContext.Entry(tel).State = EntityState.Modified;
                                FicLoBDContext.SaveChanges();
                            }
                            
                        }
                    }
                }

                //List<rh_cat_telefonos> telefonos = new List<rh_cat_telefonos>();
                var telefonos = await (from t_telefonos in FicLoBDContext.rh_cat_telefonos select t_telefonos).AsNoTracking().ToListAsync();
                telefono.IdTelefono = 1;
                if (telefonos.Count != 0)
                {
                    var mx_id = telefonos.Max(x => x.IdTelefono);
                    telefono.IdTelefono += mx_id;
                }

                using (await ficMutex.LockAsync().ConfigureAwait(false))
                {
                    FicLoBDContext.rh_cat_telefonos.Add(telefono);
                    FicLoBDContext.SaveChanges();
                }
            }
            catch (Exception e) {
                
            }
            

        }

        public async Task<IEnumerable<cat_generales>> FicMetGetListRhCatGenerales(int id)
        {
            var generales = await (from gen in FicLoBDContext.cat_generales where gen.IdTipoGeneral == id select gen).AsNoTracking().ToListAsync();
            return generales;
        }
    }
}
