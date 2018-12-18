using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.SQLite;
using FicAppPersonas.ViewModels.RhCatDirWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.RhCatDirWeb
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViRhCatDirWebList : ContentPage
	{
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private readonly FicDBContext FicLoDBContext;
        private readonly rh_cat_personas persona;
        public FicViRhCatDirWebList()
        {
            InitializeComponent();
            FicLoDBContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            BindingContext = App.FicVmLocator.FicVmRhCatDirWebList;
        }//CONSTRUCTOR

        public FicViRhCatDirWebList(rh_cat_personas per)
        {
            InitializeComponent();
            //(BindingContext as FicVmRhCatTelefonosList).Edificio.IdPersona = per.IdPersona;
            FicLoDBContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            persona = per;
            BindingContext = App.FicVmLocator.FicVmRhCatDirWebList;
        }//CONSTRUCTOR

        //Command="{Binding FicMetDeleteCommand}"
        protected async void FicMetDeleteCommand(object sender, EventArgs e)
        {
            var context = BindingContext as FicVmRhCatDirWebList;
            if (context._SfDataGrid_SelectItem_Telefono == null)
            {
                await DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN Persona", "OK");
                return;
            }
            bool conf = await DisplayAlert("Cuidado", "¿Desea eliminar este elemento?", "Sí", "No");
            if (conf)
            {
                await FicMetRemovePersona(context._SfDataGrid_SelectItem_Telefono);
                context.FicSfDataGrid_ItemSource_Telefonos.Remove(context._SfDataGrid_SelectItem_Telefono);
            }

            dataGrid.View.Refresh();
        }

        public async Task FicMetRemovePersona(rh_cat_dir_web item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoDBContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                FicLoDBContext.SaveChanges();
            }
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatDirWebList;
            if (FicViewModel != null)
            {
                FicViewModel.getTelefonoData(persona);
                FicViewModel.OnAppearing();
            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW I//CLASSE
    }//CLASSE

}//NAMESPACE