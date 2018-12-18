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
	public partial class FicViRhCatDomiciliosDetail : ContentPage
	{
        private rh_cat_personas FicLoParameter;
        private rh_cat_domicilios FicLoParameter2;
        public FicViRhCatDomiciliosDetail()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmRhCatDomiciliosDetail;
        }



        public FicViRhCatDomiciliosDetail(rh_cat_domicilios FicParameter2, rh_cat_personas FicParameter)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            FicLoParameter2 = FicParameter2;
            BindingContext = App.FicVmLocator.FicVmRhCatDomiciliosDetail;
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatDomiciliosDetail;
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