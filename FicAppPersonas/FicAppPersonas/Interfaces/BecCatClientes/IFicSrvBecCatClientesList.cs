using System;
using System.Collections.Generic;
using System.Text;
using FicAppPersonas.Models.Asistencia;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Data;
namespace FicAppPersonas.Interfaces.BecCatClientes
{
    public interface IFicSrvBecCatClientesList
    {
        Task<IEnumerable<bec_cat_clientes>> FicMetGetListBecCatClientes(int IdPersona);//READ
    }
}
