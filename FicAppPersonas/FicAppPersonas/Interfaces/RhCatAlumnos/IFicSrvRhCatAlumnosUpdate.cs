using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Interfaces.RhCatAlumnos
{
    public interface IFicSrvRhCatAlumnosUpdate
    {
        Task FicMetUpdateAlumnos(rh_cat_alumnos ficPa_eva_Cat_Edificios);
        Task<IEnumerable<eva_cat_carreras>> FicMetGetListRhCaCarreras();

    }
}
