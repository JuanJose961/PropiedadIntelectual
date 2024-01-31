using GISMVC.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GISMVC.Models
{
    public class AuthHelper
    {
        public static bool SignIn(ApplicationUser user)
        {
            HttpContext.Current.Session["User"] = user;
            //CreateDefualtUser();  // Mock user data
            return true;
        }
        public static bool SignInV2(UsuarioPortal user)
        {
            HttpContext.Current.Session["User"] = user;
            //CreateDefualtUser();  // Mock user data
            return true;
        }
        public static void SignOut()
        {
            HttpContext.Current.Session["User"] = null;
        }
        public static bool IsAuthenticated()
        {
            return GetLoggedInUserInfo() != null;
        }

        public static ApplicationUser GetLoggedInUserInfo()
        {
            return HttpContext.Current.Session["User"] as ApplicationUser;
        }
        public static UsuarioPortal GetLoggedInUserInfoV2()
        {
            return HttpContext.Current.Session["User"] as UsuarioPortal;
        }
        private static ApplicationUser CreateDefualtUser()
        {
            return new ApplicationUser
            {
                UserName = "JBell",
                Names = "Julia",
                Email = "julia.bell@example.com",
                Imagen = "~/Content/Photo/Julia_Bell.jpg"
            };
        }
    }
}