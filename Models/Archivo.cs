using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GISMVC.Models
{
    public class Archivo
    {
        public int id { get; set; }
        public AspNetUsers usuario { get; set; }
        public DateTime fc { get; set; }
        public DateTime fu { get; set; }
        public string file_nombre { get; set; }
        public byte[] file_data { get; set; }
        public string file_content_type { get; set; }
        public int file_size { get; set; }
        public string tipo { get; set; }
        //
        public string USUARIO_n { get; set; }
        public string FC_d { get; set; }
        public string FU_d { get; set; }
        public int cargado { get; set; }
        public string comentario { get; set; }
        public string file_extension { get; set; }
        public string nombre { get; set; }
        public string url { get; set; }
        public string permalink { get; set; }

        public Archivo()
        {
            permalink = "";
            url = "";
            id = 0;
            usuario = new AspNetUsers();
            fc = DateTime.Parse("01-01-1969");
            fu = DateTime.Parse("01-01-1969");
            file_nombre = "";
            //file_data = null;
            file_content_type = "";
            file_size = 0;
            FC_d = "";
            FU_d = "";
            USUARIO_n = "";
            cargado = 0;
            comentario = "";
            file_extension = "";
            nombre = "";
        }

        public RespuestaFormato Crear()
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_proc_Archivo(this, out dt, out errores))
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
        /*
        public static RespuestaFormato Eliminar(Archivo modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.DEL_proc_Archivo(modelo.id, out dt, out errores))
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
        */
        public static Archivo GetById(int id)
        {
            dll_Gis.Funciones funcion = new dll_Gis.Funciones();
            Archivo res = new Archivo();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_proc_ArchivoById(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];
                        var item = new Archivo();
                        item.id = Int32.Parse(row[idx].ToString()); idx++;
                        item.usuario.id = row[idx].ToString(); idx++;
                        item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                        item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                        item.file_nombre = row[idx].ToString(); idx++;
                        /*if (row[idx] != null)
                        {
                            item.file_data = (byte[])row[idx];
                        }
                        idx++;*/
                        //file_data = null;
                        item.file_content_type = row[idx].ToString(); idx++;
                        item.file_size = Int32.Parse(row[idx].ToString()); idx++;
                        item.tipo = row[idx].ToString(); idx++;
                        item.usuario.nombre = row[idx].ToString(); idx++;

                        item.file_extension = row[idx].ToString(); idx++;
                        item.url = row[idx].ToString(); idx++;
                        item.nombre = row[idx].ToString(); idx++;
                        item.cargado = 1;
                        item.permalink = Utility.hosturl +
                            "PI/DescargarArchivo?id=" +
                            HttpUtility.UrlEncode(funcion.Encriptar(item.id.ToString()));
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
                res = new Archivo();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
        /*
        
        */
    }
}