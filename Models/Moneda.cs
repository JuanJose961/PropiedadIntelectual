﻿using Microsoft.AspNet.Identity.EntityFramework;
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
    public class Moneda
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fc { get; set; }
        public DateTime fu { get; set; }
        public int activo { get; set; }
        public string updated_by { get; set; }
        public int orden { get; set; }
        public string clave_sat { get; set; }
        public decimal tipo_cambio { get; set; }

        public Moneda()
        {
            id = 0;
            nombre = "";
            descripcion = "";
            fc = DateTime.Parse("1969-01-01");
            fu = DateTime.Parse("1969-01-01");
            activo = 0;
            updated_by = "";
            orden = 0;
            clave_sat = "";
            tipo_cambio = 0;
        }


        public static Moneda GetById(int id)
        {
            Moneda res = new Moneda();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_MonedaById(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];

                        res.id = Int32.Parse(row[idx].ToString()); idx++;
                        res.nombre = row[idx].ToString(); idx++;
                        res.descripcion = row[idx].ToString(); idx++;
                        res.fc = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fu = DateTime.Parse(row[idx].ToString()); idx++;
                        res.activo = Int32.Parse(row[idx].ToString()); idx++;
                        res.updated_by = row[idx].ToString(); idx++;
                        res.orden = Int32.Parse(row[idx].ToString()); idx++;
                        res.clave_sat = row[idx].ToString(); idx++;
                        res.tipo_cambio = Decimal.Parse(row[idx].ToString()); idx++;
                    }
                }
                else
                {
                    //
                }


            }
            catch (Exception ex)
            {
                res = new Moneda();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
        public static Moneda GetByNombre(string id)
        {
            Moneda res = new Moneda();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_MonedaByNombre(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];

                        res.id = Int32.Parse(row[idx].ToString()); idx++;
                        res.nombre = row[idx].ToString(); idx++;
                        res.descripcion = row[idx].ToString(); idx++;
                        res.fc = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fu = DateTime.Parse(row[idx].ToString()); idx++;
                        res.activo = Int32.Parse(row[idx].ToString()); idx++;
                        res.updated_by = row[idx].ToString(); idx++;
                        res.orden = Int32.Parse(row[idx].ToString()); idx++;
                        res.clave_sat = row[idx].ToString(); idx++;
                        res.tipo_cambio = Decimal.Parse(row[idx].ToString()); idx++;
                    }
                }
                else
                {
                    //
                }


            }
            catch (Exception ex)
            {
                res = new Moneda();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<Moneda> Get(int activo = -1)
        {
            List<Moneda> res = new List<Moneda>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_Moneda(out dt, out errores, activo))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new Moneda();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.nombre = row[idx].ToString(); idx++;
                            item.descripcion = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.activo = Int32.Parse(row[idx].ToString()); idx++;
                            item.updated_by = row[idx].ToString(); idx++;
                            item.orden = Int32.Parse(row[idx].ToString()); idx++;
                            item.clave_sat = row[idx].ToString(); idx++;
                            item.tipo_cambio = Decimal.Parse(row[idx].ToString()); idx++;
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
                res = new List<Moneda>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }


        public static RespuestaFormato Crear(Moneda modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_cat_Moneda(modelo, out dt, out errores))
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

        public static RespuestaFormato Actualizar(Moneda modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_cat_Moneda(modelo, out dt, out errores))
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

        public static RespuestaFormato ActualizarActivo(Moneda modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_cat_Moneda_Activo(modelo, out dt, out errores))
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
