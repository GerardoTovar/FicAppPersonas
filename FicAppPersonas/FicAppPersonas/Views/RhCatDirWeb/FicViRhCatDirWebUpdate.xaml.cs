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
	public partial class FicViRhCatDirWebUpdate : ContentPage
	{
        private rh_cat_dir_web FicLoParameter;
        private rh_cat_personas FicLoParameter2;

        public FicViRhCatDirWebUpdate()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmRhCatDirWebUpdate;
        }


        public FicViRhCatDirWebUpdate(rh_cat_dir_web FicParameter)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            BindingContext = App.FicVmLocator.FicVmRhCatDirWebUpdate;
        }
        public FicViRhCatDirWebUpdate(rh_cat_dir_web FicParameter, rh_cat_personas FicParameter2)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            FicLoParameter2 = FicParameter2;
            //Prior.Value = (FicParameter as eva_cat_edificios).Prioridad;
            BindingContext = App.FicVmLocator.FicVmRhCatDirWebUpdate;
        }



        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatDirWebUpdate;
            if (FicViewModel != null)
            {
                FicViewModel.llenado(FicLoParameter, FicLoParameter2);
                FicViewModel.OnAppearing();
            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW I//CLASSE



        protected void FicMetNavigateBack(object sender, EventArgs e)
        {

            Application.Current.MainPage = new NavigationPage();
        }

    }
}