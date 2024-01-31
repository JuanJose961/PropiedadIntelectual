using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GISMVC.Models
{
    public class DocumentoProveedor
    {
        public byte[] file_data { get; set; }
        public string file_data_str { get; set; }
        public string file_nombre { get; set; }
        public string file_ext { get; set; }
        public string tipo { get; set; }
        public string descripcion { get; set; }
        public string file_content_type { get; set; }
        public int file_size { get; set; }

        public int idx { get; set; }
        public DocumentoProveedor()
        {
            //file_data = null;
            file_nombre = "";
            file_ext = "";
            tipo = "";
            descripcion = "";
            file_content_type = "";
            file_size = 0;
            file_data_str = "";
            idx = 0;
        }
        /*
        public static DocumentoProveedor GetById(int id)
        {
            DocumentoProveedor res = new DocumentoProveedor();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_DocumentoProveedorById(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];
                        var item = new DocumentoProveedor();
                        item.id = Int32.Parse(row[idx].ToString()); idx++;
                        item.usuario.id = row[idx].ToString(); idx++;
                        item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                        item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                        item.contrato = Int32.Parse(row[idx].ToString()); idx++;
                        item.file_nombre = row[idx].ToString(); idx++;
                        if (row[idx] != null)
                        {
                            item.file_data = (byte[])row[idx];
                        }
                        idx++;
                        //file_data = null;
                        item.file_content_type = row[idx].ToString(); idx++;
                        item.file_size = Int32.Parse(row[idx].ToString()); idx++;
                        item.tipo = row[idx].ToString(); idx++;
                        item.usuario.nombre = row[idx].ToString(); idx++;
                        item.comentario = row[idx].ToString(); idx++;

                        item.file_extension = row[idx].ToString(); idx++;
                        item.nombre = row[idx].ToString(); idx++;

                        if (item.file_extension != "" && item.nombre != "")
                        {
                            item.file_nombre = item.nombre + "_" + item.id + item.file_extension;
                        }
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
                res = new DocumentoProveedor();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
        */
        public static List<DocumentoProveedor> Get(string rfc = "")
        {
            List<DocumentoProveedor> res = new List<DocumentoProveedor>();
            try
            {
                DataAccess da = new DataAccess("ProveedoresConnection");

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.cons_DocumentacionProv(rfc, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new DocumentoProveedor();
                            item.idx = i;
                            item.file_data = Encoding.ASCII.GetBytes(row[idx].ToString());
                            item.file_data = Convert.FromBase64String(row[idx].ToString());
                            item.file_data_str = row[idx].ToString(); idx++;
                            item.file_nombre = row[idx].ToString(); idx++;
                            item.file_ext = row[idx].ToString(); idx++;
                            item.tipo = row[idx].ToString(); idx++;
                            item.descripcion = row[idx].ToString(); idx++;
                            item.file_content_type = Utility.GetContentTypeFromExt(item.file_ext);
                            idx++;
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
                res = new List<DocumentoProveedor>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }


        public static List<DocumentoContrato> GetArchivos(string rfc = "")
        {
            List<DocumentoContrato> res = new List<DocumentoContrato>();
            try
            {
                DataAccess da = new DataAccess("ProveedoresConnection");

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.cons_DocumentacionProv(rfc, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //tipo = cliente
                            //tipo_archivo.id = 5
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new DocumentoContrato();
                            item.idx = i;
                            //var file_data = Encoding.ASCII.GetBytes(row[idx].ToString());
                            var file_data = Convert.FromBase64String(row[idx].ToString());
                            item.file_data_str = row[idx].ToString(); idx++;
                            item.file_nombre = row[idx].ToString(); idx++;
                            item.nombre = item.file_nombre;
                            item.file_ext = row[idx].ToString(); idx++;
                            item.file_extension = item.file_ext;
                            item.tipo = row[idx].ToString(); idx++;
                            item.descripcion = row[idx].ToString(); idx++;
                            item.file_content_type = Utility.GetContentTypeFromExt(item.file_ext);
                            item.tipo_archivo.id = 6;
                            item.file_size = file_data.Length;

                            item.file_nombre = item.tipo.Replace(" ", "") + "_" + item.file_nombre;
                            item.cargado = 0;
                            item.nombre_original = item.file_nombre;
                            idx++;
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
                res = new List<DocumentoContrato>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

    }
}