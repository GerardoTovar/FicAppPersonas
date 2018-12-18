using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.Interfaces.RhCatDirWeb;
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

namespace FicAppPersonas.ViewModels.RhCatDirWeb
{
    public class FicVmRhCatDirWebNew : INotifyPropertyChanged
    {
       
        public ObservableCollection<cat_generales> _Picker_ItemSource_CatGeneralesDirWeb;
        private IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas;
        private IFicSrvRhCatDirWebNew IFicSrvRhCatDirWebNew;
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

        //private  FicDBContext FicLoBDContext;

        public FicVmRhCatDirWebNew(IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas, IFicSrvRhCatDirWebNew IFicSrvRhCatDirWebNew)
        {
            this.IFicSrvNavigationRhCatPersonas = IFicSrvNavigationRhCatPersonas;
            this.IFicSrvRhCatDirWebNew = IFicSrvRhCatDirWebNew;

            _Picker_ItemSource_CatGeneralesDirWeb = new ObservableCollection<cat_generales>();
            

        }//CONSTRUCTOR

        private rh_cat_dir_web _DirWeb;
        public rh_cat_dir_web DirWeb
        {
            get { return _DirWeb; }
            set
            {
                _DirWeb = value;
                RaisePropertyChanged();
            }
        }
        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand { get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); } }
        private void FicMetCatClienteExecute() { IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatDirWebList>(Persona); }

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
            if (DirWeb.DesDirWeb == null)
            {
                noFillFields.Add("DesDirWeb");
            }
            if (DirWeb.DireccionWeb == null)
            {
                noFillFields.Add("DireccionWeb");
            }
            if (DirWeb.Activo == null)
            {
                noFillFields.Add("Activo");
            }
            if (DirWeb.DireccionWeb == null)
            {
                noFillFields.Add("DireccionWeb");
            }
            if (FicSfDataGrid_SelectItem_CatGenDirWeb == null)
            {
                noFillFields.Add("GenDirWeb");
            }          


            #endregion

            //SI TODOS LOS CAMPOS PASARON LA VALIDACION ASIGNAN SE PREPARA LA INSERCION PARA EL OBJETO PERSONA
            if (noFillFields.Count == 0)
            {
                DirWeb.ClaveReferencia = Persona.IdPersona.ToString();
                DirWeb.Referencia = "rh_cat_personas";
                DirWeb.UsuarioReg = "GUERRA";
                DirWeb.IdGenDirWeb = FicSfDataGrid_SelectItem_CatGenDirWeb.IdGeneral;
                DirWeb.IdTipoGenDirWeb = FicSfDataGrid_SelectItem_CatGenDirWeb.IdTipoGeneral;
                DirWeb.UsuarioMod = DirWeb.UsuarioReg;
                DirWeb.FechaReg = DateTime.Now;
                DirWeb.FechaUltMod = DateTime.Now;
                if (Principal == true) { DirWeb.Principal = "S"; };
                if (Principal == false) { DirWeb.Principal = "N"; };
                if (Activo == true) { DirWeb.Activo = "S"; };
                if (Activo == false) { DirWeb.Activo = "N"; };
                if (Borrado == true) { DirWeb.Borrado = "S"; };
                if (Borrado == false) { DirWeb.Borrado = "N"; };
                await IFicSrvRhCatDirWebNew.FicMetGetNewRhCatDirWeb(DirWeb);
                IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatDirWebList>(Persona);
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

        

   
       

        public ObservableCollection<cat_generales> Picker_ItemSource_CatGenDirWeb
        {
            get
            {
                return _Picker_ItemSource_CatGeneralesDirWeb;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL PIKER INSTITUTOS DE LA VIEW
        #endregion

        public cat_generales _SfDataGrid_SelectItem_GeneralesDir;
        public cat_generales FicSfDataGrid_SelectItem_CatGenDirWeb
        {
            get { return _SfDataGrid_SelectItem_GeneralesDir; }
            set
            {
                _SfDataGrid_SelectItem_GeneralesDir = value;
                RaisePropertyChanged();
            }
        }




        public async void OnAppearing()
        {
            try
            {


                var source_local_institutos = await IFicSrvRhCatDirWebNew.FicMetGetListRhCatGenerales(2);
                if (source_local_institutos != null)
                {
                    foreach (cat_generales Dir in source_local_institutos)
                    {
                        _Picker_ItemSource_CatGeneralesDirWeb.Add(Dir);
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

        public void getPersonaData(rh_cat_personas persona)
        {
            DirWeb = new rh_cat_dir_web();
            //DirWeb.
            Persona = new rh_cat_personas();
            Persona = persona;
            DirWeb.Referencia = "";
            DirWeb.ClaveReferencia = "";
            DirWeb.Principal = "N";
            DirWeb.Activo = "N";
            DirWeb.Borrado = "N";
            if (DirWeb.Principal == "S") { Principal = true; };
            if (DirWeb.Principal == "N") { Principal = false; };
            if (DirWeb.Activo == "S") { Activo = true; };
            if (DirWeb.Activo == "N") { Activo = false; };
            if (DirWeb.Borrado == "S") { Borrado = true; };
            if (DirWeb.Borrado == "N") { Borrado = false; };
        }
    }//CLASS }



}//NAMESPACE

