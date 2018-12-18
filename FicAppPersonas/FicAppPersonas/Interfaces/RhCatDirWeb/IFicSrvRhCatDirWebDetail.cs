using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Interfaces.RhCatDirWeb
{
   public interface IFicSrvRhCatDirWebDetail
    {

        Task FicMetGetDetailRhCatDirWeb(rh_cat_dir_web item);// CREATE
        Task<IEnumerable<cat_generales>> FicMetGetListRhCatGenerales(int id);//GET GENERALES

    }
}
