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

namespace FicAppPersonas.Services.RhCatTelefonos
{
    public class FicSrvRhCatTelefonosList : IFicSrvRhCatTelefonosList
    {
        private readonly FicDBContext FicLoBDContext;

        public FicSrvRhCatTelefonosList()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task<IEnumerable<rh_cat_telefonos>> FicMetGetListRhCatTelefonos(int IdPersona)
        {
            var telefonos = await (from tel in FicLoBDContext.rh_cat_telefonos where int.Parse(tel.ClaveReferencia) == IdPersona select tel).AsNoTracking().ToListAsync();
            return telefonos;
        }

    }
}