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
    public class FicVmRhCatPersonasDatosAdicionalesEdit : FicViewModelBase
    {
        public ObservableCollection<cat_generales> _Picker_ItemSource_CatGeneralesDirWeb;
        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        private IFicSrvRhCatPersonasDatosAdicionalesEdit FicLoSrvApp;
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
        private bool _Activo;
        public bool Activo { get { return _Activo; } set { _Activo = value; RaisePropertyChanged(); } }
        private bool _Borrado;
        public bool Borrado { get { return _Borrado; } set { _Borrado = value; RaisePropertyChanged(); } }
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
        private rh_cat_personas_datos_adicionales _Edificios;
        public rh_cat_personas_datos_adicionales Edificio
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
        private void FicMetCatClienteExecute() { FicLoSrvNavigation.FicMetNavigateTo<FicVmRhCatPersonasDatosAdicionalesList>(Persona); }

        private ICommand AddEdificio;
        public ICommand FicMetAddCommand
        {
            get { return AddEdificio = AddEdificio ?? new FicVmDelegateCommand(AddEdificioExecute); }
        }
        private void AddEdificioExecute()
        {
            Edificio.UsuarioReg = "gera";
            Edificio.IdPersona = Persona.IdPersona;
            Edificio.IdGenSeccion = FicSfDataGrid_SelectItem_CatGenDirWeb.IdGeneral;
            Edificio.IdTipoGenSeccion = FicSfDataGrid_SelectItem_CatGenDirWeb.IdTipoGeneral;
           // Edificio.UsuarioMod = Edificio.UsuarioReg;
            Edificio.FechaUltMod = DateTime.Now;
            //Edificio.FechaReg = DateTime.Now;
            if (Activo == true) { Edificio.Activo = "S"; };
            if (Activo == false) { Edificio.Activo = "N"; };
            if (Borrado == true) { Edificio.Borrado = "S"; };
            if (Borrado == false) { Edificio.Borrado = "N"; };
            FicLoSrvApp.FicMetGetEditRhCatEmpleados(Edificio);
            FicLoSrvNavigation.FicMetNavigateTo<FicVmRhCatPersonasDatosAdicionalesList>(Persona);
        }

        public FicVmRhCatPersonasDatosAdicionalesEdit(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvRhCatPersonasDatosAdicionalesEdit FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
            _Picker_ItemSource_CatGeneralesDirWeb = new ObservableCollection<cat_generales>();
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
                        _Picker_ItemSource_CatGeneralesDirWeb.Add(Dir);
                    }
                }//LLENAR EL PICKER DE INSTITUTOS
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }

        }
        public void llenado(rh_cat_personas_datos_adicionales obj, rh_cat_personas persona)
        {
            _Edificios = new rh_cat_personas_datos_adicionales();
            Edificio = obj;
            Persona = new rh_cat_personas();
            Persona = persona;

            if (Edificio.Activo == "S") { Activo = true; };
            if (Edificio.Activo == "N") { Activo = false; };
            if (Edificio.Borrado == "S") { Borrado = true; };
            if (Edificio.Borrado == "N") { Borrado = false; };
        }


    }
}


