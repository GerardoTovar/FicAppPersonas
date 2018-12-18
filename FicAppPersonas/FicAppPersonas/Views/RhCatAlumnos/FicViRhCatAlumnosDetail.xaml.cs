using FicAppPersonas.ViewModels.RhCatAlumnos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.RhCatAlumnos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViRhCatAlumnosDetail : ContentPage
	{
        private rh_cat_alumnos FicLoParameter;
        private rh_cat_personas FicLoParameter2;
        public FicViRhCatAlumnosDetail()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmRhCatAlumnosDetail;
        }

        //Plugin para gestion de GALLERY
        //NOTA: Para android es necesario agregar en el MANIFEST los permisos READ_EXTERNAL_STORAGE y WRITE_EXTERNAL_STORAGE


        public FicViRhCatAlumnosDetail(rh_cat_alumnos FicParameter)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            BindingContext = App.FicVmLocator.FicVmRhCatAlumnosDetail;
        }
        public FicViRhCatAlumnosDetail(rh_cat_alumnos FicParameter, rh_cat_personas FicParameter2)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            FicLoParameter2 = FicParameter2;
            //Prior.Value = (FicParameter as eva_cat_edificios).Prioridad;
            BindingContext = App.FicVmLocator.FicVmRhCatAlumnosDetail;
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
            var FicViewModel = BindingContext as FicVmRhCatAlumnosDetail;
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