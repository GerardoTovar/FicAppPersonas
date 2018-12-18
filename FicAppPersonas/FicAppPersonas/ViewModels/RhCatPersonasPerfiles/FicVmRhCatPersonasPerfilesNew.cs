using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.Interfaces.RhCatPersonasPerfiles;
using FicAppPersonas.ViewModels.Base;
using FicAppPersonas.ViewModels.RhCatPersonas;
using FicAppPersonas.ViewModels.RhPersonasPerfilEstatus;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.ViewModels.RhCatPersonasPerfiles
{
    public class FicVmRhCatPersonasPerfilesNew : FicViewModelBase
    {
        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        public ObservableCollection<rh_cat_perfiles> _Picker_ItemSource_CatGeneralesDirWeb;
        private IFicSrvRhCatPersonasPerfilesNew FicLoSrvApp;
        private bool _Activo;
        public bool Activo { get { return _Activo; } set { _Activo = value; RaisePropertyChanged(); } }
        private bool _Borrado;
        public bool Borrado { get { return _Borrado; } set { _Borrado = value; RaisePropertyChanged(); } }
        public ObservableCollection<rh_cat_perfiles> Picker_ItemSource_CatGenDirWeb
        {
            get
            {
                return _Picker_ItemSource_CatGeneralesDirWeb;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER INSTITUTOS DE LA VIEW


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

        private rh_cat_personas_perfiles _Edificios;
        public rh_cat_personas_perfiles Edificio
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
        private void FicMetCatClienteExecute() { FicLoSrvNavigation.FicMetNavigateTo<FicVmRhCatPersonasPerfilesList>(Persona); }

        private ICommand AddEdificio;
        public ICommand FicMetAddCommand
        {
            get { return AddEdificio = AddEdificio ?? new FicVmDelegateCommand(AddEdificioExecute); }
        }
        private void AddEdificioExecute()
        {
            Edificio.UsuarioReg = "gera";
            Edificio.IdPerfil = FicSfDataGrid_SelectItem_CatGenDirWeb.IdPerfil;
            Edificio.UsuarioMod = Edificio.UsuarioReg;
            Edificio.FechaUltMod = DateTime.Now;
            Edificio.FechaReg = DateTime.Now;
            Edificio.IdPersona = Persona.IdPersona;
            if (Activo == true) { Edificio.Activo = "S"; };
            if (Activo == false) { Edificio.Activo = "N"; };
            if (Borrado == true) { Edificio.Borrado = "S"; };
            if (Borrado == false) { Edificio.Borrado = "N"; };
            FicLoSrvApp.FicMetGetNewRhCatPersonasPerfiles(Edificio);
            FicLoSrvNavigation.FicMetNavigateTo<FicVmRhCatPersonasPerfilesList>(Persona);
        }

        public FicVmRhCatPersonasPerfilesNew(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvRhCatPersonasPerfilesNew FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
            _Picker_ItemSource_CatGeneralesDirWeb = new ObservableCollection<rh_cat_perfiles>();
        }

        public async override void OnAppearing(object navigationContext)
        {
            try
            {


                var source_local_institutos = await FicLoSrvApp.FicMetGetListRhCatGenerales();
                if (source_local_institutos != null)
                {
                    foreach (rh_cat_perfiles Dir in source_local_institutos)
                    {
                        if (Edificio.IdPerfil == Dir.IdPerfil)
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
        public void getPersonaData(rh_cat_personas persona)
        {
            _Edificios = new rh_cat_personas_perfiles();

            Activo = false;
            Borrado = false;
            Persona = new rh_cat_personas();
            Persona = persona;
        }

    }
}

