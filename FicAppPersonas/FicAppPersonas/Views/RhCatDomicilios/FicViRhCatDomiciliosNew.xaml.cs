using FicAppPersonas.ViewModels.RhCatDomicilios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.RhCatDomicilios
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViRhCatDomiciliosNew : ContentPage
	{
        private rh_cat_personas persona;

        public FicViRhCatDomiciliosNew()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmRhCatDomiciliosNew;
        }



        public FicViRhCatDomiciliosNew(rh_cat_personas FicParameter)
        {
            InitializeComponent();
            persona = FicParameter;
            BindingContext = App.FicVmLocator.FicVmRhCatDomiciliosNew;
        }


        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatDomiciliosNew;
            if (FicViewModel != null)
            {
                FicViewModel.getPersonaData(persona);
                FicViewModel.OnAppearing();
            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW I//CLASSE



        protected void FicMetNavigateBack(object sender, EventArgs e)
        {

            Application.Current.MainPage = new NavigationPage();
        }

    }
}