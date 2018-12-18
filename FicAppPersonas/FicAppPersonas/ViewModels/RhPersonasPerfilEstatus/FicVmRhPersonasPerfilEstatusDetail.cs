using System;
using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.ViewModels.Base;
using System.Windows.Input;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Interfaces.RhPersonasPerfilEstatus;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FicAppPersonas.ViewModels.RhPersonasPerfilEstatus
{
    public class FicVmRhPersonasPerfilEstatusDetail : FicViewModelBase
    {
        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        private IFicSrvRhPersonasPerfilEstatusDetail FicLoSrvApp;
        public ObservableCollection<cat_estatus> _Picker_ItemSource_CatGeneralesDirWeb;
        public ObservableCollection<cat_estatus> Picker_ItemSource_CatGenDirWeb
        {
            get
            {
                return _Picker_ItemSource_CatGeneralesDirWeb;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER INSTITUTOS DE LA VIEW

        public cat_estatus _SfDataGrid_SelectItem_GeneralesDir;
        public cat_estatus FicSfDataGrid_SelectItem_CatGenDirWeb
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
        public rh_cat_personas_perfiles _PersonasPerfil;
        public rh_cat_personas_perfiles PersonasPerfil
        {
            get { return _PersonasPerfil; }
            set
            {
                _PersonasPerfil = value;
                RaisePropertyChanged();
            }
        }
        public rh_cat_perfiles _Perfil;
        public rh_cat_perfiles Perfil
        {
            get { return _Perfil; }
            set
            {
                _Perfil = value;
                RaisePropertyChanged();
            }
        }

        private rh_personas_perfil_estatus _Edificios;
        public rh_personas_perfil_estatus Edificio
        {
            get { return _Edificios; }
            set
            {
                _Edificios = value;
                RaisePropertyChanged();
            }
        }

        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand { get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); } }
        private void FicMetCatClienteExecute() { FicLoSrvNavigation.FicMetNavigateTo<FicVmRhPersonasPerfilEstatusList>(PersonasPerfil, Persona); }

        public FicVmRhPersonasPerfilEstatusDetail(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvRhPersonasPerfilEstatusDetail FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
            _Picker_ItemSource_CatGeneralesDirWeb = new ObservableCollection<cat_estatus>();

        }

        public async override void OnAppearing(object navigationContext)
        {
            try
            {

                var source_local_institutos = await FicLoSrvApp.FicMetGetListRhCatGenerales(Perfil.IdPerfil);
                if (source_local_institutos != null)
                {
                    foreach (cat_estatus Dir in source_local_institutos)
                    {
                        if (Edificio.IdEstatus == Dir.IdEstatus)
                        {
                            FicSfDataGrid_SelectItem_CatGenDirWeb = Dir;
                        }
                        Picker_ItemSource_CatGenDirWeb.Add(Dir);
                    }
                }//LLENAR EL PICKER DE INSTITUTOS
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }
        public void llenado(rh_personas_perfil_estatus FicParameter4, rh_cat_personas_perfiles obj, rh_cat_personas persona, rh_cat_perfiles FicParameter3)
        {
            _Edificios = new rh_personas_perfil_estatus();
            Edificio = FicParameter4;
            PersonasPerfil = new rh_cat_personas_perfiles();
            PersonasPerfil = obj;
            Perfil = new rh_cat_perfiles();
            Perfil = FicParameter3;
            Persona = new rh_cat_personas();
            Persona = persona;


        }

    }

}