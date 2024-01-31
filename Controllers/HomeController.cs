using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GISMVC.Models;
using GISMVC.Data;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GISMVC.Controllers {
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public HomeController()
        {
        }

        public async Task<ActionResult> Index()
        {

            /*var rolestore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var rolemanager = new RoleManager<IdentityRole>(rolestore);
            var rol = new AspNetRoles();
            await rol.AddRole("SUPER ADMINISTRADOR", rolemanager);
            await rol.AddRole("ADMINISTRADOR", rolemanager);
            await rol.AddRole("USUARIO GIS", rolemanager);
            await rol.AddRole("USUARIO", rolemanager);*/
            /*
            */
            dll_Gis.Funciones fn = new dll_Gis.Funciones();
            //string dbnueva = "";
            //dbnueva = fn.Encriptar("Data Source =LAPTOP-4AN23J2H\\SQLEXPRESS; Initial Catalog = GIS_PortalJ; User ID = alexchg; Password=lmad2014;MultipleActiveResultSets=true;");

            //var connstr = "Server=SRGISMTY2-0726;Database=GIS_PortalJ;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=steven.manllo;pwd=AcSoft$2058";
            //var enc = fn.Encriptar(connstr);

            /*
            var a = fn.Desencriptar("3OzZf/CQ8KBtiS4yRYMmGey2M1Efvkb0NK+sDK1+gk4=");
            var b = fn.Desencriptar("aU4wR0Tzi94lfXQJOMNImojGYsv+8Nv0chTnyX0VzIU=");*/
            return Redirect(Utility.hosturl + "Admin");
            /*var a = User.Identity.IsAuthenticated;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect(Utility.hosturl + "Account/Login");
            }*/
                /**/
                return View();
        }

    }
}