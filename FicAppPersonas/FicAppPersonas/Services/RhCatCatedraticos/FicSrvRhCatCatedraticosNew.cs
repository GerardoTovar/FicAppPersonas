using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.RhCatCatedraticos;
using FicAppPersonas.Interfaces.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Services.RhCatCatedraticos
{
    public class FicSrvRhCatCatedraticosNew : IFicSrvRhCatCatedraticosNew
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private readonly FicDBContext FicLoBDContext;

        public FicSrvRhCatCatedraticosNew()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task FicMetGetNewRhCatEmpleados(rh_cat_catedraticos item)
        {
            var catedratico_exist = await (from cat in FicLoBDContext.rh_cat_catedraticos where cat.IdEmpleado == item.IdEmpleado select cat).AsNoTracking().ToListAsync();
            if (catedratico_exist.Count != 0)
            {
                await new Page().DisplayAlert("ALERTA", "Ya se encuentra activo este catedratico", "OK");
            }
            else {
                using (await ficMutex.LockAsync().ConfigureAwait(false))
                {
                    FicLoBDContext.rh_cat_catedraticos.Add(item);
                    FicLoBDContext.SaveChanges();
                }
            }
            
        }
    }
}
