using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.RhCatDomicilios;
using FicAppPersonas.Interfaces.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Services.RhCatDomicilios
{
    public class FicSrvRhCatDomiciliosNew : IFicSrvRhCatDomiciliosNew
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private  FicDBContext FicLoBDContext;

        public FicSrvRhCatDomiciliosNew()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

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

        public async Task FicMetGetNewRhCatDomicilios(rh_cat_domicilios domicilio)
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
             try{

                if (domicilio.Principal == "S")
                {
                    using (await ficMutex.LockAsync().ConfigureAwait(false))
                    {                        
                        var doms_list = FicLoBDContext.rh_cat_domicilios.Where(c => 
                        
                        c.ClaveReferencia == domicilio.ClaveReferencia)
                        .ToList();
                        if (doms_list.Count != 0)
                        {
                            //FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());                            
                            foreach (rh_cat_domicilios dom in doms_list) {
                                dom.Principal = "N";
                                FicLoBDContext.Entry(dom).State = EntityState.Modified;
                                FicLoBDContext.SaveChanges();
                            }
                            
                        }
                    }
                }
                
                var domicilios = await (from dom in FicLoBDContext.rh_cat_domicilios select dom).AsNoTracking().ToListAsync();
                domicilio.IdDomicilio = 1;
                if (domicilios.Count != 0)
                {
                    var mx_id = domicilios.Max(x => x.IdDomicilio);
                    domicilio.IdDomicilio += mx_id;
                }    
           

                using (await ficMutex.LockAsync().ConfigureAwait(false))
                {
                    FicLoBDContext.rh_cat_domicilios.Add(domicilio);
                    FicLoBDContext.SaveChanges();
                }
             }
             catch (Exception e)
             {

             }
        }
    }
}
