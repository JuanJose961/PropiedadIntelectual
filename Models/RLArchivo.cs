using GISMVC.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dll_Gis;

namespace GISMVC.Models
{
    public class RLArchivo
    {
        public int id { get; set; }
        public int objeto { get; set; }
        public int archivo { get; set; }
        public DateTime fc { get; set; }
        public DateTime fu { get; set; }
        public int activo { get; set; }
        public RLArchivo()
        {
            id = 0;
            objeto = 0;
            archivo = 0;
            fc = DateTime.Parse("1969-01-01");
            fu = DateTime.Parse("1969-01-01");
            activo = 0;
        }


        public RespuestaFormato CrearMarca()
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_proc_RLArchivoMarca(this, out dt, out errores))
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
        public RespuestaFormato CrearAvisoComercial()
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_proc_RLArchivoAvisoComercial(this, out dt, out errores))
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
        public RespuestaFormato CrearPatente()
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_proc_RLArchivoPatente(this, out dt, out errores))
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


        public RespuestaFormato CrearDisenoIndustrial()
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_proc_RLArchivoDisenoIndustrial(this, out dt, out errores))
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

        public RespuestaFormato CrearModeloIndustrial()
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_proc_RLArchivoModeloIndustrial(this, out dt, out errores))
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

        public RespuestaFormato CrearModeloUtilidad()
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_proc_RLArchivoModeloUtilidad(this, out dt, out errores))
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


        public RespuestaFormato CrearObra()
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_proc_RLArchivoObra(this, out dt, out errores))
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


        public RespuestaFormato CrearRegistroMarca()
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_proc_RLArchivoRegistroMarca(this, out dt, out errores))
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
        public static List<Archivo> GetFromMarca(int id = 0, string tipo = "")
        {
            List<Archivo> res = new List<Archivo>();
            Funciones funcion = new Funciones();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_proc_RLArchivoMarcaFromId(id, tipo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new Archivo();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.file_nombre = row[idx].ToString(); idx++;
                            if (row[idx] != null)
                            {
                                //item.file_data = (byte[])row[idx];
                            }
                            idx++;
                            //file_data = null;
                            item.file_content_type = row[idx].ToString(); idx++;
                            item.file_size = Int32.Parse(row[idx].ToString()); idx++;
                            item.tipo = row[idx].ToString(); idx++;
                            item.usuario.nombre = row[idx].ToString(); idx++;

                            item.file_extension = row[idx].ToString(); idx++;
                            item.url = row[idx].ToString(); idx++;
                            item.nombre = row[idx].ToString(); idx++;

                            item.permalink = Utility.hosturl +
                                "PI/DescargarArchivo?id=" +
                                HttpUtility.UrlEncode(funcion.Encriptar(item.id.ToString()));
                            item.cargado = 1;
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
                res = new List<Archivo>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
        public static List<Archivo> GetFromAvisoComercial(int id = 0, string tipo = "")
        {
            List<Archivo> res = new List<Archivo>();
            try
            {
                DataAccess da = new DataAccess();
                Funciones funcion = new Funciones();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_proc_RLArchivoAvisoComercialFromId(id, tipo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new Archivo();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.file_nombre = row[idx].ToString(); idx++;
                            if (row[idx] != null)
                            {
                                //item.file_data = (byte[])row[idx];
                            }
                            idx++;
                            //file_data = null;
                            item.file_content_type = row[idx].ToString(); idx++;
                            item.file_size = Int32.Parse(row[idx].ToString()); idx++;
                            item.tipo = row[idx].ToString(); idx++;
                            item.usuario.nombre = row[idx].ToString(); idx++;

                            item.file_extension = row[idx].ToString(); idx++;
                            item.url = row[idx].ToString(); idx++;
                            item.nombre = row[idx].ToString(); idx++;

                            item.permalink = Utility.hosturl +
                                "PI/DescargarArchivo?id=" +
                                HttpUtility.UrlEncode(funcion.Encriptar(item.id.ToString()));
                            item.cargado = 1;
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
                res = new List<Archivo>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<Archivo> GetFromPatente(int id = 0, string tipo = "")
        {
            List<Archivo> res = new List<Archivo>();
            try
            {
                DataAccess da = new DataAccess();
                Funciones funcion = new Funciones();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_proc_RLArchivoPatenteFromId(id, tipo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new Archivo();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.file_nombre = row[idx].ToString(); idx++;
                            if (row[idx] != null)
                            {
                                //item.file_data = (byte[])row[idx];
                            }
                            idx++;
                            //file_data = null;
                            item.file_content_type = row[idx].ToString(); idx++;
                            item.file_size = Int32.Parse(row[idx].ToString()); idx++;
                            item.tipo = row[idx].ToString(); idx++;
                            item.usuario.nombre = row[idx].ToString(); idx++;

                            item.file_extension = row[idx].ToString(); idx++;
                            item.url = row[idx].ToString(); idx++;
                            item.nombre = row[idx].ToString(); idx++;

                            item.permalink = Utility.hosturl +
                                "PI/DescargarArchivo?id=" +
                                HttpUtility.UrlEncode(funcion.Encriptar(item.id.ToString()));
                            item.cargado = 1;
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
                res = new List<Archivo>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }


        public static List<Archivo> GetFromDisenoIndustrial(int id = 0, string tipo = "")
        {
            List<Archivo> res = new List<Archivo>();
            try
            {
                DataAccess da = new DataAccess();
                Funciones funcion = new Funciones();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_proc_RLArchivoDisenoIndustrialFromId(id, tipo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new Archivo();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.file_nombre = row[idx].ToString(); idx++;
                            if (row[idx] != null)
                            {
                                //item.file_data = (byte[])row[idx];
                            }
                            idx++;
                            //file_data = null;
                            item.file_content_type = row[idx].ToString(); idx++;
                            item.file_size = Int32.Parse(row[idx].ToString()); idx++;
                            item.tipo = row[idx].ToString(); idx++;
                            item.usuario.nombre = row[idx].ToString(); idx++;

                            item.file_extension = row[idx].ToString(); idx++;
                            item.url = row[idx].ToString(); idx++;
                            item.nombre = row[idx].ToString(); idx++;

                            item.permalink = Utility.hosturl +
                                "PI/DescargarArchivo?id=" +
                                HttpUtility.UrlEncode(funcion.Encriptar(item.id.ToString()));
                            item.cargado = 1;
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
                res = new List<Archivo>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<Archivo> GetFromModeloUtilidad(int id = 0, string tipo = "")
        {
            List<Archivo> res = new List<Archivo>();
            try
            {
                DataAccess da = new DataAccess();
                Funciones funcion = new Funciones();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_proc_RLArchivoModeloUtilidadFromId(id, tipo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new Archivo();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.file_nombre = row[idx].ToString(); idx++;
                            if (row[idx] != null)
                            {
                                //item.file_data = (byte[])row[idx];
                            }
                            idx++;
                            //file_data = null;
                            item.file_content_type = row[idx].ToString(); idx++;
                            item.file_size = Int32.Parse(row[idx].ToString()); idx++;
                            item.tipo = row[idx].ToString(); idx++;
                            item.usuario.nombre = row[idx].ToString(); idx++;

                            item.file_extension = row[idx].ToString(); idx++;
                            item.url = row[idx].ToString(); idx++;
                            item.nombre = row[idx].ToString(); idx++;

                            item.permalink = Utility.hosturl +
                                "PI/DescargarArchivo?id=" +
                                HttpUtility.UrlEncode(funcion.Encriptar(item.id.ToString()));
                            item.cargado = 1;
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
                res = new List<Archivo>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<Archivo> GetFromModeloIndustrial(int id = 0, string tipo = "")
        {
            List<Archivo> res = new List<Archivo>();
            try
            {
                DataAccess da = new DataAccess();
                Funciones funcion = new Funciones();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_proc_RLArchivoModeloIndustrialFromId(id, tipo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new Archivo();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.file_nombre = row[idx].ToString(); idx++;
                            if (row[idx] != null)
                            {
                                //item.file_data = (byte[])row[idx];
                            }
                            idx++;
                            //file_data = null;
                            item.file_content_type = row[idx].ToString(); idx++;
                            item.file_size = Int32.Parse(row[idx].ToString()); idx++;
                            item.tipo = row[idx].ToString(); idx++;
                            item.usuario.nombre = row[idx].ToString(); idx++;

                            item.file_extension = row[idx].ToString(); idx++;
                            item.url = row[idx].ToString(); idx++;
                            item.nombre = row[idx].ToString(); idx++;

                            item.permalink = Utility.hosturl +
                                "PI/DescargarArchivo?id=" +
                                HttpUtility.UrlEncode(funcion.Encriptar(item.id.ToString()));
                            item.cargado = 1;
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
                res = new List<Archivo>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<Archivo> GetFromObra(int id = 0, string tipo = "")
        {
            List<Archivo> res = new List<Archivo>();
            try
            {
                DataAccess da = new DataAccess();
                Funciones funcion = new Funciones();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_proc_RLArchivoObraFromId(id, tipo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new Archivo();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.file_nombre = row[idx].ToString(); idx++;
                            if (row[idx] != null)
                            {
                                //item.file_data = (byte[])row[idx];
                            }
                            idx++;
                            //file_data = null;
                            item.file_content_type = row[idx].ToString(); idx++;
                            item.file_size = Int32.Parse(row[idx].ToString()); idx++;
                            item.tipo = row[idx].ToString(); idx++;
                            item.usuario.nombre = row[idx].ToString(); idx++;

                            item.file_extension = row[idx].ToString(); idx++;
                            item.url = row[idx].ToString(); idx++;
                            item.nombre = row[idx].ToString(); idx++;

                            item.permalink = Utility.hosturl +
                                "PI/DescargarArchivo?id=" +
                                HttpUtility.UrlEncode(funcion.Encriptar(item.id.ToString()));
                            item.cargado = 1;
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
                res = new List<Archivo>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }


        public static List<Archivo> GetFromRegistroMarca(int id = 0, string tipo = "")
        {
            List<Archivo> res = new List<Archivo>();
            dll_Gis.Funciones funcion = new dll_Gis.Funciones();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_proc_RLArchivoRegistroMarcaFromId(id, tipo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new Archivo();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.file_nombre = row[idx].ToString(); idx++;
                            item.url = row[idx].ToString(); idx++;
                            /*if (row[idx] != null)
                            {
                                //item.file_data = (byte[])row[idx];
                            }*/
                            //file_data = null;
                            item.file_content_type = row[idx].ToString(); idx++;
                            item.file_size = Int32.Parse(row[idx].ToString()); idx++;
                            item.tipo = row[idx].ToString(); idx++;
                            item.usuario.nombre = row[idx].ToString(); idx++;

                            item.file_extension = row[idx].ToString(); idx++;
                            item.nombre = row[idx].ToString(); idx++;
                            item.cargado = 1;
                            item.permalink = Utility.hosturl +
                                "PI/DescargarArchivo?id=" +
                                HttpUtility.UrlEncode(funcion.Encriptar(item.id.ToString()));
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
                res = new List<Archivo>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
    }
}