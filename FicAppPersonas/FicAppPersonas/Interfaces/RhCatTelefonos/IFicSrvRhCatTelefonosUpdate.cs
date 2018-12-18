using System;
using System.Collections.Generic;
using System.Text;
using FicAppPersonas.Models.Asistencia;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Data;
namespace FicAppPersonas.Interfaces.RhCatTelefonos
{
    public interface IFicSrvRhCatTelefonosUpdate
    {
        Task FicMetUpdateEdificio(rh_cat_telefonos ficPa_eva_Cat_Edificios);
        Task<IEnumerable<cat_generales>> FicMetGetListRhCatGenerales(int id);//GET GENERALES
    }
}
