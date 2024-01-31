using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GISMVC.Models
{
    public class RecordatorioContrato
    {
        public int id { get; set; }
        public AspNetUsers autor { get; set; }
        public AspNetUsers usuario { get; set; }
        public AspNetUsers asignado { get; set; }
        public DateTime fc { get; set; }
        public DateTime fu { get; set; }
        public int contrato { get; set; }
        //
        public string descripcion { get; set; }
        public string FC_d { get; set; }
        public string FU_d { get; set; }
        public DateTime fecha_recordatorio { get; set; }
        public string FR_d { get; set; }
        public int colaborador { get; set; }

        public RecordatorioContrato()
        {
            id = 0;
            usuario = new AspNetUsers();
            asignado = new AspNetUsers();
            fc = DateTime.Parse("01-01-1969");
            fu = DateTime.Parse("01-01-1969");
            fecha_recordatorio = DateTime.Parse("01-01-1969");
            FR_d = "";
            contrato = 0;
            FC_d = "";
            FU_d = "";
            descripcion = "";
            colaborador = 0;
        }

        public static RespuestaFormato Crear(RecordatorioContrato modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_RecordatorioContrato(modelo, out dt, out errores))
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

        public static RespuestaFormato Eliminar(RecordatorioContrato modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.DEL_RecordatorioContrato(modelo.id, out dt, out errores))
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

        public static RecordatorioContrato GetById(int id)
        {
            RecordatorioContrato res = new RecordatorioContrato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_RecordatorioContratoById(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];
                        var item = new RecordatorioContrato();
                        item.id = Int32.Parse(row[idx].ToString()); idx++;
                        item.usuario.id = row[idx].ToString(); idx++;
                        item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                        item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                        item.contrato = Int32.Parse(row[idx].ToString()); idx++;
                        item.descripcion = row[idx].ToString(); idx++;
                        item.usuario.nombre = row[idx].ToString(); idx++;
                        item.fecha_recordatorio = DateTime.Parse(row[idx].ToString()); idx++;
                        item.asignado.nombre = row[idx].ToString(); idx++;
                        item.asignado.nombre = row[idx].ToString(); idx++;
                        var fecha_c = FechasFormato.GetFormatos(item.fc.ToString("yyyy-MM-dd"));
                        item.FC_d = fecha_c.month_name + " " + fecha_c.day.ToString() + ", " + fecha_c.year.ToString();
                        var fecha_r = FechasFormato.GetFormatos(item.fecha_recordatorio.ToString("yyyy-MM-dd"));
                        item.FR_d = fecha_r.month_name + " " + fecha_r.day.ToString() + ", " + fecha_r.year.ToString();
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
                res = new RecordatorioContrato();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<RecordatorioContrato> GetFromId(int id = 0)
        {
            List<RecordatorioContrato> res = new List<RecordatorioContrato>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_RecordatorioContratoFromId(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new RecordatorioContrato();

                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.contrato = Int32.Parse(row[idx].ToString()); idx++;
                            item.descripcion = row[idx].ToString(); idx++;
                            item.usuario.nombre = row[idx].ToString(); idx++;
                            item.fecha_recordatorio = DateTime.Parse(row[idx].ToString()); idx++;
                            item.asignado.nombre = row[idx].ToString(); idx++;
                            item.asignado.nombre = row[idx].ToString(); idx++;
                            var fecha_c = FechasFormato.GetFormatos(item.fc.ToString("yyyy-MM-dd"));
                            item.FC_d = fecha_c.month_name + " " + fecha_c.day.ToString() + ", " + fecha_c.year.ToString();
                            var fecha_r = FechasFormato.GetFormatos(item.fecha_recordatorio.ToString("yyyy-MM-dd"));
                            item.FR_d = fecha_r.month_name + " " + fecha_r.day.ToString() + ", " + fecha_r.year.ToString();
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
                res = new List<RecordatorioContrato>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
    }
}