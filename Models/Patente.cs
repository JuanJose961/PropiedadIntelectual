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
    public class Patente
    {
        public int id { get; set; }
        public int empresa { get; set; }
        public string nombre_patente { get; set; }
        public string nombre { get; set; }
        public int prioridad { get; set; }
        public int pais { get; set; }
        public string explicacion { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public int activo { get; set; }
        public int orden { get; set; }
        public DateTime fc { get; set; }
        public DateTime fu { get; set; }
        public string usuario { get; set; }
        public string empresa_nombre { get; set; }
        public string prioridad_nombre { get; set; }
        public string pais_nombre { get; set; }
        public string identificador { get; set; }
        public string nacionalidad { get; set; }
        public string domicilio { get; set; }
        public string rfc { get; set; }
        public string curp { get; set; }
        public string lugar_nacimiento { get; set; }
        public string fecha_nacimientoS { get; set; }
        public int tipo_solicitud { get; set; }
        public string tipo_solicitud_nombre { get; set; }
        public int aplicado { get; set; }
        public List<Archivo> dibujo { get; set; }
        public List<Archivo> _explicacion { get; set; }

        public Patente()
        {
            id = 0;
            empresa = 0;
            nombre_patente = "";
            nombre = "";
            prioridad = 0;
            pais = 0;
            explicacion = "";
            fecha_nacimiento = DateTime.Parse("1969-01-01");
            activo = 0;
            orden = 0;
            fc = DateTime.Parse("1969-01-01");
            fu = DateTime.Parse("1969-01-01");
            usuario = "";
            empresa_nombre = "";
            prioridad_nombre = "";
            pais_nombre = "";
            identificador = "";
            nacionalidad = "";
            domicilio = "";
            rfc = "";
            curp = "";
            lugar_nacimiento = "";
            fecha_nacimientoS = "";
            tipo_solicitud = 0;
            tipo_solicitud_nombre = "";
            aplicado = 0;
            dibujo = new List<Archivo>();
            _explicacion = new List<Archivo>();
        }


        public static Patente GetById(int id)
        {
            Patente res = new Patente();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_proc_PatenteById(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];

                        res.id = Int32.Parse(row[idx].ToString()); idx++;
                        res.empresa = Int32.Parse(row[idx].ToString()); idx++;
                        res.nombre_patente = row[idx].ToString(); idx++;
                        res.nombre = row[idx].ToString(); idx++;
                        res.prioridad = Int32.Parse(row[idx].ToString()); idx++;
                        res.pais = Int32.Parse(row[idx].ToString()); idx++;
                        res.explicacion = row[idx].ToString(); idx++;
                        res.fecha_nacimiento = DateTime.Parse(row[idx].ToString()); idx++;
                        res.activo = Int32.Parse(row[idx].ToString()); idx++;
                        res.orden = Int32.Parse(row[idx].ToString()); idx++;
                        res.fc = DateTime.Parse(row[idx].ToString()); idx++;
                        res.fu = DateTime.Parse(row[idx].ToString()); idx++;
                        res.usuario = row[idx].ToString(); idx++;
                        res.empresa_nombre = row[idx].ToString(); idx++;
                        res.prioridad_nombre = row[idx].ToString(); idx++;
                        res.pais_nombre = row[idx].ToString(); idx++;
                        res.identificador = row[idx].ToString(); idx++;
                        res.nacionalidad = row[idx].ToString(); idx++;
                        res.domicilio = row[idx].ToString(); idx++;
                        res.rfc = row[idx].ToString(); idx++;
                        res.curp = row[idx].ToString(); idx++;
                        res.lugar_nacimiento = row[idx].ToString(); idx++;

                        if (res.fecha_nacimiento.Year != 1969)
                        {
                            res.fecha_nacimientoS = res.fecha_nacimiento.ToString("dd/MM/yyyy");
                        }
                        //res.fecha_usoS = row[idx].ToString(); idx++;

                        res.dibujo = RLArchivo.GetFromPatente(res.id, "Dibujo");
                        res._explicacion = RLArchivo.GetFromPatente(res.id, "Explicación");
                    }
                }
                else
                {
                    //
                }


            }
            catch (Exception ex)
            {
                res = new Patente();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<Patente> Get(int activo = -1)
        {
            List<Patente> res = new List<Patente>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_proc_Patente(out dt, out errores, activo))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new Patente();

                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.empresa = Int32.Parse(row[idx].ToString()); idx++;
                            item.nombre_patente = row[idx].ToString(); idx++;
                            item.nombre = row[idx].ToString(); idx++;
                            item.prioridad = Int32.Parse(row[idx].ToString()); idx++;
                            item.pais = Int32.Parse(row[idx].ToString()); idx++;
                            item.explicacion = row[idx].ToString(); idx++;
                            item.fecha_nacimiento = DateTime.Parse(row[idx].ToString()); idx++;
                            item.activo = Int32.Parse(row[idx].ToString()); idx++;
                            item.orden = Int32.Parse(row[idx].ToString()); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.usuario = row[idx].ToString(); idx++;
                            item.empresa_nombre = row[idx].ToString(); idx++;
                            item.prioridad_nombre = row[idx].ToString(); idx++;
                            item.pais_nombre = row[idx].ToString(); idx++;
                            item.identificador = row[idx].ToString(); idx++;
                            item.nacionalidad = row[idx].ToString(); idx++;
                            item.domicilio = row[idx].ToString(); idx++;
                            item.rfc = row[idx].ToString(); idx++;
                            item.curp = row[idx].ToString(); idx++;
                            item.lugar_nacimiento = row[idx].ToString(); idx++;
                            item.tipo_solicitud = Int32.Parse(row[idx].ToString()); idx++;
                            item.tipo_solicitud_nombre = row[idx].ToString(); idx++;
                            item.aplicado = Int32.Parse(row[idx].ToString()); idx++;

                            if (item.fecha_nacimiento.Year != 1969)
                            {
                                item.fecha_nacimientoS = item.fecha_nacimiento.ToString("dd/MM/yyyy");
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
                res = new List<Patente>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static RespuestaFormato Crear(Patente modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_proc_Patente(modelo, out dt, out errores))
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

        public static RespuestaFormato Actualizar(Patente modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_proc_Patente(modelo, out dt, out errores))
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

        public static RespuestaFormato ActualizarActivo(Patente modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_proc_Patente_Activo(modelo, out dt, out errores))
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
