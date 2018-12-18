using FicAppPersonas.Data;
using FicAppPersonas.Helpers;
using FicAppPersonas.Interfaces.SQLite;
using FicAppPersonas.ViewModels.BecInstitutosPersonas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Views.BecInstitutosPersonas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViBecInstitutosPersonasList : ContentPage
	{

        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private  FicDBContext FicLoDBContext;
        private readonly rh_cat_personas persona;
        public FicViBecInstitutosPersonasList()
        {
            InitializeComponent();
            FicLoDBContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            BindingContext = App.FicVmLocator.FicVmBecInstitutosPersonasList;
        }//CONSTRUCTOR

        public FicViBecInstitutosPersonasList(rh_cat_personas FicNavigationContext)
        {
            InitializeComponent();
            persona = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmBecInstitutosPersonasList;
        }//CONSTRUCTOR

        //Command="{Binding FicMetDeleteCommand}"
        protected async void FicMetDeleteCommand(object sender, EventArgs e)
        {
            FicLoDBContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            var context = BindingContext as FicVmBecInstitutosPersonasList;
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
                context.FicSfDataGrid_ItemSource_CatEdificios2.Remove(context._SfDataGrid_SelectItem_Edificio2);
            }

            dataGrid.View.Refresh();
        }

        public async Task FicMetRemoveEdificio(bec_institutos_personas item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoDBContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                FicLoDBContext.SaveChanges();
            }
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmBecInstitutosPersonasList;
            if (FicViewModel != null)
            {
                FicViewModel.llenado(persona);
                FicViewModel.OnAppearing();
            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW I//CLASSE
    }//CLASSE

}//NAMESPACE