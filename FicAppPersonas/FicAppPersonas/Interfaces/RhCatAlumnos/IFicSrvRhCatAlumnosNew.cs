using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Interfaces.RhCatAlumnos
{
    public interface IFicSrvRhCatAlumnosNew
    {
        Task FicMetGetNewRhCatAlumnos(rh_cat_alumnos item);// CREATE
        Task<IEnumerable<eva_cat_carreras>> FicMetGetListRhCaCarreras();

    }
}
