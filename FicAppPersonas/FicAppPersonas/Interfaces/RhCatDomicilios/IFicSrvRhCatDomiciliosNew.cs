using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Interfaces.RhCatDomicilios
{
    public interface IFicSrvRhCatDomiciliosNew
    {
        Task FicMetGetNewRhCatDomicilios(rh_cat_domicilios item);// CREATE
        Task<IEnumerable<cat_generales>> FicMetGetListRhCatGenerales(int id);//GET GENERALES
        Task<IEnumerable<cat_paises>> FicMetGetListRhCaPaises();//GET INSTITUTOS
        Task<IEnumerable<cat_estados>> FicMetGetListRhCaEstados();//GET Estados
        Task<IEnumerable<cat_municipios>> FicMetGetListRhCaMunincipios();//GET munincipios
        Task<IEnumerable<cat_localidades>> FicMetGetListRhCaLocalidades();//GET localidades
        Task<IEnumerable<cat_colonias>> FicMetGetListRhCaColonias();//GET colonias



    }
}
