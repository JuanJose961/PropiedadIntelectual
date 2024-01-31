using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GISMVC.Models
{
    public class DocumentoComentario
    {
        public int id { get; set; }
        public AspNetUsers usuario { get; set; }
        public DateTime fc { get; set; }
        public DateTime fu { get; set; }
        public int contrato { get; set; }
        public int documento { get; set; }
        //
        public string descripcion { get; set; }
        public string FC_d { get; set; }
        public string FU_d { get; set; }

        public DocumentoComentario()
        {
            id = 0;
            usuario = new AspNetUsers();
            fc = DateTime.Parse("01-01-1969");
            fu = DateTime.Parse("01-01-1969");
            documento = 0;
            contrato = 0;
            FC_d = "";
            FU_d = "";
            descripcion = "";
        }

        public static RespuestaFormato Crear(DocumentoComentario modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_DocumentoComentario(modelo, out dt, out errores))
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

        public static RespuestaFormato Eliminar(DocumentoComentario modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.DEL_DocumentoComentario(modelo.id, out dt, out errores))
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

        public static DocumentoComentario GetById(int id)
        {
            DocumentoComentario res = new DocumentoComentario();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_DocumentoComentarioById(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];
                        var item = new DocumentoComentario();
                        item.id = Int32.Parse(row[idx].ToString()); idx++;
                        item.usuario.id = row[idx].ToString(); idx++;
                        item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                        item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                        item.contrato = Int32.Parse(row[idx].ToString()); idx++;
                        item.documento = Int32.Parse(row[idx].ToString()); idx++;
                        item.usuario.nombre = row[idx].ToString(); idx++;
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
                res = new DocumentoComentario();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<DocumentoComentario> GetFromId(int id = 0)
        {
            List<DocumentoComentario> res = new List<DocumentoComentario>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_DocumentoComentarioFromId(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new DocumentoComentario();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.contrato = Int32.Parse(row[idx].ToString()); idx++;
                            item.documento = Int32.Parse(row[idx].ToString()); idx++;
                            /*if (!String.IsNullOrEmpty(row[idx].ToString()))
                            {

                            }*/
                            idx++;
                            item.usuario.id = row[idx].ToString(); idx++;
                            //propuesta_data = null;
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
                res = new List<DocumentoComentario>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
    }
}