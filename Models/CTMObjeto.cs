using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GISMVC.Models
{

    public class CTMObjeto
    {
        public int id { get; set; }
        public string descripcion { set; get; }
        public List<string> errors { get; set; }

        public CTMObjeto()
        {
            id = 0;
            descripcion = "";
            errors = new List<string>();
        }
    }
}
