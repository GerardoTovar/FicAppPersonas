using System;
using System.Collections.Generic;
using System.Text;
using FicAppPersonas.Models.Asistencia;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Data;
namespace FicAppPersonas.Interfaces.RhCatTelefonos
{
    public interface IFicSrvRhCatTelefonosList
    {
        Task<IEnumerable<rh_cat_telefonos>> FicMetGetListRhCatTelefonos(int IdPersona);//READ
    }
}

