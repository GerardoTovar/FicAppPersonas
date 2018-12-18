using FicAppPersonas.Interfaces.RhPersonasPerfilEstatus;
using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.Models.Asistencia;
using FicAppPersonas.ViewModels.Base;
using FicAppPersonas.ViewModels.RhPersonasPerfilEstatus;

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.ViewModels.RhCatPersonasPerfiles;

namespace FicAppPersonas.ViewModels.RhPersonasPerfilEstatus
{
    public class FicVmRhPersonasPerfilEstatusList : INotifyPropertyChanged
    {
        public ObservableCollection<rh_personas_perfil_estatus> _FicSfDataGrid_ItemSource_CatEdificios;
        public rh_personas_perfil_estatus _FicSfDataGrid_SelectItem_CatEdificios;
        //private ICommand _FicMetAddEdificioICommand, _FicMetAcumuladosICommand;
        private IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas;
        private IFicSrvRhPersonasPerfilEstatusList IFicSrvRhPersonasPerfilEstatusList;
        public rh_cat_personas_perfiles _PersonaEstatus;
        public rh_cat_personas_perfiles PersonaEstatus
        {
            get { return _PersonaEstatus; }
            set{_PersonaEstatus = value; RaisePropertyChanged();}
        }
        public rh_cat_personas _Persona;
        public rh_cat_personas Persona
        {
            get { return _Persona; }
            set { _Persona = value; RaisePropertyChanged();}
        }
        public rh_cat_perfiles _SfDataGrid_SelectItem_GeneralesDir;
        public rh_cat_perfiles FicSfDataGrid_SelectItem_CatGenDirWeb
        {
            get { return _SfDataGrid_SelectItem_GeneralesDir; }
            set
            {
                _SfDataGrid_SelectItem_GeneralesDir = value;
                RaisePropertyChanged();
            }
        }

        public FicVmRhPersonasPerfilEstatusList(IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas, IFicSrvRhPersonasPerfilEstatusList IFicSrvRhPersonasPerfilEstatusList)
        {
            this.IFicSrvNavigationRhCatPersonas = IFicSrvNavigationRhCatPersonas; this.IFicSrvRhPersonasPerfilEstatusList = IFicSrvRhPersonasPerfilEstatusList;
            _FicSfDataGrid_ItemSource_CatEdificios = new ObservableCollection<rh_personas_perfil_estatus>();

        }//CONSTRUCTOR

        public ObservableCollection<rh_personas_perfil_estatus> FicSfDataGrid_ItemSource_CatEdificios
        {
            get
            {
                return _FicSfDataGrid_ItemSource_CatEdificios;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL GRID DE LA VIEW

        public rh_personas_perfil_estatus _SfDataGrid_SelectItem_Edificio;

        public rh_personas_perfil_estatus FicSfDataGrid_SelectItem_CatEdificios
        {
            get { return _SfDataGrid_SelectItem_Edificio; }
            set
            {
                _SfDataGrid_SelectItem_Edificio = value;
                RaisePropertyChanged();
            }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL GRID DE LA VIEW

        public rh_personas_perfil_estatus SfDataGrid_SelectItem_Edificio
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
        private void FicMetCatClienteExecute() { IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasPerfilesList>(Persona); }


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
                IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhPersonasPerfilEstatusEdit>(_SfDataGrid_SelectItem_Edificio, PersonaEstatus, Persona, FicSfDataGrid_SelectItem_CatGenDirWeb);
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
                IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhPersonasPerfilEstatusDetail>(_SfDataGrid_SelectItem_Edificio, PersonaEstatus, Persona, FicSfDataGrid_SelectItem_CatGenDirWeb);
            }

        }

        private ICommand NewEdificio;
        public ICommand FicMetNewCommand
        {
            get { return NewEdificio = NewEdificio ?? new FicVmDelegateCommand(NewEdificioExecute); }
        }
        private void NewEdificioExecute()
        {

           IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhPersonasPerfilEstatusNew>(PersonaEstatus, Persona, FicSfDataGrid_SelectItem_CatGenDirWeb);
        }


        public async void OnAppearing()
        {
            try
            {
                var source_local_inv = await IFicSrvRhPersonasPerfilEstatusList.FicMetGetListRhPersonasPerfilEstatusList(PersonaEstatus);
                if (source_local_inv != null)
                {
                    foreach (rh_personas_perfil_estatus inv in source_local_inv)
                    {
                        _FicSfDataGrid_ItemSource_CatEdificios.Add(inv);
                    }
                }//LLENAR EL GRID
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }

            try
            {


                var source_local_institutos = await IFicSrvRhPersonasPerfilEstatusList.FicMetGetListRhCatGenerales();
                if (source_local_institutos != null)
                {
                    foreach (rh_cat_perfiles Dir in source_local_institutos)
                    {
                        if (PersonaEstatus.IdPerfil == Dir.IdPerfil)
                        {
                            FicSfDataGrid_SelectItem_CatGenDirWeb = Dir;
                        }
                        //Picker_ItemSource_CatGenDirWeb.Add(Dir);
                    }
                }//LLENAR EL PICKER DE INSTITUTOS
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

        public void llenado(rh_cat_personas_perfiles obj, rh_cat_personas persona)
        {
            PersonaEstatus = new rh_cat_personas_perfiles();
            PersonaEstatus = obj;

            Persona = new rh_cat_personas();
            Persona = persona;

        }
        

    }//CLASS 
}//NAMESPACE