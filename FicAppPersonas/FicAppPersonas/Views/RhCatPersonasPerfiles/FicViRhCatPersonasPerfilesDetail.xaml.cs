using FicAppPersonas.ViewModels.RhCatPersonasPerfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.RhCatPersonasPerfiles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViRhCatPersonasPerfilesDetail : ContentPage
	{
        private rh_cat_personas_perfiles FicLoParameter;
        private rh_cat_personas FicLoParameter2;
        public FicViRhCatPersonasPerfilesDetail()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasPerfilesDetail;
        }

        //Plugin para gestion de GALLERY
        //NOTA: Para android es necesario agregar en el MANIFEST los permisos READ_EXTERNAL_STORAGE y WRITE_EXTERNAL_STORAGE

        public FicViRhCatPersonasPerfilesDetail(rh_cat_personas_perfiles FicParameter, rh_cat_personas FicParameter2)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            FicLoParameter2 = FicParameter2;
            //Prior.Value = (FicParameter as eva_cat_edificios).Prioridad;
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasPerfilesDetail;
        }

        public void Handle_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            //(BindingContext as FicVmRhCatPersonasNew).Persona.Prioridad = Int16.Parse(e.Value.ToString());
        }

        private void DatePicker_OnDataSelected(object sender, DateChangedEventArgs e)
        {
            //var fecha = e.NewDate.ToString();
            //(BindingContext as FicVmRhCatDirWebDetail).Persona.FechaNac = DateTime.Parse(fecha);
        }


        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatPersonasPerfilesDetail;
            if (FicViewModel != null)
            {
                FicViewModel.llenado(FicLoParameter, FicLoParameter2);
                FicViewModel.OnAppearing(FicLoParameter);
            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW I//CLASSE



        protected void FicMetNavigateBack(object sender, EventArgs e)
        {

            Application.Current.MainPage = new NavigationPage();
        }

    }
}