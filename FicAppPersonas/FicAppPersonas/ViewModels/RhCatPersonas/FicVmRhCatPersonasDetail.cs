using FicAppPersonas.Interfaces.Navegacion;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Interfaces.RhCatPersonas;
using FicAppPersonas.ViewModels.Base;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using System.Collections.Generic;

namespace FicAppPersonas.ViewModels.RhCatPersonas
{
    public class FicVmRhCatPersonasDetail : FicViewModelBase
    {
        private IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas;
        private IFicSrvRhCatPersonasDetail IFicSrvRhCatPersonasDetail;
        private rh_cat_personas _Persona;
        public rh_cat_personas Persona
        {
            get { return _Persona; }
            set
            {
                _Persona = value;
                RaisePropertyChanged();
            }
        }
                public FillPicker _SfDataGrid_SelectItem_Sexo;
        public FillPicker FicSfDataGrid_SelectItem_Sexo
        {
            get { return _SfDataGrid_SelectItem_Sexo; }
            set
            {
                _SfDataGrid_SelectItem_Sexo = value;
                RaisePropertyChanged();
            }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL PICKER TIPO PERSONA DE LA VIEW

        public FillPicker _SfDataGrid_SelectItem_TipoPersona;
        public FillPicker FicSfDataGrid_SelectItem_TipoPersona
        {
            get { return _SfDataGrid_SelectItem_TipoPersona; }
            set
            {
                _SfDataGrid_SelectItem_TipoPersona = value;
                RaisePropertyChanged();
            }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL PICKER TIPO PERSONA DE LA VIEW
        public cat_generales _SfDataGrid_SelectItem_Ocupacion;
        public cat_generales FicSfDataGrid_SelectItem_CatGeneralesOcupacion
        {
            get { return _SfDataGrid_SelectItem_Ocupacion; }
            set
            {
                _SfDataGrid_SelectItem_Ocupacion = value;
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
        public cat_generales _SfDataGrid_SelectItem_Estado_Civil;
        public cat_generales FicSfDataGrid_SelectItem_CatGeneralesEstadoCivil
        {
            get { return _SfDataGrid_SelectItem_Estado_Civil; }
            set
            {
                _SfDataGrid_SelectItem_Estado_Civil = value;
                RaisePropertyChanged();
            }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL PICKER ESTADO CIVIL DE LA VIEW
        public FicVmRhCatPersonasDetail(IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas, IFicSrvRhCatPersonasDetail IFicSrvRhCatPersonasDetail)
        {
            this.IFicSrvNavigationRhCatPersonas = IFicSrvNavigationRhCatPersonas;
            this.IFicSrvRhCatPersonasDetail = IFicSrvRhCatPersonasDetail;
        }//CONSTRUCTOR

        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand
        {

            get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); }
        }
        private void FicMetCatClienteExecute()
        {
             IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasList>(null);
        }

        public List<FillPicker> GetTipoPersona()
        {
            var tipos_personas = new List<FillPicker>()
            {
               new FillPicker(){ Clave = "F", Valor = "Física"},
               new FillPicker(){ Clave = "M", Valor = "Moral"},
            };

            return tipos_personas;
        }//AQUI SE OBTIENEN LOS TIPOS DE PERSONAS MANUALMENTE

        public List<FillPicker> GetSexo()
        {
            var sexo = new List<FillPicker>()
            {
                new FillPicker(){ Clave = "M", Valor = "Mujer"},
                new FillPicker(){ Clave = "H", Valor = "Hombre"},
            };

            return sexo;
        }//AQUI SE OBTIENEN LOS SEXOS MANUALMENTE        

        public async void OnAppearing()
        {
            try
            {
                var source_local_sexo = GetSexo();
                foreach (FillPicker sexo in source_local_sexo)
                {
                    if (Persona.Sexo == sexo.Clave)
                    {
                        FicSfDataGrid_SelectItem_Sexo = sexo;
                    }
                   // _Picker_ItemSource_Sexo.Add(sexo);
                }//LLENAR EL PICKER DE SEXO

                var source_local_tipo_per = GetTipoPersona();
                foreach (FillPicker tipo_per in source_local_tipo_per)
                {
                    if (Persona.TipoPersona == tipo_per.Clave)
                    {
                        FicSfDataGrid_SelectItem_TipoPersona = tipo_per;
                    }
                    //_Picker_ItemSource_TipoPersona.Add(tipo_per);
                }//LLENAR EL PICKER DE TIPO PERSONA

                var source_local_estado_civil = await IFicSrvRhCatPersonasDetail.FicMetGetListRhCatGenerales(4);
                if (source_local_estado_civil != null)
                {
                    foreach (cat_generales estado_civil in source_local_estado_civil)
                    {
                        if (Persona.IdGenEstadoCivil == estado_civil.IdGeneral)
                        {
                            FicSfDataGrid_SelectItem_CatGeneralesEstadoCivil = estado_civil;
                        }
                        //_Picker_ItemSource_CatGeneralesEstadoCivil.Add(estado_civil);
                    }
                }//LLENAR EL PICKER DE ESTADO CIVIL

                var source_local_ocupacion = await IFicSrvRhCatPersonasDetail.FicMetGetListRhCatGenerales(3);
                if (source_local_ocupacion != null)
                {
                    foreach (cat_generales ocupacion in source_local_ocupacion)
                    {
                        if (Persona.IdGenOcupacion == ocupacion.IdGeneral)
                        {
                            FicSfDataGrid_SelectItem_CatGeneralesOcupacion = ocupacion;
                        }
                        //_Picker_ItemSource_CatGeneralesOcupacion.Add(ocupacion);
                    }
                }//LLENAR EL PICKER DE OCUPACIONES

                var source_local_institutos = await IFicSrvRhCatPersonasDetail.FicMetGetListRhCatInstitutos();
                if (source_local_institutos != null)
                {
                    foreach (cat_institutos instituto in source_local_institutos)
                    {
                        if (Persona.IdInstituto == instituto.IdInstituto)
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
        public void getPersonaData(rh_cat_personas persona)
        {
            Persona = new rh_cat_personas();
            Persona = persona;
        }


    }//CLASS }



}//NAMESPACE


