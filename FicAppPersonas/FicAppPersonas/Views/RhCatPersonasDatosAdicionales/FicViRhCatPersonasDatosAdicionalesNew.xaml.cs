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
    public partial class FicViRhCatPersonasDatosAdicionalesNew : ContentPage
    {
        private rh_cat_personas FicLoParameter;
        public FicViRhCatPersonasDatosAdicionalesNew()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasDatosAdicionalesNew;
        }

        public FicViRhCatPersonasDatosAdicionalesNew(rh_cat_personas FicParameter)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasDatosAdicionalesNew;
        }

        public void Handle_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            //(BindingContext as FicVmRhCatPersonasNew).Edificio.Prioridad = Int16.Parse(e.Value.ToString());
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmRhCatPersonasDatosAdicionalesNew;
            if (viewModel != null)
            {
                viewModel.getPersonaData(FicLoParameter);
                viewModel.OnAppearing(FicLoParameter);
            }

        }


        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmRhCatPersonasDatosAdicionalesNew;
            if (viewModel != null) viewModel.OnDisappearing();
        }
        protected void FicMetNavigateBack(object sender, EventArgs e)
        {

            Application.Current.MainPage = new NavigationPage();
        }

    }
}