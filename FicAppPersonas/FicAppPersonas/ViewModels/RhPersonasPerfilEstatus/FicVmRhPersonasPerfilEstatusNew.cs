using System;
using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.ViewModels.Base;
using System.Windows.Input;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Interfaces.RhPersonasPerfilEstatus;
using FicAppPersonas.ViewModels.RhCatPersonas;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace FicAppPersonas.ViewModels.RhPersonasPerfilEstatus
{
    public class FicVmRhPersonasPerfilEstatusNew : FicViewModelBase
    {
        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        private IFicSrvRhPersonasPerfilEstatusNew FicLoSrvApp;
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
        private void AddEdificioExecute()
        {
            var a = new DateTime();
            a = DateTime.Parse(Edificio.FechaEstatus.ToString());
            if (a.Year <= 1)
            {
                Edificio.FechaEstatus = DateTime.Now;
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

            Edificio.IdPersona = Persona.IdPersona;
            Edificio.IdPerfil = Perfil.IdPerfil;
            Edificio.UsuarioReg = "GUERRA";
            Edificio.UsuarioMod = Edificio.UsuarioReg;
            Edificio.FechaUltMod = DateTime.Now;
            Edificio.IdEstatus = _SfDataGrid_SelectItem_GeneralesDir.IdEstatus;
            Edificio.IdTipoEstatus = _SfDataGrid_SelectItem_GeneralesDir.IdTipoEstatus;
            Edificio.FechaReg = DateTime.Now;
            if (Edificio.Actual == "True")
            {
                Edificio.Actual = "S";
            };
            if (Edificio.Actual == null)
            {
                Edificio.Actual = "N";
            };
            if (Edificio.Activo == "True")
            {
                Edificio.Activo = "S";
            };
            if (Edificio.Activo == null)
            {
                Edificio.Activo = "N";
            };
            if (Edificio.Borrado == "True")
            {
                Edificio.Borrado = "S";
            };
            if (Edificio.Borrado == null)
            {
                Edificio.Borrado = "N";
            };
            FicLoSrvApp.FicMetGetNewRhPersonasPerfilEstatus(Edificio);
            FicLoSrvNavigation.FicMetNavigateTo<FicVmRhPersonasPerfilEstatusList>(PersonasPerfil, Persona);
        }

        public FicVmRhPersonasPerfilEstatusNew(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvRhPersonasPerfilEstatusNew FicPaSrvApp)
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
                       /* if (Perfil.IdPerfil == Dir.id)
                        {
                            FicSfDataGrid_SelectItem_CatGenDirWeb = Dir;
                        }*/
                        Picker_ItemSource_CatGenDirWeb.Add(Dir);
                    }
                }//LLENAR EL PICKER DE INSTITUTOS
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }
        public void llenado(rh_cat_personas_perfiles obj, rh_cat_personas persona, rh_cat_perfiles FicParameter3)
        {
            _Edificios = new rh_personas_perfil_estatus();
            PersonasPerfil = new rh_cat_personas_perfiles();
            PersonasPerfil = obj;
            Edificio.FechaEstatus = DateTime.Parse(DateTime.Now.ToShortDateString());
            Perfil = new rh_cat_perfiles();
            Perfil = FicParameter3;
            Persona = new rh_cat_personas();
            Persona = persona;

        }
   

    }
}
