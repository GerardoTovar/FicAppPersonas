
using FicAppPersonas.Interfaces.RhCatPersonasDatosAdicionales;
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

namespace FicAppPersonas.Services.RhCatPersonasDatosAdicionales
{
    public class FicSrvRhCatPersonasDatosAdicionalesList : IFicSrvRhCatPersonasDatosAdicionalesList
    {
        private readonly FicDBContext FicLoBDContext;

        public FicSrvRhCatPersonasDatosAdicionalesList()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task<IEnumerable<rh_cat_personas_datos_adicionales>> FicMetGetListRhCatPersonasDatosAdicionales(int IdPersona)
        {
            var personasdatosadicionales = await (from perdatadi in FicLoBDContext.rh_cat_personas_datos_adicionales where perdatadi.IdPersona == IdPersona select perdatadi).AsNoTracking().ToListAsync();
            return personasdatosadicionales;
        }

    }
}
