using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.Interfaces.RhCatAlumnos;
using FicAppPersonas.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.ViewModels.RhCatAlumnos
{
   public class FicVmRhCatAlumnosDetail : FicViewModelBase
    {
        public ObservableCollection<rh_cat_alumnos> _FicSfDataGrid_ItemSource_CatAlumno;

        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        private IFicSrvRhCatAlumnosDetail FicLoSrvApp;
        private IFicSrvNavigationRhCatPersonas IFicSrvNavigationCatAlumnos;
       // private IFicSrvRhCatAlumnosDetail IFicSrvRhCatAlumnosDetail;

        public eva_cat_carreras _SfDataGrid_SelectItem_Estado_Civil;
        public eva_cat_carreras FicSfDataGrid_SelectItem_CatGeneralesEstadoCivil
        {
            get { return _SfDataGrid_SelectItem_Estado_Civil; }
            set { _SfDataGrid_SelectItem_Estado_Civil = value; RaisePropertyChanged(); }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL PICKER ESTADO CIVIL DE LA VIEW

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
        private ICommand ItemAlumno;
        public ICommand FicMetItemCommand
        {

            get { return ItemAlumno = ItemAlumno ?? new FicVmDelegateCommand(ItemAlumnoExecute); }
        }
        private void ItemAlumnoExecute()
        {

            IFicSrvNavigationCatAlumnos.FicMetNavigateTo<FicVmRhCatAlumnosList>(Persona);
        }

        public FicVmRhCatAlumnosDetail(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvRhCatAlumnosDetail FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
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



        public async void OnAppearing()
        {

            try
            {
                var source_local_estado_civil = await FicLoSrvApp.FicMetGetListRhCaCarreras();
                if (source_local_estado_civil != null)
                {
                    foreach (eva_cat_carreras estado_civil in source_local_estado_civil)
                    {
                        if (estado_civil.IdCarrera == Alumnos.IdCarrera)
                        {
                            FicSfDataGrid_SelectItem_CatGeneralesEstadoCivil = estado_civil;
                        }

                    }
                }//LLENAR EL PICKER DE ESTADO CIVIL
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }

        }//SOBRECARGA AL METODO OnAppearing() DE LA VIEW 
        public void llenado(rh_cat_alumnos obj, rh_cat_personas FicLoParameter2)
        {
            Alumnos = new rh_cat_alumnos();
            Persona = new rh_cat_personas();
            Alumnos = obj;
            Persona = FicLoParameter2;
        }


    }//CLASS }



}//NAMESPACE


