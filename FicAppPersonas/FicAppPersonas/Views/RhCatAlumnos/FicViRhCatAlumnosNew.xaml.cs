using FicAppPersonas.ViewModels.RhCatAlumnos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.RhCatAlumnos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViRhCatAlumnosNew : ContentPage
	{
        private rh_cat_personas FicLoParameter;
        //private rh_cat_personas FicLoParameter2;
        public FicViRhCatAlumnosNew()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmRhCatAlumnosNew;
        }


        public FicViRhCatAlumnosNew(rh_cat_personas FicParameter)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            BindingContext = App.FicVmLocator.FicVmRhCatAlumnosNew;
        }

        public void Handle_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            //(BindingContext as FicVmRhCatPersonasNew).Edificio.Prioridad = Int16.Parse(e.Value.ToString());
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmRhCatAlumnosNew;
            if (viewModel != null)
            {
                viewModel.OnAppearing(FicLoParameter);
                viewModel.llenado(FicLoParameter);
            }

        }


        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmRhCatAlumnosNew;
            if (viewModel != null) viewModel.OnDisappearing();
        }
        protected void FicMetNavigateBack(object sender, EventArgs e)
        {

            Application.Current.MainPage = new NavigationPage();
        }

    }
}