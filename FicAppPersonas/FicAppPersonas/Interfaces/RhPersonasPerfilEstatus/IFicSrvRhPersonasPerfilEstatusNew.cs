using System;
using System.Collections.Generic;
using System.Text;
using FicAppPersonas.Models.Asistencia;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Data;

namespace FicAppPersonas.Interfaces.RhPersonasPerfilEstatus
{
    public interface IFicSrvRhPersonasPerfilEstatusNew
    {
        Task FicMetGetNewRhPersonasPerfilEstatus(rh_personas_perfil_estatus item);// CREATE
        Task<IEnumerable<cat_estatus>> FicMetGetListRhCatGenerales(int id);//GET GENERALES
    }
}
