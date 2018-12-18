using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Interfaces.RhCatPersonasPerfiles
{
    public interface IFicSrvRhCatPersonasPerfilesDetail
    {
        Task<IEnumerable<rh_cat_perfiles>> FicMetGetListRhCatGenerales();//GET GENERALES
    }
}
