using dll_Gis;
using GISMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace GISMVC.Controllers
{
    public class ArchivosController : ApiController
    {
        public Funciones funcion = new Funciones();

        [System.Web.Http.Route("api/Archivos/DocumentoContrato")]
        [System.Web.Http.HttpPost]
        public async Task<RespuestaFormato> DecoradoArchivos()
        {
            RespuestaFormato res = new RespuestaFormato();
            //--------------------
            var req = HttpContext.Current.Request;
            int contrato = 0;
            int tipo_archivo = 0;
            string usuario = "";
            string tipo = "";
            HttpPostedFile file = null;    

            try
            {
                Int32.TryParse(req.Params[contrato].ToString(), out contrato);
                Int32.TryParse(req.Params[tipo_archivo].ToString(), out tipo_archivo);
                if (!String.IsNullOrEmpty(req.Params["usuario"].ToString()))
                {
                    usuario = req.Params["usuario"];
                }
                if (!String.IsNullOrEmpty(req.Params["tipo"].ToString()))
                {
                    tipo = req.Params["tipo"];
                }
                if (req.Files.Count > 0)
                {
                    file = req.Files[0];
                }
                if (file == null || file.ContentLength == 0)
                {
                    res.flag = false;
                }
                else
                {
                    Contrato contratoPbj = Contrato.GetById(contrato);
                    string ext = Path.GetExtension(file.FileName);
                    string nombre = contratoPbj.folio + "_" + contratoPbj.proveedor.ToUpper() + "_" + DateTime.Now.ToString("dd/MM/yyyy").Replace("/", "");
                    DocumentoContrato archivo = new DocumentoContrato();
                    archivo.file_content_type = file.ContentType;
                    archivo.file_nombre = file.FileName;
                    archivo.nombre = nombre;
                    archivo.file_extension = ext;
                    archivo.contrato = contrato;
                    archivo.usuario.id = usuario;
                    archivo.tipo_archivo.id = tipo_archivo;
                    archivo.tipo = tipo;

                    var path = "";
                    byte[] bytes = new byte[] { 0 };
                    if (file != null)
                    {
                        archivo.file_size = (int)file.ContentLength;
                        using (var binaryReader = new BinaryReader(file.InputStream))
                        {
                            bytes = binaryReader.ReadBytes(file.ContentLength);
                        }
                    }

                    archivo.file_data = bytes;

                    res = archivo.Crear();
                    if (res.flag == true)
                    {
                        /*var archivos = DocumentoContrato.GetFromId(contrato, tipo);
                        res.content.Add(archivos);*/
                        res.data_int = res.data_int;
                        res.data_string = file.FileName;

                        RegistroActividad actividad = new RegistroActividad();
                        actividad.usuario.id = usuario;
                        actividad.titulo = "DOCUMENTO";
                        actividad.descripcion = "Agregó un documento: " + res.data_string;
                        actividad.aux_int = res.data_int;
                        actividad.contrato = contrato;
                        actividad.Crear();
                    }
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [System.Web.Http.Route("api/Archivos/UploadArchivo")]
        [System.Web.Http.HttpPost]
        public async Task<RespuestaFormato> UploadArchivo()
        {
            RespuestaFormato res = new RespuestaFormato();
            //--------------------
            var req = HttpContext.Current.Request;
            int objeto = 0;
            string usuario = "";
            string tipo = "";
            string modelo = "";
            HttpPostedFile file = null;

            try
            {
                Int32.TryParse(req.Params[objeto].ToString(), out objeto);
                if (!String.IsNullOrEmpty(req.Params["usuario"].ToString()))
                {
                    usuario = req.Params["usuario"];
                }
                if (!String.IsNullOrEmpty(req.Params["tipo"].ToString()))
                {
                    tipo = req.Params["tipo"];
                }
                if (!String.IsNullOrEmpty(req.Params["modelo"].ToString()))
                {
                    modelo = req.Params["modelo"];
                }
                if (req.Files.Count > 0)
                {
                    file = req.Files[0];
                }
                if (file == null || file.ContentLength == 0)
                {
                    res.flag = false;
                }
                else
                {
                    string ext = Path.GetExtension(file.FileName);
                    Archivo archivo = new Archivo();
                    archivo.file_content_type = file.ContentType;
                    archivo.file_nombre = file.FileName;
                    archivo.nombre = ext;
                    archivo.file_extension = ext;
                    archivo.usuario.id = usuario;
                    archivo.tipo = tipo;

                    var path = "";
                    byte[] bytes = new byte[] { 0 };
                    if (file != null)
                    {
                        archivo.file_size = (int)file.ContentLength;
                        using (var binaryReader = new BinaryReader(file.InputStream))
                        {
                            bytes = binaryReader.ReadBytes(file.ContentLength);
                        }
                    }

                    archivo.file_data = bytes;

                    res = archivo.Crear();
                    if (res.flag == true)
                    {
                        res.data_int = res.data_int;
                        res.data_string = file.FileName;

                        //
                        RLArchivo rl = new RLArchivo();
                        rl.objeto = objeto;
                        rl.archivo = res.data_int;
                        switch (modelo)
                        {
                            case "Marca":
                                rl.CrearMarca();
                                break;
                            case "AvisoComercial":
                                rl.CrearAvisoComercial();
                                break;
                            case "Patente":
                                rl.CrearPatente();
                                break;
                            case "DisenoIndustrial":
                                rl.CrearDisenoIndustrial();
                                break;
                            case "ModeloUtilidad":
                                rl.CrearModeloUtilidad();
                                break;
                            case "ModeloIndustrial":
                                rl.CrearModeloIndustrial();
                                break;
                            case "Obra":
                                rl.CrearObra();
                                break;
                        }
                        //
                    }
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [System.Web.Http.Route("api/Archivos/UploadArchivoV2")]
        [System.Web.Http.HttpPost]
        public async Task<RespuestaFormato> UploadArchivoV2()
        {
            RespuestaFormato res = new RespuestaFormato();
            //--------------------
            var req = HttpContext.Current.Request;
            int objeto = 0;
            string usuario = "";
            string tipo = "";
            string modelo = "";
            HttpPostedFile file = null;

            try
            {
                Int32.TryParse(req.Params["objeto"].ToString(), out objeto);
                if (!String.IsNullOrEmpty(req.Params["usuario"].ToString()))
                {
                    usuario = req.Params["usuario"];
                }
                if (!String.IsNullOrEmpty(req.Params["tipo"].ToString()))
                {
                    tipo = req.Params["tipo"];
                }
                if (!String.IsNullOrEmpty(req.Params["modelo"].ToString()))
                {
                    modelo = req.Params["modelo"];
                }
                if (req.Files.Count > 0)
                {
                    file = req.Files[0];
                }
                if (file == null || file.ContentLength == 0)
                {
                    res.flag = false;
                }
                else
                {
                    //
                    string setting_folder_path = ConfigurationManager.AppSettings["PI_filepath"].ToString();
                    var content_host = System.Web.Hosting.HostingEnvironment.MapPath("~/Content");
                    var content_app = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content");
                    string main_folder = Path.Combine(content_host, setting_folder_path, modelo.ToUpper() + "_" + objeto.ToString());
                    bool continuar = false;
                    Directory.CreateDirectory(main_folder);
                    if (Directory.Exists(main_folder))
                    {
                        string ext = Path.GetExtension(file.FileName);
                        Archivo archivo = new Archivo();
                        archivo.file_nombre = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ff")
                            .Replace("-", "")
                            .Replace(" ", "_")
                            .Replace(":", "")
                            + ".txt";
                        archivo.file_content_type = file.ContentType;
                        archivo.file_size = (int)file.ContentLength;
                        archivo.file_extension = ext;
                        archivo.nombre = file.FileName;
                        archivo.url = Path.Combine(main_folder, archivo.file_nombre);
                        archivo.usuario.id = usuario;
                        archivo.tipo = tipo;

                        byte[] bytes = new byte[] { 0 };
                        archivo.file_data = bytes;
                        if (file != null)
                        {
                            //archivo.file_size = (int)file.ContentLength;
                            using (var binaryReader = new BinaryReader(file.InputStream))
                            {
                                bytes = binaryReader.ReadBytes(file.ContentLength);
                                binaryReader.Close();
                            }
                        }

                        String contenido_archivo = Convert.ToBase64String(bytes);

                        using (StreamWriter sw = new StreamWriter(archivo.url, true, Encoding.UTF8))
                        {
                            sw.WriteLine(contenido_archivo);
                            sw.Close();
                        }

                        if (File.Exists(archivo.url))
                        {
                            //
                            archivo.url = funcion.Encriptar(Path.Combine(modelo.ToUpper() + "_" + objeto.ToString(),archivo.file_nombre));
                            res = archivo.Crear();
                            if (res.flag != false)
                            {
                                var result = Archivo.GetById(res.data_int);
                                res.content.Add(result);
                                //res.content.Add(archivo.permalink);

                                RLArchivo rl = new RLArchivo();
                                rl.objeto = objeto;
                                rl.archivo = res.data_int;
                                switch (modelo)
                                {
                                    case "Marca":
                                        rl.CrearMarca();
                                        break;
                                    case "AvisoComercial":
                                        rl.CrearAvisoComercial();
                                        break;
                                    case "Patente":
                                        rl.CrearPatente();
                                        break;
                                    case "DisenoIndustrial":
                                        rl.CrearDisenoIndustrial();
                                        break;
                                    case "ModeloUtilidad":
                                        rl.CrearModeloUtilidad();
                                        break;
                                    case "ModeloIndustrial":
                                        rl.CrearModeloIndustrial();
                                        break;
                                    case "Obra":
                                        rl.CrearObra();
                                        break;
                                    case "RegistroMarca":
                                        rl.CrearRegistroMarca();
                                        break;
                                }
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
                    //
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [System.Web.Http.Route("api/Archivos/RegistroMarcaSaveFile")]
        [System.Web.Http.HttpPost]
        public async Task<RespuestaFormato> RegistroMarcaSaveFile()
        {
            RespuestaFormato res = new RespuestaFormato();
            //--------------------
            var req = HttpContext.Current.Request;
            int objeto = 0;
            string usuario = "";
            string tipo = "";
            string valor = "";
            HttpPostedFile file = null;

            try
            {
                Int32.TryParse(req.Params[objeto].ToString(), out objeto);
                if (!String.IsNullOrEmpty(req.Params["usuario"].ToString()))
                {
                    usuario = req.Params["usuario"];
                }
                if (!String.IsNullOrEmpty(req.Params["tipo"].ToString()))
                {
                    tipo = req.Params["tipo"];
                }
                if (!String.IsNullOrEmpty(req.Params["valor"].ToString()))
                {
                    valor = req.Params["valor"];
                }
                if (req.Files.Count > 0)
                {
                    file = req.Files[0];
                }
                if (file == null || file.ContentLength == 0)
                {
                    res.flag = false;
                }
                else
                {
                    string setting_folder_path = ConfigurationManager.AppSettings["PI_filepath"].ToString();
                    var content_host = System.Web.Hosting.HostingEnvironment.MapPath("~/Content");
                    var content_app = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content");
                    string main_folder = Path.Combine(content_host, setting_folder_path, "RM_" + valor);
                    bool continuar = false;
                    Directory.CreateDirectory(main_folder);
                    if (Directory.Exists(main_folder))
                    {
                        RegistroMarca archivo = new RegistroMarca();
                        archivo.id = Int32.Parse(valor);
                        string ext = Path.GetExtension(file.FileName);
                        archivo.solicitud_nombre = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ff")
                            .Replace("-","")
                            .Replace(" ", "_")
                            .Replace(":", "")
                            + ".txt"; //nombre nuevo del txt
                        archivo.solicitud_content_type = file.ContentType;
                        archivo.solicitud_size = (int)file.ContentLength;
                        archivo.solicitud_extension = ext;
                        archivo.solicitud_nombre_original = file.FileName; //nombre original
                        archivo.solicitud_url = Path.Combine(main_folder, archivo.solicitud_nombre);
                        archivo.solicitud_permalink = Utility.hosturl +
                            "PI/RegistroMarcaDocumento?id=" +
                            HttpUtility.UrlEncode(funcion.Encriptar(archivo.id.ToString())) +
                            "&tp=" +
                            HttpUtility.UrlEncode(funcion.Encriptar(tipo));
                        ///

                        byte[] bytes = new byte[] { 0 };
                        if (file != null)
                        {
                            //archivo.file_size = (int)file.ContentLength;
                            using (var binaryReader = new BinaryReader(file.InputStream))
                            {
                                bytes = binaryReader.ReadBytes(file.ContentLength);
                                binaryReader.Close();
                            }
                        }

                        String contenido_archivo = Convert.ToBase64String(bytes);

                        using (StreamWriter sw = new StreamWriter(archivo.solicitud_url, true, Encoding.UTF8))
                        {
                            sw.WriteLine(contenido_archivo);
                            sw.Close();
                        }

                        if (File.Exists(archivo.solicitud_url))
                        {
                            //

                            int documento = -1;
                            switch (tipo)
                            {
                                case "solicitud":
                                    documento = 0;
                                    break;
                                case "titulo":
                                    documento = 1;
                                    break;
                                case "oficio":
                                    documento = 2;
                                    break;
                            }
                            archivo.solicitud_url = funcion.Encriptar(archivo.solicitud_url);
                            var addArchivo = RegistroMarca.ActualizarDocumento(archivo, documento);
                            res = addArchivo;
                            if(res.flag != false)
                            {
                                res.content.Add(archivo.solicitud_nombre_original);
                                res.content.Add(archivo.solicitud_permalink);
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
                    /*string ext = Path.GetExtension(file.FileName);
                       Archivo archivo = new Archivo();
                       archivo.file_content_type = file.ContentType;
                       archivo.file_nombre = file.FileName;
                       archivo.nombre = ext;
                       archivo.file_extension = ext;
                       archivo.usuario.id = usuario;
                       archivo.tipo = tipo;

                       var path = "";
                       byte[] bytes = new byte[] { 0 };
                       if (file != null)
                       {
                           archivo.file_size = (int)file.ContentLength;
                           using (var binaryReader = new BinaryReader(file.InputStream))
                           {
                               bytes = binaryReader.ReadBytes(file.ContentLength);
                           }
                       }

                       archivo.file_data = bytes;

                       res = archivo.Crear();
                       if (res.flag == true)
                       {
                           res.data_int = res.data_int;
                           res.data_string = file.FileName;

                           //
                           RLArchivo rl = new RLArchivo();
                           rl.objeto = objeto;
                           rl.archivo = res.data_int;
                           switch (modelo)
                           {
                               case "Marca":
                                   rl.CrearMarca();
                                   break;
                               case "AvisoComercial":
                                   rl.CrearAvisoComercial();
                                   break;
                               case "Patente":
                                   rl.CrearPatente();
                                   break;
                               case "DisenoIndustrial":
                                   rl.CrearDisenoIndustrial();
                                   break;
                               case "ModeloUtilidad":
                                   rl.CrearModeloUtilidad();
                                   break;
                               case "ModeloIndustrial":
                                   rl.CrearModeloIndustrial();
                                   break;
                               case "Obra":
                                   rl.CrearObra();
                                   break;
                           }
                           //
                       }

                       */

                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [System.Web.Http.Route("api/Archivos/LicenciaSaveFile")]
        [System.Web.Http.HttpPost]
        public async Task<RespuestaFormato> LicenciaSaveFile()
        {
            RespuestaFormato res = new RespuestaFormato();
            //--------------------
            var req = HttpContext.Current.Request;
            int objeto = 0;
            string usuario = "";
            string tipo = "";
            string valor = "";
            HttpPostedFile file = null;

            try
            {
                Int32.TryParse(req.Params[objeto].ToString(), out objeto);
                if (!String.IsNullOrEmpty(req.Params["usuario"].ToString()))
                {
                    usuario = req.Params["usuario"];
                }
                if (!String.IsNullOrEmpty(req.Params["tipo"].ToString()))
                {
                    tipo = req.Params["tipo"];
                }
                if (!String.IsNullOrEmpty(req.Params["valor"].ToString()))
                {
                    valor = req.Params["valor"];
                }
                if (req.Files.Count > 0)
                {
                    file = req.Files[0];
                }
                if (file == null || file.ContentLength == 0)
                {
                    res.flag = false;
                }
                else
                {
                    string setting_folder_path = ConfigurationManager.AppSettings["PI_filepath"].ToString();
                    var content_host = System.Web.Hosting.HostingEnvironment.MapPath("~/Content");
                    var content_app = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content");
                    string main_folder = Path.Combine(content_host, setting_folder_path, "CL_" + valor);
                    bool continuar = false;
                    Directory.CreateDirectory(main_folder);
                    if (Directory.Exists(main_folder))
                    {
                        ConvenioLicencia archivo = new ConvenioLicencia();
                        archivo.id = Int32.Parse(valor);
                        string ext = Path.GetExtension(file.FileName);
                        archivo.solicitud_nombre = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ff")
                            .Replace("-", "")
                            .Replace(" ", "_")
                            .Replace(":", "")
                            + ".txt"; //nombre nuevo del txt
                        archivo.solicitud_content_type = file.ContentType;
                        archivo.solicitud_size = (int)file.ContentLength;
                        archivo.solicitud_extension = ext;
                        archivo.solicitud_nombre_original = file.FileName; //nombre original
                        archivo.solicitud_url = Path.Combine(main_folder, archivo.solicitud_nombre);
                        archivo.solicitud_permalink = Utility.hosturl +
                            "PI/ConvenioLicenciaDocumento?id=" +
                            HttpUtility.UrlEncode(funcion.Encriptar(archivo.id.ToString())) +
                            "&tp=" +
                            HttpUtility.UrlEncode(funcion.Encriptar(tipo));
                        ///

                        byte[] bytes = new byte[] { 0 };
                        if (file != null)
                        {
                            //archivo.file_size = (int)file.ContentLength;
                            using (var binaryReader = new BinaryReader(file.InputStream))
                            {
                                bytes = binaryReader.ReadBytes(file.ContentLength);
                                binaryReader.Close();
                            }
                        }

                        String contenido_archivo = Convert.ToBase64String(bytes);

                        using (StreamWriter sw = new StreamWriter(archivo.solicitud_url, true, Encoding.UTF8))
                        {
                            sw.WriteLine(contenido_archivo);
                            sw.Close();
                        }

                        if (File.Exists(archivo.solicitud_url))
                        {
                            //

                            int documento = -1;
                            switch (tipo)
                            {
                                case "solicitud":
                                    documento = 0;
                                    break;
                                case "contrato":
                                    documento = 1;
                                    break;
                                case "oficio":
                                    documento = 2;
                                    break;
                            }
                            archivo.solicitud_url = funcion.Encriptar(archivo.solicitud_url);
                            var addArchivo = ConvenioLicencia.ActualizarDocumento(archivo, documento);
                            res = addArchivo;
                            if (res.flag != false)
                            {
                                res.content.Add(archivo.solicitud_nombre_original);
                                res.content.Add(archivo.solicitud_permalink);
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
                    /*string ext = Path.GetExtension(file.FileName);
                       Archivo archivo = new Archivo();
                       archivo.file_content_type = file.ContentType;
                       archivo.file_nombre = file.FileName;
                       archivo.nombre = ext;
                       archivo.file_extension = ext;
                       archivo.usuario.id = usuario;
                       archivo.tipo = tipo;

                       var path = "";
                       byte[] bytes = new byte[] { 0 };
                       if (file != null)
                       {
                           archivo.file_size = (int)file.ContentLength;
                           using (var binaryReader = new BinaryReader(file.InputStream))
                           {
                               bytes = binaryReader.ReadBytes(file.ContentLength);
                           }
                       }

                       archivo.file_data = bytes;

                       res = archivo.Crear();
                       if (res.flag == true)
                       {
                           res.data_int = res.data_int;
                           res.data_string = file.FileName;

                           //
                           RLArchivo rl = new RLArchivo();
                           rl.objeto = objeto;
                           rl.archivo = res.data_int;
                           switch (modelo)
                           {
                               case "Marca":
                                   rl.CrearMarca();
                                   break;
                               case "AvisoComercial":
                                   rl.CrearAvisoComercial();
                                   break;
                               case "Patente":
                                   rl.CrearPatente();
                                   break;
                               case "DisenoIndustrial":
                                   rl.CrearDisenoIndustrial();
                                   break;
                               case "ModeloUtilidad":
                                   rl.CrearModeloUtilidad();
                                   break;
                               case "ModeloIndustrial":
                                   rl.CrearModeloIndustrial();
                                   break;
                               case "Obra":
                                   rl.CrearObra();
                                   break;
                           }
                           //
                       }

                       */

                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }


        [System.Web.Http.Route("api/Archivos/CesionSaveFile")]
        [System.Web.Http.HttpPost]
        public async Task<RespuestaFormato> CesionSaveFile()
        {
            RespuestaFormato res = new RespuestaFormato();
            //--------------------
            var req = HttpContext.Current.Request;
            int objeto = 0;
            string usuario = "";
            string tipo = "";
            string valor = "";
            HttpPostedFile file = null;

            try
            {
                Int32.TryParse(req.Params[objeto].ToString(), out objeto);
                if (!String.IsNullOrEmpty(req.Params["usuario"].ToString()))
                {
                    usuario = req.Params["usuario"];
                }
                if (!String.IsNullOrEmpty(req.Params["tipo"].ToString()))
                {
                    tipo = req.Params["tipo"];
                }
                if (!String.IsNullOrEmpty(req.Params["valor"].ToString()))
                {
                    valor = req.Params["valor"];
                }
                if (req.Files.Count > 0)
                {
                    file = req.Files[0];
                }
                if (file == null || file.ContentLength == 0)
                {
                    res.flag = false;
                }
                else
                {
                    string setting_folder_path = ConfigurationManager.AppSettings["PI_filepath"].ToString();
                    var content_host = System.Web.Hosting.HostingEnvironment.MapPath("~/Content");
                    var content_app = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content");
                    string main_folder = Path.Combine(content_host, setting_folder_path, "CC_" + valor);
                    bool continuar = false;
                    Directory.CreateDirectory(main_folder);
                    if (Directory.Exists(main_folder))
                    {
                        ContratoCesion archivo = new ContratoCesion();
                        archivo.id = Int32.Parse(valor);
                        string ext = Path.GetExtension(file.FileName);
                        archivo.solicitud_nombre = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ff")
                            .Replace("-", "")
                            .Replace(" ", "_")
                            .Replace(":", "")
                            + ".txt"; //nombre nuevo del txt
                        archivo.solicitud_content_type = file.ContentType;
                        archivo.solicitud_size = (int)file.ContentLength;
                        archivo.solicitud_extension = ext;
                        archivo.solicitud_nombre_original = file.FileName; //nombre original
                        archivo.solicitud_url = Path.Combine(main_folder, archivo.solicitud_nombre);
                        archivo.solicitud_permalink = Utility.hosturl +
                            "PI/ContratoCesionDocumento?id=" +
                            HttpUtility.UrlEncode(funcion.Encriptar(archivo.id.ToString())) +
                            "&tp=" +
                            HttpUtility.UrlEncode(funcion.Encriptar(tipo));
                        ///

                        byte[] bytes = new byte[] { 0 };
                        if (file != null)
                        {
                            //archivo.file_size = (int)file.ContentLength;
                            using (var binaryReader = new BinaryReader(file.InputStream))
                            {
                                bytes = binaryReader.ReadBytes(file.ContentLength);
                                binaryReader.Close();
                            }
                        }

                        String contenido_archivo = Convert.ToBase64String(bytes);

                        using (StreamWriter sw = new StreamWriter(archivo.solicitud_url, true, Encoding.UTF8))
                        {
                            sw.WriteLine(contenido_archivo);
                            sw.Close();
                        }

                        if (File.Exists(archivo.solicitud_url))
                        {
                            //

                            int documento = -1;
                            switch (tipo)
                            {
                                case "solicitud":
                                    documento = 0;
                                    break;
                                case "contrato":
                                    documento = 1;
                                    break;
                                case "oficio":
                                    documento = 2;
                                    break;
                            }
                            archivo.solicitud_url = funcion.Encriptar(archivo.solicitud_url);
                            var addArchivo = ContratoCesion.ActualizarDocumento(archivo, documento);
                            res = addArchivo;
                            if (res.flag != false)
                            {
                                res.content.Add(archivo.solicitud_nombre_original);
                                res.content.Add(archivo.solicitud_permalink);
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
                    /*string ext = Path.GetExtension(file.FileName);
                       Archivo archivo = new Archivo();
                       archivo.file_content_type = file.ContentType;
                       archivo.file_nombre = file.FileName;
                       archivo.nombre = ext;
                       archivo.file_extension = ext;
                       archivo.usuario.id = usuario;
                       archivo.tipo = tipo;

                       var path = "";
                       byte[] bytes = new byte[] { 0 };
                       if (file != null)
                       {
                           archivo.file_size = (int)file.ContentLength;
                           using (var binaryReader = new BinaryReader(file.InputStream))
                           {
                               bytes = binaryReader.ReadBytes(file.ContentLength);
                           }
                       }

                       archivo.file_data = bytes;

                       res = archivo.Crear();
                       if (res.flag == true)
                       {
                           res.data_int = res.data_int;
                           res.data_string = file.FileName;

                           //
                           RLArchivo rl = new RLArchivo();
                           rl.objeto = objeto;
                           rl.archivo = res.data_int;
                           switch (modelo)
                           {
                               case "Marca":
                                   rl.CrearMarca();
                                   break;
                               case "AvisoComercial":
                                   rl.CrearAvisoComercial();
                                   break;
                               case "Patente":
                                   rl.CrearPatente();
                                   break;
                               case "DisenoIndustrial":
                                   rl.CrearDisenoIndustrial();
                                   break;
                               case "ModeloUtilidad":
                                   rl.CrearModeloUtilidad();
                                   break;
                               case "ModeloIndustrial":
                                   rl.CrearModeloIndustrial();
                                   break;
                               case "Obra":
                                   rl.CrearObra();
                                   break;
                           }
                           //
                       }

                       */

                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }


        #region ARCHIVOS
        [System.Web.Http.Route("api/Archivos/ArchivoContrato")]
        [System.Web.Http.HttpPost]
        public async Task<RespuestaFormato> ArchivoContrato()
        {
            RespuestaFormato res = new RespuestaFormato();
            //--------------------
            var req = HttpContext.Current.Request;
            int contrato = 0;
            int tipo_archivo = 0;
            string usuario = "";
            string tipo = "";
            string modelo = "";
            HttpPostedFile file = null;

            try
            {
                Int32.TryParse(req.Params["contrato"].ToString(), out contrato);
                Int32.TryParse(req.Params["tipo_archivo"].ToString(), out tipo_archivo);
                if (!String.IsNullOrEmpty(req.Params["usuario"].ToString()))
                {
                    usuario = req.Params["usuario"];
                }
                if (!String.IsNullOrEmpty(req.Params["tipo"].ToString()))
                {
                    tipo = req.Params["tipo"];
                }
                if (!String.IsNullOrEmpty(req.Params["modelo"].ToString()))
                {
                    modelo = req.Params["modelo"];
                }
                if (req.Files.Count > 0)
                {
                    file = req.Files[0];
                }
                if (file == null || file.ContentLength == 0)
                {
                    res.flag = false;
                }
                else
                {
                    //
                    string setting_folder_path = ConfigurationManager.AppSettings["Contratos_filepath"].ToString();
                    var content_host = System.Web.Hosting.HostingEnvironment.MapPath("~/Content");
                    var content_app = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content");
                    string main_folder = Path.Combine(content_host, setting_folder_path, modelo.ToUpper() + "_" + contrato.ToString());
                    bool continuar = false;
                    Directory.CreateDirectory(main_folder);
                    if (Directory.Exists(main_folder))
                    {
                        string ext = Path.GetExtension(file.FileName);

                        DocumentoContrato archivo = new DocumentoContrato();
                        archivo.file_nombre = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ff")
                            .Replace("-", "")
                            .Replace(" ", "_")
                            .Replace(":", "")
                            + ".txt";
                        archivo.file_content_type = file.ContentType;
                        archivo.file_size = (int)file.ContentLength;
                        archivo.file_extension = ext;
                        archivo.nombre = file.FileName;
                        archivo.url = Path.Combine(main_folder, archivo.file_nombre);
                        archivo.contrato = contrato;
                        archivo.usuario.id = usuario;
                        archivo.tipo_archivo.id = tipo_archivo;
                        archivo.tipo = tipo;

                        byte[] bytes = new byte[] { 0 };
                        archivo.file_data = bytes;
                        if (file != null)
                        {
                            //archivo.file_size = (int)file.ContentLength;
                            using (var binaryReader = new BinaryReader(file.InputStream))
                            {
                                bytes = binaryReader.ReadBytes(file.ContentLength);
                                binaryReader.Close();
                            }
                        }

                        String contenido_archivo = Convert.ToBase64String(bytes);

                        using (StreamWriter sw = new StreamWriter(archivo.url, true, Encoding.UTF8))
                        {
                            sw.WriteLine(contenido_archivo);
                            sw.Close();
                        }

                        if (File.Exists(archivo.url))
                        {
                            //
                            archivo.url = funcion.Encriptar(Path.Combine(modelo.ToUpper() + "_" + contrato.ToString(), archivo.file_nombre));

                            res = archivo.Crear();
                            if (res.flag != false)
                            {
                                var result = DocumentoContrato.GetById(res.data_int);
                                res.content.Add(result);
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
                    //
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }
        #endregion
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}