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
    public partial class FicViRhPersonasPerfilEstatusNew : ContentPage
    {
        private rh_cat_personas_perfiles FicLoParameter;
        private rh_cat_personas FicLoParameter2;
        private rh_cat_perfiles FicLoParameter3;
        public FicViRhPersonasPerfilEstatusNew()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmRhPersonasPerfilEstatusNew;
        }


        public FicViRhPersonasPerfilEstatusNew(rh_cat_personas_perfiles FicParameter, rh_cat_personas FicParameter2, rh_cat_perfiles FicParameter3)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            FicLoParameter2 = FicParameter2;
            FicLoParameter3 = FicParameter3;
            BindingContext = App.FicVmLocator.FicVmRhPersonasPerfilEstatusNew;
        }

        public void Handle_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            //(BindingContext as FicVmRhCatPersonasNew).Edificio.Prioridad = Int16.Parse(e.Value.ToString());
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmRhPersonasPerfilEstatusNew;
            if (viewModel != null)
            {
                viewModel.llenado(FicLoParameter, FicLoParameter2, FicLoParameter3);
                viewModel.OnAppearing(FicLoParameter);
            }

        }

        private void DatePicker_OnDataSelected(object sender, DateChangedEventArgs e)
        {
            var fecha = e.NewDate.ToString();
            (BindingContext as FicVmRhPersonasPerfilEstatusNew).Edificio.FechaEstatus = DateTime.Parse(fecha);
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmRhPersonasPerfilEstatusNew;
            if (viewModel != null) viewModel.OnDisappearing();
        }
        protected void FicMetNavigateBack(object sender, EventArgs e)
        {

            Application.Current.MainPage = new NavigationPage();
        }

    }
}