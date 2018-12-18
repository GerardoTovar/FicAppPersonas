using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FicAppPersonas.ViewModels.BecCatClientes;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.BecCatClientes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViBecCatClientesDetail : ContentPage
    {
        private bec_cat_clientes FicLoParameter;
        private rh_cat_personas FicLoParameter2;
        public FicViBecCatClientesDetail()
        {
            InitializeComponent();

            BindingContext = App.FicVmLocator.FicVmBecCatClientesDetail;
        }



        public FicViBecCatClientesDetail(bec_cat_clientes FicParameter)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            BindingContext = App.FicVmLocator.FicVmBecCatClientesDetail;
        }
        public FicViBecCatClientesDetail(bec_cat_clientes FicParameter, rh_cat_personas FicParameter2)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            FicLoParameter2 = FicParameter2;
            //Prior.Value = (FicParameter as eva_cat_edificios).Prioridad;
            BindingContext = App.FicVmLocator.FicVmBecCatClientesDetail;
        }


        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmBecCatClientesDetail;
            if (viewModel != null)
            {
                viewModel.llenado(FicLoParameter, FicLoParameter2);
                viewModel.OnAppearing(FicLoParameter);

            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW I//CLASSE

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmBecCatClientesDetail;
            if (viewModel != null)
            {
                viewModel.OnDisappearing();
            }
        }

    }

}