using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GISMVC.Models
{
    public class RegistroMarcaComentario
    {
        public int id { get; set; }
        public AspNetUsers usuario { get; set; }
        public DateTime fc { get; set; }
        public DateTime fu { get; set; }
        public int registro_marca { get; set; }
        public int tipo_comentario { get; set; }
        //
        public string descripcion { get; set; }
        public string FC_d { get; set; }
        public string FU_d { get; set; }

        public RegistroMarcaComentario()
        {
            id = 0;
            usuario = new AspNetUsers();
            fc = DateTime.Parse("01-01-1969");
            fu = DateTime.Parse("01-01-1969");
            tipo_comentario = 0;
            registro_marca = 0;
            FC_d = "";
            FU_d = "";
            descripcion = "";
        }

        public static RespuestaFormato Crear(RegistroMarcaComentario modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_RegistroMarcaComentario(modelo, out dt, out errores))
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

        public static RespuestaFormato Eliminar(RegistroMarcaComentario modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.DEL_RegistroMarcaComentario(modelo.id, out dt, out errores))
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
        
        public static RegistroMarcaComentario GetById(int id)
        {
            RegistroMarcaComentario res = new RegistroMarcaComentario();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_RegistroMarcaComentarioById(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];
                        var item = new RegistroMarcaComentario();
                        item.id = Int32.Parse(row[idx].ToString()); idx++;
                        item.usuario.id = row[idx].ToString(); idx++;
                        item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                        item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                        item.registro_marca = Int32.Parse(row[idx].ToString()); idx++;
                        item.descripcion = row[idx].ToString(); idx++;
                        item.tipo_comentario = Int32.Parse(row[idx].ToString()); idx++;
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
                res = new RegistroMarcaComentario();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
        
        public static List<RegistroMarcaComentario> GetFromId(int id = 0)
        {
            List<RegistroMarcaComentario> res = new List<RegistroMarcaComentario>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_RegistroMarcaComentarioFromId(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new RegistroMarcaComentario();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.registro_marca = Int32.Parse(row[idx].ToString()); idx++;
                            item.descripcion = row[idx].ToString(); idx++;
                            item.tipo_comentario = Int32.Parse(row[idx].ToString()); idx++;
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
                res = new List<RegistroMarcaComentario>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
    }
}