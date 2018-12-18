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
	public partial class FicViRhCatAlumnosUpdate : ContentPage
	{
        private rh_cat_alumnos FicLoParameter;
        private rh_cat_personas FicLoParameter2;
        public FicViRhCatAlumnosUpdate()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmRhCatAlumnosUpdate;
        }
        public FicViRhCatAlumnosUpdate(rh_cat_alumnos FicParameter)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            //Prior.Value = (FicParameter as eva_cat_edificios).Prioridad;
            BindingContext = App.FicVmLocator.FicVmRhCatAlumnosUpdate;
        }
        public FicViRhCatAlumnosUpdate(rh_cat_alumnos FicParameter,rh_cat_personas FicParameter2)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            FicLoParameter2 = FicParameter2;
            //Prior.Value = (FicParameter as eva_cat_edificios).Prioridad;
            BindingContext = App.FicVmLocator.FicVmRhCatAlumnosUpdate;
        }

        public void Handle_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            //(BindingContext as FicVmCatEdificiosUpdate).Edificio.Prioridad = Int16.Parse(e.Value.ToString());
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmRhCatAlumnosUpdate;
            if (viewModel != null)
            {
                viewModel.llenado(FicLoParameter, FicLoParameter2);
                viewModel.OnAppearing(FicLoParameter);

            }
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmRhCatAlumnosUpdate;
            if (viewModel != null)
            {
                viewModel.OnDisappearing();
            }
        }

    }
}