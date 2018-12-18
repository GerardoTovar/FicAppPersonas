using FicAppPersonas.Interfaces.RhCatCatedraticos;
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

namespace FicAppPersonas.ViewModels.RhCatCatedraticos
{
    public class FicVmRhCatCatedraticosList : INotifyPropertyChanged
    {
        public ObservableCollection<rh_cat_catedraticos> _FicSfDataGrid_ItemSource_CatEdificios;
        public rh_cat_personas _FicSfDataGrid_SelectItem_CatEdificios;
        //private ICommand _FicMetAddEdificioICommand, _FicMetAcumuladosICommand;
        private IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas;
        private IFicSrvRhCatCatedraticosList IFicSrvRhCatCatedraticosList;

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

        public FicVmRhCatCatedraticosList(IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas, IFicSrvRhCatCatedraticosList IFicSrvRhCatCatedraticosList)
        {
            this.IFicSrvNavigationRhCatPersonas = IFicSrvNavigationRhCatPersonas; this.IFicSrvRhCatCatedraticosList = IFicSrvRhCatCatedraticosList;
            _FicSfDataGrid_ItemSource_CatEdificios = new ObservableCollection<rh_cat_catedraticos>();

        }//CONSTRUCTOR

        public ObservableCollection<rh_cat_catedraticos> FicSfDataGrid_ItemSource_CatEdificios
        {
            get
            {
                return _FicSfDataGrid_ItemSource_CatEdificios;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL GRID DE LA VIEW
        public rh_cat_catedraticos _SfDataGrid_SelectItem_Edificio;

        public rh_cat_catedraticos FicSfDataGrid_SelectItem_CatEdificios
        {
            get { return _SfDataGrid_SelectItem_Edificio; }
            set
            {
                _SfDataGrid_SelectItem_Edificio = value;
                RaisePropertyChanged();
            }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL GRID DE LA VIEW

        public rh_cat_catedraticos SfDataGrid_SelectItem_Edificio
        {
            get { return _SfDataGrid_SelectItem_Edificio; }
            set
            {
                _SfDataGrid_SelectItem_Edificio = value;
                RaisePropertyChanged();
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
                IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatCatedraticosEdit>(_SfDataGrid_SelectItem_Edificio, Persona);
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
                IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatCatedraticosDetail>(_SfDataGrid_SelectItem_Edificio, Persona);
            }

        }

        private ICommand NewEdificio;
        public ICommand FicMetNewCommand
        {
            get { return NewEdificio = NewEdificio ?? new FicVmDelegateCommand(NewEdificioExecute); }
        }
        private void NewEdificioExecute()
        {

            IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatCatedraticosNew>(Persona);
        }

        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand { get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); } }
        private void FicMetCatClienteExecute() { IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasList>(null); }


        public async void OnAppearing()
        {
            try
            {
                var source_local_inv = await IFicSrvRhCatCatedraticosList.FicMetGetListRhCatCatedraticos(Persona.IdPersona);
                if (source_local_inv != null)
                {
                    foreach (rh_cat_catedraticos inv in source_local_inv)
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

        public void getTelefonoData(rh_cat_personas per)
        {
            Persona = new rh_cat_personas();
            Persona = per;
        }
    }//CLASS 
}//NAMESPACE

