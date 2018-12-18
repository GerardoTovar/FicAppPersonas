using FicAppPersonas.Data;
using FicAppPersonas.Interfaces.RhCatDirWeb;
using FicAppPersonas.Interfaces.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using Microsoft.EntityFrameworkCore;


namespace FicAppPersonas.Services.RhCatDirWeb
{
    public class FicSrvRhCatDirWebList : IFicSrvRhCatDirWebList
    {

        private readonly FicDBContext FicLoBDContext;

        public FicSrvRhCatDirWebList()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task<IEnumerable<rh_cat_dir_web>> FicMetGetListRhCatDirWeb(int IdPersona)
        {
            var dirsweb = await (from dirsw in FicLoBDContext.rh_cat_dir_web where int.Parse(dirsw.ClaveReferencia) == IdPersona select dirsw).AsNoTracking().ToListAsync();
            return dirsweb;
        }

    }
}
