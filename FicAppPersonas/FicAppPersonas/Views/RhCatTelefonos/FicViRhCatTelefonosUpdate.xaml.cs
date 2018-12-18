using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FicAppPersonas.ViewModels.RhCatTelefonos;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.RhCatTelefonos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViRhCatTelefonosUpdate : ContentPage
    {
        private rh_cat_telefonos FicLoParameter;
        private rh_cat_personas FicLoParameter2;
        public FicViRhCatTelefonosUpdate()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmRhCatTelefonosUpdate;
        }
        public FicViRhCatTelefonosUpdate(rh_cat_telefonos FicParameter)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            //Prior.Value = (FicParameter as eva_cat_edificios).Prioridad;
            BindingContext = App.FicVmLocator.FicVmRhCatTelefonosUpdate;
        }
        public FicViRhCatTelefonosUpdate(rh_cat_telefonos FicParameter, rh_cat_personas FicParameter2)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            FicLoParameter2 = FicParameter2;
            //Prior.Value = (FicParameter as eva_cat_edificios).Prioridad;
            BindingContext = App.FicVmLocator.FicVmRhCatTelefonosUpdate;
        }


        public void Handle_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            //(BindingContext as FicVmCatEdificiosUpdate).Edificio.Prioridad = Int16.Parse(e.Value.ToString());
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmRhCatTelefonosUpdate;
            if (viewModel != null)
            {
                viewModel.llenado(FicLoParameter, FicLoParameter2);
                viewModel.OnAppearing(FicLoParameter);

            }
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmRhCatTelefonosUpdate;
            if (viewModel != null)
            {
                viewModel.OnDisappearing();
            }
        }

    }
}