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
    public class FicSrvRhCatDomiciliosUpdate : IFicSrvRhCatDomiciliosUpdate
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private  FicDBContext FicLoBDContext;

        public FicSrvRhCatDomiciliosUpdate()
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
            try
            {

                if (domicilio.Principal == "S")
                {
                    using (await ficMutex.LockAsync().ConfigureAwait(false))
                    {
                        var doms_list = FicLoBDContext.rh_cat_domicilios.Where(c =>

                        int.Parse(c.ClaveReferencia) == int.Parse(domicilio.ClaveReferencia)
                        && c.Principal == "S")                        
                        .ToList();
                        if (doms_list.Count != 0)
                        {
                            
                            foreach (rh_cat_domicilios dom in doms_list)
                            {
                                dom.Principal = "N";
                                FicLoBDContext.Entry(dom).State = EntityState.Modified;
                                FicLoBDContext.SaveChanges();
                            }
                        }
                    }
                }
                FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());                            
                using (await ficMutex.LockAsync().ConfigureAwait(false))
                {
                    FicLoBDContext.Entry(domicilio).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    FicLoBDContext.SaveChanges();
                }
            }
            catch (Exception e) {

            }
        }
    }
}
