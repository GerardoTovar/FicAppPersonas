using FicAppPersonas.Interfaces.RhCatPersonas;
using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using System.Linq;
using System.Collections.Generic;

namespace FicAppPersonas.ViewModels.RhCatPersonas
    {
        public class FicVmRhCatPersonasNew : INotifyPropertyChanged
        {
            public ObservableCollection<FillPicker> _Picker_ItemSource_TipoPersona;
            public ObservableCollection<FillPicker> _Picker_ItemSource_Sexo;
            public ObservableCollection<cat_generales> _Picker_ItemSource_CatGeneralesOcupacion;
            public ObservableCollection<cat_generales> _Picker_ItemSource_CatGeneralesEstadoCivil;
            public ObservableCollection<cat_institutos> _Picker_ItemSource_CatInstitutos;
            //private ICommand _FicMetAddPersonaICommand, _FicMetAcumuladosICommand;
            private IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas;
            private IFicSrvRhCatPersonasNew IFicSrvRhCatPersonasNew;
            
            //private  FicDBContext FicLoBDContext;

            public FicVmRhCatPersonasNew(IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas, IFicSrvRhCatPersonasNew IFicSrvRhCatPersonasNew)
            {
                this.IFicSrvNavigationRhCatPersonas = IFicSrvNavigationRhCatPersonas;
                this.IFicSrvRhCatPersonasNew = IFicSrvRhCatPersonasNew;
                _Picker_ItemSource_CatGeneralesOcupacion = new ObservableCollection<cat_generales>();
                _Picker_ItemSource_CatGeneralesEstadoCivil = new ObservableCollection<cat_generales>();
                _Picker_ItemSource_CatInstitutos = new ObservableCollection<cat_institutos>();
                _Picker_ItemSource_TipoPersona = new ObservableCollection<FillPicker>();
                _Picker_ItemSource_Sexo = new ObservableCollection<FillPicker>();

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

        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand
        {

            get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); }
        }
        private void FicMetCatClienteExecute()
        {
            IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasList>(null);
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
            
            if (Persona.FechaNac == null)
            {
                Persona.FechaNac = DateTime.Now;
            }
            else
            {
                var a = new DateTime();
                a = DateTime.Parse(Persona.FechaNac.ToString());
                var fecha_temp = a;
                var day = Int32.Parse(fecha_temp.Day.ToString());
                var month = Int32.Parse(fecha_temp.Month.ToString());
                var year = Int32.Parse(fecha_temp.Year.ToString());

                var hours = Int32.Parse(DateTime.Now.Hour.ToString());
                var mins = Int32.Parse(DateTime.Now.Minute.ToString());
                var sec = Int32.Parse(DateTime.Now.Second.ToString());
                var milisec = Int32.Parse(DateTime.Now.Millisecond.ToString());
                DateTime fecha = new DateTime(year, month, day, hours, mins, sec, milisec);
                Persona.FechaNac = fecha;
            }
            if (Persona.ApMaterno == null || Persona.ApPaterno == null || Persona.Nombre == null)
            {
                noFillFields.Add("nombre");               
            }
            if (Persona.CURP == null) {
                noFillFields.Add("CURP");
            }           
            if (FicSfDataGrid_SelectItem_CatInstituto == null)
            {
                noFillFields.Add("instituto");
            }
            if (FicSfDataGrid_SelectItem_CatGeneralesEstadoCivil == null)
            {
                noFillFields.Add("estado civil");
            }
            if (FicSfDataGrid_SelectItem_CatGeneralesOcupacion == null)
            {
                noFillFields.Add("ocupacion");
            }
            if (FicSfDataGrid_SelectItem_TipoPersona == null)
            {
                noFillFields.Add("tipo persona");
            }
            if (FicSfDataGrid_SelectItem_Sexo == null)
            {
                noFillFields.Add("sexo");
            }
            #endregion
            
            //SI TODOS LOS CAMPOS PASARON LA VALIDACION ASIGNAN SE PREPARA LA INSERCION PARA EL OBJETO PERSONA
            if (noFillFields.Count == 0)
            {
                Persona.TipoPersona = FicSfDataGrid_SelectItem_TipoPersona.Clave;
                Persona.Sexo = FicSfDataGrid_SelectItem_Sexo.Clave;
                Persona.IdGenOcupacion = FicSfDataGrid_SelectItem_CatGeneralesOcupacion.IdGeneral;
                Persona.IdTipoGenOcupacion = FicSfDataGrid_SelectItem_CatGeneralesOcupacion.IdTipoGeneral;
                Persona.IdGenEstadoCivil = FicSfDataGrid_SelectItem_CatGeneralesEstadoCivil.IdGeneral;
                Persona.IdTipoGenEstadoCivil = FicSfDataGrid_SelectItem_CatGeneralesEstadoCivil.IdTipoGeneral;
                Persona.IdInstituto = FicSfDataGrid_SelectItem_CatInstituto.IdInstituto;

                Persona.UsuarioReg = "GUERRA";
                Persona.UsuarioMod = Persona.UsuarioReg;
                Persona.FechaUltMod = DateTime.Now;
                Persona.FechaReg = DateTime.Now;
                if (Persona.Activo == "True")
                {
                    Persona.Activo = "S";
                };
                if (Persona.Activo == null)
                {
                    Persona.Activo = "N";
                };
                if (Persona.Borrado == "True")
                {
                    Persona.Borrado = "S";
                };
                if (Persona.Borrado == null)
                {
                    Persona.Borrado = "N";
                };
                await IFicSrvRhCatPersonasNew.FicMetGetNewRhCatPersonas(Persona);
                IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasList>(null);
            }
            else {
                //LISTADO DE LOS CAMPOS QUE NO FUERON LLENADOS
                var empty_fields = "Los siguientes campos no fueron llenados: ";
                int i = 0;
                foreach (string field in noFillFields ) {
                    i++;
                    if (i != noFillFields.Count() - 1)
                    {
                        if (i != noFillFields.Count())
                        {
                            empty_fields += field + ", ";
                        }
                        else {
                            empty_fields += field + ".";
                        }                        
                    }
                    else {
                        empty_fields += field + " y ";
                    }                                        
                }
                //ALERT DIALOG DE CAMPOS FALTANTES
                await new Page().DisplayAlert("ALERTA", empty_fields.ToString(), "OK");
            }

            
        }


        //=========================Item sources==============================//        


        #region

        public ObservableCollection<FillPicker> Picker_ItemSource_Sexo
        {
            get
            {
                return _Picker_ItemSource_Sexo;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER SEXO DE LA VIEW

        public ObservableCollection<FillPicker> Picker_ItemSource_TipoPersona
        {
            get
            {
                return _Picker_ItemSource_TipoPersona;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER TIPO PERSONA DE LA VIEW

        public ObservableCollection<cat_generales> Picker_ItemSource_CatGeneralesOcupacion
        {
            get
            {
                return _Picker_ItemSource_CatGeneralesOcupacion;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER OCUPACION DE LA VIEW

        public ObservableCollection<cat_generales> Picker_ItemSource_CatGeneralesEstadoCivil
        {
            get
            {
                return _Picker_ItemSource_CatGeneralesEstadoCivil;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER ESTADO CIVIL DE LA VIEW

        public ObservableCollection<cat_institutos> Picker_ItemSource_CatInstitutos
        {
            get
            {
                return _Picker_ItemSource_CatInstitutos;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER INSTITUTOS DE LA VIEW
        #endregion


        //=========================Selected Items============================//
        #region

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


        public rh_cat_personas _SfDataGrid_SelectItem_Persona;
        public rh_cat_personas SfDataGrid_SelectItem_Persona
        {
            get { return _SfDataGrid_SelectItem_Persona; }
            set
            {
                _SfDataGrid_SelectItem_Persona = value;
                RaisePropertyChanged();
            }
        }//ESTE APUNTA A CADA CAMPO EN EL FORMULARIO DE NUEVA PERSONA
        #endregion

        
        public List<FillPicker> GetTipoPersona () {
            var tipos_personas = new List<FillPicker>()
            {
                new FillPicker(){ Clave = "F", Valor = "Física"},
                new FillPicker(){ Clave = "M", Valor = "Moral"},                
            };

            return tipos_personas;
        }//AQUI SE OBTIENEN LOS TIPOS DE PERSONAS MANUALMENTE

        public List<FillPicker> GetSexo() {
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
                _Personas = new rh_cat_personas();
                var source_local_sexo = GetSexo();
                foreach (FillPicker sexo in source_local_sexo) {
                    _Picker_ItemSource_Sexo.Add(sexo);
                }//LLENAR EL PICKER DE SEXO

                var source_local_tipo_per = GetTipoPersona();
                foreach (FillPicker tipo_per in source_local_tipo_per) {
                    _Picker_ItemSource_TipoPersona.Add(tipo_per);
                }//LLENAR EL PICKER DE TIPO PERSONA
               
                            
                var source_local_ocupacion = await IFicSrvRhCatPersonasNew.FicMetGetListRhCatGenerales(3);
                if (source_local_ocupacion != null)
                {
                    foreach (cat_generales ocupacion in source_local_ocupacion)
                    {
                        _Picker_ItemSource_CatGeneralesOcupacion.Add(ocupacion);
                    }
                }//LLENAR EL PICKER DE OCUPACIONES

                var source_local_estado_civil = await IFicSrvRhCatPersonasNew.FicMetGetListRhCatGenerales (4);
                if (source_local_estado_civil != null)
                {
                    foreach (cat_generales estado_civil in source_local_estado_civil)
                    {
                        _Picker_ItemSource_CatGeneralesEstadoCivil.Add(estado_civil);
                    }
                }//LLENAR EL PICKER DE ESTADO CIVIL

                var source_local_institutos = await IFicSrvRhCatPersonasNew.FicMetGetListRhCatInstitutos();
                if (source_local_institutos != null)
                {
                    foreach (cat_institutos instituto in source_local_institutos)
                    {
                        _Picker_ItemSource_CatInstitutos.Add(instituto);
                    }
                }//LLENAR EL PICKER DE INSTITUTOS
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//SOBRECARGA AL METODO OnAppearing() DE LA VIEW 




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


