using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Interfaces.BecCatClientes
{
    public interface IFicSrvBecCatClientesDetail
    {
        Task<IEnumerable<rh_cat_grupos>> FicMetGetListRhCatGenerales(int id);//GET GENERALES
    }
}
