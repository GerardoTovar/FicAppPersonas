using System;
using System.Collections.Generic;
using System.Text;
using FicAppPersonas.Models.Asistencia;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Data;

namespace FicAppPersonas.Interfaces.BecCatClientes
{
    public interface IFicSrvBecCatClientesEdit
    {
        Task FicMetGetEditBecCatClientes(bec_cat_clientes item);// CREATE
        Task<IEnumerable<rh_cat_grupos>> FicMetGetListRhCatGenerales(int id);//GET GENERALES
    }
}
