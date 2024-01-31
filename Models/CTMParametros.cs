using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GISMVC.Models
{
    public class CTMParametros
    {
        public bool v_bool { get; set; }
        public int v_int { get; set; }
        public decimal v_decimal { get; set; }
        public string v_string { get; set; }
        public string v_string2 { get; set; }
        public List<bool> v_bool_l { get; set; }
        public List<int> v_int_l { get; set; }
        public List<decimal> v_decimal_l { get; set; }
        public List<string> v_string_l { get; set; }
        public List<string> v_string_l2 { get; set; }

        public CTMParametros()
        {
            v_bool = false;
            v_int = 0;
            v_decimal = 0;
            v_string = "";
            v_string2 = "";
            v_bool_l = new List<bool>();
            v_int_l = new List<int>();
            v_decimal_l = new List<decimal>();
            v_string_l = new List<string>();
            v_string_l2 = new List<string>();
        }
    }
}
