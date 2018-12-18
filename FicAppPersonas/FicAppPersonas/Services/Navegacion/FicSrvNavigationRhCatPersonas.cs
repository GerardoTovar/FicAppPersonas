using FicAppPersonas.Interfaces.Navegacion;

using FicAppPersonas.ViewModels.RhCatPersonas;
using FicAppPersonas.ViewModels.RhCatEmpleados;
using FicAppPersonas.ViewModels.RhCatTelefonos;

using FicAppPersonas.Views.RhCatEmpleados;
using FicAppPersonas.Views.RhCatPersonas;
using FicAppPersonas.Views.RhCatTelefonos;

using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FicAppPersonas.ViewModels.RhCatDirWeb;
using FicAppPersonas.Views.RhCatDirWeb;
using FicAppPersonas.ViewModels.RhCatCatedraticos;
using FicAppPersonas.Views.RhCatCatedraticos;
using FicAppPersonas.ViewModels.RhCatPersonasDatosAdicionales;
using FicAppPersonas.Views.RhCatPersonasDatosAdicionales;
using FicAppPersonas.ViewModels.RhCatAlumnos;
using FicAppPersonas.Views.RhCatAlumnos;
using FicAppPersonas.ViewModels.RhCatPersonasPerfiles;
using FicAppPersonas.Views.RhCatPersonasPerfiles;
using FicAppPersonas.ViewModels.BecCatClientes;
using FicAppPersonas.Views.BecCatClientes;
using FicAppPersonas.ViewModels.RhPersonasPerfilEstatus;
using FicAppPersonas.Views.RhPersonasPerfilEstatus;
using FicAppPersonas.ViewModels.ExportarWebApi;
using FicAppPersonas.Views.ExportarWebApi;
using FicAppPersonas.ViewModels.ImportarWebApi;
using FicAppPersonas.Views.ImportarWebApi;
using FicAppPersonas.Views.RhCatDomicilios;
using FicAppPersonas.ViewModels.RhCatDomicilios;
using FicAppPersonas.ViewModels.BecInstitutosPersonas;
using FicAppPersonas.Views.BecInstitutosPersonas;

namespace FicAppPersonas.Services.Navegacion
{
    public class FicSrvNavigationRhCatPersonas : IFicSrvNavigationRhCatPersonas
    {
        private IDictionary<Type, Type> FicViewModelRouting = new Dictionary<Type, Type>()
        { 
            //AQUI SE HACE UNA UNION ENTRE LA VM Y VI DE CADA VIEW DE LA APP
            //{ typeof(FicVmCatEdificiosNuevo)  ,typeof(FicViCatEdificiosNuevo) },
            { typeof(FicVmRhCatPersonasList)    ,typeof(FicViRhCatPersonasList) },
            { typeof(FicVmRhCatEmpleadosList)   ,typeof(FicViRhCatEmpleadosList) },
            { typeof(FicVmRhCatCatedraticosList),typeof(FicViRhCatCatedraticosList) },
            { typeof(FicVmRhCatTelefonosList)   ,typeof(FicViRhCatTelefonosList) },
            { typeof(FicVmRhCatDirWebList)      ,typeof(FicViRhCatDirWebList) },
            { typeof(FicVmRhCatPersonasPerfilesList),typeof(FicViRhCatPersonasPerfilesList) },
            { typeof(FicVmRhCatAlumnosList),typeof(FicViRhCatAlumnosList) },
        
            { typeof(FicVmRhCatAlumnosNew),typeof(FicViRhCatAlumnosNew) },
            { typeof(FicVmRhCatPersonasPerfilesNew),typeof(FicViRhCatPersonasPerfilesNew) },
            { typeof(FicVmRhCatDirWebNew)       ,typeof(FicViRhCatDirWebNew) },
            { typeof(FicVmRhCatPersonasNew)     ,typeof(FicViRhCatPersonasNew) },
            { typeof(FicVmRhCatCatedraticosNew) ,typeof(FicViRhCatCatedraticosNew) },
            { typeof(FicVmRhCatEmpleadosNew)    ,typeof(FicViRhCatEmpleadosNew) },
            { typeof(FicVmRhCatTelefonosNew)    ,typeof(FicViRhCatTelefonosNew) },
            { typeof(FicVmBecCatClientesNew)    ,typeof(FicViBecCatClientesNew) },

            { typeof(FicVmRhCatEmpleadosUpdate)       ,typeof(FicViRhCatEmpleadosUpdate) },
            { typeof(FicVmRhCatAlumnosUpdate)         ,typeof(FicViRhCatAlumnosUpdate) },
            { typeof(FicVmRhCatPersonasPerfilesUpdate),typeof(FicViRhCatPersonasPerfilesUpdate) },
            { typeof(FicVmRhCatDirWebUpdate)          ,typeof(FicViRhCatDirWebUpdate) },

            { typeof(FicVmRhCatDirWebDetail)          ,typeof(FicViRhCatDirWebDetail) },
            { typeof(FicVmRhCatEmpleadosDetail)       ,typeof(FicViRhCatEmpleadosDetail) },
            { typeof(FicVmRhCatAlumnosDetail)         ,typeof(FicViRhCatAlumnosDetail) },
            { typeof(FicVmRhCatPersonasPerfilesDetail),typeof(FicViRhCatPersonasPerfilesDetail) },

            { typeof(FicVmBecCatClientesList)   ,typeof(FicViBecCatClientesList) },
            { typeof(FicVmRhCatTelefonosUpdate) ,typeof(FicViRhCatTelefonosUpdate) },
            { typeof(FicVmRhCatPersonasEdit)    ,typeof(FicViRhCatPersonasEdit) },
            { typeof(FicVmRhCatPersonasDetail)  ,typeof(FicViRhCatPersonasDetail) },

            { typeof(FicVmRhCatPersonasDatosAdicionalesList)  ,typeof(FicViRhCatPersonasDatosAdicionalesList) },
            { typeof(FicVmRhCatPersonasDatosAdicionalesNew)   ,typeof(FicViRhCatPersonasDatosAdicionalesNew) },
            { typeof(FicVmRhCatPersonasDatosAdicionalesEdit)  ,typeof(FicViRhCatPersonasDatosAdicionalesEdit) },
            { typeof(FicVmRhCatPersonasDatosAdicionalesDetail),typeof(FicViRhCatPersonasDatosAdicionalesDetail) },
            { typeof(FicVmRhCatCatedraticosDetail)            ,typeof(FicViRhCatCatedraticosDetail) },
            { typeof(FicVmRhCatCatedraticosEdit)              ,typeof(FicViRhCatCatedraticosEdit) },
            { typeof(FicVmRhCatTelefonosDetail)               ,typeof(FicViRhCatTelefonosDetail) },
            { typeof(FicVmBecCatClientesEdit)                 ,typeof(FicViBecCatClientesEdit) },
	        { typeof(FicVmBecCatClientesDetail)               ,typeof(FicViBecCatClientesDetail) },

            { typeof(FicVmRhPersonasPerfilEstatusList)       ,typeof(FicViRhPersonasPerfilEstatusList) },
            { typeof(FicVmRhPersonasPerfilEstatusNew)        ,typeof(FicViRhPersonasPerfilEstatusNew) },
            { typeof(FicVmRhPersonasPerfilEstatusEdit)       ,typeof(FicViRhPersonasPerfilEstatusEdit) },
            { typeof(FicVmRhPersonasPerfilEstatusDetail)     ,typeof(FicViRhPersonasPerfilEstatusDetail) },

            { typeof(FicVmBecInstitutosPersonasList)       ,typeof(FicViBecInstitutosPersonasList) },
            { typeof(FicVmBecInstitutosPersonasDetail)        ,typeof(FicViBecInstitutosPersonasDetail) },
            { typeof(FicVmBecInstitutosPersonasNew)       ,typeof(FicViBecInstitutosPersonasNew) },
            { typeof(FicVmBecInstitutosPersonasUpdate)     ,typeof(FicViBecInstitutosPersonasUpdate) },

            { typeof(FicVmRhCatDomiciliosDetail)       ,typeof(FicViRhCatDomiciliosDetail) },
            { typeof(FicVmRhCatDomiciliosList)        ,typeof(FicViRhCatDomiciliosList) },
            { typeof(FicVmRhCatDomiciliosNew)       ,typeof(FicViRhCatDomiciliosNew) },
            { typeof(FicVmRhCatDomiciliosUpdate)     ,typeof(FicViRhCatDomiciliosUpdate) },

            {typeof(FicVmExportarWebApi) , typeof(FicViExportarWebApi)},
            {typeof(FicVmImportarWebApi) , typeof(FicViImportarWebApi)},
        };

        #region METODOS DE IMPLEMENTACION DE LA INTERFACE -> IFicSrvNavigationInventario
        public void FicMetNavigateTo<FicTDestinationViewModel>(object FicNavigationContext = null, object FicNavigationContext2 = null, object FicNavigationContext3 = null, object FicNavigationContext4 = null)
        {
            Type FicPageType = FicViewModelRouting[typeof(FicTDestinationViewModel)];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext, FicNavigationContext2, FicNavigationContext3, FicNavigationContext4) as Page;

            if (FicPage != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushAsync(FicPage);
            }
        }
        public void FicMetNavigateTo<FicTDestinationViewModel>(object FicNavigationContext = null, object FicNavigationContext2 = null, object FicNavigationContext3 = null)
        {
            Type FicPageType = FicViewModelRouting[typeof(FicTDestinationViewModel)];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext, FicNavigationContext2, FicNavigationContext3) as Page;

            if (FicPage != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushAsync(FicPage);
            }
        }
        public void FicMetNavigateTo<FicTDestinationViewModel>(object FicNavigationContext = null, object FicNavigationContext2 = null)
        {
            Type FicPageType = FicViewModelRouting[typeof(FicTDestinationViewModel)];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext , FicNavigationContext2) as Page;

            if (FicPage != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushAsync(FicPage);
            }
        }
        public void FicMetNavigateTo<FicTDestinationViewModel>(object FicNavigationContext = null)
        {
            Type FicPageType = FicViewModelRouting[typeof(FicTDestinationViewModel)];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext) as Page;

            if (FicPage != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushAsync(FicPage);
            }
        }

        public void FicMetNavigateTo(Type FicDestinationType, object FicNavigationContext = null)
        {
            Type FicPageType = FicViewModelRouting[FicDestinationType];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext) as Page;

            if (FicPage != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushAsync(FicPage);
            }
        }

        public void FicMetNavigateBack()
        {
            Application.Current.MainPage = new NavigationPage();
        }
        #endregion

    }//CLASS
}//NAMESPACE
