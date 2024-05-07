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
    public class Marca
    {
        public int id { get; set; }
        public int empresa { get; set; }
        public string nombre { get; set; }
        public int tipo { get; set; }
        public int pais { get; set; }
        public string productos { get; set; }
        public DateTime fecha_uso { get; set; }
        public int activo { get; set; }
        public int orden { get; set; }
        public DateTime fc { get; set; }
        public DateTime fu { get; set; }
        public string usuario { get; set; }
        public string empresa_nombre { get; set; }
        public string tipo_nombre { get; set; }
        public string pais_nombre { get; set; }
        public string identificador { get; set; }
        public string fecha_usoS { get; set; }
        public string usuario_nombre { get; set; } = "";
        public int tipo_solicitud { get; set; }
        public string tipo_solicitud_nombre { get; set; }
        public int atendido { get; set; }
        public List<Archivo> anexos { get; set; }

        public Marca()
        {
            id = 0;
            empresa = 0;
            nombre = "";
            tipo = 0;
            pais = 0;
            productos = "";
            fecha_uso = DateTime.Parse("1969-01-01");
            activo = 0;
            orden = 0;
            fc = DateTime.Parse("1969-01-01");
            fu = DateTime.Parse("1969-01-01");
            usuario = "";
            empresa_nombre = "";
            tipo_nombre = "";
            pais_nombre = "";
            identificador = "";
            fecha_usoS = "";
            tipo_solicitud = 0;
            tipo_solicitud_nombre = "";
            atendido = 0;
            anexos = new List<Archivo>();
        }

        public static Marca GetById(int id)
        {
            Marca res = new Marca();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_proc_MarcaById(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];

                        res.id = Int32.Parse(row[idx].ToString()); idx++;
                        res.empresa = Int32.Parse(row[idx].ToString()); idx++;
                        res.nombre = row[idx].ToString(); idx++;
                        res.tipo = Int32.Parse(row[idx].ToString()); idx++;
                        res.pais = Int32.Parse(row[idx].ToString()); idx++;
                        res.productos = row[idx].ToString(); idx++;
                        res.fecha_uso = DateTime.Parse(row[idx].ToString()); idx++;
                        res.activo = Int32.Parse(row[idx].ToString()); idx++;
                        res.orden = Int32.Parse(row[idx].ToString()); idx++;
                        res.fc = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fu = DateTime.Parse(row[idx].ToString()); idx++;
                        res.usuario = row[idx].ToString(); idx++;
                        res.empresa_nombre = row[idx].ToString(); idx++;
                        res.tipo_nombre = row[idx].ToString(); idx++;
                        res.pais_nombre = row[idx].ToString(); idx++;
                        res.identificador = row[idx].ToString(); idx++;


                        if(res.fecha_uso.Year != 1969)
                        {
                            res.fecha_usoS = res.fecha_uso.ToString("dd/MM/yyyy");
                        }

                        res.anexos = RLArchivo.GetFromMarca(res.id, "");
                        //res.fecha_usoS = row[idx].ToString(); idx++;
                    }
                }
                else
                {
                    //
                }


            }
            catch (Exception ex)
            {
                res = new Marca();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<Marca> Get(int activo = -1)
        {
            List<Marca> res = new List<Marca>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_proc_Marca(out dt, out errores, activo))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new Marca();

                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.empresa = Int32.Parse(row[idx].ToString()); idx++;
                            item.nombre = row[idx].ToString(); idx++;
                            item.tipo = Int32.Parse(row[idx].ToString()); idx++;
                            item.pais = Int32.Parse(row[idx].ToString()); idx++;
                            item.productos = row[idx].ToString(); idx++;
                            item.fecha_uso = DateTime.Parse(row[idx].ToString()); idx++;
                            item.activo = Int32.Parse(row[idx].ToString()); idx++;
                            item.orden = Int32.Parse(row[idx].ToString()); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.usuario = row[idx].ToString(); idx++;
                            item.empresa_nombre = row[idx].ToString(); idx++;
                            item.tipo_nombre = row[idx].ToString(); idx++;
                            item.pais_nombre = row[idx].ToString(); idx++;
                            item.identificador = row[idx].ToString(); idx++;
                            //item.fecha_usoS = row[idx].ToString(); idx++;
                            item.tipo_solicitud = Int32.Parse(row[idx].ToString()); idx++;
                            item.tipo_solicitud_nombre = row[idx].ToString(); idx++;
                            item.atendido = Int32.Parse(row[idx].ToString()); idx++;

                            if (item.fecha_uso.Year != 1969)
                            {
                                item.fecha_usoS = item.fecha_uso.ToString("dd/MM/yyyy");
                            }
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
                res = new List<Marca>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static RespuestaFormato Crear(Marca modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_proc_Marca(modelo, out dt, out errores))
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

        public static RespuestaFormato Actualizar(Marca modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_proc_Marca(modelo, out dt, out errores))
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

        public static RespuestaFormato ActualizarActivo(Marca modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_proc_Marca_Activo(modelo, out dt, out errores))
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
