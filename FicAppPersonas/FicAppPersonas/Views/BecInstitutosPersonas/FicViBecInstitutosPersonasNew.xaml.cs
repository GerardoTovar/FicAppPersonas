using FicAppPersonas.ViewModels.BecInstitutosPersonas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.BecInstitutosPersonas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViBecInstitutosPersonasNew : ContentPage
	{
        private rh_cat_personas FicLoParameter;
        public FicViBecInstitutosPersonasNew()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmBecInstitutosPersonasNew;
        }



        public FicViBecInstitutosPersonasNew(rh_cat_personas FicParameter)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            BindingContext = App.FicVmLocator.FicVmBecInstitutosPersonasNew;
        }


        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmBecInstitutosPersonasNew;
            if (FicViewModel != null)
            {
                FicViewModel.llenado(FicLoParameter);
                FicViewModel.OnAppearing();
            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW I//CLASSE



        protected void FicMetNavigateBack(object sender, EventArgs e)
        {

            Application.Current.MainPage = new NavigationPage();
        }

    }
}