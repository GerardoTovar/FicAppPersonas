using System;
using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.ViewModels.Base;
using System.Windows.Input;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Interfaces.RhCatCatedraticos;

namespace FicAppPersonas.ViewModels.RhCatCatedraticos
{
    public class FicVmRhCatCatedraticosDetail : FicViewModelBase
    {
        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        private IFicSrvRhCatCatedraticosDetail FicLoSrvApp;
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
        public rh_cat_catedraticos _Edificios;
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

        public FicVmRhCatCatedraticosDetail(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvRhCatCatedraticosDetail FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;

        }

        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            
        }
        public void llenado(rh_cat_catedraticos obj, rh_cat_personas obj2)
        {
            Edificio = new rh_cat_catedraticos();
            Edificio = obj;
            Persona = new rh_cat_personas();
            Persona = obj2;
        }

    }

}