using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.RhCatEmpleados;
using FicAppPersonas.Interfaces.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Services.RhCatEmpleados
{
    public class FicSrvRhCatEmpleadosUpdate : IFicSrvRhCatEmpleadosUpdate
    {

        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private  FicDBContext FicLoBDContext;

        public FicSrvRhCatEmpleadosUpdate()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR



        public async Task FicMetGetUpdateRhCatEmpleados(rh_cat_empleados empleado)
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.Entry(empleado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                FicLoBDContext.SaveChanges();
            }
        }

    }
}
