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

namespace FicAppPersonas.Views.RhCatPersonas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViRhCatPersonasList : ContentPage
    {
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private readonly FicDBContext FicLoDBContext;
        public FicViRhCatPersonasList()
        {
            InitializeComponent();
            FicLoDBContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasList;
        }//CONSTRUCTOR

        public FicViRhCatPersonasList(object FicNavigationContext)
        {
            InitializeComponent();
            FicLoDBContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasList;
        }//CONSTRUCTOR

        //Command="{Binding FicMetDeleteCommand}"
        protected async void FicMetDeleteCommand(object sender, EventArgs e)
        {
           var context = BindingContext as FicVmRhCatPersonasList;
            if (context._SfDataGrid_SelectItem_Persona == null)
            {
                await DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN Persona", "OK");
                return;
            }
            bool conf = await DisplayAlert("Cuidado", "¿Desea eliminar este elemento?", "Sí", "No");
            if (conf)
            {
                await FicMetRemovePersona(context._SfDataGrid_SelectItem_Persona);
                context.FicSfDataGrid_ItemSource_CatPersonas.Remove(context._SfDataGrid_SelectItem_Persona);
            }

           dataGrid.View.Refresh();
        }

        public async Task FicMetRemovePersona(rh_cat_personas item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoDBContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                FicLoDBContext.SaveChanges();
            }
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatPersonasList;
            if (FicViewModel != null)
            {

                FicViewModel.OnAppearing();
            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW I//CLASSE
    }//CLASSE

}//NAMESPACE