using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.RhCatAlumnos;
using FicAppPersonas.Interfaces.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace FicAppPersonas.Services.RhCatAlumnos
{
    public class FicSrvRhCatAlumnosNew : IFicSrvRhCatAlumnosNew
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private  FicDBContext FicLoBDContext;

        public FicSrvRhCatAlumnosNew()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task FicMetGetNewRhCatAlumnos(rh_cat_alumnos item)
        {
            var alumno_exist = await (from cat in FicLoBDContext.rh_cat_alumnos where cat.IdAlumno == item.IdAlumno select cat).AsNoTracking().ToListAsync();
            if (alumno_exist.Count != 0)
            {
                await new Page().DisplayAlert("ALERTA", "Ya se ha registrado numero de control para este alumno", "OK");
            }
            else
            {
                using (await ficMutex.LockAsync().ConfigureAwait(false))
                {
                    FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
                    FicLoBDContext.rh_cat_alumnos.Add(item);
                    FicLoBDContext.SaveChanges();
                }
            }
            
        }
        public async Task<IEnumerable<eva_cat_carreras>> FicMetGetListRhCaCarreras()
        {
            var institutos = await (from inst in FicLoBDContext.eva_cat_carreras select inst).AsNoTracking().ToListAsync();
            return institutos;
        }
    }
}
