using FicAppPersonas.Interfaces.BecCatClientes;
using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using FicAppPersonas.Data;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Interfaces.SQLite;

namespace FicAppPersonas.Services.BecCatClientes
{
    public class FicSrvBecCatClientesList : IFicSrvBecCatClientesList
    {
        private readonly FicDBContext FicLoBDContext;

        public FicSrvBecCatClientesList()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR

        public async Task<IEnumerable<bec_cat_clientes>> FicMetGetListBecCatClientes(int IdPersona)
        {
            var clientes = await (from cli in FicLoBDContext.bec_cat_clientes where cli.IdCliente == IdPersona select cli).AsNoTracking().ToListAsync();
            return clientes;
        }

    }
}