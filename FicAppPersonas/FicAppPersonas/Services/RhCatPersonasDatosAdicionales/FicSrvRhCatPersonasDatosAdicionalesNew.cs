using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.RhCatPersonasDatosAdicionales;
using FicAppPersonas.Interfaces.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FicAppPersonas.Services.RhCatPersonasDatosAdicionales
{
    public class FicSrvRhCatPersonasDatosAdicionalesNew : IFicSrvRhCatPersonasDatosAdicionalesNew
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private readonly FicDBContext FicLoBDContext;

        public FicSrvRhCatPersonasDatosAdicionalesNew()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task FicMetGetNewRhCatEmpleados(rh_cat_personas_datos_adicionales personadatoadicional)
        {
            var telefonos = await (from dato in FicLoBDContext.rh_cat_personas_datos_adicionales where personadatoadicional.IdPersona == dato.IdPersona select dato).AsNoTracking().ToListAsync();
            personadatoadicional.IdDatoAdicional = 1;
            if (telefonos.Count != 0)
            {
                var mx_id = telefonos.Max(x => x.IdDatoAdicional);
                personadatoadicional.IdDatoAdicional += mx_id;
            }
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.rh_cat_personas_datos_adicionales.Add(personadatoadicional);
                FicLoBDContext.SaveChanges();
            }

        }
        public async Task<IEnumerable<cat_generales>> FicMetGetListRhCatGenerales(int id)
        {
            var generales = await (from gen in FicLoBDContext.cat_generales where gen.IdTipoGeneral == id select gen).AsNoTracking().ToListAsync();
            return generales;
        }
    }
}
