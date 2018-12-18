using System;
using System.Collections.Generic;
using System.Text;
using FicAppPersonas.Models.Asistencia;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Data;
namespace FicAppPersonas.Interfaces.RhPersonasPerfilEstatus
{
    public interface IFicSrvRhPersonasPerfilEstatusList
    {
        Task<IEnumerable<rh_personas_perfil_estatus>> FicMetGetListRhPersonasPerfilEstatusList(rh_cat_personas_perfiles estaus_per);//READ
        Task<IEnumerable<rh_cat_perfiles>> FicMetGetListRhCatGenerales();//GET GENERALES
    }
}
