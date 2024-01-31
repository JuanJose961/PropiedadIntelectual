using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GISMVC.Models
{
    public class DocumentoContrato
    {
        public string permalink { get; set; }
        public int id { get; set; }
        public AspNetUsers usuario { get; set; }
        public DateTime fc { get; set; }
        public DateTime fu { get; set; }
        public int contrato { get; set; }
        public string file_nombre { get; set; }
        public byte[] file_data { get; set; }
        public string file_content_type { get; set; }
        public int file_size { get; set; }
        public int activo { get; set; }
        public string tipo { get; set; }
        //
        public string USUARIO_n { get; set; }
        public string FC_d { get; set; }
        public string FU_d { get; set; }
        public int cargado { get; set; }
        public int versionamiento { get; set; }
        public int idx { get; set; }
        public TipoArchivo tipo_archivo { get; set; }
        public string comentario { get; set; }
        public string file_extension { get; set; }
        public string nombre { get; set; }
        public string nombre_original { get; set; }
        public string file_data_str { get; set; }
        public string file_ext { get; set; }
        public string descripcion { get; set; }
        public string url { get; set; }
        public int es_precarga { get; set; }

        public DocumentoContrato()
        {
            es_precarga = 0;
            permalink = "";
            url = "";
            descripcion = "";
            file_data_str = "";
            file_ext = "";
            idx = 0;
            id = 0;
            usuario = new AspNetUsers();
            fc = DateTime.Parse("01-01-1969");
            fu = DateTime.Parse("01-01-1969");
            contrato = 0;
            file_nombre = "";
            //file_data = null;
            file_content_type = "";
            file_size = 0;
            FC_d = "";
            FU_d = "";
            USUARIO_n = "";
            cargado = 0;
            versionamiento = 0;
            tipo_archivo = new TipoArchivo();
            comentario = "";
            file_extension = "";
            nombre = "";
            nombre_original = "";
            activo = 0;
        }

        public static RespuestaFormato ActualizarTipo(DocumentoContrato modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_DocumentoContratoTipo(modelo, out dt, out errores))
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
        public RespuestaFormato Crear()
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_DocumentoContrato(this, out dt, out errores))
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

        public static RespuestaFormato CrearCliente(DocumentoContrato modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_DocumentoContratoCliente(modelo, out dt, out errores))
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

        public static RespuestaFormato Eliminar(DocumentoContrato modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.DEL_DocumentoContrato(modelo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        int id = 0;
                        int siguiente = 0;
                        Int32.TryParse(row[3].ToString(), out id);
                        Int32.TryParse(row[4].ToString(), out siguiente);
                        if (id > 0)
                        {
                            res.flag = true;
                            res.data_int = siguiente;
                        }
                    }
                }
                else
                {
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

        public static RespuestaFormato EliminarTodos(int contrato, int tipo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.DEL_DocumentosContrato(contrato, tipo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        int id = 0;
                        int siguiente = 0;
                        Int32.TryParse(row[3].ToString(), out id);
                        Int32.TryParse(row[4].ToString(), out siguiente);
                        if (id > 0)
                        {
                            res.flag = true;
                            res.data_int = siguiente;
                        }
                    }
                }
                else
                {
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

        public static DocumentoContrato GetById(int id)
        {
            DocumentoContrato res = new DocumentoContrato();
            try
            {
                dll_Gis.Funciones funcion = new dll_Gis.Funciones();
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_DocumentoContratoById(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];
                        var item = new DocumentoContrato();
                        item.id = Int32.Parse(row[idx].ToString()); idx++;
                        item.usuario.id = row[idx].ToString(); idx++;
                        item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                        item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                        item.contrato = Int32.Parse(row[idx].ToString()); idx++;
                        item.file_nombre = row[idx].ToString(); idx++;
                        if (row[idx] != null)
                        {
                            //item.file_data = (byte[])row[idx];
                        }
                        idx++;
                        //file_data = null;
                        item.file_content_type = row[idx].ToString(); idx++;
                        item.file_size = Int32.Parse(row[idx].ToString()); idx++;
                        item.tipo = row[idx].ToString(); idx++;
                        item.usuario.nombre = row[idx].ToString(); idx++;
                        item.comentario = row[idx].ToString(); idx++;

                        item.file_extension = row[idx].ToString(); idx++;
                        item.nombre = row[idx].ToString(); idx++;

                        item.tipo_archivo.id = Int32.Parse(row[idx].ToString()); idx++;
                        item.versionamiento = Int32.Parse(row[idx].ToString()); idx++;
                        item.tipo_archivo.nombre = row[idx].ToString(); idx++;
                        item.url = row[idx].ToString(); idx++;

                        item.nombre_original = item.file_nombre;
                        item.nombre_original = row[idx].ToString(); idx++;
                        if (item.tipo_archivo.id == 3 || item.tipo_archivo.nombre == "Anexo" ||
                            item.tipo_archivo.id == 6 || item.tipo_archivo.nombre == "Documento Cliente" ||
                            item.tipo_archivo.id == 7 || item.tipo_archivo.nombre == "Documento Cliente Manual")
                        {
                            if(item.tipo_archivo.id == 3 || item.tipo_archivo.nombre == "Anexo")
                            {
                                item.file_nombre = item.nombre_original;
                            }
                        }
                        else
                        {
                            if (item.file_extension != "" && item.nombre != "")
                            {
                                item.file_nombre = item.nombre + item.file_extension;
                            }
                        }

                        item.permalink = Utility.hosturl +
                            "Admin/Descargar?id=" +
                            HttpUtility.UrlEncode(funcion.Encriptar(item.id.ToString()));
                        res = item;
                    }
                }
                else
                {
                    //
                }


            }
            catch (Exception ex)
            {
                res = new DocumentoContrato();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<DocumentoContrato> GetFromId(int id = 0, string tipo = "")
        {
            List<DocumentoContrato> res = new List<DocumentoContrato>();
            try
            {
                dll_Gis.Funciones funcion = new dll_Gis.Funciones();
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_DocumentoContratoFromId(id, tipo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new DocumentoContrato();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.contrato = Int32.Parse(row[idx].ToString()); idx++;
                            item.file_nombre = row[idx].ToString(); idx++;
                            /*if (row[idx] != null)
                            {
                                item.file_data = (byte[])row[idx];
                            }*/
                            idx++;
                            //file_data = null;
                            item.file_content_type = row[idx].ToString(); idx++;
                            item.file_size = Int32.Parse(row[idx].ToString()); idx++;
                            item.tipo = row[idx].ToString(); idx++;
                            item.usuario.nombre = row[idx].ToString(); idx++;
                            item.comentario = row[idx].ToString(); idx++;
                            item.file_extension = row[idx].ToString(); idx++;
                            item.nombre = row[idx].ToString(); idx++;

                            item.tipo_archivo.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.versionamiento = Int32.Parse(row[idx].ToString()); idx++;
                            item.tipo_archivo.nombre = row[idx].ToString(); idx++;
                            item.nombre_original = item.file_nombre;

                            item.url = row[idx].ToString(); idx++;
                            item.nombre_original = row[idx].ToString(); idx++;
                            item.activo = Int32.Parse(row[idx].ToString()); idx++;

                            if (item.tipo_archivo.id == 3 || item.tipo_archivo.nombre == "Anexo" ||
                                item.tipo_archivo.id == 6 || item.tipo_archivo.nombre == "Documento Cliente" ||
                                item.tipo_archivo.id == 7 || item.tipo_archivo.nombre == "Documento Cliente Manual")
                            {
                                //
                                if (item.tipo_archivo.id == 3 || item.tipo_archivo.nombre == "Anexo")
                                {
                                    item.file_nombre = item.nombre_original;
                                }
                            }
                            else
                            {
                                if (item.file_extension != "" && item.nombre != "")
                                {
                                    item.file_nombre = item.nombre + item.file_extension;
                                }
                            }
                            item.cargado = 1;
                            item.permalink = Utility.hosturl +
                                "Admin/Descargar?id=" +
                                HttpUtility.UrlEncode(funcion.Encriptar(item.id.ToString()));
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
                res = new List<DocumentoContrato>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }


        public static List<DocumentoContrato> GetFromIdVersionamiento(int id = 0, int tipo = 0)
        {
            List<DocumentoContrato> res = new List<DocumentoContrato>();
            try
            {
                dll_Gis.Funciones funcion = new dll_Gis.Funciones();
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_DocumentoContratoFromIdVersionamiento(id, tipo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new DocumentoContrato();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.contrato = Int32.Parse(row[idx].ToString()); idx++;
                            item.file_nombre = row[idx].ToString(); idx++;
                            if (row[idx] != null)
                            {
                                item.file_data = (byte[])row[idx];
                            }
                            idx++;
                            //file_data = null;
                            item.file_content_type = row[idx].ToString(); idx++;
                            item.file_size = Int32.Parse(row[idx].ToString()); idx++;
                            item.tipo = row[idx].ToString(); idx++;
                            item.usuario.nombre = row[idx].ToString(); idx++;
                            item.comentario = row[idx].ToString(); idx++;
                            item.file_extension = row[idx].ToString(); idx++;
                            item.nombre = row[idx].ToString(); idx++;

                            item.tipo_archivo.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.versionamiento = Int32.Parse(row[idx].ToString()); idx++;
                            item.tipo_archivo.nombre = row[idx].ToString(); idx++;
                            item.activo = Int32.Parse(row[idx].ToString()); idx++;
                            item.nombre_original = row[idx].ToString(); idx++;
                            if (item.tipo_archivo.id == 3 || item.tipo_archivo.nombre == "Anexo" ||
                                item.tipo_archivo.id == 6 || item.tipo_archivo.nombre == "Documento Cliente" ||
                                item.tipo_archivo.id == 7 || item.tipo_archivo.nombre == "Documento Cliente Manual")
                            {
                                //
                            }
                            else
                            {
                                if (item.file_extension != "" && item.nombre != "")
                                {
                                    item.file_nombre = item.nombre + item.file_extension;
                                }
                            }
                            if(item.activo == 0)
                            {
                                item.versionamiento = -1;
                            }
                            item.permalink = Utility.hosturl +
                                "Admin/Descargar?id=" +
                                HttpUtility.UrlEncode(funcion.Encriptar(item.id.ToString()));
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
                res = new List<DocumentoContrato>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<DocumentoContrato> GetFromIdDesgloseTipoArchivo(List<DocumentoContrato> lista)
        {
            List<DocumentoContrato> res = new List<DocumentoContrato>();
            try
            {
                var tipos = TipoArchivo.Get();
                if (lista.Count > 0)
                {
                    foreach (var item_tipo in tipos) //por cada tipo de archivo
                    {
                        if (item_tipo.nombre == "Anexo" || item_tipo.id == 3)
                        {
                            var it = new DocumentoContrato();
                            it.tipo_archivo = item_tipo;
                            res.Add(it);
                            var items = lista.Where(i => i.tipo_archivo.id == item_tipo.id).ToList();
                            foreach(var item in items)
                            {
                                res.Add(item);
                            }
                        }
                        else if (item_tipo.nombre == "Documento Cliente" || item_tipo.id == 6)
                        {
                            //
                        }
                        else if (item_tipo.nombre == "Documento Cliente Manual" || item_tipo.id == 7)
                        {
                            //
                        }
                        else
                        {
                            var items = lista.Where(i => i.tipo_archivo.id == item_tipo.id).ToList();
                            if (items.Count > 0) //si hay archivos
                            {
                                if (items.Count > 1) //si hay mas de uno
                                {
                                    var versionamiento = items.Where(i => i.versionamiento == 1).FirstOrDefault();
                                    if (versionamiento != null)
                                    {
                                        if (versionamiento.id > 0) //buscar si hay uno principal
                                        {
                                            res.Add(versionamiento);
                                        }
                                        else
                                        {
                                            //si no poner el primero
                                            res.Add(items[0]);
                                        }
                                    }
                                    else
                                    {
                                        //si no poner el primero
                                        res.Add(items[0]);
                                    }
                                }
                                else
                                {
                                    //si solo hay uno
                                    res.Add(items[0]);
                                }
                            }
                            else
                            {
                                //si no hay archivos crear un dummy
                                var it = new DocumentoContrato();
                                it.tipo_archivo = item_tipo;
                                res.Add(it);
                            }
                        }
                    }
                }
                else
                {
                    foreach(var item_tipo in tipos)
                    {


                        if (item_tipo.nombre == "Documento Cliente" || item_tipo.id == 6 &&
                                item_tipo.nombre == "Documento Cliente Manual" || item_tipo.id == 7)
                        {
                            //
                        }
                        else
                        {
                            var it = new DocumentoContrato();
                            it.tipo_archivo = item_tipo;

                            res.Add(it);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                res = new List<DocumentoContrato>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }




        public static RespuestaFormato Carga(DocumentoContrato modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Upd_DocumentoContratoCarga(modelo, out dt, out errores))
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
        /*



        public static List<proc_contratoNacimiento> Get()
        {
            List<proc_contratoNacimiento> res = new List<proc_contratoNacimiento>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_proc_contratoNacimiento(out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new proc_contratoNacimiento();

                            item.ID = Int32.Parse(row[idx].ToString()); idx++;
                            item.DESCRIPCION = row[idx].ToString(); idx++;
                            item.TITULO = row[idx].ToString(); idx++;
                            item.FC = DateTime.Parse(row[idx].ToString()); idx++;
                            item.FU = DateTime.Parse(row[idx].ToString()); idx++;
                            item.LINEA = Int32.Parse(row[idx].ToString()); idx++;
                            item.UPDATED_BY = row[idx].ToString(); idx++;
                            item.PORTAFOLIO = Int32.Parse(row[idx].ToString()); idx++;
                            item.FOLIO = row[idx].ToString(); idx++;
                            item.MARCA = row[idx].ToString(); idx++;
                            item.DESCRIPCION_SAT = Int32.Parse(row[idx].ToString()); idx++;
                            item.DEFINICION = row[idx].ToString(); idx++;
                            item.NUEVO_PRODUCTO = Int32.Parse(row[idx].ToString()); idx++;
                            item.SUBLINEA = Int32.Parse(row[idx].ToString()); idx++;
                            item.LINEA_ANFAD = Int32.Parse(row[idx].ToString()); idx++;
                            item.CODIGO_SAT = Int32.Parse(row[idx].ToString()); idx++;
                            item.ATRIBUTO_PRODUCTO = Int32.Parse(row[idx].ToString()); idx++;
                            item.TIPO_ESMALTE = Int32.Parse(row[idx].ToString()); idx++;
                            item.INPACK = Int32.Parse(row[idx].ToString()); idx++;
                            item.TIPO_EMPAQUE = Int32.Parse(row[idx].ToString()); idx++;
                            item.TIPO_IMPRESION = Int32.Parse(row[idx].ToString()); idx++;
                            item.RPN_MINIMO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.RPN_OBJETIVO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.RPN_MAXIMO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.RPR_MINIMO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.RPR_OBJETIVO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.RPR_MAXIMO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.RPC_MINIMO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.RPC_OBJETIVO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.RPC_MAXIMO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.VPE_UNIDADES = Decimal.Parse(row[idx].ToString()); idx++;
                            item.VPE_VALORES = Decimal.Parse(row[idx].ToString()); idx++;
                            item.VPA_UNIDADES = Decimal.Parse(row[idx].ToString()); idx++;
                            item.VPA_VALORES = Decimal.Parse(row[idx].ToString()); idx++;
                            item.ITEM_REFERENCIA = row[idx].ToString(); idx++;
                            item.PROTOTIPO = row[idx].ToString(); idx++;
                            item.COSTO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.PORCENTAJE_GVV = Decimal.Parse(row[idx].ToString()); idx++;
                            item.FECHA_PT = DateTime.Parse(row[idx].ToString()); idx++;
                            item.GENETICA = Int32.Parse(row[idx].ToString()); idx++;
                            item.FRACCION_ARANCELARIA = Int32.Parse(row[idx].ToString()); idx++;
                            item.CODIGO_PRODUCTO = row[idx].ToString(); idx++;
                            item.CODIGO_BARRAS = row[idx].ToString(); idx++;
                            item.CONTENIDO_PIEZAS = row[idx].ToString(); idx++;
                            item.NUMERO_CAJA_INDIVIDUAL = row[idx].ToString(); idx++;
                            item.TIPO_CIERRE_INDIVIDUAL = row[idx].ToString(); idx++;
                            item.NUMERO_CAJA_MASTER = row[idx].ToString(); idx++;
                            item.TIPO_CIERRE_MASTER = row[idx].ToString(); idx++;
                            item.NUMERO_DIVISIONES = Decimal.Parse(row[idx].ToString()); idx++;
                            item.CANTIDAD_DIVISIONES = Decimal.Parse(row[idx].ToString()); idx++;
                            item.DATOS_ETIQUETA = row[idx].ToString(); idx++;
                            item.PESO_NETO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.PESO_BRUTO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.CUBICAJE = row[idx].ToString(); idx++;
                            item.TIPO_CALCA = Int32.Parse(row[idx].ToString()); idx++;
                            item.TIPO_EMPAQUE_CAJA = Int32.Parse(row[idx].ToString()); idx++;
                            item.DISENO_GRAFICO = Int32.Parse(row[idx].ToString()); idx++;
                            item.APROBADO_MERCADOTECNIA = Int32.Parse(row[idx].ToString()); idx++;
                            item.APROBADO_INGENIERIA = Int32.Parse(row[idx].ToString()); idx++;
                            item.APROBADO_GERENCIA = Int32.Parse(row[idx].ToString()); idx++;
                            item.APROBADO_CALIDAD = Int32.Parse(row[idx].ToString()); idx++;
                            item.ESTATUS = Int32.Parse(row[idx].ToString()); idx++;
                            item.COMENTARIO = row[idx].ToString(); idx++;
                            item.USUARIO = row[idx].ToString(); idx++;

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
                res = new List<proc_contratoNacimiento>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }





        public static List<proc_contratoNacimiento> GetFromUsuario(string id)
        {
            List<proc_contratoNacimiento> res = new List<proc_contratoNacimiento>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_proc_contratoNacimientoFromUsuario(id,out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new proc_contratoNacimiento();

                            item.ID = Int32.Parse(row[idx].ToString()); idx++;
                            item.DESCRIPCION = row[idx].ToString(); idx++;
                            item.TITULO = row[idx].ToString(); idx++;
                            item.FC = DateTime.Parse(row[idx].ToString()); idx++;
                            item.FU = DateTime.Parse(row[idx].ToString()); idx++;
                            item.LINEA = Int32.Parse(row[idx].ToString()); idx++;
                            item.UPDATED_BY = row[idx].ToString(); idx++;
                            item.PORTAFOLIO = Int32.Parse(row[idx].ToString()); idx++;
                            item.FOLIO = row[idx].ToString(); idx++;
                            item.MARCA = row[idx].ToString(); idx++;
                            item.DESCRIPCION_SAT = Int32.Parse(row[idx].ToString()); idx++;
                            item.DEFINICION = row[idx].ToString(); idx++;
                            item.NUEVO_PRODUCTO = Int32.Parse(row[idx].ToString()); idx++;
                            item.SUBLINEA = Int32.Parse(row[idx].ToString()); idx++;
                            item.LINEA_ANFAD = Int32.Parse(row[idx].ToString()); idx++;
                            item.CODIGO_SAT = Int32.Parse(row[idx].ToString()); idx++;
                            item.ATRIBUTO_PRODUCTO = Int32.Parse(row[idx].ToString()); idx++;
                            item.TIPO_ESMALTE = Int32.Parse(row[idx].ToString()); idx++;
                            item.INPACK = Int32.Parse(row[idx].ToString()); idx++;
                            item.TIPO_EMPAQUE = Int32.Parse(row[idx].ToString()); idx++;
                            item.TIPO_IMPRESION = Int32.Parse(row[idx].ToString()); idx++;
                            item.RPN_MINIMO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.RPN_OBJETIVO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.RPN_MAXIMO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.RPR_MINIMO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.RPR_OBJETIVO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.RPR_MAXIMO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.RPC_MINIMO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.RPC_OBJETIVO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.RPC_MAXIMO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.VPE_UNIDADES = Decimal.Parse(row[idx].ToString()); idx++;
                            item.VPE_VALORES = Decimal.Parse(row[idx].ToString()); idx++;
                            item.VPA_UNIDADES = Decimal.Parse(row[idx].ToString()); idx++;
                            item.VPA_VALORES = Decimal.Parse(row[idx].ToString()); idx++;
                            item.ITEM_REFERENCIA = row[idx].ToString(); idx++;
                            item.PROTOTIPO = row[idx].ToString(); idx++;
                            item.COSTO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.PORCENTAJE_GVV = Decimal.Parse(row[idx].ToString()); idx++;
                            item.FECHA_PT = DateTime.Parse(row[idx].ToString()); idx++;
                            item.GENETICA = Int32.Parse(row[idx].ToString()); idx++;
                            item.FRACCION_ARANCELARIA = Int32.Parse(row[idx].ToString()); idx++;
                            item.CODIGO_PRODUCTO = row[idx].ToString(); idx++;
                            item.CODIGO_BARRAS = row[idx].ToString(); idx++;
                            item.CONTENIDO_PIEZAS = row[idx].ToString(); idx++;
                            item.NUMERO_CAJA_INDIVIDUAL = row[idx].ToString(); idx++;
                            item.TIPO_CIERRE_INDIVIDUAL = row[idx].ToString(); idx++;
                            item.NUMERO_CAJA_MASTER = row[idx].ToString(); idx++;
                            item.TIPO_CIERRE_MASTER = row[idx].ToString(); idx++;
                            item.NUMERO_DIVISIONES = Decimal.Parse(row[idx].ToString()); idx++;
                            item.CANTIDAD_DIVISIONES = Decimal.Parse(row[idx].ToString()); idx++;
                            item.DATOS_ETIQUETA = row[idx].ToString(); idx++;
                            item.PESO_NETO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.PESO_BRUTO = Decimal.Parse(row[idx].ToString()); idx++;
                            item.CUBICAJE = row[idx].ToString(); idx++;
                            item.TIPO_CALCA = Int32.Parse(row[idx].ToString()); idx++;
                            item.TIPO_EMPAQUE_CAJA = Int32.Parse(row[idx].ToString()); idx++;
                            item.DISENO_GRAFICO = Int32.Parse(row[idx].ToString()); idx++;
                            item.APROBADO_MERCADOTECNIA = Int32.Parse(row[idx].ToString()); idx++;
                            item.APROBADO_INGENIERIA = Int32.Parse(row[idx].ToString()); idx++;
                            item.APROBADO_GERENCIA = Int32.Parse(row[idx].ToString()); idx++;
                            item.APROBADO_CALIDAD = Int32.Parse(row[idx].ToString()); idx++;
                            item.ESTATUS = Int32.Parse(row[idx].ToString()); idx++;
                            item.COMENTARIO = row[idx].ToString(); idx++;
                            item.USUARIO = row[idx].ToString(); idx++;
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
                res = new List<proc_contratoNacimiento>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
        */
    }

}