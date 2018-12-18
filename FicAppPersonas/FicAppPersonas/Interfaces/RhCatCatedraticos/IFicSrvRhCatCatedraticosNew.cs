﻿using System;
using System.Collections.Generic;
using System.Text;
using FicAppPersonas.Models.Asistencia;
using System.Threading.Tasks;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Data;

namespace FicAppPersonas.Interfaces.RhCatCatedraticos
{
    public interface IFicSrvRhCatCatedraticosNew
    {
        Task FicMetGetNewRhCatEmpleados(rh_cat_catedraticos item);// CREATE
    }
}

