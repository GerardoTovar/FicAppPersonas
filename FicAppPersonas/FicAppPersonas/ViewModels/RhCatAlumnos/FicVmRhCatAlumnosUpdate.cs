using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.Interfaces.RhCatAlumnos;

using FicAppPersonas.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.ViewModels.RhCatAlumnos
{
    public class FicVmRhCatAlumnosUpdate : FicViewModelBase
    {
        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        private IFicSrvRhCatAlumnosUpdate FicLoSrvApp;
        private bool _Activo;
        public bool Activo { get { return _Activo; } set { _Activo = value; RaisePropertyChanged(); } }
        private bool _Borrado;
        public bool Borrado { get { return _Borrado; } set { _Borrado = value; RaisePropertyChanged(); } }
        public ObservableCollection<eva_cat_carreras> _Picker_ItemSource_CatGeneralesEstadoCivil;



        public eva_cat_carreras _SfDataGrid_SelectItem_Estado_Civil;
        public eva_cat_carreras FicSfDataGrid_SelectItem_CatGeneralesEstadoCivil
        {
            get { return _SfDataGrid_SelectItem_Estado_Civil; }
            set { _SfDataGrid_SelectItem_Estado_Civil = value; RaisePropertyChanged(); }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL PICKER ESTADO CIVIL DE LA VIEW
        public ObservableCollection<eva_cat_carreras> Picker_ItemSource_CatGeneralesEstadoCivil
        {
            get { return _Picker_ItemSource_CatGeneralesEstadoCivil; }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER ESTADO CIVIL DE LA VIEW
        private rh_cat_personas _Personas;
        public rh_cat_personas Persona
        {
            get { return _Personas; }
            set
            {
                _Personas = value;
                RaisePropertyChanged();
            }
        }

        public rh_cat_alumnos _Alumnos;
        public rh_cat_alumnos Alumnos
        {
            get { return _Alumnos; }
            set
            {
                _Alumnos = value;
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
            FicLoSrvNavigation.FicMetNavigateTo<FicVmRhCatAlumnosList>(Persona);
        }
        private ICommand UpdateEdificio;
        public ICommand FicMetUpdateCommand
        {
            get { return UpdateEdificio = UpdateEdificio ?? new FicVmDelegateCommand(UpdateEdificioExecute); }
        }
        private void UpdateEdificioExecute()
        {
            Alumnos.UsuarioMod = "GUERRA";
            Alumnos.FechaUltMod = DateTime.Now;
            Alumnos.IdCarrera = FicSfDataGrid_SelectItem_CatGeneralesEstadoCivil.IdCarrera;
            if (Activo == true) { Persona.Activo = "S"; };
            if (Activo == false) { Persona.Activo = "N"; };
            if (Borrado == true) { Persona.Borrado = "S"; };
            if (Borrado == false) { Persona.Borrado = "N"; };
            FicLoSrvApp.FicMetUpdateAlumnos(Alumnos);
            FicLoSrvNavigation.FicMetNavigateTo<FicVmRhCatAlumnosList>(Persona);
        }

        public FicVmRhCatAlumnosUpdate(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvRhCatAlumnosUpdate FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
            _Picker_ItemSource_CatGeneralesEstadoCivil = new ObservableCollection<eva_cat_carreras>();
        }



        public async override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            var source_local_estado_civil = await FicLoSrvApp.FicMetGetListRhCaCarreras();
            if (source_local_estado_civil != null)
            {
                foreach (eva_cat_carreras estado_civil in source_local_estado_civil)
                {
                    if (estado_civil.IdCarrera == Alumnos.IdCarrera)
                    {
                        FicSfDataGrid_SelectItem_CatGeneralesEstadoCivil = estado_civil;
                    }
                    _Picker_ItemSource_CatGeneralesEstadoCivil.Add(estado_civil);
                }
            }//LLENAR EL PICKER DE ESTADO CIVIL
        }
        public void llenado(rh_cat_alumnos obj, rh_cat_personas FicLoParameter2)
        {
            Alumnos = new rh_cat_alumnos();
            Persona = new rh_cat_personas();
            Alumnos = obj;
            Persona = FicLoParameter2;
            if (Persona.Activo == "S") { Activo = true; };
            if (Persona.Activo == "N") { Activo = false; };
            if (Persona.Borrado == "S") { Borrado = true; };
            if (Persona.Borrado == "N") { Borrado = false; };
        }


    }
}
