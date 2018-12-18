using FicAppPersonas.Data;
using FicAppPersonas.Interfaces.SQLite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Interfaces.ExportarWebApi;

namespace FicAppPersonas.Services.ExportarWebApi
{
    public class FicSrvExportarWebApi : IFicSrvExportarWebApi
    {
        private const string url = "http://localhost:53285//api/AddPerson";
        private readonly FicDBContext FicLoBDContext;
        private readonly HttpClient FiClient;

        public FicSrvExportarWebApi()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            FiClient = new HttpClient();
            FiClient.MaxResponseContentBufferSize = 256000;
        }//CONSTRUCTOR

        private async Task<string> FicPostListInventarios(reg_personas item)
        {                   
            var js = JsonConvert.SerializeObject(item);
            var uri = new Uri(string.Format(url, string.Empty));
            HttpResponseMessage response = await FiClient.PostAsync(
                new Uri(string.Format(url, string.Empty)),
                new StringContent(js, Encoding.UTF8, "application/json")
            );

            return await response.Content.ReadAsStringAsync();
        }//POST: A INVENTARIOS

        public async Task<string> FicPostExportInventarios()
        {

            return await FicPostListInventarios(new reg_personas()
            {
                rh_cat_personas = await (from a in FicLoBDContext.rh_cat_personas select a).ToListAsync(),
                bec_cat_clientes = await (from a in FicLoBDContext.bec_cat_clientes select a).ToListAsync(),
                bec_institutos_personas = await (from a in FicLoBDContext.bec_institutos_personas select a).ToListAsync(),
                rh_cat_alumnos = await (from a in FicLoBDContext.rh_cat_alumnos select a).ToListAsync(),
                rh_cat_catedraticos = await (from a in FicLoBDContext.rh_cat_catedraticos select a).ToListAsync(),
                rh_cat_dir_web = await (from a in FicLoBDContext.rh_cat_dir_web select a).ToListAsync(),
                rh_cat_domicilios = await (from a in FicLoBDContext.rh_cat_domicilios select a).ToListAsync(),
                rh_cat_empleados = await (from a in FicLoBDContext.rh_cat_empleados select a).ToListAsync(),
                rh_cat_personas_datos_adicionales = await (from a in FicLoBDContext.rh_cat_personas_datos_adicionales select a).ToListAsync(),
                rh_cat_telefonos = await (from a in FicLoBDContext.rh_cat_telefonos select a).ToListAsync(),
                rh_cat_personas_perfiles = await (from a in FicLoBDContext.rh_cat_personas_perfiles select a).ToListAsync(),
                rh_personas_perfil_estatus = await (from a in FicLoBDContext.rh_personas_perfil_estatus select a).ToListAsync(),                
            });
        }//METODO DE EXPORT INVENTARIOS

    }//CLASS 
}//NAMESPACE
