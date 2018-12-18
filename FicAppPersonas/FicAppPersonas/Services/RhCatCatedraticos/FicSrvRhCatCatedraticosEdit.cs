using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.RhCatCatedraticos;
using FicAppPersonas.Interfaces.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Services.RhCatCatedraticos
{
    public class FicSrvRhCatCatedraticosEdit : IFicSrvRhCatCatedraticosEdit
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private  FicDBContext FicLoBDContext;

        public FicSrvRhCatCatedraticosEdit()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task FicMetGetEditRhCatEmpleados(rh_cat_catedraticos item)
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
                FicLoBDContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                FicLoBDContext.SaveChanges();
            }
        }
    }
}