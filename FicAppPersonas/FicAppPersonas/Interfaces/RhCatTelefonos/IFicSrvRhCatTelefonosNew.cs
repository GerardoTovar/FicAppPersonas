using System.Collections.Generic;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Interfaces.RhCatTelefonos
{
    public interface IFicSrvRhCatTelefonosNew
    {
        Task FicMetGetNewRhCatTelefonos(rh_cat_telefonos item);// CREATE
        Task<IEnumerable<cat_generales>> FicMetGetListRhCatGenerales(int id);//GET GENERALES
    }
}


