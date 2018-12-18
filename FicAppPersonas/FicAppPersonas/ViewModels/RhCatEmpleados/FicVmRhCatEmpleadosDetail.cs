using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.Interfaces.RhCatEmpleados;
using FicAppPersonas.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.ViewModels.RhCatEmpleados
{
   public class FicVmRhCatEmpleadosDetail : FicViewModelBase
    {
        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        private IFicSrvRhCatEmpleadosDetail FicLoSrvApp;
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
        public rh_cat_empleados _Empleados;
        public rh_cat_empleados Empleados
        {
            get { return _Empleados; }
            set
            {
                _Empleados = value;
                RaisePropertyChanged();
            }
        }

        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand { get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); } }
        private void FicMetCatClienteExecute() { FicLoSrvNavigation.FicMetNavigateTo<FicVmRhCatEmpleadosList>(Persona); }

        public FicVmRhCatEmpleadosDetail(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvRhCatEmpleadosDetail FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;

        }

        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
           
        }
        public void llenado(rh_cat_empleados obj , rh_cat_personas obj2 )
        {
            Empleados = new rh_cat_empleados();
            Empleados = obj;
            Persona = new rh_cat_personas();
            Persona = obj2;
        }

    }
}
