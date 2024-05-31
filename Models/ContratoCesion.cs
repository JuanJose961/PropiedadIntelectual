using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Web;
using dll_Gis;

namespace GISMVC.Models
{
    public class ContratoCesion
    {
        public int id { get; set; }
        public int cedente { get; set; }
        public string cedente_nombre { get; set; }
        public int cesionario { get; set; }
        public string cesionario_nombre { get; set; }
        public string solicitante { get; set; }
        public string solicitante_nombre { get; set; }
        public string nombre { get; set; }
        public string numero_registro { get; set; }
        public string numero_expediente { get; set; }
        public int clase { get; set; }
        public string clase_nombre { get; set; }
        public int pais { get; set; }
        public string pais_nombre { get; set; }
        public DateTime fecha_instrucciones { get; set; }
        public DateTime fecha_instrucciones_completado { get; set; }
        public DateTime fecha_envio_documentos { get; set; }
        public DateTime fecha_envio_documentos_completado { get; set; }
        public DateTime fecha_solicitud { get; set; }
        public DateTime fecha_concesion { get; set; }
        public DateTime fecha_legal { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public string observaciones { get; set; }
        public int despacho { get; set; }
        public string despacho_nombre { get; set; }
        public int corresponsal { get; set; }
        public string corresponsal_nombre { get; set; }
        public int tipo_cesion { get; set; }
        public string tipo_cesion_nombre { get; set; }
        public DateTime fc { get; set; }
        public DateTime fu { get; set; }
        public byte[] solicitud_data { get; set; }
        public string solicitud_filename { get; set; }
        public int solicitud_size { get; set; }
        public string solicitud_nombre { get; set; }
        public string solicitud_content_type { get; set; }
        public string solicitud_extension { get; set; }
        public DateTime solicitud_fecha { get; set; }
        public string solicitud_fechaS { get; set; }
        public byte[] oficio_data { get; set; }
        public string oficio_filename { get; set; }
        public int oficio_size { get; set; }
        public string oficio_nombre { get; set; }
        public string oficio_content_type { get; set; }
        public string oficio_extension { get; set; }
        public DateTime oficio_fecha { get; set; }
        public string oficio_fechaS { get; set; }
        public byte[] contrato_data { get; set; }
        public string contrato_filename { get; set; }
        public int contrato_size { get; set; }
        public string contrato_nombre { get; set; }
        public string contrato_content_type { get; set; }
        public string contrato_extension { get; set; }
        public DateTime contrato_fecha { get; set; }
        public string contrato_fechaS { get; set; }
        public int activo { get; set; }
        public int orden { get; set; }

        public string fecha_instruccionesS { get; set; }
        public string fecha_instrucciones_completadoS { get; set; }
        public string fecha_envio_documentosS { get; set; }
        public string fecha_envio_documentos_completadoS { get; set; }
        public string fecha_solicitudS { get; set; }
        public string fecha_concesionS { get; set; }
        public string fecha_legalS { get; set; }
        public string fecha_vencimientoS { get; set; }
        //
        public string solicitud_url { get; set; }
        public string contrato_url { get; set; }
        public string oficio_url { get; set; }
        public string solicitud_permalink { get; set; }
        public string contrato_permalink { get; set; }
        public string oficio_permalink { get; set; }
        public string solicitud_nombre_original { get; set; }
        public string contrato_nombre_original { get; set; }
        public string oficio_nombre_original { get; set; }
        public int cesion_usado { get; set; }
        public ContratoCesion()
        {
            solicitud_url = "";
            solicitud_permalink = "";
            solicitud_nombre_original = "";
            oficio_url = "";
            oficio_permalink = "";
            oficio_nombre_original = "";
            contrato_url = "";
            contrato_permalink = "";
            contrato_nombre_original = "";

            id = 0;
            cedente = 0;
            cedente_nombre = "";
            cesionario = 0;
            cesionario_nombre = "";
            solicitante = "";
            solicitante_nombre = "";
            nombre = "";
            numero_registro = "";
            numero_expediente = "";
            clase = 0;
            clase_nombre = "";
            pais = 0;
            pais_nombre = "";
            fecha_instrucciones = DateTime.Parse("1969-01-01");
            fecha_instrucciones_completado = DateTime.Parse("1969-01-01");
            fecha_envio_documentos = DateTime.Parse("1969-01-01");
            fecha_envio_documentos_completado = DateTime.Parse("1969-01-01");
            fecha_solicitud = DateTime.Parse("1969-01-01");
            fecha_concesion = DateTime.Parse("1969-01-01");
            fecha_legal = DateTime.Parse("1969-01-01");
            fecha_vencimiento = DateTime.Parse("1969-01-01");
            observaciones = "";
            despacho = 0;
            despacho_nombre = "";
            corresponsal = 0;
            corresponsal_nombre = "";
            tipo_cesion = 0;
            tipo_cesion_nombre = "";
            fc = DateTime.Parse("1969-01-01");
            fu = DateTime.Parse("1969-01-01");
            //solicitud_data = new byte { 0 };
            solicitud_filename = "";
            solicitud_size = 0;
            solicitud_nombre = "";
            solicitud_content_type = "";
            solicitud_extension = "";
            solicitud_fecha = DateTime.Parse("1969-01-01");
            //oficio_data = new byte { 0 };
            oficio_filename = "";
            oficio_size = 0;
            oficio_nombre = "";
            oficio_content_type = "";
            oficio_extension = "";
            oficio_fecha = DateTime.Parse("1969-01-01");
            //contrato_data = new byte { 0 };
            contrato_filename = "";
            contrato_size = 0;
            contrato_nombre = "";
            contrato_content_type = "";
            contrato_extension = "";
            contrato_fecha = DateTime.Parse("1969-01-01");
            activo = 0;
            orden = 0;

            fecha_instruccionesS = "";
            fecha_instrucciones_completadoS = "";
            fecha_envio_documentosS = "";
            fecha_envio_documentos_completadoS = "";
            fecha_solicitudS = "";
            fecha_concesionS = "";
            fecha_legalS = "";
            fecha_vencimientoS = "";

            solicitud_fechaS = "";
            oficio_fechaS = "";
            contrato_fechaS = "";
            cesion_usado = 0;
        }

        
        public static ContratoCesion GetById(int id)
        {
            ContratoCesion res = new ContratoCesion();
            Funciones funcion = new Funciones();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_ContratoCesionById(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];

                        res.id = Int32.Parse(row[idx].ToString()); idx++;
                        res.cedente = Int32.Parse(row[idx].ToString()); idx++;
                        res.cedente_nombre = row[idx].ToString(); idx++;
                        res.cesionario = Int32.Parse(row[idx].ToString()); idx++;
                        res.cesionario_nombre = row[idx].ToString(); idx++;
                        res.solicitante = row[idx].ToString(); idx++;
                        res.solicitante_nombre = row[idx].ToString(); idx++;
                        res.nombre = row[idx].ToString(); idx++;
                        //res.numero_registro = row[idx].ToString(); idx++;
                        res.numero_expediente = row[idx].ToString(); idx++;
                        res.clase = Int32.Parse(row[idx].ToString()); idx++;
                        res.clase_nombre = row[idx].ToString(); idx++;
                        res.pais = Int32.Parse(row[idx].ToString()); idx++;
                        res.pais_nombre = row[idx].ToString(); idx++;
                        res.fecha_instrucciones = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_instrucciones_completado = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_envio_documentos = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_envio_documentos_completado = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_solicitud = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_concesion = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_legal = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fecha_vencimiento = DateTime.Parse(row[idx].ToString()); idx++;
                        res.observaciones = row[idx].ToString(); idx++;
                        res.despacho = Int32.Parse(row[idx].ToString()); idx++;
                        res.despacho_nombre = row[idx].ToString(); idx++;
                        res.corresponsal = Int32.Parse(row[idx].ToString()); idx++;
                        res.corresponsal_nombre = row[idx].ToString(); idx++;
                        res.tipo_cesion = Int32.Parse(row[idx].ToString()); idx++;
                        res.tipo_cesion_nombre = row[idx].ToString(); idx++;
                        res.fc = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fu = DateTime.Parse(row[idx].ToString()); idx++;
                        res.solicitud_filename = row[idx].ToString(); idx++;
                        res.solicitud_size = Int32.Parse(row[idx].ToString()); idx++;

                        idx++;
                        res.solicitud_nombre = row[idx].ToString(); idx++;
                        res.solicitud_content_type = row[idx].ToString(); idx++;
                        res.solicitud_extension = row[idx].ToString(); idx++;
                        res.solicitud_fecha = DateTime.Parse(row[idx].ToString()); idx++;
                        res.oficio_filename = row[idx].ToString(); idx++;
                        res.oficio_size = Int32.Parse(row[idx].ToString()); idx++;

                        idx++;
                        res.oficio_nombre = row[idx].ToString(); idx++;
                        res.oficio_content_type = row[idx].ToString(); idx++;
                        res.oficio_extension = row[idx].ToString(); idx++;
                        res.oficio_fecha = DateTime.Parse(row[idx].ToString()); idx++;
                        res.contrato_filename = row[idx].ToString(); idx++;
                        res.contrato_size = Int32.Parse(row[idx].ToString()); idx++;

                        idx++;
                        res.contrato_nombre = row[idx].ToString(); idx++;
                        res.contrato_content_type = row[idx].ToString(); idx++;
                        res.contrato_extension = row[idx].ToString(); idx++;
                        res.contrato_fecha = DateTime.Parse(row[idx].ToString()); idx++;
                        res.activo = Int32.Parse(row[idx].ToString()); idx++;
                        res.orden = Int32.Parse(row[idx].ToString()); idx++;

                        res.solicitud_url = row[idx].ToString(); idx++;
                        res.solicitud_nombre_original = row[idx].ToString(); idx++;

                        res.contrato_url = row[idx].ToString(); idx++;
                        res.contrato_nombre_original = row[idx].ToString(); idx++;

                        res.oficio_url = row[idx].ToString(); idx++;
                        res.oficio_nombre_original = row[idx].ToString(); idx++;

                        if (res.solicitud_nombre != "")
                        {
                            res.solicitud_permalink = Utility.hosturl + "PI/ContratoCesionDocumento?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.id.ToString())) + "&tp=" + HttpUtility.UrlEncode(funcion.Encriptar("solicitud"));
                        }
                        if (res.contrato_nombre != "")
                        {
                            res.contrato_permalink = Utility.hosturl + "PI/ContratoCesionDocumento?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.id.ToString())) + "&tp=" + HttpUtility.UrlEncode(funcion.Encriptar("contrato"));
                        }
                        if (res.oficio_nombre != "")
                        {
                            res.oficio_permalink = Utility.hosturl + "PI/ContratoCesionDocumento?id=" + HttpUtility.UrlEncode(funcion.Encriptar(res.id.ToString())) + "&tp=" + HttpUtility.UrlEncode(funcion.Encriptar("oficio"));
                        }

                        if (res.fecha_instrucciones.Year != 1969)
                        {
                            res.fecha_instruccionesS = res.fecha_instrucciones.ToString("dd/MM/yyyy");
                        }
                        if (res.fecha_instrucciones_completado.Year != 1969)
                        {
                            res.fecha_instrucciones_completadoS = res.fecha_instrucciones_completado.ToString("dd/MM/yyyy");
                        }
                        if (res.fecha_envio_documentos.Year != 1969)
                        {
                            res.fecha_envio_documentosS = res.fecha_envio_documentos.ToString("dd/MM/yyyy");
                        }
                        if (res.fecha_envio_documentos_completado.Year != 1969)
                        {
                            res.fecha_envio_documentos_completadoS = res.fecha_envio_documentos_completado.ToString("dd/MM/yyyy");
                        }
                        if (res.fecha_solicitud.Year != 1969)
                        {
                            res.fecha_solicitudS = res.fecha_solicitud.ToString("dd/MM/yyyy");
                        }
                        if (res.fecha_concesion.Year != 1969)
                        {
                            res.fecha_concesionS = res.fecha_concesion.ToString("dd/MM/yyyy");
                        }
                        if (res.fecha_legal.Year != 1969)
                        {
                            res.fecha_legalS = res.fecha_legal.ToString("dd/MM/yyyy");
                        }
                        if (res.fecha_vencimiento.Year != 1969)
                        {
                            res.fecha_vencimientoS = res.fecha_vencimiento.ToString("dd/MM/yyyy");
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
                res = new ContratoCesion();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
        public static List<ContratoCesion> Get(int activo = -1)
        {
            List<ContratoCesion> res = new List<ContratoCesion>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_ContratoCesion(out dt, out errores, activo))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new ContratoCesion();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.cedente = Int32.Parse(row[idx].ToString()); idx++;
                            item.cedente_nombre = row[idx].ToString(); idx++;
                            item.cesionario = Int32.Parse(row[idx].ToString()); idx++;
                            item.cesionario_nombre = row[idx].ToString(); idx++;
                            //item.solicitante = row[idx].ToString(); idx++;
                            //item.solicitante_nombre = row[idx].ToString(); idx++;
                            item.nombre = row[idx].ToString(); idx++;
                            //item.numero_registro = row[idx].ToString(); idx++;
                            item.numero_expediente = row[idx].ToString(); idx++;
                            item.clase = Int32.Parse(row[idx].ToString()); idx++;
                            item.clase_nombre = row[idx].ToString(); idx++;
                            item.pais = Int32.Parse(row[idx].ToString()); idx++;
                            item.pais_nombre = row[idx].ToString(); idx++;
                            item.fecha_instrucciones = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fecha_instrucciones_completado = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fecha_envio_documentos = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fecha_envio_documentos_completado = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fecha_solicitud = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fecha_concesion = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fecha_legal = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fecha_vencimiento = DateTime.Parse(row[idx].ToString()); idx++;
                            item.observaciones = row[idx].ToString(); idx++;
                            item.despacho = Int32.Parse(row[idx].ToString()); idx++;
                            item.despacho_nombre = row[idx].ToString(); idx++;
                            item.corresponsal = Int32.Parse(row[idx].ToString()); idx++;
                            item.corresponsal_nombre = row[idx].ToString(); idx++;
                            //item.tipo_cesion = Int32.Parse(row[idx].ToString()); idx++;
                            //item.tipo_cesion_nombre = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.solicitud_filename = row[idx].ToString(); idx++;
                            item.solicitud_size = Int32.Parse(row[idx].ToString()); idx++;
                            
                            idx++;
                            item.solicitud_nombre = row[idx].ToString(); idx++;
                            item.solicitud_content_type = row[idx].ToString(); idx++;
                            item.solicitud_extension = row[idx].ToString(); idx++;
                            item.solicitud_fecha = DateTime.Parse(row[idx].ToString()); idx++;
                            item.oficio_filename = row[idx].ToString(); idx++;
                            item.oficio_size = Int32.Parse(row[idx].ToString()); idx++;
                            
                            idx++;
                            item.oficio_nombre = row[idx].ToString(); idx++;
                            item.oficio_content_type = row[idx].ToString(); idx++;
                            item.oficio_extension = row[idx].ToString(); idx++;
                            item.oficio_fecha = DateTime.Parse(row[idx].ToString()); idx++;
                            item.contrato_filename = row[idx].ToString(); idx++;
                            item.contrato_size = Int32.Parse(row[idx].ToString()); idx++;
                            
                            idx++;
                            item.contrato_nombre = row[idx].ToString(); idx++;
                            item.contrato_content_type = row[idx].ToString(); idx++;
                            item.contrato_extension = row[idx].ToString(); idx++;
                            item.contrato_fecha = DateTime.Parse(row[idx].ToString()); idx++;


                            item.activo = Int32.Parse(row[idx].ToString()); idx++;
                            item.orden = Int32.Parse(row[idx].ToString()); idx++;
                            item.cesion_usado = Int32.Parse(row[idx].ToString()); idx++;
                            res.Add(item);
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
                res = new List<ContratoCesion>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }


        public static RespuestaFormato Crear(ContratoCesion modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_ContratoCesion(modelo, out dt, out errores))
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

        public static RespuestaFormato Actualizar(ContratoCesion modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_ContratoCesion(modelo, out dt, out errores))
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

        public static RespuestaFormato ActualizarActivo(ContratoCesion modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_ContratoCesion_Activo(modelo, out dt, out errores))
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


        public static RespuestaFormato ActualizarDocumento(ContratoCesion modelo, int tipo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_proc_ContratoCesionDocumento(modelo, tipo, out dt, out errores))
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
    }
}
