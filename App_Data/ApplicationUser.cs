using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GISMVC.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Names { get; internal set; }
        public string Cellphone { get; internal set; }
        public string Puesto { get; internal set; }
        //public int Recepcion { get; internal set; }
        //public decimal Rating { get; internal set; }
        //public string Direccion { get; internal set; }
        //public string Direccion2 { get; internal set; }
        //public string Direccion3 { get; internal set; }
        //public string Direccion4 { get; internal set; }
        public string Imagen { get; internal set; }
        //public string Distribuidor { get; internal set; }
        //public string Terminos { get; internal set; }
        public string Notas { get; internal set; }
        //public string FormatoMail { get; internal set; }
        public string GisPassword { get; internal set; }
        public string Usuario { get; internal set; }
        public string UsuarioNombre { get; internal set; }
        //public int VendorId { get; internal set; }
    }

}
