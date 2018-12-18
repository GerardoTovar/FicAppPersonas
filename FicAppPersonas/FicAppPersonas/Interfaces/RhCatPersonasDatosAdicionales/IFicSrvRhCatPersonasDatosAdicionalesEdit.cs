using System;
using System.Collections.Generic;
using System.Text;
using FicAppPersonas.Models.Asistencia;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Data;

namespace FicAppPersonas.Interfaces.RhCatPersonasDatosAdicionales
{
    public interface IFicSrvRhCatPersonasDatosAdicionalesEdit
    {
        Task FicMetGetEditRhCatEmpleados(rh_cat_personas_datos_adicionales item);// CREATE
        Task<IEnumerable<cat_generales>> FicMetGetListRhCatGenerales(int id);//GET GENERALES
    }
}
