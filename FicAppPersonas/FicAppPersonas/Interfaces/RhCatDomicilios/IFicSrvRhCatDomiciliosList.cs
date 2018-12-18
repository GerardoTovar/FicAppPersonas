using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Interfaces.RhCatDomicilios
{
    public interface IFicSrvRhCatDomiciliosList
    {
        Task<IEnumerable<rh_cat_domicilios>> FicMetGetListRhCatDomicilios(int IdPersona );//READ
        //Task<IEnumerable<cat_generales>> FicMetGetListRhCatGenerales(int id);//GET GENERALES

    }
}
