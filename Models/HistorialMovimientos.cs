using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using dll_Gis;
using System;
using System.Web;
using System.Net.NetworkInformation;
//using static ClosedXML.Excel.XLPredefinedFormat; con la libreria marca error el DateTime
using System.Web.UI;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Spreadsheet;
using DevExtreme.AspNet.Data;
using GISMVC.Controllers;


namespace GISMVC.Models
{
    public class HistorialMovimientos
    {
        public int id { get; set; } = 0;
        public int modulo { get; set; } = 0;
        public string modulo_desc { get; set; } = "";
        public int tipo { get; set; } = 0;
        public string tipo_desc { get; set; } = "";
        public string detalle { get; set; } = "";
        public string usuario { get; set; } = "";
        public string usuario_desc { get; set; } = "";
        public DateTime fc { get; set; }
        public int activo { get; set; } = 0;
        public string fcS { get; set; } = "";
        public string fcH { get; set; } = "";
        public string fechaS { get; set; } = "";
        public HistorialMovimientos()
        {
            id = 0;
            modulo = 0;
            modulo_desc = "";
            tipo = 0;
            tipo_desc = "";
            detalle = "";
            usuario = "";
            usuario_desc = "";
            fc = DateTime.Parse("1969-01-01");
            activo = 0;
            fcS = "";
            fcH = "";
            fechaS = "";
        }

        //public static List<RegistroMarca> BusquedaHistorialMovimientos(int solicitud_tipo = 0, string id_usuario = "", int empresa = 0, int empresa_anterior = 0, int clase = 0, int pais = 0, int estatus = 0, int uso = 0, int tipo_registro_solicitud = 0, string nombre = "", string no_registro = "", string no_solicitud = "", string fecha_legalS = "", string fecha_vencimientoS = "", string fecha_concesionS = "", string fecha_quinquenio_anualidadS = "", string fecha_requerimientoS = "", string fecha_instruccionesS = "", string fecha_registroS = "", string fecha_busquedaS = "", string fecha_resultadosS = "", string fecha_comprobacionS = "", int activo = -1)
        public static List<HistorialMovimientos> BusquedaHistorialMovimientos(int modulo = 0, int tipo = 0 , string usuario = "", string detalle = "", string fechaS = "", int activo = -1)
        {
            List<HistorialMovimientos> list = new List<HistorialMovimientos>();
            Funciones funcion = new Funciones();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                //if (da.Cons_proc_BusquedaAvanzadaRegistroMarca(out dt, out errores, solicitud_tipo, id_usuario, empresa, empresa_anterior, clase, pais, estatus, uso, tipo_registro_solicitud, nombre, no_registro, no_solicitud, fecha_legalS, fecha_vencimientoS, fecha_concesionS, fecha_quinquenio_anualidadS, fecha_requerimientoS, fecha_instruccionesS, fecha_registroS, fecha_busquedaS, fecha_resultadosS, fecha_comprobacionS, activo))
                if (da.Cons_proc_HistorialMovimientos(out dt, out errores, modulo, tipo, usuario,detalle,fechaS, activo))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var res = new HistorialMovimientos();
                            res.id = Int32.Parse(row[idx].ToString()); idx++;
                            res.tipo = Int32.Parse(row[idx].ToString()); idx++;
                            res.tipo_desc = row[idx].ToString(); idx++;
                            res.modulo = Int32.Parse(row[idx].ToString()); idx++;
                            res.modulo_desc = row[idx].ToString(); idx++;
                            res.detalle = row[idx].ToString(); idx++;
                            //res.no_registro = row[idx].ToString(); idx++;
                            //res.titulo = row[idx].ToString(); idx++;
                            //res.fecha_legal = DateTime.Parse(row[idx].ToString()); idx++;
                            //res.fecha_vencimiento = DateTime.Parse(row[idx].ToString()); idx++;
                            //res.fecha_concesion = DateTime.Parse(row[idx].ToString()); idx++;
                            //res.clase = Int32.Parse(row[idx].ToString()); idx++;
                            //res.clase_desc = row[idx].ToString(); idx++;
                            //res.tipo_registro = Int32.Parse(row[idx].ToString()); idx++;
                            //res.tipo_registro_desc = row[idx].ToString(); idx++;
                            //res.pais = Int32.Parse(row[idx].ToString()); idx++;
                            //res.pais_desc = row[idx].ToString(); idx++;
                            //res.estatus = Int32.Parse(row[idx].ToString()); idx++;
                            //res.estatus_desc = row[idx].ToString(); idx++;
                            //res.solicitud_nombre = row[idx].ToString(); idx++;
                            //if (res.solicitud_nombre != "")
                            //{
                            //    res.solicitud_permalink = Utility.hosturl + "PI/RegistroMarcaDocumento?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.id.ToString())) + "&tp=" + HttpUtility.UrlEncode(funcion.Encriptar("solicitud"));
                            //}
                            //idx++;
                            //res.solicitud_content_type = row[idx].ToString(); idx++;
                            //res.solicitud_size = Int32.Parse(row[idx].ToString()); idx++;
                            //res.solicitud_extension = row[idx].ToString(); idx++;
                            //res.solicitud_nombre_original = row[idx].ToString(); idx++;
                            //res.solicitud_url = row[idx].ToString(); idx++;
                            //res.no_solicitud = row[idx].ToString(); idx++;
                            //res.tipo_registro_solicitud = Int32.Parse(row[idx].ToString()); idx++;
                            //res.tipo_registro_solicitud_desc = row[idx].ToString(); idx++;
                            //res.autor_registro = row[idx].ToString(); idx++;
                            //res.autor_registro_desc = row[idx].ToString(); idx++;
                            //res.despacho = Int32.Parse(row[idx].ToString()); idx++;
                            //res.despacho_desc = row[idx].ToString(); idx++;
                            //res.corresponsal = Int32.Parse(row[idx].ToString()); idx++;
                            //res.corresponsal_desc = row[idx].ToString(); idx++;
                            //res.solicitante_licencia = row[idx].ToString(); idx++;
                            //res.solicitante_licencia_desc = row[idx].ToString(); idx++;
                            //res.licencia = Int32.Parse(row[idx].ToString()); idx++;
                            //res.licencia_desc = row[idx].ToString(); idx++;
                            //res.solicitante_cesion = row[idx].ToString(); idx++;
                            //res.solicitante_cesion_desc = row[idx].ToString(); idx++;
                            //res.cesion = Int32.Parse(row[idx].ToString()); idx++;
                            //res.cesion_desc = row[idx].ToString(); idx++;
                            //res.fecha_requerimiento = DateTime.Parse(row[idx].ToString()); idx++;
                            //res.fecha_requerimiento_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            //res.fecha_instrucciones = DateTime.Parse(row[idx].ToString()); idx++;
                            //res.fecha_instrucciones_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            //res.fecha_registro = DateTime.Parse(row[idx].ToString()); idx++;
                            //res.fecha_registro_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            //res.fecha_busqueda = DateTime.Parse(row[idx].ToString()); idx++;
                            //res.fecha_busqueda_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            //res.fecha_resultados = DateTime.Parse(row[idx].ToString()); idx++;
                            //res.fecha_resultados_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            //res.fecha_comprobacion = DateTime.Parse(row[idx].ToString()); idx++;
                            //res.fecha_comprobacion_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            //res.fecha_vencimiento_workflow = DateTime.Parse(row[idx].ToString()); idx++;
                            //res.fecha_vencimiento_workflow_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            //res.fecha_concesion_workflow = DateTime.Parse(row[idx].ToString()); idx++;
                            //res.fecha_concesion_workflow_completo = DateTime.Parse(row[idx].ToString()); idx++;
                            
                            //res.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            res.usuario = row[idx].ToString(); idx++;
                            res.usuario_desc = row[idx].ToString(); idx++;
                            res.fc = System.DateTime.Parse(row[idx].ToString()); idx++;
                            res.activo = Int32.Parse(row[idx].ToString()); idx++;

                            //res.titulo_nombre = row[idx].ToString(); idx++;
                            //if (res.titulo_nombre != "")
                            //{
                            //    res.titulo_permalink = Utility.hosturl + "PI/RegistroMarcaDocumento?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.id.ToString())) + "&tp=" + HttpUtility.UrlEncode(funcion.Encriptar("titulo"));
                            //}
                            //idx++;
                            //res.titulo_content_type = row[idx].ToString(); idx++;
                            //res.titulo_size = Int32.Parse(row[idx].ToString()); idx++;
                            //res.titulo_extension = row[idx].ToString(); idx++;
                            //res.titulo_nombre_original = row[idx].ToString(); idx++;
                            //res.titulo_url = row[idx].ToString(); idx++;
                            //res.solicitud = Int32.Parse(row[idx].ToString()); idx++;
                            //res.solicitud_desc = row[idx].ToString(); idx++;
                            //res.solicitud_tipo = Int32.Parse(row[idx].ToString()); idx++;
                            //res.solicitud_tipo_desc = row[idx].ToString(); idx++;
                            //res.fecha_declaracion = DateTime.Parse(row[idx].ToString()); idx++;
                            //res.fecha_declaracion_completo = DateTime.Parse(row[idx].ToString()); idx++;

                            if (res.fc.Year > 1969)
                                res.fcS = res.fc.ToString("dd/MM/yyyy");
                            if (res.fc.Year > 1969)
                                res.fcH = res.fc.ToString("H:mmm:ss");
                            //if (res.fecha_vencimiento.Year > 1969)
                            //    res.fecha_vencimientoS = res.fecha_vencimiento.ToString("dd/MM/yyyy");
                            //if (res.fecha_concesion.Year > 1969)
                            //    res.fecha_concesionS = res.fecha_concesion.ToString("dd/MM/yyyy");

                            //if (res.fecha_requerimiento.Year > 1969)
                            //    res.fecha_requerimientoS = res.fecha_requerimiento.ToString("dd/MM/yyyy");

                            //if (res.fecha_requerimiento_completo.Year > 1969)
                            //    res.fecha_requerimiento_completoS = res.fecha_requerimiento_completo.ToString("dd/MM/yyyy");

                            //if (res.fecha_instrucciones.Year > 1969)
                            //    res.fecha_instruccionesS = res.fecha_instrucciones.ToString("dd/MM/yyyy");

                            //if (res.fecha_instrucciones_completo.Year > 1969)
                            //    res.fecha_instrucciones_completoS = res.fecha_instrucciones_completo.ToString("dd/MM/yyyy");

                            //if (res.fecha_registro.Year > 1969)
                            //    res.fecha_registroS = res.fecha_registro.ToString("dd/MM/yyyy");

                            //if (res.fecha_registro_completo.Year > 1969)
                            //    res.fecha_registro_completoS = res.fecha_registro_completo.ToString("dd/MM/yyyy");

                            //if (res.fecha_busqueda.Year > 1969)
                            //    res.fecha_busquedaS = res.fecha_busqueda.ToString("dd/MM/yyyy");

                            //if (res.fecha_busqueda_completo.Year > 1969)
                            //    res.fecha_busqueda_completoS = res.fecha_busqueda_completo.ToString("dd/MM/yyyy");

                            //if (res.fecha_resultados.Year > 1969)
                            //    res.fecha_resultadosS = res.fecha_resultados.ToString("dd/MM/yyyy");

                            //if (res.fecha_resultados_completo.Year > 1969)
                            //    res.fecha_resultados_completoS = res.fecha_resultados_completo.ToString("dd/MM/yyyy");

                            //if (res.fecha_comprobacion.Year > 1969)
                            //    res.fecha_comprobacionS = res.fecha_comprobacion.ToString("dd/MM/yyyy");

                            //if (res.fecha_comprobacion_completo.Year > 1969)
                            //    res.fecha_comprobacion_completoS = res.fecha_comprobacion_completo.ToString("dd/MM/yyyy");

                            //if (res.fecha_vencimiento_workflow.Year > 1969)
                            //    res.fecha_vencimiento_workflowS = res.fecha_vencimiento_workflow.ToString("dd/MM/yyyy");

                            //if (res.fecha_vencimiento_workflow_completo.Year > 1969)
                            //    res.fecha_vencimiento_workflow_completoS = res.fecha_vencimiento_workflow_completo.ToString("dd/MM/yyyy");

                            //if (res.fecha_concesion_workflow.Year > 1969)
                            //    res.fecha_concesion_workflowS = res.fecha_concesion_workflow.ToString("dd/MM/yyyy");

                            //if (res.fecha_concesion_workflow_completo.Year > 1969)
                            //    res.fecha_concesion_workflow_completoS = res.fecha_concesion_workflow_completo.ToString("dd/MM/yyyy");

                            //if (res.fecha_declaracion.Year > 1969)
                            //    res.fecha_declaracionS = res.fecha_declaracion.ToString("dd/MM/yyyy");

                            //if (res.fecha_declaracion_completo.Year > 1969)
                            //    res.fecha_declaracion_completoS = res.fecha_declaracion_completo.ToString("dd/MM/yyyy");

                            //res.permalink = Utility.hosturl + "PI/RegistroMarca?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.id.ToString())) + "&tipo=" + tipo_registro_solicitud;
                            list.Add(res);
                        }

                    }
                }
                else
                {
                    //
                }
                //var res = new HistorialMovimientos();
                //res.tipo = 2;
                //list.Add(res);

            }
            catch (Exception ex)
            {
                list = new List<HistorialMovimientos>();
            }
            finally
            {
                //con.Close();
            }
            return list;
        }

    }
}