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

    public class PortalSideBar
    {
        public bool administracion { get; set; } = false;
        public bool contratos { get; set; } = false;
        public bool pi { get; set; } = false;
        //
        public bool adm_usuarios { get; set; } = false;
        public bool adm_roles { get; set; } = false;
        public bool adm_dashboard { get; set; } = false;
        ////
        public bool pi_propiedadindustrial { get; set; } = false;
        public bool pi_propiedadintelectual { get; set; } = false;
        public bool pi_catalogos { get; set; } = false;
        public bool pi_Negocio { get; set; } = false;
        public bool pi_TipoCatalogo { get; set; } = false;
        public bool pi_TipoRegistro { get; set; } = false;
        public bool pi_Clase { get; set; } = false;
        public bool pi_EstatusCatalogo { get; set; } = false;
        public bool pi_Despacho { get; set; } = false;
        public bool pi_Corresponsal { get; set; } = false;
        public bool pi_Pais { get; set; } = false;
        public bool pi_ConvenioLicencia { get; set; } = false;
        public bool pi_ContratoCesion { get; set; } = false;

        public bool pi_Marca { get; set; } = false;
        public bool pi_AvisoComercial { get; set; } = false;
        public bool pi_Patente { get; set; } = false;
        public bool pi_ModeloUtilidad { get; set; } = false;
        public bool pi_ModeloIndustrial { get; set; } = false;
        public bool pi_DisenoIndustrial { get; set; } = false;
        public bool pi_Obra { get; set; } = false;
        public bool pi_Marca_alta { get; set; } = false;
        public bool pi_AvisoComercial_alta { get; set; } = false;
        public bool pi_Patente_alta { get; set; } = false;
        public bool pi_ModeloUtilidad_alta { get; set; } = false;
        public bool pi_ModeloIndustrial_alta { get; set; } = false;
        public bool pi_DisenoIndustrial_alta { get; set; } = false;
        public bool pi_Obra_alta { get; set; } = false;
        //
        public bool pi_RegistroMarcas { get; set; } = false;
        public bool pi_RegistroMarca { get; set; } = false;
        //
        public bool pi_otros { get; set; } = false;
        public bool pi_RecordatorioPI { get; set; } = false;
        public bool pi_BusquedaAvanzada { get; set; } = false;
        public bool pi_HistorialMovimientos { get; set; } = false;
        //

        public static PortalSideBar Get(List<AccesoVistas> accesos)
        {
            PortalSideBar res = new PortalSideBar();
            try
            {
                if (accesos.Where(i => i.modulo == "GENERAL" && i.acceso == 1).Count() > 0)
                {
                    res.administracion = true;
                    if (accesos.Where(i => i.modulo == "GENERAL" && i.url == "Usuarios" && i.acceso == 1).Count() > 0)
                    {
                        res.adm_usuarios = true;
                    }
                    if (accesos.Where(i => i.modulo == "GENERAL" && i.url == "Roles" && i.acceso == 1).Count() > 0)
                    {
                        res.adm_roles = true;
                    }
                    if (accesos.Where(i => i.modulo == "GENERAL" && i.url == "Dashboard" && i.acceso == 1).Count() > 0)
                    {
                        res.adm_dashboard = true;
                    }
                }
                if (accesos.Where(i => i.modulo == "PI" && i.acceso == 1).Count() > 0)
                {
                    res.pi = true;
                    //catalogos
                    if (accesos.Where(i => i.modulo == "PI" && i.tipo == "CATALOGO" && i.acceso == 1).Count() > 0)
                    {
                        res.pi_catalogos = true;

                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "CATALOGO" && i.url == "Negocio" && i.acceso == 1).Count() > 0)
                        {
                            res.pi_Negocio = true;
                        }
                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "CATALOGO" && i.url == "TipoCatalogo" && i.acceso == 1).Count() > 0)
                        {
                            res.pi_TipoCatalogo = true;
                        }
                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "CATALOGO" && i.url == "TipoRegistro" && i.acceso == 1).Count() > 0)
                        {
                            res.pi_TipoRegistro = true;
                        }
                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "CATALOGO" && i.url == "Clase" && i.acceso == 1).Count() > 0)
                        {
                            res.pi_Clase = true;
                        }
                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "CATALOGO" && i.url == "EstatusCatalogo" && i.acceso == 1).Count() > 0)
                        {
                            res.pi_EstatusCatalogo = true;
                        }
                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "CATALOGO" && i.url == "Despacho" && i.acceso == 1).Count() > 0)
                        {
                            res.pi_Despacho = true;
                        }
                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "CATALOGO" && i.url == "Corresponsal" && i.acceso == 1).Count() > 0)
                        {
                            res.pi_Corresponsal = true;
                        }
                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "CATALOGO" && i.url == "Pais" && i.acceso == 1).Count() > 0)
                        {
                            res.pi_Pais = true;
                        }
                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "CATALOGO" && i.url == "ConvenioLicencia" && i.acceso == 1).Count() > 0)
                        {
                            res.pi_ConvenioLicencia = true;
                        }
                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "CATALOGO" && i.url == "ContratoCesion" && i.acceso == 1).Count() > 0)
                        {
                            res.pi_ContratoCesion = true;
                        }
                    }
                    //formatos
                    if (accesos.Where(i => i.modulo == "PI" && i.tipo == "FORMATOS" && i.acceso == 1).Count() > 0)
                    {

                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "FORMATOS" && i.url == "Marca" && i.acceso == 1).Count() > 0)
                        {
                            res.pi_propiedadindustrial = true;
                            res.pi_Marca = true;
                            res.pi_Marca_alta = true;
                        }
                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "FORMATOS" && i.url == "AvisoComercial" && i.acceso == 1).Count() > 0)
                        {
                            res.pi_propiedadindustrial = true;
                            res.pi_AvisoComercial = true;
                            res.pi_AvisoComercial_alta = true;
                        }
                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "FORMATOS" && i.url == "Patente" && i.acceso == 1).Count() > 0)
                        {
                            res.pi_propiedadindustrial = true;
                            res.pi_Patente = true;
                            res.pi_Patente_alta = true;
                        }
                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "FORMATOS" && i.url == "ModeloUtilidad" && i.acceso == 1).Count() > 0)
                        {
                            res.pi_propiedadindustrial = true;
                            res.pi_ModeloUtilidad = true;
                            res.pi_ModeloUtilidad_alta = true;
                        }
                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "FORMATOS" && i.url == "ModeloIndustrial" && i.acceso == 1).Count() > 0)
                        {
                            res.pi_propiedadindustrial = true;
                            res.pi_ModeloIndustrial = true;
                            res.pi_ModeloIndustrial_alta = true;
                        }
                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "FORMATOS" && i.url == "DisenoIndustrial" && i.acceso == 1).Count() > 0)
                        {
                            res.pi_propiedadindustrial = true;
                            res.pi_DisenoIndustrial = true;
                            res.pi_DisenoIndustrial_alta = true;
                        }
                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "FORMATOS" && i.url == "Obra" && i.acceso == 1).Count() > 0)
                        {
                            res.pi_propiedadintelectual = true;
                            res.pi_Obra = true;
                            res.pi_Obra_alta = true;
                        }
                    }

                    //utilidad
                    if (accesos.Where(i => i.modulo == "PI" && i.tipo == "UTILIDAD" && i.acceso == 1).Count() > 0)
                    {
                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "UTILIDAD" && i.url == "RegistroMarcas" && i.acceso == 1).Count() > 0)
                        {
                            //res.pi_otros = true;
                            res.pi_RegistroMarcas = true;
                        }
                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "UTILIDAD" && i.url == "RegistroMarca" && i.acceso == 1).Count() > 0)
                        {
                            //res.pi_otros = true;
                            //res.pi_RegistroMarcas = true;
                            res.pi_RegistroMarca = true;
                        }
                    }
                    //administracion
                    if (accesos.Where(i => i.modulo == "PI" && i.tipo == "ADMINISTRACION" && i.acceso == 1).Count() > 0)
                    {
                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "ADMINISTRACION" && i.url == "RecordatorioPI" && i.acceso == 1).Count() > 0)
                        {
                            res.pi_otros = true;
                            res.pi_RecordatorioPI = true;
                        }
                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "ADMINISTRACION" && i.url == "BusquedaAvanzada" && i.acceso == 1).Count() > 0)
                        {
                            res.pi_otros = true;
                            res.pi_BusquedaAvanzada = true;
                        }
                        if (accesos.Where(i => i.modulo == "PI" && i.tipo == "ADMINISTRACION" && i.url == "HistorialMovimientos" && i.acceso == 1).Count() > 0)
                        {
                            res.pi_otros = true;
                            res.pi_HistorialMovimientos = true;
                        }
                    }
                }

                if (accesos.Where(i => i.modulo == "CONTRATOS" && i.acceso == 1).Count() > 0)
                {
                    res.contratos = true;
                }
            }
            catch (Exception ex)
            {
                res = new PortalSideBar();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

    }
    public class AccesoVistas
    {
        public int pagina { get; set; }
        public string url { get; set; }
        public string descripcion { get; set; }
        public string usuario { get; set; }
        public string rol { get; set; }
        public DateTime fc { get; set; }
        public DateTime fu { get; set; }
        public int activo { get; set; }
        public string tipo { get; set; }
        public int id { get; set; }
        public string modulo { get; set; }
        public int acceso { get; set; }
        public AccesoVistas()
        {
            pagina = 0;
            url = "";
            descripcion = "";
            fc = DateTime.Parse("1969-01-01");
            fu = DateTime.Parse("1969-01-01");
            activo = 0;
            tipo = "";
            modulo = "";
            usuario = "";
            rol = "";
            id = 0;
            acceso = 0;
        }

        public static List<AccesoVistas> GetFromUsuario(string id = "")
        {
            List<AccesoVistas> res = new List<AccesoVistas>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_proc_AccesoVistasPorUsuario(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int paginax = 0;
                            var row = dt.Rows[i];
                            var item = new AccesoVistas();
                            item.pagina = Int32.Parse(row[paginax].ToString()); paginax++;
                            item.url = row[paginax].ToString(); paginax++;
                            item.descripcion = row[paginax].ToString(); paginax++;
                            item.tipo = row[paginax].ToString(); paginax++;
                            item.modulo = row[paginax].ToString(); paginax++;
                            item.id = Int32.Parse(row[paginax].ToString()); paginax++;
                            item.acceso = Int32.Parse(row[paginax].ToString()); paginax++;
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
                res = new List<AccesoVistas>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<AccesoVistas> GetFromRol(string id = "")
        {
            List<AccesoVistas> res = new List<AccesoVistas>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_proc_AccesoVistasPorRol(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int paginax = 0;
                            var row = dt.Rows[i];
                            var item = new AccesoVistas();
                            item.pagina = Int32.Parse(row[paginax].ToString()); paginax++;
                            item.url = row[paginax].ToString(); paginax++;
                            item.descripcion = row[paginax].ToString(); paginax++;
                            item.tipo = row[paginax].ToString(); paginax++;
                            item.modulo = row[paginax].ToString(); paginax++;
                            item.id = Int32.Parse(row[paginax].ToString()); paginax++;
                            item.acceso = Int32.Parse(row[paginax].ToString()); paginax++;
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
                res = new List<AccesoVistas>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }


        public static RespuestaFormato TieneAcceso(List<AccesoVistas> lista, string url = "", string tipo = "", string modulo = "")
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                var acceso = lista.Where(i => i.url == url && i.tipo == tipo && i.modulo == modulo && i.acceso == 1).Count();
                if(acceso > 0)
                {
                    res.flag = true;
                }
                else
                {
                    res.description = "No tiene acceso a la vista";
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

        public static RespuestaFormato ActualizarUsuario(AccesoVistas modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_proc_AccesoVistasPorUsuario(modelo.usuario, modelo.pagina, modelo.acceso, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        int pagina = 0;
                        Int32.TryParse(row[3].ToString(), out pagina);
                        if (pagina > 0)
                        {
                            res.flag = true;
                            res.data_int = pagina;
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


        public static RespuestaFormato ActualizarRol(AccesoVistas modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_proc_AccesoVistasPorRol(modelo.rol, modelo.pagina, modelo.acceso, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        int pagina = 0;
                        Int32.TryParse(row[3].ToString(), out pagina);
                        if (pagina > 0)
                        {
                            res.flag = true;
                            res.data_int = pagina;
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
