using FicAppPersonas.ViewModels.RhCatDirWeb;
using FicAppPersonas.ViewModels.RhCatTelefonos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.RhCatTelefonos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViRhCatTelefonosDetail : ContentPage
    {
        //private object FicLoParameter;
        private rh_cat_telefonos telefono;
        private rh_cat_personas FicLoParameter2;
        public FicViRhCatTelefonosDetail()
        {
            InitializeComponent();
           BindingContext = App.FicVmLocator.FicVmRhCatTelefonosDetail;
        }

        //Plugin para gestion de GALLERY
        //NOTA: Para android es necesario agregar en el MANIFEST los permisos READ_EXTERNAL_STORAGE y WRITE_EXTERNAL_STORAGE


        public FicViRhCatTelefonosDetail(rh_cat_telefonos tel)
        {
            InitializeComponent();
            telefono = tel;
            BindingContext = App.FicVmLocator.FicVmRhCatTelefonosDetail;
        }
        public FicViRhCatTelefonosDetail(rh_cat_telefonos FicParameter, rh_cat_personas FicParameter2)
        {
            InitializeComponent();
            telefono = FicParameter;
            FicLoParameter2 = FicParameter2;
            //Prior.Value = (FicParameter as eva_cat_edificios).Prioridad;
            BindingContext = App.FicVmLocator.FicVmRhCatTelefonosDetail;
        }

        public void Handle_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            //(BindingContext as FicVmRhCatPersonasNew).Persona.Prioridad = Int16.Parse(e.Value.ToString());
        }

        private void DatePicker_OnDataSelected(object sender, DateChangedEventArgs e)
        {
            var fecha = e.NewDate.ToString();
            //(BindingContext as FicVmRhCatDirWebDetail).Persona.FechaNac = DateTime.Parse(fecha);
        }


        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatTelefonosDetail;
            if (FicViewModel != null)
            {
                FicViewModel.getTelefonoData(telefono, FicLoParameter2);
                FicViewModel.OnAppearing();
            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW I//CLASSE



        protected void FicMetNavigateBack(object sender, EventArgs e)
        {

            Application.Current.MainPage = new NavigationPage();
        }

    }
}