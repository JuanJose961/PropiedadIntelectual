﻿using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using dll_Gis;
using System.Web;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Spreadsheet;
using DevExtreme.AspNet.Data;
using GISMVC.Controllers;

namespace GISMVC.Models
{
    public class RegistroMarcaOBJ
    {
        public RegistroMarca registro { get; set; } = new RegistroMarca();
        public bool enviar_correo_registro { get; set; } = false;
        public bool enviar_correo_actualizar { get; set; } = false;
        public bool correo_registro { get; set; } = false;
        public bool enviar_correo_renovacion { get; set; } = false;
        public string nombre_despacho { get; set; } = "";
        public string email_despacho { get; set; } = "";
    }
    public class Solicitud
    {
        public int id { get; set; } = 0;
        public string nombre { get; set; } = "";
        public string usuario { get; set; } = "";
        public int empresa { get; set; } = 0;
        public int pais { get; set; } = 0;
        public int tipo { get; set; } = 0;
        public int tipo_solicitud { get; set; } = 0;
        public int activo { get; set; } = 0;
        public int atendido { get; set; } = 0;
        public int tipo_registro { get; set; } = 0;

        public Solicitud(int _id, string _nombre, int _empresa, int _pais, int _tipo, string _usuario,int _tipo_solicitud, int _activo, int _atendido, int _tipo_registro)
        {
            id = _id;
            nombre = _nombre;
            empresa = _empresa;
            pais = _pais;
            tipo = _tipo;
            usuario = _usuario;
            tipo_solicitud = _tipo_solicitud;
            activo = _activo;
            atendido = _atendido;
            tipo_registro = _tipo_registro;
        }
        public static List<Solicitud> ListMarcaToSolicitud(List<Marca> lista)
        {
            List<Solicitud> list = new List<Solicitud>();

            try
            {
                foreach (var item in lista)
                {
                    Solicitud solicitud = new Solicitud(item.id, item.nombre, item.empresa, item.pais, 1, item.usuario,item.tipo_solicitud,item.activo,item.atendido,item.tipo);
                    list.Add(solicitud);
                }
            }
            catch (Exception ex)
            {
                list = new List<Solicitud>();
            }
            return list;
        }
        public static List<Solicitud> ListAvisoComercialToSolicitud(List<AvisoComercial> lista)
        {
            List<Solicitud> list = new List<Solicitud>();

            try
            {
                foreach (var item in lista)
                {
                    Solicitud solicitud = new Solicitud(item.id, item.nombre, item.empresa, item.pais, 2, item.usuario, item.tipo_solicitud, item.activo, item.atendido,item.tipo);
                    list.Add(solicitud);
                }
            }
            catch (Exception ex)
            {
                list = new List<Solicitud>();
            }
            return list;
        }
        public static List<Solicitud> ListPatenteToSolicitud(List<Patente> lista)
        {
            List<Solicitud> list = new List<Solicitud>();

            try
            {
                foreach (var item in lista)
                {
                    Solicitud solicitud = new Solicitud(item.id, item.nombre_patente, item.empresa, item.pais, 3, item.usuario, item.tipo_solicitud, item.activo, item.atendido,0);
                    list.Add(solicitud);
                }
            }
            catch (Exception ex)
            {
                list = new List<Solicitud>();
            }
            return list;
        }
        public static List<Solicitud> ListDisenoIndustrialToSolicitud(List<DisenoIndustrial> lista)
        {
            List<Solicitud> list = new List<Solicitud>();

            try
            {
                foreach (var item in lista)
                {
                    Solicitud solicitud = new Solicitud(item.id, item.nombre_patente, item.empresa, item.pais, 4, item.usuario, item.tipo_solicitud, item.activo, item.atendido,0);
                    list.Add(solicitud);
                }
            }
            catch (Exception ex)
            {
                list = new List<Solicitud>();
            }
            return list;
        }
        public static List<Solicitud> ListModeloUtilidadToSolicitud(List<ModeloUtilidad> lista)
        {
            List<Solicitud> list = new List<Solicitud>();

            try
            {
                foreach (var item in lista)
                {
                    Solicitud solicitud = new Solicitud(item.id, item.nombre_patente, item.empresa, item.pais, 5, item.usuario, item.tipo_solicitud, item.activo, item.atendido,0);
                    list.Add(solicitud);
                }
            }
            catch (Exception ex)
            {
                list = new List<Solicitud>();
            }
            return list;
        }
        public static List<Solicitud> ListModeloIndustrialToSolicitud(List<ModeloIndustrial> lista)
        {
            List<Solicitud> list = new List<Solicitud>();

            try
            {
                foreach (var item in lista)
                {
                    Solicitud solicitud = new Solicitud(item.id, item.nombre_patente, item.empresa, item.pais, 6, item.usuario, item.tipo_solicitud, item.activo, item.atendido,0);
                    list.Add(solicitud);
                }
            }
            catch (Exception ex)
            {
                list = new List<Solicitud>();
            }
            return list;
        }
        public static List<Solicitud> ListObraToSolicitud(List<Obra> lista)
        {
            List<Solicitud> list = new List<Solicitud>();

            try
            {
                foreach (var item in lista)
                {
                    Solicitud solicitud = new Solicitud(item.id, item.nombre_obra, item.empresa, item.pais, 7, item.usuario, item.tipo_solicitud, item.activo, item.atendido,0);
                    list.Add(solicitud);
                }
            }
            catch (Exception ex)
            {
                list = new List<Solicitud>();
            }
            return list;
        }
    }
    public class TipoSolicitud
    {
        public int id { get; set; } = 0;
        public string nombre { get; set; } = "";
        public static TipoSolicitud GetById(int id)
        {
            TipoSolicitud res = new TipoSolicitud();
            List<TipoSolicitud> list = new List<TipoSolicitud>();
            list.Add(new TipoSolicitud() { id = 1, nombre = "Marca" });
            list.Add(new TipoSolicitud() { id = 2, nombre = "Aviso Comercial" });
            list.Add(new TipoSolicitud() { id = 3, nombre = "Patente" });
            list.Add(new TipoSolicitud() { id = 4, nombre = "Diseño Industrial" });
            list.Add(new TipoSolicitud() { id = 5, nombre = "Modelo de Utilidad" });
            list.Add(new TipoSolicitud() { id = 6, nombre = "Modelo Industrial" });
            list.Add(new TipoSolicitud() { id = 7, nombre = "Obra Artística" });
            list.Add(new TipoSolicitud() { id = 8, nombre = "Obra Visual" });
            list.Add(new TipoSolicitud() { id = 9, nombre = "Obra Literaria" });
            list.Add(new TipoSolicitud() { id = 10, nombre = "Obra Auditiva" });
            list.Add(new TipoSolicitud() { id = 11, nombre = "Obra Gráfica" });
            list.Add(new TipoSolicitud() { id = 12, nombre = "Obra Tecnológica" });

            if (id >= 1 && id <= 12)
            {
                res = list.Where(i => i.id == id).FirstOrDefault();
            }
            return res;
        }

        public static List<TipoSolicitud> Get(int activo = -1)
        {
            List<TipoSolicitud> list = new List<TipoSolicitud>();
            list.Add(new TipoSolicitud() { id = 1, nombre = "Marca" });
            list.Add(new TipoSolicitud() { id = 2, nombre = "Aviso Comercial" });
            list.Add(new TipoSolicitud() { id = 3, nombre = "Patente" });
            list.Add(new TipoSolicitud() { id = 4, nombre = "Diseño Industrial" });
            list.Add(new TipoSolicitud() { id = 5, nombre = "Modelo de Utilidad" });
            list.Add(new TipoSolicitud() { id = 6, nombre = "Modelo Industrial" });
            list.Add(new TipoSolicitud() { id = 7, nombre = "Obra Artística" });
            list.Add(new TipoSolicitud() { id = 8, nombre = "Obra Visual" });
            list.Add(new TipoSolicitud() { id = 9, nombre = "Obra Literaria" });
            list.Add(new TipoSolicitud() { id = 10, nombre = "Obra Auditiva" });
            list.Add(new TipoSolicitud() { id = 11, nombre = "Obra Gráfica" });
            list.Add(new TipoSolicitud() { id = 12, nombre = "Obra Tecnológica" });

            return list;
        }

    }

    public class TipoPago
    {
        public int id { get; set; } = 0;
        public string nombre { get; set; } = "";
        public static TipoPago GetById(int id)
        {
            TipoPago res = new TipoPago();
            List<TipoPago> list = new List<TipoPago>();
            list.Add(new TipoPago() { id = 1, nombre = "Quinquenio" });
            list.Add(new TipoPago() { id = 2, nombre = "Anualidad" });
            

            if (id >= 1 && id <= 2)
            {
                res = list.Where(i => i.id == id).FirstOrDefault();
            }
            return res;
        }

        public static List<TipoPago> Get(int activo = -1)
        {
            List<TipoPago> list = new List<TipoPago>();
            list.Add(new TipoPago() { id = 1, nombre = "Quinquenio" });
            list.Add(new TipoPago() { id = 2, nombre = "Anualidad" });
            

            return list;
        }

    }

    public class Uso
    {
        public int id { get; set; } = 0;
        public string nombre { get; set; } = "";
        public static Uso GetById(int id)
        {
            Uso res = new Uso();
            List<Uso> list = new List<Uso>();
            list.Add(new Uso() { id = 1, nombre = "No" });
            list.Add(new Uso() { id = 2, nombre = "Si" });


            if (id >= 1 && id <= 2)
            {
                res = list.Where(i => i.id == id).FirstOrDefault();
            }
            return res;
        }

        public static List<Uso> Get(int activo = -1)
        {
            List<Uso> list = new List<Uso>();
            list.Add(new Uso() { id = 1, nombre = "No" });
            list.Add(new Uso() { id = 2, nombre = "Si" });


            return list;
        }

    }
    public class RegistroMarca
    {
        public int id { get; set; } = 0;
        public int empresa { get; set; } = 0;
        public string empresa_desc { get; set; } = "";
        public int empresa_anterior { get; set; } = 0;
        public string empresa_anterior_desc { get; set; } = "";
        public string nombre { get; set; } = "";
        public string no_registro { get; set; } = "";
        public string titulo { get; set; } = "";
        public DateTime fecha_legal { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_vencimiento { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_concesion { get; set; } = DateTime.Parse("1969-01-01");
        public string fecha_legalS { get; set; } = "";
        public string fecha_vencimientoS { get; set; } = "";
        public string fecha_concesionS { get; set; } = "";
        public int clase { get; set; } = 0;
        public string clase_desc { get; set; } = "";
        public int tipo_registro { get; set; } = 0;
        public string tipo_registro_desc { get; set; } = "";
        public int pais { get; set; } = 0;
        public string pais_desc { get; set; } = "";
        public int estatus { get; set; } = 0;
        public string estatus_desc { get; set; } = "";
        public string solicitud_nombre { get; set; } = "";
        public byte[] solicitud_data { get; set; }
        public string solicitud_content_type { get; set; } = "";
        public int solicitud_size { get; set; } = 0;
        public string solicitud_extension { get; set; } = "";
        public string solicitud_nombre_original { get; set; } = "";
        public string solicitud_url { get; set; } = "";
        public string no_solicitud { get; set; } = "";
        public int tipo_registro_solicitud { get; set; } = 0;
        public string tipo_registro_solicitud_desc { get; set; } = "";
        public string autor_registro { get; set; } = "";
        public string autor_registro_desc { get; set; } = "";
        public int despacho { get; set; } = 0;
        public string despacho_desc { get; set; } = "";
        public int corresponsal { get; set; } = 0;
        public string corresponsal_desc { get; set; } = "";
        public string solicitante_licencia { get; set; } = "";
        public string solicitante_licencia_desc { get; set; } = "";
        public int licencia { get; set; } = 0;
        public string licencia_desc { get; set; } = "";
        public string solicitante_cesion { get; set; } = "";
        public string solicitante_cesion_desc { get; set; } = "";
        public int cesion { get; set; } = 0;
        public string cesion_desc { get; set; } = "";
        public DateTime fecha_requerimiento { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_requerimiento_completo { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_instrucciones { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_instrucciones_completo { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_registro { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_registro_completo { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_busqueda { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_busqueda_completo { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_resultados { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_resultados_completo { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_comprobacion { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_comprobacion_completo { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_vencimiento_workflow { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_vencimiento_workflow_completo { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_concesion_workflow { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_concesion_workflow_completo { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_declaracion { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_declaracion_completo { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fc { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fu { get; set; } = DateTime.Parse("1969-01-01");
        public string usuario { get; set; } = "";
        public string usuario_desc { get; set; } = "";
        public int activo { get; set; } = 0;
        public string titulo_nombre { get; set; } = "";
        public byte[] titulo_data { get; set; }
        public string titulo_content_type { get; set; } = "";
        public int titulo_size { get; set; } = 0;
        public string titulo_extension { get; set; } = "";
        public string titulo_nombre_original { get; set; } = "";
        public string titulo_url { get; set; } = "";
        public int solicitud { get; set; } = 0;
        public string solicitud_desc { get; set; } = "";
        public int solicitud_tipo { get; set; } = 0;
        public string solicitud_tipo_desc { get; set; } = "";

        public string fecha_requerimientoS { get; set; } = "";
        public string fecha_requerimiento_completoS { get; set; } = "";
        public string fecha_instruccionesS { get; set; } = "";
        public string fecha_instrucciones_completoS { get; set; } = "";
        public string fecha_registroS { get; set; } = "";
        public string fecha_registro_completoS { get; set; } = "";
        public string fecha_busquedaS { get; set; } = "";
        public string fecha_busqueda_completoS { get; set; } = "";
        public string fecha_resultadosS { get; set; } = "";
        public string fecha_resultados_completoS { get; set; } = "";
        public string fecha_comprobacionS { get; set; } = "";
        public string fecha_comprobacion_completoS { get; set; } = "";
        public string fecha_vencimiento_workflowS { get; set; } = "";
        public string fecha_vencimiento_workflow_completoS { get; set; } = "";
        public string fecha_concesion_workflowS { get; set; } = "";
        public string fecha_concesion_workflow_completoS { get; set; } = "";
        public string fecha_declaracionS { get; set; } = "";
        public string fecha_declaracion_completoS { get; set; } = "";


        public string solicitud_permalink { get; set; } = "";
        public string titulo_permalink { get; set; } = "";
        public string permalink { get; set; } = "";
        public string notificacion_titulo { get; set; } = "";
        public string notificacion_vencimiento { get; set; } = "";
        public int vobo { get; set; } = 0;
        public string notificacion_estatus { get; set; } = "";
        //

        public DateTime fecha_renovar { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_renovar_completo { get; set; } = DateTime.Parse("1969-01-01");
        public string fecha_renovarS { get; set; } = "";
        public string fecha_renovar_completoS { get; set; } = "";
        public DateTime fecha_instruccion_corresponsal { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_instruccion_corresponsal_completo { get; set; } = DateTime.Parse("1969-01-01");
        public string fecha_instruccion_corresponsalS { get; set; } = "";
        public string fecha_instruccion_corresponsal_completoS { get; set; } = "";
        public DateTime fecha_solicitud_empresa { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_solicitud_empresa_completo { get; set; } = DateTime.Parse("1969-01-01");
        public string fecha_solicitud_empresaS { get; set; } = "";
        public string fecha_solicitud_empresa_completoS { get; set; } = "";
        public DateTime fecha_despacho { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_despacho_completo { get; set; } = DateTime.Parse("1969-01-01");
        public string fecha_despachoS { get; set; } = "";
        public string fecha_despacho_completoS { get; set; } = "";
        public DateTime oficio_completo { get; set; } = DateTime.Parse("1969-01-01");
        public string oficio_completoS { get; set; } = "";
        public string oficio_nombre { get; set; } = "";
        public byte[] oficio_data { get; set; }
        public string oficio_content_type { get; set; } = "";
        public int oficio_size { get; set; } = 0;
        public string oficio_extension { get; set; } = "";
        public string oficio_nombre_original { get; set; } = "";
        public string oficio_url { get; set; } = "";
        public string oficio_permalink { get; set; } = "";
        public int renovacion { get; set; } = 0;
        public int uso { get; set; } = 0;
        public string uso_desc { get; set; } = "";
        public DateTime fecha_quinquenio_anualidad { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fecha_vencimiento_prioridad { get; set; } = DateTime.Parse("1969-01-01");
        public string fecha_quinquenio_anualidadS { get; set; } = "";
        public string fecha_vencimiento_prioridadS { get; set; } = "";
        public int tipo_pago { get; set; } = 0;
        public string tipo_pago_desc { get; set; } = "";
        public string prioridad { get; set; } = "";
        public string autor { get; set; } = "";
        public string contrato_nombre { get; set; } = "";
        public byte[] contrato_data { get; set; }
        public string contrato_content_type { get; set; } = "";
        public int contrato_size { get; set; } = 0;
        public string contrato_extension { get; set; } = "";
        public string contrato_nombre_original { get; set; } = "";
        public string contrato_url { get; set; } = "";
        public string contrato_permalink { get; set; } = "";
        public string reivindicacion_nombre { get; set; } = "";
        public byte[] reivindicacion_data { get; set; }
        public string reivindicacion_content_type { get; set; } = "";
        public int reivindicacion_size { get; set; } = 0;
        public string reivindicacion_extension { get; set; } = "";
        public string reivindicacion_nombre_original { get; set; } = "";
        public string reivindicacion_url { get; set; } = "";
        public string reivindicacion_permalink { get; set; } = "";
        public string carta_nombre { get; set; } = "";
        public byte[] carta_data { get; set; }
        public string carta_content_type { get; set; } = "";
        public int carta_size { get; set; } = 0;
        public string carta_extension { get; set; } = "";
        public string carta_nombre_original { get; set; } = "";
        public string carta_url { get; set; } = "";
        public string carta_permalink { get; set; } = "";
        public int idlic { get; set; } = 0;
        public string licencia_fecha_vencimientoS { get; set; } = "";
        public DateTime licencia_fecha_vencimiento { get; set; }= DateTime.Parse("1969-01-01");
        public string licencia_observaciones { get; set; } = "";
        public string licencia_nombre_original { get; set; } = "";
        public string licencia_permalink { get; set; } = "";
        public int idces { get; set; } = 0;
        public string cesion_fecha_vencimientoS { get; set; } = "";
        public DateTime cesion_fecha_vencimiento { get; set; } = DateTime.Parse("1969-01-01");
        public string cesion_observaciones { get; set; } = "";
        public string cesion_nombre_original { get; set; } = "";
        public string cesion_permalink { get; set; } = "";
        public string cesion_cesionario { get; set; } = "";
        public string cesion_nombre { get; set; } = "";
        public string cesion_expediente { get; set; } = "";
        public string cesion_cedente { get; set; } = "";
        public string cesion_registro { get; set; } = "";
        public string cesion_clase { get; set; } = "";
        public string cesion_pais { get; set; } = "";
        public DateTime nueva_fecha_vencimiento { get; set; } = DateTime.Parse("1969-01-01");
        public string nueva_fecha_vencimientoS { get; set; } = "";
        public string id_usuario { get; set; } = "";
        public int cktodo { get; set; } = 0;
        public RegistroMarca()
        {
        }


        public static RegistroMarca GetById(int id)
        {
            RegistroMarca res = new RegistroMarca();
            Funciones funcion = new Funciones();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_proc_RegistroMarcaById(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];

                        res.id = Int32.Parse(row[idx].ToString()); idx++;
                        res.empresa = Int32.Parse(row[idx].ToString()); idx++;
                        res.empresa_desc = row[idx].ToString(); idx++;
                        res.empresa_anterior = Int32.Parse(row[idx].ToString()); idx++;
                        res.empresa_anterior_desc = row[idx].ToString(); idx++;
                        res.nombre = row[idx].ToString(); idx++;
                        res.no_registro = row[idx].ToString(); idx++;
                        res.titulo = row[idx].ToString(); idx++;
                        res.fecha_legal = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_vencimiento = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_concesion = DateTime.Parse(row[idx].ToString()); idx++;
                        res.clase = Int32.Parse(row[idx].ToString()); idx++;
                        res.clase_desc = row[idx].ToString(); idx++;
                        res.tipo_registro = Int32.Parse(row[idx].ToString()); idx++;
                        res.tipo_registro_desc = row[idx].ToString(); idx++;
                        res.pais = Int32.Parse(row[idx].ToString()); idx++;
                        res.pais_desc = row[idx].ToString(); idx++;
                        res.estatus = Int32.Parse(row[idx].ToString()); idx++;
                        res.estatus_desc = row[idx].ToString(); idx++;
                        res.solicitud_nombre = row[idx].ToString(); idx++;
                        if (res.solicitud_nombre != "")
                        {
                            res.solicitud_permalink = Utility.hosturl + "PI/RegistroMarcaDocumento?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.id.ToString())) + "&tp=" + HttpUtility.UrlEncode(funcion.Encriptar("solicitud"));
                        }
                        //if (res.solicitud_nombre != "" && row[idx] != null) { res.solicitud_data = (byte[])row[idx]; }
                        idx++;
                        res.solicitud_content_type = row[idx].ToString(); idx++;
                        res.solicitud_size = Int32.Parse(row[idx].ToString()); idx++;
                        res.solicitud_extension = row[idx].ToString(); idx++;
                        res.solicitud_nombre_original = row[idx].ToString(); idx++;
                        res.solicitud_url = row[idx].ToString(); idx++;
                        res.no_solicitud = row[idx].ToString(); idx++;
                        res.tipo_registro_solicitud = Int32.Parse(row[idx].ToString()); idx++;
                        res.tipo_registro_solicitud_desc = row[idx].ToString(); idx++;
                        res.autor_registro = row[idx].ToString(); idx++;
                        res.autor_registro_desc = row[idx].ToString(); idx++;
                        res.despacho = Int32.Parse(row[idx].ToString()); idx++;
                        res.despacho_desc = row[idx].ToString(); idx++;
                        res.corresponsal = Int32.Parse(row[idx].ToString()); idx++;
                        res.corresponsal_desc = row[idx].ToString(); idx++;
                        res.solicitante_licencia = row[idx].ToString(); idx++;
                        res.solicitante_licencia_desc = row[idx].ToString(); idx++;
                        res.licencia = Int32.Parse(row[idx].ToString()); idx++;
                        res.licencia_desc = row[idx].ToString(); idx++;
                        if (res.licencia >= 1)
                        {
                            DataAccess da2 = new DataAccess();
                            var dt2 = new System.Data.DataTable();
                            var errores2 = "";
                            if (da2.Cons_ConvenioLicenciaById(res.licencia, out dt2, out errores2))
                            {
                                if (dt2.Rows.Count > 0)
                                {
                                    int idx2 = 0;
                                    var row2 = dt2.Rows[0];

                                    res.idlic = Int32.Parse(row2[idx2].ToString()); idx2++;
                                    idx2 = 21;
                                    res.licencia_fecha_vencimiento = DateTime.Parse(row2[idx2].ToString()); idx2++;
                                    idx2 = 22;
                                    res.licencia_observaciones = row2[idx2].ToString(); idx2++;
                                    idx2 = 59;
                                    res.licencia_nombre_original= row2[idx2].ToString(); idx2++;
                                }
                                else
                                {
                                    res.idlic = 0;
                                    res.licencia_fecha_vencimiento = DateTime.Parse("1969-01-01");
                                    res.licencia_observaciones = "";
                                    res.licencia_nombre_original = "";

                                }
                            }
                        }
                        if (res.licencia_desc != "" && res.licencia_nombre_original != "")
                        {
                            //res.licencia_permalink = Utility.hosturl + "PI/RegistroMarcaDocumento?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.idlic.ToString())) + "&tp=" + HttpUtility.UrlEncode(funcion.Encriptar("contrato"));
                            //res.licencia_permalink= Utility.hosturl + "PI/ConvenioLicenciaDocumento?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.idlic.ToString())) + "&tp=" + HttpUtility.UrlEncode(funcion.Encriptar("contrato"));
                            res.licencia_permalink = Utility.hosturl + "PI/ConvenioLicenciaDocumento?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.idlic.ToString())) + "&tp=" + HttpUtility.UrlEncode(funcion.Encriptar("oficio"));
                        }
                        res.solicitante_cesion = row[idx].ToString(); idx++;
                        res.solicitante_cesion_desc = row[idx].ToString(); idx++;
                        res.cesion = Int32.Parse(row[idx].ToString()); idx++;
                        res.cesion_desc = row[idx].ToString(); idx++;
                        if (res.cesion >= 1)
                        {
                            DataAccess da3 = new DataAccess();
                            var dt3 = new System.Data.DataTable();
                            var errores3 = "";
                            if (da3.Cons_ContratoCesionById(res.cesion, out dt3, out errores3))
                            {
                                if (dt3.Rows.Count > 0)
                                {
                                    int idx3 = 0;
                                    var row3 = dt3.Rows[0];

                                    res.idces = Int32.Parse(row3[idx3].ToString()); idx3++;
                                    idx3 = 2;
                                    res.cesion_cedente = row3[idx3].ToString(); idx3++;
                                    idx3 = 4;
                                    res.cesion_cesionario = row3[idx3].ToString(); idx3++;
                                    idx3 = 7;
                                    res.cesion_nombre = row3[idx3].ToString(); idx3++;
                                    res.cesion_registro = row3[idx3].ToString(); idx3++;
                                    res.cesion_expediente = row3[idx3].ToString(); idx3++;
                                    idx3 = 11;
                                    res.cesion_clase = row3[idx3].ToString(); idx3++;
                                    idx3 = 13;
                                    res.cesion_pais = row3[idx3].ToString(); idx3++;
                                    idx3 = 21;
                                    res.cesion_fecha_vencimiento = DateTime.Parse(row3[idx3].ToString()); idx3++;
                                    idx3 = 22;
                                    res.cesion_observaciones = row3[idx3].ToString(); idx3++;
                                    idx3 = 59;
                                    res.cesion_nombre_original = row3[idx3].ToString(); idx3++;
                                }
                                else
                                {
                                    res.idces = 0;
                                    res.cesion_fecha_vencimiento = DateTime.Parse("1969-01-01");
                                    res.cesion_observaciones = "";
                                    res.cesion_nombre_original = "";

                                }
                            }
                        }
                        if (res.cesion_desc != "" && res.cesion_nombre_original != "")
                        {
                            //res.licencia_permalink = Utility.hosturl + "PI/ConvenioLicenciaDocumento?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.idlic.ToString())) + "&tp=" + HttpUtility.UrlEncode(funcion.Encriptar("oficio"));
                            res.cesion_permalink = Utility.hosturl + "PI/ContratoCesionDocumento?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.idces.ToString())) + "&tp=" + HttpUtility.UrlEncode(funcion.Encriptar("oficio"));
                        }
                        res.fecha_requerimiento = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_requerimiento_completo = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_instrucciones = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_instrucciones_completo = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_registro = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_registro_completo = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_busqueda = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_busqueda_completo = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_resultados = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_resultados_completo = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_comprobacion = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_comprobacion_completo = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_vencimiento_workflow = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_vencimiento_workflow_completo = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_concesion_workflow = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_concesion_workflow_completo = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fc = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fu = DateTime.Parse(row[idx].ToString()); idx++;
                        res.usuario = row[idx].ToString(); idx++;
                        res.usuario_desc = row[idx].ToString(); idx++;
                        res.activo = Int32.Parse(row[idx].ToString()); idx++;
                        //res.tipo_pago = Int32.Parse(row[idx].ToString()); idx++;
                        //res.tipo_pago_desc = row[idx].ToString(); idx++;


                        res.titulo_nombre = row[idx].ToString(); idx++;


                        if (res.titulo_nombre != "")
                        {
                            res.titulo_permalink = Utility.hosturl + "PI/RegistroMarcaDocumento?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.id.ToString())) + "&tp=" + HttpUtility.UrlEncode(funcion.Encriptar("titulo"));
                        }
                        //if (res.titulo_nombre != "" && row[idx] != null) { res.titulo_data = (byte[])row[idx]; }
                        idx++;
                        res.titulo_content_type = row[idx].ToString(); idx++;
                        res.titulo_size = Int32.Parse(row[idx].ToString()); idx++;
                        res.titulo_extension = row[idx].ToString(); idx++;
                        res.titulo_nombre_original = row[idx].ToString(); idx++;
                        res.titulo_url = row[idx].ToString(); idx++;
                        res.solicitud = Int32.Parse(row[idx].ToString()); idx++;
                        res.solicitud_desc = row[idx].ToString(); idx++;
                        res.solicitud_tipo = Int32.Parse(row[idx].ToString()); idx++;
                        res.solicitud_tipo_desc = row[idx].ToString(); idx++;
                        res.vobo = Int32.Parse(row[idx].ToString()); idx++;
                        res.notificacion_titulo = row[idx].ToString(); idx++;
                        res.notificacion_vencimiento = row[idx].ToString(); idx++;


                        //renovacion
                        res.fecha_renovar = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_renovar_completo = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_instruccion_corresponsal = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_instruccion_corresponsal_completo = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_solicitud_empresa = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_solicitud_empresa_completo = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_despacho = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_despacho_completo = DateTime.Parse(row[idx].ToString()); idx++;
                        res.oficio_completo = DateTime.Parse(row[idx].ToString()); idx++;

                        res.oficio_nombre = row[idx].ToString(); idx++;
                        if (res.oficio_nombre != "")
                        {
                            res.oficio_permalink = Utility.hosturl + "PI/RegistroMarcaDocumento?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.id.ToString())) + "&tp=" + HttpUtility.UrlEncode(funcion.Encriptar("oficio"));
                        }
                        //if (res.titulo_nombre != "" && row[idx] != null) { res.titulo_data = (byte[])row[idx]; }
                        idx++;
                        res.oficio_content_type = row[idx].ToString(); idx++;
                        res.oficio_size = Int32.Parse(row[idx].ToString()); idx++;
                        res.oficio_extension = row[idx].ToString(); idx++;
                        res.oficio_nombre_original = row[idx].ToString(); idx++;
                        res.oficio_url = row[idx].ToString(); idx++;
                        res.renovacion = Int32.Parse(row[idx].ToString()); idx++;

                        res.fecha_quinquenio_anualidad = DateTime.Parse(row[idx].ToString()); idx++;
                        res.tipo_pago = Int32.Parse(row[idx].ToString()); idx++;
                        res.tipo_pago_desc = row[idx].ToString(); idx++;
                        res.prioridad = row[idx].ToString(); idx++;
                        res.fecha_vencimiento_prioridad = DateTime.Parse(row[idx].ToString()); idx++;
                        res.contrato_nombre = row[idx].ToString(); idx++;
                        if (res.contrato_nombre != "")
                        {
                            res.contrato_permalink = Utility.hosturl + "PI/RegistroMarcaDocumento?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.id.ToString())) + "&tp=" + HttpUtility.UrlEncode(funcion.Encriptar("contrato"));
                        }
                        idx++;
                        res.contrato_content_type = row[idx].ToString(); idx++;
                        res.contrato_size = Int32.Parse(row[idx].ToString()); idx++;
                        res.contrato_extension = row[idx].ToString(); idx++;
                        res.contrato_nombre_original = row[idx].ToString(); idx++;
                        res.contrato_url = row[idx].ToString(); idx++;
                        res.reivindicacion_nombre = row[idx].ToString(); idx++;
                        if (res.reivindicacion_nombre != "")
                        {
                            res.reivindicacion_permalink = Utility.hosturl + "PI/RegistroMarcaDocumento?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.id.ToString())) + "&tp=" + HttpUtility.UrlEncode(funcion.Encriptar("reivindicacion"));
                        }
                        idx++;
                        res.reivindicacion_content_type = row[idx].ToString(); idx++;
                        res.reivindicacion_size = Int32.Parse(row[idx].ToString()); idx++;
                        res.reivindicacion_extension = row[idx].ToString(); idx++;
                        res.reivindicacion_nombre_original = row[idx].ToString(); idx++;
                        res.reivindicacion_url = row[idx].ToString(); idx++;
                        res.autor = row[idx].ToString(); idx++;
                        res.carta_nombre = row[idx].ToString(); idx++;
                        if (res.carta_nombre != "")
                        {
                            res.carta_permalink = Utility.hosturl + "PI/RegistroMarcaDocumento?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.id.ToString())) + "&tp=" + HttpUtility.UrlEncode(funcion.Encriptar("carta"));
                        }
                        idx++;
                        res.carta_content_type = row[idx].ToString(); idx++;
                        res.carta_size = Int32.Parse(row[idx].ToString()); idx++;
                        res.carta_extension = row[idx].ToString(); idx++;
                        res.carta_nombre_original = row[idx].ToString(); idx++;
                        res.carta_url = row[idx].ToString(); idx++;
                        res.uso = Int32.Parse(row[idx].ToString()); idx++;
                        res.uso_desc = row[idx].ToString(); idx++;
                        res.fecha_declaracion = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_declaracion_completo = DateTime.Parse(row[idx].ToString()); idx++;
                        res.nueva_fecha_vencimiento = DateTime.Parse(row[idx].ToString()); idx++;
                        res.notificacion_estatus = row[idx].ToString(); idx++;
                        //

                        if (res.fecha_legal.Year > 1969)
                            res.fecha_legalS = res.fecha_legal.ToString("dd/MM/yyyyy");
                        if (res.fecha_vencimiento.Year > 1969)
                            res.fecha_vencimientoS = res.fecha_vencimiento.ToString("dd/MM/yyyyy");
                        if (res.fecha_concesion.Year > 1969)
                            res.fecha_concesionS = res.fecha_concesion.ToString("dd/MM/yyyyy");

                        if (res.fecha_requerimiento.Year > 1969)
                            res.fecha_requerimientoS = res.fecha_requerimiento.ToString("dd/MM/yyyyy");

                        if (res.fecha_requerimiento_completo.Year > 1969)
                            res.fecha_requerimiento_completoS = res.fecha_requerimiento_completo.ToString("dd/MM/yyyyy");

                        if (res.fecha_instrucciones.Year > 1969) 
                            res.fecha_instruccionesS = res.fecha_instrucciones.ToString("dd/MM/yyyyy");

                        if (res.fecha_instrucciones_completo.Year > 1969)
                            res.fecha_instrucciones_completoS = res.fecha_instrucciones_completo.ToString("dd/MM/yyyyy");

                        if (res.fecha_registro.Year > 1969)
                            res.fecha_registroS = res.fecha_registro.ToString("dd/MM/yyyyy");

                        if (res.fecha_registro_completo.Year > 1969)
                            res.fecha_registro_completoS = res.fecha_registro_completo.ToString("dd/MM/yyyyy");

                        if (res.fecha_busqueda.Year > 1969)
                            res.fecha_busquedaS = res.fecha_busqueda.ToString("dd/MM/yyyyy");

                        if (res.fecha_busqueda_completo.Year > 1969)
                            res.fecha_busqueda_completoS = res.fecha_busqueda_completo.ToString("dd/MM/yyyyy");

                        if (res.fecha_resultados.Year > 1969)
                            res.fecha_resultadosS = res.fecha_resultados.ToString("dd/MM/yyyyy");

                        if (res.fecha_resultados_completo.Year > 1969)
                            res.fecha_resultados_completoS = res.fecha_resultados_completo.ToString("dd/MM/yyyyy");

                        if (res.fecha_comprobacion.Year > 1969)
                            res.fecha_comprobacionS = res.fecha_comprobacion.ToString("dd/MM/yyyyy");

                        if (res.fecha_comprobacion_completo.Year > 1969)
                            res.fecha_comprobacion_completoS = res.fecha_comprobacion_completo.ToString("dd/MM/yyyyy");

                        if (res.fecha_vencimiento_workflow.Year > 1969)
                            res.fecha_vencimiento_workflowS = res.fecha_vencimiento_workflow.ToString("dd/MM/yyyyy");

                        if (res.fecha_vencimiento_workflow_completo.Year > 1969)
                            res.fecha_vencimiento_workflow_completoS = res.fecha_vencimiento_workflow_completo.ToString("dd/MM/yyyyy");

                        if (res.fecha_concesion_workflow.Year > 1969)
                            res.fecha_concesion_workflowS = res.fecha_concesion_workflow.ToString("dd/MM/yyyyy");

                        if (res.fecha_concesion_workflow_completo.Year > 1969)
                            res.fecha_concesion_workflow_completoS = res.fecha_concesion_workflow_completo.ToString("dd/MM/yyyyy");
                        //---
                        if (res.fecha_renovar.Year > 1969)
                            res.fecha_renovarS = res.fecha_renovar.ToString("dd/MM/yyyyy");

                        if (res.fecha_renovar_completo.Year > 1969)
                            res.fecha_renovar_completoS = res.fecha_renovar_completo.ToString("dd/MM/yyyyy");

                        if (res.fecha_instruccion_corresponsal.Year > 1969)
                            res.fecha_instruccion_corresponsalS = res.fecha_instruccion_corresponsal.ToString("dd/MM/yyyyy");

                        if (res.fecha_instruccion_corresponsal_completo.Year > 1969)
                            res.fecha_instruccion_corresponsal_completoS = res.fecha_instruccion_corresponsal_completo.ToString("dd/MM/yyyyy");

                        if (res.fecha_solicitud_empresa.Year > 1969)
                            res.fecha_solicitud_empresaS = res.fecha_solicitud_empresa.ToString("dd/MM/yyyyy");

                        if (res.fecha_solicitud_empresa_completo.Year > 1969)
                            res.fecha_solicitud_empresa_completoS = res.fecha_solicitud_empresa_completo.ToString("dd/MM/yyyyy");

                        if (res.fecha_despacho.Year > 1969)
                            res.fecha_despachoS = res.fecha_despacho.ToString("dd/MM/yyyyy");

                        if (res.fecha_despacho_completo.Year > 1969)
                            res.fecha_despacho_completoS = res.fecha_despacho_completo.ToString("dd/MM/yyyyy");

                        if (res.oficio_completo.Year > 1969)
                            res.oficio_completoS = res.oficio_completo.ToString("dd/MM/yyyyy");

                        if (res.fecha_quinquenio_anualidad.Year > 1969)
                            res.fecha_quinquenio_anualidadS = res.fecha_quinquenio_anualidad.ToString("dd/MM/yyyyy");

                        if (res.fecha_vencimiento_prioridad.Year > 1969)
                            res.fecha_vencimiento_prioridadS = res.fecha_vencimiento_prioridad.ToString("dd/MM/yyyyy");

                        if (res.fecha_declaracion.Year > 1969)
                            res.fecha_declaracionS = res.fecha_declaracion.ToString("dd/MM/yyyyy");

                        if (res.fecha_declaracion_completo.Year > 1969)
                            res.fecha_declaracion_completoS = res.fecha_declaracion_completo.ToString("dd/MM/yyyyy");
                        if (res.nueva_fecha_vencimiento.Year > 1969)
                            res.nueva_fecha_vencimientoS = res.nueva_fecha_vencimiento.ToString("dd/MM/yyyyy");

                        res.permalink = Utility.hosturl + "PI/RegistroMarca?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.id.ToString()));
                    }
                }
                else
                {
                    //
                }


            }
            catch (Exception ex)
            {
                res = new RegistroMarca();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<RegistroMarca> Get(int tipo_registro = 0,string id_usuario="", int activo = -1)
        {
            List<RegistroMarca> list = new List<RegistroMarca>();
            Funciones funcion = new Funciones();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_proc_RegistroMarca(out dt, out errores, tipo_registro,id_usuario ,activo))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var res = new RegistroMarca();
                            res.id = Int32.Parse(row[idx].ToString()); idx++;
                            res.empresa = Int32.Parse(row[idx].ToString()); idx++;
                            res.empresa_desc = row[idx].ToString(); idx++;
                            res.empresa_anterior = Int32.Parse(row[idx].ToString()); idx++;
                            res.empresa_anterior_desc = row[idx].ToString(); idx++;
                            res.nombre = row[idx].ToString(); idx++;
                            res.no_registro = row[idx].ToString(); idx++;
                            res.titulo = row[idx].ToString(); idx++;
                            res.fecha_legal = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_vencimiento = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_concesion = DateTime.Parse(row[idx].ToString()); idx++;
                            res.clase = Int32.Parse(row[idx].ToString()); idx++;
                            res.clase_desc = row[idx].ToString(); idx++;
                            res.tipo_registro = Int32.Parse(row[idx].ToString()); idx++;
                            res.tipo_registro_desc = row[idx].ToString(); idx++;
                            res.pais = Int32.Parse(row[idx].ToString()); idx++;
                            res.pais_desc = row[idx].ToString(); idx++;
                            res.estatus = Int32.Parse(row[idx].ToString()); idx++;
                            res.estatus_desc = row[idx].ToString(); idx++;
                            res.solicitud_nombre = row[idx].ToString(); idx++;
                            if (res.solicitud_nombre != "")
                            {
                                res.solicitud_permalink = Utility.hosturl + "PI/RegistroMarcaDocumento?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.id.ToString())) + "&tp=" + HttpUtility.UrlEncode(funcion.Encriptar("solicitud"));
                            }
                            //if (res.solicitud_nombre != "" && row[idx] != null) { res.solicitud_data = (byte[])row[idx]; }
                            idx++;
                            res.solicitud_content_type = row[idx].ToString(); idx++;
                            res.solicitud_size = Int32.Parse(row[idx].ToString()); idx++;
                            res.solicitud_extension = row[idx].ToString(); idx++;
                            res.solicitud_nombre_original = row[idx].ToString(); idx++;
                            res.solicitud_url = row[idx].ToString(); idx++;
                            res.no_solicitud = row[idx].ToString(); idx++;
                            res.tipo_registro_solicitud = Int32.Parse(row[idx].ToString()); idx++;
                            res.tipo_registro_solicitud_desc = row[idx].ToString(); idx++;
                            res.autor_registro = row[idx].ToString(); idx++;
                            res.autor_registro_desc = row[idx].ToString(); idx++;
                            res.despacho = Int32.Parse(row[idx].ToString()); idx++;
                            res.despacho_desc = row[idx].ToString(); idx++;
                            res.corresponsal = Int32.Parse(row[idx].ToString()); idx++;
                            res.corresponsal_desc = row[idx].ToString(); idx++;
                            res.solicitante_licencia = row[idx].ToString(); idx++;
                            res.solicitante_licencia_desc = row[idx].ToString(); idx++;
                            res.licencia = Int32.Parse(row[idx].ToString()); idx++;
                            res.licencia_desc = row[idx].ToString(); idx++;
                            res.solicitante_cesion = row[idx].ToString(); idx++;
                            res.solicitante_cesion_desc = row[idx].ToString(); idx++;
                            res.cesion = Int32.Parse(row[idx].ToString()); idx++;
                            res.cesion_desc = row[idx].ToString(); idx++;
                            res.fecha_requerimiento = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_requerimiento_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_instrucciones = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_instrucciones_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_registro = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_registro_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_busqueda = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_busqueda_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_resultados = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_resultados_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_comprobacion = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_comprobacion_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_vencimiento_workflow = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_vencimiento_workflow_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_concesion_workflow = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_concesion_workflow_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            res.usuario = row[idx].ToString(); idx++;
                            res.usuario_desc = row[idx].ToString(); idx++;
                            res.activo = Int32.Parse(row[idx].ToString()); idx++;

                            res.titulo_nombre = row[idx].ToString(); idx++;
                            if (res.titulo_nombre != "")
                            {
                                res.titulo_permalink = Utility.hosturl + "PI/RegistroMarcaDocumento?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.id.ToString())) + "&tp=" + HttpUtility.UrlEncode(funcion.Encriptar("titulo"));
                            }
                            //if (res.titulo_nombre != "" && row[idx] != null) { res.titulo_data = (byte[])row[idx]; }
                            idx++;
                            res.titulo_content_type = row[idx].ToString(); idx++;
                            res.titulo_size = Int32.Parse(row[idx].ToString()); idx++;
                            res.titulo_extension = row[idx].ToString(); idx++;
                            res.titulo_nombre_original = row[idx].ToString(); idx++;
                            res.titulo_url = row[idx].ToString(); idx++;
                            res.solicitud = Int32.Parse(row[idx].ToString()); idx++;
                            res.solicitud_desc = row[idx].ToString(); idx++;
                            res.solicitud_tipo = Int32.Parse(row[idx].ToString()); idx++;
                            res.solicitud_tipo_desc = row[idx].ToString(); idx++;
                            //res.nueva_fecha_vencimiento = DateTime.Parse(row[idx].ToString()); idx++;

                            if (res.fecha_legal.Year > 1969)
                                res.fecha_legalS = res.fecha_legal.ToString("dd/MM/yyyyy");
                            if (res.fecha_vencimiento.Year > 1969)
                                res.fecha_vencimientoS = res.fecha_vencimiento.ToString("dd/MM/yyyyy");
                            if (res.fecha_concesion.Year > 1969)
                                res.fecha_concesionS = res.fecha_concesion.ToString("dd/MM/yyyyy");

                            if (res.fecha_requerimiento.Year > 1969)
                                res.fecha_requerimientoS = res.fecha_requerimiento.ToString("dd/MM/yyyyy");

                            if (res.fecha_requerimiento_completo.Year > 1969)
                                res.fecha_requerimiento_completoS = res.fecha_requerimiento_completo.ToString("dd/MM/yyyyy");

                            if (res.fecha_instrucciones.Year > 1969)
                                res.fecha_instruccionesS = res.fecha_instrucciones.ToString("dd/MM/yyyyy");

                            if (res.fecha_instrucciones_completo.Year > 1969)
                                res.fecha_instrucciones_completoS = res.fecha_instrucciones_completo.ToString("dd/MM/yyyyy");

                            if (res.fecha_registro.Year > 1969)
                                res.fecha_registroS = res.fecha_registro.ToString("dd/MM/yyyyy");

                            if (res.fecha_registro_completo.Year > 1969)
                                res.fecha_registro_completoS = res.fecha_registro_completo.ToString("dd/MM/yyyyy");

                            if (res.fecha_busqueda.Year > 1969)
                                res.fecha_busquedaS = res.fecha_busqueda.ToString("dd/MM/yyyyy");

                            if (res.fecha_busqueda_completo.Year > 1969)
                                res.fecha_busqueda_completoS = res.fecha_busqueda_completo.ToString("dd/MM/yyyyy");

                            if (res.fecha_resultados.Year > 1969)
                                res.fecha_resultadosS = res.fecha_resultados.ToString("dd/MM/yyyyy");

                            if (res.fecha_resultados_completo.Year > 1969)
                                res.fecha_resultados_completoS = res.fecha_resultados_completo.ToString("dd/MM/yyyyy");

                            if (res.fecha_comprobacion.Year > 1969)
                                res.fecha_comprobacionS = res.fecha_comprobacion.ToString("dd/MM/yyyyy");

                            if (res.fecha_comprobacion_completo.Year > 1969)
                                res.fecha_comprobacion_completoS = res.fecha_comprobacion_completo.ToString("dd/MM/yyyyy");

                            if (res.fecha_vencimiento_workflow.Year > 1969)
                                res.fecha_vencimiento_workflowS = res.fecha_vencimiento_workflow.ToString("dd/MM/yyyyy");

                            if (res.fecha_vencimiento_workflow_completo.Year > 1969)
                                res.fecha_vencimiento_workflow_completoS = res.fecha_vencimiento_workflow_completo.ToString("dd/MM/yyyyy");

                            if (res.fecha_concesion_workflow.Year > 1969)
                                res.fecha_concesion_workflowS = res.fecha_concesion_workflow.ToString("dd/MM/yyyyy");

                            if (res.fecha_concesion_workflow_completo.Year > 1969)
                                res.fecha_concesion_workflow_completoS = res.fecha_concesion_workflow_completo.ToString("dd/MM/yyyyy");

                            res.permalink = Utility.hosturl + "PI/RegistroMarca?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.id.ToString())) + "&tipo="+tipo_registro;
                            list.Add(res);
                        }
                    }
                }
                else
                {
                    //
                }


            }
            catch (Exception ex)
            {
                list = new List<RegistroMarca>();
            }
            finally
            {
                //con.Close();
            }
            return list;
        }

        public static RespuestaFormato Crear(RegistroMarca modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_proc_RegistroMarca(modelo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        int id = 0;
                        Int32.TryParse(row[3].ToString(), out id);
                        if (id > 0)
                        {
                            res.flag = true;
                            res.data_int = id;
                        }
                    }
                }
                else
                {
                    res.description = "Ocurrió un error.";
                    res.errors.Add(errores);
                }


            }
            catch (Exception ex)
            {
                res.errors.Add(ex.Message);
                res.description = "Ocurrió un error.";
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static RespuestaFormato Actualizar(RegistroMarca modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_proc_RegistroMarca(modelo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        int id = 0;
                        Int32.TryParse(row[3].ToString(), out id);
                        if (id > 0)
                        {
                            res.flag = true;
                            res.data_int = id;
                        }
                    }
                }
                else
                {
                    res.description = "Ocurrió un error.";
                    res.errors.Add(errores);
                }


            }
            catch (Exception ex)
            {
                res.errors.Add(ex.Message);
                res.description = "Ocurrió un error.";
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static RespuestaFormato ActualizarActivo(RegistroMarca modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_proc_RegistroMarca_Activo(modelo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        int id = 0;
                        Int32.TryParse(row[3].ToString(), out id);
                        if (id > 0)
                        {
                            res.flag = true;
                            res.data_int = id;
                        }
                    }
                }
                else
                {
                    res.description = "Ocurrió un error.";
                    res.errors.Add(errores);
                }


            }
            catch (Exception ex)
            {
                res.errors.Add(ex.Message);
                res.description = "Ocurrió un error.";
            }
            finally
            {
                //con.Close();
            }
            return res;
        }


        public static RespuestaFormato ActualizarVoBo(RegistroMarca modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_proc_RegistroMarca_VoBo(modelo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        int id = 0;
                        Int32.TryParse(row[3].ToString(), out id);
                        if (id > 0)
                        {
                            res.flag = true;
                            res.data_int = id;
                        }
                    }
                }
                else
                {
                    res.description = "Ocurrió un error.";
                    res.errors.Add(errores);
                }


            }
            catch (Exception ex)
            {
                res.errors.Add(ex.Message);
                res.description = "Ocurrió un error.";
            }
            finally
            {
                //con.Close();
            }
            return res;
        }


        public static RespuestaFormato ActualizarDocumento(RegistroMarca modelo, int tipo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_proc_RegistroMarcaDocumento(modelo, tipo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        int id = 0;
                        Int32.TryParse(row[3].ToString(), out id);
                        if (id > 0)
                        {
                            res.flag = true;
                            res.data_int = id;
                        }
                    }
                }
                else
                {
                    res.description = "Ocurrió un error.";
                    res.errors.Add(errores);
                }


            }
            catch (Exception ex)
            {
                res.errors.Add(ex.Message);
                res.description = "Ocurrió un error.";
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<RegistroMarca> BusquedaAvanzadaRegistroMarca(int solicitud_tipo = 0, string id_usuario = "", int empresa = 0, int empresa_anterior = 0, int clase = 0, int pais = 0, int estatus = 0, int uso = 0,int tipo_registro_solicitud = 0, string nombre="", string no_registro = "", string no_solicitud = "",string fecha_legalS="", string fecha_vencimientoS = "", string fecha_concesionS = "",string fecha_quinquenio_anualidadS="",string fecha_requerimientoS="",string fecha_instruccionesS="",string fecha_registroS="",string fecha_busquedaS="",string fecha_resultadosS="",string fecha_comprobacionS="", int activo = -1)
        {
            List<RegistroMarca> list = new List<RegistroMarca>();
            Funciones funcion = new Funciones();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_proc_BusquedaAvanzadaRegistroMarca(out dt, out errores, solicitud_tipo, id_usuario, empresa,empresa_anterior,clase,pais,estatus,uso,tipo_registro_solicitud, nombre,no_registro,no_solicitud,fecha_legalS,fecha_vencimientoS,fecha_concesionS, fecha_quinquenio_anualidadS, fecha_requerimientoS, fecha_instruccionesS, fecha_registroS, fecha_busquedaS, fecha_resultadosS, fecha_comprobacionS, activo))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var res = new RegistroMarca();
                            res.id = Int32.Parse(row[idx].ToString()); idx++;
                            res.empresa = Int32.Parse(row[idx].ToString()); idx++;
                            res.empresa_desc = row[idx].ToString(); idx++;
                            res.empresa_anterior = Int32.Parse(row[idx].ToString()); idx++;
                            res.empresa_anterior_desc = row[idx].ToString(); idx++;
                            res.nombre = row[idx].ToString(); idx++;
                            res.no_registro = row[idx].ToString(); idx++;
                            res.titulo = row[idx].ToString(); idx++;
                            res.fecha_legal = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_vencimiento = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_concesion = DateTime.Parse(row[idx].ToString()); idx++;
                            res.clase = Int32.Parse(row[idx].ToString()); idx++;
                            res.clase_desc = row[idx].ToString(); idx++;
                            res.tipo_registro = Int32.Parse(row[idx].ToString()); idx++;
                            res.tipo_registro_desc = row[idx].ToString(); idx++;
                            res.pais = Int32.Parse(row[idx].ToString()); idx++;
                            res.pais_desc = row[idx].ToString(); idx++;
                            res.estatus = Int32.Parse(row[idx].ToString()); idx++;
                            res.estatus_desc = row[idx].ToString(); idx++;
                            res.solicitud_nombre = row[idx].ToString(); idx++;
                            if (res.solicitud_nombre != "")
                            {
                                res.solicitud_permalink = Utility.hosturl + "PI/RegistroMarcaDocumento?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.id.ToString())) + "&tp=" + HttpUtility.UrlEncode(funcion.Encriptar("solicitud"));
                            }
                            //if (res.solicitud_nombre != "" && row[idx] != null) { res.solicitud_data = (byte[])row[idx]; }
                            idx++;
                            res.solicitud_content_type = row[idx].ToString(); idx++;
                            res.solicitud_size = Int32.Parse(row[idx].ToString()); idx++;
                            res.solicitud_extension = row[idx].ToString(); idx++;
                            res.solicitud_nombre_original = row[idx].ToString(); idx++;
                            res.solicitud_url = row[idx].ToString(); idx++;
                            res.no_solicitud = row[idx].ToString(); idx++;
                            res.tipo_registro_solicitud = Int32.Parse(row[idx].ToString()); idx++;
                            res.tipo_registro_solicitud_desc = row[idx].ToString(); idx++;
                            res.autor_registro = row[idx].ToString(); idx++;
                            res.autor_registro_desc = row[idx].ToString(); idx++;
                            res.despacho = Int32.Parse(row[idx].ToString()); idx++;
                            res.despacho_desc = row[idx].ToString(); idx++;
                            res.corresponsal = Int32.Parse(row[idx].ToString()); idx++;
                            res.corresponsal_desc = row[idx].ToString(); idx++;
                            res.solicitante_licencia = row[idx].ToString(); idx++;
                            res.solicitante_licencia_desc = row[idx].ToString(); idx++;
                            res.licencia = Int32.Parse(row[idx].ToString()); idx++;
                            res.licencia_desc = row[idx].ToString(); idx++;
                            res.solicitante_cesion = row[idx].ToString(); idx++;
                            res.solicitante_cesion_desc = row[idx].ToString(); idx++;
                            res.cesion = Int32.Parse(row[idx].ToString()); idx++;
                            res.cesion_desc = row[idx].ToString(); idx++;
                            res.fecha_requerimiento = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_requerimiento_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_instrucciones = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_instrucciones_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_registro = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_registro_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_busqueda = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_busqueda_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_resultados = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_resultados_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_comprobacion = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_comprobacion_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_vencimiento_workflow = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_vencimiento_workflow_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_concesion_workflow = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_concesion_workflow_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            res.usuario = row[idx].ToString(); idx++;
                            res.usuario_desc = row[idx].ToString(); idx++;
                            res.activo = Int32.Parse(row[idx].ToString()); idx++;

                            res.titulo_nombre = row[idx].ToString(); idx++;
                            if (res.titulo_nombre != "")
                            {
                                res.titulo_permalink = Utility.hosturl + "PI/RegistroMarcaDocumento?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.id.ToString())) + "&tp=" + HttpUtility.UrlEncode(funcion.Encriptar("titulo"));
                            }
                            //if (res.titulo_nombre != "" && row[idx] != null) { res.titulo_data = (byte[])row[idx]; }
                            idx++;
                            res.titulo_content_type = row[idx].ToString(); idx++;
                            res.titulo_size = Int32.Parse(row[idx].ToString()); idx++;
                            res.titulo_extension = row[idx].ToString(); idx++;
                            res.titulo_nombre_original = row[idx].ToString(); idx++;
                            res.titulo_url = row[idx].ToString(); idx++;
                            res.solicitud = Int32.Parse(row[idx].ToString()); idx++;
                            res.solicitud_desc = row[idx].ToString(); idx++;
                            res.solicitud_tipo = Int32.Parse(row[idx].ToString()); idx++;
                            res.solicitud_tipo_desc = row[idx].ToString(); idx++;
                            res.fecha_declaracion = DateTime.Parse(row[idx].ToString()); idx++;
                            res.fecha_declaracion_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            //res.nueva_fecha_vencimiento = DateTime.Parse(row[idx].ToString()); idx++;

                            if (res.fecha_legal.Year > 1969)
                                res.fecha_legalS = res.fecha_legal.ToString("dd/MM/yyyy");
                            if (res.fecha_vencimiento.Year > 1969)
                                res.fecha_vencimientoS = res.fecha_vencimiento.ToString("dd/MM/yyyy");
                            if (res.fecha_concesion.Year > 1969)
                                res.fecha_concesionS = res.fecha_concesion.ToString("dd/MM/yyyy");

                            if (res.fecha_requerimiento.Year > 1969)
                                res.fecha_requerimientoS = res.fecha_requerimiento.ToString("dd/MM/yyyy");

                            if (res.fecha_requerimiento_completo.Year > 1969)
                                res.fecha_requerimiento_completoS = res.fecha_requerimiento_completo.ToString("dd/MM/yyyy");

                            if (res.fecha_instrucciones.Year > 1969)
                                res.fecha_instruccionesS = res.fecha_instrucciones.ToString("dd/MM/yyyy");

                            if (res.fecha_instrucciones_completo.Year > 1969)
                                res.fecha_instrucciones_completoS = res.fecha_instrucciones_completo.ToString("dd/MM/yyyy");

                            if (res.fecha_registro.Year > 1969)
                                res.fecha_registroS = res.fecha_registro.ToString("dd/MM/yyyy");

                            if (res.fecha_registro_completo.Year > 1969)
                                res.fecha_registro_completoS = res.fecha_registro_completo.ToString("dd/MM/yyyy");

                            if (res.fecha_busqueda.Year > 1969)
                                res.fecha_busquedaS = res.fecha_busqueda.ToString("dd/MM/yyyy");

                            if (res.fecha_busqueda_completo.Year > 1969)
                                res.fecha_busqueda_completoS = res.fecha_busqueda_completo.ToString("dd/MM/yyyy");

                            if (res.fecha_resultados.Year > 1969)
                                res.fecha_resultadosS = res.fecha_resultados.ToString("dd/MM/yyyy");

                            if (res.fecha_resultados_completo.Year > 1969)
                                res.fecha_resultados_completoS = res.fecha_resultados_completo.ToString("dd/MM/yyyy");

                            if (res.fecha_comprobacion.Year > 1969)
                                res.fecha_comprobacionS = res.fecha_comprobacion.ToString("dd/MM/yyyy");

                            if (res.fecha_comprobacion_completo.Year > 1969)
                                res.fecha_comprobacion_completoS = res.fecha_comprobacion_completo.ToString("dd/MM/yyyy");

                            if (res.fecha_vencimiento_workflow.Year > 1969)
                                res.fecha_vencimiento_workflowS = res.fecha_vencimiento_workflow.ToString("dd/MM/yyyy");

                            if (res.fecha_vencimiento_workflow_completo.Year > 1969)
                                res.fecha_vencimiento_workflow_completoS = res.fecha_vencimiento_workflow_completo.ToString("dd/MM/yyyy");

                            if (res.fecha_concesion_workflow.Year > 1969)
                                res.fecha_concesion_workflowS = res.fecha_concesion_workflow.ToString("dd/MM/yyyy");

                            if (res.fecha_concesion_workflow_completo.Year > 1969)
                                res.fecha_concesion_workflow_completoS = res.fecha_concesion_workflow_completo.ToString("dd/MM/yyyy");

                            if (res.fecha_declaracion.Year > 1969)
                                res.fecha_declaracionS = res.fecha_declaracion.ToString("dd/MM/yyyy");

                            if (res.fecha_declaracion_completo.Year > 1969)
                                res.fecha_declaracion_completoS = res.fecha_declaracion_completo.ToString("dd/MM/yyyy");

                            res.permalink = Utility.hosturl + "PI/RegistroMarca?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.id.ToString())) + "&tipo=" + tipo_registro_solicitud;
                            list.Add(res);
                        }
                        //var descarga = Utility.hosturl + "Admin/DescargarExcelRegistroMarca()";
                        //var ocl2 = RegistroMarca.Get(1, "bef7d03f-d37b-41a2-8ec6-eb204d313a78");
                        //return Request.CreateResponse(DataSourceLoader.Load(ocl2));
                        //return Utility.hosturl + "Admin/DescargarExcelRegistroMarca";
                        //var tu = new AdminController();
                        //var solic = tu.DescargarExcelRegistroMarca();
                    }
                }
                else
                {
                    //
                }


            }
            catch (Exception ex)
            {
                list = new List<RegistroMarca>();
            }
            finally
            {
                //con.Close();
            }
            return list;
        }
    }

}
