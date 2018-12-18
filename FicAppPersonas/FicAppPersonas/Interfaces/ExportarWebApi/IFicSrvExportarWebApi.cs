using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FicAppPersonas.Interfaces.ExportarWebApi
{
    public interface IFicSrvExportarWebApi
    {
        Task<string> FicPostExportInventarios();
    }//INTERFACE
}//NAMESPACE