using FicAppPersonas.Interfaces.RhCatTelefonos;
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

namespace FicAppPersonas.ViewModels.RhCatTelefonos
{
    public class FicVmRhCatTelefonosList : INotifyPropertyChanged
    {
        public ObservableCollection<rh_cat_telefonos> _FicSfDataGrid_ItemSource_Telefonos;
        //private ICommand _FicMetAddTelefonoICommand, _FicMetAcumuladosICommand;
        private IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas;
        private IFicSrvRhCatTelefonosList IFicSrvRhCatTelefonosList;
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

        public FicVmRhCatTelefonosList(IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas, IFicSrvRhCatTelefonosList IFicSrvRhCatTelefonosList)
        {
            this.IFicSrvNavigationRhCatPersonas = IFicSrvNavigationRhCatPersonas; this.IFicSrvRhCatTelefonosList = IFicSrvRhCatTelefonosList;
            _FicSfDataGrid_ItemSource_Telefonos = new ObservableCollection<rh_cat_telefonos>();

        }//CONSTRUCTOR

        public ObservableCollection<rh_cat_telefonos> FicSfDataGrid_ItemSource_Telefonos
        {
            get
            {
                return _FicSfDataGrid_ItemSource_Telefonos;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL GRID DE LA VIEW
        public rh_cat_telefonos _SfDataGrid_SelectItem_Telefono;

        public rh_cat_telefonos FicSfDataGrid_SelectItem_Telefono
        {
            get { return _SfDataGrid_SelectItem_Telefono; }
            set
            {
                _SfDataGrid_SelectItem_Telefono = value;
                RaisePropertyChanged();
            }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL GRID DE LA VIEW

        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand { get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); } }
        private void FicMetCatClienteExecute() { IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasList>(null); }


        private ICommand UpdateTelefono;
        public ICommand FicMetUpdateCommand
        {
            get { return UpdateTelefono = UpdateTelefono ?? new FicVmDelegateCommand(UpdateTelefonoExecute); }
        }
        private void UpdateTelefonoExecute()
        {
            if (_SfDataGrid_SelectItem_Telefono == null)
            {
                new Page().DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN ITEM", "OK");
                return;
            }
            else
            {
                IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatTelefonosUpdate>(_SfDataGrid_SelectItem_Telefono, Persona);
            }
        }

        private ICommand DetalleTelefono;
        public ICommand FicMetDetalleCommand
        {

            get { return DetalleTelefono = DetalleTelefono ?? new FicVmDelegateCommand(DetalleTelefonoExecute); }
        }
        private void DetalleTelefonoExecute()
        {
            if (_SfDataGrid_SelectItem_Telefono == null)
            {
                new Page().DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN ITEM", "OK");
                return;
            }
            else
            {
                IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatTelefonosDetail>(_SfDataGrid_SelectItem_Telefono, Persona);
            }
        }

        private ICommand NewTelefono;
        public ICommand FicMetNewCommand{get { return NewTelefono = NewTelefono ?? new FicVmDelegateCommand(NewTelefonoExecute); } }
        private void NewTelefonoExecute(){IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatTelefonosNew>(Persona);}


        public async void OnAppearing()
        {
            try
            {
                var source_local_telefono = await IFicSrvRhCatTelefonosList.FicMetGetListRhCatTelefonos(Persona.IdPersona);
                if (source_local_telefono != null && _FicSfDataGrid_ItemSource_Telefonos.Count == 0)
                {
                    foreach (rh_cat_telefonos tel in source_local_telefono)
                    {
                        _FicSfDataGrid_ItemSource_Telefonos.Add(tel);
                    }
                }//LLENAR EL GRID
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//SOBRE CARGA AL METODO OnAppearing() DE LA VIEW 
        public void getTelefonoData(rh_cat_personas per)
        {
            Persona = new rh_cat_personas();
            Persona = per;
        }

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
