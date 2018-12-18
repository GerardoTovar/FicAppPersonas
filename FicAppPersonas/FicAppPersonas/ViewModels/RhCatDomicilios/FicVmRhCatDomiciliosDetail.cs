using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.Interfaces.RhCatDomicilios;
using FicAppPersonas.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.ViewModels.RhCatDomicilios
{
    public class FicVmRhCatDomiciliosDetail : FicViewModelBase
    {
        private IFicSrvNavigationRhCatPersonas NavigationRhCatPersonas;
        private IFicSrvRhCatDomiciliosDetail IFicSCatDomiciliosDetail;

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

        private rh_cat_domicilios _Domicilio;
        public rh_cat_domicilios Domicilio
        {
            get { return _Domicilio; }
            set
            {
                _Domicilio = value;
                RaisePropertyChanged();
            }
        }

        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand { get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); } }
        private void FicMetCatClienteExecute() { NavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatDomiciliosList>(Persona); }


        public FicVmRhCatDomiciliosDetail(IFicSrvNavigationRhCatPersonas NavigationCatPersonas, IFicSrvRhCatDomiciliosDetail IFicSrvRhCatDomiciliosDetail)
        {
            this.NavigationRhCatPersonas = NavigationCatPersonas;
            this.IFicSCatDomiciliosDetail = IFicSrvRhCatDomiciliosDetail;
        }

        //=========================Selected Items============================//
        #region



        public cat_generales _SfDataGrid_SelectItem_CatGeneralesDomicilio;
        public cat_generales FicSfDataGrid_SelectItem_CatGeneralesDomicilio
        {
            get { return _SfDataGrid_SelectItem_CatGeneralesDomicilio; }
            set
            {
                _SfDataGrid_SelectItem_CatGeneralesDomicilio = value;
                RaisePropertyChanged();
            }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL PICKER OCUPACION DE LA VIEW

        public cat_paises _SfDataGrid_SelectItem_Paises;
        public cat_paises FicSfDataGrid_SelectItem_CatPais
        {
            get { return _SfDataGrid_SelectItem_Paises; }
            set
            {
                _SfDataGrid_SelectItem_Paises = value;
                RaisePropertyChanged();
            }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL PICKER INSTITUTOS DE LA VIEW

        public cat_estados _SfDataGrid_SelectItem_Estados;
        public cat_estados FicSfDataGrid_SelectItem_CatEstado
        {
            get { return _SfDataGrid_SelectItem_Estados; }
            set
            {
                _SfDataGrid_SelectItem_Estados = value;
                RaisePropertyChanged();
            }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL PICKER ESTADOS DE LA VIEW

        public cat_municipios _SfDataGrid_SelectItem_Munincipios;
        public cat_municipios FicSfDataGrid_SelectItem_CatMunicipio
        {
            get { return _SfDataGrid_SelectItem_Munincipios; }
            set
            {
                _SfDataGrid_SelectItem_Munincipios = value;
                RaisePropertyChanged();
            }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL PICKER ESTADOS DE LA VIEW

        public cat_localidades _SfDataGrid_SelectItem_Localidades;
        public cat_localidades FicSfDataGrid_SelectItem_CatLocalidad
        {
            get { return _SfDataGrid_SelectItem_Localidades; }
            set
            {
                _SfDataGrid_SelectItem_Localidades = value;
                RaisePropertyChanged();
            }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL PICKER LOCALIDAD DE LA VIEW
        public cat_colonias _SfDataGrid_SelectItem_Colonias;
        public cat_colonias FicSfDataGrid_SelectItem_CatColonia
        {
            get { return _SfDataGrid_SelectItem_Colonias; }
            set
            {
                _SfDataGrid_SelectItem_Colonias = value;
                RaisePropertyChanged();
            }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL PICKER LOCALIDAD DE LA VIEW
        #endregion

        public async void OnAppearing()
        {
            try
            {

                var source_local_generales_domicilio = await IFicSCatDomiciliosDetail.FicMetGetListRhCatGenerales(12);
                if (source_local_generales_domicilio != null)
                {
                    foreach (cat_generales domicilio in source_local_generales_domicilio)
                    {
                        if (domicilio.IdTipoGeneral == Domicilio.IdTipoGenDom)
                        {
                            FicSfDataGrid_SelectItem_CatGeneralesDomicilio = domicilio;
                        }
                        //_Picker_ItemSource_CatGeneralesDomicilio.Add(domicilio);
                    }
                }//LLENAR EL PICKER DE GENERALES

                var source_local_paises = await IFicSCatDomiciliosDetail.FicMetGetListRhCaPaises();
                if (source_local_paises != null)
                {
                    foreach (cat_paises paises in source_local_paises)
                    {
                        if (paises.DesPais == Domicilio.Pais)
                        {
                            FicSfDataGrid_SelectItem_CatPais = paises;
                        }
                        //_Picker_ItemSource_CatPaises.Add(paises);
                    }
                }//LLENAR EL PICKER DE INSTITUTOS

                var source_local_estados = await IFicSCatDomiciliosDetail.FicMetGetListRhCaEstados();
                if (source_local_estados != null)
                {
                    foreach (cat_estados paises in source_local_estados)
                    {
                        if (paises.DesEstado == Domicilio.Estado)
                        {
                            FicSfDataGrid_SelectItem_CatEstado = paises;
                        }
                        //_Picker_ItemSource_CatEstado.Add(paises);
                    }
                }//LLENAR EL PICKER DE ESTADOS

                var source_local_municipios = await IFicSCatDomiciliosDetail.FicMetGetListRhCaMunincipios();
                if (source_local_municipios != null)
                {
                    foreach (cat_municipios paises in source_local_municipios)
                    {
                        if (paises.DesMunicipio == Domicilio.Municipio)
                        {
                            FicSfDataGrid_SelectItem_CatMunicipio = paises;
                        }
                        //_Picker_ItemSource_CatMunicipio.Add(paises);
                    }
                }//LLENAR EL PICKER DE MUNICIPIOS

                var source_local_localidad = await IFicSCatDomiciliosDetail.FicMetGetListRhCaLocalidades();
                if (source_local_localidad != null)
                {
                    foreach (cat_localidades paises in source_local_localidad)
                    {
                        if (paises.DesLocalidad == Domicilio.Localidad)
                        {
                            FicSfDataGrid_SelectItem_CatLocalidad = paises;
                        }
                        //_Picker_ItemSource_CatLocalidad.Add(paises);
                    }
                }//LLENAR EL PICKER DE MUNICIPIOS
                var source_local_colonias = await IFicSCatDomiciliosDetail.FicMetGetListRhCaColonias();
                if (source_local_colonias != null)
                {
                    foreach (cat_colonias colonias in source_local_colonias)
                    {
                        if (colonias.DesColonia == Domicilio.Colonia)
                        {
                            FicSfDataGrid_SelectItem_CatColonia = colonias;
                        }
                        //_Picker_ItemSource_CatColonia.Add(colonias);
                    }
                }//LLENAR EL PICKER DE MUNICIPIOS
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//SOBRECARGA AL METODO OnAppearing() DE LA VIEW 

        public void llenado(rh_cat_domicilios obj, rh_cat_personas persona)
        {
            Persona = new rh_cat_personas();
            Persona = persona;
            _Domicilio = new rh_cat_domicilios();
            Domicilio = obj;

        }


    }//CLASS }



}//NAMESPACE


