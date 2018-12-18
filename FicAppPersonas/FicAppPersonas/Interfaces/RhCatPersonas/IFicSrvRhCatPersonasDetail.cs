using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Interfaces.RhCatPersonas
{
    public interface IFicSrvRhCatPersonasDetail
    {
        Task FicMetGetDetailRhCatPersonas(rh_cat_personas item);// CREATE
        Task<IEnumerable<cat_generales>> FicMetGetListRhCatGenerales(int id);//GET GENERALES
        Task<IEnumerable<cat_institutos>> FicMetGetListRhCatInstitutos();//GET INSTITUTOS
    }
}
