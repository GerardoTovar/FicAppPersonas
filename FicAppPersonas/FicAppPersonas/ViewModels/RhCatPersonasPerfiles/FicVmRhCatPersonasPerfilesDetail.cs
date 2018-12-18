using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.Interfaces.RhCatPersonas;
using FicAppPersonas.Interfaces.RhCatPersonasPerfiles;
using FicAppPersonas.ViewModels.Base;
using FicAppPersonas.ViewModels.RhCatPersonas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.ViewModels.RhCatPersonasPerfiles
{
    public class FicVmRhCatPersonasPerfilesDetail : FicViewModelBase
    {
        public ObservableCollection<cat_generales> _FicSfDataGrid_ItemSource_CatDirWeb;

        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        private IFicSrvRhCatPersonasPerfilesDetail FicLoSrvApp;
        private IFicSrvNavigationRhCatPersonas IFicSrvNavigationCatDirWeb;
       // private IFicSrvRhCatPersonasPerfilesDetail IFicSrvRhCatDirWebList;
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
        private rh_cat_personas_perfiles _DirWeb;
        public rh_cat_personas_perfiles DirWeb
        {
            get { return _DirWeb; }
            set
            {
                _DirWeb = value;
                RaisePropertyChanged();
            }
        }


        public FicVmRhCatPersonasPerfilesDetail(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvRhCatPersonasPerfilesDetail FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
        }

        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand { get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); } }
        private void FicMetCatClienteExecute() { FicLoSrvNavigation.FicMetNavigateTo<FicVmRhCatPersonasPerfilesList>(Persona); }



        public async override void OnAppearing(object navigationContext)
        {
            try
            {


                var source_local_institutos = await FicLoSrvApp.FicMetGetListRhCatGenerales();
                if (source_local_institutos != null)
                {
                    foreach (rh_cat_perfiles Dir in source_local_institutos)
                    {
                        if (DirWeb.IdPerfil == Dir.IdPerfil)
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
        }

        public void llenado(rh_cat_personas_perfiles telefono, rh_cat_personas persona)
        {
            DirWeb = new rh_cat_personas_perfiles();
            DirWeb = telefono;
            Persona = new rh_cat_personas();
            Persona = persona;
        }


    }//CLASS }



}//NAMESPACE