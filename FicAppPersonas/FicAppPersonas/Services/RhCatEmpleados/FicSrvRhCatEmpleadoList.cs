using FicAppPersonas.Interfaces.RhCatEmpleados;
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

namespace FicAppPersonas.Services.RhCatEmpleados
{
    public class FicSrvRhCatEmpleadoList : IFicSrvRhCatEmpleadosList
    {
        private readonly FicDBContext FicLoBDContext;

        public FicSrvRhCatEmpleadoList() {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task<IEnumerable<rh_cat_empleados>> FicMetGetListRhCatEmpleados(int id)
        {
            return await (from inv in FicLoBDContext.rh_cat_empleados where inv.IdEmpleado == id select inv).AsNoTracking().ToListAsync();
        }

    }
}
