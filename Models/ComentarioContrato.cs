using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GISMVC.Models
{

    public class ComentarioContrato
    {
        public int id { get; set; }
        public AspNetUsers usuario { get; set; }
        public DateTime fc { get; set; }
        public DateTime fu { get; set; }
        public int contrato { get; set; }
        //
        public string descripcion { get; set; }
        public string FC_d { get; set; }
        public string FU_d { get; set; }

        public ComentarioContrato()
        {
            id = 0;
            usuario = new AspNetUsers();
            fc = DateTime.Parse("01-01-1969");
            fu = DateTime.Parse("01-01-1969");
            contrato = 0;
            FC_d = "";
            FU_d = "";
            descripcion = "";
        }

        public static RespuestaFormato Crear(ComentarioContrato modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_ComentarioContrato(modelo, out dt, out errores))
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

        public static RespuestaFormato Eliminar(ComentarioContrato modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.DEL_ComentarioContrato(modelo.id, out dt, out errores))
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

        public static ComentarioContrato GetById(int id)
        {
            ComentarioContrato res = new ComentarioContrato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_ComentarioContratoById(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];
                        var item = new ComentarioContrato();
                        item.id = Int32.Parse(row[idx].ToString()); idx++;
                        item.usuario.id = row[idx].ToString(); idx++;
                        item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                        item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                        item.contrato = Int32.Parse(row[idx].ToString()); idx++;
                        item.descripcion = row[idx].ToString(); idx++;
                        item.usuario.nombre = row[idx].ToString(); idx++;
                        var fecha_c = FechasFormato.GetFormatos(item.fc.ToString("yyyy-MM-dd HH:mm tt"));
                        item.FC_d = fecha_c.hmm_tt + " " + fecha_c.month_name + " " + fecha_c.day.ToString() + ", " + fecha_c.year.ToString();
                        res = item;
                    }
                }
                else
                {
                    //
                }


            }
            catch (Exception ex)
            {
                res = new ComentarioContrato();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<ComentarioContrato> GetFromId(int id = 0)
        {
            List<ComentarioContrato> res = new List<ComentarioContrato>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_ComentarioContratoFromId(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new ComentarioContrato();

                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.contrato = Int32.Parse(row[idx].ToString()); idx++;
                            item.descripcion = row[idx].ToString(); idx++;
                            item.usuario.nombre = row[idx].ToString(); idx++;
                            var fecha_c = FechasFormato.GetFormatos(item.fc.ToString("yyyy-MM-dd HH:mm tt"));
                            item.FC_d = fecha_c.hmm_tt + " " + fecha_c.month_name + " " + fecha_c.day.ToString() + ", " + fecha_c.year.ToString();
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
                res = new List<ComentarioContrato>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
    }
}