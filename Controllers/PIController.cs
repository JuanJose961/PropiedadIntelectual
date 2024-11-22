using dll_Gis;
using GISMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Configuration;

namespace GISMVC.Controllers
{
    public class PIController : Controller
    {
        public Funciones funcion = new Funciones();


        public ActionResult RegistroMarcaDocumento(string id = "", string tp = "", string us = "")
        {
        //http://localhost:54689/PI/DescargarDocumento?id=1231&usuario=qwertyuio
            if (id == "" || tp == "")
                return View("Error");
            try
            {
                string filename = "";
                byte[] bytes = new byte[] { 0 };
                string ctype = "";
                string path = "";
                int objetoid = 0;
                Int32.TryParse(funcion.Desencriptar(id), out objetoid);
                GISMVC.Models.RegistroMarca objeto = GISMVC.Models.RegistroMarca.GetById(objetoid);
                string tipo = funcion.Desencriptar(tp);


                string setting_folder_path = ConfigurationManager.AppSettings["PI_filepath"].ToString();
                string content_host = System.Web.Hosting.HostingEnvironment.MapPath("~/Content");
                string content_app = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content");
                string main_folder = Path.Combine(content_host, setting_folder_path, "RM_" + objeto.id.ToString());

                switch (tipo)
                {
                    case "titulo":
                        filename = objeto.titulo_nombre_original;
                        ctype = objeto.titulo_content_type;
                        path = Path.Combine(main_folder, objeto.titulo_nombre);
                        break;
                    case "solicitud":
                        filename = objeto.solicitud_nombre_original;
                        ctype = objeto.solicitud_content_type;
                        path = Path.Combine(main_folder, objeto.solicitud_nombre);
                        break;
                    case "oficio":
                        filename = objeto.oficio_nombre_original;
                        ctype = objeto.oficio_content_type;
                        path = Path.Combine(main_folder, objeto.oficio_nombre);
                        break;
                    case "contrato":
                        filename = objeto.contrato_nombre_original;
                        ctype = objeto.contrato_content_type;
                        path = Path.Combine(main_folder, objeto.contrato_nombre);
                        break;
                    case "reivindicacion":
                        filename = objeto.reivindicacion_nombre_original;
                        ctype = objeto.reivindicacion_content_type;
                        path = Path.Combine(main_folder, objeto.reivindicacion_nombre);
                        break;
                    case "carta":
                        filename = objeto.carta_nombre_original;
                        ctype = objeto.carta_content_type;
                        path = Path.Combine(main_folder, objeto.carta_nombre);
                        break;
                }

                //var path2 = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Pi/RegistrosMarca/20220905_183517_17.txt");
                List<string> lineas = new List<string>();

                string content_string = "";
                using (var reader = new StreamReader(path, Encoding.Default))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (!String.IsNullOrEmpty(line))
                        {
                            content_string += line;
                            Console.WriteLine(line);
                        }
                    }
                }

                bytes = Convert.FromBase64String(content_string);
                if (filename != "")
                {
                    return File(bytes, Utility.GetContentType(filename), filename);
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }

        public ActionResult ConvenioLicenciaDocumento(string id = "", string tp = "", string us = "")
        {
            //http://localhost:54689/PI/DescargarDocumento?id=1231&usuario=qwertyuio
            if (id == "" || tp == "")
                return View("Error");
            try
            {
                string filename = "";
                byte[] bytes = new byte[] { 0 };
                string ctype = "";
                string path = "";
                int objetoid = 0;
                Int32.TryParse(funcion.Desencriptar(id), out objetoid);
                GISMVC.Models.ConvenioLicencia objeto = GISMVC.Models.ConvenioLicencia.GetById(objetoid);
                string tipo = funcion.Desencriptar(tp);


                string setting_folder_path = ConfigurationManager.AppSettings["PI_filepath"].ToString();
                string content_host = System.Web.Hosting.HostingEnvironment.MapPath("~/Content");
                string content_app = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content");
                string main_folder = Path.Combine(content_host, setting_folder_path, "CL_" + objeto.id.ToString());

                switch (tipo)
                {
                    case "contrato":
                        filename = objeto.contrato_nombre_original;
                        ctype = objeto.contrato_content_type;
                        path = Path.Combine(main_folder, objeto.contrato_nombre);
                        break;
                    case "solicitud":
                        filename = objeto.solicitud_nombre_original;
                        ctype = objeto.solicitud_content_type;
                        path = Path.Combine(main_folder, objeto.solicitud_nombre);
                        break;
                    case "oficio":
                        filename = objeto.oficio_nombre_original;
                        ctype = objeto.oficio_content_type;
                        path = Path.Combine(main_folder, objeto.oficio_nombre);
                        break;
                }

                //var path2 = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Pi/RegistrosMarca/20220905_183517_17.txt");
                List<string> lineas = new List<string>();

                string content_string = "";
                using (var reader = new StreamReader(path, Encoding.Default))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (!String.IsNullOrEmpty(line))
                        {
                            content_string += line;
                            Console.WriteLine(line);
                        }
                    }
                }

                bytes = Convert.FromBase64String(content_string);
                if (filename != "")
                {
                    return File(bytes, Utility.GetContentType(filename), filename);
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }

        public ActionResult ContratoCcesionDocumento(string id = "", string tp = "", string us = "")
        {
            //http://localhost:54689/PI/DescargarDocumento?id=1231&usuario=qwertyuio
            if (id == "" || tp == "")
                return View("Error");
            try
            {
                string filename = "";
                byte[] bytes = new byte[] { 0 };
                string ctype = "";
                string path = "";
                int objetoid = 0;
                Int32.TryParse(funcion.Desencriptar(id), out objetoid);
                GISMVC.Models.ContratoCesion objeto = GISMVC.Models.ContratoCesion.GetById(objetoid);
                string tipo = funcion.Desencriptar(tp);


                string setting_folder_path = ConfigurationManager.AppSettings["PI_filepath"].ToString();
                string content_host = System.Web.Hosting.HostingEnvironment.MapPath("~/Content");
                string content_app = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content");
                string main_folder = Path.Combine(content_host, setting_folder_path, "CC_" + objeto.id.ToString());

                switch (tipo)
                {
                    case "contrato":
                        filename = objeto.contrato_nombre_original;
                        ctype = objeto.contrato_content_type;
                        path = Path.Combine(main_folder, objeto.contrato_nombre);
                        break;
                    case "solicitud":
                        filename = objeto.solicitud_nombre_original;
                        ctype = objeto.solicitud_content_type;
                        path = Path.Combine(main_folder, objeto.solicitud_nombre);
                        break;
                    case "oficio":
                        filename = objeto.oficio_nombre_original;
                        ctype = objeto.oficio_content_type;
                        path = Path.Combine(main_folder, objeto.oficio_nombre);
                        break;
                }

                //var path2 = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Pi/RegistrosMarca/20220905_183517_17.txt");
                List<string> lineas = new List<string>();

                string content_string = "";
                using (var reader = new StreamReader(path, Encoding.Default))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (!String.IsNullOrEmpty(line))
                        {
                            content_string += line;
                            Console.WriteLine(line);
                        }
                    }
                }

                bytes = Convert.FromBase64String(content_string);
                if (filename != "")
                {
                    return File(bytes, Utility.GetContentType(filename), filename);
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }

        public ActionResult DescargarArchivo(string id = "")
        {
            //http://localhost:54689/PI/DescargarDocumento?id=1231&usuario=qwertyuio
            if (id == "")
                return View("Error");
            try
            {
                string filename = "";
                byte[] bytes = new byte[] { 0 };
                string ctype = "";
                string path = "";
                int objetoid = 0;
                Int32.TryParse(funcion.Desencriptar(id), out objetoid);
                Archivo objeto = Archivo.GetById(objetoid);
                string url = funcion.Desencriptar(objeto.url);


                string setting_folder_path = ConfigurationManager.AppSettings["PI_filepath"].ToString();
                string content_host = System.Web.Hosting.HostingEnvironment.MapPath("~/Content");
                string content_app = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content");
                string main_folder = Path.Combine(content_host, setting_folder_path, url);


                filename = objeto.nombre;
                ctype = objeto.file_content_type;
                path = main_folder;

                //var path2 = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Pi/RegistrosMarca/20220905_183517_17.txt");
                List<string> lineas = new List<string>();

                string content_string = "";
                using (var reader = new StreamReader(path, Encoding.Default))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (!String.IsNullOrEmpty(line))
                        {
                            content_string += line;
                            Console.WriteLine(line);
                        }
                    }
                }

                bytes = Convert.FromBase64String(content_string);
                if (filename != "")
                {
                    return File(bytes, Utility.GetContentType(filename), filename);
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }

        //[HttpGet("Admin/PlanoMecanico/{id}", nameof = "PlanoMecanico")]
        public async Task<ActionResult> Index()
        {
            string id1 = funcion.Encriptar("a.chaires@softdepot.mx");
            string id0 = funcion.Encriptar("softdepot12.");
            string id2 = funcion.Encriptar("smtp.gmail.com");
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                //
                /*RegistroActividad test = new RegistroActividad();
                test.usuario.id = "id de usuario";
                test.titulo = "titulo";
                test.descripcion = "desc";
                test.aux_decimal = 5/4;
                test.aux_str = "aux str";
                test.aux_int = 856;
                test.contrato = 99;
                var addRA = test.Crear();*/
                //
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Inicio";


                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                ViewBag.pagina = pagina;
                ViewBag.ul = ul;

                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }

        public async Task<ActionResult> Negocio()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Negocio";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                ViewBag.pagina = pagina;
                ViewBag.ul = ul;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }

        public async Task<ActionResult> PoliticasAdm()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Politicas";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);
                var politicas = RespuestaFormato.Get("POLITICAS");
                ViewBag.pagina = pagina;
                ViewBag.ul = ul;
                ViewBag.politicas = politicas;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }
        public async Task<ActionResult> Politicas()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Politicas";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);
                var politicas = RespuestaFormato.Get("POLITICAS");
                ViewBag.pagina = pagina;
                ViewBag.ul = ul;
                ViewBag.politicas = politicas;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }


        public async Task<ActionResult> TipoCatalogo()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Tipo Catalogo";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                ViewBag.pagina = pagina;
                ViewBag.ul = ul;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }


        public async Task<ActionResult> TipoRegistro()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Tipo Registro";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                ViewBag.pagina = pagina;
                ViewBag.ul = ul;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }

        public async Task<ActionResult> Clase()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Clase";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                ViewBag.pagina = pagina;
                ViewBag.ul = ul;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }


        public async Task<ActionResult> EstatusCatalogo()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Estatus Catalogo";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                ViewBag.pagina = pagina;
                ViewBag.ul = ul;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }


        public async Task<ActionResult> Despacho()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Despacho";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                ViewBag.pagina = pagina;
                ViewBag.ul = ul;

                var abogados = AspNetUsers.GetByRol("e9d0046c-3c62-4e91-81d5-8c8bc2a5c16b");
                ViewBag.abogado = abogados;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }


        public async Task<ActionResult> Corresponsal()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Corresponsal";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                ViewBag.pagina = pagina;
                ViewBag.ul = ul;

                var abogados = AspNetUsers.GetByRol("e9d0046c-3c62-4e91-81d5-8c8bc2a5c16b");
                ViewBag.abogado = abogados;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }

        public async Task<ActionResult> Pais()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "País";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                ViewBag.pagina = pagina;
                ViewBag.ul = ul;

                var abogados = AspNetUsers.GetByRol("e9d0046c-3c62-4e91-81d5-8c8bc2a5c16b");
                ViewBag.abogado = abogados;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }

        public async Task<ActionResult> ConvenioLicencia()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Convenio Licencia";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                var empresas = GISMVC.Models.NegocioPI.Get();
                var paises = GISMVC.Models.Pais.Get();
                var usuarios = GISMVC.Models.AspNetUsers.Get();
                var despacho = GISMVC.Models.Despacho.Get();
                var corresponsal = GISMVC.Models.Corresponsal.Get();
                var clases = GISMVC.Models.Clase.Get();
                var cesion = GISMVC.Models.ContratoCesion.Get();

                ViewBag.pagina = pagina;
                ViewBag.ul = ul;

                ViewBag.empresas = empresas;
                ViewBag.paises = paises;
                ViewBag.usuarios = usuarios;
                ViewBag.despacho = despacho;
                ViewBag.corresponsal = corresponsal;
                ViewBag.clases = clases;
                ViewBag.cesion = cesion;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }
        public async Task<ActionResult> ContratoCesion()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Contrato Cesión";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                var empresas = GISMVC.Models.NegocioPI.Get();
                var paises = GISMVC.Models.Pais.Get();
                var usuarios = GISMVC.Models.AspNetUsers.Get();
                var despacho = GISMVC.Models.Despacho.Get();
                var corresponsal = GISMVC.Models.Corresponsal.Get();
                var clases = GISMVC.Models.Clase.Get();

                ViewBag.pagina = pagina;
                ViewBag.ul = ul;

                ViewBag.empresas = empresas;
                ViewBag.paises = paises;
                ViewBag.usuarios = usuarios;
                ViewBag.despacho = despacho;
                ViewBag.corresponsal = corresponsal;
                ViewBag.clases = clases;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }

        public async Task<ActionResult> Marca()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Marca";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                var empresas = GISMVC.Models.NegocioPI.Get();
                var paises = GISMVC.Models.Pais.Get();
                var usuarios = GISMVC.Models.AspNetUsers.Get();
                var tipo_registro_solicitud = GISMVC.Models.TipoRegistro.Get();

                ViewBag.pagina = pagina;
                ViewBag.ul = ul;

                ViewBag.empresas = empresas;
                ViewBag.paises = paises;
                ViewBag.usuarios = usuarios;
                ViewBag.tipo_registro_solicitud = tipo_registro_solicitud;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }

        public async Task<ActionResult> AvisoComercial()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Aviso Comercial";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                var empresas = GISMVC.Models.NegocioPI.Get();
                var paises = GISMVC.Models.Pais.Get();
                var usuarios = GISMVC.Models.AspNetUsers.Get();
                var tipo_registro_solicitud = GISMVC.Models.TipoRegistro.Get();

                ViewBag.pagina = pagina;
                ViewBag.ul = ul;

                ViewBag.empresas = empresas;
                ViewBag.paises = paises;
                ViewBag.usuarios = usuarios;
                ViewBag.tipo_registro_solicitud = tipo_registro_solicitud;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }

        public async Task<ActionResult> Patente()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Patente";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                var empresas = GISMVC.Models.NegocioPI.Get();
                var paises = GISMVC.Models.Pais.Get();
                var usuarios = GISMVC.Models.AspNetUsers.Get();

                ViewBag.pagina = pagina;
                ViewBag.ul = ul;

                ViewBag.empresas = empresas;
                ViewBag.paises = paises;
                ViewBag.usuarios = usuarios;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }
        public async Task<ActionResult> ModeloUtilidad()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Modelo Utilidad";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                var empresas = GISMVC.Models.NegocioPI.Get();
                var paises = GISMVC.Models.Pais.Get();
                var usuarios = GISMVC.Models.AspNetUsers.Get();

                ViewBag.pagina = pagina;
                ViewBag.ul = ul;

                ViewBag.empresas = empresas;
                ViewBag.paises = paises;
                ViewBag.usuarios = usuarios;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }
        public async Task<ActionResult> ModeloIndustrial()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Modelo Industrial";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                var empresas = GISMVC.Models.NegocioPI.Get();
                var paises = GISMVC.Models.Pais.Get();
                var usuarios = GISMVC.Models.AspNetUsers.Get();

                ViewBag.pagina = pagina;
                ViewBag.ul = ul;

                ViewBag.empresas = empresas;
                ViewBag.paises = paises;
                ViewBag.usuarios = usuarios;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }
        public async Task<ActionResult> DisenoIndustrial()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Diseño Industrial";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                var empresas = GISMVC.Models.NegocioPI.Get();
                var paises = GISMVC.Models.Pais.Get();
                var usuarios = GISMVC.Models.AspNetUsers.Get();

                ViewBag.pagina = pagina;
                ViewBag.ul = ul;

                ViewBag.empresas = empresas;
                ViewBag.paises = paises;
                ViewBag.usuarios = usuarios;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }

        public async Task<ActionResult> Obra()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Obra";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                var empresas = GISMVC.Models.NegocioPI.Get();
                var paises = GISMVC.Models.Pais.Get();
                var usuarios = GISMVC.Models.AspNetUsers.Get();

                ViewBag.pagina = pagina;
                ViewBag.ul = ul;

                ViewBag.empresas = empresas;
                ViewBag.paises = paises;
                ViewBag.usuarios = usuarios;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }


        public async Task<ActionResult> Usuarios()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Usuarios";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);
                //if (ul.roles.id == "8566d71d-72f0-489d-92d4-410804d82e60")
                //{
                    var roles = AspNetRoles.GetAll("PI");

                    var negocios = GISMVC.Models.NegocioPI.Get();

                    ViewBag.pagina = pagina;
                    ViewBag.ul = ul;
                    ViewBag.roles = roles;
                    ViewBag.negocios = negocios;
                    return View();
                /*}
                else
                {
                    return Redirect(Utility.hosturl + "Admin/Index");
                }*/
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }
        /*///////////////*/

        public async Task<ActionResult> RecordatorioPI()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Recordatorios";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                var usuarios = GISMVC.Models.AspNetUsers.Get();
                var tiporecordatorio= GISMVC.Models.TipoRecordatorio.Get();
                var fchvalidacion=GISMVC.Models.FechaValidacion.Get();
                //var negocios = GISMVC.Models.Negocio.Get();
                var campos = GISMVC.Models.RecordatorioPICampos.Get();
                var tiposolicitudrecordatorio = GISMVC.Models.TipoSolicitudRecordatorio.Get();

                ViewBag.pagina = pagina;
                ViewBag.ul = ul;
                ViewBag.usuarios = usuarios;
                ViewBag.tiporecordatorio = tiporecordatorio;
                ViewBag.fechavalidacion = fchvalidacion;
                //ViewBag.negocios = negocios;
                ViewBag.campos = campos;
                ViewBag.tiposolicitudrecordatorio = tiposolicitudrecordatorio;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }
        public async Task<ActionResult> RegistroMarcas()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Registro Marcas";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                var empresas = GISMVC.Models.NegocioPI.Get();
                var paises = GISMVC.Models.Pais.Get();
                var usuarios = GISMVC.Models.AspNetUsers.Get();

                ViewBag.pagina = pagina;
                ViewBag.ul = ul;
                ViewBag.idRol = ul.roles.id;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }
        public async Task<ActionResult> RegistroMarca()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                int id = 0;
                if (Request.QueryString["id"] == "" || Request.QueryString["id"] == null)
                {
                    id = 0;
                }
                else
                {
                    //string dc = Request.QueryString["id"].ToString();
                    string dc = Utility.descifrar(Request.QueryString["id"].ToString());
                    Int32.TryParse(dc, out id);
                }
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Registro de Marca";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                var empresa = NegocioPI.Get();
                //
                var tipo_solicitud = TipoSolicitud.Get();
                var tipo_pago = TipoPago.Get();
                var uso = Uso.Get();

                var solicitud = new List<Solicitud>();
                var marca = GISMVC.Models.Marca.Get();
                var aviso = GISMVC.Models.AvisoComercial.Get();
                var patente = GISMVC.Models.Patente.Get();
                var diseno = GISMVC.Models.DisenoIndustrial.Get();
                var modin = GISMVC.Models.ModeloIndustrial.Get();
                var modut = GISMVC.Models.ModeloUtilidad.Get();
                var obra = GISMVC.Models.Obra.Get();

                solicitud = solicitud.Concat(Solicitud.ListMarcaToSolicitud(marca)).ToList();
                solicitud = solicitud.Concat(Solicitud.ListAvisoComercialToSolicitud(aviso)).ToList();
                solicitud = solicitud.Concat(Solicitud.ListPatenteToSolicitud(patente)).ToList();
                solicitud = solicitud.Concat(Solicitud.ListDisenoIndustrialToSolicitud(diseno)).ToList();
                solicitud = solicitud.Concat(Solicitud.ListModeloIndustrialToSolicitud(modin)).ToList();
                solicitud = solicitud.Concat(Solicitud.ListModeloUtilidadToSolicitud(modut)).ToList();
                solicitud = solicitud.Concat(Solicitud.ListObraToSolicitud(obra)).ToList();
                //
                var clase = GISMVC.Models.Clase.Get();
                var tipo_registro = GISMVC.Models.TipoRegistro.Get();
                var pais = GISMVC.Models.Pais.Get();
                var estatus = GISMVC.Models.EstatusCatalogo.Get();
                var tipo_registro_solicitud = GISMVC.Models.TipoRegistro.Get();
                var despacho = GISMVC.Models.Despacho.Get();
                var corresponsal = GISMVC.Models.Corresponsal.Get();
                var licencia = GISMVC.Models.ConvenioLicencia.Get();
                var cesion = GISMVC.Models.ContratoCesion.Get();
                var usuarios = AspNetUsers.Get();

                ViewBag.mainid = id;
                ViewBag.pagina = pagina;
                ViewBag.ul = ul;


                ViewBag.tipo_solicitud = tipo_solicitud;
                ViewBag.tipo_pago = tipo_pago;
                ViewBag.uso = uso;
                ViewBag.empresa = empresa;
                ViewBag.solicitud = solicitud;
                ViewBag.clase = clase;
                ViewBag.tipo_registro = tipo_registro;
                ViewBag.pais = pais;
                ViewBag.tipo_registro_solicitud = tipo_registro_solicitud;
                ViewBag.estatus = estatus;
                ViewBag.despacho = despacho;
                ViewBag.corresponsal = corresponsal;
                ViewBag.licencia = licencia;
                ViewBag.cesion = cesion;
                ViewBag.usuarios = usuarios;
                ViewBag.idRol = ul.roles.id;
                return View();
            }
            else
            {
                string return_url = Utility.hosturl + "Account/Login?return_url=PI/RegistroMarcaDetalle?" + Request.QueryString.ToString();
                return Redirect(return_url);
            }
        }

        public async Task<ActionResult> BusquedaAvanzada()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Busqueda Avanzada";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                var empresa = GISMVC.Models.NegocioPI.Get();
                var paises = GISMVC.Models.Pais.Get();
                var usuarios = GISMVC.Models.AspNetUsers.Get();
                var tipo_solicitud = TipoSolicitud.Get();
                var clase = GISMVC.Models.Clase.Get();
                var pais = GISMVC.Models.Pais.Get();
                var estatus = GISMVC.Models.EstatusCatalogo.Get();
                var uso = Uso.Get();
                var tipo_registro_solicitud = GISMVC.Models.TipoRegistro.Get();


                ViewBag.pagina = pagina;
                ViewBag.ul = ul;
                ViewBag.idRol = ul.roles.id;
                ViewBag.tipo_solicitud = tipo_solicitud;
                ViewBag.empresa = empresa;
                ViewBag.clase = clase;
                ViewBag.pais = pais;
                ViewBag.estatus = estatus;
                ViewBag.uso = uso;
                ViewBag.tipo_registro_solicitud = tipo_registro_solicitud;
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }

    }
}