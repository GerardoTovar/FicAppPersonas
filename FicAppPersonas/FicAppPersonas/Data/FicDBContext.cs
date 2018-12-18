using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;
using static FicAppPersonas.Models.Asistencia.FicModAsistencia;

namespace FicAppPersonas.Data
{
    public class FicDBContext : DbContext
    {
        private readonly string FicDataBasePath;

        public DbSet<rh_cat_personas> rh_cat_personas { get; set; }
        public DbSet<rh_cat_domicilios> rh_cat_domicilios { get; set; }
        public DbSet<rh_cat_telefonos> rh_cat_telefonos { get; set; }
        public DbSet<rh_cat_personas_perfiles> rh_cat_personas_perfiles { get; set; }
        public DbSet<rh_cat_alumnos> rh_cat_alumnos { get; set; }
        public DbSet<rh_cat_empleados> rh_cat_empleados { get; set; }
        public DbSet<rh_cat_catedraticos> rh_cat_catedraticos { get; set; }
        public DbSet<rh_cat_dir_web> rh_cat_dir_web { get; set; }
        public DbSet<rh_personas_perfil_estatus> rh_personas_perfil_estatus { get; set; }
        public DbSet<rh_cat_personas_datos_adicionales> rh_cat_personas_datos_adicionales { get; set; }
        public DbSet<bec_cat_clientes> bec_cat_clientes { get; set; }
        public DbSet<bec_institutos_personas> bec_institutos_personas { get; set; }


        //--------------CATALOGOS
        public DbSet<cat_institutos> cat_institutos { get; set; }
        public DbSet<cat_tipos_estatus> cat_tipos_estatus { get; set; }
        public DbSet<cat_estatus> cat_estatus { get; set; }
        public DbSet<cat_tipos_generales> cat_tipos_generales { get; set; }
        public DbSet<cat_generales> cat_generales { get; set; }
        public DbSet<rh_cat_tipo_grupos> rh_cat_tipo_grupos { get; set; }
        public DbSet<rh_cat_grupos> rh_cat_grupos { get; set; }
        public DbSet<eva_cat_carreras> eva_cat_carreras { get; set; }
        public DbSet<cat_paises> cat_paises { get; set; }
        public DbSet<cat_estados> cat_estados { get; set; }
        public DbSet<cat_municipios> cat_municipios { get; set; }
        public DbSet<cat_colonias> cat_colonias { get; set; }
        public DbSet<cat_localidades> cat_localidades { get; set; }
        public DbSet<rh_cat_perfiles> rh_cat_perfiles { get; set; }

        public FicDBContext(string FicPaDataBasePath)
        {
            FicDataBasePath = FicPaDataBasePath;
            //C:\Users\L_Z0K\AppData\Local\Packages\610583a7-21ab-48e3-a30d-748c2ae47154_wa7wgrm6get44\LocalState\CocacolaNayDB34.db3
            FicMetCrearDB();
        } //CONSTRUCTOR

        public async void FicMetCrearDB()
        {
            try
            {
                //Se crea la base de datos en base el al esquema 
                //await Database.EnsureDeletedAsync();
                //Nuevo metodo básico de Entity Framework que garantiza que exite la base de datos para el contexto
                //Si no existe, no se toma ninguna acción
                await Database.EnsureCreatedAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//ESTE METODO CREA LA BASE DE DATOS

        protected async override void OnConfiguring(DbContextOptionsBuilder FicPaOptionsBuilder)
        {
            try
            {
                FicPaOptionsBuilder.UseSqlite($"Filename={FicDataBasePath}");
                FicPaOptionsBuilder.EnableSensitiveDataLogging();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//CONFIGURACION DE LA CONEXION



        protected async override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {

                //bec_institutos_personas//
                #region bec_institutos_personas
                modelBuilder
                    .Entity<bec_institutos_personas>()
                    .HasKey(c => new { c.IdInstituto, c.IdPersona, c.IdPerfil });
                modelBuilder
                    .Entity<bec_institutos_personas>()
                    .HasOne(s => s.cat_institutos)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdInstituto });
                modelBuilder
                    .Entity<bec_institutos_personas>()
                    .HasOne(s => s.rh_cat_personas)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdPersona });
                modelBuilder
                   .Entity<bec_institutos_personas>()
                   .HasOne(s => s.rh_cat_perfiles)
                   .WithMany()
                   .HasForeignKey(s => new { s.IdPerfil });
                #endregion

                //bec_cat_clientes//
                #region bec_cat_clientes
                modelBuilder
                    .Entity<bec_cat_clientes>()
                   .HasKey(c => new { c.IdCliente });
                modelBuilder
                    .Entity<bec_cat_clientes>()
                    .HasOne(s => s.rh_cat_grupos)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdGrupo, s.IdTipoGrupo });
                modelBuilder
                    .Entity<bec_cat_clientes>()
                    .HasOne(s => s.rh_cat_personas)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdCliente });
                #endregion

                //rh_cat_alumnos//
                #region rh_cat_alumnos
                modelBuilder
                    .Entity<rh_cat_alumnos>()
                    .HasKey(c => new { c.IdAlumno });
                modelBuilder
                    .Entity<rh_cat_alumnos>()
                    .HasOne(s => s.rh_cat_personas)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdAlumno });
                modelBuilder
                    .Entity<rh_cat_alumnos>()
                    .HasOne(s => s.eva_cat_carreras)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdCarrera });
                #endregion

                //rh_cat_empleados//
                #region rh_cat_empleados
                modelBuilder
                    .Entity<rh_cat_empleados>()
                    .HasKey(c => new { c.IdEmpleado });
                modelBuilder
                    .Entity<rh_cat_empleados>()
                    .HasOne(s => s.rh_cat_personas)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdEmpleado });
                #endregion

                //rh_cat_catedraticos//
                #region rh_cat_catedraticos
                modelBuilder
                    .Entity<rh_cat_catedraticos>()
                    .HasKey(c => new { c.IdEmpleado });
                modelBuilder
                    .Entity<rh_cat_catedraticos>()
                    .HasOne(s => s.rh_cat_personas)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdEmpleado });
                #endregion

                //rh_cat_dir_web//
                #region rh_cat_dir_web
                modelBuilder
                    .Entity<rh_cat_dir_web>()
                    .HasKey(c => new { c.IdDirWeb });
                modelBuilder
                    .Entity<rh_cat_dir_web>()
                    .HasOne(s => s.cat_generales)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdGenDirWeb, s.IdTipoGenDirWeb });
                #endregion

                //rh_personas_perfil_estatus//
                #region rh_personas_perfil_estatus
                modelBuilder
                    .Entity<rh_personas_perfil_estatus>()
                    .HasKey(c => new { c.IdEstatusDet, c.IdPersona, c.IdPerfil });
                modelBuilder
                    .Entity<rh_personas_perfil_estatus>()
                    .HasOne(s => s.rh_cat_personas)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdPersona });
                modelBuilder
                    .Entity<rh_personas_perfil_estatus>()
                    .HasOne(s => s.rh_cat_perfiles)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdPerfil });
                modelBuilder
                    .Entity<rh_personas_perfil_estatus>()
                    .HasOne(s => s.cat_estatus)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdEstatus, s.IdTipoEstatus });
                #endregion

                //rh_cat_domicilios//
                #region rh_cat_domicilios
                modelBuilder
                    .Entity<rh_cat_domicilios>()
                    .HasKey(c => new { c.IdDomicilio });
                modelBuilder
                    .Entity<rh_cat_domicilios>()
                    .HasOne(s => s.cat_generales)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdGenDom, s.IdTipoGenDom });
                #endregion

                //rh_cat_telefonos//
                #region rh_cat_telefonos
                modelBuilder
                    .Entity<rh_cat_telefonos>()
                    .HasKey(c => new { c.IdTelefono });
                modelBuilder
                    .Entity<rh_cat_telefonos>()
                    .HasOne(s => s.cat_generales)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdGenTelefono, s.IdTipoGenTelefono });
                #endregion

                //rh_cat_personas_perfiles//
                #region rh_cat_personas_perfiles
                modelBuilder
                    .Entity<rh_cat_personas_perfiles>()
                    .HasKey(c => new { c.IdPersona, c.IdPerfil });
                modelBuilder
                    .Entity<rh_cat_personas_perfiles>()
                    .HasOne(s => s.rh_cat_persona)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdPersona });
                modelBuilder
                    .Entity<rh_cat_personas_perfiles>()
                    .HasOne(s => s.rh_cat_perfiles)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdPerfil });
                #endregion

                //rh_cat_personas_datos_adicionales//
                #region rh_cat_personas_datos_adicionales
                modelBuilder
                    .Entity<rh_cat_personas_datos_adicionales>()
                    .HasKey(c => new { c.IdDatoAdicional, c.IdPersona });
                modelBuilder
                    .Entity<rh_cat_personas_datos_adicionales>()
                    .HasOne(s => s.rh_cat_personas)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdPersona });
                modelBuilder
                    .Entity<rh_cat_personas_datos_adicionales>()
                    .HasOne(s => s.cat_generales)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdGenSeccion, s.IdTipoGenSeccion });
                #endregion

                //rh_cat_personas//
                #region rh_cat_personas
                modelBuilder
                    .Entity<rh_cat_personas>()
                    .HasKey(c => new { c.IdPersona });
                modelBuilder
                    .Entity<rh_cat_personas>()
                    .HasOne(s => s.cat_generales_estado)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdGenEstadoCivil, s.IdTipoGenEstadoCivil });
                modelBuilder
                    .Entity<rh_cat_personas>()
                    .HasOne(s => s.cat_institutos)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdInstituto });
                modelBuilder
                    .Entity<rh_cat_personas>()
                    .HasOne(s => s.cat_generales_ocupacion)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdGenOcupacion, s.IdTipoGenOcupacion });

                #endregion

                //===========================================catalogos==========================================//



                //cat_institutos
                #region cat_institutos
                modelBuilder
                    .Entity<cat_institutos>()
                    .HasKey(c => new { c.IdInstituto });
                modelBuilder
                    .Entity<cat_institutos>()
                    .HasOne(s => s.cat_generales_giro)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdGenGiro, s.IdTipoGenGiro });
                modelBuilder
                    .Entity<cat_institutos>()
                    .HasOne(s => s.cat_Institutos)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdInstitutoPadre });


                #endregion

                //cat_paises
                #region cat_paises
                modelBuilder
                    .Entity<cat_paises>()
                    .HasKey(c => new { c.IdPais });
                #endregion

                //cat_estados
                #region cat_estados
                modelBuilder
                    .Entity<cat_estados>()
                    .HasKey(c => new { c.IdEstado });
                modelBuilder
                    .Entity<cat_estados>()
                    .HasOne(s => s.cat_paises)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdPais });

                #endregion

                //cat_municipios
                #region cat_municipios
                modelBuilder
                    .Entity<cat_municipios>()
                    .HasKey(c => new { c.IdMunicipio });
                modelBuilder
                    .Entity<cat_municipios>()
                    .HasOne(s => s.cat_paises)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdPais });

                modelBuilder
                    .Entity<cat_municipios>()
                    .HasOne(s => s.cat_estados)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdEstado });

                #endregion

                //cat_localidades
                #region cat_localidades
                modelBuilder
                    .Entity<cat_localidades>()
                    .HasKey(c => new { c.IdLocalidad });
                modelBuilder
                    .Entity<cat_localidades>()
                    .HasOne(s => s.cat_paises)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdPais });


                modelBuilder
                    .Entity<cat_localidades>()
                    .HasOne(s => s.cat_estados)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdEstado });

                modelBuilder
                    .Entity<cat_localidades>()
                    .HasOne(s => s.cat_municipios)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdMunicipio });

                #endregion

                //cat_colonias
                #region cat_colonias
                modelBuilder
                    .Entity<cat_colonias>()
                    .HasKey(c => new { c.IdColonia });
                modelBuilder
                    .Entity<cat_colonias>()
                    .HasOne(s => s.cat_paises)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdPais });


                modelBuilder
                    .Entity<cat_colonias>()
                    .HasOne(s => s.cat_estados)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdEstado });

                modelBuilder
                    .Entity<cat_colonias>()
                    .HasOne(s => s.cat_localidades)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdLocalidad });

                #endregion

                //cat_tipos_generales
                #region cat_tipos_generales
                modelBuilder
                    .Entity<cat_tipos_generales>()
                    .HasKey(c => new { c.IdTipoGeneral });
                #endregion

                //cat_generales
                #region cat_generales
                modelBuilder
                    .Entity<cat_generales>()
                    .HasKey(c => new { c.IdGeneral, c.IdTipoGeneral });
                modelBuilder
                    .Entity<cat_generales>()
                    .HasOne(s => s.cat_tipos_generales)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdTipoGeneral });

                #endregion

                //eva_cat_carreras
                #region eva_cat_carreras
                modelBuilder
                    .Entity<eva_cat_carreras>()
                    .HasKey(c => new { c.IdCarrera });
                modelBuilder
                    .Entity<eva_cat_carreras>()
                    .HasOne(s => s.cat_generales_grado)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdGenGradoEscolar, s.IdTipoGenGradoEscolar });

                modelBuilder
                    .Entity<eva_cat_carreras>()
                    .HasOne(s => s.cat_generales_modalidad)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdGenModalidad, s.IdTipoGenModalidad });

                #endregion

                //cat_tipos_estatus
                #region cat_tipos_estatus
                modelBuilder
                    .Entity<cat_tipos_estatus>()
                    .HasKey(c => new { c.IdTipoEstatus });
                #endregion

                //cat_estatus
                #region
                modelBuilder
                    .Entity<cat_estatus>()
                    .HasKey(c => new { c.IdEstatus, c.IdTipoEstatus });
                modelBuilder
                    .Entity<cat_estatus>()
                    .HasOne(s => s.cat_tipos_estatus)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdTipoEstatus });

                #endregion

                //rh_cat_tipo_grupos
                #region rh_cat_tipo_grupos
                modelBuilder
                    .Entity<rh_cat_tipo_grupos>()
                    .HasKey(c => new { c.IdTipoGrupo });
                #endregion

                //rh_cat_grupos
                #region rh_cat_grupos
                modelBuilder
                    .Entity<rh_cat_grupos>()
                    .HasKey(c => new { c.IdGrupo, c.IdTipoGrupo });
                modelBuilder
                    .Entity<rh_cat_grupos>()
                    .HasOne(s => s.rh_cat_tipo_grupos)
                    .WithMany()
                    .HasForeignKey(s => new { s.IdTipoGrupo });

                #endregion

                //rh_cat_perfiles
                #region rh_cat_perfiles
                modelBuilder
                    .Entity<rh_cat_perfiles>()
                    .HasKey(c => new { c.IdPerfil });

                #endregion
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }

        }//AL CREAR EL MODELO
    }
}