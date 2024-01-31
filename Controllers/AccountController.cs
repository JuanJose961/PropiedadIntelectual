using GISMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GISMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            dll_Gis.Funciones fn = new dll_Gis.Funciones();
            string pass = fn.Encriptar("Data Source =LAPTOP-4AN23J2H\\SQLEXPRESS; Initial Catalog = GIS_PortalJ_PI; User ID = alexchg; Password=lmad2014;MultipleActiveResultSets=true;");
            return View();
        }
        // GET: Account
        public ActionResult Login()
        {
            string return_url = "";
            if (Request.QueryString["return_url"] == "" || Request.QueryString["return_url"] == null)
            {
                return_url = "";
            }
            else
            {
                return_url = Request.QueryString["return_url"].ToString();
            }
            CTMSEO pagina = new CTMSEO();
            pagina.nombre = "Login";
            ViewBag.pagina = pagina;
            //
            ViewBag.texto_IniciarSesion = "Iniciar Sesión";
            ViewBag.texto_BotonIniciarSesion = "Iniciar sesión";
            ViewBag.texto_Contrasena = "Contraseña";
            ViewBag.texto_Olvidaste = "¿Olvidaste tu contraseña?";
            ViewBag.return_url = return_url;
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Logoutv3()
        {
            AuthHelper.SignOut(); // DXCOMMENT: Your Signing out logic

            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            //Response.Redirect("~/Account/SignIn.aspx");

            string urlMain = Utility.hosturl;// HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.ToUriComponent();
            return Redirect(urlMain);
        }
    }
}