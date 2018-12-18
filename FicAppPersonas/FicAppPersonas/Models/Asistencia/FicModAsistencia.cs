using System;
using System.Collections.Generic;
using System.Text;

//
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FicAppPersonas.Models.Asistencia
{
    public class FicModAsistencia
    {

        public class rh_cat_personas
        {
            public int IdPersona { get; set; }
            public Nullable<Int16> IdInstituto { get; set; }
            public cat_institutos cat_institutos { get; set; }
            [StringLength(20)]
            public string NumControl { get; set; }
            [StringLength(100)]
            public string Nombre { get; set; }
            [StringLength(60)]
            public string ApPaterno { get; set; }
            [StringLength(60)]
            public string ApMaterno { get; set; }
            [StringLength(15)]
            public string RFC { get; set; }
            [StringLength(25)]
            public string CURP { get; set; }
            public Nullable<DateTime> FechaNac { get; set; }
            [StringLength(1)]
            public string TipoPersona { get; set; }
            [StringLength(1)]
            public string Sexo { get; set; }
            [StringLength(255)]
            public string RutaFoto { get; set; }
            [StringLength(20)]
            public string Alias { get; set; }
            public Nullable<Int16> IdTipoGenOcupacion { get; set; }
            public Nullable<Int16> IdGenOcupacion { get; set; }
            public cat_generales cat_generales_ocupacion { get; set; }
            public Nullable<Int16> IdTipoGenEstadoCivil { get; set; }
            public Nullable<Int16> IdGenEstadoCivil { get; set; }
            public cat_generales cat_generales_estado { get; set; }

            [StringLength(1)]
            public string Activo { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }
        public class rh_cat_domicilios
        {
            public int IdDomicilio { get; set; }
            [StringLength(200)]
            public string Domicilio { get; set; }
            [StringLength(150)]
            public string EntreCalle1 { get; set; }
            [StringLength(150)]
            public string EntreCalle2 { get; set; }
            [StringLength(10)]
            public string CodigoPostal { get; set; }
            [StringLength(255)]
            public string Coordenadas { get; set; }
            [StringLength(1)]
            public string Principal { get; set; }
            public Nullable<Int16> IdTipoGenDom { get; set; }
            public Nullable<Int16> IdGenDom { get; set; }
            public cat_generales cat_generales { get; set; }
            [StringLength(50)]
            public string Pais { get; set; }
            [StringLength(50)]
            public string Estado { get; set; }
            [StringLength(50)]
            public string Municipio { get; set; }
            [StringLength(50)]
            public string Localidad { get; set; }
            [StringLength(100)]
            public string Colonia { get; set; }
            [StringLength(50)]
            public string Referencia { get; set; }
            [StringLength(50)]
            public string ClaveReferencia { get; set; }
            [StringLength(1)]
            public string TipoDomicilio { get; set; }

            public Nullable<DateTime> FechaReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Activo { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }

        public class rh_cat_telefonos
        {
            public int IdTelefono { get; set; }
            [StringLength(2)]
            public string CodPais { get; set; }
            [StringLength(20)]
            public string NumTelefono { get; set; }
            [StringLength(30)]
            public string NumExtension { get; set; }
            [StringLength(1)]
            public string Principal { get; set; }
            public Nullable<Int16> IdTipoGenTelefono { get; set; }
            public Nullable<Int16> IdGenTelefono { get; set; }
            public cat_generales cat_generales { get; set; }
            [StringLength(50)]
            public string ClaveReferencia { get; set; }
            [StringLength(50)]
            public string Referencia { get; set; }

            public Nullable<DateTime> FechaReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Activo { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }

        public class rh_cat_personas_perfiles
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int IdPersona { get; set; }
            public rh_cat_personas rh_cat_persona { get; set; }
            public Nullable<Int16> IdPerfil { get; set; }
            public rh_cat_perfiles rh_cat_perfiles { get; set; }

            [StringLength(1)]
            public string Activo { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }

        public class rh_cat_personas_datos_adicionales
        {
            public int IdDatoAdicional { get; set; }
            [StringLength(50)]
            public string Etiqueta { get; set; }
            public Nullable<int> IdPersona { get; set; }
            public rh_cat_personas rh_cat_personas { get; set; }
            [StringLength(500)]
            public string Valor { get; set; }
            public Nullable<Int16> IdTipoGenSeccion { get; set; }
            public Nullable<Int16> IdGenSeccion { get; set; }
            public cat_generales cat_generales { get; set; }

            [StringLength(1)]
            public string Activo { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }

        public class rh_cat_alumnos
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int IdAlumno { get; set; }
            public rh_cat_personas rh_cat_personas { get; set; }
            [StringLength(20)]
            public string NumControl { get; set; }

            [StringLength(20)]
            public string UsuarioReg { get; set; }
            [StringLength(18)]
            public string UsuarioMod { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(1)]
            public string Activo { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
            public Nullable<Int16> IdCarrera { get; set; }
            public eva_cat_carreras eva_cat_carreras { get; set; }
        }

        public class rh_cat_empleados
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int IdEmpleado { get; set; }
            public rh_cat_personas rh_cat_personas { get; set; }
            [StringLength(20)]
            public string NumControl { get; set; }

            public Nullable<DateTime> FechaReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Activo { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }

        public class rh_cat_catedraticos
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int IdEmpleado { get; set; }
            public rh_cat_personas rh_cat_personas { get; set; }

            public Nullable<DateTime> FechaReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public String UsuarioReg { get; set; }
            [StringLength(20)]
            public String UsuarioMod { get; set; }
            [StringLength(1)]
            public String Activo { get; set; }
            [StringLength(1)]
            public String Borrado { get; set; }
        }

        public class rh_cat_dir_web
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int IdDirWeb { get; set; }
            [StringLength(50)]
            public string DesDirWeb { get; set; }
            [StringLength(255)]
            public String DireccionWeb { get; set; }
            [StringLength(1)]
            public string Principal { get; set; }
            public Nullable<Int16> IdTipoGenDirWeb { get; set; }
            public Nullable<Int16> IdGenDirWeb { get; set; }
            public cat_generales cat_generales { get; set; }
            [StringLength(50)]
            public string ClaveReferencia { get; set; }
            [StringLength(50)]
            public string Referencia { get; set; }

            public Nullable<DateTime> FechaReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Activo { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }//class rh_cat_dir_web OK

        public class rh_personas_perfil_estatus
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdEstatusDet { get; set; }
            public int IdPersona { get; set; }
            public rh_cat_personas rh_cat_personas { get; set; }
            public Int16 IdPerfil { get; set; }
            public rh_cat_perfiles rh_cat_perfiles { get; set; }
            public Nullable<DateTime> FechaEstatus { get; set; }
            public Int16 IdTipoEstatus { get; set; }
            public Int16 IdEstatus { get; set; }
            public cat_estatus cat_estatus { get; set; }
            [StringLength(1)]
            public string Actual { get; set; }
            [StringLength(500)]
            public string Observacion { get; set; }

            public Nullable<DateTime> FechaReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Activo { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }

        public class bec_cat_clientes
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int IdCliente { get; set; }
            public rh_cat_personas rh_cat_personas { get; set; }
            public Nullable<DateTime> FechaAlta { get; set; }
            public Int16 IdTipoGrupo { get; set; }
            public Int16 IdGrupo { get; set; }
            public rh_cat_grupos rh_cat_grupos { get; set; }

            public Nullable<DateTime> FechaReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Activo { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }

        public class bec_institutos_personas
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]

            public Int16 IdInstituto { get; set; }
            public cat_institutos cat_institutos { get; set; }
            public int IdPersona { get; set; }
            public rh_cat_personas rh_cat_personas { get; set; }
            public Int16 IdPerfil { get; set; }
            public rh_cat_perfiles rh_cat_perfiles { get; set; }

            [StringLength(1)]
            public string Activo { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }

        public class reg_personas
        {
            public List<rh_cat_personas> rh_cat_personas { get; set; }
            public List<bec_institutos_personas> bec_institutos_personas { get; set; }
            public List<bec_cat_clientes> bec_cat_clientes { get; set; }
            public List<rh_cat_dir_web> rh_cat_dir_web { get; set; }
            public List<rh_cat_catedraticos> rh_cat_catedraticos { get; set; }
            public List<rh_cat_empleados> rh_cat_empleados { get; set; }
            public List<rh_cat_alumnos> rh_cat_alumnos { get; set; }
            public List<rh_cat_personas_datos_adicionales> rh_cat_personas_datos_adicionales { get; set; }
            public List<rh_cat_telefonos> rh_cat_telefonos { get; set; }
            public List<rh_cat_domicilios> rh_cat_domicilios { get; set; }
            public List<rh_cat_personas_perfiles> rh_cat_personas_perfiles { get; set; }
            public List<rh_personas_perfil_estatus> rh_personas_perfil_estatus { get; set; }
        }



        //===========================================catalogos================================================//




        public class cat_institutos
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdInstituto { get; set; }
            [StringLength(50)]
            public string DesInstituto { get; set; }
            [StringLength(20)]
            public string Alias { get; set; }
            [StringLength(1)]
            public string Matriz { get; set; }
            public Nullable<Int16> IdInstitutoPadre { get; set; }
            public cat_institutos cat_Institutos { get; set; }
            public Int16 IdTipoGenGiro { get; set; }
            public Int16 IdGenGiro { get; set; }
            public cat_generales cat_generales_giro { get; set; }

            [StringLength(1)]
            public string Activo { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }

        public class cat_paises
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdPais { get; set; }
            [StringLength(20)]
            public string DesPais { get; set; }
            [StringLength(5)]
            public string ClavePais { get; set; }

            [StringLength(1)]
            public string Activo { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }


        public class cat_estados
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdEstado { get; set; }
            public Int16 IdPais { get; set; }
            public cat_paises cat_paises { get; set; }
            [StringLength(5)]
            public string ClaveEstado { get; set; }
            [StringLength(50)]
            public string DesEstado { get; set; }
            [StringLength(5)]
            public string Abreviatura { get; set; }
            [StringLength(50)]
            public string DesCapital { get; set; }

            [StringLength(1)]
            public string Activo { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }

        public class cat_municipios
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdMunicipio { get; set; }
            public Int16 IdPais { get; set; }
            public cat_paises cat_paises { get; set; }
            public Int16 IdEstado { get; set; }
            public cat_estados cat_estados { get; set; }
            [StringLength(5)]
            public string ClaveMunicipio { get; set; }
            [StringLength(30)]
            public string DesMunicipio { get; set; }

            [StringLength(1)]
            public string Activo { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }

        public class cat_localidades
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdLocalidad { get; set; }
            public Int16 IdPais { get; set; }
            public cat_paises cat_paises { get; set; }
            public Int16 IdEstado { get; set; }
            public cat_estados cat_estados { get; set; }
            public Int16 IdMunicipio { get; set; }
            public cat_municipios cat_municipios { get; set; }
            [StringLength(10)]
            public string ClaveLocalidad { get; set; }
            [StringLength(100)]
            public string DesLocalidad { get; set; }
            [StringLength(20)]
            public string GradoMarginacion { get; set; }

            [StringLength(1)]
            public string Activo { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }

        public class cat_colonias
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdColonia { get; set; }
            public Int16 IdPais { get; set; }
            public cat_paises cat_paises { get; set; }
            public Int16 IdEstado { get; set; }
            public cat_estados cat_estados { get; set; }
            public Int16 IdMunicipio { get; set; }
            public cat_municipios cat_municipios { get; set; }
            public Int16 IdLocalidad { get; set; }
            public cat_localidades cat_localidades { get; set; }
            [StringLength(10)]
            public string ClaveColonia { get; set; }
            [StringLength(30)]
            public string DesColonia { get; set; }
            [StringLength(10)]
            public string CodPostal { get; set; }
            [StringLength(20)]
            public string TipoAsentamiento { get; set; }

            [StringLength(1)]
            public string Activo { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }

        public class cat_tipos_generales
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdTipoGeneral { get; set; }
            [StringLength(100)]
            public string DesTipo { get; set; }

            [StringLength(1)]
            public string Activo { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }

        public class cat_generales
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdGeneral { get; set; }
            public Int16 IdTipoGeneral { get; set; }
            public cat_tipos_generales cat_tipos_generales { get; set; }
            [StringLength(20)]
            public string Clave { get; set; }
            [StringLength(100)]
            public string DesGeneral { get; set; }
            [StringLength(50)]
            public string LlaveClasifica { get; set; }
            [StringLength(50)]
            public string Referencia { get; set; }

            [StringLength(1)]
            public string Activo { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }


        //no tenemos tabla de carreras
        public class eva_cat_carreras
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdCarrera { get; set; }
            [StringLength(50)]
            public string ClaveCarrera { get; set; }
            [StringLength(50)]
            public string ClaveOficial { get; set; }
            [StringLength(100)]
            public string DesCarrera { get; set; }
            [StringLength(10)]
            public string Alias { get; set; }
            public Int16 IdTipoGenGradoEscolar { get; set; }
            public Int16 IdGenGradoEscolar { get; set; }
            public cat_generales cat_generales_grado { get; set; }
            [StringLength(50)]
            public string NombreCorto { get; set; }
            public int Creditos { get; set; }
            public Int16 IdTipoGenModalidad { get; set; }
            public Int16 IdGenModalidad { get; set; }
            public cat_generales cat_generales_modalidad { get; set; }
            public Nullable<DateTime> FechaIni { get; set; }
            public Nullable<DateTime> FechaFin { get; set; }

            [StringLength(1)]
            public string Activo { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }

        public class cat_tipos_estatus
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdTipoEstatus { get; set; }
            [StringLength(30)]
            public string DesTipoEstatus { get; set; }

            [StringLength(1)]
            public string Activo { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }

        public class cat_estatus
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdEstatus { get; set; }
            public Int16 IdTipoEstatus { get; set; }
            public cat_tipos_estatus cat_tipos_estatus { get; set; }
            [StringLength(50)]
            public string Clave { get; set; }
            [StringLength(30)]
            public string DesEstatus { get; set; }

            [StringLength(1)]
            public string Activo { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }

        }

        //no tenemos tabla de rh_cat_tipos_grupos
        public class rh_cat_tipo_grupos
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdTipoGrupo { get; set; }
            [StringLength(60)]
            public string DesTipoGrupo { get; set; }

            [StringLength(1)]
            public string Activo { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }

        public class rh_cat_grupos
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdGrupo { get; set; }
            public Int16 IdTipoGrupo { get; set; }
            public rh_cat_tipo_grupos rh_cat_tipo_grupos { get; set; }
            [StringLength(60)]
            public string DesGrupo { get; set; }

            [StringLength(1)]
            public string Activo { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }

        public class rh_cat_perfiles
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdPerfil { get; set; }
            [StringLength(500)]
            public string DesPerfil { get; set; }

            [StringLength(1)]
            public string Activo { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }

        public class FillPicker
        {
            public string Clave { get; set; }
            public string Valor { get; set; }

        }//CLASE PARA LOS PICKERS ESTATICOS, TIPO PERSONA, SEXO

        public class catalogos
        {
            public List<cat_institutos> cat_institutos { get; set; }
            public List<cat_tipos_estatus> cat_tipos_estatus { get; set; }
            public List<cat_estatus> cat_estatus { get; set; }
            public List<cat_tipos_generales> cat_tipos_generales { get; set; }
            public List<cat_generales> cat_generales { get; set; }
            public List<rh_cat_tipo_grupos> rh_cat_tipo_grupos { get; set; }
            public List<rh_cat_grupos> rh_cat_grupos { get; set; }
            public List<eva_cat_carreras> eva_cat_carreras { get; set; }
            public List<cat_paises> cat_paises { get; set; }
            public List<cat_estados> cat_estados { get; set; }
            public List<cat_municipios> cat_municipios { get; set; }
            public List<cat_colonias> cat_colonias { get; set; }
            public List<cat_localidades> cat_localidades { get; set; }
            public List<rh_cat_perfiles> rh_cat_perfiles { get; set; }
        }

        public class institutos_personas_text
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]

            public Int16 IdInstituto { get; set; }
            public cat_institutos cat_institutos { get; set; }
            [StringLength(50)]
            public string Instituto { get; set; }
            public int IdPersona { get; set; }
            public rh_cat_personas rh_cat_personas { get; set; }
            public Int16 IdPerfil { get; set; }
            public rh_cat_perfiles rh_cat_perfiles { get; set; }
            [StringLength(50)]
            public string Perfil { get; set; }
            [StringLength(1)]
            public string Activo { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        }

    }



}
