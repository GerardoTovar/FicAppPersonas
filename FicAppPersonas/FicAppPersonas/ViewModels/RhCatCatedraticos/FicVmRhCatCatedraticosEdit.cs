using System;
using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.ViewModels.Base;
using System.Windows.Input;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Interfaces.RhCatCatedraticos;


namespace FicAppPersonas.ViewModels.RhCatCatedraticos
{
    public class FicVmRhCatCatedraticosEdit : FicViewModelBase
    {
        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        private IFicSrvRhCatCatedraticosEdit FicLoSrvApp;
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
        private rh_cat_catedraticos _Edificios;
        public rh_cat_catedraticos Edificio
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
        private void FicMetCatClienteExecute() { FicLoSrvNavigation.FicMetNavigateTo<FicVmRhCatCatedraticosList>(Persona); }

        private ICommand AddEdificio;
        public ICommand FicMetAddCommand
        {
            get { return AddEdificio = AddEdificio ?? new FicVmDelegateCommand(AddEdificioExecute); }
        }
        private void AddEdificioExecute()
        {
            // Edificio.UsuarioMod = Edificio.UsuarioReg;
            Edificio.FechaUltMod = DateTime.Now;
            // Edificio.FechaReg = DateTime.Now;
            if (Activo == true) { Edificio.Activo = "S"; };
            if (Activo == false) { Edificio.Activo = "N"; };
            if (Borrado == true) { Edificio.Borrado = "S"; };
            if (Borrado == false) { Edificio.Borrado = "N"; };
            FicLoSrvApp.FicMetGetEditRhCatEmpleados(Edificio);
            FicLoSrvNavigation.FicMetNavigateTo<FicVmRhCatCatedraticosList>(Persona);
        }

        public FicVmRhCatCatedraticosEdit(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvRhCatCatedraticosEdit FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
        }

        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
           
        }

        public void llenado(rh_cat_catedraticos obj, rh_cat_personas persona)
        {
            _Edificios = new rh_cat_catedraticos();
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