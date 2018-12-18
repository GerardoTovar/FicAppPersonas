using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.Interfaces.RhCatAlumnos;
using FicAppPersonas.ViewModels.Base;
using FicAppPersonas.ViewModels.RhCatPersonas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.ViewModels.RhCatAlumnos
{
    public class FicVmRhCatAlumnosList : INotifyPropertyChanged
    {
        public ObservableCollection<rh_cat_alumnos> _FicSfDataGrid_ItemSource_CatEdificios;
        public rh_cat_alumnos _FicSfDataGrid_SelectItem_CatEdificios;
        //private ICommand _FicMetAddEdificioICommand, _FicMetAcumuladosICommand;
        private IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas;
        private IFicSrvRhCatAlumnosList IFicSrvRhCatAlumnosList;
        public rh_cat_personas _Alumnos;
        public rh_cat_personas Alumnos
        {
            get { return _Alumnos; }
            set
            {
                _Alumnos = value;
                RaisePropertyChanged();
            }
        }

        public FicVmRhCatAlumnosList(IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas, IFicSrvRhCatAlumnosList IFicSrvRhCatAlumnosList)
        {
            this.IFicSrvNavigationRhCatPersonas = IFicSrvNavigationRhCatPersonas; this.IFicSrvRhCatAlumnosList = IFicSrvRhCatAlumnosList;
            _FicSfDataGrid_ItemSource_CatEdificios = new ObservableCollection<rh_cat_alumnos>();

        }//CONSTRUCTOR

        public ObservableCollection<rh_cat_alumnos> FicSfDataGrid_ItemSource_CatEdificios
        {
            get
            {
                return _FicSfDataGrid_ItemSource_CatEdificios;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL GRID DE LA VIEW
        public rh_cat_alumnos _SfDataGrid_SelectItem_Edificio;

        public rh_cat_alumnos FicSfDataGrid_SelectItem_CatEdificios
        {
            get { return _SfDataGrid_SelectItem_Edificio; }
            set
            {
                _SfDataGrid_SelectItem_Edificio = value;
                RaisePropertyChanged();
            }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL GRID DE LA VIEW

        public rh_cat_alumnos SfDataGrid_SelectItem_Edificio
        {
            get { return _SfDataGrid_SelectItem_Edificio; }
            set
            {
                _SfDataGrid_SelectItem_Edificio = value;
                RaisePropertyChanged();
            }
        }

        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand
        {

            get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); }
        }
        private void FicMetCatClienteExecute()
        {
            IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasList>(null);
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
                IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatAlumnosUpdate>(_SfDataGrid_SelectItem_Edificio, Alumnos);
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
                IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatAlumnosDetail>(_SfDataGrid_SelectItem_Edificio, Alumnos);
            }

        }

        private ICommand NewEdificio;
        public ICommand FicMetNewCommand {get { return NewEdificio = NewEdificio ?? new FicVmDelegateCommand(NewEdificioExecute); }}
        private void NewEdificioExecute(){
           IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatAlumnosNew>(Alumnos);}


        public async void OnAppearing()
        {
            try
            {
                var source_local_inv = await IFicSrvRhCatAlumnosList.FicMetGetListRhCatAlumnos(Alumnos.IdPersona);
                if (source_local_inv != null && _FicSfDataGrid_ItemSource_CatEdificios.Count == 0)
                {
                    foreach (rh_cat_alumnos inv in source_local_inv)
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
        public void llenado(rh_cat_personas obj)
        {
            Alumnos = new rh_cat_personas();
            Alumnos = obj;
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

