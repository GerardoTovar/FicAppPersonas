using System;
using System.Collections.Generic;
using System.Text;
using FicAppPersonas.Models.Asistencia;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Data;

namespace FicAppPersonas.Interfaces.RhPersonasPerfilEstatus
{
    public interface IFicSrvRhPersonasPerfilEstatusDetail
    {
        Task<IEnumerable<cat_estatus>> FicMetGetListRhCatGenerales(int id);//GET GENERALES

    }
}


