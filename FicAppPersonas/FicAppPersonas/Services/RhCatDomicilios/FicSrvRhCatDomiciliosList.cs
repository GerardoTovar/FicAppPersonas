using FicAppPersonas.Data;
using FicAppPersonas.Interfaces.RhCatDomicilios;
using FicAppPersonas.Interfaces.RhCatTelefonos;
using FicAppPersonas.Interfaces.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using Microsoft.EntityFrameworkCore;

namespace FicAppPersonas.Services.RhCatDomicilios
{
    public class FicSrvRhCatDomiciliosList : IFicSrvRhCatDomiciliosList
    {
        private readonly FicDBContext FicLoBDContext;

        public FicSrvRhCatDomiciliosList()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task<IEnumerable<rh_cat_domicilios>> FicMetGetListRhCatDomicilios(int IdPersona)
        {
            return await (from domicilios in FicLoBDContext.rh_cat_domicilios where int.Parse(domicilios.ClaveReferencia) == IdPersona select domicilios).AsNoTracking().ToListAsync();
        }

    }
}