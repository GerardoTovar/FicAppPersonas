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
	public partial class FicViBecInstitutosPersonasUpdate : ContentPage
	{
        private rh_cat_personas FicLoParameter;
        private bec_institutos_personas FicLoParameter2;
        public FicViBecInstitutosPersonasUpdate()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmBecInstitutosPersonasUpdate;
        }

        public FicViBecInstitutosPersonasUpdate(bec_institutos_personas FicParameter2, rh_cat_personas FicParameter)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            FicLoParameter2 = FicParameter2;
            BindingContext = App.FicVmLocator.FicVmBecInstitutosPersonasUpdate;
        }
        


        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmBecInstitutosPersonasUpdate;
            if (FicViewModel != null)
            {

                    FicViewModel.llenado(FicLoParameter2, FicLoParameter);
                    FicViewModel.OnAppearing();
            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW I//CLASSE



        protected void FicMetNavigateBack(object sender, EventArgs e)
        {

            Application.Current.MainPage = new NavigationPage();
        }

    }
}