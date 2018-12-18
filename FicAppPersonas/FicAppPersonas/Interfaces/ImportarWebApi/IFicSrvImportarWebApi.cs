using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FicAppPersonas.Interfaces.ImportarWebApi
{
    public interface IFicSrvImportarWebApi
    {
        //Task<string> FicGetImportInventarios(int id = 0);
        Task<string> FicGetImportCatalogos();
        Task<string> FicGetImportPersonas(int id);
    }//INTERFACE
}//NAMESPACE
