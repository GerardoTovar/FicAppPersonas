using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FicAppPersonas.ViewModels.RhCatCatedraticos;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.RhCatCatedraticos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViRhCatCatedraticosDetail : ContentPage
    {
        private rh_cat_catedraticos FicLoParameter;
        private rh_cat_personas FicLoParameter2;
        public FicViRhCatCatedraticosDetail()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmRhCatCatedraticosDetail;
        }



        public FicViRhCatCatedraticosDetail(rh_cat_catedraticos FicParameter)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            BindingContext = App.FicVmLocator.FicVmRhCatCatedraticosDetail;
        }
        public FicViRhCatCatedraticosDetail(rh_cat_catedraticos FicParameter, rh_cat_personas FicParameter2)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            FicLoParameter2 = FicParameter2;
            //Prior.Value = (FicParameter as eva_cat_edificios).Prioridad;
            BindingContext = App.FicVmLocator.FicVmRhCatCatedraticosDetail;
        }


        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmRhCatCatedraticosDetail;
            if (viewModel != null)
            {
                viewModel.llenado(FicLoParameter, FicLoParameter2);
                viewModel.OnAppearing(FicLoParameter);

            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW I//CLASSE

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmRhCatCatedraticosDetail;
            if (viewModel != null)
            {
                viewModel.OnDisappearing();
            }
        }

    }

}