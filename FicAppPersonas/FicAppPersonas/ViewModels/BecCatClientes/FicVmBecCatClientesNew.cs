using System;
using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.ViewModels.Base;
using System.Windows.Input;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Interfaces.BecCatClientes;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

namespace FicAppPersonas.ViewModels.BecCatClientes
{
    public class FicVmBecCatClientesNew : FicViewModelBase
    {
        private IFicSrvNavigationRhCatPersonas FicLoSrvNavigation;
        private IFicSrvBecCatClientesNew FicLoSrvApp;
        public ObservableCollection<rh_cat_grupos> _Picker_ItemSource_CatGeneralesDirWeb;

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

        private bec_cat_clientes _Edificios;
        public bec_cat_clientes Edificio
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
        private void FicMetCatClienteExecute() { FicLoSrvNavigation.FicMetNavigateTo<FicVmBecCatClientesList>(Persona); }

        private ICommand AddEdificio;
        public ICommand FicMetAddCommand
        {
            get { return AddEdificio = AddEdificio ?? new FicVmDelegateCommand(AddEdificioExecute); }
        }
        private async void AddEdificioExecute()
        {

            List<string> noFillFields = new List<string>();//LISTA DE CAMPOS QUE NO FUERON LLENADOS

            //CONJUNTO DE VALIDACIONES DE CAMPOS NO LLENADOS O NO SELECCIONADOS
            #region
            
            if (FicSfDataGrid_SelectItem_CatGenDirWeb == null)
            {
                noFillFields.Add("Dir web");
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

                if (Edificio.FechaAlta == null)
                {
                    Edificio.FechaAlta = DateTime.Now;
                }
                else
                {
                    DateTime a = new DateTime();
                    a = DateTime.Parse(Edificio.FechaAlta.ToString());
                    var fecha_temp = DateTime.Parse(Edificio.FechaAlta.ToString());
                    var day = Int32.Parse(fecha_temp.Day.ToString());
                    var month = Int32.Parse(fecha_temp.Month.ToString());
                    var year = Int32.Parse(fecha_temp.Year.ToString());

                    var hours = Int32.Parse(DateTime.Now.Hour.ToString());
                    var mins = Int32.Parse(DateTime.Now.Minute.ToString());
                    var sec = Int32.Parse(DateTime.Now.Second.ToString());
                    var milisec = Int32.Parse(DateTime.Now.Millisecond.ToString());
                    DateTime fecha = new DateTime(year, month, day, hours, mins, sec, milisec);
                    Edificio.FechaAlta = fecha;

                }

                Edificio.IdGrupo = FicSfDataGrid_SelectItem_CatGenDirWeb.IdGrupo;
                Edificio.IdTipoGrupo = FicSfDataGrid_SelectItem_CatGenDirWeb.IdTipoGrupo;
                Edificio.UsuarioReg = "gera";
                Edificio.UsuarioMod = Edificio.UsuarioReg;
                Edificio.FechaUltMod = DateTime.Now;
                Edificio.FechaReg = DateTime.Now;
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
                await FicLoSrvApp.FicMetGetNewRhCatEmpleados(Edificio);
                FicLoSrvNavigation.FicMetNavigateTo<FicVmBecCatClientesList>(Persona);
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

        public FicVmBecCatClientesNew(IFicSrvNavigationRhCatPersonas FicPaSrvNavigation, IFicSrvBecCatClientesNew FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
            _Picker_ItemSource_CatGeneralesDirWeb = new ObservableCollection<rh_cat_grupos>();
        }

        public async override void OnAppearing(object navigationContext)
        {
            //base.OnAppearing(navigationContext);
            try
            {


                var source_local_institutos = await FicLoSrvApp.FicMetGetListRhCatGenerales(1);
                if (source_local_institutos != null)
                {
                    foreach (rh_cat_grupos Dir in source_local_institutos)
                    {

                        _Picker_ItemSource_CatGeneralesDirWeb.Add(Dir);
                    }
                }//LLENAR EL PICKER DE INSTITUTOS
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }

        }
        public void getPersonaData(rh_cat_personas persona)
        {
            Persona = new rh_cat_personas();
            Persona = persona;
            _Edificios = new bec_cat_clientes();
            Edificio.IdCliente = Persona.IdPersona;
            //Edificio.FechaAlta = DateTime.Now;
            //_Edificios.FechaAlta = DateTime.Now;
            _Edificios.IdCliente = Persona.IdPersona;
        }

    }
}