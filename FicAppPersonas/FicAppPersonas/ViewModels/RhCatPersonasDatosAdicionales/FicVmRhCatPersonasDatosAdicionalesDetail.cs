using System;
using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.ViewModels.Base;
using System.Windows.Input;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Interfaces.RhCatPersonasDatosAdicionales;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FicAppPersonas.ViewModels.RhCatPersonasDatosAdicionales
{
    public class FicVmRhCatPersonasDatosAdicionalesDetail : FicViewModelBase
    {
        public ObservableCollection<cat_generales> _Picker_ItemSource_CatGeneralesDirWeb;
        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        private IFicSrvRhCatPersonasDatosAdicionalesDetail FicLoSrvApp;
        #region


        public ObservableCollection<cat_generales> Picker_ItemSource_CatGenDirWeb
        {
            get
            {
                return _Picker_ItemSource_CatGeneralesDirWeb;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER INSTITUTOS DE LA VIEW
        #endregion

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
        public rh_cat_personas_datos_adicionales _Edificios;
        public rh_cat_personas_datos_adicionales Edificio
        {
            get { return _Edificios; }
            set
            {
                _Edificios = value;
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
        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand { get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); } }
        private void FicMetCatClienteExecute() { FicLoSrvNavigation.FicMetNavigateTo<FicVmRhCatPersonasDatosAdicionalesList>(Persona); }

        public FicVmRhCatPersonasDatosAdicionalesDetail(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvRhCatPersonasDatosAdicionalesDetail FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;

        }

        public async override void OnAppearing(object navigationContext)
        {
            try
            {


                var source_local_institutos = await FicLoSrvApp.FicMetGetListRhCatGenerales(13);
                if (source_local_institutos != null)
                {
                    foreach (cat_generales Dir in source_local_institutos)
                    {
                        if (Edificio.IdGenSeccion == Dir.IdGeneral)
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

        public void llenado(rh_cat_personas_datos_adicionales telefono, rh_cat_personas persona)
        {
            Edificio = new rh_cat_personas_datos_adicionales();
            Edificio = telefono;
            Persona = new rh_cat_personas();
            Persona = persona;
        }

    }

}


