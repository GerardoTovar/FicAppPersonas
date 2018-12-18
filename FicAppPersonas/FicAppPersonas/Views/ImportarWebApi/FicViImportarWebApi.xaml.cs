﻿using FicAppPersonas.ViewModels.ImportarWebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FicAppPersonas.Views.ImportarWebApi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViImportarWebApi : ContentPage
    {
        public FicViImportarWebApi()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmImportarWebApi;
        }//CONSTRUCTOR

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmImportarWebApi;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing();
            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW

    }//CLASS
}//NAMESPACE