using System;
using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.ViewModels.Base;
using System.Windows.Input;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Interfaces.BecCatClientes;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FicAppPersonas.ViewModels.BecCatClientes
{
    public class FicVmBecCatClientesDetail : FicViewModelBase
    {
        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        private IFicSrvBecCatClientesDetail FicLoSrvApp;
        public ObservableCollection<rh_cat_grupos> _Picker_ItemSource_CatGeneralesDirWeb;
        public bec_cat_clientes _Edificios;
        public bec_cat_clientes Edificio
        {
            get { return _Edificios; }
            set
            {
                _Edificios = value;
                RaisePropertyChanged();
            }
        }
        public rh_cat_personas _Persona;
        public rh_cat_personas Persona
        {
            get { return _Persona; }
            set
            {
                _Persona = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<rh_cat_grupos> Picker_ItemSource_CatGenDirWeb
        {
            get
            {
                return _Picker_ItemSource_CatGeneralesDirWeb;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER INSTITUTOS DE LA VIEW


        public rh_cat_grupos _SfDataGrid_SelectItem_GeneralesDir;
        public rh_cat_grupos FicSfDataGrid_SelectItem_CatGenDirWeb
        {
            get { return _SfDataGrid_SelectItem_GeneralesDir; }
            set
            {
                _SfDataGrid_SelectItem_GeneralesDir = value;
                RaisePropertyChanged();
            }
        }
        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand { get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); } }
        private void FicMetCatClienteExecute() { FicLoSrvNavigation.FicMetNavigateTo<FicVmBecCatClientesList>(Persona); }


        public FicVmBecCatClientesDetail(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvBecCatClientesDetail FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
            _Picker_ItemSource_CatGeneralesDirWeb = new ObservableCollection<rh_cat_grupos>();

        }

        public async override void OnAppearing(object navigationContext)
        {
            try
            {


                var source_local_institutos = await FicLoSrvApp.FicMetGetListRhCatGenerales(1);
                if (source_local_institutos != null)
                {
                    foreach (rh_cat_grupos Dir in source_local_institutos)
                    {
                        if (Edificio.IdGrupo == Dir.IdGrupo)
                        {
                            FicSfDataGrid_SelectItem_CatGenDirWeb = Dir;
                        }
                        _Picker_ItemSource_CatGeneralesDirWeb.Add(Dir);
                    }
                }//LLENAR EL PICKER DE INSTITUTOS
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }
        public void llenado(bec_cat_clientes obj, rh_cat_personas obj2)
        {
            Edificio = new bec_cat_clientes();
            Edificio = obj;
            Persona = new rh_cat_personas();
            Persona = obj2;
        }

    }

}