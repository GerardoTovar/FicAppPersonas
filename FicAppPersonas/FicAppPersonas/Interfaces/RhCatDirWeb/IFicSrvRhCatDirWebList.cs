using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Interfaces.RhCatDirWeb
{
    public interface IFicSrvRhCatDirWebList
    {
        Task<IEnumerable<rh_cat_dir_web>> FicMetGetListRhCatDirWeb(int IdPersona);//READ

    }
}
