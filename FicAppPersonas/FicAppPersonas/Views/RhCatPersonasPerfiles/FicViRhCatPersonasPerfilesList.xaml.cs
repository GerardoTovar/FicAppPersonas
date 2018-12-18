using FicAppPersonas.ViewModels.RhCatPersonas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FicAppPersonas.Helpers;
using FicAppPersonas.Views.RhCatPersonas;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FicAppPersonas.Data;
using FicAppPersonas.Interfaces.SQLite;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.ViewModels.RhCatPersonasPerfiles;

namespace FicAppPersonas.Views.RhCatPersonasPerfiles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViRhCatPersonasPerfilesList : ContentPage
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private  FicDBContext FicLoDBContext;
        private readonly rh_cat_personas persona;
        public FicViRhCatPersonasPerfilesList()
        {
            InitializeComponent();
            FicLoDBContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasPerfilesList;
        }//CONSTRUCTOR

        public FicViRhCatPersonasPerfilesList(rh_cat_personas per)
        {
            InitializeComponent();
            persona = per;
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasPerfilesList;
        }//CONSTRUCTOR

        //Command="{Binding FicMetDeleteCommand}"
        protected async void FicMetDeleteCommand(object sender, EventArgs e)
        {
            FicLoDBContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            var context = BindingContext as FicVmRhCatPersonasPerfilesList;
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

        public async Task FicMetRemoveEdificio(rh_cat_personas_perfiles item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoDBContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                FicLoDBContext.SaveChanges();
            }
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatPersonasPerfilesList;
            FicViewModel._FicSfDataGrid_ItemSource_CatEdificios.Clear();
            if (FicViewModel != null)
            {
                FicViewModel.getPersonaData(persona);
                FicViewModel.OnAppearing();
            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW I//CLASSE
    }//CLASSE

}//NAMESPACE