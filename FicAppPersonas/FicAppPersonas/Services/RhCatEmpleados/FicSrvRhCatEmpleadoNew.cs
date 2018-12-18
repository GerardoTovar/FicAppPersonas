using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.RhCatEmpleados;
using FicAppPersonas.Interfaces.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Services.RhCatEmpleados
{
    public class FicSrvRhCatEmpleadosNew : IFicSrvRhCatEmpleadosNew
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private readonly FicDBContext FicLoBDContext;

        public FicSrvRhCatEmpleadosNew()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task FicMetGetNewRhCatEmpleados(rh_cat_empleados item)
        {
            var empleado_exist = await (from cat in FicLoBDContext.rh_cat_empleados where cat.IdEmpleado == item.IdEmpleado select cat).AsNoTracking().ToListAsync();
            if (empleado_exist.Count != 0)
            {
                await new Page().DisplayAlert("ALERTA", "Ya se ha registrado numero de control para este empleado", "OK");
            }
            else
            {
                using (await ficMutex.LockAsync().ConfigureAwait(false))
                {
                    FicLoBDContext.rh_cat_empleados.Add(item);
                    FicLoBDContext.SaveChanges();
                }
            }
        }
    }
}
