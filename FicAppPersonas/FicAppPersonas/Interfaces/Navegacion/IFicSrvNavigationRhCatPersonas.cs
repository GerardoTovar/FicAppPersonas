using System;
using System.Collections.Generic;
using System.Text;

namespace FicAppPersonas.Interfaces.Navegacion
{
    public interface IFicSrvNavigationRhCatPersonas
    {
        /*METODOS PARA LA NAVEGACION ENTRE VIEWS DE LA APP*/
        void FicMetNavigateTo<FicTDestinationViewModel>(object FicNavigationContext = null, object FicNavigationContext2 = null, object FicNavigationContext3 = null, object FicNavigationContext4 = null);
        void FicMetNavigateTo<FicTDestinationViewModel>(object FicNavigationContext = null, object FicNavigationContext2 = null , object FicNavigationContext3 = null);
        void FicMetNavigateTo<FicTDestinationViewModel>(object FicNavigationContext = null, object FicNavigationContext2 = null );
        void FicMetNavigateTo<FicTDestinationViewModel>(object FicNavigationContext = null);
        void FicMetNavigateTo(Type FicDestinationType, object FicNavigationContext = null);
        void FicMetNavigateBack();
    }//INTERFACE
}//NAMESPACE