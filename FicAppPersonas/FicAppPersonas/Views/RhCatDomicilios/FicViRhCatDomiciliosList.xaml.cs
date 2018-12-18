using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.SQLite;
using FicAppPersonas.ViewModels.RhCatDomicilios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.RhCatDomicilios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViRhCatDomiciliosList : ContentPage
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private  FicDBContext FicLoDBContext;
        private readonly rh_cat_personas persona;
        public FicViRhCatDomiciliosList()
        {
            InitializeComponent();
            FicLoDBContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            BindingContext = App.FicVmLocator.FicVmRhCatDomiciliosList;
        }//CONSTRUCTOR

        public FicViRhCatDomiciliosList(rh_cat_personas FicNavigationContext)
        {
            InitializeComponent();
            persona = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmRhCatDomiciliosList;
        }//CONSTRUCTOR

        //Command="{Binding FicMetDeleteCommand}"
        protected async void FicMetDeleteCommand(object sender, EventArgs e)
        {
            FicLoDBContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            var context = BindingContext as FicVmRhCatDomiciliosList;
            if (context._SfDataGrid_SelectItem_Edificio == null)
            {
                await DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN ITEM", "OK");
                return;
            }
            bool conf = await DisplayAlert("Cuidado", "¿Desea eliminar este elemento?", "Sí", "No");
            if (conf)
            {
                await FicMetRemoveEdificio(context._SfDataGrid_SelectItem_Edificio);
                context.FicSfDataGrid_ItemSource_CatEdificios.Remove(context._SfDataGrid_SelectItem_Edificio);
            }

            dataGrid.View.Refresh();
        }

        public async Task FicMetRemoveEdificio(rh_cat_domicilios item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoDBContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                FicLoDBContext.SaveChanges();
            }
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatDomiciliosList;
            if (FicViewModel != null)
            {
                FicViewModel.llenado(persona);
                FicViewModel.OnAppearing();
            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW I//CLASSE
    }//CLASSE

}//NAMESPACE