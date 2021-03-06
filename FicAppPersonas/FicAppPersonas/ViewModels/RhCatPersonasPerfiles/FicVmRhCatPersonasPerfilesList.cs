﻿using FicAppPersonas.Interfaces.RhCatPersonas;
using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.Models.Asistencia;
using FicAppPersonas.ViewModels.Base;

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.ViewModels.RhCatPersonas;
using FicAppPersonas.ViewModels.RhPersonasPerfilEstatus;

namespace FicAppPersonas.ViewModels.RhCatPersonasPerfiles
{
    public class FicVmRhCatPersonasPerfilesList : INotifyPropertyChanged
    {
        public ObservableCollection<rh_cat_personas_perfiles> _FicSfDataGrid_ItemSource_CatEdificios;
        public rh_cat_personas_perfiles _FicSfDataGrid_SelectItem_CatEdificios;
        //private ICommand _FicMetAddEdificioICommand, _FicMetAcumuladosICommand;
        private IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas;
        private IFicSrvRhCatPersonasPerfilesList IFicSrvRhCatPersonasPerfilesList;
        public rh_cat_personas _Persona;
        public rh_cat_personas Persona
        {
            get { return _Persona; }
            set
            {
                _Persona = value;
                RaisePropertyChanged();
            }
        }


        public FicVmRhCatPersonasPerfilesList(IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas, IFicSrvRhCatPersonasPerfilesList IFicSrvRhCatPersonasPerfilesList)
        {
            this.IFicSrvNavigationRhCatPersonas = IFicSrvNavigationRhCatPersonas; this.IFicSrvRhCatPersonasPerfilesList = IFicSrvRhCatPersonasPerfilesList;
            _FicSfDataGrid_ItemSource_CatEdificios = new ObservableCollection<rh_cat_personas_perfiles>();

        }//CONSTRUCTOR

        public ObservableCollection<rh_cat_personas_perfiles> FicSfDataGrid_ItemSource_CatEdificios
        {  
            get
            {
                return _FicSfDataGrid_ItemSource_CatEdificios;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL GRID DE LA VIEW
        public rh_cat_personas_perfiles _SfDataGrid_SelectItem_Edificio;

        public rh_cat_personas_perfiles FicSfDataGrid_SelectItem_CatEdificios
        {
            get { return _SfDataGrid_SelectItem_Edificio; }
            set
            {
                _SfDataGrid_SelectItem_Edificio = value;
                RaisePropertyChanged();
            }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL GRID DE LA VIEW

        public rh_cat_personas_perfiles SfDataGrid_SelectItem_Edificio
        {
            get { return _SfDataGrid_SelectItem_Edificio; }
            set
            {
                _SfDataGrid_SelectItem_Edificio = value;
                RaisePropertyChanged();
            }
        }

        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand { get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); } }
        private void FicMetCatClienteExecute() { IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasList>(null); }


        private ICommand _FicMetNewEstatusCommand;
        public ICommand FicMetNewEstatusCommand { get { return _FicMetNewEstatusCommand = _FicMetNewEstatusCommand ?? new FicVmDelegateCommand(FicMetEstatusExecute); } }
        private void FicMetEstatusExecute()
        {
            if (_SfDataGrid_SelectItem_Edificio == null)
            {
                new Page().DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN ITEM", "OK");
                return;
            }
            else
            {
                IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhPersonasPerfilEstatusList>(_SfDataGrid_SelectItem_Edificio, Persona);
            }
            
        }

        private ICommand UpdateEdificio;
        public ICommand FicMetUpdateCommand
        {

            get { return UpdateEdificio = UpdateEdificio ?? new FicVmDelegateCommand(UpdateEdificioExecute); }
        }
        private void UpdateEdificioExecute()
        {
            if (_SfDataGrid_SelectItem_Edificio == null)
            {
                new Page().DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN ITEM", "OK");
                return;
            }
            else
            {
                IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasPerfilesUpdate>(_SfDataGrid_SelectItem_Edificio, Persona);
            }

        }

        private ICommand DetalleEdificio;
        public ICommand FicMetDetalleCommand
        {

            get { return DetalleEdificio = DetalleEdificio ?? new FicVmDelegateCommand(DetalleEdificioExecute); }
        }
        private void DetalleEdificioExecute()
        {
            if (_SfDataGrid_SelectItem_Edificio == null)
            {
                new Page().DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN ITEM", "OK");
                return;
            }
            else
            {
                IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasPerfilesDetail>(_SfDataGrid_SelectItem_Edificio, Persona);
            }

        }

        private ICommand NewEdificio;
        public ICommand FicMetNewCommand
        {
            get { return NewEdificio = NewEdificio ?? new FicVmDelegateCommand(NewEdificioExecute); }
        }
        private void NewEdificioExecute()
        {

            IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasPerfilesNew>(Persona);
        }


        public async void OnAppearing()
        {
            try
                {
               var source_local_inv = await IFicSrvRhCatPersonasPerfilesList.FicMetGetListRhCatPersonasPerfiles(Persona.IdPersona);
                if (source_local_inv != null)
                {
                    foreach (rh_cat_personas_perfiles inv in source_local_inv)
                    {
                        _FicSfDataGrid_ItemSource_CatEdificios.Add(inv);
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

        public void getPersonaData(rh_cat_personas persona)
        {
            Persona = new rh_cat_personas();
            Persona = persona;
        }
    }//CLASS 
}//NAMESPACE

