using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Interfaces.RhCatEmpleados
{
    public interface IFicSrvRhCatEmpleadosUpdate
    {
        Task FicMetGetUpdateRhCatEmpleados(rh_cat_empleados item);// CREATE

    }
}
