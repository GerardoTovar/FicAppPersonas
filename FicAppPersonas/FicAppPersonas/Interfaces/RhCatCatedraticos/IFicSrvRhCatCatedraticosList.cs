using System;
using System.Collections.Generic;
using System.Text;
using FicAppPersonas.Models.Asistencia;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Data;
namespace FicAppPersonas.Interfaces.RhCatCatedraticos
{
    public interface IFicSrvRhCatCatedraticosList
    {
        Task<IEnumerable<rh_cat_catedraticos>> FicMetGetListRhCatCatedraticos(int id);//READ
    }
}
