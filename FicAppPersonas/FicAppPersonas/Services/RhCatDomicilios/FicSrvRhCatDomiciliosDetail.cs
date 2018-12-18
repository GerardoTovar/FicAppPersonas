using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.RhCatDomicilios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using Xamarin.Forms;
using FicAppPersonas.Interfaces.SQLite;

namespace FicAppPersonas.Services.RhCatDomicilios
{
   public class FicSrvRhCatDomiciliosDetail : IFicSrvRhCatDomiciliosDetail
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private readonly FicDBContext FicLoBDContext;

        public FicSrvRhCatDomiciliosDetail()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR


        public async Task<IEnumerable<rh_cat_domicilios>> FicMetGetDetaildomicilios(rh_cat_domicilios b_ins_per)// GET DATA FROM bec_institutos_person

        {

            var instper = await (from ip in FicLoBDContext.rh_cat_domicilios where ip.IdDomicilio == b_ins_per.IdDomicilio && ip.IdGenDom == b_ins_per.IdGenDom select ip).AsNoTracking().ToListAsync();
            return instper;
            //persona.IdPersona = 1;
            //if (per.Count != 0)
            //{
            //    var mx_id = per.Max(x => x.IdPersona);
            //    persona.IdPersona += mx_id;
            //}

            //using (await ficMutex.LockAsync().ConfigureAwait(false))
            //{
            //    FicLoBDContext.rh_cat_personas.Add(persona);
            //    FicLoBDContext.SaveChanges();
            //}
        }
        public async Task<IEnumerable<cat_generales>> FicMetGetListRhCatGenerales(int id)
        {
            var generales = await (from gen in FicLoBDContext.cat_generales where gen.IdTipoGeneral == id select gen).AsNoTracking().ToListAsync();
            return generales;
        }

        public async Task<IEnumerable<cat_paises>> FicMetGetListRhCaPaises()
        {
            var paises = await (from inst in FicLoBDContext.cat_paises select inst).AsNoTracking().ToListAsync();
            return paises;
        }

        public async Task<IEnumerable<cat_estados>> FicMetGetListRhCaEstados()
        {
            var estados = await (from inst in FicLoBDContext.cat_estados select inst).AsNoTracking().ToListAsync();
            return estados;
        }

        public async Task<IEnumerable<cat_municipios>> FicMetGetListRhCaMunincipios()
        {
            var municipios = await (from inst in FicLoBDContext.cat_municipios select inst).AsNoTracking().ToListAsync();
            return municipios;
        }

        public async Task<IEnumerable<cat_localidades>> FicMetGetListRhCaLocalidades()
        {
            var localidad = await (from inst in FicLoBDContext.cat_localidades select inst).AsNoTracking().ToListAsync();
            return localidad;
        }
        public async Task<IEnumerable<cat_colonias>> FicMetGetListRhCaColonias()
        {
            var colonias = await (from inst in FicLoBDContext.cat_colonias select inst).AsNoTracking().ToListAsync();
            return colonias;
        }




    }
}
