﻿using FicAppPersonas.ViewModels.ExportarWebApi;
using FicAppPersonas.Views.ImportarWebApi;
using FicAppPersonas.Views.RhCatPersonas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FicAppPersonas.Views.Navegacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicMasterPage : MasterDetailPage
    {
        public FicMasterPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }//CONSTRUCTOR

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var FicItemMenu = e.SelectedItem as FicMasterPageMenuItem;
                if (FicItemMenu == null)
                    return;

                var FicPagina = FicItemMenu.FicPageName as string;
                switch (FicPagina)
                {
                    case "FicViRhCatPersonasList":
                        FicItemMenu.TargetType = typeof(FicViRhCatPersonasList);
                        break;
                    case "FicViImportarWebApi":
                        FicItemMenu.TargetType = typeof(FicViImportarWebApi);
                        break;
                    case "FicVmExportarWebApi":
                        FicItemMenu.TargetType = typeof(FicVmExportarWebApi);
                        break;
                    //case "FicViExportarWebApi":
                    //    FicItemMenu.TargetType = typeof(FicViExportarWebApi);
                    //    break;
                    default:
                        break;
                }

                object[] FicObjeto = new object[1];
                //FIC: Sin enviar parametro
                var FicPageOpen = (Page)Activator.CreateInstance(FicItemMenu.TargetType);
                //var FicPageOpen = Activator.CreateInstance(typeof(FicViInventarioList)) as Page;

                //FIC: Enviando como parametro un objeto vacio
                FicPageOpen.Title = FicItemMenu.Title;

                Detail = new NavigationPage(FicPageOpen);
                IsPresented = false;
                MasterPage.ListView.SelectedItem = null;
            }
            catch (Exception ex)
            {
                new Page().DisplayAlert("ERROR", ex.Message.ToString(), "OK");
            }
        }//AL SELECCIONAR UN ITEM DE DE LA LISTA

    }//CLASS
}//NAMESPACE