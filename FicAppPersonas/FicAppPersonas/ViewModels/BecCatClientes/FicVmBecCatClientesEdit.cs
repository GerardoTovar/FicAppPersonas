using System;
using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.ViewModels.Base;
using System.Windows.Input;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Interfaces.BecCatClientes;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FicAppPersonas.ViewModels.BecCatClientes
{
    public class FicVmBecCatClientesEdit : FicViewModelBase
    {
        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        private IFicSrvBecCatClientesEdit FicLoSrvApp;
        public ObservableCollection<rh_cat_grupos> _Picker_ItemSource_CatGeneralesDirWeb;
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
        private bec_cat_clientes _Edificios;
        public bec_cat_clientes Edificio
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
        private void FicMetCatClienteExecute() { FicLoSrvNavigation.FicMetNavigateTo<FicVmBecCatClientesList>(Persona); }

        private ICommand AddEdificio;
        public ICommand FicMetAddCommand
        {
            get { return AddEdificio = AddEdificio ?? new FicVmDelegateCommand(AddEdificioExecute); }
        }
        private void AddEdificioExecute()
        {
            DateTime a = DateTime.Parse(Edificio.FechaAlta.ToString());
            if (a.Year <= 1)
            {
                Edificio.FechaAlta = DateTime.Now;
            }
            else
            {
                var fecha_temp = DateTime.Parse(Edificio.FechaAlta.ToString());
                var day = Int32.Parse(fecha_temp.Day.ToString());
                var month = Int32.Parse(fecha_temp.Month.ToString());
                var year = Int32.Parse(fecha_temp.Year.ToString());

                var hours = Int32.Parse(DateTime.Now.Hour.ToString());
                var mins = Int32.Parse(DateTime.Now.Minute.ToString());
                var sec = Int32.Parse(DateTime.Now.Second.ToString());
                var milisec = Int32.Parse(DateTime.Now.Millisecond.ToString());
                DateTime fecha = new DateTime(year, month, day, hours, mins, sec, milisec);
                Edificio.FechaAlta = fecha;

            }
            //Edificio.UsuarioMod = Edificio.UsuarioReg;
            Edificio.FechaUltMod = DateTime.Now;
            Edificio.IdGrupo = FicSfDataGrid_SelectItem_CatGenDirWeb.IdGrupo;
            Edificio.IdTipoGrupo = FicSfDataGrid_SelectItem_CatGenDirWeb.IdTipoGrupo;
            //Edificio.FechaReg = DateTime.Now;
            if (Activo == true) { Edificio.Activo = "S"; };
            if (Activo == false) { Edificio.Activo = "N"; };
            if (Borrado == true) { Edificio.Borrado = "S"; };
            if (Borrado == false) { Edificio.Borrado = "N"; };
            FicLoSrvApp.FicMetGetEditBecCatClientes(Edificio);
            FicLoSrvNavigation.FicMetNavigateTo<FicVmBecCatClientesList>(Persona);
        }

        public FicVmBecCatClientesEdit(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvBecCatClientesEdit FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
            _Picker_ItemSource_CatGeneralesDirWeb = new ObservableCollection<rh_cat_grupos>();
        }
        public ObservableCollection<rh_cat_grupos> Picker_ItemSource_CatGenDirWeb
        {
            get
            {
                return _Picker_ItemSource_CatGeneralesDirWeb;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER INSTITUTOS DE LA VIEW


        public rh_cat_grupos _SfDataGrid_SelectItem_GeneralesDir;
        public rh_cat_grupos FicSfDataGrid_SelectItem_CatGenDirWeb
        {
            get { return _SfDataGrid_SelectItem_GeneralesDir; }
            set
            {
                _SfDataGrid_SelectItem_GeneralesDir = value;
                RaisePropertyChanged();
            }
        }
        public async override void OnAppearing(object navigationContext)
        {
            try
            {


                var source_local_institutos = await FicLoSrvApp.FicMetGetListRhCatGenerales(1);
                if (source_local_institutos != null)
                {
                    foreach (rh_cat_grupos Dir in source_local_institutos)
                    {
                        if (Edificio.IdGrupo == Dir.IdGrupo)
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
        public void llenado(bec_cat_clientes obj, rh_cat_personas persona)
        {
            _Edificios = new bec_cat_clientes();
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