using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FicAppPersonas.ViewModels.RhCatPersonas;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;

namespace FicAppPersonas.Views.RhCatPersonas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViRhCatPersonasNew : ContentPage
	{
        private object FicLoParameter;
        public FicViRhCatPersonasNew()
		{
            InitializeComponent();
            btnPickerImage.Clicked += BtnPickerImage_Clicked;
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasNew;
        }

        //Plugin para gestion de GALLERY
        //NOTA: Para android es necesario agregar en el MANIFEST los permisos READ_EXTERNAL_STORAGE y WRITE_EXTERNAL_STORAGE
        private async void BtnPickerImage_Clicked(object sender, EventArgs e) {
            try
            {
                //los tipos de archivos o fuentes permitidas
                //para mas detalles https://github.com/jfversluis/FilePicker-Plugin-for-Xamarin-and-Windows#async-taskfiledata-pickfilestring-allowedtypes--null
                string[] allowedTypes = { ".jpg", ".png", "image/*" };
                FileData fileData = await CrossFilePicker.Current.PickFile(allowedTypes);                
                if (fileData != null)
                {
                    lblRuta.IsEnabled = true;
                    (BindingContext as FicVmRhCatPersonasNew).Persona.RutaFoto = fileData.FilePath;
                    lblRuta.Text = fileData.FilePath;
                    lblRuta.IsEnabled = false;
                }
                else {
                    return;
                }
            }
            catch (Exception ex) {
                System.Console.WriteLine("Excepcion seleccionando imagen: " + ex.ToString());
            }
            
        }

        public FicViRhCatPersonasNew(object FicParameter)
        {
            InitializeComponent();
            btnPickerImage.Clicked += BtnPickerImage_Clicked;
            FicLoParameter = FicParameter;
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasNew;
        }

        public void Handle_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            //(BindingContext as FicVmRhCatPersonasNew).Persona.Prioridad = Int16.Parse(e.Value.ToString());
        }

        private void DatePicker_OnDataSelected(object sender, DateChangedEventArgs e)
        {
            var fecha = e.NewDate.ToString();
            (BindingContext as FicVmRhCatPersonasNew).Persona.FechaNac = DateTime.Parse(fecha);            
        }


        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatPersonasNew;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing();
            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW I//CLASSE



        protected void FicMetNavigateBack(object sender, EventArgs e)
        {

            Application.Current.MainPage = new NavigationPage();
        }

    }
}