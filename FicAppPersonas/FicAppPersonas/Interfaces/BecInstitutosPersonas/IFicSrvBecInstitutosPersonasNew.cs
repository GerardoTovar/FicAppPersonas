using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Interfaces.BecInstitutosPersonas
{
    public interface IFicSrvBecInstitutosPersonasNew
    {
        Task FicMetGetNewBecInstitutosPersonas(bec_institutos_personas item);// CREATE
        Task<IEnumerable<cat_institutos>> FicMetGetListRhCatInstitutos();//GET INSTITUTOS
        Task<IEnumerable<rh_cat_perfiles>> FicMetGetList();//GET GENERALES
        Task<IEnumerable<bec_institutos_personas>> FicMetGetListBecInstitutosPersonas(int IdPersona);//READ


    }
}
