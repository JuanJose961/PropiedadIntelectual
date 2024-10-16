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
using System.Configuration;
using System.Text;

namespace GISMVC.Controllers
{
    public class AdminController : Controller
    {
        public Funciones funcion = new Funciones();
        public ActionResult DescargarDocumento(int id = 0, string usuario = "")
        {
            if (id == 0 || usuario == "")
                return View("Error");
            try
            {
                string filename = "";
                byte[] bytes = new byte[] { 0 };
                string ctype = "";

                var tempFile = DocumentoContrato.GetById(id);
                filename = tempFile.file_nombre;
                bytes = tempFile.file_data;
                ctype = tempFile.file_content_type;

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

        public ActionResult Descargar(string id = "", string usuario = "")
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
                DocumentoContrato objeto = DocumentoContrato.GetById(objetoid);
                string url = funcion.Desencriptar(objeto.url);


                string setting_folder_path = ConfigurationManager.AppSettings["Contratos_filepath"].ToString();
                string content_host = System.Web.Hosting.HostingEnvironment.MapPath("~/Content");
                string content_app = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content");
                string main_folder = Path.Combine(content_host, setting_folder_path, url);


                filename = objeto.file_nombre;
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

        public ActionResult DescargarC(string id = "", string usuario = "")
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
                DocumentoCliente objeto = DocumentoCliente.GetById(objetoid);
                string url = funcion.Desencriptar(objeto.url);


                string setting_folder_path = ConfigurationManager.AppSettings["Clientes_filepath"].ToString();
                string content_host = System.Web.Hosting.HostingEnvironment.MapPath("~/Content");
                string content_app = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content");
                string main_folder = Path.Combine(content_host, setting_folder_path, url);


                filename = objeto.nombre_original;
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
        public ActionResult DescargarArchivo(int id = 0)
        {
            if (id == 0)
                return View("Error");
            try
            {
                string filename = "";
                byte[] bytes = new byte[] { 0 };
                string ctype = "";

                var tempFile = Archivo.GetById(id);
                filename = tempFile.file_nombre;
                bytes = tempFile.file_data;
                ctype = tempFile.file_content_type;

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

        public ActionResult DescargarDocumentoProveedor()
        {
            /*if (id == 0)
                return View("Error");*/
            try
            {
                string filename = "";
                byte[] bytes = new byte[] { 0 };
                string ctype = "";

                var docs = DocumentoProveedor.Get("CUCO8702086J6");
                filename = docs[0].file_nombre;
                bytes = docs[0].file_data;
                ctype = docs[0].file_content_type;

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

        public async Task<ActionResult> DescargarExcel()
        {
            try
            {
                var busqueda = new BusquedaContrato();
                busqueda.inicio = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd") + " 00:00:00";
                busqueda.fin = DateTime.Now.AddMonths(3).ToString("yyyy-MM-dd") + " 23:59:59";
                busqueda.abogado = "";
                busqueda.min_monto = 0;
                busqueda.max_monto = 999999999;
                int total = 0;
                var contratos = GISMVC.Models.Contrato.GetBusqueda(busqueda, out total);
                string filename = "excel_contrato_.xlsx";
                XLWorkbook wb = new XLWorkbook();

                var contentfolder = HttpContext.Server.MapPath("~/Content");
                var url = Path.Combine(
                       contentfolder, filename);


                var ws1 = wb.Worksheets.Add("DATOS GENERALES");

                ws1.Cell("C3").Value = "MATRIZ DE CONTROL DE CONTRATOS";
                ws1.Cell("C4").Value = "COMPAÑIA";
                ws1.Cell("C3").Style.Font.Bold = true;
                ws1.Cell("C4").Style.Font.Bold = true;

                ws1.Cell("C7").Value = "Folio Jurídico";
                ws1.Cell("D7").Value = "Contraparte";
                ws1.Cell("E7").Value = "RFC de la Contraparte";
                ws1.Cell("F7").Value = "País de residencia de la contraparte";
                ws1.Cell("G7").Value = "Empresa GIS";
                ws1.Cell("H7").Value = "Apoderado Legal GIS";
                ws1.Cell("I7").Value = "Fecha inicio de la vigencia";
                ws1.Cell("J7").Value = "Fecha de fin de la vigencia";
                ws1.Cell("K7").Value = "Contraprestación";
                ws1.Cell("L7").Value = "Término de pago";
                ws1.Cell("M7").Value = "Tipo de moneda";
                ws1.Cell("N7").Value = "Importe total del Contrato";
                ws1.Cell("O7").Value = "Tipo de Contrato";
                ws1.Cell("P7").Value = "Objeto";
                ws1.Cell("Q7").Value = "Descripción del servicio";
                ws1.Cell("R7").Value = "Intercompañia";
                ws1.Cell("S7").Value = "Días Vencido";
                ws1.Cell("T7").Value = "Estatus del Contrato";
                ws1.Cell("U7").Value = "Comentarios";
                ws1.Cell("V7").Value = "Usuario solicitante";
                ws1.Cell("W7").Value = "Abogado asignado";
                ws1.Cell("C7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("D7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("E7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("F7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("G7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("H7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("I7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("J7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("K7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("L7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("M7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("N7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("O7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("P7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("Q7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("R7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("S7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("T7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("U7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("V7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("W7").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);

                int cellIdx = 8;
                foreach (var item in contratos)
                {
                    ws1.Cell("C" + cellIdx).Value = item.id;
                    ws1.Cell("D" + cellIdx).Value = item.proveedor;
                    ws1.Cell("E" + cellIdx).Value = item.rfc;
                    ws1.Cell("F" + cellIdx).Value = "---";
                    ws1.Cell("G" + cellIdx).Value = item.negocio_desc;
                    ws1.Cell("H" + cellIdx).Value = "---";
                    ws1.Cell("I" + cellIdx).Value = item.inicio_vigencia.ddmmyyyy;
                    ws1.Cell("J" + cellIdx).Value = item.termino_contrato.ddmmyyyy;
                    ws1.Cell("K" + cellIdx).Value = item.monto.ToString("C", CultureInfo.CurrentCulture).Replace("$","");
                    ws1.Cell("L" + cellIdx).Value = "---";
                    ws1.Cell("M" + cellIdx).Value = item.moneda_desc;
                    ws1.Cell("N" + cellIdx).Value = "---";
                    ws1.Cell("O" + cellIdx).Value = item.tipo_contrato_desc;
                    ws1.Cell("P" + cellIdx).Value = "---";
                    ws1.Cell("Q" + cellIdx).Value = item.descripcion;
                    ws1.Cell("R" + cellIdx).Value = "---";
                    ws1.Cell("S" + cellIdx).Value = "Pendiente calcular";
                    ws1.Cell("T" + cellIdx).Value = "Pendiente calcular/Ajustar Estatus";
                    ws1.Cell("U" + cellIdx).Value = "---";
                    ws1.Cell("V" + cellIdx).Value = item.usuario.name;
                    ws1.Cell("W" + cellIdx).Value = item.abogado_nombre;
                    cellIdx += 1;
                }
                if (filename != "")
                {
                    wb.SaveAs(url);
                    //--
                    var memory = new MemoryStream();
                    using (var stream = new FileStream(url, FileMode.Open))
                    {
                        await stream.CopyToAsync(memory);
                    }
                    memory.Position = 0;
                    string ctype = Utility.GetContentType(url);
                    string dname = Path.GetFileName(url);
                    System.IO.File.Delete(url);
                    return File(memory, ctype, dname);
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

        public async Task<ActionResult> DescargarExcelRegistroMarca()
        {
            try
            {
                //var busqueda = new RegistroMarca();
                //busqueda.inicio = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd") + " 00:00:00";
                //busqueda.fin = DateTime.Now.AddMonths(3).ToString("yyyy-MM-dd") + " 23:59:59";
                //busqueda.abogado = "";
                //busqueda.min_monto = 0;
                //busqueda.max_monto = 999999999;
                //int total = 0;
                //var contratos = GISMVC.Models.RegistroMarca.Get(busqueda, out total);

                var solicitudes = GISMVC.Models.RegistroMarca.Get(0, "bef7d03f-d37b-41a2-8ec6-eb204d313a78");
                DateTime localDate = DateTime.Now;
                string formatted = localDate.ToString("yyyyMdd_Hmmss");
                string filename = "solicitudes"+formatted+".xlsx";
                XLWorkbook wb = new XLWorkbook();

                var contentfolder = HttpContext.Server.MapPath("~/Content");
                var url = Path.Combine(
                       contentfolder, filename);


                var ws1 = wb.Worksheets.Add("Solicitudes");

                ws1.Cell("A1").Value = "TIPO DE SOLICITUD";
                ws1.Cell("B1").Value = "NOMBRE";
                ws1.Cell("A1").Style.Font.Bold = true;
                ws1.Cell("B1").Style.Font.Bold = true;
                ws1.Cell("C1").Value = "EMPRESA";
                ws1.Cell("D1").Value = "EMPRESA ANTERIOR";
                ws1.Cell("E1").Value = "FECHA LEGAL";
                ws1.Cell("F1").Value = "FECHA VENCIMIENTO";
                ws1.Cell("G1").Value = "FECHA CONCESIÓN";
                ws1.Cell("H1").Value = "No. REGISTRO";
                ws1.Cell("I1").Value = "PAIS";
                ws1.Cell("J1").Value = "CLASE";
                ws1.Cell("K1").Value = "ESTATUS";
                ws1.Cell("L1").Value = "USO";
                ws1.Cell("M1").Value = "No. SOLICITUD";
                ws1.Cell("N1").Value = "TIPO REGISTRO";
                ws1.Cell("O1").Value = "SOLICITO REGISTRO";
                ws1.Cell("P1").Value = "DESPACHO";
                ws1.Cell("Q1").Value = "CORRESPONSAL";
                ws1.Cell("R1").Value = "LICENCIA";
                ws1.Cell("S1").Value = "SOLICITO LICENCIA";
                ws1.Cell("T1").Value = "CESIÓN";
                ws1.Cell("U1").Value = "SOLICITO CESIÓN";
                ws1.Cell("V1").Value = "FECHA REQUERIMIENTO DEL NEGOCIO";
                ws1.Cell("W1").Value = "FECHA INSTRUCCIONES AL CORRESPONSAL";
                ws1.Cell("X1").Value = "FECHA REGISTRO ANTE LA AUTOTIDAD";
                ws1.Cell("Y1").Value = "FECHA SOLICITUD DE BUSQUEDA";
                ws1.Cell("Z1").Value = "FECHA INFORMACIÓN DE RESULTADOS";
                ws1.Cell("AA1").Value = "FECHA COMPROBACIÓN DE USO";
                ws1.Cell("AB1").Value = "FECHA DECLARACIÓN DE USO";
                ws1.Cell("A1").Style.Font.Bold = true;
                ws1.Cell("B1").Style.Font.Bold = true;
                ws1.Cell("A1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("B1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("C1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("D1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("E1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("F1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("G1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("H1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("I1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("J1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("K1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("L1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("M1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("N1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("O1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("P1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("Q1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("R1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("S1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("T1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("U1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("V1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("W1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("X1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("Y1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("Z1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("AA1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws1.Cell("AB1").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);

                int cellIdx = 2;
                foreach (var item in solicitudes)
                {
                    ws1.Cell("A" + cellIdx).Value = item.solicitud_tipo_desc;
                    ws1.Cell("B" + cellIdx).Value = item.nombre;
                    ws1.Cell("C" + cellIdx).Value = item.empresa_desc;
                    ws1.Cell("D" + cellIdx).Value = item.empresa_anterior_desc;
                    ws1.Cell("E" + cellIdx).Value = item.fecha_legalS;
                    ws1.Cell("F" + cellIdx).Value = item.fecha_vencimientoS;
                    ws1.Cell("G" + cellIdx).Value = item.fecha_concesionS;
                    ws1.Cell("H" + cellIdx).Value = item.no_registro;
                    ws1.Cell("I" + cellIdx).Value = item.pais_desc;
                    ws1.Cell("J" + cellIdx).Value = item.clase_desc;
                    ws1.Cell("K" + cellIdx).Value = item.estatus_desc;
                    ws1.Cell("L" + cellIdx).Value = item.uso_desc;
                    ws1.Cell("M" + cellIdx).Value = item.no_solicitud;
                    ws1.Cell("N" + cellIdx).Value = item.tipo_registro_desc;
                    ws1.Cell("O" + cellIdx).Value = item.autor_registro_desc;
                    ws1.Cell("P" + cellIdx).Value = item.despacho_desc;
                    ws1.Cell("Q" + cellIdx).Value = item.corresponsal_desc;
                    ws1.Cell("R" + cellIdx).Value = item.licencia_desc;
                    ws1.Cell("S" + cellIdx).Value = item.solicitante_licencia_desc;
                    ws1.Cell("T" + cellIdx).Value = item.cesion_desc;
                    ws1.Cell("U" + cellIdx).Value = item.solicitante_cesion_desc;
                    ws1.Cell("V" + cellIdx).Value = item.fecha_requerimientoS;
                    ws1.Cell("W" + cellIdx).Value = item.fecha_instruccionesS;
                    ws1.Cell("X" + cellIdx).Value = item.fecha_registroS;
                    ws1.Cell("Y" + cellIdx).Value = item.fecha_busquedaS;
                    ws1.Cell("Z" + cellIdx).Value = item.fecha_resultadosS;
                    ws1.Cell("AA" + cellIdx).Value = item.fecha_comprobacionS;
                    ws1.Cell("AB" + cellIdx).Value = item.fecha_declaracionS;
                    cellIdx += 1;
                }
                if (filename != "")
                {
                    wb.SaveAs(url);
                    //--
                    var memory = new MemoryStream();
                    using (var stream = new FileStream(url, FileMode.Open))
                    {
                        await stream.CopyToAsync(memory);
                    }
                    memory.Position = 0;
                    string ctype = Utility.GetContentType(url);
                    string dname = Path.GetFileName(url);
                    System.IO.File.Delete(url);
                    return File(memory, ctype, dname);
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
            /*string id1 = funcion.Encriptar("a.chaires@softdepot.mx");
            string id0 = funcion.Encriptar("softdepot12.");
            string id2 = funcion.Encriptar("smtp.gmail.com");
            var admin = Administracion.Get();*/
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
                var permisos = AccesoVistas.GetFromUsuario(ul.id);
                var acceso = AccesoVistas.TieneAcceso(permisos, "Index", "CONTRATOS", "GENERAL");
                acceso.flag = true;
                if (acceso.flag != false)
                {
                    if (ul.roles.id == "e4aacdfd-3425-42de-9ac5-7e0bcdf177c3" || ul.roles.id == "4c8ed3da-531b-4e4d-8b0f-2fb89e09119d")
                    {
                        return Redirect(Utility.hosturl + "PI/Index");
                    }
                    var usuarios = AspNetUsers.GetByRol("e9d0046c-3c62-4e91-81d5-8c8bc2a5c16b");
                    var estatus = EstatusValidacion.Get(1);
                    var indicadores = Indicadores.Get(ul.id, DateTime.Now.AddDays(-60).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));

                    ViewBag.pagina = pagina;
                    ViewBag.ul = ul;
                    ViewBag.usuarios = usuarios.OrderBy(i => i.nombre).ToList();
                    ViewBag.estatus = estatus.OrderBy(i => i.nombre).ToList();
                    ViewBag.indicadores = indicadores;
                    return View();
                }
                else
                {
                    //return Redirect(Utility.hosturl + "PI/Index");
                    return Redirect(Utility.hosturl + "Admin/Error?p=Index&m=CONTRATOS");
                }

            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }

        public async Task<ActionResult> Roles()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Roles";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);
                if (ul.roles.id == "8566d71d-72f0-489d-92d4-410804d82e60")
                {
                    ViewBag.pagina = pagina;
                    ViewBag.ul = ul;
                    return View();
                }
                else
                {
                    return Redirect(Utility.hosturl + "Admin/Index");
                }
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
                if (ul.roles.id == "8566d71d-72f0-489d-92d4-410804d82e60")
                {
                    var roles = AspNetRoles.GetAll("");

                    var negocios = Negocio.Get();

                    ViewBag.pagina = pagina;
                    ViewBag.ul = ul;
                    ViewBag.roles = roles;
                    ViewBag.negocios = negocios;
                    return View();
                }
                else
                {
                    return Redirect(Utility.hosturl + "Admin/Index");
                }
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }

        public async Task<ActionResult> Contratos()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Contratos";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);

                var usuarios = AspNetUsers.Get();
                var abogados = AspNetUsers.GetByRol("e9d0046c-3c62-4e91-81d5-8c8bc2a5c16b");
                var estatus = EstatusValidacion.Get(1);
                var negocios = Negocio.Get(1);
                var folios = GISMVC.Models.Contrato.GetFolios(ul.id);//TipoContrato.Get();
                var rfc = GISMVC.Models.Contrato.GetRFCs(ul.id); ;//TipoContrato.Get();
                var contraparte = GISMVC.Models.Contrato.GetContrapartes(ul.id);//TipoContrato.Get();
                var tipoContrato = TipoContrato.Get();

                string filtrado = "00";
                if (!String.IsNullOrEmpty(HttpContext.Request.Params["filtrado"]))
                {
                    filtrado = HttpContext.Request.Params["filtrado"];
                }
                ViewBag.filtrado = filtrado;
                ViewBag.pagina = pagina;
                ViewBag.ul = ul;
                ViewBag.usuarios = usuarios.OrderBy(i => i.nombre).ToList();
                ViewBag.abogados = abogados.OrderBy(i => i.nombre).ToList();
                ViewBag.estatus = estatus.OrderBy(i => i.nombre).ToList();
                ViewBag.negocios = negocios.OrderBy(i => i.nombre).ToList();
                ViewBag.folios = folios.OrderBy(i => i).ToList();
                ViewBag.tipoContrato = tipoContrato.OrderBy(i => i.nombre).ToList();
                ViewBag.rfc = rfc.OrderBy(i => i).ToList();
                ViewBag.contraparte = contraparte.OrderBy(i => i).ToList();
                return View();
            }
            else
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }
        }

        [Route("Admin/Contrato")]
        [HttpGet]
        public async Task<ActionResult> Contrato()
        {
            var admin = Administracion.Get();
            //
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                int id = 0;
                if(Request.QueryString["id"] == "" || Request.QueryString["id"] == null)
                {
                    id = 0;
                }
                else
                {
                    string dc = Utility.descifrar(Request.QueryString["id"].ToString());
                    Int32.TryParse(dc, out id);
                }
                CTMSEO pagina = new CTMSEO();
                pagina.nombre = "Contrato";

                var ul = new AspNetUsers();
                ul = AspNetUsers.GetByName(HttpContext.User.Identity.Name);
                var roles = AspNetRoles.GetAll("");

                var contrato = GISMVC.Models.Contrato.GetById(id);
                if(contrato.id > 0)
                {
                    RegistroActividad actividad = new RegistroActividad();
                    actividad.usuario.id = ul.id;
                    actividad.titulo = "CONTRATO";
                    actividad.descripcion = "El usuario " + ul.nombre + " ingreso a ver los datos del contrato";
                    actividad.contrato = contrato.id;
                    actividad.Crear();
                }
                var colaboradores = ColaboradorContrato.GetFromId(contrato.id);

                var esColaborador = new ColaboradorContrato();
                if(colaboradores.Where(i=> i.usuario.id == ul.id).Count() > 0)
                {
                    esColaborador = colaboradores.Where(i => i.usuario.id == ul.id).First();
                }
                var pendienteValidar = 0;
                var aprobadosValidar = 0;
                pendienteValidar = colaboradores.Count - colaboradores.Where(i => i.aprobado > 0).Count();
                aprobadosValidar = colaboradores.Where(i => i.aprobado == 1).Count();

                var abogado = AspNetUsers.GetByRol("e9d0046c-3c62-4e91-81d5-8c8bc2a5c16b");
                var usuarios = AspNetUsers.Get();
                var negocio = Negocio.Get(1);
                var moneda = Moneda.Get();
                var tipo_contrato = TipoContrato.Get();

                var documentosTipo = DocumentoContrato.GetFromIdDesgloseTipoArchivo(new List<DocumentoContrato>());
                ViewBag.documentosTipo = documentosTipo;

                ViewBag.mainid = id;
                ViewBag.pagina = pagina;
                ViewBag.ul = ul;
                ViewBag.roles = roles;
                ViewBag.contrato = contrato;
                ViewBag.abogado = abogado.OrderBy(i => i.nombre).ToList();
                ViewBag.usuarios = usuarios.OrderBy(i => i.nombre).ToList();
                ViewBag.negocio = negocio.OrderBy(i => i.nombre).ToList();
                ViewBag.moneda = moneda.OrderBy(i => i.nombre).ToList();
                ViewBag.tipo_contrato = tipo_contrato.OrderBy(i => i.nombre).ToList();
                ViewBag.esColaborador = esColaborador;
                ViewBag.pendienteValidar = pendienteValidar;
                ViewBag.aprobadosValidar = aprobadosValidar;
                ViewBag.colaboradores = colaboradores;
                return View();
            }
            else
            {
                string return_url = Utility.hosturl + "Account/Login?return_url=Admin/Contrato?" + Request.QueryString.ToString();
                return Redirect(return_url);
            }
        }
    }
}