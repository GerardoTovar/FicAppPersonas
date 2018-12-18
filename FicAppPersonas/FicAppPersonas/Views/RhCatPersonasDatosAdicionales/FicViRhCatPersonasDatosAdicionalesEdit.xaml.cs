﻿using System;
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
    public partial class FicViRhCatPersonasDatosAdicionalesEdit : ContentPage
    {

        private rh_cat_personas_datos_adicionales FicLoParameter;
        private rh_cat_personas FicLoParameter2;
        public FicViRhCatPersonasDatosAdicionalesEdit()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasDatosAdicionalesEdit;
        }


        public FicViRhCatPersonasDatosAdicionalesEdit(rh_cat_personas_datos_adicionales FicParameter)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasDatosAdicionalesEdit;
        }
        public FicViRhCatPersonasDatosAdicionalesEdit(rh_cat_personas_datos_adicionales FicParameter, rh_cat_personas FicParameter2)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            FicLoParameter2 = FicParameter2;
            //Prior.Value = (FicParameter as eva_cat_edificios).Prioridad;
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasDatosAdicionalesEdit;
        }

        public void Handle_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            //(BindingContext as FicVmRhCatPersonasNew).Edificio.Prioridad = Int16.Parse(e.Value.ToString());
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmRhCatPersonasDatosAdicionalesEdit;
            if (viewModel != null)
            {
                viewModel.llenado(FicLoParameter, FicLoParameter2);
                viewModel.OnAppearing(FicLoParameter);
            }

        }


        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmRhCatPersonasDatosAdicionalesEdit;
            if (viewModel != null) viewModel.OnDisappearing();
        }
        protected void FicMetNavigateBack(object sender, EventArgs e)
        {

            Application.Current.MainPage = new NavigationPage();
        }

    }
}




