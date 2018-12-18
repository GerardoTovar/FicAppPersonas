using FicAppPersonas.Interfaces.RhCatPersonas;
using FicAppPersonas.Interfaces.RhCatEmpleados;
using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.Models.Asistencia;
using FicAppPersonas.ViewModels.Base;
using FicAppPersonas.ViewModels.RhCatEmpleados;

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.ViewModels.RhCatTelefonos;
using FicAppPersonas.ViewModels.RhCatDirWeb;
using FicAppPersonas.ViewModels.RhCatCatedraticos;
using FicAppPersonas.ViewModels.RhCatAlumnos;
using FicAppPersonas.ViewModels.RhCatPersonasDatosAdicionales;
using FicAppPersonas.ViewModels.BecCatClientes;
using FicAppPersonas.ViewModels.RhCatPersonasPerfiles;
using FicAppPersonas.ViewModels.RhCatDomicilios;
using FicAppPersonas.ViewModels.BecInstitutosPersonas;

namespace FicAppPersonas.ViewModels.RhCatPersonas
{
    public class FicVmRhCatPersonasList : INotifyPropertyChanged
    {
        public ObservableCollection<rh_cat_personas> _FicSfDataGrid_ItemSource_CatPersonas;
        //public rh_cat_personas _FicSfDataGrid_SelectItem_CatPersonas;
        //private ICommand _FicMetAddPersonaICommand, _FicMetAcumuladosICommand;
        private IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas;
        private IFicSrvRhCatPersonasList IFicSrvRhCatPersonasList;


        public FicVmRhCatPersonasList(IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas, IFicSrvRhCatPersonasList IFicSrvRhCatPersonasList)
        {
            this.IFicSrvNavigationRhCatPersonas = IFicSrvNavigationRhCatPersonas;
            this.IFicSrvRhCatPersonasList = IFicSrvRhCatPersonasList;
            _FicSfDataGrid_ItemSource_CatPersonas = new ObservableCollection<rh_cat_personas>();

        }//CONSTRUCTOR

        public ObservableCollection<rh_cat_personas> FicSfDataGrid_ItemSource_CatPersonas
        {  
            get
            {
                return _FicSfDataGrid_ItemSource_CatPersonas;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL GRID DE LA VIEW
        public rh_cat_personas _SfDataGrid_SelectItem_Persona;
        public rh_cat_personas FicSfDataGrid_SelectItem_CatPersonas
        {
            get { return _SfDataGrid_SelectItem_Persona; }
            set
            {
                _SfDataGrid_SelectItem_Persona = value;
                RaisePropertyChanged();
            }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL GRID DE LA VIEW


        private ICommand VistaListFicMetCatDomicilios;
        public ICommand FicMetCatDomicilios
        {

            get { return VistaListFicMetCatDomicilios = VistaListFicMetCatDomicilios ?? new FicVmDelegateCommand(FicMetCatDomiciliosExecute); }
        }
        private void FicMetCatDomiciliosExecute()
        {
            if (_SfDataGrid_SelectItem_Persona == null)
            {
                new Page().DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN ITEM", "OK");
                return;
            }
            else
            {
                IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatDomiciliosList>(_SfDataGrid_SelectItem_Persona);
            }
        }

        private ICommand VistaListFicMetCatInstitutosPersonas;
        public ICommand FicMetCatInstitutosPersonas{get { return VistaListFicMetCatInstitutosPersonas = VistaListFicMetCatInstitutosPersonas ?? new FicVmDelegateCommand(FicMetCatInstitutosPersonasExecute); }}
        private void FicMetCatInstitutosPersonasExecute()
        {
            if (_SfDataGrid_SelectItem_Persona == null){new Page().DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN ITEM", "OK");return;}
            else{ IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmBecInstitutosPersonasList>(_SfDataGrid_SelectItem_Persona);}
        }

        private ICommand VistaListFicMetCatDatosAdicionales;
        public ICommand FicMetCatDatosAdicionales {get { return VistaListFicMetCatDatosAdicionales = VistaListFicMetCatDatosAdicionales ?? new FicVmDelegateCommand(FicMetCatDatosAdicionalesExecute); }}
        private void FicMetCatDatosAdicionalesExecute()
        {
            if (_SfDataGrid_SelectItem_Persona == null){new Page().DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN ITEM", "OK");return;}
            else {IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasDatosAdicionalesList>(_SfDataGrid_SelectItem_Persona);}
        }

        private ICommand VistaListFicMetCatPersonasPerfiles;
        public ICommand FicMetCatPersonasPerfiles { get { return VistaListFicMetCatPersonasPerfiles = VistaListFicMetCatPersonasPerfiles ?? new FicVmDelegateCommand(FicMetCatPersonasPerfilesExecute); }}
        private void FicMetCatPersonasPerfilesExecute()
        {
            if (_SfDataGrid_SelectItem_Persona == null){ new Page().DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN ITEM", "OK");return; }
            else{ IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasPerfilesList>(_SfDataGrid_SelectItem_Persona);}
        }

        private ICommand VistaListFicMetCatCliente;
        public ICommand FicMetCatCliente{get { return VistaListFicMetCatCliente = VistaListFicMetCatCliente ?? new FicVmDelegateCommand(FicMetCatClienteExecute); }}
        private void FicMetCatClienteExecute()
        {
            if (_SfDataGrid_SelectItem_Persona == null) {new Page().DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN ITEM", "OK");return;}
            else{IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmBecCatClientesList>(_SfDataGrid_SelectItem_Persona);}
        }
        private ICommand VistaListFicMetCatCatedratico;
        public ICommand FicMetCatCatedratico{get { return VistaListFicMetCatCatedratico = VistaListFicMetCatCatedratico ?? new FicVmDelegateCommand(FicMetCatCatedraticoExecute); }}
        private void FicMetCatCatedraticoExecute()
        {
            if (_SfDataGrid_SelectItem_Persona == null){ new Page().DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN ITEM", "OK");return;}
            else{ IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatCatedraticosList>(_SfDataGrid_SelectItem_Persona); }
        }

        private ICommand VistaListFicMetCatEmpleado;
        public ICommand FicMetCatEmpleado { get { return VistaListFicMetCatEmpleado = VistaListFicMetCatEmpleado ?? new FicVmDelegateCommand(FicMetCatEmpleadoExecute); }}
        private void FicMetCatEmpleadoExecute()
        {
            if (_SfDataGrid_SelectItem_Persona == null){new Page().DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN ITEM", "OK");return;}
            else { IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatEmpleadosList>(_SfDataGrid_SelectItem_Persona); }
        }

        private ICommand VistaListFicMetCatDirWeb;
        public ICommand FicMetCatDirWeb{ get { return VistaListFicMetCatDirWeb = VistaListFicMetCatDirWeb ?? new FicVmDelegateCommand(FicMetCatDirWebExecute); }}
        private void FicMetCatDirWebExecute()
        {
            if (_SfDataGrid_SelectItem_Persona == null){new Page().DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN ITEM", "OK");return;}
            else{ IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatDirWebList>(_SfDataGrid_SelectItem_Persona);}
        }

        private ICommand VistaListFicMetCatAlumnos;
        public ICommand FicMetCatAlumnos { get { return VistaListFicMetCatAlumnos = VistaListFicMetCatAlumnos ?? new FicVmDelegateCommand(FicMetCatAlumnosExecute); }}
        private void FicMetCatAlumnosExecute()
        {
            if (_SfDataGrid_SelectItem_Persona == null){new Page().DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN ITEM", "OK"); return;}
            else{IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatAlumnosList>(_SfDataGrid_SelectItem_Persona); }
        }

        private ICommand VistaListFicMetCatTelefonos;
        public ICommand FicMetCatTelefonos {get { return VistaListFicMetCatTelefonos = VistaListFicMetCatTelefonos ?? new FicVmDelegateCommand(FicMetCatTelefonosExecute); }}
        private void FicMetCatTelefonosExecute()
        {
            if (_SfDataGrid_SelectItem_Persona == null) { new Page().DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN ITEM", "OK"); return; }
            else { IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatTelefonosList>(_SfDataGrid_SelectItem_Persona); }
        }

        private ICommand UpdatePersona;
        public ICommand FicMetUpdateCommand{get { return UpdatePersona = UpdatePersona ?? new FicVmDelegateCommand(UpdatePersonaExecute); }}
        private void UpdatePersonaExecute()
        {
            if (_SfDataGrid_SelectItem_Persona == null){ new Page().DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN Persona", "OK");return;}
            else{IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasEdit>(_SfDataGrid_SelectItem_Persona);}
        }

        private ICommand DetallePersona;
        public ICommand FicMetDetalleCommand{get { return DetallePersona = DetallePersona ?? new FicVmDelegateCommand(DetallePersonaExecute); }}
        private void DetallePersonaExecute()
        {
            if (_SfDataGrid_SelectItem_Persona == null){new Page().DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN Persona", "OK");return;}
            else{IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasDetail>(_SfDataGrid_SelectItem_Persona);}
        }

        private ICommand NewPersona;
        public ICommand FicMetNewCommand{get { return NewPersona = NewPersona ?? new FicVmDelegateCommand(NewPersonaExecute); }}
        private void NewPersonaExecute(){IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasNew>(null);}


        public async void OnAppearing()
        {
            try
                {
               var source_local_per = await IFicSrvRhCatPersonasList.FicMetGetListRhCatPersonas();
                if (source_local_per != null && _FicSfDataGrid_ItemSource_CatPersonas.Count == 0)
                {
                    foreach (rh_cat_personas per in source_local_per)
                    {
                        _FicSfDataGrid_ItemSource_CatPersonas.Add(per);
                     }
                }//LLENAR EL GRID
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//SOBRE CARGA AL METODO OnAppearing() DE LA VIEW 
        
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
            public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(propertyName));
            }
        #endregion
    }//CLASS 
}//NAMESPACE

