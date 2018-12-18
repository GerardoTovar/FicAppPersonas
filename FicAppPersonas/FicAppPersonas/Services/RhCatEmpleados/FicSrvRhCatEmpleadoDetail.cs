

using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.RhCatEmpleados;
using FicAppPersonas.Interfaces.SQLite;

using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

using System.Linq;
using Microsoft.EntityFrameworkCore;



namespace FicAppPersonas.Services.RhCatEmpleados
{
    public class FicSrvRhCatEmpleadoDetail : IFicSrvRhCatEmpleadosDetail
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private readonly FicDBContext FicLoBDContext;

        public FicSrvRhCatEmpleadoDetail()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//CONSTRUCTOR


    }
}