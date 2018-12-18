using FicAppPersonas.Interfaces.ImportarWebApi;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using static FicAppPersonas.Models.Asistencia.FicModAsistencia;
using FicAppPersonas.Data;
using System;
using FicAppPersonas.Interfaces.SQLite;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FicAppPersonas.Services.ImportarWebApi
{
    class FicSrvImportarWebApi : IFicSrvImportarWebApi
    {
        private FicDBContext FicLoBDContext;
        private readonly HttpClient FiClient;

        public FicSrvImportarWebApi()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            FiClient = new HttpClient();
            FiClient.MaxResponseContentBufferSize = 256000;
        }//CONSTRUCTOR

        


        private async Task<rh_cat_personas> FicExistrh_cat_personas(int idPer)
        {
            return await (from per in FicLoBDContext.rh_cat_personas where per.IdPersona == idPer select per).AsNoTracking().SingleOrDefaultAsync();
        }//buscar en local

        private async Task<rh_cat_domicilios> FicExistrh_cat_domicilios(int id)
        {
            return await (from per in FicLoBDContext.rh_cat_domicilios where per.IdDomicilio == id select per).AsNoTracking().SingleOrDefaultAsync();
        }//buscar en local

        private async Task<rh_cat_telefonos> FicExistrh_cat_telefonos(int id)
        {
            return await (from per in FicLoBDContext.rh_cat_telefonos where per.IdTelefono == id select per).AsNoTracking().SingleOrDefaultAsync();
        }//buscar en local

        private async Task<rh_cat_personas_perfiles> FicExistrh_cat_personas_perfiles(int id, int idperfil)
        {
            return await (from per in FicLoBDContext.rh_cat_personas_perfiles where per.IdPersona == id && per.IdPerfil == idperfil select per).AsNoTracking().SingleOrDefaultAsync();
        }//buscar en local

        private async Task<rh_cat_alumnos> FicExistrh_cat_alumnos(int id)
        {
            return await (from per in FicLoBDContext.rh_cat_alumnos where per.IdAlumno == id select per).AsNoTracking().SingleOrDefaultAsync();
        }//buscar en local

        private async Task<rh_cat_empleados> FicExistrh_cat_empleados(int id)
        {
            return await (from per in FicLoBDContext.rh_cat_empleados where per.IdEmpleado == id select per).AsNoTracking().SingleOrDefaultAsync();
        }//buscar en local

        private async Task<rh_cat_catedraticos> FicExistrh_cat_catedraticos(int id)
        {
            return await (from per in FicLoBDContext.rh_cat_catedraticos where per.IdEmpleado == id select per).AsNoTracking().SingleOrDefaultAsync();
        }//buscar en local

        private async Task<rh_cat_dir_web> FicExistrh_cat_dir_web(int id)
        {
            return await (from per in FicLoBDContext.rh_cat_dir_web where per.IdDirWeb == id select per).AsNoTracking().SingleOrDefaultAsync();
        }//buscar en local

        private async Task<rh_personas_perfil_estatus> FicExistrh_personas_perfil_estatus(int id, int idpersona, int idperfil)
        {
            return await (from per in FicLoBDContext.rh_personas_perfil_estatus where per.IdEstatusDet == id && per.IdPersona == idpersona && per.IdPerfil == idperfil select per).AsNoTracking().SingleOrDefaultAsync();
        }//buscar en local

        private async Task<rh_cat_personas_datos_adicionales> FicExistrh_cat_personas_datos_adicionales(int id, int idpersona)
        {
            return await (from per in FicLoBDContext.rh_cat_personas_datos_adicionales where per.IdDatoAdicional == id && per.IdPersona == idpersona select per).AsNoTracking().SingleOrDefaultAsync();
        }//buscar en local

        private async Task<bec_cat_clientes> FicExistbec_cat_clientes(int id)
        {
            return await (from per in FicLoBDContext.bec_cat_clientes where per.IdCliente == id select per).AsNoTracking().SingleOrDefaultAsync();
        }//buscar en local

        private async Task<bec_institutos_personas> FicExistbec_institutos_personas(int idpersona, int idinstituto, int idperfil)
        {
            return await (from per in FicLoBDContext.bec_institutos_personas where per.IdPersona == idpersona && per.IdInstituto == idinstituto && per.IdPerfil == idperfil select per).AsNoTracking().SingleOrDefaultAsync();
        }//buscar en local


        private async Task<reg_personas> FicGetListPersonasActualiza(int id)
        {
            try
            {
                reg_personas cats = new reg_personas();

                #region rh_cat_personas
                string url = "http://localhost:53285//api/GetRhCatPersonas";
                if (id != 0) url +="/"+id;                                
                var task = await FiClient.GetAsync(url);
                var jsonString = await task.Content.ReadAsStringAsync();
                List<rh_cat_personas> ctg = new List<rh_cat_personas>();
                ctg = (JsonConvert.DeserializeObject<List<rh_cat_personas>>(jsonString));
                cats.rh_cat_personas = ctg;
                #endregion

                #region rh_cat_domicilios
                url = "http://localhost:53285//api/GetRhCatDomicilios";
                if (id != 0) url += "/" + id;
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<rh_cat_domicilios> cg = new List<rh_cat_domicilios>();
                cg = (JsonConvert.DeserializeObject<List<rh_cat_domicilios>>(jsonString));
                cats.rh_cat_domicilios = cg;
                #endregion

                #region rh_cat_telefonos
                url = "http://localhost:53285//api/GetRhCatTelefonos";
                if (id != 0) url += "/" + id;
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<rh_cat_telefonos> cte = new List<rh_cat_telefonos>();
                cte = (JsonConvert.DeserializeObject<List<rh_cat_telefonos>>(jsonString));
                cats.rh_cat_telefonos = cte;
                #endregion

                #region rh_cat_personas_perfiles
                url = "http://localhost:53285//api/GetRhCatPersonasPerfiles";
                if (id != 0) url += "/" + id;
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<rh_cat_personas_perfiles> ce = new List<rh_cat_personas_perfiles>();
                ce = (JsonConvert.DeserializeObject<List<rh_cat_personas_perfiles>>(jsonString));
                cats.rh_cat_personas_perfiles = ce;
                #endregion

                #region rh_cat_alumnos
                url = "http://localhost:53285//api/GetRhCatAlumnos";
                if (id != 0) url += "/" + id;
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<rh_cat_alumnos> rctg = new List<rh_cat_alumnos>();
                rctg = (JsonConvert.DeserializeObject<List<rh_cat_alumnos>>(jsonString));
                cats.rh_cat_alumnos = rctg;
                #endregion

                #region rh_cat_empleados
                url = "http://localhost:53285//api/GetRhCatEmpleados";
                if (id != 0) url += "/" + id;
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<rh_cat_empleados> rcg = new List<rh_cat_empleados>();
                rcg = (JsonConvert.DeserializeObject<List<rh_cat_empleados>>(jsonString));
                cats.rh_cat_empleados = rcg;
                #endregion

                #region rh_cat_catedraticos
                url = "http://localhost:53285//api/GetRhCatCatedraticos";
                if (id != 0) url += "/" + id;
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<rh_cat_catedraticos> rcp = new List<rh_cat_catedraticos>();
                rcp = (JsonConvert.DeserializeObject<List<rh_cat_catedraticos>>(jsonString));
                cats.rh_cat_catedraticos = rcp;
                #endregion

                #region rh_cat_dir_web
                url = "http://localhost:53285//api/GetRhCatdDirWeb";
                if (id != 0) url += "/" + id;
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<rh_cat_dir_web> cp = new List<rh_cat_dir_web>();
                cp = (JsonConvert.DeserializeObject<List<rh_cat_dir_web>>(jsonString));
                cats.rh_cat_dir_web = cp;
                #endregion

                #region rh_personas_perfil_estatus
                url = "http://localhost:53285//api/GetRhPersonasPerfilEstatus";
                if (id != 0) url += "/" + id;
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<rh_personas_perfil_estatus> cestatus = new List<rh_personas_perfil_estatus>();
                cestatus = (JsonConvert.DeserializeObject<List<rh_personas_perfil_estatus>>(jsonString));
                cats.rh_personas_perfil_estatus = cestatus;
                #endregion

                #region rh_cat_personas_datos_adicionales
                url = "http://localhost:53285//api/GetRhCatPersonasDatosAdicionales";
                if (id != 0) url += "/" + id;
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<rh_cat_personas_datos_adicionales> cm = new List<rh_cat_personas_datos_adicionales>();
                cm = (JsonConvert.DeserializeObject<List<rh_cat_personas_datos_adicionales>>(jsonString));
                cats.rh_cat_personas_datos_adicionales = cm;
                #endregion

                #region bec_cat_clientes
                url = "http://localhost:53285//api/GetBecCatClientes";
                if (id != 0) url += "/" + id;
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<bec_cat_clientes> cl = new List<bec_cat_clientes>();
                cl = (JsonConvert.DeserializeObject<List<bec_cat_clientes>>(jsonString));
                cats.bec_cat_clientes = cl;
                #endregion

                #region bec_institutos_personas
                url = "http://localhost:53285//api/GetBecInstitutosPersonas";
                if (id != 0) url += "/" + id;
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<bec_institutos_personas> cc = new List<bec_institutos_personas>();
                cc = (JsonConvert.DeserializeObject<List<bec_institutos_personas>>(jsonString));
                cats.bec_institutos_personas = cc;
                #endregion
               

                //IMPORTANTE: retornar cuando se haya terminado de importar todos los catalogos

                return cats;
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                return null;
            }
        }//GET: A PERSONAS

        public async Task<string> FicGetImportPersonas(int id)
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            string FicMensaje = "";
            try
            {
                FicMensaje = "IMPORTACION: \n";
               
                var FicGetReultREST = await FicGetListPersonasActualiza(id);

                #region rh_cat_personas
                if (FicGetReultREST != null && FicGetReultREST.rh_cat_personas != null)
                {
                    FicMensaje += "IMPORTANDO: rh_cat_personas \n";
                    foreach (rh_cat_personas per in FicGetReultREST.rh_cat_personas)
                    {
                        var respuesta = await FicExistrh_cat_personas(per.IdPersona);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.Sexo = per.Sexo;
                                respuesta.Activo = per.Activo;
                                respuesta.Alias = per.Alias;
                                respuesta.ApMaterno = per.ApMaterno;
                                respuesta.ApPaterno = per.ApPaterno;
                                respuesta.Borrado = per.Borrado;
                                respuesta.CURP = per.CURP;
                                respuesta.FechaNac = per.FechaNac;
                                respuesta.FechaReg = per.FechaReg;
                                respuesta.FechaUltMod = per.FechaUltMod;
                                respuesta.IdGenEstadoCivil = per.IdGenEstadoCivil;
                                respuesta.IdGenOcupacion = per.IdGenOcupacion;
                                respuesta.IdInstituto = per.IdInstituto;                                
                                respuesta.RFC = per.RFC;
                                //IdPersona = per.IdPersona;
                                respuesta.IdTipoGenEstadoCivil = per.IdTipoGenEstadoCivil;
                                respuesta.IdTipoGenOcupacion = per.IdTipoGenOcupacion;
                                respuesta.Nombre = per.Nombre;
                                respuesta.NumControl = per.NumControl;
                                respuesta.RutaFoto = per.RutaFoto;
                                respuesta.TipoPersona = per.TipoPersona;
                                respuesta.UsuarioMod = per.UsuarioMod;
                                respuesta.UsuarioReg = per.UsuarioReg;

                                FicLoBDContext.Update(respuesta);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdPersona: " + per.IdPersona + " \n" : "-NO NECESITO ACTUALIZAR->  IdPersona: " + per.IdPersona + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(per);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdPersona: " + per.IdPersona + " \n" : "-ERROR EN INSERT-> IdPersona: " + per.IdPersona + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region rh_cat_domicilios
                if (FicGetReultREST != null && FicGetReultREST.rh_cat_domicilios != null)
                {
                    FicMensaje += "IMPORTANDO: rh_cat_domicilios \n";
                    foreach (rh_cat_domicilios per in FicGetReultREST.rh_cat_domicilios)
                    {
                        var respuesta = await FicExistrh_cat_domicilios(per.IdDomicilio);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.Domicilio = per.Domicilio;
                                respuesta.EntreCalle1 = per.EntreCalle1;
                                respuesta.EntreCalle2 = per.EntreCalle2;
                                respuesta.CodigoPostal = per.CodigoPostal;
                                respuesta.Coordenadas = per.Coordenadas;
                                respuesta.Principal = per.Principal;
                                respuesta.IdTipoGenDom = per.IdTipoGenDom;
                                respuesta.IdGenDom = per.IdGenDom;
                                respuesta.Pais = per.Pais;
                                respuesta.Estado = per.Estado;
                                respuesta.Municipio = per.Municipio;
                                respuesta.Localidad = per.Localidad;
                                respuesta.Colonia = per.Colonia;
                                respuesta.Referencia = per.Referencia;
                                respuesta.ClaveReferencia = per.ClaveReferencia;
                                respuesta.TipoDomicilio = per.TipoDomicilio;

                                respuesta.FechaReg = per.FechaReg;
                                respuesta.FechaUltMod = per.FechaUltMod;
                                respuesta.UsuarioReg = per.UsuarioReg;
                                respuesta.UsuarioMod = per.UsuarioMod;
                                respuesta.Activo = per.Activo;
                                respuesta.Borrado = per.Borrado;

                                FicLoBDContext.Update(respuesta);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdDomicilio: " + per.IdDomicilio + " \n" : "-NO NECESITO ACTUALIZAR->  IdDomicilio: " + per.IdDomicilio + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(per);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdDomicilio: " + per.IdDomicilio + " \n" : "-ERROR EN INSERT-> IdPersona: " + per.IdDomicilio + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region rh_cat_telefonos
                if (FicGetReultREST != null && FicGetReultREST.rh_cat_telefonos != null)
                {
                    FicMensaje += "IMPORTANDO: rh_cat_telefonos \n";
                    foreach (rh_cat_telefonos per in FicGetReultREST.rh_cat_telefonos)
                    {
                        var respuesta = await FicExistrh_cat_telefonos(per.IdTelefono);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.CodPais = per.CodPais;
                                respuesta.NumTelefono = per.NumTelefono;
                                respuesta.NumExtension = per.NumExtension;
                                respuesta.Principal = per.Principal;
                                respuesta.IdTipoGenTelefono = per.IdTipoGenTelefono;
                                respuesta.IdGenTelefono = per.IdGenTelefono;
                                respuesta.ClaveReferencia = per.ClaveReferencia;
                                respuesta.Referencia = per.Referencia;
                                respuesta.FechaReg = per.FechaReg;
                                respuesta.FechaUltMod = per.FechaUltMod;
                                respuesta.UsuarioReg = per.UsuarioReg;
                                respuesta.UsuarioMod = per.UsuarioMod;
                                respuesta.Activo = per.Activo;
                                respuesta.Borrado = per.Borrado;

                                FicLoBDContext.Update(respuesta);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdTelefono: " + per.IdTelefono + " \n" : "-NO NECESITO ACTUALIZAR->  IdTelefono: " + per.IdTelefono + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(per);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdTelefono: " + per.IdTelefono + " \n" : "-ERROR EN INSERT-> IdTelefono: " + per.IdTelefono + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region rh_cat_personas_perfiles
                if (FicGetReultREST != null && FicGetReultREST.rh_cat_personas_perfiles != null)
                {
                    FicMensaje += "IMPORTANDO: rh_cat_personas_perfiles \n";
                    foreach (rh_cat_personas_perfiles per in FicGetReultREST.rh_cat_personas_perfiles)
                    {
                        var respuesta = await FicExistrh_cat_personas_perfiles(per.IdPersona, int.Parse(per.IdPerfil.ToString()));
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.Activo = per.Activo;
                                respuesta.FechaReg = per.FechaReg;
                                respuesta.UsuarioReg = per.UsuarioReg;
                                respuesta.FechaUltMod = per.FechaUltMod;
                                respuesta.UsuarioMod = per.UsuarioMod;
                                respuesta.Borrado = per.Borrado;

                                FicLoBDContext.Update(respuesta);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdPersona, IdPerfil: " + per.IdPersona +"-"+ per.IdPerfil + " \n" : "-NO NECESITO ACTUALIZAR->  IdPersona, IdPerfil: " + per.IdPersona + "-" + per.IdPerfil + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(per);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdPersona, IdPerfil: " + per.IdPersona +"-"+ per.IdPerfil + " \n" : "-ERROR EN INSERT-> IdPersona, IdPerfil: " + per.IdPersona + "-" + per.IdPerfil + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region rh_cat_alumnos
                if (FicGetReultREST != null && FicGetReultREST.rh_cat_alumnos != null)
                {
                    FicMensaje += "IMPORTANDO: rh_cat_alumnos \n";
                    foreach (rh_cat_alumnos per in FicGetReultREST.rh_cat_alumnos)
                    {
                        var respuesta = await FicExistrh_cat_alumnos(per.IdAlumno);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.NumControl = per.NumControl;
                                respuesta.FechaReg = per.FechaReg;
                                respuesta.FechaUltMod = per.FechaUltMod;
                                respuesta.UsuarioReg = per.UsuarioReg;
                                respuesta.UsuarioMod = per.UsuarioMod;
                                respuesta.Activo = per.Activo;
                                respuesta.Borrado = per.Borrado;
                                respuesta.IdCarrera = per.IdCarrera;

                                FicLoBDContext.Update(respuesta);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdAlumno: " + per.IdAlumno + " \n" : "-NO NECESITO ACTUALIZAR->  IdAlumno: " + per.IdAlumno + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(per);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdAlumno: " + per.IdAlumno + " \n" : "-ERROR EN INSERT-> IdAlumno: " + per.IdAlumno + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region rh_cat_empleados
                if (FicGetReultREST != null && FicGetReultREST.rh_cat_empleados != null)
                {
                    FicMensaje += "IMPORTANDO: rh_cat_empleados \n";
                    foreach (rh_cat_empleados per in FicGetReultREST.rh_cat_empleados)
                    {
                        var respuesta = await FicExistrh_cat_empleados(per.IdEmpleado);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.NumControl = per.NumControl;
                                respuesta.FechaReg = per.FechaReg;
                                respuesta.FechaUltMod = per.FechaUltMod;
                                respuesta.UsuarioReg = per.UsuarioReg;
                                respuesta.UsuarioMod = per.UsuarioMod;
                                respuesta.Borrado = per.Borrado;

                                FicLoBDContext.Update(respuesta);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdEmpleado: " + per.IdEmpleado + " \n" : "-NO NECESITO ACTUALIZAR->  IdEmpleado: " + per.IdEmpleado + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(per);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdEmpleado: " + per.IdEmpleado + " \n" : "-ERROR EN INSERT-> IdEmpleado: " + per.IdEmpleado + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region rh_cat_catedraticos
                if (FicGetReultREST != null && FicGetReultREST.rh_cat_catedraticos != null)
                {
                    FicMensaje += "IMPORTANDO: rh_cat_catedraticos \n";
                    foreach (rh_cat_catedraticos per in FicGetReultREST.rh_cat_catedraticos)
                    {
                        var respuesta = await FicExistrh_cat_catedraticos(per.IdEmpleado);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.FechaReg = per.FechaReg;
                                respuesta.FechaUltMod = per.FechaUltMod;
                                respuesta.UsuarioReg = per.UsuarioReg;
                                respuesta.UsuarioMod = per.UsuarioMod;
                                respuesta.Activo = per.Activo;
                                respuesta.Borrado = per.Borrado;

                                FicLoBDContext.Update(respuesta);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdEmpleado: " + per.IdEmpleado + " \n" : "-NO NECESITO ACTUALIZAR->  IdEmpleado: " + per.IdEmpleado + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(per);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdEmpleado: " + per.IdEmpleado + " \n" : "-ERROR EN INSERT-> IdEmpleado: " + per.IdEmpleado + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region rh_cat_dir_web
                if (FicGetReultREST != null && FicGetReultREST.rh_cat_dir_web != null)
                {
                    FicMensaje += "IMPORTANDO: rh_cat_dir_web \n";
                    foreach (rh_cat_dir_web per in FicGetReultREST.rh_cat_dir_web)
                    {
                        var respuesta = await FicExistrh_cat_dir_web(per.IdDirWeb);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.DesDirWeb = per.DesDirWeb;
                                respuesta.DireccionWeb = per.DireccionWeb;
                                respuesta.Principal = per.Principal;
                                respuesta.IdTipoGenDirWeb = per.IdTipoGenDirWeb;
                                respuesta.IdGenDirWeb = per.IdGenDirWeb;
                                respuesta.ClaveReferencia = per.ClaveReferencia;
                                respuesta.Referencia = per.Referencia;
                                respuesta.FechaReg = per.FechaReg;
                                respuesta.FechaUltMod = per.FechaUltMod;
                                respuesta.Activo = per.Activo;
                                respuesta.Borrado = per.Borrado;
                                respuesta.UsuarioReg = per.UsuarioReg;
                                respuesta.UsuarioMod = per.UsuarioMod;

                                FicLoBDContext.Update(respuesta);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdDirWeb: " + per.IdDirWeb + " \n" : "-NO NECESITO ACTUALIZAR->  IdDirWeb: " + per.IdDirWeb + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(per);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdDirWeb: " + per.IdDirWeb + " \n" : "-ERROR EN INSERT-> IdDirWeb: " + per.IdDirWeb + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region rh_personas_perfil_estatus
                if (FicGetReultREST != null && FicGetReultREST.rh_personas_perfil_estatus != null)
                {
                    FicMensaje += "IMPORTANDO: rh_personas_perfil_estatus \n";
                    foreach (rh_personas_perfil_estatus per in FicGetReultREST.rh_personas_perfil_estatus)
                    {
                        var respuesta = await FicExistrh_personas_perfil_estatus(per.IdEstatusDet, per.IdPersona, per.IdPerfil);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.FechaEstatus = per.FechaEstatus;
                                respuesta.IdTipoEstatus = per.IdTipoEstatus;
                                respuesta.IdEstatus = per.IdEstatus;
                                respuesta.Actual = per.Actual;
                                respuesta.Observacion = per.Observacion;
                                respuesta.FechaReg = per.FechaReg;
                                respuesta.FechaUltMod = per.FechaUltMod;
                                respuesta.UsuarioReg = per.UsuarioReg;
                                respuesta.UsuarioMod = per.UsuarioMod;
                                respuesta.Activo = per.Activo;
                                respuesta.Borrado = per.Borrado;

                                FicLoBDContext.Update(respuesta);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdEstatusDet, IdPersona, IdPerfil: " + per.IdEstatusDet + "-" +per.IdPersona + "-" + per.IdPerfil + " \n" : "-NO NECESITO ACTUALIZAR->  IdEstatusDet, IdPersona, IdPerfil: " + per.IdEstatusDet + "-" + per.IdPersona + "-" + per.IdPerfil + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(per);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdEstatusDet, IdPersona, IdPerfil: " + per.IdEstatusDet + "-" + per.IdPersona + "-" + per.IdPerfil + " \n" : "-ERROR EN INSERT-> IdEstatusDet, IdPersona, IdPerfil: " + per.IdEstatusDet + "-" + per.IdPersona + "-" + per.IdPerfil + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region rh_cat_personas_datos_adicionales
                if (FicGetReultREST != null && FicGetReultREST.rh_cat_personas_datos_adicionales != null)
                {
                    FicMensaje += "IMPORTANDO: rh_cat_personas_datos_adicionales \n";
                    foreach (rh_cat_personas_datos_adicionales per in FicGetReultREST.rh_cat_personas_datos_adicionales)
                    {
                        var respuesta = await FicExistrh_cat_personas_datos_adicionales(per.IdDatoAdicional, int.Parse(per.IdPersona.ToString()));
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.Etiqueta = per.Etiqueta;
                                respuesta.Valor = per.Valor;
                                respuesta.IdTipoGenSeccion = per.IdTipoGenSeccion;
                                respuesta.IdGenSeccion = per.IdGenSeccion;
                                respuesta.FechaReg = per.FechaReg;
                                respuesta.FechaUltMod = per.FechaUltMod;
                                respuesta.UsuarioReg = per.UsuarioReg;
                                respuesta.UsuarioMod = per.UsuarioMod;
                                respuesta.Activo = per.Activo;
                                respuesta.Borrado = per.Borrado;

                                FicLoBDContext.Update(respuesta);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdDatoAdicional, IdPersona: " + per.IdDatoAdicional + "-" + per.IdPersona + " \n" : "-NO NECESITO ACTUALIZAR->  IdDatoAdicional, IdPersona: " + per.IdDatoAdicional + "-" + per.IdPersona + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(per);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdDatoAdicional, IdPersona: " + per.IdDatoAdicional + "-" + per.IdPersona + " \n" : "-ERROR EN INSERT-> IdDatoAdicional, IdPersona: " + per.IdDatoAdicional + "-" + per.IdPersona + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region bec_cat_clientes
                if (FicGetReultREST != null && FicGetReultREST.bec_cat_clientes != null)
                {
                    FicMensaje += "IMPORTANDO: bec_cat_clientes \n";
                    foreach (bec_cat_clientes per in FicGetReultREST.bec_cat_clientes)
                    {
                        var respuesta = await FicExistbec_cat_clientes(per.IdCliente);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.FechaAlta = per.FechaAlta;
                                respuesta.FechaReg = per.FechaReg;
                                respuesta.IdTipoGrupo = per.IdTipoGrupo;
                                respuesta.IdGrupo = per.IdGrupo;
                                respuesta.FechaUltMod = per.FechaUltMod;
                                respuesta.Activo = per.Activo;
                                respuesta.Borrado = per.Borrado;
                                respuesta.UsuarioReg = per.UsuarioReg;
                                respuesta.UsuarioMod = per.UsuarioMod;

                                FicLoBDContext.Update(respuesta);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdCliente: " + per.IdCliente + " \n" : "-NO NECESITO ACTUALIZAR->  IdCliente: " + per.IdCliente + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(per);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdCliente: " + per.IdCliente + " \n" : "-ERROR EN INSERT-> IdCliente: " + per.IdCliente + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region bec_institutos_personas
                if (FicGetReultREST != null && FicGetReultREST.bec_institutos_personas != null)
                {
                    FicMensaje += "IMPORTANDO: bec_institutos_personas \n";
                    foreach (bec_institutos_personas per in FicGetReultREST.bec_institutos_personas)
                    {
                        var respuesta = await FicExistbec_institutos_personas(per.IdPersona, per.IdInstituto, per.IdPerfil);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.Activo = per.Activo;
                                respuesta.FechaReg = per.FechaReg;
                                respuesta.UsuarioReg = per.UsuarioReg;
                                respuesta.FechaUltMod = per.FechaUltMod;
                                respuesta.UsuarioMod = per.UsuarioMod;
                                respuesta.Borrado = per.Borrado;

                                FicLoBDContext.Update(respuesta);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdPersona, IdInstituto, IdPerfil: " + per.IdPersona +"-"+ per.IdInstituto +"-"+ per.IdPerfil + " \n" : "-NO NECESITO ACTUALIZAR->  IdPersona, IdInstituto, IdPerfil: " + per.IdPersona + "-" + per.IdInstituto + "-" + per.IdPerfil + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(per);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdPersona, IdInstituto, IdPerfil: " + per.IdPersona + "-" + per.IdInstituto + "-" + per.IdPerfil + " \n" : "-ERROR EN INSERT-> IdPersona, IdInstituto, IdPerfil: " + per.IdPersona + "-" + per.IdInstituto + "-" + per.IdPerfil + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion
            }
            catch (Exception e)
            {
                FicMensaje += "ALERTA: " + e.Message.ToString() + "\n";
            }
            return FicMensaje;
        }//FicGetImportInventarios()

        private async Task <catalogos> FicGetListCatalogosActualiza()
        {
            try
            {
                catalogos cats = new catalogos();

                #region cat_tipos_generales
                string url = "http://localhost:53285//api/GetCatTiposGenerales";                               
                var task = await FiClient.GetAsync(url);
                var jsonString = await task.Content.ReadAsStringAsync();
                List<cat_tipos_generales> ctg = new List<cat_tipos_generales>();
                ctg = (JsonConvert.DeserializeObject<List<cat_tipos_generales>>(jsonString));
                cats.cat_tipos_generales = ctg;
                #endregion

                #region cat_generales
                url = "http://localhost:53285//api/GetCatGenerales";
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<cat_generales> cg = new List<cat_generales>();
                cg = (JsonConvert.DeserializeObject<List<cat_generales>>(jsonString));
                cats.cat_generales = cg;
                #endregion

                #region cat_tipos_estatus
                url = "http://localhost:53285//api/GetCatTiposEstatus";
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<cat_tipos_estatus> cte = new List<cat_tipos_estatus>();
                cte = (JsonConvert.DeserializeObject<List<cat_tipos_estatus>>(jsonString));
                cats.cat_tipos_estatus = cte;
                #endregion

                #region cat_estatus
                url = "http://localhost:53285//api/GetCatEstatus";
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<cat_estatus> ce = new List<cat_estatus>();
                ce = (JsonConvert.DeserializeObject<List<cat_estatus>>(jsonString));
                cats.cat_estatus = ce;
                #endregion

                #region rh_cat_tipos_grupos
                url = "http://localhost:53285//api/GetRhCatTipoGrupos";
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<rh_cat_tipo_grupos> rctg = new List<rh_cat_tipo_grupos>();
                rctg = (JsonConvert.DeserializeObject<List<rh_cat_tipo_grupos>>(jsonString));
                cats.rh_cat_tipo_grupos = rctg;
                #endregion

                #region rh_cat_grupos
                url = "http://localhost:53285//api/GetRhCatGrupos";
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<rh_cat_grupos> rcg = new List<rh_cat_grupos>();
                rcg = (JsonConvert.DeserializeObject<List<rh_cat_grupos>>(jsonString));
                cats.rh_cat_grupos = rcg;
                #endregion

                #region rh_cat_perfiles
                url = "http://localhost:53285//api/GetRhCatPerfiles";
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<rh_cat_perfiles> rcp = new List<rh_cat_perfiles>();
                rcp = (JsonConvert.DeserializeObject<List<rh_cat_perfiles>>(jsonString));
                cats.rh_cat_perfiles = rcp;
                #endregion

                #region cat_paises
                url = "http://localhost:53285//api/GetCatPaises";
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<cat_paises> cp = new List<cat_paises>();
                cp = (JsonConvert.DeserializeObject<List<cat_paises>>(jsonString));
                cats.cat_paises = cp;
                #endregion

                #region cat_estados
                url = "http://localhost:53285//api/GetCatEstados";
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<cat_estados> cestatus = new List<cat_estados>();
                cestatus = (JsonConvert.DeserializeObject<List<cat_estados>>(jsonString));
                cats.cat_estados = cestatus;
                #endregion

                #region cat_municipios
                url = "http://localhost:53285//api/GetCatMunicipios";
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<cat_municipios> cm = new List<cat_municipios>();
                cm = (JsonConvert.DeserializeObject<List<cat_municipios>>(jsonString));
                cats.cat_municipios = cm;
                #endregion

                #region cat_localidades
                url = "http://localhost:53285//api/GetCatLocalidades";
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<cat_localidades> cl = new List<cat_localidades>();
                cl = (JsonConvert.DeserializeObject<List<cat_localidades>>(jsonString));
                cats.cat_localidades = cl;
                #endregion

                #region cat_colonias
                url = "http://localhost:53285//api/GetCatColonias";
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<cat_colonias> cc = new List<cat_colonias>();
                cc = (JsonConvert.DeserializeObject<List<cat_colonias>>(jsonString));
                cats.cat_colonias = cc;
                #endregion

                #region cat_institutos
                url = "http://localhost:53285//api/GetCatInstitutos";
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<cat_institutos> ci = new List<cat_institutos>();
                ci = (JsonConvert.DeserializeObject<List<cat_institutos>>(jsonString));
                cats.cat_institutos = ci;
                #endregion

                #region eva_cat_carreras
                url = "http://localhost:53285//api/GetEvaCatCarreras";
                task = await FiClient.GetAsync(url);
                jsonString = await task.Content.ReadAsStringAsync();
                List<eva_cat_carreras> ccarreras = new List<eva_cat_carreras>();
                ccarreras = (JsonConvert.DeserializeObject<List<eva_cat_carreras>>(jsonString));
                cats.eva_cat_carreras = ccarreras;
                #endregion

                //IMPORTANTE: retornar cuando se haya terminado de importar todos los catalogos

                return cats;
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                return null;
            }
        }//GET: A CATALOGOS

        public async Task<string> FicGetImportCatalogos()
        {
            string FicMensaje = "";
            try
            {
                FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
                FicMensaje = "IMPORTACION: \n";
                var FicGetReultREST = await FicGetListCatalogosActualiza();


                #region cat_tipos_generales
                if (FicGetReultREST != null && FicGetReultREST.cat_tipos_generales != null)
                {
                    FicMensaje += "IMPORTANDO: cat_tipos_generales \n";
                    foreach (cat_tipos_generales ctg in FicGetReultREST.cat_tipos_generales)
                    {
                        var respuesta = await FicExistcat_tipos_generales(ctg.IdTipoGeneral);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.DesTipo = ctg.DesTipo;
                                respuesta.Activo = ctg.Activo;                                
                                respuesta.FechaReg = ctg.FechaReg;
                                respuesta.FechaUltMod = ctg.FechaUltMod;
                                respuesta.Borrado = ctg.Borrado;
                                respuesta.UsuarioReg = ctg.UsuarioReg;                                
                                respuesta.UsuarioMod = ctg.UsuarioMod;                                
                                
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdTipoGeneral: " + ctg.IdTipoGeneral + " \n" : "-NO NECESITO ACTUALIZAR-> IdTipoGeneral: " + ctg.IdTipoGeneral + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(ctg);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdSKU: " + ctg.IdTipoGeneral + " \n" : "-ERROR EN INSERTAR-> IdSKU: " + ctg.IdTipoGeneral + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region cat_generales
                if (FicGetReultREST != null && FicGetReultREST.cat_generales != null)
                {
                    FicMensaje += "IMPORTANDO: cat_generales \n";
                    foreach (cat_generales ctg in FicGetReultREST.cat_generales)
                    {
                        var respuesta = await FicExistcat_generales(ctg.IdGeneral, ctg.IdTipoGeneral);
                        if (respuesta != null)
                        {
                            try
                            {                           
                                respuesta.Clave  = ctg.Clave;
                                respuesta.DesGeneral = ctg.DesGeneral;                                
                                respuesta.LlaveClasifica= ctg.LlaveClasifica;
                                respuesta.Activo = ctg.Activo;
                                respuesta.FechaReg = ctg.FechaReg;
                                respuesta.FechaUltMod = ctg.FechaUltMod;
                                respuesta.Borrado = ctg.Borrado;
                                respuesta.UsuarioReg = ctg.UsuarioReg;
                                respuesta.UsuarioMod = ctg.UsuarioMod;

                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> ctg.IdGeneral, ctg.IdTipoGeneral: " + ctg.IdGeneral + "-" + ctg.IdTipoGeneral + " \n" : "-NO NECESITO ACTUALIZAR-> ctg.IdGeneral, ctg.IdTipoGeneral: " + ctg.IdGeneral + "-" + ctg.IdTipoGeneral + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(ctg);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> ctg.IdGeneral, ctg.IdTipoGeneral: " + ctg.IdGeneral + "-" + ctg.IdTipoGeneral + " \n" : "-ERROR EN INSERTAR-> ctg.IdGeneral, ctg.IdTipoGeneral: " + ctg.IdGeneral + "-" + ctg.IdTipoGeneral + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion cat_tipos_estatus

                #region cat_tipos_estatus
                if (FicGetReultREST != null && FicGetReultREST.cat_tipos_estatus != null)
                {
                    FicMensaje += "IMPORTANDO: cat_tipos_estatus \n";
                    foreach (cat_tipos_estatus ctg in FicGetReultREST.cat_tipos_estatus)
                    {
                        var respuesta = await FicExistcat_tipos_estatus(ctg.IdTipoEstatus);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.DesTipoEstatus = ctg.DesTipoEstatus;
                                respuesta.Activo = ctg.Activo;
                                respuesta.FechaReg = ctg.FechaReg;
                                respuesta.FechaUltMod = ctg.FechaUltMod;
                                respuesta.Borrado = ctg.Borrado;
                                respuesta.UsuarioReg = ctg.UsuarioReg;
                                respuesta.UsuarioMod = ctg.UsuarioMod;

                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdTipoEstatus: " + ctg.IdTipoEstatus + " \n" : "-NO NECESITO ACTUALIZAR-> IdTipoEstatus: " + ctg.IdTipoEstatus + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(ctg);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdTipoEstatus: " + ctg.IdTipoEstatus + " \n" : "-ERROR EN INSERTAR-> IdTipoEstatus: " + ctg.IdTipoEstatus + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region cat_estatus
                if (FicGetReultREST != null && FicGetReultREST.cat_estatus != null)
                {
                    FicMensaje += "IMPORTANDO: cat_estatus \n";
                    foreach (cat_estatus ctg in FicGetReultREST.cat_estatus)
                    {
                        var respuesta = await FicExistcat_estatus(ctg.IdEstatus, ctg.IdTipoEstatus);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.Clave = ctg.Clave;
                                respuesta.DesEstatus = ctg.DesEstatus;
                                respuesta.Activo = ctg.Activo;
                                respuesta.FechaReg = ctg.FechaReg;
                                respuesta.FechaUltMod = ctg.FechaUltMod;
                                respuesta.Borrado = ctg.Borrado;
                                respuesta.UsuarioReg = ctg.UsuarioReg;
                                respuesta.UsuarioMod = ctg.UsuarioMod;

                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> ctg.IdEstatus, ctg.IdTipoEstatus: " + ctg.IdEstatus + "-" + ctg.IdTipoEstatus + " \n" : "-NO NECESITO ACTUALIZAR-> ctg.IdEstatus, ctg.IdTipoEstatus: " + ctg.IdEstatus + "-" + ctg.IdTipoEstatus + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(ctg);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> ctg.IdEstatus, ctg.IdTipoEstatus: " + ctg.IdEstatus + "-" + ctg.IdTipoEstatus + " \n" : "-ERROR EN INSERTAR-> ctg.IdEstatus, ctg.IdTipoEstatus: " + ctg.IdEstatus + "-" + ctg.IdTipoEstatus + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region rh_cat_tipo_grupos
                if (FicGetReultREST != null && FicGetReultREST.rh_cat_tipo_grupos != null)
                {
                    FicMensaje += "IMPORTANDO: rh_cat_tipo_grupos \n";
                    foreach (rh_cat_tipo_grupos ctg in FicGetReultREST.rh_cat_tipo_grupos)
                    {
                        var respuesta = await FicExistrh_cat_tipo_grupos(ctg.IdTipoGrupo);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.DesTipoGrupo = ctg.DesTipoGrupo;
                                respuesta.Activo = ctg.Activo;
                                respuesta.FechaReg = ctg.FechaReg;
                                respuesta.FechaUltMod = ctg.FechaUltMod;
                                respuesta.Borrado = ctg.Borrado;
                                respuesta.UsuarioReg = ctg.UsuarioReg;
                                respuesta.UsuarioMod = ctg.UsuarioMod;

                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdTipoGrupo: " + ctg.IdTipoGrupo + " \n" : "-NO NECESITO ACTUALIZAR-> IdTipoGrupo: " + ctg.IdTipoGrupo + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(ctg);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdTipoGrupo: " + ctg.IdTipoGrupo + " \n" : "-ERROR EN INSERTAR-> IdTipoGrupo: " + ctg.IdTipoGrupo + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region rh_cat_grupos
                if (FicGetReultREST != null && FicGetReultREST.rh_cat_grupos != null)
                {
                    FicMensaje += "IMPORTANDO: rh_cat_grupos \n";
                    foreach (rh_cat_grupos ctg in FicGetReultREST.rh_cat_grupos)
                    {
                        var respuesta = await FicExistrh_cat_grupos(ctg.IdGrupo, ctg.IdTipoGrupo);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.DesGrupo = ctg.DesGrupo;
                                respuesta.Activo = ctg.Activo;
                                respuesta.FechaReg = ctg.FechaReg;
                                respuesta.FechaUltMod = ctg.FechaUltMod;
                                respuesta.Borrado = ctg.Borrado;
                                respuesta.UsuarioReg = ctg.UsuarioReg;
                                respuesta.UsuarioMod = ctg.UsuarioMod;

                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdGrupo, IdTipoGrupo: " + ctg.IdGrupo +"-"+ ctg.IdTipoGrupo + " \n" : "-NO NECESITO ACTUALIZAR-> IdGrupo, IdTipoGrupo: " + ctg.IdGrupo + "-" + ctg.IdTipoGrupo + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(ctg);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdGrupo, IdTipoGrupo: " + ctg.IdGrupo + "-" + ctg.IdTipoGrupo + " \n" : "-ERROR EN INSERTAR-> IdGrupo, IdTipoGrupo: " + ctg.IdGrupo + "-" + ctg.IdTipoGrupo + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region rh_cat_perfiles
                if (FicGetReultREST != null && FicGetReultREST.rh_cat_perfiles != null)
                {
                    FicMensaje += "IMPORTANDO: rh_cat_perfiles \n";
                    foreach (rh_cat_perfiles ctg in FicGetReultREST.rh_cat_perfiles)
                    {
                        var respuesta = await FicExistrh_cat_perfiles(ctg.IdPerfil);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.DesPerfil = ctg.DesPerfil;
                                respuesta.Activo = ctg.Activo;
                                respuesta.FechaReg = ctg.FechaReg;
                                respuesta.FechaUltMod = ctg.FechaUltMod;
                                respuesta.Borrado = ctg.Borrado;
                                respuesta.UsuarioReg = ctg.UsuarioReg;
                                respuesta.UsuarioMod = ctg.UsuarioMod;

                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdPerfil: " + ctg.IdPerfil + " \n" : "-NO NECESITO ACTUALIZAR-> IdPerfil: " + ctg.IdPerfil + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(ctg);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdPerfil: " + ctg.IdPerfil + " \n" : "-ERROR EN INSERTAR-> IdPerfil: " + ctg.IdPerfil + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region cat_paises
                if (FicGetReultREST != null && FicGetReultREST.cat_paises != null)
                {
                    FicMensaje += "IMPORTANDO: cat_paises \n";
                    foreach (cat_paises ctg in FicGetReultREST.cat_paises)
                    {
                        var respuesta = await FicExistcat_paises(ctg.IdPais);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.DesPais = ctg.DesPais;
                                respuesta.ClavePais = ctg.ClavePais;
                                respuesta.Activo = ctg.Activo;
                                respuesta.FechaReg = ctg.FechaReg;
                                respuesta.FechaUltMod = ctg.FechaUltMod;
                                respuesta.Borrado = ctg.Borrado;
                                respuesta.UsuarioReg = ctg.UsuarioReg;
                                respuesta.UsuarioMod = ctg.UsuarioMod;

                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdPais: " + ctg.IdPais + " \n" : "-NO NECESITO ACTUALIZAR-> IdPais: " + ctg.IdPais + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(ctg);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdPais: " + ctg.IdPais + " \n" : "-ERROR EN INSERTAR-> IdPais: " + ctg.IdPais + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region cat_estados
                if (FicGetReultREST != null && FicGetReultREST.cat_estados != null)
                {
                    FicMensaje += "IMPORTANDO: cat_estados \n";
                    foreach (cat_estados ctg in FicGetReultREST.cat_estados)
                    {
                        var respuesta = await FicExistcat_estados(ctg.IdEstado);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.IdPais = ctg.IdPais;
                                respuesta.ClaveEstado = ctg.ClaveEstado;
                                respuesta.DesEstado = ctg.DesEstado;
                                respuesta.Abreviatura = ctg.Abreviatura;
                                respuesta.DesCapital = ctg.DesCapital;
                                respuesta.Activo = ctg.Activo;
                                respuesta.FechaReg = ctg.FechaReg;
                                respuesta.FechaUltMod = ctg.FechaUltMod;
                                respuesta.Borrado = ctg.Borrado;
                                respuesta.UsuarioReg = ctg.UsuarioReg;
                                respuesta.UsuarioMod = ctg.UsuarioMod;

                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdEstado: " + ctg.IdEstado + " \n" : "-NO NECESITO ACTUALIZAR-> IdEstado: " + ctg.IdEstado + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(ctg);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdEstado: " + ctg.IdEstado + " \n" : "-ERROR EN INSERTAR-> IdEstado: " + ctg.IdEstado + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region cat_municipios
                if (FicGetReultREST != null && FicGetReultREST.cat_municipios != null)
                {
                    FicMensaje += "IMPORTANDO: cat_municipios \n";
                    foreach (cat_municipios ctg in FicGetReultREST.cat_municipios)
                    {
                        var respuesta = await FicExistcat_municipios(ctg.IdMunicipio);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.IdEstado = ctg.IdEstado;
                                respuesta.IdPais = ctg.IdPais;
                                respuesta.ClaveMunicipio = ctg.ClaveMunicipio;
                                respuesta.DesMunicipio = ctg.DesMunicipio;
                                respuesta.Activo = ctg.Activo;
                                respuesta.FechaReg = ctg.FechaReg;
                                respuesta.FechaUltMod = ctg.FechaUltMod;
                                respuesta.Borrado = ctg.Borrado;
                                respuesta.UsuarioReg = ctg.UsuarioReg;
                                respuesta.UsuarioMod = ctg.UsuarioMod;

                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdMunicipio: " + ctg.IdMunicipio + " \n" : "-NO NECESITO ACTUALIZAR-> IdMunicipio: " + ctg.IdMunicipio + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(ctg);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdMunicipio: " + ctg.IdMunicipio + " \n" : "-ERROR EN INSERTAR-> IdMunicipio: " + ctg.IdMunicipio + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region cat_localidades
                if (FicGetReultREST != null && FicGetReultREST.cat_localidades != null)
                {
                    FicMensaje += "IMPORTANDO: cat_localidades \n";
                    foreach (cat_localidades ctg in FicGetReultREST.cat_localidades)
                    {
                        var respuesta = await FicExistcat_localidades(ctg.IdLocalidad);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.IdEstado = ctg.IdEstado;
                                respuesta.IdPais = ctg.IdPais;
                                respuesta.IdMunicipio= ctg.IdMunicipio;
                                respuesta.ClaveLocalidad = ctg.ClaveLocalidad;
                                respuesta.DesLocalidad = ctg.DesLocalidad;
                                respuesta.GradoMarginacion = ctg.GradoMarginacion;
                                respuesta.FechaReg = ctg.FechaReg;
                                respuesta.FechaUltMod = ctg.FechaUltMod;
                                respuesta.Borrado = ctg.Borrado;
                                respuesta.UsuarioReg = ctg.UsuarioReg;
                                respuesta.UsuarioMod = ctg.UsuarioMod;

                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdLocalidad: " + ctg.IdLocalidad + " \n" : "-NO NECESITO ACTUALIZAR-> IdLocalidad: " + ctg.IdLocalidad + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(ctg);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdLocalidad: " + ctg.IdLocalidad + " \n" : "-ERROR EN INSERTAR-> IdLocalidad: " + ctg.IdLocalidad + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region cat_colonias
                if (FicGetReultREST != null && FicGetReultREST.cat_colonias != null)
                {
                    FicMensaje += "IMPORTANDO: cat_colonias \n";
                    foreach (cat_colonias ctg in FicGetReultREST.cat_colonias)
                    {
                        var respuesta = await FicExistcat_colonias(ctg.IdColonia);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.IdEstado = ctg.IdEstado;
                                respuesta.IdPais = ctg.IdPais;
                                respuesta.IdMunicipio = ctg.IdMunicipio;
                                respuesta.IdLocalidad = ctg.IdLocalidad;
                                respuesta.ClaveColonia = ctg.ClaveColonia;
                                respuesta.DesColonia = ctg.DesColonia;
                                respuesta.CodPostal = ctg.CodPostal;
                                respuesta.TipoAsentamiento = ctg.TipoAsentamiento;                                
                                respuesta.Activo = ctg.Activo;
                                respuesta.FechaReg = ctg.FechaReg;
                                respuesta.FechaUltMod = ctg.FechaUltMod;
                                respuesta.Borrado = ctg.Borrado;
                                respuesta.UsuarioReg = ctg.UsuarioReg;
                                respuesta.UsuarioMod = ctg.UsuarioMod;

                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdColonia: " + ctg.IdColonia + " \n" : "-NO NECESITO ACTUALIZAR-> IdTipoGeneral: " + ctg.IdColonia + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(ctg);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdColonia: " + ctg.IdColonia + " \n" : "-ERROR EN INSERTAR-> IdSKU: " + ctg.IdColonia + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region cat_institutos
                if (FicGetReultREST != null && FicGetReultREST.cat_institutos != null)
                {
                    FicMensaje += "IMPORTANDO: cat_institutos \n";
                    foreach (cat_institutos ctg in FicGetReultREST.cat_institutos)
                    {
                        var respuesta = await FicExistcat_institutos(ctg.IdInstituto);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.DesInstituto = ctg.DesInstituto;
                                respuesta.Alias = ctg.Alias;
                                respuesta.Matriz = ctg.Matriz;
                                respuesta.IdInstitutoPadre = ctg.IdInstitutoPadre;
                                respuesta.IdTipoGenGiro = ctg.IdTipoGenGiro;
                                respuesta.IdGenGiro = ctg.IdGenGiro;
                                respuesta.Activo = ctg.Activo;
                                respuesta.FechaReg = ctg.FechaReg;
                                respuesta.FechaUltMod = ctg.FechaUltMod;
                                respuesta.Borrado = ctg.Borrado;
                                respuesta.UsuarioReg = ctg.UsuarioReg;
                                respuesta.UsuarioMod = ctg.UsuarioMod;

                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdInstituto: " + ctg.IdInstituto + " \n" : "-NO NECESITO ACTUALIZAR-> IdInstituto: " + ctg.IdInstituto + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
                                FicLoBDContext.Add(ctg);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdInstituto: " + ctg.IdInstituto + " \n" : "-ERROR EN INSERTAR-> IdInstituto: " + ctg.IdInstituto + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion

                #region eva_cat_carreras
                if (FicGetReultREST != null && FicGetReultREST.eva_cat_carreras != null)
                {
                    FicMensaje += "IMPORTANDO: eva_cat_carreras \n";
                    foreach (eva_cat_carreras ctg in FicGetReultREST.eva_cat_carreras)
                    {
                        var respuesta = await FicExisteva_cat_carreras(ctg.IdCarrera);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.ClaveCarrera = ctg.ClaveCarrera;
                                respuesta.ClaveOficial = ctg.ClaveOficial;
                                respuesta.DesCarrera = ctg.DesCarrera;
                                respuesta.Alias = ctg.Alias;
                                respuesta.IdTipoGenGradoEscolar = ctg.IdTipoGenGradoEscolar;
                                respuesta.IdGenGradoEscolar = ctg.IdGenGradoEscolar;
                                respuesta.NombreCorto = ctg.NombreCorto;
                                respuesta.Creditos = ctg.Creditos;
                                respuesta.IdTipoGenModalidad = ctg.IdTipoGenModalidad;
                                respuesta.IdGenModalidad = ctg.IdGenModalidad;
                                respuesta.FechaIni = ctg.FechaIni;
                                respuesta.FechaFin = ctg.FechaFin;
                                respuesta.Activo = ctg.Activo;
                                respuesta.FechaReg = ctg.FechaReg;
                                respuesta.FechaUltMod = ctg.FechaUltMod;
                                respuesta.Borrado = ctg.Borrado;
                                respuesta.UsuarioReg = ctg.UsuarioReg;
                                respuesta.UsuarioMod = ctg.UsuarioMod;

                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdCarrera: " + ctg.IdCarrera + " \n" : "-NO NECESITO ACTUALIZAR-> IdTipoGeneral: " + ctg.IdCarrera + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
                                FicLoBDContext.Add(ctg);
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdCarrera: " + ctg.IdCarrera + " \n" : "-ERROR EN INSERTAR-> IdCarrera: " + ctg.IdCarrera + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
                #endregion


            }
            catch (Exception e)
            {
                FicMensaje += "ALERTA: " + e.Message.ToString() + "\n";
            }
            return FicMensaje;
        }//FicGetImportCatalogos()

        public async Task<cat_tipos_generales> FicExistcat_tipos_generales(int idCatalogo) {

            var catalogos = await (
                from cat in FicLoBDContext.cat_tipos_generales
                where cat.IdTipoGeneral == idCatalogo
                select cat).AsNoTracking().ToListAsync();

            var a = new cat_tipos_generales();
            if (catalogos.Count != 0) {                
                a = catalogos[0];
                return a;
            }
            return null;
        }

        public async Task<cat_generales> FicExistcat_generales(int IdCatalogo, int IdTipoCatalogo)
        {

            var catalogos = await (
                from cat in FicLoBDContext.cat_generales
                where cat.IdGeneral == IdCatalogo && cat.IdTipoGeneral == IdTipoCatalogo
                select cat).AsNoTracking().ToListAsync();

            var a = new cat_generales();
            if (catalogos.Count != 0)
            {
                a = catalogos[0];
                return a;
            }
            return null;
        }

        public async Task<cat_tipos_estatus> FicExistcat_tipos_estatus(int idCatalogo)
        {

            var catalogos = await (
                from cat in FicLoBDContext.cat_tipos_estatus
                where cat.IdTipoEstatus == idCatalogo
                select cat).AsNoTracking().ToListAsync();

            var a = new cat_tipos_estatus();
            if (catalogos.Count != 0)
            {
                a = catalogos[0];
                return a;
            }
            return null;
        }

        public async Task<cat_estatus> FicExistcat_estatus(int idCatalogo, int IdTipoCatalogo)
        {

            var catalogos = await (
                from cat in FicLoBDContext.cat_estatus
                where cat.IdEstatus == idCatalogo && cat.IdTipoEstatus == IdTipoCatalogo
                select cat).AsNoTracking().ToListAsync();

            var a = new cat_estatus();
            if (catalogos.Count != 0)
            {
                a = catalogos[0];
                return a;
            }
            return null;
        }

        public async Task<rh_cat_tipo_grupos> FicExistrh_cat_tipo_grupos(int idCatalogo)
        {

            var catalogos = await (
                from cat in FicLoBDContext.rh_cat_tipo_grupos
                where cat.IdTipoGrupo == idCatalogo
                select cat).AsNoTracking().ToListAsync();

            var a = new rh_cat_tipo_grupos();
            if (catalogos.Count != 0)
            {
                a = catalogos[0];
                return a;
            }
            return null;
        }

        public async Task<rh_cat_grupos> FicExistrh_cat_grupos(int idCatalogo, int IdTipoCatalogo)
        {

            var catalogos = await (
                from cat in FicLoBDContext.rh_cat_grupos
                where cat.IdGrupo == idCatalogo && cat.IdTipoGrupo == IdTipoCatalogo
                select cat).AsNoTracking().ToListAsync();

            var a = new rh_cat_grupos();
            if (catalogos.Count != 0)
            {
                a = catalogos[0];
                return a;
            }
            return null;
        }

        public async Task<cat_paises> FicExistcat_paises(int idCatalogo)
        {

            var catalogos = await (
                from cat in FicLoBDContext.cat_paises
                where cat.IdPais == idCatalogo
                select cat).AsNoTracking().ToListAsync();

            var a = new cat_paises();
            if (catalogos.Count != 0)
            {
                a = catalogos[0];
                return a;
            }
            return null;
        }

        public async Task<cat_estados> FicExistcat_estados(int IdCatalogo)
        {

            var catalogos = await (
                from cat in FicLoBDContext.cat_estados
                where cat.IdEstado == IdCatalogo
                select cat).AsNoTracking().ToListAsync();

            var a = new cat_estados();
            if (catalogos.Count != 0)
            {
                a = catalogos[0];
                return a;
            }
            return null;
        }

        public async Task<cat_municipios> FicExistcat_municipios(int IdCatalogo)
        {

            var catalogos = await (
                from cat in FicLoBDContext.cat_municipios
                where cat.IdMunicipio == IdCatalogo
                select cat).AsNoTracking().ToListAsync();

            var a = new cat_municipios();
            if (catalogos.Count != 0)
            {
                a = catalogos[0];
                return a;
            }
            return null;
        }

        public async Task<cat_colonias> FicExistcat_colonias(int IdCatalago)
        {

            var catalogos = await (
                from cat in FicLoBDContext.cat_colonias
                where cat.IdColonia == IdCatalago
                select cat).AsNoTracking().ToListAsync();

            var a = new cat_colonias();
            if (catalogos.Count != 0)
            {
                a = catalogos[0];
                return a;
            }
            return null;
        }

        public async Task<cat_localidades> FicExistcat_localidades(int IdCatalogo)
        {

            var catalogos = await (
                from cat in FicLoBDContext.cat_localidades
                where cat.IdLocalidad == IdCatalogo               
                select cat).AsNoTracking().ToListAsync();
            var a = new cat_localidades();
            if (catalogos.Count != 0)
            {
                a = catalogos[0];
                return a;
            }
            return null;
        }

        public async Task<rh_cat_perfiles> FicExistrh_cat_perfiles(int idCatalogo)
        {

            var catalogos = await (
                from cat in FicLoBDContext.rh_cat_perfiles
                where cat.IdPerfil == idCatalogo
                select cat).AsNoTracking().ToListAsync();

            var a = new rh_cat_perfiles();
            if (catalogos.Count != 0)
            {
                a = catalogos[0];
                return a;
            }
            return null;
        }

        public async Task<eva_cat_carreras> FicExisteva_cat_carreras(int idCatalogo)
        {

            var catalogos = await (
                from cat in FicLoBDContext.eva_cat_carreras
                where cat.IdCarrera == idCatalogo
                select cat).AsNoTracking().ToListAsync();

            var a = new eva_cat_carreras();
            if (catalogos.Count != 0)
            {
                a = catalogos[0];
                return a;
            }
            return null;
        }

        public async Task<cat_institutos> FicExistcat_institutos(int idCatalogo)
        {

            var catalogos = await (
                from cat in FicLoBDContext.cat_institutos
                where cat.IdInstituto == idCatalogo
                select cat).AsNoTracking().ToListAsync();

            var a = new cat_institutos();
            if (catalogos.Count != 0)
            {
                a = catalogos[0];
                return a;
            }
            return null;
        }


    }//CLASS
}//NAMESPACE

