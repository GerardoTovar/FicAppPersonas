using FicAppPersonas.ViewModels.RhCatPersonas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.RhCatPersonas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViRhCatPersonasDetail : ContentPage
	{
        private rh_cat_personas persona;
        public FicViRhCatPersonasDetail()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasDetail;
        }

        //Plugin para gestion de GALLERY
        //NOTA: Para android es necesario agregar en el MANIFEST los permisos READ_EXTERNAL_STORAGE y WRITE_EXTERNAL_STORAGE
        

        public FicViRhCatPersonasDetail(rh_cat_personas FicParameter)
        {
            
            InitializeComponent();
            persona = FicParameter;
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasDetail;
            //var a = ImageSource.FromFile(FicParameter.RutaFoto);
            //imagen.Source.BindingContext = a;
            //imagen.Source = ImageSource.FromFile(FicParameter.RutaFoto);

            //Uri path = new Uri(a.ToString());


        }

        public void Handle_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            //(BindingContext as FicVmRhCatPersonasNew).Persona.Prioridad = Int16.Parse(e.Value.ToString());
        }

        private void DatePicker_OnDataSelected(object sender, DateChangedEventArgs e)
        {
            var fecha = e.NewDate.ToString();
            //(BindingContext as FicVmRhCatPersonasDetail).Persona.FechaNac = DateTime.Parse(fecha);
        }


        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatPersonasDetail;
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