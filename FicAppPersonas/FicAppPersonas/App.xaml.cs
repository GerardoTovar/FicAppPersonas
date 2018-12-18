using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FicAppPersonas.Views;
using FicAppPersonas.Views.RhCatPersonas;
using FicAppPersonas.ViewModels.Base;
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FicAppPersonas
{
    public partial class App : Application
    {
        private static FicViewModelLocator FicLocalVmLocator;

        public static FicViewModelLocator FicVmLocator {
            get
            {
                return FicLocalVmLocator = FicLocalVmLocator ?? new FicViewModelLocator();
            }
        }

        public App()
        {
            InitializeComponent();
            //MANDAMOS NUESTRO MAESTRO DETALLE COMO NUESTRO MAIN PAGE
            MainPage = new Views.Navegacion.FicMasterPage();
            
        }
       
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
