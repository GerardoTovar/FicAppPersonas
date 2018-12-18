using System;
using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.ViewModels.Base;
using System.Windows.Input;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Interfaces.RhPersonasPerfilEstatus;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace FicAppPersonas.ViewModels.RhPersonasPerfilEstatus
{
    public class FicVmRhPersonasPerfilEstatusEdit : FicViewModelBase
    {
        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        private IFicSrvRhPersonasPerfilEstatusEdit FicLoSrvApp;
        private bool _Actual;
        public bool Actual { get { return _Actual; } set { _Actual = value; RaisePropertyChanged(); } }
        private bool _Activo;
        public bool Activo { get { return _Activo; } set { _Activo = value; RaisePropertyChanged(); } }
        private bool _Borrado;
        public bool Borrado { get { return _Borrado; } set { _Borrado = value; RaisePropertyChanged(); } }
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

        private ICommand AddEdificio;
        public ICommand FicMetAddCommand
        {
            get { return AddEdificio = AddEdificio ?? new FicVmDelegateCommand(AddEdificioExecute); }
        }
        private async void AddEdificioExecute()
        {
            List<string> noFillFields = new List<string>();//LISTA DE CAMPOS QUE NO FUERON LLENADOS

            //CONJUNTO DE VALIDACIONES DE CAMPOS NO LLENADOS O NO SELECCIONADOS
            #region
            var a = new DateTime();
            a = DateTime.Parse(Edificio.FechaEstatus.ToString());
            if (a.Year <= 1)
            {                
            }
            else
            {
                var fecha_temp = a;
                var day = Int32.Parse(fecha_temp.Day.ToString());
                var month = Int32.Parse(fecha_temp.Month.ToString());
                var year = Int32.Parse(fecha_temp.Year.ToString());

                var hours = Int32.Parse(DateTime.Now.Hour.ToString());
                var mins = Int32.Parse(DateTime.Now.Minute.ToString());
                var sec = Int32.Parse(DateTime.Now.Second.ToString());
                var milisec = Int32.Parse(DateTime.Now.Millisecond.ToString());
                DateTime fecha = new DateTime(year, month, day, hours, mins, sec, milisec);
                Edificio.FechaEstatus = fecha;
            }
            if (FicSfDataGrid_SelectItem_CatGenDirWeb == null) {
                noFillFields.Add("estatus");
            }
            #endregion
            //SI TODOS LOS CAMPOS PASARON LA VALIDACION ASIGNAN SE PREPARA LA INSERCION PARA EL OBJETO PERSONA
            if (noFillFields.Count == 0)
            {


                Edificio.UsuarioMod = "GUERRA";
                Edificio.FechaUltMod = DateTime.Now;
                Edificio.IdEstatus = _SfDataGrid_SelectItem_GeneralesDir.IdEstatus;
                Edificio.IdTipoEstatus = _SfDataGrid_SelectItem_GeneralesDir.IdTipoEstatus;
                if (Actual == true) { Edificio.Actual = "S"; };
                if (Actual == false) { Edificio.Actual = "N"; }
                if (Activo == true) { Edificio.Activo = "S"; };
                if (Activo == false) { Edificio.Activo = "N"; };
                if (Borrado == true) { Edificio.Borrado = "S"; };
                if (Borrado == false) { Edificio.Borrado = "N"; };
                await FicLoSrvApp.FicMetGetEditRhPersonasPerfilEstatus(Edificio);
                FicLoSrvNavigation.FicMetNavigateTo<FicVmRhPersonasPerfilEstatusList>(PersonasPerfil, Persona);
            }
            else
            {
                //LISTADO DE LOS CAMPOS QUE NO FUERON LLENADOS
                var empty_fields = "Los siguientes campos no fueron llenados: ";
                int i = 0;
                foreach (string field in noFillFields)
                {
                    i++;
                    if (i != noFillFields.Count() - 1)
                    {
                        if (i != noFillFields.Count())
                        {
                            empty_fields += field + ", ";
                        }
                        else
                        {
                            empty_fields += field + ".";
                        }
                    }
                    else
                    {
                        empty_fields += field + " y ";
                    }
                }
                //ALERT DIALOG DE CAMPOS FALTANTES
                await new Page().DisplayAlert("ALERTA", empty_fields.ToString(), "OK");
            }
        }

        public FicVmRhPersonasPerfilEstatusEdit(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvRhPersonasPerfilEstatusEdit FicPaSrvApp)
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
           // Edificio.FechaEstatus = DateTime.Parse(DateTime.Now.ToShortDateString());
            Perfil = new rh_cat_perfiles();
            Perfil = FicParameter3;
            Persona = new rh_cat_personas();
            Persona = persona;

            if (Edificio.Actual == "S") { Actual = true; };
            if (Edificio.Actual == "N") { Actual = false; };
            if (Edificio.Activo == "S") { Activo = true; };
            if (Edificio.Activo == "N") { Activo = false; };
            if (Edificio.Borrado == "S") { Borrado = true; };
            if (Edificio.Borrado == "N") { Borrado = false; };

        }


    }
}

