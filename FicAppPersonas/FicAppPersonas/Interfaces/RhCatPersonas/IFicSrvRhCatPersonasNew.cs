﻿using System;
using System.Collections.Generic;
using System.Text;
using FicAppPersonas.Models.Asistencia;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Data;
namespace FicAppPersonas.Interfaces.RhCatPersonas
{
    public interface IFicSrvRhCatPersonasNew
    {

        Task FicMetGetNewRhCatPersonas(rh_cat_personas item);// CREATE
        Task<IEnumerable<cat_generales>> FicMetGetListRhCatGenerales(int id);//GET GENERALES
        Task<IEnumerable<cat_institutos>> FicMetGetListRhCatInstitutos();//GET INSTITUTOS
    }
}

