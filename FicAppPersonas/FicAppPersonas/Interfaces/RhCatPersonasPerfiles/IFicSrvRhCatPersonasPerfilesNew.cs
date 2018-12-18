using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Interfaces.RhCatPersonasPerfiles
{
    public interface IFicSrvRhCatPersonasPerfilesNew
    {
        Task FicMetGetNewRhCatPersonasPerfiles(rh_cat_personas_perfiles item);// CREATE
        Task<IEnumerable<rh_cat_perfiles>> FicMetGetListRhCatGenerales();//GET GENERALES

    }
}
