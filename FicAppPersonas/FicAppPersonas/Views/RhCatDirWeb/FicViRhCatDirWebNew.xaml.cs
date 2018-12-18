using FicAppPersonas.ViewModels.RhCatDirWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.RhCatDirWeb
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViRhCatDirWebNew : ContentPage
	{
        private rh_cat_personas FicLoParameter;

        public FicViRhCatDirWebNew()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmRhCatDirWebNew;
        }
        

        public FicViRhCatDirWebNew(rh_cat_personas FicParameter)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            BindingContext = App.FicVmLocator.FicVmRhCatDirWebNew;
        }

        

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatDirWebNew;
            if (FicViewModel != null)
            {
                FicViewModel.getPersonaData(FicLoParameter);
                FicViewModel.OnAppearing();
            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW I//CLASSE



        protected void FicMetNavigateBack(object sender, EventArgs e)
        {

            Application.Current.MainPage = new NavigationPage();
        }

    }
}