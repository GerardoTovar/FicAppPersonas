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
    public partial class FicViBecCatClientesEdit : ContentPage
    {
        private bec_cat_clientes FicLoParameter;
        private rh_cat_personas FicLoParameter2;
        public FicViBecCatClientesEdit()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmBecCatClientesEdit;
        }

        public FicViBecCatClientesEdit(bec_cat_clientes FicParameter, rh_cat_personas FicParameter2)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            FicLoParameter2 = FicParameter2;
            //Prior.Value = (FicParameter as eva_cat_edificios).Prioridad;
            BindingContext = App.FicVmLocator.FicVmBecCatClientesEdit;
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
            var viewModel = BindingContext as FicVmBecCatClientesEdit;
            if (viewModel != null)
            {
                viewModel.llenado(FicLoParameter, FicLoParameter2);
                viewModel.OnAppearing(FicLoParameter);
            }

        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmBecCatClientesEdit;
            if (viewModel != null) viewModel.OnDisappearing();
        }
        protected void FicMetNavigateBack(object sender, EventArgs e)
        {

            Application.Current.MainPage = new NavigationPage();
        }

    }
}