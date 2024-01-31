using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GISMVC.Models
{
    public class RespuestaFormato
    {
        public bool flag { get; set; }
        public string description { get; set; }
        public List<string> errors { get; set; }
        public ArrayList content { get; set; }
        public int data_int { get; set; }
        public string data_string { get; set; }
        public string info { get; set; }
        public decimal data_decimal { get; set; }
        public string data_string1 { get; set; }
        public string data_string2 { get; set; }
        public string data_string3 { get; set; }

        public RespuestaFormato()
        {
            flag = false;
            description = "No se ha ejecutado";
            errors = new List<string>();
            content = new ArrayList();
            data_int = 0;
            info = "";
            data_decimal = 0;
            data_string = "";
            data_string1 = "";
            data_string2 = "";
            data_string3 = "";
        }

        public static RespuestaFormato Get(string attr = "")
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_cat_Administracion(attr, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        res.flag = true;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            res.data_string = row[idx].ToString(); idx++;
                        }
                    }
                    else
                    {
                        res.flag = false;
                    }
                }
                else
                {
                    res.errors.Add(errores);
                }


            }
            catch (Exception ex)
            {
                res.errors.Add(ex.Message);
                res.description = "Ocurrió un error.";
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static RespuestaFormato ActualizarAdministracion(RespuestaFormato modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_cat_Administracion(modelo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        int id = 0;
                        Int32.TryParse(row[3].ToString(), out id);
                        if (id > 0)
                        {
                            res.flag = true;
                            res.data_int = id;
                        }
                    }
                }
                else
                {
                    res.description = "Ocurrió un error.";
                    res.errors.Add(errores);
                }


            }
            catch (Exception ex)
            {
                res.errors.Add(ex.Message);
                res.description = "Ocurrió un error.";
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
    }
}
