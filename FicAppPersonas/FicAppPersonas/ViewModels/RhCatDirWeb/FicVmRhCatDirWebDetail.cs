using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.Interfaces.RhCatDirWeb;
using FicAppPersonas.Interfaces.RhCatPersonas;
using FicAppPersonas.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.ViewModels.RhCatDirWeb
{
    public class FicVmRhCatDirWebDetail : FicViewModelBase
    {
        public ObservableCollection<rh_cat_dir_web> _FicSfDataGrid_ItemSource_CatDirWeb;

        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        private IFicSrvRhCatDirWebDetail FicLoSrvApp;
        public ObservableCollection<cat_generales> _Picker_ItemSource_CatGeneralesDirWeb;
        private IFicSrvNavigationRhCatPersonas IFicSrvNavigationCatDirWeb;
        //private IFicSrvRhCatDirWebDetail IFicSrvRhCatDirWebDetail;
        public cat_generales _SfDataGrid_SelectItem_GeneralesDir;
        public cat_generales FicSfDataGrid_SelectItem_CatGenDirWeb
        {
            get { return _SfDataGrid_SelectItem_GeneralesDir; }
            set
            {
                _SfDataGrid_SelectItem_GeneralesDir = value;
                RaisePropertyChanged();
            }
        }
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
        private rh_cat_dir_web _DirWeb;
        public rh_cat_dir_web DirWeb
        {
            get { return _DirWeb; }
            set
            {
                _DirWeb = value;
                RaisePropertyChanged();
            }
        }
        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand { get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); } }
        private void FicMetCatClienteExecute() { FicLoSrvNavigation.FicMetNavigateTo<FicVmRhCatDirWebList>(Persona); }
        private ICommand ItemDirWeb;
        public ICommand FicMetItemCommand
        {

            get { return ItemDirWeb = ItemDirWeb ?? new FicVmDelegateCommand(ItemDirWebExecute); }
        }
        private void ItemDirWebExecute()    
        {
           
            IFicSrvNavigationCatDirWeb.FicMetNavigateTo<FicVmRhCatDirWebList>(null);
        }

        public FicVmRhCatDirWebDetail(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvRhCatDirWebDetail FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
            _Picker_ItemSource_CatGeneralesDirWeb = new ObservableCollection<cat_generales>();
        }




        public ObservableCollection<cat_generales> Picker_ItemSource_CatGenDirWeb
        {
            get
            {
                return _Picker_ItemSource_CatGeneralesDirWeb;
            }
        }

        public async void OnAppearing()
        {

            try
            {
                var source_local_institutos = await FicLoSrvApp.FicMetGetListRhCatGenerales(2);
                if (source_local_institutos != null)
                {
                    foreach (cat_generales Dir in source_local_institutos)
                    {
                        if (DirWeb.IdGenDirWeb == Dir.IdGeneral)
                        {
                            FicSfDataGrid_SelectItem_CatGenDirWeb = Dir;
                        }
                        _Picker_ItemSource_CatGeneralesDirWeb.Add(Dir);
                    }
                }//LLENAR EL PICKER DE INSTITUTOS
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }

        }//SOBRECARGA AL METODO OnAppearing() DE LA VIEW 
        public void getTelefonoData(rh_cat_dir_web telefono, rh_cat_personas persona)
        {
            DirWeb = new rh_cat_dir_web();
            DirWeb = telefono;
            Persona = new rh_cat_personas();
            Persona = persona;
        }


    }//CLASS }



}//NAMESPACE