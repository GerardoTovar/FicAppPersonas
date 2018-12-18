using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FicAppPersonas.ViewModels.RhPersonasPerfilEstatus;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.RhPersonasPerfilEstatus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViRhPersonasPerfilEstatusDetail : ContentPage
    {
        private rh_cat_personas_perfiles FicLoParameter;
        private rh_cat_personas FicLoParameter2;
        private rh_cat_perfiles FicLoParameter3;
        private rh_personas_perfil_estatus FicLoParameter4;
        public FicViRhPersonasPerfilEstatusDetail()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmRhPersonasPerfilEstatusDetail;
        }



        public FicViRhPersonasPerfilEstatusDetail(rh_personas_perfil_estatus FicParameter4, rh_cat_personas_perfiles FicParameter, rh_cat_personas FicParameter2, rh_cat_perfiles FicParameter3)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            FicLoParameter2 = FicParameter2;
            FicLoParameter3 = FicParameter3;
            FicLoParameter4 = FicParameter4;
            BindingContext = App.FicVmLocator.FicVmRhPersonasPerfilEstatusDetail;
        }


        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmRhPersonasPerfilEstatusDetail;
            if (viewModel != null)
            {
                viewModel.llenado(FicLoParameter4, FicLoParameter, FicLoParameter2, FicLoParameter3);
                viewModel.OnAppearing(FicLoParameter);

            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW I//CLASSE

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmRhPersonasPerfilEstatusDetail;
            if (viewModel != null)
            {
                viewModel.OnDisappearing();
            }
        }

    }

}