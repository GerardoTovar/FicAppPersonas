using FicAppPersonas.Interfaces.RhCatCatedraticos;
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

namespace FicAppPersonas.Services.RhCatCatedraticos
{
    public class FicSrvRhCatCatedraticosList : IFicSrvRhCatCatedraticosList
    {
        private readonly FicDBContext FicLoBDContext;

        public FicSrvRhCatCatedraticosList() {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task<IEnumerable<rh_cat_catedraticos>> FicMetGetListRhCatCatedraticos(int id)
        {
            return await (from inv in FicLoBDContext.rh_cat_catedraticos where inv.IdEmpleado == id select inv).AsNoTracking().ToListAsync();
        }

    }
}
