using System;
using System.Collections.Generic;
using System.Text;
using FicAppPersonas.Models.Asistencia;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Data;
namespace FicAppPersonas.Interfaces.RhCatEmpleados
{
    public interface IFicSrvRhCatEmpleadosNew
    {
        Task FicMetGetNewRhCatEmpleados(rh_cat_empleados item);// CREATE
    }
}


