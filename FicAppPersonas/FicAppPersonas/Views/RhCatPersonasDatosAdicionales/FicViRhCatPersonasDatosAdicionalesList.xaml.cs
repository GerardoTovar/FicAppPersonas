using FicAppPersonas.ViewModels.RhCatPersonasDatosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FicAppPersonas.Helpers;
using FicAppPersonas.Views.RhCatPersonasDatosAdicionales;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FicAppPersonas.Data;
using FicAppPersonas.Interfaces.SQLite;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.RhCatPersonasDatosAdicionales
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViRhCatPersonasDatosAdicionalesList : ContentPage
    {

        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private readonly FicDBContext FicLoDBContext;
        private readonly rh_cat_personas persona;
        public FicViRhCatPersonasDatosAdicionalesList()
        {
            InitializeComponent();
            FicLoDBContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasDatosAdicionalesList;
        }//CONSTRUCTOR

        public FicViRhCatPersonasDatosAdicionalesList(rh_cat_personas per)
        {
            InitializeComponent();
            //(BindingContext as FicVmRhCatTelefonosList).Edificio.IdPersona = per.IdPersona;
            FicLoDBContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            persona = per;
            BindingContext = App.FicVmLocator.FicVmRhCatPersonasDatosAdicionalesList;
        }//CONSTRUCTOR

        //Command="{Binding FicMetDeleteCommand}"
        protected async void FicMetDeleteCommand(object sender, EventArgs e)
        {
            var context = BindingContext as FicVmRhCatPersonasDatosAdicionalesList;
            if (context._SfDataGrid_SelectItem_Edificio == null)
            {
                await DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN EDIFICIO", "OK");
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

        public async Task FicMetRemoveEdificio(rh_cat_personas_datos_adicionales item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoDBContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                FicLoDBContext.SaveChanges();
            }
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatPersonasDatosAdicionalesList;
            if (FicViewModel != null)
            {
                FicViewModel.getTelefonoData(persona);
                FicViewModel.OnAppearing();
            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW I//CLASSE
    }//CLASSE

}//NAMESPACE