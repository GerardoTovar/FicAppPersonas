using FicAppPersonas.Interfaces.BecInstitutosPersonas;
using FicAppPersonas.Interfaces.Navegacion;
using FicAppPersonas.ViewModels.Base;
using FicAppPersonas.ViewModels.RhCatPersonas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.ViewModels.BecInstitutosPersonas
{
    public class FicVmBecInstitutosPersonasList : INotifyPropertyChanged
    {
        public ObservableCollection<bec_institutos_personas> _FicSfDataGrid_ItemSource_CatEdificios;
        public ObservableCollection<institutos_personas_text> _FicSfDataGrid_ItemSource_CatEdificios2;
        public bec_institutos_personas _FicSfDataGrid_SelectItem_CatEdificios;
        public institutos_personas_text _FicSfDataGrid_SelectItem_CatEdificios2;
        //private ICommand _FicMetAddEdificioICommand, _FicMetAcumuladosICommand;
        private IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas;
        private IFicSrvBecInstitutosPersonasList IFicSrvBecInstitutosPersonasList;
        public rh_cat_personas _Edificios;
        public rh_cat_personas Edificio
        {
            get { return _Edificios; }
            set
            {
                _Edificios = value;
                RaisePropertyChanged();
            }
        }

        public FicVmBecInstitutosPersonasList(IFicSrvNavigationRhCatPersonas IFicSrvNavigationRhCatPersonas, IFicSrvBecInstitutosPersonasList IFicSrvBecInstitutosPersonasList)
        {
            this.IFicSrvNavigationRhCatPersonas = IFicSrvNavigationRhCatPersonas; this.IFicSrvBecInstitutosPersonasList = IFicSrvBecInstitutosPersonasList;
            _FicSfDataGrid_ItemSource_CatEdificios = new ObservableCollection<bec_institutos_personas>();
            _FicSfDataGrid_ItemSource_CatEdificios2 = new ObservableCollection<institutos_personas_text>();

        }//CONSTRUCTOR

        public ObservableCollection<bec_institutos_personas> FicSfDataGrid_ItemSource_CatEdificios
        {
            get
            {
                return _FicSfDataGrid_ItemSource_CatEdificios;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL GRID DE LA VIEW
        public ObservableCollection<institutos_personas_text> FicSfDataGrid_ItemSource_CatEdificios2
        {
            get
            {
                return _FicSfDataGrid_ItemSource_CatEdificios2;
            }
        }//ESTE APUNTA ATRAVEZ DEL BindingContext AL GRID DE LA VIEW
        public bec_institutos_personas _SfDataGrid_SelectItem_Edificio;

        public bec_institutos_personas FicSfDataGrid_SelectItem_CatEdificios
        {
            get { return _SfDataGrid_SelectItem_Edificio; }
            set
            {
                _SfDataGrid_SelectItem_Edificio = value;
                RaisePropertyChanged();
            }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL GRID DE LA VIEW

        public institutos_personas_text _SfDataGrid_SelectItem_Edificio2;

        public institutos_personas_text FicSfDataGrid_SelectItem_CatEdificios2
        {
            get { return _SfDataGrid_SelectItem_Edificio2; }
            set
            {
                foreach (bec_institutos_personas temp in _FicSfDataGrid_ItemSource_CatEdificios)
                {
                    if (value == null)
                    {
                        _SfDataGrid_SelectItem_Edificio = null;
                    }
                    else
                    {
                        if (temp.IdPersona == value.IdPersona && temp.IdPerfil == value.IdPerfil && temp.IdInstituto == value.IdInstituto)
                        {
                            _SfDataGrid_SelectItem_Edificio = temp;
                        }
                    }
                }
                _SfDataGrid_SelectItem_Edificio2 = value;
                RaisePropertyChanged();
            }
        }//ESTE APUNTA A UN ITEM SELECCIONADO EN EL GRID DE LA VIEW


        private ICommand UpdateEdificio;
        public ICommand FicMetUpdateCommand
        {

            get { return UpdateEdificio = UpdateEdificio ?? new FicVmDelegateCommand(UpdateEdificioExecute); }
        }
        private void UpdateEdificioExecute()
        {
            if (_SfDataGrid_SelectItem_Edificio == null)
            {
                new Page().DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN ITEM", "OK");
                return;
            }
            else
            {
                IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmBecInstitutosPersonasUpdate>(_SfDataGrid_SelectItem_Edificio, Edificio);
            }

        }

        private ICommand _BackNavgCommand;
        public ICommand BackNavgCommand { get { return _BackNavgCommand = _BackNavgCommand ?? new FicVmDelegateCommand(FicMetCatClienteExecute); } }
        private void FicMetCatClienteExecute() { IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasList>(null); }

        private ICommand DetalleEdificio;
        public ICommand FicMetDetalleCommand
        {

            get { return DetalleEdificio = DetalleEdificio ?? new FicVmDelegateCommand(DetalleEdificioExecute); }
        }
        private void DetalleEdificioExecute()
        {
            if (_SfDataGrid_SelectItem_Edificio == null)
            {
                new Page().DisplayAlert("ATENCION", "NO SELECIONASTE NINGUN ITEM", "OK");
                return;
            }
            else
            {
                IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmBecInstitutosPersonasDetail>(_SfDataGrid_SelectItem_Edificio, Edificio);
            }

        }

        private ICommand NewEdificio;
        public ICommand FicMetNewCommand
        {
            get { return NewEdificio = NewEdificio ?? new FicVmDelegateCommand(NewEdificioExecute); }
        }
        private void NewEdificioExecute()
        {

           IFicSrvNavigationRhCatPersonas.FicMetNavigateTo<FicVmBecInstitutosPersonasNew>(Edificio);
        }


        public async void OnAppearing()
        {
            try
            {
                var source_local_inv = await IFicSrvBecInstitutosPersonasList.FicMetGetListBecInstitutosPersonas(Edificio.IdPersona);
                if (source_local_inv != null && _FicSfDataGrid_ItemSource_CatEdificios.Count == 0)
                {
                    foreach (bec_institutos_personas inv in source_local_inv)
                    {
                        institutos_personas_text temp = new institutos_personas_text()
                        {
                            IdInstituto = inv.IdInstituto,
                            IdPersona =  inv.IdPersona,
                            IdPerfil = inv.IdPerfil,
                            Activo = inv.Activo,
                            FechaReg = inv.FechaReg,
                            UsuarioReg = inv.UsuarioReg,
                            FechaUltMod = inv.FechaUltMod,
                            UsuarioMod = inv.UsuarioMod,
                            Borrado = inv.Borrado
                        };

                        _FicSfDataGrid_ItemSource_CatEdificios2.Add(temp);
                        _FicSfDataGrid_ItemSource_CatEdificios.Add(inv);
                    }
                }//LLENAR EL GRID
                var source_local_ocupacion = await IFicSrvBecInstitutosPersonasList.FicMetGetList();
                if (source_local_ocupacion != null)
                {
                    int i = 0;
                    foreach (rh_cat_perfiles ocupacion in source_local_ocupacion)
                    {
                        i = 0;
                        foreach (institutos_personas_text temp in _FicSfDataGrid_ItemSource_CatEdificios2)
                        {
                            if (temp.IdPerfil == ocupacion.IdPerfil)
                            {
                                _FicSfDataGrid_ItemSource_CatEdificios2[i].Perfil = ocupacion.DesPerfil;
                            }
                            i++;
                        }
                    
                    }
                }//LLENAR EL PICKER DE OCUPACIONES

                var source_local_institutos = await IFicSrvBecInstitutosPersonasList.FicMetGetListRhCatInstitutos();
                if (source_local_institutos != null)
                {
                    int i = 0;
                    foreach (cat_institutos instituto in source_local_institutos)
                    {
                        i = 0;
                        foreach (institutos_personas_text temp in _FicSfDataGrid_ItemSource_CatEdificios2)
                        {
                            if (temp.IdInstituto == instituto.IdInstituto)
                            {
                                _FicSfDataGrid_ItemSource_CatEdificios2[i].Instituto = instituto.DesInstituto;
                            }
                            i++;
                        }
                    }
                }//LLENAR EL PICKER DE INSTITUTOS
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//SOBRE CARGA AL METODO OnAppearing() DE LA VIEW 
        public void llenado(rh_cat_personas obj)
        {
            Edificio = new rh_cat_personas();
            Edificio = obj;
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

