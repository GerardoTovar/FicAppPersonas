using System;
using System.Collections.Generic;
using System.Text;
using FicAppPersonas.Models.Asistencia;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Data;
namespace FicAppPersonas.Interfaces.RhCatPersonas
{
    public interface IFicSrvRhCatPersonasPerfilesList
    {
        Task<IEnumerable<rh_cat_personas_perfiles>> FicMetGetListRhCatPersonasPerfiles(int IdPersona);//READ
    }
}
