using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.Interfaces.RhCatDomicilios;
using FicAppPersonas.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.ViewModels.RhCatDomicilios
{
    public class FicVmRhCatDomiciliosNew : INotifyPropertyChanged
    {
        public ObservableCollection<cat_generales> _Picker_ItemSource_CatGeneralesDomicilio;
        public ObservableCollection<cat_paises> _Picker_ItemSource_CatPaises;
        public ObservableCollection<cat_estados> _Picker_ItemSource_CatEstado;
        public ObservableCollection<cat_municipios> _Picker_ItemSource_CatMunicipio;
        public ObservableCollection<cat_localidades> _Picker_ItemSource_CatLocalidad;
        public ObservableCollection<cat_colonias> _Picker_ItemSource_CatColonia;

        //private ICommand _FicMetAddPersonaICommand, _FicMetAcumuladosICommand;
        private IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas;
        private IFicSrvRhCatDomiciliosNew IFicSrvRhCatDomiciliosNew;

        //private  FicDBContext FicLoBDContext;

        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand { get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); } }
        private void FicMetCatClienteExecute() { IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatDomiciliosList>(Persona); }

        public FicVmRhCatDomiciliosNew(IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas, IFicSrvRhCatDomiciliosNew IFicSrvRhCatDomiciliosNew)
        {
            this.IFicSrvNavigationRhCatPersonas = IFicSrvNavigationRhCatPersonas;
            this.IFicSrvRhCatDomiciliosNew = IFicSrvRhCatDomiciliosNew;
            _Picker_ItemSource_CatGeneralesDomicilio = new ObservableCollection<cat_generales>();
            _Picker_ItemSource_CatPaises = new ObservableCollection<cat_paises>();
            _Picker_ItemSource_CatEstado = new ObservableCollection<cat_estados>();
            _Picker_ItemSource_CatMunicipio = new ObservableCollection<cat_municipios>();
            _Picker_ItemSource_CatLocalidad = new ObservableCollection<cat_localidades>();
            _Picker_ItemSource_CatColonia = new ObservableCollection<cat_colonias>();



        }//CONSTRUCTOR

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
        

        private ICommand AddPersona;
        public ICommand FicMetAddCommand
        {
            get { return AddPersona = AddPersona ?? new FicVmDelegateCommand(AddPersonaExecute); }
        }
        private async void AddPersonaExecute()
        {

            List<string> noFillFields = new List<string>();//LISTA DE CAMPOS QUE NO FUERON LLENADOS

            //CONJUNTO DE VALIDACIONES DE CAMPOS NO LLENADOS O NO SELECCIONADOS
            #region

            if (FicSfDataGrid_SelectItem_CatPais == null)
            {
                noFillFields.Add("Pais");
            }
            if (FicSfDataGrid_SelectItem_CatEstado == null)
            {
                noFillFields.Add("Estado");
            }
            if (FicSfDataGrid_SelectItem_CatMunicipio == null)
            {
                noFillFields.Add("Municipio");
            }
            if (FicSfDataGrid_SelectItem_CatLocalidad == null)
            {
                noFillFields.Add("Localidad");
            }
            if (FicSfDataGrid_SelectItem_CatColonia == null)
            {
                noFillFields.Add("Colonia");
            }
            if (FicSfDataGrid_SelectItem_CatGeneralesDomicilio == null)
            {
                noFillFields.Add("Domicilio");
            }
            if (Domicilio.TipoDomicilio == null)
            {
                noFillFields.Add("Tipo Domicilio");
            }                   
            if (Domicilio.CodigoPostal == null)
            {
                noFillFields.Add("CodigoPostal");
            }
            if (Domicilio.Coordenadas == null)
            {
                noFillFields.Add("Coordenadas");
            }
            if (Domicilio.Domicilio == null)
            {
                noFillFields.Add("Domicilio");
            }                      

            #endregion

            //SI TODOS LOS CAMPOS PASARON LA VALIDACION ASIGNAN SE PREPARA LA INSERCION PARA EL OBJETO PERSONA
            if (noFillFields.Count == 0)
            {
                Domicilio.Pais = FicSfDataGrid_SelectItem_CatPais.DesPais;
                Domicilio.Estado = FicSfDataGrid_SelectItem_CatEstado.DesEstado;
                Domicilio.Municipio = FicSfDataGrid_SelectItem_CatMunicipio.DesMunicipio;
                Domicilio.Localidad = FicSfDataGrid_SelectItem_CatLocalidad.DesLocalidad;
                Domicilio.Colonia = FicSfDataGrid_SelectItem_CatColonia.DesColonia;
                Domicilio.IdGenDom = FicSfDataGrid_SelectItem_CatGeneralesDomicilio.IdGeneral;
                Domicilio.IdTipoGenDom = FicSfDataGrid_SelectItem_CatGeneralesDomicilio.IdTipoGeneral;
                Domicilio.ClaveReferencia = Persona.IdPersona.ToString();
                Domicilio.Referencia = "rh_cat_personas";

                Domicilio.UsuarioReg = "gera";
                Domicilio.UsuarioMod = Persona.UsuarioReg;
                Domicilio.FechaUltMod = DateTime.Now;
                Domicilio.FechaReg = DateTime.Now;
                if (Domicilio.TipoDomicilio == "True")
                {
                    Domicilio.TipoDomicilio = "S";
                };
                if (Domicilio.TipoDomicilio == null)
                {
                    Domicilio.TipoDomicilio = "N";
                };
                if (Domicilio.Principal == "True")
                {
                    Domicilio.Principal = "S";
                };
                if (Domicilio.Principal == null)
                {
                    Domicilio.Principal = "N";
                };
                if (Domicilio.Activo == "True")
                {
                    Domicilio.Activo = "S";
                };
                if (Domicilio.Activo == null)
                {
                    Domicilio.Activo = "N";
                };
                if (Domicilio.Borrado == "True")
                {
                    Domicilio.Borrado = "S";
                };
                if (Domicilio.Borrado == null)
                {
                    Domicilio.Borrado = "N";
                };
                await IFicSrvRhCatDomiciliosNew.FicMetGetNewRhCatDomicilios(Domicilio);
                IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatDomiciliosList>(Persona);
            }
            else
            {
                //LISTADO DE LOS CAMPOS QUE NO FUERON LLENADOS
                var empty_fields = "Los siguientes campos no fueron llenados: ";
                int i = 0;
                foreach (string field in noFillFields)
                {
                    i++;
                    if (i != noFillFields.Count() - 1)
                    {
                        if (i != noFillFields.Count())
                        {
                            empty_fields += field + ", ";
                        }
                        else
                        {
                            empty_fields += field + ".";
                        }
                    }
                    else
                    {
                        empty_fields += field + " y ";
                    }
                }
                //ALERT DIALOG DE CAMPOS FALTANTES
                await new Page().DisplayAlert("ALERTA", empty_fields.ToString(), "OK");
            }
        }


        //=========================Item sources==============================//        


        #region

        public ObservableCollection<cat_generales> Picker_ItemSource_CatGeneralesDomicilio
        {
            get
            {
                return _Picker_ItemSource_CatGeneralesDomicilio;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER GENERALES DOMICILIO DE LA VIEW

        public ObservableCollection<cat_paises> Picker_ItemSource_CatPaises
        {
            get
            {
                return _Picker_ItemSource_CatPaises;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER PAISES DE LA VIEW

        public ObservableCollection<cat_estados> Picker_ItemSource_CatEstado
        {
            get
            {
                return _Picker_ItemSource_CatEstado;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER ESTADOS DE LA VIEW

        public ObservableCollection<cat_municipios> Picker_ItemSource_CatMunicipio
        {
            get
            {
                return _Picker_ItemSource_CatMunicipio;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER MUNICIPIOS DE LA VIEW

        public ObservableCollection<cat_localidades> Picker_ItemSource_CatLocalidad
        {
            get
            {
                return _Picker_ItemSource_CatLocalidad;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER LOCALIDADES  DE LA VIEW

        public ObservableCollection<cat_colonias> Picker_ItemSource_CatColonia
        {
            get
            {
                return _Picker_ItemSource_CatColonia;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER LOCALIDADES  DE LA VIEW


        #endregion


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
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL PICKER pPAISES DE LA VIEW

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

                var source_local_generales_domicilio = await IFicSrvRhCatDomiciliosNew.FicMetGetListRhCatGenerales(12);
                if (source_local_generales_domicilio != null)
                {
                    foreach (cat_generales domicilio in source_local_generales_domicilio)
                    {
                        _Picker_ItemSource_CatGeneralesDomicilio.Add(domicilio);
                    }
                }//LLENAR EL PICKER DE GENERALES

                var source_local_paises = await IFicSrvRhCatDomiciliosNew.FicMetGetListRhCaPaises();
                if (source_local_paises != null)
                {
                    foreach (cat_paises paises in source_local_paises)
                    {
                        _Picker_ItemSource_CatPaises.Add(paises);
                    }
                }//LLENAR EL PICKER DE PAISES

                var source_local_estados = await IFicSrvRhCatDomiciliosNew.FicMetGetListRhCaEstados();
                if (source_local_estados != null)
                {
                    foreach (cat_estados paises in source_local_estados)
                    {
                        _Picker_ItemSource_CatEstado.Add(paises);
                    }
                }//LLENAR EL PICKER DE ESTADOS


                var source_local_municipios = await IFicSrvRhCatDomiciliosNew.FicMetGetListRhCaMunincipios();
                if (source_local_municipios != null)
                {
                    foreach (cat_municipios paises in source_local_municipios)
                    {
                        _Picker_ItemSource_CatMunicipio.Add(paises);
                    }
                }//LLENAR EL PICKER DE MUNICIPIOS

                var source_local_localidad = await IFicSrvRhCatDomiciliosNew.FicMetGetListRhCaLocalidades();
                if (source_local_localidad != null)
                {
                    foreach (cat_localidades paises in source_local_localidad)
                    {
                        _Picker_ItemSource_CatLocalidad.Add(paises);
                    }
                }//LLENAR EL PICKER DE MUNICIPIOS

                var source_local_colonias = await IFicSrvRhCatDomiciliosNew.FicMetGetListRhCaColonias();
                if (source_local_colonias != null)
                {
                    foreach (cat_colonias colonias in source_local_colonias)
                    {
                        _Picker_ItemSource_CatColonia.Add(colonias);
                    }
                }//LLENAR EL PICKER DE MUNICIPIOS

            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//SOBRECARGA AL METODO OnAppearing() DE LA VIEW 


        public void getPersonaData(rh_cat_personas persona)
        {
            Persona = new rh_cat_personas();
            Persona = persona;
            _Domicilio = new rh_cat_domicilios();
            // Domicilio.IdDomicilio = Persona.IdPersona;
            //_Domicilio.IdDomicilio = Persona.IdPersona;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }//CLASS }



}//NAMESPACE


