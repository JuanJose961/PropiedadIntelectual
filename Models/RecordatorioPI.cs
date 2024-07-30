using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GISMVC.Models
{
    public class TipoRecordatorio
    {
        public int id { get; set; } = 0;
        public string nombre { get; set; } = "";
        public static TipoRecordatorio GetById(int id)
        {
            TipoRecordatorio res = new TipoRecordatorio();
            List<TipoRecordatorio> list = new List<TipoRecordatorio>();
            list.Add(new TipoRecordatorio() { id = 1, nombre = "Días de vencimiento" });
            list.Add(new TipoRecordatorio() { id = 2, nombre = "Frecuencia" });


            if (id >= 1 && id <= 2)
            {
                res = list.Where(i => i.id == id).FirstOrDefault();
            }
            return res;
        }

        public static List<TipoRecordatorio> Get(int activo = -1)
        {
            List<TipoRecordatorio> list = new List<TipoRecordatorio>();
            list.Add(new TipoRecordatorio() { id = 1, nombre = "Días de vencimiento" });
            list.Add(new TipoRecordatorio() { id = 2, nombre = "Frecuencia" });


            return list;
        }

    }

    public class FechaValidacion
    {
        public int id { get; set; } = 0;
        public string nombre { get; set; } = "";
        public static FechaValidacion GetById(int id)
        {
            FechaValidacion res = new FechaValidacion();
            List<FechaValidacion> list = new List<FechaValidacion>();
            list.Add(new FechaValidacion() { id = 1, nombre = "Fecha de vencimiento" });
            list.Add(new FechaValidacion() { id = 2, nombre = "Fecha legal" });
            list.Add(new FechaValidacion() { id = 3, nombre = "Fecha concesión" });
            list.Add(new FechaValidacion() { id = 4, nombre = "Requerimiento del negocio" });
            list.Add(new FechaValidacion() { id = 5, nombre = "Instrucciones al corresponsal" });
            list.Add(new FechaValidacion() { id = 6, nombre = "Solicitud de registro ante la autoridad competente" });
            list.Add(new FechaValidacion() { id = 7, nombre = "Solicitud de busqueda" });
            list.Add(new FechaValidacion() { id = 8, nombre = "Información de resultados al negocio" });
            list.Add(new FechaValidacion() { id = 9, nombre = "Comprobación de uso" });
            list.Add(new FechaValidacion() { id = 10, nombre = "Declaración de uso" });
            list.Add(new FechaValidacion() { id = 11, nombre = "Fecha para pagar quinquenios o anualidades" });
            list.Add(new FechaValidacion() { id = 12, nombre = "Fecha de vencimiento de prioridad" });

            if (id >= 1 && id <= 10)
            {
                res = list.Where(i => i.id == id).FirstOrDefault();
            }
            return res;
        }

        public static List<FechaValidacion> Get(int activo = -1)
        {
            List<FechaValidacion> list = new List<FechaValidacion>();
            list.Add(new FechaValidacion() { id = 1, nombre = "Fecha de vencimiento" });
            list.Add(new FechaValidacion() { id = 2, nombre = "Fecha legal" });
            list.Add(new FechaValidacion() { id = 3, nombre = "Fecha concesión" });
            list.Add(new FechaValidacion() { id = 4, nombre = "Requerimiento del negocio" });
            list.Add(new FechaValidacion() { id = 5, nombre = "Instrucciones al corresponsal" });
            list.Add(new FechaValidacion() { id = 6, nombre = "Solicitud de registro ante la autoridad competente" });
            list.Add(new FechaValidacion() { id = 7, nombre = "Solicitud de busqueda" });
            list.Add(new FechaValidacion() { id = 8, nombre = "Información de resultados al negocio" });
            list.Add(new FechaValidacion() { id = 9, nombre = "Comprobación de uso" });
            list.Add(new FechaValidacion() { id = 10, nombre = "Declaración de uso" });
            list.Add(new FechaValidacion() { id = 11, nombre = "Fecha para pagar quinquenios o anualidades" });
            list.Add(new FechaValidacion() { id = 12, nombre = "Fecha de vencimiento de prioridad" });

            return list;
        }

    }

    public class TipoSolicitudRecordatorio
    {
        public int id { get; set; } = 0;
        public string nombre { get; set; } = "";
        public static TipoSolicitudRecordatorio GetById(int id)
        {
            TipoSolicitudRecordatorio res = new TipoSolicitudRecordatorio();
            List<TipoSolicitudRecordatorio> list = new List<TipoSolicitudRecordatorio>();
            list.Add(new TipoSolicitudRecordatorio() { id = 1, nombre = "Marcas y Avisos" });
            list.Add(new TipoSolicitudRecordatorio() { id = 2, nombre = "Invenciones" });
            list.Add(new TipoSolicitudRecordatorio() { id = 3, nombre = "Obras" });
            list.Add(new TipoSolicitudRecordatorio() { id = 4, nombre = "Todos" });
            //list.Add(new TipoSolicitudRecordatorio() { id = 5, nombre = "Modelo de Utilidad" });
            //list.Add(new TipoSolicitudRecordatorio() { id = 6, nombre = "Modelo Industrial" });
            //list.Add(new TipoSolicitudRecordatorio() { id = 7, nombre = "Obra Artística" });
            //list.Add(new TipoSolicitudRecordatorio() { id = 8, nombre = "Obra Visual" });
            //list.Add(new TipoSolicitudRecordatorio() { id = 9, nombre = "Obra Literaria" });
            //list.Add(new TipoSolicitudRecordatorio() { id = 10, nombre = "Obra Auditiva" });
            //list.Add(new TipoSolicitudRecordatorio() { id = 11, nombre = "Obra Gráfica" });
            //list.Add(new TipoSolicitudRecordatorio() { id = 12, nombre = "Obra Tecnológica" });

            if (id >= 1 && id <= 4)
            {
                res = list.Where(i => i.id == id).FirstOrDefault();
            }
            return res;
        }

        public static List<TipoSolicitudRecordatorio> Get(int activo = -1)
        {
            List<TipoSolicitudRecordatorio> list = new List<TipoSolicitudRecordatorio>();
            list.Add(new TipoSolicitudRecordatorio() { id = 1, nombre = "Marcas y Avisos" });
            list.Add(new TipoSolicitudRecordatorio() { id = 2, nombre = "Invenciones" });
            list.Add(new TipoSolicitudRecordatorio() { id = 3, nombre = "Obras" });
            list.Add(new TipoSolicitudRecordatorio() { id = 4, nombre = "Todos" });

            return list;
        }

    }
    public class RecordatorioPI
    {
        //public int id { get; set; } = 0;
        public int id { get; set; }
        public string usuario { get; set; } = "";
        public string asignado { get; set; } = "";
        public DateTime fc { get; set; } = DateTime.Parse("01-01-1969");
        public DateTime fu { get; set; } = DateTime.Parse("01-01-1969");
        public DateTime fecha_recordatorio { get; set; } = DateTime.Parse("01-01-1969");
        public int dias_vencimiento { get; set; } = 0;
        //public int frecuencia { get; set; } = 0;
        public string dias_frecuencia { get; set; } = "";
        public string descripcion { get; set; } = "";
        public string nombre { get; set; } = "";
        public int estatus { get; set; } = 0;
        public DateTime fecha_pre_vencimiento { get; set; } = DateTime.Parse("01-01-1969");
        public DateTime fecha_siguiente_notif { get; set; } = DateTime.Parse("01-01-1969");
        public int notif_fecha_recordatorio { get; set; } = 0;
        public int notif_vencimiento { get; set; } = 0;
        public string usuario_nombre { get; set; } = "";
        public string usuario_correo { get; set; } = "";
        public string asignado_nombre { get; set; } = "";
        public string asignado_correo { get; set; } = "";
        public string fecha_recordatorioS { get; set; } = "";
        public bool activo { get; set; } = false;
        public DateTime fecha_fin { get; set; } = DateTime.Parse("01-01-1969");
        public string fecha_finS { get; set; } = "";
        public int tipo { get; set; } = 0;
        public string tipo_desc { get; set; } = "";
        public int aux1 { get; set; } = 0;
        public string registro_desc { get; set; } = "";
        public string campos { get; set; } = "";
        public int fecha_validacion { get; set; } = 0;
        public string fecha_validacion_desc { get; set; } = "";
        //

        public RecordatorioPI()
        {
        }

        //
        public static RespuestaFormato Actualizar_PorRegistroFecha(DateTime fecha_recordatorio, int registro, int tipo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_RecordatorioPI_PorRegistroFecha(fecha_recordatorio, registro, tipo, out dt, out errores))
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

        public static RespuestaFormato Crear(RecordatorioPI modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.INS_RecordatorioPI(modelo, out dt, out errores))
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

        public static RespuestaFormato Actualizar(RecordatorioPI modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_RecordatorioPI(modelo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        int id = 0;
                        //int id = modelo.id;
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

        public static RespuestaFormato Eliminar(RecordatorioPI modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.DEL_RecordatorioPI(modelo.id, out dt, out errores))
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

        public static RecordatorioPI GetById(int id)
        {
            RecordatorioPI res = new RecordatorioPI();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_RecordatorioPIById(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];
                        var item = new RecordatorioPI();

                        item.id = Int32.Parse(row[idx].ToString()); idx++;
                        item.nombre = row[idx].ToString(); idx++;
                        item.usuario = row[idx].ToString(); idx++;
                        item.asignado = row[idx].ToString(); idx++;
                        item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                        item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                        item.fecha_recordatorio = DateTime.Parse(row[idx].ToString()); idx++;
                        item.dias_vencimiento = Int32.Parse(row[idx].ToString()); idx++;
                        //item.frecuencia = Int32.Parse(row[idx].ToString()); idx++;
                        item.dias_frecuencia = row[idx].ToString(); idx++;
                        item.descripcion = row[idx].ToString(); idx++;
                        item.estatus = Int32.Parse(row[idx].ToString()); idx++;
                        item.fecha_pre_vencimiento = DateTime.Parse(row[idx].ToString()); idx++;
                        item.fecha_siguiente_notif = DateTime.Parse(row[idx].ToString()); idx++;
                        item.notif_fecha_recordatorio = Int32.Parse(row[idx].ToString()); idx++;
                        item.notif_vencimiento = Int32.Parse(row[idx].ToString()); idx++;
                        item.usuario_nombre = row[idx].ToString(); idx++;
                        item.usuario_correo = row[idx].ToString(); idx++;
                        item.asignado_nombre = row[idx].ToString(); idx++;
                        item.asignado_correo = row[idx].ToString(); idx++;

                        item.fecha_fin = DateTime.Parse(row[idx].ToString()); idx++;

                        item.tipo = Int32.Parse(row[idx].ToString()); idx++;
                        item.tipo_desc = row[idx].ToString(); idx++;
                        item.aux1 = Int32.Parse(row[idx].ToString()); idx++;
                        item.registro_desc = row[idx].ToString(); idx++;
                        item.campos = row[idx].ToString(); idx++;
                        item.fecha_validacion = Int32.Parse(row[idx].ToString()); idx++;
                        item.fecha_validacion_desc = row[idx].ToString(); idx++;

                        if (item.estatus == 1)
                        {
                            item.activo = true;
                        }
                        if (item.fecha_recordatorio.Year != 1969)
                        {
                            item.fecha_recordatorioS = item.fecha_recordatorio.ToString("dd/MM/yyyy");
                        }
                        if (item.fecha_fin.Year != 1969)
                        {
                            item.fecha_finS = item.fecha_fin.ToString("dd/MM/yyyy");
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
                res = new RecordatorioPI();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<RecordatorioPI> Get(int id = -1)
        {
            List<RecordatorioPI> res = new List<RecordatorioPI>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_RecordatorioPI(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new RecordatorioPI();

                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.nombre = row[idx].ToString(); idx++;
                            item.usuario = row[idx].ToString(); idx++;
                            item.asignado = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fecha_recordatorio = DateTime.Parse(row[idx].ToString()); idx++;
                            item.dias_vencimiento = Int32.Parse(row[idx].ToString()); idx++;
                            //item.frecuencia = Int32.Parse(row[idx].ToString()); idx++;
                            item.dias_frecuencia = row[idx].ToString(); idx++;
                            item.descripcion = row[idx].ToString(); idx++;
                            item.estatus = Int32.Parse(row[idx].ToString()); idx++;
                            item.fecha_pre_vencimiento = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fecha_siguiente_notif = DateTime.Parse(row[idx].ToString()); idx++;
                            item.notif_fecha_recordatorio = Int32.Parse(row[idx].ToString()); idx++;
                            item.notif_vencimiento = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario_nombre = row[idx].ToString(); idx++;
                            item.usuario_correo = row[idx].ToString(); idx++;
                            item.asignado_nombre = row[idx].ToString(); idx++;
                            item.asignado_correo = row[idx].ToString(); idx++;
                            item.fecha_fin = DateTime.Parse(row[idx].ToString()); idx++;
                            idx++;
                            item.tipo_desc = row[idx].ToString(); idx++;
                            idx++; idx++;
                            item.campos = row[idx].ToString(); idx++;
                            item.fecha_validacion = Int32.Parse(row[idx].ToString()); idx++;
                            item.fecha_validacion_desc = row[idx].ToString(); idx++;

                            if (item.estatus == 1)
                            {
                                item.activo = true;
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
                res = new List<RecordatorioPI>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }


        public static List<RecordatorioPI> GetFromRegistro(int id = 0)
        {
            List<RecordatorioPI> res = new List<RecordatorioPI>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_RecordatoriosPI_FromRegistro(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new RecordatorioPI();

                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario = row[idx].ToString(); idx++;
                            item.asignado = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fecha_recordatorio = DateTime.Parse(row[idx].ToString()); idx++;
                            item.dias_vencimiento = Int32.Parse(row[idx].ToString()); idx++;
                            item.dias_frecuencia = row[idx].ToString(); idx++;
                            item.descripcion = row[idx].ToString(); idx++;
                            item.estatus = Int32.Parse(row[idx].ToString()); idx++;
                            item.fecha_pre_vencimiento = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fecha_siguiente_notif = DateTime.Parse(row[idx].ToString()); idx++;
                            item.notif_fecha_recordatorio = Int32.Parse(row[idx].ToString()); idx++;
                            item.notif_vencimiento = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario_nombre = row[idx].ToString(); idx++;
                            item.usuario_correo = row[idx].ToString(); idx++;
                            item.asignado_nombre = row[idx].ToString(); idx++;
                            item.asignado_correo = row[idx].ToString(); idx++;

                            item.fecha_fin = DateTime.Parse(row[idx].ToString()); idx++;

                            item.tipo = Int32.Parse(row[idx].ToString()); idx++;
                            item.tipo_desc = row[idx].ToString(); idx++;
                            item.aux1 = Int32.Parse(row[idx].ToString()); idx++;
                            item.registro_desc = row[idx].ToString(); idx++;

                            if (item.estatus == 1)
                            {
                                item.activo = true;
                            }
                            if (item.fecha_recordatorio.Year != 1969)
                            {
                                item.fecha_recordatorioS = item.fecha_recordatorio.ToString("dd/MM/yyyy");
                            }
                            if (item.fecha_fin.Year != 1969)
                            {
                                item.fecha_finS = item.fecha_fin.ToString("dd/MM/yyyy");
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
                res = new List<RecordatorioPI>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
        
        public static RespuestaFormato ActualizarActivo(RecordatorioPI modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_proc_RecordatorioPI_Activo(modelo, out dt, out errores))
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
        /*
        public static List<RecordatorioPI> GetFromId(int id = 0)
        {
            List<RecordatorioPI> res = new List<RecordatorioPI>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_RecordatorioPIFromId(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new RecordatorioPI();

                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario = row[idx].ToString(); idx++;
                            item.asignado = row[idx].ToString(); idx++;
                            item.fc = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fu = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fecha_recordatorio = DateTime.Parse(row[idx].ToString()); idx++;
                            item.dias_vencimiento = Int32.Parse(row[idx].ToString()); idx++;
                            item.frecuencia = Int32.Parse(row[idx].ToString()); idx++;
                            item.descripcion = row[idx].ToString(); idx++;
                            item.estatus = Int32.Parse(row[idx].ToString()); idx++;
                            item.fecha_pre_vencimiento = DateTime.Parse(row[idx].ToString()); idx++;
                            item.fecha_siguiente_notif = DateTime.Parse(row[idx].ToString()); idx++;
                            item.notif_fecha_recordatorio = Int32.Parse(row[idx].ToString()); idx++;
                            item.notif_vencimiento = Int32.Parse(row[idx].ToString()); idx++;
                            item.usuario_nombre = row[idx].ToString(); idx++;
                            item.usuario_correo = row[idx].ToString(); idx++;
                            item.asignado_nombre = row[idx].ToString(); idx++;
                            item.asignado_correo = row[idx].ToString(); idx++;

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
                res = new List<RecordatorioPI>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
        */
    }

    /*jjjjjjjjjjjjjjjjjjj*/
    public class RecordatorioPICampos
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fc { get; set; }
        public DateTime fu { get; set; }
        public int activo { get; set; }
        public int orden { get; set; }
        public RecordatorioPICampos()
        {
            id = 0;
            nombre = "";
            descripcion = "";
            fc = DateTime.Parse("1969-01-01");
            fu = DateTime.Parse("1969-01-01");
            activo = 0;
            orden = 0;
        }

        //




        //public static RecordatorioPI GetById(int id)
        //{
        //    RecordatorioPI res = new RecordatorioPI();
        //    try
        //    {
        //        DataAccess da = new DataAccess();

        //        var dt = new System.Data.DataTable();
        //        var errores = "";
        //        if (da.CONS_RecordatorioPIById(id, out dt, out errores))
        //        {
        //            if (dt.Rows.Count > 0)
        //            {
        //                int idx = 0;
        //                var row = dt.Rows[0];
        //                var item = new RecordatorioPI();

        //                item.id = Int32.Parse(row[idx].ToString()); idx++;
        //                item.nombre = row[idx].ToString(); idx++;
        //                item.usuario = row[idx].ToString(); idx++;
        //                item.asignado = row[idx].ToString(); idx++;
        //                item.fc = DateTime.Parse(row[idx].ToString()); idx++;
        //                item.fu = DateTime.Parse(row[idx].ToString()); idx++;
        //                item.fecha_recordatorio = DateTime.Parse(row[idx].ToString()); idx++;
        //                item.dias_vencimiento = Int32.Parse(row[idx].ToString()); idx++;
        //                #item.frecuencia = Int32.Parse(row[idx].ToString()); idx++;
        //                item.dias_frecuencia = row[idx].ToString(); idx++;
        //                item.descripcion = row[idx].ToString(); idx++;
        //                item.estatus = Int32.Parse(row[idx].ToString()); idx++;
        //                item.fecha_pre_vencimiento = DateTime.Parse(row[idx].ToString()); idx++;
        //                item.fecha_siguiente_notif = DateTime.Parse(row[idx].ToString()); idx++;
        //                item.notif_fecha_recordatorio = Int32.Parse(row[idx].ToString()); idx++;
        //                item.notif_vencimiento = Int32.Parse(row[idx].ToString()); idx++;
        //                item.usuario_nombre = row[idx].ToString(); idx++;
        //                item.usuario_correo = row[idx].ToString(); idx++;
        //                item.asignado_nombre = row[idx].ToString(); idx++;
        //                item.asignado_correo = row[idx].ToString(); idx++;

        //                item.fecha_fin = DateTime.Parse(row[idx].ToString()); idx++;

        //                item.tipo = Int32.Parse(row[idx].ToString()); idx++;
        //                item.tipo_desc = row[idx].ToString(); idx++;
        //                item.aux1 = Int32.Parse(row[idx].ToString()); idx++;
        //                item.registro_desc = row[idx].ToString(); idx++;
        //                item.campos = row[idx].ToString(); idx++;
        //                item.fecha_validacion = Int32.Parse(row[idx].ToString()); idx++;
        //                item.fecha_validacion_desc = row[idx].ToString(); idx++;

        //                if (item.estatus == 1)
        //                {
        //                    item.activo = true;
        //                }
        //                if (item.fecha_recordatorio.Year != 1969)
        //                {
        //                    item.fecha_recordatorioS = item.fecha_recordatorio.ToString("dd/MM/yyyy");
        //                }
        //                if (item.fecha_fin.Year != 1969)
        //                {
        //                    item.fecha_finS = item.fecha_fin.ToString("dd/MM/yyyy");
        //                }
        //                res = item;
        //            }
        //        }
        //        else
        //        {
        //            //
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        res = new RecordatorioPI();
        //    }
        //    finally
        //    {
        //        //con.Close();
        //    }
        //    return res;
        //}

        public static List<RecordatorioPICampos> Get(int activo = -1)
        {
            List<RecordatorioPICampos> res = new List<RecordatorioPICampos>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                //if (da.Cons_RecordatorioPICampos(id, out dt, out errores))
                if (da.Cons_Proc_RecordatorioPICampos(out dt, out errores, activo))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new RecordatorioPICampos();
                            item.id = Int32.Parse(row[idx].ToString()); idx++;
                            item.nombre = row[idx].ToString(); idx++;
                            item.descripcion = row[idx].ToString(); idx++;
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
                res = new List<RecordatorioPICampos>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
    }//RecordatorioPICampos
}