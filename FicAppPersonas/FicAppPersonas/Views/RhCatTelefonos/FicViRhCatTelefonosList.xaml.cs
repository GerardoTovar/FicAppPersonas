using FicAppPersonas.ViewModels.RhCatTelefonos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FicAppPersonas.Helpers;
using FicAppPersonas.Views.RhCatTelefonos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FicAppPersonas.Data;
using FicAppPersonas.Interfaces.SQLite;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.RhCatTelefonos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViRhCatTelefonosList : ContentPage
    {

        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private readonly FicDBContext FicLoDBContext;
        private readonly rh_cat_personas persona;
        public FicViRhCatTelefonosList()
        {
            InitializeComponent();
            FicLoDBContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            BindingContext = App.FicVmLocator.FicVmRhCatTelefonosList;
        }//CONSTRUCTOR

        public FicViRhCatTelefonosList(rh_cat_personas per)
        {
            InitializeComponent();
            //(BindingContext as FicVmRhCatTelefonosList).Edificio.IdPersona = per.IdPersona;
            FicLoDBContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            persona = per;
            BindingContext = App.FicVmLocator.FicVmRhCatTelefonosList;
        }//CONSTRUCTOR

        //Command="{Binding FicMetDeleteCommand}"
        protected async void FicMetDeleteCommand(object sender, EventArgs e)
        {
            var context = BindingContext as FicVmRhCatTelefonosList;
            if (context._SfDataGrid_SelectItem_Telefono == null)
            {
                await DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN ITEM", "OK");
                return;
            }
            bool conf = await DisplayAlert("Cuidado", "¿Desea eliminar este elemento?", "Sí", "No");
            if (conf)
            {
                await FicMetRemoveTelefono(context._SfDataGrid_SelectItem_Telefono);
                context._FicSfDataGrid_ItemSource_Telefonos.Remove(context._SfDataGrid_SelectItem_Telefono);
            }

            dataGrid.View.Refresh();
        }

        public async Task FicMetRemoveTelefono(rh_cat_telefonos item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoDBContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                FicLoDBContext.SaveChanges();
            }
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatTelefonosList;
            if (FicViewModel != null)
            {
                FicViewModel.getTelefonoData(persona);
                FicViewModel.OnAppearing();
            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW I//CLASSE
    }//CLASSE

}//NAMESPACE