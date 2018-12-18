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
    public class FicVmRhCatAlumnosNew : FicViewModelBase
    {
        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        private IFicSrvRhCatAlumnosNew FicLoSrvApp;
        public ObservableCollection<eva_cat_carreras> _Picker_ItemSource_CatGeneralesEstadoCivil;



        public eva_cat_carreras _SfDataGrid_SelectItem_Estado_Civil;
        public eva_cat_carreras FicSfDataGrid_SelectItem_CatGeneralesEstadoCivil
        {
            get { return _SfDataGrid_SelectItem_Estado_Civil; }
            set{ _SfDataGrid_SelectItem_Estado_Civil = value;RaisePropertyChanged();}
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL PICKER ESTADO CIVIL DE LA VIEW
        public ObservableCollection<eva_cat_carreras> Picker_ItemSource_CatGeneralesEstadoCivil
        {
            get{return _Picker_ItemSource_CatGeneralesEstadoCivil;}
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER ESTADO CIVIL DE LA VIEW


        private rh_cat_alumnos _Alumnos;
        public rh_cat_alumnos Alumnos
        {
            get { return _Alumnos; }
            set
            {
                _Alumnos = value;
                RaisePropertyChanged();
            }
        }
        private rh_cat_personas _Persona;
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
        public ICommand BackNavgCommand
        {

            get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); }
        }
        private void FicMetCatClienteExecute()
        {
            FicLoSrvNavigation.FicMetNavigateTo<FicVmRhCatAlumnosList>(Persona);
        }

        private ICommand AddEdificio;
        public ICommand FicMetAddCommand
        {
            get { return AddEdificio = AddEdificio ?? new FicVmDelegateCommand(AddEdificioExecute); }
        }
        private void AddEdificioExecute()
        {
            Alumnos.UsuarioReg = "GUERRA";
            Alumnos.IdAlumno = Persona.IdPersona;
            Alumnos.UsuarioMod = Alumnos.UsuarioReg;
            Alumnos.FechaUltMod = DateTime.Now;
            Alumnos.FechaReg = DateTime.Now;
            Alumnos.IdCarrera = FicSfDataGrid_SelectItem_CatGeneralesEstadoCivil.IdCarrera;

            //Alumnos.IdCarrera = 1;
            if (Alumnos.Activo == "True")
            {
                Alumnos.Activo = "S";
            };
            if (Alumnos.Activo == null)
            {
                Alumnos.Activo = "N";
            };
            if (Alumnos.Borrado == "True")
            {
                Alumnos.Borrado = "S";
            };
            if (Alumnos.Borrado == null)
            {
                Alumnos.Borrado = "N";
            };
            FicLoSrvApp.FicMetGetNewRhCatAlumnos(Alumnos);
            FicLoSrvNavigation.FicMetNavigateTo<FicVmRhCatAlumnosList>(Persona);
        }

        public FicVmRhCatAlumnosNew(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvRhCatAlumnosNew FicPaSrvApp)
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
                    _Picker_ItemSource_CatGeneralesEstadoCivil.Add(estado_civil);
                }
            }//LLENAR EL PICKER DE ESTADO CIVIL

            _Alumnos = new rh_cat_alumnos();
            _Persona = new rh_cat_personas();
        }
        public void llenado(rh_cat_personas navigationContext)
        {
            Persona = navigationContext;

        }

    }
}
