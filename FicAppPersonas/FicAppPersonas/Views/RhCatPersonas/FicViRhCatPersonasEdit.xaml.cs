using FicAppPersonas.ViewModels.RhCatPersonas;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.RhCatPersonas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViRhCatPersonasEdit : ContentPage
	{
        private rh_cat_personas FicLoParameter;
        public FicViRhCatPersonasEdit()
        {
            InitializeComponent();
            btnPickerImage.Clicked += BtnPickerImage_Clicked;
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasEdit;
        }

        //Plugin para gestion de GALLERY
        //NOTA: Para android es necesario agregar en el MANIFEST los permisos READ_EXTERNAL_STORAGE y WRITE_EXTERNAL_STORAGE
        private async void BtnPickerImage_Clicked(object sender, EventArgs e)
        {
            try
            {
                //los tipos de archivos o fuentes permitidas
                //para mas detalles https://github.com/jfversluis/FilePicker-Plugin-for-Xamarin-and-Windows#async-taskfiledata-pickfilestring-allowedtypes--null
                string[] allowedTypes = { ".jpg", ".png", "image/*" };
                FileData fileData = await CrossFilePicker.Current.PickFile(allowedTypes);
                if (fileData != null)
                {
                    lblRuta.IsEnabled = true;
                    (BindingContext as FicVmRhCatPersonasEdit).Persona.RutaFoto = fileData.FilePath;
                    lblRuta.Text = fileData.FilePath;
                    lblRuta.IsEnabled = false;
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Excepcion seleccionando imagen: " + ex.ToString());
            }

        }

        public FicViRhCatPersonasEdit(rh_cat_personas FicParameter)
        {
            InitializeComponent();
            btnPickerImage.Clicked += BtnPickerImage_Clicked;
            FicLoParameter = FicParameter;
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasEdit;
        }

        public void Handle_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            //(BindingContext as FicVmRhCatPersonasEdit).Persona.Prioridad = Int16.Parse(e.Value.ToString());
        }

        private void DatePicker_OnDataSelected(object sender, DateChangedEventArgs e)
        {
            var fecha = e.NewDate.ToString();
            (BindingContext as FicVmRhCatPersonasEdit).Persona.FechaNac = DateTime.Parse(fecha);
        }


        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatPersonasEdit;
            if (FicViewModel != null)
            {
                FicViewModel.llenado(FicLoParameter);
                FicViewModel.OnAppearing();

            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW I//CLASSE



        protected void FicMetNavigateBack(object sender, EventArgs e)
        {

            Application.Current.MainPage = new NavigationPage();
        }

    }
}