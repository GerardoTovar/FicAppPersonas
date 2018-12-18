using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.Interfaces.RhCatTelefonos;
using FicAppPersonas.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.ViewModels.RhCatTelefonos
{
    public class FicVmRhCatTelefonosDetail : FicViewModelBase
    {
        

        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        private IFicSrvRhCatTelefonosDetail FicLoSrvApp;
        private ObservableCollection<cat_generales> _Picker_ItemSource_CatGenTelefonos;

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

        private rh_cat_telefonos _Telefono;
        public rh_cat_telefonos Telefono
        {
            get { return _Telefono; }
            set
            {
                _Telefono = value;
                RaisePropertyChanged();
            }
        }
        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand { get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); } }
        private void FicMetCatClienteExecute() { FicLoSrvNavigation.FicMetNavigateTo<FicVmRhCatTelefonosList>(Persona); }


        public FicVmRhCatTelefonosDetail(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvRhCatTelefonosDetail FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
            _Picker_ItemSource_CatGenTelefonos = new ObservableCollection<cat_generales>();

        }
        //=========================Item sources==============================//        


        #region           
        public ObservableCollection<cat_generales> Picker_ItemSource_CatGenTelefonos
        {
            get
            {
                return _Picker_ItemSource_CatGenTelefonos;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER TIPOS DE TELEFONOS DE LA VIEW
        #endregion


        //=========================Select Item==============================//      

        #region
        public cat_generales _Picker_SelectItem_CatGenTelefono;
        public cat_generales Picker_SelectItem_CatGenTelefono
        {
            get { return _Picker_SelectItem_CatGenTelefono; }
            set
            {
                _Picker_SelectItem_CatGenTelefono = value;
                RaisePropertyChanged();
            }
        }
        #endregion



        public async void OnAppearing()
        {

            var source_local_telefonos = await FicLoSrvApp.FicMetGetListRhCatGenerales(2); ;
            if (source_local_telefonos != null && _Picker_ItemSource_CatGenTelefonos.Count == 0)
            {
                foreach (cat_generales tel in source_local_telefonos)
                {
                    if (Telefono.IdGenTelefono == tel.IdGeneral)
                    {
                        Picker_SelectItem_CatGenTelefono = tel;
                    }
                    _Picker_ItemSource_CatGenTelefonos.Add(tel);
                }
            }//LLENAR EL PICKER DE INSTITUTOS
        }

        
        public void getTelefonoData(rh_cat_telefonos telefono,rh_cat_personas persona)
        {
            Telefono = new rh_cat_telefonos();
            Telefono = telefono;
            Persona = new rh_cat_personas();
            Persona = persona;
        }

    }//CLASS }



}//NAMESPACE


