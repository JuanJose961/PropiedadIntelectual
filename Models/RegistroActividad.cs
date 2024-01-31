using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GISMVC.Models
{
    public class RegistroActividad
    {
        public int id { get; set; }
        public AspNetUsers usuario { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public DateTime fc { get; set; }
        public DateTime fu { get; set; }
        public string aux_str { get; set; }
        public int aux_int { get; set; }
        public decimal aux_decimal { get; set; }
        public int contrato { get; set; }
        //

        public RegistroActividad()
        {
            id = 0;
            usuario = new AspNetUsers();
            titulo = "";
            descripcion = "";
            aux_int = 0;
            aux_str = "";
            aux_decimal = 0;
            fc = DateTime.Parse("01-01-1969");
            fu = DateTime.Parse("01-01-1969");
            contrato = 0;
        }

        public RespuestaFormato Crear()
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_RegistroActividad(this, out dt, out errores))
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
                    //
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

        public static List<RegistroActividad> GetFromId(int id = 0)
        {
            List<RegistroActividad> res = new List<RegistroActividad>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_RegistroActividadFromId(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new RegistroActividad();

                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            item.usuario.nombre = row[idx].ToString(); idx++;
                            item.titulo = row[idx].ToString(); idx++;
                            item.descripcion = row[idx].ToString(); idx++;
                            item.aux_str = row[idx].ToString(); idx++;
                            item.aux_int = Int32.Parse(row[idx].ToString()); idx++;
                            item.aux_decimal = Decimal.Parse(row[idx].ToString()); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.contrato = Int32.Parse(row[idx].ToString()); idx++;
                            res.Add(item);
                        }
                    }
                }
                else
                {
                    //
                }


            }
            catch (Exception ex)
            {
                res = new List<RegistroActividad>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
    }
}