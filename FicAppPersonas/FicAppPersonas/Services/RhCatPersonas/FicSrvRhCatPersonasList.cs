using FicAppPersonas.Interfaces.RhCatPersonas;
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

namespace FicAppPersonas.Services.RhCatPersonas
{
    public class FicSrvRhCatPersonasList : IFicSrvRhCatPersonasList
    {
        private readonly FicDBContext FicLoBDContext;

        public FicSrvRhCatPersonasList() {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task<IEnumerable<rh_cat_personas>> FicMetGetListRhCatPersonas()
        {
            return await (from inv in FicLoBDContext.rh_cat_personas select inv).AsNoTracking().ToListAsync();
        }

    }
}
