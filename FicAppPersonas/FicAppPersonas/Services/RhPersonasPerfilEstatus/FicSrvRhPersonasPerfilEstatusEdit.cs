using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.RhPersonasPerfilEstatus;
using FicAppPersonas.Interfaces.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FicAppPersonas.Services.RhPersonasPerfilEstatus
{
    public class FicSrvRhPersonasPerfilEstatusEdit : IFicSrvRhPersonasPerfilEstatusEdit
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private  FicDBContext FicLoBDContext;

        public FicSrvRhPersonasPerfilEstatusEdit()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task FicMetGetEditRhPersonasPerfilEstatus(rh_personas_perfil_estatus item)
        {
            if (item.Actual == "S")
            {
                using (await ficMutex.LockAsync().ConfigureAwait(false))
                {
                    var estatus_list = FicLoBDContext.rh_personas_perfil_estatus.Where(c =>
                    c.IdPerfil == item.IdPerfil &&
                    c.IdPersona == item.IdPersona)
                    .ToList();
                    if (estatus_list.Count != 0)
                    {
                        //FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());                            
                        foreach (rh_personas_perfil_estatus est in estatus_list)
                        {
                            est.Actual = "N";
                            FicLoBDContext.Entry(est).State = EntityState.Modified;
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
        public async Task<IEnumerable<cat_estatus>> FicMetGetListRhCatGenerales(int id)
        {
            var generales = await (from gen in FicLoBDContext.cat_estatus where gen.IdTipoEstatus == id select gen).AsNoTracking().ToListAsync();
            return generales;
        }
    }
}
