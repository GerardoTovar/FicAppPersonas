using System;
using System.Collections.Generic;
using System.Text;
using FicAppPersonas.ViewModels.Base;
using FicAppPersonas.Models.Asistencia;
using System.Windows.Input;
using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.Interfaces.RhCatTelefonos;
using FicAppPersonas.Services.RhCatTelefonos;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;

namespace FicAppPersonas.ViewModels.RhCatTelefonos
{
    public class FicVmRhCatTelefonosUpdate : FicViewModelBase
    {
        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        private IFicSrvRhCatTelefonosUpdate FicLoSrvApp;
        private ObservableCollection<cat_generales> _Picker_ItemSource_CatGenTelefonos;
        private bool _Principal;
        public bool Principal { get { return _Principal; } set { _Principal = value; RaisePropertyChanged(); } }
        private bool _Activo;
        public bool Activo { get { return _Activo; } set { _Activo = value; RaisePropertyChanged(); } }
        private bool _Borrado;
        public bool Borrado { get { return _Borrado; } set { _Borrado = value; RaisePropertyChanged(); } }
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

        public rh_cat_telefonos _Edificios;
        public rh_cat_telefonos Edificio
        {
            get { return _Edificios; }
            set
            {
                _Edificios = value;
                RaisePropertyChanged();
            }
        }

        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand { get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); } }
        private void FicMetCatClienteExecute() { FicLoSrvNavigation.FicMetNavigateTo<FicVmRhCatTelefonosList>(Persona); }

        private ICommand UpdateEdificio;
        public ICommand FicMetUpdateCommand
        {
            get { return UpdateEdificio = UpdateEdificio ?? new FicVmDelegateCommand(UpdateEdificioExecute); }
        }
        private async  void UpdateEdificioExecute()
        {
            List<string> noFillFields = new List<string>();//LISTA DE CAMPOS QUE NO FUERON LLENADOS

            //CONJUNTO DE VALIDACIONES DE CAMPOS NO LLENADOS O NO SELECCIONADOS
            #region
            if (Edificio.CodPais == null)
            {
                noFillFields.Add("codigo del pais");
            }
            if (Edificio.NumTelefono == null)
            {
                noFillFields.Add("numero de telefono");
            }
            if (Edificio.NumExtension == null)
            {
                noFillFields.Add("numero de extension");
            }
            if (Picker_SelectItem_CatGenTelefono == null)
            {
                noFillFields.Add("tipo de telefono");
            }
           
            #endregion


            //SI TODOS LOS CAMPOS PASARON LA VALIDACION ASIGNAN SE PREPARA LA INSERCION PARA EL OBJETO DirWeb
            if (noFillFields.Count == 0)
            {
                Edificio.UsuarioMod = "GUERRA";
                Edificio.IdGenTelefono = Picker_SelectItem_CatGenTelefono.IdGeneral;
                Edificio.IdTipoGenTelefono = Picker_SelectItem_CatGenTelefono.IdTipoGeneral;
                Edificio.FechaUltMod = DateTime.Now;
                if (Principal == true) { Edificio.Principal = "S"; };
                if (Principal == false) { Edificio.Principal = "N"; };
                if (Activo == true) { Edificio.Activo = "S"; };
                if (Activo == false) { Edificio.Activo = "N"; };
                if (Borrado == true) { Edificio.Borrado = "S"; };
                if (Borrado == false) { Edificio.Borrado = "N"; };
                await FicLoSrvApp.FicMetUpdateEdificio(Edificio);
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

        public FicVmRhCatTelefonosUpdate(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvRhCatTelefonosUpdate FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
            _Picker_ItemSource_CatGenTelefonos = new ObservableCollection<cat_generales>();
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



        public async override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            try
            {
               

                var source_local_telefonos = await FicLoSrvApp.FicMetGetListRhCatGenerales(5); ;
                if (source_local_telefonos != null && _Picker_ItemSource_CatGenTelefonos.Count == 0)
                {
                    foreach (cat_generales tel in source_local_telefonos)
                    {
                        if(Edificio.IdGenTelefono == tel.IdGeneral)
                        {
                            Picker_SelectItem_CatGenTelefono = tel;
                        }
                        _Picker_ItemSource_CatGenTelefonos.Add(tel);
                    }
                }//LLENAR EL PICKER DE INSTITUTOS
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }


        }
        public void llenado(rh_cat_telefonos obj, rh_cat_personas persona)
        {
            Edificio = new rh_cat_telefonos();
            Edificio = obj;
            Persona = new rh_cat_personas();
            Persona = persona;
            if (Edificio.Principal == "S") { Principal = true; };
            if (Edificio.Principal == "N") { Principal = false; };
            if (Edificio.Activo == "S") { Activo = true; };
            if (Edificio.Activo == "N") { Activo = false; };
            if (Edificio.Borrado == "S") { Borrado = true; };
            if (Edificio.Borrado == "N") { Borrado = false; };
        }


    }
}
