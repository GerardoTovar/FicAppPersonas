using System;
using System.Collections.Generic;
using System.Text;
using FicAppPersonas.Models.Asistencia;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Data;
namespace FicAppPersonas.Interfaces.RhCatPersonas
{
    public interface IFicSrvRhCatPersonasList
    {
        Task<IEnumerable<rh_cat_personas>> FicMetGetListRhCatPersonas();//READ
    }
}
