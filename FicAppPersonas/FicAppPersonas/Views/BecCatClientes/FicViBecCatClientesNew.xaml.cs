using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FicAppPersonas.ViewModels.BecCatClientes;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.BecCatClientes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViBecCatClientesNew : ContentPage
    {
        private rh_cat_personas FicLoParameter;
        public FicViBecCatClientesNew()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmBecCatClientesNew;
        }

        public FicViBecCatClientesNew(rh_cat_personas FicParameter)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            BindingContext = App.FicVmLocator.FicVmBecCatClientesNew;
        }

        public void Handle_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            //(BindingContext as FicVmRhCatPersonasNew).Edificio.Prioridad = Int16.Parse(e.Value.ToString());
        }

        private void DatePicker_OnDataSelected(object sender, DateChangedEventArgs e)
        {


            (BindingContext as FicVmBecCatClientesNew).Edificio.FechaAlta = DateTime.Parse(e.NewDate.ToString());
        }



        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmBecCatClientesNew;
            if (viewModel != null)
            {
                viewModel.getPersonaData(FicLoParameter);
                viewModel.OnAppearing(FicLoParameter);
            }

        }


        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmBecCatClientesNew;
            if (viewModel != null) viewModel.OnDisappearing();
        }
        protected void FicMetNavigateBack(object sender, EventArgs e)
        {

            Application.Current.MainPage = new NavigationPage();
        }

    }
}
