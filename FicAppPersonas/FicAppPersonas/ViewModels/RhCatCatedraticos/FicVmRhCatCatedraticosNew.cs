using System;
using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.ViewModels.Base;
using System.Windows.Input;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Interfaces.RhCatCatedraticos;


namespace FicAppPersonas.ViewModels.RhCatCatedraticos
{
    public class FicVmRhCatCatedraticosNew : FicViewModelBase
    {
        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        private IFicSrvRhCatCatedraticosNew FicLoSrvApp;
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
            Edificio.UsuarioReg = "gera";
            Edificio.UsuarioMod = Edificio.UsuarioReg;
            Edificio.FechaUltMod = DateTime.Now;
            Edificio.FechaReg = DateTime.Now;
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
            FicLoSrvApp.FicMetGetNewRhCatEmpleados(Edificio);
            FicLoSrvNavigation.FicMetNavigateTo<FicVmRhCatCatedraticosList>(Persona);
        }

        public FicVmRhCatCatedraticosNew(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvRhCatCatedraticosNew FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
        }

        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            
        }
        public void getPersonaData(rh_cat_personas persona)
        {
            Persona = new rh_cat_personas();
            Persona = persona;
            _Edificios = new rh_cat_catedraticos();
            Edificio.IdEmpleado = Persona.IdPersona;
            _Edificios.IdEmpleado = Persona.IdPersona;
        }

    }
}
