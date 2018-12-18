using System;
using System.Collections.Generic;
using System.Text;
using FicAppPersonas.Models.Asistencia;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Data;
namespace FicAppPersonas.Interfaces.RhCatEmpleados
{
    public interface IFicSrvRhCatEmpleadosList
    {
        Task<IEnumerable<rh_cat_empleados>> FicMetGetListRhCatEmpleados(int id);//READ
    }
}
