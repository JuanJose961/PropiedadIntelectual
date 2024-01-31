using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GISMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public static dll_Gis.Funciones fn = new dll_Gis.Funciones();
        public static string nameOrConnstring = fn.Desencriptar(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        //public static string nameOrConnstring2 = "Data Source =LAPTOP-4AN23J2H\\SQLEXPRESS; Initial Catalog = db_TemplateTest; User ID = alexchg; Password=lmad2014;MultipleActiveResultSets=true;";

        public ApplicationDbContext()
            : base(nameOrConnstring)
        {

        }
        public ApplicationDbContext(string str = "")
            : base("DefaultConnection")
        {

        }

    }
}
