using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Interfaces.BecInstitutosPersonas
{
    public interface IFicSrvBecInstitutosPersonasDetail
    {
        //Task<IEnumerable<bec_institutos_personas>> FicMetGetDetailInstitutosPersonas(bec_institutos_personas b_ins_per);// GET DATA FROM bec_institutos_person
        Task<IEnumerable<cat_institutos>> FicMetGetListRhCatInstitutos();//GET INSTITUTOS
        Task<IEnumerable<rh_cat_perfiles>> FicMetGetList();//GET GENERALES

    }
}
