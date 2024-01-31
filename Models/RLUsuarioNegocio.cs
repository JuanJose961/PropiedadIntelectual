using GISMVC.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GISMVC.Models
{
    public class proc_RLUsuarioNegocio
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string descripcion { get; set; }
        public int negocio { get; set; }
        public DateTime fc { get; set; }
        public DateTime fu { get; set; }
        public int activo { get; set; }
        public proc_RLUsuarioNegocio()
        {
            id = 0;
            usuario = "";
            descripcion = "";
            negocio = 0;
            fc = DateTime.Parse("1969-01-01");
            fu = DateTime.Parse("1969-01-01");
            activo = 0;
        }


        public static RespuestaFormato Actualizar(proc_RLUsuarioNegocio modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_proc_RLUsuarioNegocio(modelo, out dt, out errores))
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


    public class proc_AccesoUsuarioNegocio
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string descripcion { get; set; }
        public int negocio { get; set; }
        public DateTime fc { get; set; }
        public DateTime fu { get; set; }
        public int activo { get; set; }
        public proc_AccesoUsuarioNegocio()
        {
            id = 0;
            usuario = "";
            descripcion = "";
            negocio = 0;
            fc = DateTime.Parse("1969-01-01");
            fu = DateTime.Parse("1969-01-01");
            activo = 0;
        }


        public static RespuestaFormato Actualizar(string usuario = "", int negocio = 0, int acceso = 0)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_proc_AccesoUsuarioNegocio(usuario, negocio, acceso, out dt, out errores))
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

        public static List<proc_AccesoUsuarioNegocio> GetFromUsuario(string id = "")
        {
            List<proc_AccesoUsuarioNegocio> res = new List<proc_AccesoUsuarioNegocio>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_proc_AccesoUsuarioNegocioFromUsuario(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int paginax = 0;
                            var row = dt.Rows[i];
                            var item = new proc_AccesoUsuarioNegocio();
                            item.id = Int32.Parse(row[paginax].ToString()); paginax++;
                            item.usuario = row[paginax].ToString(); paginax++;
                            item.descripcion = row[paginax].ToString(); paginax++;
                            item.negocio = Int32.Parse(row[paginax].ToString()); paginax++;
                            item.activo = Int32.Parse(row[paginax].ToString()); paginax++;
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
                res = new List<proc_AccesoUsuarioNegocio>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
    }
}