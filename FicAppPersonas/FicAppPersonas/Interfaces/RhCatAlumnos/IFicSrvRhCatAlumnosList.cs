using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Interfaces.RhCatAlumnos
{
    public interface IFicSrvRhCatAlumnosList
    {
        Task<IEnumerable<rh_cat_alumnos>> FicMetGetListRhCatAlumnos(int id);//READ

    }
}
