using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FicAppPersonas.ViewModels.RhCatTelefonos;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.RhCatTelefonos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViRhCatTelefonosNew : ContentPage
    {
        //private object FicLoParameter;
        private rh_cat_personas persona;
        public FicViRhCatTelefonosNew()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmRhCatTelefonosNew;
        }


        public FicViRhCatTelefonosNew(rh_cat_personas FicParameter)
        {
            InitializeComponent();
            persona = FicParameter;
            BindingContext = App.FicVmLocator.FicVmRhCatTelefonosNew;
        }

        public void Handle_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
             //(BindingContext as FicVmRhCatPersonasNew).Edificio.Prioridad = Int16.Parse(e.Value.ToString());
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmRhCatTelefonosNew;
            if (viewModel != null)
            {
                viewModel.getPersonaData(persona);
                viewModel.OnAppearing();
            }

        }


        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmRhCatTelefonosNew;
            //if (viewModel != null) viewModel.OnDisappearing();
        }
        protected void FicMetNavigateBack(object sender, EventArgs e)
        {

            Application.Current.MainPage = new NavigationPage();
        }

    }
}