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
    public class FicSrvRhCatPersonasPerfilesList : IFicSrvRhCatPersonasPerfilesList
    {
        private readonly FicDBContext FicLoBDContext;

        public FicSrvRhCatPersonasPerfilesList() {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task<IEnumerable<rh_cat_personas_perfiles>> FicMetGetListRhCatPersonasPerfiles(int IdPersona)
        {
            return await (from perper in FicLoBDContext.rh_cat_personas_perfiles where perper.IdPersona == IdPersona select perper).AsNoTracking().ToListAsync();
        }

    }
}
