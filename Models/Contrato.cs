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
using System.Globalization;

namespace GISMVC.Models
{

    public class Indicadores
    {
        public int enproceso { get; set; }
        public int enproceso_et { get; set; }
        public int enproceso_v { get; set; }
        public int envalidacionA { get; set; }
        public int envalidacionA_et { get; set; }
        public int envalidacionA_v { get; set; }
        public int envalidacionU {get;set; }
        public int envalidacionU_et { get; set; }
        public int envalidacionU_v { get; set; }
        public int aprobados { get; set; }
        public int aprobados_et { get; set; }
        public int aprobados_v { get; set; }
        public int firmados { get; set; }
        public int firmados_et { get; set; }
        public int firmados_v { get; set; }
        public int  porvencer {get;set;}
	    public int  vigentes {get;set;}
	    public int  vencidos {get;set;}
	    public int  cancelados {get;set;}
	    public int  suspendidos {get;set; }
        public int envalidacionU2 { get; set; }
        public int envalidacionU2_et { get; set; }
        public int envalidacionU2_v { get; set; }
        public int enprocesoT { get; set; }
        public int enprocesoT_et { get; set; }
        public int enprocesoT_v { get; set; }

        public Indicadores()
        {
            enprocesoT = 0;
            enprocesoT_et = 0;
            enprocesoT_v = 0;

            enproceso = 0;
            enproceso_et = 0;
            enproceso_v = 0;
            envalidacionA  = 0;
            envalidacionA_et = 0;
            envalidacionA_v = 0;
            envalidacionU  = 0;
            envalidacionU_et = 0;
            envalidacionU_v = 0;
            aprobados = 0;
            aprobados_et = 0;
            aprobados_v = 0;
            firmados = 0;
            firmados_et = 0;
            firmados_v = 0;
            porvencer  = 0;
            vigentes  = 0;
            vencidos  = 0;
            cancelados  = 0;
            suspendidos = 0;
            envalidacionU2 = 0;
            envalidacionU2_et = 0;
            envalidacionU2_v = 0;
        }

        public static Indicadores Get(string id = "", string inicio = "", string fin = "")
        {
            Indicadores res = new Indicadores();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";

                if (inicio == "")
                {
                    inicio = DateTime.Now.AddDays(-60).ToString("yyyy-MM-dd");
                }
                if (fin == "")
                {
                    fin = DateTime.Now.ToString("yyyy-MM-dd");
                }
                inicio = inicio + " 00:00:00";
                fin = fin + " 23:59:59";

                if (da.CONS_Indicadores(id, inicio, fin, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];

                        res.enproceso = Int32.Parse(row[idx].ToString()); idx++;
                        res.enproceso_et = Int32.Parse(row[idx].ToString()); idx++;
                        res.enproceso_v = Int32.Parse(row[idx].ToString()); idx++;
                        res.envalidacionA = Int32.Parse(row[idx].ToString()); idx++;
                        res.envalidacionA_et = Int32.Parse(row[idx].ToString()); idx++;
                        res.envalidacionA_v = Int32.Parse(row[idx].ToString()); idx++;
                        res.envalidacionU = Int32.Parse(row[idx].ToString()); idx++;
                        res.envalidacionU_et = Int32.Parse(row[idx].ToString()); idx++;
                        res.envalidacionU_v = Int32.Parse(row[idx].ToString()); idx++;
                        res.aprobados = Int32.Parse(row[idx].ToString()); idx++;
                        res.aprobados_et = Int32.Parse(row[idx].ToString()); idx++;
                        res.aprobados_v = Int32.Parse(row[idx].ToString()); idx++;
                        res.firmados = Int32.Parse(row[idx].ToString()); idx++;
                        res.firmados_et = Int32.Parse(row[idx].ToString()); idx++;
                        res.firmados_v = Int32.Parse(row[idx].ToString()); idx++;
                        res.cancelados = Int32.Parse(row[idx].ToString()); idx++;
                        res.suspendidos = Int32.Parse(row[idx].ToString()); idx++;

                        res.envalidacionU2 = res.enproceso;// + res.envalidacionU;
                        res.envalidacionU2_et = res.enproceso_et;// + res.envalidacionU_et;
                        res.envalidacionU2_v = res.enproceso_v;// + res.envalidacionU_v;


                        res.enprocesoT = res.enproceso + res.envalidacionA;// + res.envalidacionU;
                        res.enprocesoT_et = res.enproceso_et + res.envalidacionA_et;// + res.envalidacionU2_et;
                        res.enprocesoT_v = res.enproceso_v + res.envalidacionA_v;// + res.envalidacionU_v;
                    }
                }
                else
                {
                    //
                }


            }
            catch (Exception ex)
            {
                res = new Indicadores();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }


    }
    public class BusquedaContrato
    {
        public int estatus { get; set; }
        public string abogado { get; set; }
        public string inicio { get; set; }
        public string fin { get; set; }
        public string buscar { get; set; }
        public int indefinido { get; set; }
        public int confidencial { get; set; }
        public decimal min_monto { get; set; }
        public decimal max_monto { get; set; }
        public string usuario { get; set; }
        public int indicadores { get; set; }

        public string dueno { get; set; }

        public int negocio { get; set; }
        public int tipocontrato { get; set; }
        public string folio { get; set; }
        public string rfc { get; set; }
        public string contraparte { get; set; }
        public string modificacion { get; set; }
        public int prioridad { get; set; }
        public int pagina { get; set; }
        public int cantidad { get; set; }

        public BusquedaContrato()
        {
            indicadores = 0;
            min_monto = 0;
            max_monto = 0;
            estatus = 0;
            abogado = "";
            inicio = "";
            fin = "";
            buscar = "";
            indefinido = 0;
            confidencial = 0;
            usuario = "";
            dueno = "";
            negocio = 0;
            tipocontrato = 0;
            folio = "";
            rfc = "";
            contraparte = "";
            modificacion = "";
            prioridad = 0;
            pagina = 1;
            cantidad = 5;
        }
    }
    public class Contrato
    {
        public string en_revision_por { get; set; }
        public string comentario { get; set; }
        public int revision { get; set; }
        public int id { get; set; }
        public string titulo { set; get; }
        public string descripcion { set; get; }
        public FechasFormato inicio_vigencia { set; get; }
        public FechasFormato termino_contrato { set; get; }
        public int termino_indefinido { get; set; }
        public string proveedor { set; get; }
        public string identificador_proveedor { set; get; }
        public string abogado { set; get; }
        public string abogado_nombre { set; get; }
        public string abogado_email { set; get; }
        public int tipo_contrato { set; get; }
        public string tipo_contrato_desc { set; get; }
        public int negocio { set; get; }
        public string negocio_desc { set; get; }
        public decimal monto { set; get; }
        public int moneda { set; get; }
        public string moneda_desc { set; get; }
        public List<string> errors { get; set; }
        public AspNetUsers usuario { set; get; }
        public string folio { set; get; }
        public string rfc { set; get; }
        public int estatus { set; get; }
        public string estatus_desc { set; get; }
        public int confidencial { set; get; }
        public string permalink { set; get; }
        public int notificado_vigencia { set; get; }
        public int notificado_vencido { set; get; }
        public int estatus_validacion { set; get; }
        public int cambio_abogado { set; get; }
        public int cambio_rfc { set; get; }
        public int doc { set; get; }
        public int doc_numero { set; get; }
        public string estatus_validacion_desc { set; get; }
        public string vigencia { set; get; }
        public int dias_transcurridos { set; get; }
        public int dias_contrato_firmado { set; get; }
        public int dias_restantes { set; get; }
        public int dias_exceso { set; get; }
        public int dias_vista { set; get; }
        public string retraso_actividad { set; get; }

        public Contrato()
        {
            dias_contrato_firmado = 0;
            dias_transcurridos = 0;
            dias_exceso = 0;
            dias_restantes = 0;

            cambio_rfc = 0;
            comentario = "";
            revision = 0;
            vigencia = "";
            notificado_vencido = 0;
            notificado_vigencia = 0;
            permalink = "";
            id = 0;
            titulo = "";
            descripcion = "";
            inicio_vigencia = new FechasFormato();
            termino_contrato = new FechasFormato();
            termino_indefinido = 0;
            proveedor = "";
            identificador_proveedor = "";
            abogado = "";
            tipo_contrato = 0;
            tipo_contrato_desc = "";
            negocio = 0;
            negocio_desc = "";
            monto = 0;
            moneda = 0;
            abogado_nombre = "";
            moneda_desc = "";
            usuario = new AspNetUsers();
            errors = new List<string>();
            rfc = "";
            folio = "";
            estatus = 0;
            estatus_desc = "";
            estatus_validacion = 0;
            estatus_validacion_desc = "";
            confidencial = 0;
            abogado_email = "";
            doc = 0;
            doc_numero = 0;
        }

        public static RespuestaFormato Crear(Contrato modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Ins_Contrato(modelo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        int id = Int32.Parse(row[3].ToString());
                        if (id > 0)
                        {
                            res.flag = true;
                            res.data_int = id;
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
                res.errors.Add(ex.Message);
                res.description = "Ocurrió un error.";
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static RespuestaFormato Actualizar(Contrato modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Upd_Contrato(modelo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        int id = Int32.Parse(row[3].ToString());
                        if (id > 0)
                        {
                            res.flag = true;
                            res.data_int = id;
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
                res.errors.Add(ex.Message);
                res.description = "Ocurrió un error.";
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
        
        public static List<Contrato> Get(string id = "")
        {
            List<Contrato> res = new List<Contrato>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_Contrato(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new Contrato();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.titulo = row[idx].ToString(); idx++;
                            item.descripcion = row[idx].ToString(); idx++;
                            item.inicio_vigencia = FechasFormato.GetFormatos(row[idx].ToString()); idx++;
                            item.termino_contrato = FechasFormato.GetFormatos(row[idx].ToString()); idx++;
                            item.termino_indefinido = Int32.Parse(row[idx].ToString()); idx++;
                            item.proveedor = row[idx].ToString(); idx++;
                            item.identificador_proveedor = row[idx].ToString(); idx++;
                            item.abogado = row[idx].ToString(); idx++;
                            item.tipo_contrato = Int32.Parse(row[idx].ToString()); idx++;
                            item.tipo_contrato_desc = row[idx].ToString(); idx++;
                            item.negocio = Int32.Parse(row[idx].ToString()); idx++;
                            item.negocio_desc = row[idx].ToString(); idx++;
                            item.monto = Int32.Parse(row[idx].ToString()); idx++;
                            item.moneda = Int32.Parse(row[idx].ToString()); idx++;
                            item.moneda_desc = row[idx].ToString(); idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            item.usuario.name = row[idx].ToString(); idx++;
                            item.folio = row[idx].ToString(); idx++;
                            item.rfc = row[idx].ToString(); idx++;
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
                res = new List<Contrato>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static Contrato GetById(int id = 0)
        {
            Contrato res = new Contrato();
            try
            {
                DataAccess da = new DataAccess();
                dll_Gis.Funciones fn = new dll_Gis.Funciones();
                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_ContratoById(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new Contrato();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.titulo = row[idx].ToString(); idx++;
                            item.descripcion = row[idx].ToString(); idx++;
                            item.inicio_vigencia = FechasFormato.GetFormatos(row[idx].ToString()); idx++;
                            item.termino_contrato = FechasFormato.GetFormatos(row[idx].ToString()); idx++;
                            item.termino_indefinido = Int32.Parse(row[idx].ToString()); idx++;
                            item.proveedor = row[idx].ToString(); idx++;
                            item.identificador_proveedor = row[idx].ToString(); idx++;
                            item.abogado = row[idx].ToString(); idx++;
                            item.abogado_nombre = row[idx].ToString(); idx++;
                            item.tipo_contrato = Int32.Parse(row[idx].ToString()); idx++;
                            item.tipo_contrato_desc = row[idx].ToString(); idx++;
                            item.negocio = Int32.Parse(row[idx].ToString()); idx++;
                            item.negocio_desc = row[idx].ToString(); idx++;
                            item.monto = Decimal.Parse(row[idx].ToString()); idx++;
                            item.moneda = Int32.Parse(row[idx].ToString()); idx++;
                            item.moneda_desc = row[idx].ToString(); idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            item.usuario.name = row[idx].ToString();
                            item.usuario.nombre = item.usuario.name;
                            idx++;
                            item.folio = row[idx].ToString(); idx++;
                            item.rfc = row[idx].ToString(); idx++;
                            item.confidencial = Int32.Parse(row[idx].ToString()); idx++;
                            item.estatus = Int32.Parse(row[idx].ToString()); idx++;
                            item.estatus_desc = row[idx].ToString(); idx++;
                            item.estatus_validacion = Int32.Parse(row[idx].ToString()); idx++;
                            item.estatus_validacion_desc = row[idx].ToString(); idx++;

                            item.usuario.email = row[idx].ToString(); idx++;
                            item.abogado_email = row[idx].ToString(); idx++;


                            item.revision = Int32.Parse(row[idx].ToString()); idx++;
                            item.doc = Int32.Parse(row[idx].ToString()); idx++;
                            item.doc_numero = Int32.Parse(row[idx].ToString()); idx++;

                            item.permalink = Utility.hosturl + "Admin/Contrato?id=" + HttpUtility.UrlEncode(fn.Encriptar(item.id.ToString()));
                            res = item;
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
                res = new Contrato();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }


        public static List<Contrato> GetBusqueda(BusquedaContrato modelo, out int total)
        {
            List<Contrato> res = new List<Contrato>();
            total = 0;
            try
            {
                dll_Gis.Funciones fn = new dll_Gis.Funciones();
                DataAccess da = new DataAccess();

                int timeout = 5;
                var res_timeout = RespuestaFormato.Get("TIMEOUT ACTIVIDAD");

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_ContratoBusqueda(modelo, out dt, out errores, out total))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new Contrato();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.titulo = row[idx].ToString(); idx++;
                            item.descripcion = row[idx].ToString(); idx++;
                            item.inicio_vigencia = FechasFormato.GetFormatos(row[idx].ToString()); idx++;
                            item.termino_contrato = FechasFormato.GetFormatos(row[idx].ToString()); idx++;
                            item.termino_indefinido = Int32.Parse(row[idx].ToString()); idx++;
                            item.proveedor = row[idx].ToString(); idx++;
                            item.identificador_proveedor = row[idx].ToString(); idx++;
                            item.abogado = row[idx].ToString(); idx++;
                            item.abogado_nombre = row[idx].ToString(); idx++;
                            item.tipo_contrato = Int32.Parse(row[idx].ToString()); idx++;
                            item.tipo_contrato_desc = row[idx].ToString(); idx++;
                            item.negocio = Int32.Parse(row[idx].ToString()); idx++;
                            item.negocio_desc = row[idx].ToString(); idx++;
                            item.monto = Decimal.Parse(row[idx].ToString()); idx++;
                            item.moneda = Int32.Parse(row[idx].ToString()); idx++;
                            item.moneda_desc = row[idx].ToString(); idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            item.usuario.name = row[idx].ToString(); idx++;
                            item.folio = row[idx].ToString(); idx++;
                            item.rfc = row[idx].ToString(); idx++;
                            item.estatus = Int32.Parse(row[idx].ToString()); idx++;
                            item.estatus_desc = row[idx].ToString(); idx++;
                            item.confidencial = Int32.Parse(row[idx].ToString()); idx++;

                            item.estatus_validacion = Int32.Parse(row[idx].ToString()); idx++;
                            item.estatus_validacion_desc = row[idx].ToString(); idx++;
                            item.vigencia = row[idx].ToString(); idx++;

                            //
                            idx++;

                            //
                            Int32.TryParse(res_timeout.data_string, out timeout);
                            //

                            item.dias_transcurridos = Int32.Parse(row[idx].ToString()); idx++;
                            item.en_revision_por = row[idx].ToString(); idx++;
                            item.dias_contrato_firmado = Int32.Parse(row[idx].ToString()); idx++;
                            if (item.estatus_validacion <= 3)
                            {
                                if (item.dias_transcurridos > timeout)
                                {
                                    item.dias_exceso = item.dias_transcurridos - timeout;
                                    item.dias_vista = item.dias_exceso;
                                    item.retraso_actividad = "Días vencido";
                                }
                                else
                                {
                                    item.dias_restantes = timeout - item.dias_transcurridos;
                                    item.dias_exceso = item.dias_transcurridos;
                                    if (item.dias_restantes < 0)
                                    {
                                        item.dias_restantes = 0;
                                    }
                                    item.dias_vista = item.dias_restantes;
                                    item.retraso_actividad = "Días restantes por atender";
                                }
                            }else if (item.estatus_validacion == 4)
                            {
                                if(item.dias_contrato_firmado == -1)
                                {
                                    //
                                } else if (item.dias_contrato_firmado > 30)
                                {
                                    item.dias_exceso = item.dias_contrato_firmado - 30;
                                    item.dias_vista = item.dias_exceso;
                                    item.retraso_actividad = "Días sin subir contrato firmado";
                                } else
                                {
                                    item.dias_restantes = 30 - item.dias_transcurridos;
                                    item.dias_exceso = item.dias_transcurridos;
                                    if (item.dias_restantes < 0)
                                    {
                                        item.dias_restantes = 0;
                                    }
                                    item.dias_vista = item.dias_restantes;
                                    item.retraso_actividad = "Días restantes por atender";
                                }
                            }
                            idx++;
                            //

                            item.permalink = Utility.hosturl + "Admin/Contrato?id=" + HttpUtility.UrlEncode(fn.Encriptar(item.id.ToString()));
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
                res = new List<Contrato>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<Contrato> GetBusquedaDashboard(BusquedaContrato modelo)
        {
            List<Contrato> res = new List<Contrato>();
            try
            {
                dll_Gis.Funciones fn = new dll_Gis.Funciones();
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_ContratoBusquedaDashboard(modelo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new Contrato();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.titulo = row[idx].ToString(); idx++;
                            item.descripcion = row[idx].ToString(); idx++;
                            item.inicio_vigencia = FechasFormato.GetFormatos(row[idx].ToString()); idx++;
                            item.termino_contrato = FechasFormato.GetFormatos(row[idx].ToString()); idx++;
                            item.termino_indefinido = Int32.Parse(row[idx].ToString()); idx++;
                            item.proveedor = row[idx].ToString(); idx++;
                            item.identificador_proveedor = row[idx].ToString(); idx++;
                            item.abogado = row[idx].ToString(); idx++;
                            item.abogado_nombre = row[idx].ToString(); idx++;
                            item.tipo_contrato = Int32.Parse(row[idx].ToString()); idx++;
                            item.tipo_contrato_desc = row[idx].ToString(); idx++;
                            item.negocio = Int32.Parse(row[idx].ToString()); idx++;
                            item.negocio_desc = row[idx].ToString(); idx++;
                            item.monto = Decimal.Parse(row[idx].ToString()); idx++;
                            item.moneda = Int32.Parse(row[idx].ToString()); idx++;
                            item.moneda_desc = row[idx].ToString(); idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            item.usuario.name = row[idx].ToString(); idx++;
                            item.folio = row[idx].ToString(); idx++;
                            item.rfc = row[idx].ToString(); idx++;
                            item.estatus = Int32.Parse(row[idx].ToString()); idx++;
                            item.estatus_desc = row[idx].ToString(); idx++;
                            item.confidencial = Int32.Parse(row[idx].ToString()); idx++;

                            item.estatus_validacion = Int32.Parse(row[idx].ToString()); idx++;
                            item.estatus_validacion_desc = row[idx].ToString(); idx++;
                            item.vigencia = row[idx].ToString(); idx++;

                            item.permalink = Utility.hosturl + "Admin/Contrato?id=" + HttpUtility.UrlEncode(fn.Encriptar(item.id.ToString()));
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
                res = new List<Contrato>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<string> GetFolios(string id)
        {
            List<string> res = new List<string>();
            try
            {
                dll_Gis.Funciones fn = new dll_Gis.Funciones();
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_UsuarioFolios(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            res.Add(row[idx].ToString());
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
                res = new List<string>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<string> GetRFCs(string id)
        {
            List<string> res = new List<string>();
            try
            {
                dll_Gis.Funciones fn = new dll_Gis.Funciones();
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_UsuarioRFCs(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            res.Add(row[idx].ToString());
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
                res = new List<string>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<string> GetContrapartes(string id)
        {
            List<string> res = new List<string>();
            try
            {
                dll_Gis.Funciones fn = new dll_Gis.Funciones();
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_UsuarioContrapartes(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            res.Add(row[idx].ToString());
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
                res = new List<string>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static RespuestaFormato ActualizarEstatusValidacion(int contrato = 0, int estatus = 1)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.ActualizarEstatusValidacion(contrato, estatus, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        int id = Int32.Parse(row[3].ToString());
                        if (id > 0)
                        {
                            res.flag = true;
                            res.data_int = id;
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
                res.errors.Add(ex.Message);
                res.description = "Ocurrió un error.";
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static RespuestaFormato DatosContrato(Contrato contrato)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                string vigencia = "<p style='font-size:13px;'><strong>Inicio de vigencia: </strong>" + contrato.inicio_vigencia.ddmmyyyy2 + "&nbsp;&nbsp;&nbsp;<strong>Término de vigencia: </strong>" + contrato.termino_contrato.ddmmyyyy2 + "</p>";
                if(contrato.termino_indefinido == 1)
                {
                    vigencia = "<p style='font-size:13px;'><strong>Inicio de vigencia: </strong>" + contrato.inicio_vigencia.ddmmyyyy2 + "</p>";
                }
                res.data_string = "<p style='font-size:13px;'><strong>Folio: </strong>" + contrato.folio + "&nbsp;&nbsp;&nbsp;<strong>Título: </strong>" + contrato.titulo + "</p>" +
                    "<p style='font-size:13px;'><strong>Descripción: </strong>" + contrato.descripcion + "</p>" +
                    "<p style='font-size:13px;'><strong>Tipo de contrato: </strong>" + contrato.tipo_contrato_desc + "</p>" +
                    "<p style='font-size:13px;'><strong>Monto: </strong>" + contrato.monto.ToString("C", CultureInfo.CurrentCulture).Replace("XDR", "$") + "&nbsp;&nbsp;&nbsp;<strong>Moneda: </strong>" + contrato.moneda_desc + "</p>" +
                    "<p style='font-size:13px;'><strong>Solicitante: </strong>" + contrato.usuario.nombre + "</p>" +
                    "<p style='font-size:13px;'><strong>Abogado: </strong>" + contrato.abogado_nombre + "</p>" +
                    "<p style='font-size:13px;'><strong>Negocio: </strong>" + contrato.negocio_desc + "</p>" +
                    "<p style='font-size:13px;'><strong>Contraparte: </strong>" + contrato.proveedor + "(" + contrato.rfc + ")</p>" +
                    vigencia;
                res.flag = true;
            }
            catch (Exception ex)
            {
                res.description = "";
            }
            finally
            {
                //con.Close();
            }
            return res;
        }


        public static RespuestaFormato ActualizarRevision(int contrato = 0)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_proc_ContratoRevision(contrato, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        int id = Int32.Parse(row[3].ToString());
                        if (id > 0)
                        {
                            res.flag = true;
                            res.data_int = id;
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
                res.errors.Add(ex.Message);
                res.description = "Ocurrió un error.";
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static RespuestaFormato ActualizarEstatus(int contrato = 0, int estatus = 1)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Upd_ContratoEstatusContrato(contrato, estatus, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        int id = Int32.Parse(row[3].ToString());
                        if (id > 0)
                        {
                            res.flag = true;
                            res.data_int = id;
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
                res.errors.Add(ex.Message);
                res.description = "Ocurrió un error.";
            }
            finally
            {
                //con.Close();
            }
            return res;
        }


        public static RespuestaFormato ActualizarComentario(int contrato = 0, string comentario = "")
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Upd_ContratoComentarioContrato(contrato, comentario, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        int id = Int32.Parse(row[3].ToString());
                        if (id > 0)
                        {
                            res.flag = true;
                            res.data_int = id;
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
