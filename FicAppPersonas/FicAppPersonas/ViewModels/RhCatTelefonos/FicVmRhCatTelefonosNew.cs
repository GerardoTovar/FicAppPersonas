using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.Interfaces.RhCatTelefonos;
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

namespace FicAppPersonas.ViewModels.RhCatTelefonos
{
    public class FicVmRhCatTelefonosNew : INotifyPropertyChanged
    {
        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        private IFicSrvRhCatTelefonosNew FicLoSrvApp;
        private ObservableCollection<cat_generales> _Picker_ItemSource_CatGenTelefonos;
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

        private rh_cat_telefonos _Telefono;
        public rh_cat_telefonos Telefono
        {
            get { return _Telefono; }
            set
            {
                _Telefono = value;
                RaisePropertyChanged();
            }
        }

        public FicVmRhCatTelefonosNew(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvRhCatTelefonosNew FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
            _Picker_ItemSource_CatGenTelefonos = new ObservableCollection<cat_generales>();
        }




        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand{ get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); }}
        private void FicMetCatClienteExecute(){FicLoSrvNavigation.FicMetNavigateTo<FicVmRhCatTelefonosList>(Persona);}

        private ICommand AddTelefono;
        public ICommand FicMetAddCommand
        {
            get { return AddTelefono = AddTelefono ?? new FicVmDelegateCommand(AddTelefonoExecute); }
        }
        private async void AddTelefonoExecute()
        {

            List<string> noFillFields = new List<string>();//LISTA DE CAMPOS QUE NO FUERON LLENADOS

            //CONJUNTO DE VALIDACIONES DE CAMPOS NO LLENADOS O NO SELECCIONADOS
            #region
            if (Telefono.CodPais == null)
            {
                noFillFields.Add("codigo del pais");
            }
            if (Telefono.NumTelefono == null)
            {
                noFillFields.Add("numero de telefono");
            }           
            if (Picker_SelectItem_CatGenTelefono == null) {
                noFillFields.Add("tipo de telefono");
            }
            
            #endregion


            //SI TODOS LOS CAMPOS PASARON LA VALIDACION ASIGNAN SE PREPARA LA INSERCION PARA EL OBJETO DirWeb
            if (noFillFields.Count == 0)
            {
                Telefono.UsuarioReg = "GUERRA";
                Telefono.ClaveReferencia = Persona.IdPersona.ToString();
                Telefono.Referencia = "rh_cat_generales";
                Telefono.IdGenTelefono = Picker_SelectItem_CatGenTelefono.IdGeneral;
                Telefono.IdTipoGenTelefono = Picker_SelectItem_CatGenTelefono.IdTipoGeneral;
                Telefono.UsuarioMod = Telefono.UsuarioReg;
                Telefono.FechaUltMod = DateTime.Now;
                Telefono.FechaReg = DateTime.Now;
                if (Telefono.Activo == "True")
                {
                    Telefono.Activo = "S";
                }
                else
                {
                    Telefono.Activo = "N";
                }
                if (Telefono.Borrado == "True")
                {
                    Telefono.Borrado = "S";
                }
                else
                {
                    Telefono.Borrado = "N";
                }
                if (Telefono.Principal == "True")
                {
                    Telefono.Principal = "S";
                }
                else
                {
                    Telefono.Principal = "N";
                }
                await FicLoSrvApp.FicMetGetNewRhCatTelefonos(Telefono);
                FicLoSrvNavigation.FicMetNavigateTo<FicVmRhCatTelefonosList>(Persona);
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
        public ObservableCollection<cat_generales> Picker_ItemSource_CatGenTelefonos
        {
            get
            {
                return _Picker_ItemSource_CatGenTelefonos;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER TIPOS DE TELEFONOS DE LA VIEW
        #endregion


        //=========================Select Item==============================//      

        #region
        public cat_generales _Picker_SelectItem_CatGenTelefono;
        public cat_generales Picker_SelectItem_CatGenTelefono
        {
            get { return _Picker_SelectItem_CatGenTelefono; }
            set
            {
                _Picker_SelectItem_CatGenTelefono = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        //Llendo de combos y cargando los Bindings
        public async void OnAppearing()
        {
            try
            {
                _Telefono = new rh_cat_telefonos();

                var source_local_telefonos = await FicLoSrvApp.FicMetGetListRhCatGenerales(5); ;
                if (source_local_telefonos != null && _Picker_ItemSource_CatGenTelefonos.Count == 0)
                {
                    foreach (cat_generales tel in source_local_telefonos)
                    {
                        _Picker_ItemSource_CatGenTelefonos.Add(tel);
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

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


    }//CLASS
}//NAMESPACE

