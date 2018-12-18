using FicAppPersonas.Interfaces.BecInstitutosPersonas;
using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.ViewModels.Base;
using System;
using System.Collections.ObjectModel;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.ViewModels.BecInstitutosPersonas
{
   public class FicVmBecInstitutosPersonasDetail : FicViewModelBase
    {

        private IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas;
        private IFicSrvBecInstitutosPersonasDetail IFicSrvBecInstitutosPersonasDetail;

        private rh_cat_personas _Personas;
        public rh_cat_personas Persona
        {
            get { return _Personas; }
            set
            {
                _Personas = value;
                RaisePropertyChanged();
            }
        }
        private bec_institutos_personas _Edificio;
        public bec_institutos_personas Edificio
        {
            get { return _Edificio; }
            set
            {
                _Edificio = value;
                RaisePropertyChanged();
            }
        }

        public rh_cat_perfiles _SfDataGrid_SelectItem_Perfil;
        public rh_cat_perfiles FicSfDataGrid_SelectItem_CatPerfil
        {
            get { return _SfDataGrid_SelectItem_Perfil; }
            set
            {
                _SfDataGrid_SelectItem_Perfil = value;
                RaisePropertyChanged();
            }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL PICKER OCUPACION DE LA VIEW

        public cat_institutos _SfDataGrid_SelectItem_Instituto;
        public cat_institutos FicSfDataGrid_SelectItem_CatInstituto
        {
            get { return _SfDataGrid_SelectItem_Instituto; }
            set
            {
                _SfDataGrid_SelectItem_Instituto = value;
                RaisePropertyChanged();
            }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL PICKER INSTITUTOS DE LA VIEW

        public FicVmBecInstitutosPersonasDetail(IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas, IFicSrvBecInstitutosPersonasDetail IFicSrvBecInstitutosPersonasDetail)
        {
            this.IFicSrvNavigationRhCatPersonas = IFicSrvNavigationRhCatPersonas;
            this.IFicSrvBecInstitutosPersonasDetail = IFicSrvBecInstitutosPersonasDetail;
        }

        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand { get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); } }
        private void FicMetCatClienteExecute() { IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmBecInstitutosPersonasList>(Persona); }

        public async void OnAppearing()
        {
            try
            {

                var source_local_ocupacion = await IFicSrvBecInstitutosPersonasDetail.FicMetGetList();
                if (source_local_ocupacion != null)
                {
                    foreach (rh_cat_perfiles ocupacion in source_local_ocupacion)
                    {
                        if (Edificio.IdPerfil == ocupacion.IdPerfil)
                        {
                            FicSfDataGrid_SelectItem_CatPerfil = ocupacion;
                        }
                        //_Picker_ItemSource_CatPerfil.Add(ocupacion);
                    }
                }//LLENAR EL PICKER DE OCUPACIONES

                var source_local_institutos = await IFicSrvBecInstitutosPersonasDetail.FicMetGetListRhCatInstitutos();
                if (source_local_institutos != null)
                {
                    foreach (cat_institutos instituto in source_local_institutos)
                    {
                        if (Edificio.IdInstituto == instituto.IdInstituto)
                        {
                            FicSfDataGrid_SelectItem_CatInstituto = instituto;
                        }
                        //_Picker_ItemSource_CatInstitutos.Add(instituto);
                    }
                }//LLENAR EL PICKER DE INSTITUTOS
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }

        }//SOBRECARGA AL METODO OnAppearing() DE LA VIEW 

        public void llenado(bec_institutos_personas per2, rh_cat_personas per)
        {
            Persona = new rh_cat_personas();
            Persona = per;
            _Edificio = new bec_institutos_personas();
            Edificio = per2;
            
        }



    }//CLASS }



}//NAMESPACE


