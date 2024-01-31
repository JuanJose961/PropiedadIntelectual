using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace GISMVC.Models
{
    public class CambioEstatusValidacion
    {
        public int id { get; set; } = 0;
        public int estatus_anterior { get; set; } = 0;
        public int estatus_nuevo { get; set; } = 0;
        public int contrato { get; set; } = 0;
        public string estatus_anterior_desc { get; set; } = "";
        public string estatus_nuevo_desc { get; set; } = "";
        public DateTime fc { get; set; } = DateTime.Parse("1969-01-01");
        public DateTime fu { get; set; } = DateTime.Parse("1969-01-01");
        public int activo { get; set; } = 0;
        public int dias { get; set; } = 0;
        public int devolucion { get; set; } = 0;
        public string usuario { get; set; } = "";
        public string usuario_nombre { get; set; } = "";

        public RespuestaFormato Crear()
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_proc_CambioEstatusValidacion(this, out dt, out errores))
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
