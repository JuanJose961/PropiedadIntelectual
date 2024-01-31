using dll_Gis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace GISMVC.Models
{
    public class DocumentoCliente
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
        public string rfc { get; set; }

        public DocumentoCliente()
        {
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
            rfc = "";
        }

        public static RespuestaFormato Cargar(DocumentoContrato doc, string rfc)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                Funciones funcion = new Funciones();
                string setting_folder_path = ConfigurationManager.AppSettings["Clientes_filepath"].ToString();
                var content_host = System.Web.Hosting.HostingEnvironment.MapPath("~/Content");
                var content_app = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content");
                string main_folder = Path.Combine(content_host, setting_folder_path, "CLIENTE_" + rfc);
                bool continuar = false;
                Directory.CreateDirectory(main_folder);
                if (Directory.Exists(main_folder))
                {
                    string ext = Path.GetExtension(doc.file_nombre);

                    DocumentoCliente archivo = new DocumentoCliente();
                    archivo.file_nombre = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ff")
                        .Replace("-", "")
                        .Replace(" ", "_")
                        .Replace(":", "")
                        + ".txt";
                    archivo.file_content_type = doc.file_content_type;
                    archivo.file_size = (int)doc.file_size;
                    archivo.file_extension = ext;
                    archivo.nombre = doc.file_nombre;
                    archivo.url = Path.Combine(main_folder, archivo.file_nombre);
                    archivo.rfc = rfc;
                    //archivo.usuario.id = usuario;
                    archivo.tipo_archivo.id = 6;
                    archivo.tipo = doc.tipo;

                    byte[] bytes = new byte[] { 0 };
                    archivo.file_data = bytes;
                    String contenido_archivo = doc.file_data_str;

                    using (StreamWriter sw = new StreamWriter(archivo.url, true, Encoding.UTF8))
                    {
                        sw.WriteLine(contenido_archivo);
                        sw.Close();
                    }

                    if (File.Exists(archivo.url))
                    {
                        //
                        archivo.url = funcion.Encriptar(Path.Combine("CLIENTE_" + rfc, archivo.file_nombre));

                        res = archivo.Crear();
                        if (res.flag != false)
                        {
                            res.description = "Correcto";
                        }
                        else
                        {
                            res.flag = false;
                            res.description = "Error al guardar archivo";
                        }
                    }
                    else
                    {
                        res.flag = false;
                        res.description = "Error";
                        res.errors.Add("No se pudo crear el archivo txt.");
                    }
                    ///
                }
                else
                {
                    continuar = false;
                    res.errors.Add("No se pudo encontrar o crear la carpeta principal para almacenar los archivos.");
                    res.flag = false;
                    res.description = "Error";
                    return res;
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
                if (da.INS_DocumentoCliente(this, out dt, out errores))
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
        
        public static RespuestaFormato Eliminar(DocumentoCliente modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.DEL_DocumentoCliente(modelo, out dt, out errores))
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
        public static RespuestaFormato RFCExiste(string rfc)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_DocumentoClienteRFCExiste(rfc, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        int id = 0;
                        int siguiente = 0;
                        Int32.TryParse(row[3].ToString(), out id);
                        if (id > 0)
                        {
                            res.flag = true;
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
        public static DocumentoCliente GetById(int id)
        {
            DocumentoCliente res = new DocumentoCliente();
            try
            {
                dll_Gis.Funciones funcion = new dll_Gis.Funciones();
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_DocumentoClienteById(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];
                        var item = new DocumentoCliente();
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

                        item.permalink = Utility.hosturl +
                            "Admin/DescargarC?id=" +
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
                res = new DocumentoCliente();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
        public static List<DocumentoCliente> GetFromId(string id = "", string tipo = "")
        {
            List<DocumentoCliente> res = new List<DocumentoCliente>();
            try
            {
                dll_Gis.Funciones funcion = new dll_Gis.Funciones();
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_DocumentoClienteFromId(id, tipo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new DocumentoCliente();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.contrato = Int32.Parse(row[idx].ToString()); idx++;
                            item.file_nombre = row[idx].ToString(); idx++;
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
                                "Admin/DescargarC?id=" +
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
                res = new List<DocumentoCliente>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<DocumentoContrato> GetFromIdToDocumentoContrato(string id = "", string tipo = "")
        {
            List<DocumentoContrato> res = new List<DocumentoContrato>();
            try
            {
                dll_Gis.Funciones funcion = new dll_Gis.Funciones();
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_DocumentoClienteFromId(id, tipo, out dt, out errores))
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
                            item.es_precarga = 1;
                            item.permalink = Utility.hosturl +
                                "Admin/DescargarC?id=" +
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

    }
}