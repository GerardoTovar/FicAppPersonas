
using System;
using System.Collections.Generic;
using System.Text;
using FicAppPersonas.Models.Asistencia;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Data;
namespace FicAppPersonas.Interfaces.RhCatPersonasDatosAdicionales
{
    public interface IFicSrvRhCatPersonasDatosAdicionalesList
    {
        Task<IEnumerable<rh_cat_personas_datos_adicionales>> FicMetGetListRhCatPersonasDatosAdicionales(int IdPersona);//READ
    }
}
