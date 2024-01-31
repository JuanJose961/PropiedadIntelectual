using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GISMVC.Models
{
    public class CTMSEO
    {
        public List<object> arrayList { set; get; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string keywords { get; set; }
        public FechasFormato fecha { get; set; }
        public List<string> errors { get; set; }

        public CTMSEO()
        {
            nombre = "Titulo";
            descripcion = "Descripcion";
            keywords = "Keywords";
            errors = new List<string>();
            arrayList = new List<object>();
            fecha = FechasFormato.GetFormatos(DateTime.Now.ToString());
        }
    }
}
