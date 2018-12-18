using FicAppPersonas.Interfaces.BecInstitutosPersonas;
using FicAppPersonas.Interfaces.Navegacion;
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

namespace FicAppPersonas.ViewModels.BecInstitutosPersonas
{
    public class FicVmBecInstitutosPersonasNew : INotifyPropertyChanged
    {
        public ObservableCollection<bec_institutos_personas> _FicSfDataGrid_ItemSource_CatEdificios;
        public ObservableCollection<rh_cat_perfiles> _Picker_ItemSource_CatPerfil;
        public ObservableCollection<cat_institutos> _Picker_ItemSource_CatInstitutos;
        //private ICommand _FicMetAddPersonaICommand, _FicMetAcumuladosICommand;
        private IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas;
        private IFicSrvBecInstitutosPersonasNew IFicSrvRhBecInstitutosPersonasNew;

        //private  FicDBContext FicLoBDContext;

        public FicVmBecInstitutosPersonasNew(IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas, IFicSrvBecInstitutosPersonasNew IFicSrvRhBecInstitutosPersonasNew)
        {
            this.IFicSrvNavigationRhCatPersonas = IFicSrvNavigationRhCatPersonas;
            this.IFicSrvRhBecInstitutosPersonasNew = IFicSrvRhBecInstitutosPersonasNew;
            _Picker_ItemSource_CatPerfil = new ObservableCollection<rh_cat_perfiles>();
            _Picker_ItemSource_CatInstitutos = new ObservableCollection<cat_institutos>();
            _FicSfDataGrid_ItemSource_CatEdificios = new ObservableCollection<bec_institutos_personas>();


        }//CONSTRUCTOR

        public ObservableCollection<bec_institutos_personas> FicSfDataGrid_ItemSource_CatEdificios
        {
            get
            {
                return _FicSfDataGrid_ItemSource_CatEdificios;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL GRID DE LA VIEW

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
        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand { get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); } }
        private void FicMetCatClienteExecute() { IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmBecInstitutosPersonasList>(Persona); }

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
            
            if (FicSfDataGrid_SelectItem_CatInstituto == null)
            {
                noFillFields.Add("instituto");
            }
            if (FicSfDataGrid_SelectItem_CatPerfil == null)
            {
                noFillFields.Add("Perfil");
            }
            if (Edificio.Activo == null)
            {
                noFillFields.Add("Activo");
            }
            if (Edificio.Activo == "false")
            {
                noFillFields.Add("Activo");
            }

            #endregion

            //SI TODOS LOS CAMPOS PASARON LA VALIDACION ASIGNAN SE PREPARA LA INSERCION PARA EL OBJETO PERSONA
            if (noFillFields.Count == 0)
            {
                //Persona.IdTipoGenEstadoCivil = FicSfDataGrid_SelectItem_CatGeneralesEstadoCivil.IdTipoGeneral;
                //Persona.IdInstituto = FicSfDataGrid_SelectItem_CatInstituto.IdInstituto;
                bool a = false;
                foreach (bec_institutos_personas inv in FicSfDataGrid_ItemSource_CatEdificios )
                {
                    if (inv.IdInstituto == FicSfDataGrid_SelectItem_CatInstituto.IdInstituto && inv.IdPerfil == FicSfDataGrid_SelectItem_CatPerfil.IdPerfil)
                    {
                        a = true;
                    }

                }

                if (a == true)
                {
                    await new Page().DisplayAlert("ALERTA", "Esta Persona ya esta registrada con el instito y perfil", "OK");
                }
                else
                {
                    Edificio.UsuarioReg = "gera";
                    Edificio.UsuarioMod = Edificio.UsuarioReg;
                    Edificio.FechaUltMod = DateTime.Now;
                    Edificio.FechaReg = DateTime.Now;
                    Edificio.IdInstituto = FicSfDataGrid_SelectItem_CatInstituto.IdInstituto;
                    Edificio.IdPersona = Persona.IdPersona;
                    Edificio.IdPerfil = FicSfDataGrid_SelectItem_CatPerfil.IdPerfil;
                    if (Edificio.Activo == "True")
                    {
                        Edificio.Activo = "S";
                    };
                    if (Edificio.Activo == null)
                    {
                        Edificio.Activo = "N";
                    };
                    if (Edificio.Borrado == "True")
                    {
                        Edificio.Borrado = "S";
                    };
                    if (Edificio.Borrado == null)
                    {
                        Edificio.Borrado = "N";
                    };
                    await IFicSrvRhBecInstitutosPersonasNew.FicMetGetNewBecInstitutosPersonas(Edificio);
                    IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmBecInstitutosPersonasList>(Persona);
                }
 
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

        public ObservableCollection<rh_cat_perfiles> Picker_ItemSource_CatPerfil
        {
            get
            {
                return _Picker_ItemSource_CatPerfil;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER OCUPACION DE LA VIEW

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

        #endregion
      

        public async void OnAppearing()
        {
            try
            {




                var source_local_inv = await IFicSrvRhBecInstitutosPersonasNew.FicMetGetListBecInstitutosPersonas(Persona.IdPersona);
                if (source_local_inv != null && _FicSfDataGrid_ItemSource_CatEdificios.Count == 0)
                {
                    foreach (bec_institutos_personas inv in source_local_inv)
                    {
                        _FicSfDataGrid_ItemSource_CatEdificios.Add(inv);
                    }
                }//LLENAR EL GRID

                var source_local_ocupacion = await IFicSrvRhBecInstitutosPersonasNew.FicMetGetList();
                if (source_local_ocupacion != null)
                {
                    foreach (rh_cat_perfiles ocupacion in source_local_ocupacion)
                    {
                        _Picker_ItemSource_CatPerfil.Add(ocupacion);
                    }
                }//LLENAR EL PICKER DE OCUPACIONES

                var source_local_institutos = await IFicSrvRhBecInstitutosPersonasNew.FicMetGetListRhCatInstitutos();
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
        public void llenado(rh_cat_personas obj)
        {
            _Edificio = new bec_institutos_personas();
            Persona = new rh_cat_personas();
            Persona = obj;
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


