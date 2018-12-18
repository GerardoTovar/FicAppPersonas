using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FicAppPersonas.ViewModels.RhCatPersonasDatosAdicionales;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.RhCatPersonasDatosAdicionales
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViRhCatPersonasDatosAdicionalesDetail : ContentPage
    {

        private rh_cat_personas_datos_adicionales FicLoParameter;
        private rh_cat_personas FicLoParameter2;
        public FicViRhCatPersonasDatosAdicionalesDetail()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasDatosAdicionalesDetail;
        }



        public FicViRhCatPersonasDatosAdicionalesDetail(rh_cat_personas_datos_adicionales FicParameter)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasNew;
        }

        public FicViRhCatPersonasDatosAdicionalesDetail(rh_cat_personas_datos_adicionales FicParameter, rh_cat_personas FicParameter2)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            FicLoParameter2 = FicParameter2;
            //Prior.Value = (FicParameter as eva_cat_edificios).Prioridad;
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasDatosAdicionalesDetail;
        }


        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmRhCatPersonasDatosAdicionalesDetail;
            if (viewModel != null)
            {
                viewModel.llenado(FicLoParameter, FicLoParameter2);
                viewModel.OnAppearing(FicLoParameter);

            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW I//CLASSE

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmRhCatPersonasDatosAdicionalesDetail;
            if (viewModel != null)
            {
                viewModel.OnDisappearing();
            }
        }


    }

}