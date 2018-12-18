using FicAppPersonas.Interfaces.RhCatPersonas;
using FicAppPersonas.Interfaces.RhCatEmpleados;
using FicAppPersonas.Interfaces.RhCatTelefonos;
using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.Services.RhCatPersonas;
using FicAppPersonas.Services.RhCatEmpleados;
using FicAppPersonas.Services.RhCatTelefonos;
using FicAppPersonas.Services.Navegacion;

using FicAppPersonas.Views.RhCatPersonas;
using FicAppPersonas.Views.RhCatEmpleados;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using FicAppPersonas.ViewModels.RhCatPersonas;
using FicAppPersonas.ViewModels.RhCatEmpleados;
using FicAppPersonas.ViewModels.RhCatTelefonos;
using FicAppPersonas.ViewModels.RhCatDirWeb;
using FicAppPersonas.Services.RhCatDirWeb;
using FicAppPersonas.Interfaces.RhCatDirWeb;
using FicAppPersonas.ViewModels.RhCatCatedraticos;
using FicAppPersonas.ViewModels.RhCatPersonasDatosAdicionales;
using FicAppPersonas.Services.RhCatCatedraticos;
using FicAppPersonas.Interfaces.RhCatCatedraticos;
using FicAppPersonas.Services.RhCatPersonasDatosAdicionales;
using FicAppPersonas.Interfaces.RhCatPersonasDatosAdicionales;
using FicAppPersonas.ViewModels.RhCatAlumnos;
using FicAppPersonas.ViewModels.RhCatPersonasPerfiles;
using FicAppPersonas.Services.RhCatAlumnos;
using FicAppPersonas.Interfaces.RhCatAlumnos;
using FicAppPersonas.Services.RhCatPersonasPerfiles;
using FicAppPersonas.Interfaces.RhCatPersonasPerfiles;
using FicAppPersonas.ViewModels.BecCatClientes;
using FicAppPersonas.Interfaces.BecCatClientes;
using FicAppPersonas.Services.BecCatClientes;
using FicAppPersonas.ViewModels.RhPersonasPerfilEstatus;
using FicAppPersonas.Interfaces.RhPersonasPerfilEstatus;
using FicAppPersonas.Services.RhPersonasPerfilEstatus;
using FicAppPersonas.ViewModels.ImportarWebApi;
using FicAppPersonas.ViewModels.ExportarWebApi;
using FicAppPersonas.Services.ImportarWebApi;
using FicAppPersonas.Services.ExportarWebApi;
using FicAppPersonas.Interfaces.ImportarWebApi;
using FicAppPersonas.Interfaces.ExportarWebApi;
using FicAppPersonas.ViewModels.BecInstitutosPersonas;
using FicAppPersonas.ViewModels.RhCatDomicilios;
using FicAppPersonas.Services.BecInstitutosPersonas;
using FicAppPersonas.Interfaces.BecInstitutosPersonas;
using FicAppPersonas.Services.RhCatDomicilios;
using FicAppPersonas.Interfaces.RhCatDomicilios;

namespace FicAppPersonas.ViewModels.Base
{
    public class FicViewModelLocator
    {
        private static IContainer FicIContainer;

        public FicViewModelLocator()
        {
            //FIC: ContainerBuilder es una clase de la libreria de Autofac para poder ejecutar la interfaz en las diferentes plataformas 
            var FicContainerBuilder = new ContainerBuilder();

            //-------------------------------- VIEW MODELS ------------------------------------------------------
            //FIC: se procede a registrar las ViewModels para que se puedan mandar llamar en cualquier plataforma
            //---------------------------------------------------------------------------------------------------

            FicContainerBuilder.RegisterType<FicVmRhCatPersonasList>();
            FicContainerBuilder.RegisterType<FicVmRhCatEmpleadosList>();
            FicContainerBuilder.RegisterType<FicVmRhCatCatedraticosList>();
            FicContainerBuilder.RegisterType<FicVmRhCatPersonasPerfilesList>();
            FicContainerBuilder.RegisterType<FicVmRhCatTelefonosList>();
            FicContainerBuilder.RegisterType<FicVmRhCatDirWebList>();
            FicContainerBuilder.RegisterType<FicVmRhCatPersonasDatosAdicionalesList>();
            FicContainerBuilder.RegisterType<FicVmRhCatAlumnosList>();
            FicContainerBuilder.RegisterType<FicVmBecCatClientesList>();

            FicContainerBuilder.RegisterType<FicVmBecCatClientesNew>();
            FicContainerBuilder.RegisterType<FicVmRhCatAlumnosNew>();
            FicContainerBuilder.RegisterType<FicVmRhCatPersonasPerfilesNew>();
            FicContainerBuilder.RegisterType<FicVmRhCatPersonasNew>();
            FicContainerBuilder.RegisterType<FicVmRhCatEmpleadosNew>();
            FicContainerBuilder.RegisterType<FicVmRhCatTelefonosNew>();
            FicContainerBuilder.RegisterType<FicVmRhCatCatedraticosNew>();
            FicContainerBuilder.RegisterType<FicVmRhCatDirWebNew>();
            FicContainerBuilder.RegisterType<FicVmRhCatPersonasDatosAdicionalesNew>();

            FicContainerBuilder.RegisterType<FicVmRhCatDirWebUpdate>();
            FicContainerBuilder.RegisterType<FicVmRhCatEmpleadosUpdate>();
            FicContainerBuilder.RegisterType<FicVmRhCatAlumnosUpdate>();
            FicContainerBuilder.RegisterType<FicVmRhCatPersonasPerfilesUpdate>();

            FicContainerBuilder.RegisterType<FicVmRhCatPersonasDatosAdicionalesDetail>();
            FicContainerBuilder.RegisterType<FicVmRhCatPersonasDatosAdicionalesEdit>();

            FicContainerBuilder.RegisterType<FicVmBecCatClientesEdit>();
            FicContainerBuilder.RegisterType<FicVmRhCatDirWebDetail>();
            FicContainerBuilder.RegisterType<FicVmRhCatTelefonosDetail>();
            FicContainerBuilder.RegisterType<FicVmRhCatEmpleadosDetail>();
            FicContainerBuilder.RegisterType<FicVmRhCatAlumnosDetail>();
            FicContainerBuilder.RegisterType<FicVmRhCatPersonasPerfilesDetail>();

            FicContainerBuilder.RegisterType<FicVmRhCatTelefonosUpdate>();
            FicContainerBuilder.RegisterType<FicVmRhCatPersonasEdit>();
            FicContainerBuilder.RegisterType<FicVmRhCatCatedraticosEdit>();
            FicContainerBuilder.RegisterType<FicVmRhCatPersonasDetail>();
            FicContainerBuilder.RegisterType<FicVmRhCatCatedraticosDetail>();
            FicContainerBuilder.RegisterType<FicVmBecCatClientesDetail>();

            FicContainerBuilder.RegisterType<FicVmRhPersonasPerfilEstatusList>();
            FicContainerBuilder.RegisterType<FicVmRhPersonasPerfilEstatusNew>();
            FicContainerBuilder.RegisterType<FicVmRhPersonasPerfilEstatusEdit>();
            FicContainerBuilder.RegisterType<FicVmRhPersonasPerfilEstatusDetail>();

            FicContainerBuilder.RegisterType<FicVmImportarWebApi>();
            FicContainerBuilder.RegisterType<FicVmExportarWebApi>();


            FicContainerBuilder.RegisterType<FicVmBecInstitutosPersonasList>();
            FicContainerBuilder.RegisterType<FicVmBecInstitutosPersonasDetail>();
            FicContainerBuilder.RegisterType<FicVmBecInstitutosPersonasNew>();
            FicContainerBuilder.RegisterType<FicVmBecInstitutosPersonasUpdate>();

            FicContainerBuilder.RegisterType<FicVmRhCatDomiciliosDetail>();
            FicContainerBuilder.RegisterType<FicVmRhCatDomiciliosList>();
            FicContainerBuilder.RegisterType<FicVmRhCatDomiciliosNew>();
            FicContainerBuilder.RegisterType<FicVmRhCatDomiciliosUpdate>();


            ////------------------------- INTERFACE SERVICES OF THE VIEW MODELS -----------------------------------
            ////FIC: se procede a registrar la interface con la que se comunican las ViewModels con los Servicios 
            ////para poder ejecutar las tareas (metodos o funciones, etc) del servicio en cuestion.
            ////---------------------------------------------------------------------------------------------------///

            FicContainerBuilder.RegisterType<FicSrvNavigationRhCatPersonas>().As<IFicSrvNavigationRhCatPersonas>().SingleInstance();
            
            FicContainerBuilder.RegisterType<FicSrvRhCatPersonasList>().As<IFicSrvRhCatPersonasList>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatEmpleadoList>().As<IFicSrvRhCatEmpleadosList>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatCatedraticosList>().As<IFicSrvRhCatCatedraticosList>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatPersonasPerfilesList>().As<IFicSrvRhCatPersonasPerfilesList>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatTelefonosList>().As<IFicSrvRhCatTelefonosList>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatDirWebList>().As<IFicSrvRhCatDirWebList>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatPersonasDatosAdicionalesList>().As<IFicSrvRhCatPersonasDatosAdicionalesList>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatAlumnosList>().As<IFicSrvRhCatAlumnosList>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhPersonasPerfilEstatusList>().As<IFicSrvRhPersonasPerfilEstatusList>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvBecCatClientesList>().As<IFicSrvBecCatClientesList>().SingleInstance();


            FicContainerBuilder.RegisterType<FicSrvBecCatClientesNew>().As<IFicSrvBecCatClientesNew>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatAlumnosNew>().As<IFicSrvRhCatAlumnosNew>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatPersonasPerfilesNew>().As<IFicSrvRhCatPersonasPerfilesNew>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatPersonasNew>().As<IFicSrvRhCatPersonasNew>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatEmpleadosNew>().As<IFicSrvRhCatEmpleadosNew>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatTelefonosNew>().As<IFicSrvRhCatTelefonosNew>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatDirWebNew>().As<IFicSrvRhCatDirWebNew>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatCatedraticosNew>().As<IFicSrvRhCatCatedraticosNew>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatPersonasDatosAdicionalesNew>().As<IFicSrvRhCatPersonasDatosAdicionalesNew>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhPersonasPerfilEstatusNew>().As<IFicSrvRhPersonasPerfilEstatusNew>().SingleInstance();

            FicContainerBuilder.RegisterType<FicSrvBecCatClientesEdit>().As<IFicSrvBecCatClientesEdit>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatDirWebUpdate>().As<IFicSrvRhCatDirWebUpdate>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatEmpleadosUpdate>().As<IFicSrvRhCatEmpleadosUpdate>().SingleInstance();            
            FicContainerBuilder.RegisterType<FicSrvRhCatAlumnosUpdate>().As<IFicSrvRhCatAlumnosUpdate>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatPersonasPerfilesUpdate>().As<IFicSrvRhCatPersonasPerfilesUpdate>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatTelefonosUpdate>().As<IFicSrvRhCatTelefonosUpdate>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatPersonasDatosAdicionalesEdit>().As<IFicSrvRhCatPersonasDatosAdicionalesEdit>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatPersonasEdit>().As<IFicSrvRhCatPersonasEdit>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatCatedraticosEdit>().As<IFicSrvRhCatCatedraticosEdit>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhPersonasPerfilEstatusEdit>().As<IFicSrvRhPersonasPerfilEstatusEdit>().SingleInstance();

            FicContainerBuilder.RegisterType<FicSrvBecCatClientesDetail>().As<IFicSrvBecCatClientesDetail>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatDirWebDetail>().As<IFicSrvRhCatDirWebDetail>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatEmpleadoDetail>().As<IFicSrvRhCatEmpleadosDetail>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatTelefonosDetail>().As<IFicSrvRhCatTelefonosDetail>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatAlumnosDetail>().As<IFicSrvRhCatAlumnosDetail>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatPersonasDetail>().As<IFicSrvRhCatPersonasDetail>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatPersonasDatosAdicionalesDetail>().As<IFicSrvRhCatPersonasDatosAdicionalesDetail>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatCatedraticosDetail>().As<IFicSrvRhCatCatedraticosDetail>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatPersonasPerfilesDetail>().As<IFicSrvRhCatPersonasPerfilesDetail>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhPersonasPerfilEstatusDetail>().As<IFicSrvRhPersonasPerfilEstatusDetail>().SingleInstance();

            FicContainerBuilder.RegisterType<FicSrvImportarWebApi>().As<IFicSrvImportarWebApi>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvExportarWebApi>().As<IFicSrvExportarWebApi>().SingleInstance();

            FicContainerBuilder.RegisterType<FicSrvBecInstitutosPersonasDetail>().As<IFicSrvBecInstitutosPersonasDetail>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvBecInstitutosPersonasList>().As<IFicSrvBecInstitutosPersonasList>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvBecInstitutosPersonasNew>().As<IFicSrvBecInstitutosPersonasNew>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvBecInstitutosPersonasUpdate>().As<IFicSrvBecInstitutosPersonasUpdate>().SingleInstance();

            FicContainerBuilder.RegisterType<FicSrvRhCatDomiciliosDetail>().As<IFicSrvRhCatDomiciliosDetail>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatDomiciliosList>().As<IFicSrvRhCatDomiciliosList>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatDomiciliosNew>().As<IFicSrvRhCatDomiciliosNew>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatDomiciliosUpdate>().As<IFicSrvRhCatDomiciliosUpdate>().SingleInstance();


            //FIC: se asigna o se libera el contenedor
            //-------------------------------------------
            if (FicIContainer != null) FicIContainer.Dispose();

            FicIContainer = FicContainerBuilder.Build();
        }//CONSTRUCTOR

        //-------------------- CONTROL DE INVENTARIOS ------------------------
        //FIC: se manda llamar desde el backend de la View de List
        public FicVmRhCatPersonasList FicVmRhCatPersonasList
        {
            get { return FicIContainer.Resolve<FicVmRhCatPersonasList>(); }
        }
        public FicVmRhCatEmpleadosList FicVmRhCatEmpleadosList
        {
            get { return FicIContainer.Resolve<FicVmRhCatEmpleadosList>(); }
        }
        public FicVmRhCatCatedraticosList FicVmRhCatCatedraticosList
        {
            get { return FicIContainer.Resolve<FicVmRhCatCatedraticosList>(); }
        }
        public FicVmRhCatPersonasPerfilesList FicVmRhCatPersonasPerfilesList
        {
            get { return FicIContainer.Resolve<FicVmRhCatPersonasPerfilesList>(); }
        }
        public FicVmRhCatDirWebList FicVmRhCatDirWebList
        {
            get { return FicIContainer.Resolve<FicVmRhCatDirWebList>(); }
        }
        public FicVmRhCatPersonasNew FicVmRhCatPersonasNew
        {
            get { return FicIContainer.Resolve<FicVmRhCatPersonasNew>(); }
        }
        public FicVmRhCatEmpleadosNew FicVmRhCatEmpleadosNew
        {
            get { return FicIContainer.Resolve<FicVmRhCatEmpleadosNew>(); }
        }

        public FicVmRhCatDirWebNew FicVmRhCatDirWebNew
        {
            get { return FicIContainer.Resolve<FicVmRhCatDirWebNew>(); }
        }

        public FicVmRhCatTelefonosList FicVmRhCatTelefonosList
        {
            get { return FicIContainer.Resolve<FicVmRhCatTelefonosList>(); }
        }
        public FicVmRhCatTelefonosNew FicVmRhCatTelefonosNew
        {
            get { return FicIContainer.Resolve<FicVmRhCatTelefonosNew>(); }
        }
        public FicVmRhCatTelefonosUpdate FicVmRhCatTelefonosUpdate
        {
            get { return FicIContainer.Resolve<FicVmRhCatTelefonosUpdate>(); }
        }

        public FicVmRhCatPersonasEdit FicVmRhCatPersonasEdit
        {
            get { return FicIContainer.Resolve<FicVmRhCatPersonasEdit>(); }
        }

        public FicVmRhCatPersonasDetail FicVmRhCatPersonasDetail
        {
            get { return FicIContainer.Resolve<FicVmRhCatPersonasDetail>(); }
        }

        public FicVmRhCatPersonasDatosAdicionalesList  FicVmRhCatPersonasDatosAdicionalesList
        {
            get { return FicIContainer.Resolve<FicVmRhCatPersonasDatosAdicionalesList>(); }
        }

        public FicVmRhCatPersonasDatosAdicionalesNew FicVmRhCatPersonasDatosAdicionalesNew
        {
            get { return FicIContainer.Resolve<FicVmRhCatPersonasDatosAdicionalesNew>(); }
        }

        public FicVmRhCatPersonasDatosAdicionalesEdit FicVmRhCatPersonasDatosAdicionalesEdit
        {
            get { return FicIContainer.Resolve<FicVmRhCatPersonasDatosAdicionalesEdit>(); }
        }

        public FicVmRhCatPersonasDatosAdicionalesDetail FicVmRhCatPersonasDatosAdicionalesDetail
        {
            get { return FicIContainer.Resolve<FicVmRhCatPersonasDatosAdicionalesDetail>(); }
        }

        public FicVmRhCatCatedraticosNew FicVmRhCatCatedraticosNew
        {
            get { return FicIContainer.Resolve<FicVmRhCatCatedraticosNew>(); }
        }

        public FicVmRhCatCatedraticosEdit FicVmRhCatCatedraticosEdit
        {
            get { return FicIContainer.Resolve<FicVmRhCatCatedraticosEdit>(); }
        }

        public FicVmRhCatCatedraticosDetail FicVmRhCatCatedraticosDetail
        {
            get { return FicIContainer.Resolve<FicVmRhCatCatedraticosDetail>(); }
        }

        public FicVmRhCatAlumnosList FicVmRhCatAlumnosList
        {
            get { return FicIContainer.Resolve<FicVmRhCatAlumnosList>(); }
        }

        public FicVmRhCatAlumnosNew FicVmRhCatAlumnosNew
        {
            get { return FicIContainer.Resolve<FicVmRhCatAlumnosNew>(); }
        }

        public FicVmRhCatPersonasPerfilesNew FicVmRhCatPersonasPerfilesNew
        {
            get { return FicIContainer.Resolve<FicVmRhCatPersonasPerfilesNew>(); }
        }

        public FicVmRhCatDirWebUpdate FicVmRhCatDirWebUpdate
        {
            get { return FicIContainer.Resolve<FicVmRhCatDirWebUpdate>(); }
        }

        public FicVmRhCatEmpleadosUpdate FicVmRhCatEmpleadosUpdate
        {
            get { return FicIContainer.Resolve<FicVmRhCatEmpleadosUpdate>(); }
        }

        public FicVmRhCatAlumnosUpdate FicVmRhCatAlumnosUpdate
        {
            get { return FicIContainer.Resolve<FicVmRhCatAlumnosUpdate>(); }
        }
        public FicVmRhCatPersonasPerfilesUpdate FicVmRhCatPersonasPerfilesUpdate
        {
            get { return FicIContainer.Resolve<FicVmRhCatPersonasPerfilesUpdate>(); }
        }

        public FicVmRhCatTelefonosDetail FicVmRhCatTelefonosDetail
        {
            get { return FicIContainer.Resolve<FicVmRhCatTelefonosDetail>(); }
        }

        public FicVmRhCatDirWebDetail FicVmRhCatDirWebDetail
        {
            get { return FicIContainer.Resolve<FicVmRhCatDirWebDetail>(); }
        }

        public FicVmRhCatEmpleadosDetail FicVmRhCatEmpleadosDetail
        {
            get { return FicIContainer.Resolve<FicVmRhCatEmpleadosDetail>(); }
        }
        public FicVmRhCatAlumnosDetail FicVmRhCatAlumnosDetail
        {
            get { return FicIContainer.Resolve<FicVmRhCatAlumnosDetail>(); }
        }

        public FicVmRhCatPersonasPerfilesDetail FicVmRhCatPersonasPerfilesDetail
        {
            get { return FicIContainer.Resolve<FicVmRhCatPersonasPerfilesDetail>(); }
        }

        public FicVmBecCatClientesList FicVmBecCatClientesList
        {
            get { return FicIContainer.Resolve<FicVmBecCatClientesList>(); }
        }

        public FicVmBecCatClientesNew FicVmBecCatClientesNew
        {
            get { return FicIContainer.Resolve<FicVmBecCatClientesNew>(); }
        }

        public FicVmBecCatClientesEdit FicVmBecCatClientesEdit
        {
            get { return FicIContainer.Resolve<FicVmBecCatClientesEdit>(); }
        }

        public FicVmBecCatClientesDetail FicVmBecCatClientesDetail
        {
            get { return FicIContainer.Resolve<FicVmBecCatClientesDetail>(); }
        }


        public FicVmRhPersonasPerfilEstatusList FicVmRhPersonasPerfilEstatusList
        {
            get { return FicIContainer.Resolve<FicVmRhPersonasPerfilEstatusList>(); }
        }

        public FicVmRhPersonasPerfilEstatusNew FicVmRhPersonasPerfilEstatusNew
        {
            get { return FicIContainer.Resolve<FicVmRhPersonasPerfilEstatusNew>(); }
        }

        public FicVmRhPersonasPerfilEstatusEdit FicVmRhPersonasPerfilEstatusEdit
        {
            get { return FicIContainer.Resolve<FicVmRhPersonasPerfilEstatusEdit>(); }
        }

        public FicVmRhPersonasPerfilEstatusDetail FicVmRhPersonasPerfilEstatusDetail{get { return FicIContainer.Resolve<FicVmRhPersonasPerfilEstatusDetail>(); }}

        public FicVmBecInstitutosPersonasList FicVmBecInstitutosPersonasList { get { return FicIContainer.Resolve<FicVmBecInstitutosPersonasList>(); } }
        public FicVmBecInstitutosPersonasDetail FicVmBecInstitutosPersonasDetail { get { return FicIContainer.Resolve<FicVmBecInstitutosPersonasDetail>(); } }
        public FicVmBecInstitutosPersonasNew FicVmBecInstitutosPersonasNew { get { return FicIContainer.Resolve<FicVmBecInstitutosPersonasNew>(); } }
        public FicVmBecInstitutosPersonasUpdate FicVmBecInstitutosPersonasUpdate { get { return FicIContainer.Resolve<FicVmBecInstitutosPersonasUpdate>(); } }

        public FicVmRhCatDomiciliosDetail FicVmRhCatDomiciliosDetail { get { return FicIContainer.Resolve<FicVmRhCatDomiciliosDetail>(); } }
        public FicVmRhCatDomiciliosList FicVmRhCatDomiciliosList { get { return FicIContainer.Resolve<FicVmRhCatDomiciliosList>(); } }
        public FicVmRhCatDomiciliosNew FicVmRhCatDomiciliosNew { get { return FicIContainer.Resolve<FicVmRhCatDomiciliosNew>(); } }
        public FicVmRhCatDomiciliosUpdate FicVmRhCatDomiciliosUpdate { get { return FicIContainer.Resolve<FicVmRhCatDomiciliosUpdate>(); } }

        public FicVmImportarWebApi FicVmImportarWebApi
        {
            get { return FicIContainer.Resolve<FicVmImportarWebApi>(); }
        }

        public FicVmExportarWebApi FicVmExportarWebApi
        {
            get { return FicIContainer.Resolve<FicVmExportarWebApi>(); }
        }


    }//CLASS
}//NAMESPACE
