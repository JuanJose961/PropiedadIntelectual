using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GISMVC.Models
{
    public class FechasFormato
    {
        public string raw { get; set; }
        public string mmddyyyy { get; set; }
        public string ddmmyyyy { get; set; }
        public string yyyymmdd { get; set; }
        public string mmddyyyy2 { get; set; }
        public string ddmmyyyy2 { get; set; }
        public string yyyymmdd2 { get; set; }
        public string day { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public string error { get; set; }
        public string hhmm_tt { get; set; }
        public string hmm_tt { get; set; }
        public string hhmmss { get; set; }
        public int week_number { get; set; }
        public int month_number { get; set; }
        public string day_name { get; set; }
        public string month_name { get; set; }
        public List<string> errores { get; set; }
        public string custom1 { get; set; }
        public string custom2 { get; set; }

        public FechasFormato()
        {
            raw = "";
            mmddyyyy = "";
            ddmmyyyy = "";
            yyyymmdd = "";
            mmddyyyy2 = "";
            ddmmyyyy2 = "";
            yyyymmdd2 = "";
            day = "";
            month = "";
            year = "";
            error = "";
            hhmm_tt = "";
            hmm_tt = "";
            hhmmss = "";
            week_number = 0;
            month_number = 0;
            custom1 = "";
            custom2 = "";
            errores = new List<string>();
    }

        public static FechasFormato GetFormatos(string fecha)
        {
            FechasFormato f = new FechasFormato();
            CultureInfo ci = new CultureInfo(CultureInfo.CurrentCulture.ToString());
            CultureInfo ces = new CultureInfo("es-ES");
            try
            {
                f.raw = fecha;
                DateTime dt = DateTime.Parse(fecha);
                ci.DateTimeFormat.GetMonthName(dt.Month);
                f.mmddyyyy = dt.ToString("MM/dd/yyyy");
                f.ddmmyyyy = dt.ToString("dd/MM/yyyy");
                f.yyyymmdd = dt.ToString("yyyy/MM/dd");
                f.mmddyyyy2 = dt.ToString("MM-dd-yyyy");
                f.ddmmyyyy2 = dt.ToString("dd-MM-yyyy");
                f.yyyymmdd2 = dt.ToString("yyyy-MM-dd");
                f.month = ces.DateTimeFormat.GetMonthName(dt.Month);
                f.year = dt.Year.ToString();
                f.day = dt.Day.ToString("D2");
                f.hhmm_tt = dt.ToString("HH:mm tt");
                f.hmm_tt = dt.ToString("H:mm tt");
                f.hhmmss = dt.ToString("HH:mm:ss");
                f.week_number = (int)(dt.DayOfYear / 7);
                f.month_number = dt.Month;
                f.month_name = UpperCaseFirst(ces.DateTimeFormat.GetMonthName(dt.Month));
                f.day_name = UpperCaseFirst(ces.DateTimeFormat.GetDayName(dt.DayOfWeek));
                f.custom1 = f.day + "/" + f.month_name + "/" + f.year;
                f.custom2 = f.day + " de " + f.month_name + " de " + f.year;

            }
            catch (Exception ex)
            {
                f.error = ex.Message;
            }

            return f;
        }

        public static string UpperCaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            return char.ToUpper(s[0]) + s.Substring(1);
        } 

        public static FechasFormato GetFormatosByFormat(string fecha, string format)
        {
            FechasFormato f = new FechasFormato();
            CultureInfo ci = new CultureInfo(CultureInfo.CurrentCulture.ToString());
            try
            {
                f.raw = fecha;
                DateTime dt = DateTime.ParseExact(fecha,format,CultureInfo.InvariantCulture);
                ci.DateTimeFormat.GetMonthName(dt.Month);
                f.mmddyyyy = dt.ToString("MM/dd/yyyy");
                f.ddmmyyyy = dt.ToString("dd/MM/yyyy");
                f.yyyymmdd = dt.ToString("yyyy/MM/dd");
                f.mmddyyyy2 = dt.ToString("MM-dd-yyyy");
                f.ddmmyyyy2 = dt.ToString("dd-MM-yyyy");
                f.yyyymmdd2 = dt.ToString("yyyy-MM-dd");
                f.month = ci.DateTimeFormat.GetMonthName(dt.Month);
                f.year = dt.Year.ToString();
                f.day = dt.Day.ToString("D2");
                f.hhmm_tt = dt.ToString("HH:mm tt");
                f.hmm_tt = dt.ToString("H:mm tt");
                f.hhmmss = dt.ToString("HH:mm:ss");
                f.week_number = (int)(dt.DayOfYear / 7);
                f.month_number = dt.Month;
            }
            catch (Exception ex)
            {
                f.error = ex.Message;
            }

            return f;
        }

        public static List<DateTime> GetFechas(DateTime fi, DateTime ff)
        {
            List<DateTime> list = new List<DateTime>();

            try
            {
                list.Add(fi);
                while(fi < ff)
                {
                    fi = fi.AddDays(1);
                    list.Add(fi);
                }
            }
            catch (Exception ex)
            {
                //
            }
            finally
            {
            }

            return list;
        }

    }
}
