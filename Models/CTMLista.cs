using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GISMVC.Models
{
    public class CTMLista
    {
        public List<object> arrayList { set; get; }
        public int rows { get; set; }
        public List<string> errors { get; set; }

        public CTMLista()
        {
            rows = 0;
            errors = new List<string>();
            arrayList = new List<object>();
        }
    }

    public class SD_SQLData
    {
        public string value { set; get; }
        public string name { get; set; }
        public string type { get; set; }

        public SD_SQLData()
        {
            value = "";
            name = "";
            type = "";
        }
    }

    public class Autocompletar
    {
        public string value { set; get; }
        public string id { get; set; }
        public string label { get; set; }
        public string name { get; set; }

        public Autocompletar()
        {
            value = "";
            id = "";
            label = "";
            name = "";
        }
    }
}
