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
    public class AdministracionController : Controller
    {
        public Funciones funcion = new Funciones();


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
                var permisos = AccesoVistas.GetFromUsuario(ul.id);
                var acceso = AccesoVistas.TieneAcceso(permisos, "Usuarios", "ADMINISTRACION", "GENERAL");
                if (acceso.flag != false)
                {
                    var roles = AspNetRoles.GetAll("PI");

                    var negocios = GISMVC.Models.Negocio.Get();
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
                var permisos = AccesoVistas.GetFromUsuario(ul.id);
                var acceso = AccesoVistas.TieneAcceso(permisos, "Roles", "ADMINISTRACION", "GENERAL");
                if (acceso.flag != false)
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
    }
}