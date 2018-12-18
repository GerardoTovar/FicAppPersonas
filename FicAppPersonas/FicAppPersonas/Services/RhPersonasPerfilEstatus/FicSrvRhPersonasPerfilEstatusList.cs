using FicAppPersonas.Interfaces.RhPersonasPerfilEstatus;
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
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using System.Linq;

namespace FicAppPersonas.Services.RhPersonasPerfilEstatus
{
    public class FicSrvRhPersonasPerfilEstatusList : IFicSrvRhPersonasPerfilEstatusList
    {
        private readonly FicDBContext FicLoBDContext;

        public FicSrvRhPersonasPerfilEstatusList()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task<IEnumerable<rh_personas_perfil_estatus>> FicMetGetListRhPersonasPerfilEstatusList(rh_cat_personas_perfiles estaus_per)
        {
            return await (from inv in FicLoBDContext.rh_personas_perfil_estatus where inv.IdPersona == estaus_per.IdPersona && inv.IdPerfil == estaus_per.IdPerfil select inv).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<rh_cat_perfiles>> FicMetGetListRhCatGenerales()
        {
            var generales = await (from gen in FicLoBDContext.rh_cat_perfiles select gen).AsNoTracking().ToListAsync();
            return generales;
        }

    }
}