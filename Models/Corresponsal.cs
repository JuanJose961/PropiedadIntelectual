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
    public class Corresponsal
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string abogado { get; set; }
        public string abogado_nombre { get; set; }
        public string abogado_email { get; set; }
        public DateTime fc { get; set; }
        public DateTime fu { get; set; }
        public int activo { get; set; }
        public int orden { get; set; }
        public string usuario { get; set; } = "";
        public string usuario_nombre { get; set; } = "";
        public Corresponsal()
        {
            id = 0;
            nombre = "";
            telefono = "";
            email = "";
            abogado = "";
            abogado_nombre = "";
            abogado_email = "";
            fc = DateTime.Parse("1969-01-01");
            fu = DateTime.Parse("1969-01-01");
            activo = 0;
            orden = 0;
            usuario = "";
            usuario_nombre = "";
        }


        public static Corresponsal GetById(int id)
        {
            Corresponsal res = new Corresponsal();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_CorresponsalById(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];

                        res.id = Int32.Parse(row[idx].ToString()); idx++;
                        res.nombre = row[idx].ToString(); idx++;
                        res.telefono = row[idx].ToString(); idx++;
                        res.email = row[idx].ToString(); idx++;
                        res.abogado = row[idx].ToString(); idx++;
                        res.abogado_nombre = row[idx].ToString(); idx++;
                        res.abogado_email = row[idx].ToString(); idx++;
                        res.fc = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fu = DateTime.Parse(row[idx].ToString()); idx++;
                        res.activo = Int32.Parse(row[idx].ToString()); idx++;
                        res.orden = Int32.Parse(row[idx].ToString()); idx++;
                    }
                }
                else
                {
                    //
                }


            }
            catch (Exception ex)
            {
                res = new Corresponsal();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
        public static List<Corresponsal> Get(int activo = -1)
        {
            List<Corresponsal> res = new List<Corresponsal>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_Corresponsal(out dt, out errores, activo))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new Corresponsal();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.nombre = row[idx].ToString(); idx++;
                            item.telefono = row[idx].ToString(); idx++;
                            item.email = row[idx].ToString(); idx++;
                            item.abogado = row[idx].ToString(); idx++;
                            item.abogado_nombre = row[idx].ToString(); idx++;
                            item.abogado_email = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.activo = Int32.Parse(row[idx].ToString()); idx++;
                            item.orden = Int32.Parse(row[idx].ToString()); idx++;
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
                res = new List<Corresponsal>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }


        public static RespuestaFormato Crear(Corresponsal modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_Corresponsal(modelo, out dt, out errores))
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

        public static RespuestaFormato Actualizar(Corresponsal modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_Corresponsal(modelo, out dt, out errores))
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

        public static RespuestaFormato ActualizarActivo(Corresponsal modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_Corresponsal_Activo(modelo, out dt, out errores))
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
