using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dll_Gis;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GISMVC.Models
{
    public class DataAccess
    {
        readonly BaseDatos bd = new BaseDatos();
        readonly String conexion = String.Empty;
        readonly Funciones fn = new Funciones();

        public DataAccess()
        {

            try
            {
                string conexionStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
                string connstring = fn.Desencriptar(conexionStr);
                conexion = connstring;//ConfigurationManager.ConnectionStrings["conexion"].ToString());

            }
            catch (Exception)
            {
                throw;
            }

        }

        public DataAccess(string con)
        {

            try
            {
                string conexionStr = ConfigurationManager.ConnectionStrings[con].ToString();
                string connstring = fn.Desencriptar(conexionStr);
                conexion = connstring;//ConfigurationManager.ConnectionStrings["conexion"].ToString());

            }
            catch (Exception)
            {
                throw;
            }

        }


        public Boolean INS_RegistroActividad(RegistroActividad modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[9];

                int i = 0;
                @params[i] = new SqlParameter("@usuario", modelo.usuario.id); i++;
                @params[i] = new SqlParameter("@titulo", modelo.titulo); i++;
                @params[i] = new SqlParameter("@descripcion", modelo.descripcion); i++;
                @params[i] = new SqlParameter("@aux_str", modelo.aux_str); i++;
                @params[i] = new SqlParameter("@aux_int", modelo.aux_int); i++;
                @params[i] = new SqlParameter("@aux_decimal", modelo.aux_decimal); i++;
                @params[i] = new SqlParameter("@contrato", modelo.contrato); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_RegistroActividad", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean CONS_RegistroActividadFromId(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_RegistroActividadFromId", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        #region ROLES
        public Boolean Cons_Rol(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_Rol", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean CONS_RolById(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_RolById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Upd_Rol(AspNetRoles modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            dt = new DataTable();

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;

                @params[i] = new SqlParameter("@id", modelo.id); i++;
                @params[i] = new SqlParameter("@descripcion", modelo.descripcion); i++;

                if (!bd.ExecuteProcedure(conexion, "Upd_Rol", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_Rol_Activo(AspNetRoles modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_Rol_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        #endregion

        #region usuarios
        public Boolean Cons_UsuarioAutocompletar(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_UsuarioAutocompletar", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_Usuarios(out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[0];

                int i = 0;
                //@params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_Usuarios", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_UsuariosV2(out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[0];

                int i = 0;
                //@params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_UsuariosV2", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_proc_AccesoVistasPorUsuario(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_proc_AccesoVistasPorUsuario", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_proc_AccesoVistasPorRol(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_proc_AccesoVistasPorRol", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_AccesoVistasPorUsuario(string usuario, int vista, int acceso, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[3];

                int i = 0;
                @params[0] = new SqlParameter("@usuario", usuario);
                @params[1] = new SqlParameter("@vista", vista);
                @params[2] = new SqlParameter("@acceso", acceso);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_AccesoVistasPorUsuario", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_proc_AccesoVistasPorRol(string rol, int vista, int acceso, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[3];

                int i = 0;
                @params[0] = new SqlParameter("@rol", rol);
                @params[1] = new SqlParameter("@vista", vista);
                @params[2] = new SqlParameter("@acceso", acceso);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_AccesoVistasPorRol", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_UsuarioById(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_UsuarioById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Upd_Usuario(AspNetUsers modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[4];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);
                @params[1] = new SqlParameter("@nombre", modelo.name);
                @params[2] = new SqlParameter("@rol", modelo.role);
                @params[3] = new SqlParameter("@puesto", modelo.puesto);

                i++;
                if (!bd.ExecuteProcedure(conexion, "upd_Usuario", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Upd_UsuarioActivo(AspNetUsers modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "upd_UsuarioActivo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_UsuarioByName(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_UsuarioByName", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_UsuarioByPuesto(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_UsuarioByPuesto", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_UsuarioByRol(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_UsuarioByRolId", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_UsuarioRol(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_UsuarioRol", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        #region contratos
        public Boolean Ins_Contrato(Contrato modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[20];

                int i = 0;
                @params[i] = new SqlParameter("@titulo", modelo.titulo); i++;
                @params[i] = new SqlParameter("@descripcion", modelo.descripcion); i++;
                @params[i] = new SqlParameter("@inicio_vigencia", modelo.inicio_vigencia.yyyymmdd2); i++;
                @params[i] = new SqlParameter("@termino_contrato", modelo.termino_contrato.yyyymmdd2); i++;
                @params[i] = new SqlParameter("@termino_indefinido", modelo.termino_indefinido); i++;

                @params[i] = new SqlParameter("@proveedor", modelo.proveedor); i++;
                @params[i] = new SqlParameter("@identificador_proveedor", modelo.identificador_proveedor); i++;
                @params[i] = new SqlParameter("@abogado", modelo.abogado); i++;
                @params[i] = new SqlParameter("@abogado_nombre", modelo.abogado_nombre); i++;
                @params[i] = new SqlParameter("@tipo_contrato", modelo.tipo_contrato); i++;

                @params[i] = new SqlParameter("@tipo_contrato_desc", modelo.tipo_contrato_desc); i++;
                @params[i] = new SqlParameter("@negocio", modelo.negocio); i++;
                @params[i] = new SqlParameter("@negocio_desc", modelo.negocio_desc); i++;
                @params[i] = new SqlParameter("@monto", modelo.monto); i++;
                @params[i] = new SqlParameter("@moneda", modelo.moneda); i++;

                @params[i] = new SqlParameter("@moneda_desc", modelo.moneda_desc); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario.id); i++;
                @params[i] = new SqlParameter("@folio", modelo.folio); i++;
                @params[i] = new SqlParameter("@rfc", modelo.rfc); i++;
                @params[i] = new SqlParameter("@confidencial", modelo.confidencial); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "Ins_proc_Contrato", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Upd_Contrato(Contrato modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[21];

                int i = 0;
                @params[i] = new SqlParameter("@id", modelo.id); i++;

                @params[i] = new SqlParameter("@titulo", modelo.titulo); i++;
                @params[i] = new SqlParameter("@descripcion", modelo.descripcion); i++;
                @params[i] = new SqlParameter("@inicio_vigencia", modelo.inicio_vigencia.yyyymmdd2); i++;
                @params[i] = new SqlParameter("@termino_contrato", modelo.termino_contrato.yyyymmdd2); i++;
                @params[i] = new SqlParameter("@termino_indefinido", modelo.termino_indefinido); i++;

                @params[i] = new SqlParameter("@proveedor", modelo.proveedor); i++;
                @params[i] = new SqlParameter("@identificador_proveedor", modelo.identificador_proveedor); i++;
                @params[i] = new SqlParameter("@abogado", modelo.abogado); i++;
                @params[i] = new SqlParameter("@abogado_nombre", modelo.abogado_nombre); i++;
                @params[i] = new SqlParameter("@tipo_contrato", modelo.tipo_contrato); i++;

                @params[i] = new SqlParameter("@tipo_contrato_desc", modelo.tipo_contrato_desc); i++;
                @params[i] = new SqlParameter("@negocio", modelo.negocio); i++;
                @params[i] = new SqlParameter("@negocio_desc", modelo.negocio_desc); i++;
                @params[i] = new SqlParameter("@monto", modelo.monto); i++;
                @params[i] = new SqlParameter("@moneda", modelo.moneda); i++;

                @params[i] = new SqlParameter("@moneda_desc", modelo.moneda_desc); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario.id); i++;
                @params[i] = new SqlParameter("@folio", modelo.folio); i++;
                @params[i] = new SqlParameter("@rfc", modelo.rfc); i++;
                @params[i] = new SqlParameter("@confidencial", modelo.confidencial); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "Upd_proc_Contrato", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_Contrato(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_Contrato", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean INS_proc_CambioEstatusValidacion(CambioEstatusValidacion modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[5];

                int i = 0;
                @params[0] = new SqlParameter("@estatus_nuevo", modelo.estatus_nuevo);
                @params[1] = new SqlParameter("@estatus_anterior", modelo.estatus_anterior);
                @params[2] = new SqlParameter("@contrato", modelo.contrato);
                @params[3] = new SqlParameter("@usuario", modelo.usuario);
                @params[4] = new SqlParameter("@devolucion", modelo.devolucion);

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_CambioEstatusValidacion", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean INS_proc_CambioEstatus(CambioEstatus modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[4];

                int i = 0;
                @params[0] = new SqlParameter("@estatus", modelo.estatus);
                @params[1] = new SqlParameter("@contrato", modelo.contrato);
                @params[2] = new SqlParameter("@usuario", modelo.usuario);

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_CambioEstatus", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean ActualizarEstatusValidacion(int contrato, int estatus, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@contrato", contrato);
                @params[1] = new SqlParameter("@estatus", estatus);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Upd_ContratoEstatusValidacion", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Upd_ContratoEstatusContrato(int contrato, int estatus, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@contrato", contrato);
                @params[1] = new SqlParameter("@estatus", estatus);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Upd_ContratoEstatusContrato", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_ContratoRevision(int contrato, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@contrato", contrato);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_ContratoRevision", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Upd_ContratoComentarioContrato(int contrato, string comentario, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@contrato", contrato);
                @params[1] = new SqlParameter("@comentario", comentario);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Upd_ContratoComentarioContrato", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_ContratoBusqueda(BusquedaContrato modelo, out DataTable dt, out String msgError, out int total)
        {
            bool boolProcess = true;
            DataSet ds = new DataSet();
            dt = new DataTable();
            msgError = string.Empty;
            total = 0;

            try
            {
                SqlParameter[] @params = new SqlParameter[20];

                int i = 0;
                @params[i] = new SqlParameter("@estatus", modelo.estatus); i++;
                @params[i] = new SqlParameter("@abogado", modelo.abogado); i++;
                @params[i] = new SqlParameter("@inicio", modelo.inicio); i++;
                @params[i] = new SqlParameter("@fin", modelo.fin); i++;
                @params[i] = new SqlParameter("@buscar", modelo.buscar); i++;
                
                @params[i] = new SqlParameter("@indefinido", modelo.indefinido); i++;
                @params[i] = new SqlParameter("@confidencial", modelo.confidencial); i++;
                @params[i] = new SqlParameter("@min_monto", modelo.min_monto); i++;
                @params[i] = new SqlParameter("@max_monto", modelo.max_monto); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario); i++;

                @params[i] = new SqlParameter("@dueno", modelo.dueno); i++;
                @params[i] = new SqlParameter("@negocio", modelo.negocio); i++;
                @params[i] = new SqlParameter("@tipocontrato", modelo.tipocontrato); i++;
                @params[i] = new SqlParameter("@folio", modelo.folio); i++;
                @params[i] = new SqlParameter("@rfc", modelo.rfc); i++;
                
                @params[i] = new SqlParameter("@contraparte", modelo.contraparte); i++;
                @params[i] = new SqlParameter("@modificacion", modelo.modificacion); i++;
                @params[i] = new SqlParameter("@prioridad", modelo.prioridad); i++;
                @params[i] = new SqlParameter("@pagina", modelo.pagina); i++;
                @params[i] = new SqlParameter("@cantidad", modelo.cantidad); i++;


                if (!bd.ExecuteProcedure(conexion, "Cons_ContratoBusquedaV3", @params, out ds, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if(ds.Tables.Count < 2)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                    else
                    {
                        dt = ds.Tables[0];
                        Int32.TryParse(ds.Tables[1].Rows[0][0].ToString(), out total);
                    }
                    /*if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }*/
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_ContratoBusquedaDashboard(BusquedaContrato modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[10];

                int i = 0;
                @params[i] = new SqlParameter("@estatus", modelo.estatus); i++;
                @params[i] = new SqlParameter("@abogado", modelo.abogado); i++;
                @params[i] = new SqlParameter("@inicio", modelo.inicio); i++;
                @params[i] = new SqlParameter("@fin", modelo.fin); i++;
                @params[i] = new SqlParameter("@buscar", modelo.buscar); i++;
                @params[i] = new SqlParameter("@indefinido", modelo.indefinido); i++;
                @params[i] = new SqlParameter("@confidencial", modelo.confidencial); i++;
                @params[i] = new SqlParameter("@min_monto", modelo.min_monto); i++;
                @params[i] = new SqlParameter("@max_monto", modelo.max_monto); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_ContratoBusquedaDashboard", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_UsuarioFolios(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[i] = new SqlParameter("@id", id); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_UsuarioFolios", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_UsuarioRFCs(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[i] = new SqlParameter("@id", id); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_UsuarioRFCs", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_UsuarioContrapartes(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[i] = new SqlParameter("@id", id); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_UsuarioContrapartes", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_ContratoById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_ContratoById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        #region EstatusValidacion
        public Boolean Cons_EstatusValidacionById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_EstatusValidacionById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_EstatusValidacion(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {

                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_EstatusValidacion", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion


        #region EstatusContrato
        public Boolean Cons_EstatusContratoById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_EstatusContratoById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_EstatusContrato(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {

                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_EstatusContrato", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        #region Negocio
        public Boolean Cons_NegocioById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_NegocioById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_NegocioFromUsuario(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_NegocioFromUsuario", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_Negocio(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {

                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_Negocio", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean INS_Negocio(Negocio modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[3];

                int i = 0;
                @params[0] = new SqlParameter("@nombre", modelo.nombre);
                @params[1] = new SqlParameter("@descripcion", modelo.descripcion);
                @params[2] = new SqlParameter("@rfc", modelo.rfc);

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_Negocio", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_Negocio(Negocio modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[4];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);
                @params[1] = new SqlParameter("@nombre", modelo.nombre);
                @params[2] = new SqlParameter("@descripcion", modelo.descripcion);
                @params[3] = new SqlParameter("@rfc", modelo.rfc);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_cat_Negocio", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_Negocio_Activo(Negocio modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_cat_Negocio_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_proc_AccesoUsuarioNegocioFromUsuario(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_proc_AccesoUsuarioNegocioFromUsuario", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_AccesoUsuarioNegocio(string usuario, int negocio, int acceso, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[3];

                int i = 0;
                @params[0] = new SqlParameter("@usuario", usuario);
                @params[1] = new SqlParameter("@negocio", negocio);
                @params[2] = new SqlParameter("@acceso", acceso);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_AccesoUsuarioNegocio", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_RLUsuarioNegocio(proc_RLUsuarioNegocio modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@usuario", modelo.usuario);
                @params[1] = new SqlParameter("@negocio", modelo.negocio);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_RLUsuarioNegocio", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        #region NegocioPI
        public Boolean Cons_NegocioPIById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_NegocioPIById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_NegocioPIFromUsuario(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_NegocioPIFromUsuario", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_NegocioPI(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {

                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_NegocioPI", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean INS_NegocioPI(NegocioPI modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[3];

                int i = 0;
                @params[0] = new SqlParameter("@nombre", modelo.nombre);
                @params[1] = new SqlParameter("@descripcion", modelo.descripcion);
                @params[2] = new SqlParameter("@rfc", modelo.rfc);

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_cat_NegocioPI", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_NegocioPI(NegocioPI modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[4];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);
                @params[1] = new SqlParameter("@nombre", modelo.nombre);
                @params[2] = new SqlParameter("@descripcion", modelo.descripcion);
                @params[3] = new SqlParameter("@rfc", modelo.rfc);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_cat_NegocioPI", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_NegocioPI_Activo(NegocioPI modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_cat_NegocioPI_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        #endregion
        #region TipoContrato
        public Boolean Cons_TipoContratoById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_TipoContratoById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_TipoContratoFromUsuario(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_TipoContratoFromUsuario", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_TipoContrato(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {

                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_TipoContrato", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean INS_TipoContrato(TipoContrato modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@nombre", modelo.nombre);
                @params[1] = new SqlParameter("@descripcion", modelo.descripcion);

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_TipoContrato", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_TipoContrato(TipoContrato modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[3];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);
                @params[1] = new SqlParameter("@nombre", modelo.nombre);
                @params[2] = new SqlParameter("@descripcion", modelo.descripcion);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_cat_TipoContrato", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_TipoContrato_Activo(TipoContrato modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_cat_TipoContrato_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        #region Moneda
        public Boolean Cons_MonedaById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_MonedaById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_MonedaByNombre(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_MonedaByNombre", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_Moneda(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_Moneda", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean INS_cat_Moneda(Moneda modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@clave_sat", modelo.clave_sat);
                @params[1] = new SqlParameter("@descripcion", modelo.descripcion);

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_cat_Moneda", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_cat_Moneda(Moneda modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[3];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);
                @params[1] = new SqlParameter("@clave_sat", modelo.clave_sat);
                @params[2] = new SqlParameter("@descripcion", modelo.descripcion);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_cat_Moneda", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_cat_Moneda_Activo(Moneda modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_cat_Moneda_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        #region Documento
        public Boolean cons_DocumentacionProv(string rfc, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@rfc", rfc);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_DocumentacionProv", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean INS_DocumentoContrato(DocumentoContrato modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[10];

                int i = 0;
                @params[i] = new SqlParameter("@usuario", modelo.usuario.id); i++;
                @params[i] = new SqlParameter("@contrato", modelo.contrato); i++;
                @params[i] = new SqlParameter("@file_nombre", modelo.file_nombre); i++;
                @params[i] = new SqlParameter("@file_data", modelo.file_data); i++;
                @params[i] = new SqlParameter("@file_content_type", modelo.file_content_type); i++;
                @params[i] = new SqlParameter("@file_size", modelo.file_size); i++;
                @params[i] = new SqlParameter("@tipo", modelo.tipo); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@file_extension", modelo.file_extension); i++;
                @params[i] = new SqlParameter("@file_url", modelo.url); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_DocumentoContrato", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_DocumentoClienteRFCExiste(string rfc, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[10];

                int i = 0;
                @params[i] = new SqlParameter("@rfc", rfc); i++;
                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_DocumentoClienteRFCExiste", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean INS_DocumentoCliente(DocumentoCliente modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[11];

                int i = 0;
                @params[i] = new SqlParameter("@usuario", modelo.usuario.id); i++;
                @params[i] = new SqlParameter("@contrato", modelo.contrato); i++;
                @params[i] = new SqlParameter("@file_nombre", modelo.file_nombre); i++;
                @params[i] = new SqlParameter("@file_data", modelo.file_data); i++;
                @params[i] = new SqlParameter("@file_content_type", modelo.file_content_type); i++;
                @params[i] = new SqlParameter("@file_size", modelo.file_size); i++;
                @params[i] = new SqlParameter("@tipo", modelo.tipo); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@file_extension", modelo.file_extension); i++;
                @params[i] = new SqlParameter("@file_url", modelo.url); i++;
                @params[i] = new SqlParameter("@rfc", modelo.rfc); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_DocumentoCliente", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean INS_DocumentoContratoCliente(DocumentoContrato modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[9];

                int i = 0;
                @params[i] = new SqlParameter("@usuario", modelo.usuario.id); i++;
                @params[i] = new SqlParameter("@contrato", modelo.contrato); i++;
                @params[i] = new SqlParameter("@file_nombre", modelo.file_nombre); i++;
                @params[i] = new SqlParameter("@file_data", modelo.file_data); i++;
                @params[i] = new SqlParameter("@file_content_type", modelo.file_content_type); i++;
                @params[i] = new SqlParameter("@file_size", modelo.file_size); i++;
                @params[i] = new SqlParameter("@tipo", modelo.tipo); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@file_extension", modelo.file_extension); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_DocumentoContratoCliente", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_DocumentoContratoTipo(DocumentoContrato modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[i] = new SqlParameter("@id", modelo.id); i++;
                @params[i] = new SqlParameter("@tipo", modelo.tipo); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_DocumentoContratoTipo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean DEL_DocumentoContrato(DocumentoContrato modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[3];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);
                @params[1] = new SqlParameter("@contrato", modelo.contrato);
                @params[2] = new SqlParameter("@tipo_archivo", modelo.tipo_archivo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "DEL_proc_DocumentoContrato", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean DEL_DocumentoCliente(DocumentoCliente modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[3];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "DEL_proc_DocumentoCliente", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean DEL_DocumentosContrato(int contrato, int tipo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[3];

                int i = 0;
                @params[0] = new SqlParameter("@contrato", contrato);
                @params[1] = new SqlParameter("@tipo_archivo", tipo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "DEL_proc_DocumentosContrato", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean CONS_DocumentoContratoById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_DocumentoContratoById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_DocumentoClienteById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_DocumentoClienteById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_DocumentoContratoFromId(int id, string tipo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);
                @params[1] = new SqlParameter("@tipo", tipo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_DocumentoContratoFromId", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_DocumentoClienteFromId(string id, string tipo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);
                @params[1] = new SqlParameter("@tipo", tipo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_DocumentoClienteFromId", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean CONS_DocumentoContratoFromIdVersionamiento(int id, int tipo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);
                @params[1] = new SqlParameter("@tipo", tipo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_DocumentoContratoFromIdVersionamiento", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Upd_DocumentoContratoCarga(DocumentoContrato modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[7];

                int i = 0;
                @params[i] = new SqlParameter("@id", modelo.id); i++;
                @params[i] = new SqlParameter("@tipo_archivo", modelo.tipo_archivo.id); i++;
                @params[i] = new SqlParameter("@versionamiento", modelo.versionamiento); i++;
                @params[i] = new SqlParameter("@contrato", modelo.contrato); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "Upd_DocumentoContratoCarga", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        #region Documento Comentario
        public Boolean INS_DocumentoComentario(DocumentoComentario modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[7];

                int i = 0;
                @params[i] = new SqlParameter("@usuario", modelo.usuario.id); i++;
                @params[i] = new SqlParameter("@contrato", modelo.contrato); i++;
                @params[i] = new SqlParameter("@documento", modelo.documento); i++;
                @params[i] = new SqlParameter("@descripcion", modelo.descripcion); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_DocumentoComentario", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean DEL_DocumentoComentario(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "DEL_DocumentoComentario", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_DocumentoComentarioById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_DocumentoComentarioById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_DocumentoComentarioFromId(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_DocumentoComentarioFromId", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        #endregion

        #region Comentario Contrato
        public Boolean INS_ComentarioContrato(ComentarioContrato modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[7];

                int i = 0;
                @params[i] = new SqlParameter("@usuario", modelo.usuario.id); i++;
                @params[i] = new SqlParameter("@contrato", modelo.contrato); i++;
                @params[i] = new SqlParameter("@descripcion", modelo.descripcion); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_ComentarioContrato", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean DEL_ComentarioContrato(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "DEL_proc_ComentarioContrato", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_ComentarioContratoById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_ComentarioContratoById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_ComentarioContratoFromId(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_ComentarioContratoFromId", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        #endregion

        #region Comentario Contrato
        public Boolean INS_ColaboradorContrato(ColaboradorContrato modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[7];

                int i = 0;
                @params[i] = new SqlParameter("@usuario", modelo.usuario.id); i++;
                @params[i] = new SqlParameter("@contrato", modelo.contrato); i++;
                //@params[i] = new SqlParameter("@descripcion", modelo.descripcion); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_ColaboradorContrato", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }


        public Boolean INS_ColaboradorContratoIf(ColaboradorContrato modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[7];

                int i = 0;
                @params[i] = new SqlParameter("@usuario", modelo.usuario.id); i++;
                @params[i] = new SqlParameter("@contrato", modelo.contrato); i++;
                //@params[i] = new SqlParameter("@descripcion", modelo.descripcion); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_ColaboradorContratoIf", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_ColaboradorEsColaborador(ColaboradorContrato modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[7];

                int i = 0;
                @params[i] = new SqlParameter("@usuario", modelo.usuario.id); i++;
                @params[i] = new SqlParameter("@contrato", modelo.contrato); i++;
                //@params[i] = new SqlParameter("@descripcion", modelo.descripcion); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_ColaboradorEsColaborador", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_Indicadores(string id, string inicio, string fin, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[3];

                int i = 0;
                @params[i] = new SqlParameter("@usuario", id); i++;
                @params[i] = new SqlParameter("@inicio", inicio); i++;
                @params[i] = new SqlParameter("@fin", fin); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_IndicadoresPorTiempoV2", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_ColaboradorContrato(ColaboradorContrato modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[7];

                int i = 0;
                @params[i] = new SqlParameter("@usuario", modelo.usuario.id); i++;
                @params[i] = new SqlParameter("@id", modelo.id); i++;
                //@params[i] = new SqlParameter("@descripcion", modelo.descripcion); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_ColaboradorContrato", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_ColaboradorContratoResetEstatus(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[i] = new SqlParameter("@id", id); i++;
                //@params[i] = new SqlParameter("@descripcion", modelo.descripcion); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_ColaboradorContratoResetEstatus", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_ColaboradorContratoEstatus(ColaboradorContrato modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[7];

                int i = 0;
                @params[i] = new SqlParameter("@id", modelo.id); i++;
                @params[i] = new SqlParameter("@estatus", modelo.aprobado); i++;
                @params[i] = new SqlParameter("@descripcion", modelo.descripcion); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_ColaboradorContratoEstatus", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }


        public Boolean DEL_ColaboradorContrato(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "DEL_proc_ColaboradorContrato", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_ColaboradorContratoById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_ColaboradorContratoById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_ColaboradorContratoFromId(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_ColaboradorContratoFromId", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        #endregion

        #region Recordatorio Contrato
        public Boolean INS_RecordatorioContrato(RecordatorioContrato modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[7];

                int i = 0;
                @params[i] = new SqlParameter("@usuario", modelo.usuario.id); i++;
                @params[i] = new SqlParameter("@contrato", modelo.contrato); i++;
                @params[i] = new SqlParameter("@asignado", modelo.asignado.id); i++;
                @params[i] = new SqlParameter("@fecha_recordatorio", modelo.FR_d); i++;
                @params[i] = new SqlParameter("@descripcion", modelo.descripcion); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_RecordatorioContrato", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean DEL_RecordatorioContrato(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "DEL_proc_RecordatorioContrato", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_RecordatorioContratoById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_RecordatorioContratoById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_RecordatorioContratoFromId(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_RecordatorioContratoFromId", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        #endregion

        #region TipoCatalogo
        public Boolean Cons_TipoCatalogoById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_TipoCatalogoById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_TipoCatalogoFromUsuario(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_TipoCatalogoFromUsuario", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_TipoCatalogo(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {

                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_TipoCatalogo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean INS_TipoCatalogo(TipoCatalogo modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[3];

                int i = 0;
                @params[0] = new SqlParameter("@nombre", modelo.nombre);
                @params[1] = new SqlParameter("@descripcion", modelo.descripcion);

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_cat_TipoCatalogo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_TipoCatalogo(TipoCatalogo modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[4];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);
                @params[1] = new SqlParameter("@nombre", modelo.nombre);
                @params[2] = new SqlParameter("@descripcion", modelo.descripcion);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_cat_TipoCatalogo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_TipoCatalogo_Activo(TipoCatalogo modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_cat_TipoCatalogo_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        #region Pais
        public Boolean Cons_PaisById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_PaisById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_PaisFromUsuario(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_PaisFromUsuario", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_Pais(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {

                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_Pais", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean INS_Pais(Pais modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[3];

                int i = 0;
                @params[0] = new SqlParameter("@nombre", modelo.nombre);
                @params[1] = new SqlParameter("@descripcion", modelo.descripcion);

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_cat_Pais", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_Pais(Pais modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[4];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);
                @params[1] = new SqlParameter("@nombre", modelo.nombre);
                @params[2] = new SqlParameter("@descripcion", modelo.descripcion);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_cat_Pais", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_Pais_Activo(Pais modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_cat_Pais_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        #region Marca
        public Boolean Cons_proc_MarcaById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_proc_MarcaById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_proc_Marca(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_proc_Marca", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean INS_proc_Marca(Marca modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[13];

                int i = 0;
                @params[i] = new SqlParameter("@tipo_solicitud", modelo.tipo_solicitud); i++;
                @params[i] = new SqlParameter("@tipo_solicitud_nombre", modelo.tipo_solicitud_nombre); i++;
                @params[i] = new SqlParameter("@empresa", modelo.empresa); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@tipo", modelo.tipo); i++;
                @params[i] = new SqlParameter("@pais", modelo.pais); i++;
                @params[i] = new SqlParameter("@productos", modelo.productos); i++;

                @params[i] = new SqlParameter("@fecha_uso", modelo.fecha_usoS); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario); i++;
                @params[i] = new SqlParameter("@empresa_nombre", modelo.empresa_nombre); i++;
                @params[i] = new SqlParameter("@tipo_nombre", modelo.tipo_nombre); i++;
                @params[i] = new SqlParameter("@pais_nombre", modelo.pais_nombre); i++;

                @params[i] = new SqlParameter("@identificador", modelo.identificador); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_Marca", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_Marca(Marca modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[12];

                int i = 0;
                @params[i] = new SqlParameter("@id", modelo.id); i++;

                @params[i] = new SqlParameter("@empresa", modelo.empresa); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@tipo", modelo.tipo); i++;
                @params[i] = new SqlParameter("@pais", modelo.pais); i++;
                @params[i] = new SqlParameter("@productos", modelo.productos); i++;

                @params[i] = new SqlParameter("@fecha_uso", modelo.fecha_usoS); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario); i++;
                @params[i] = new SqlParameter("@empresa_nombre", modelo.empresa_nombre); i++;
                @params[i] = new SqlParameter("@tipo_nombre", modelo.tipo_nombre); i++;
                @params[i] = new SqlParameter("@pais_nombre", modelo.pais_nombre); i++;

                @params[i] = new SqlParameter("@identificador", modelo.identificador); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_Marca", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_Marca_Activo(Marca modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_Marca_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        #region RegistroMarca Comentario
        public Boolean INS_RegistroMarcaComentario(RegistroMarcaComentario modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[7];

                int i = 0;
                @params[i] = new SqlParameter("@usuario", modelo.usuario.id); i++;
                @params[i] = new SqlParameter("@registro_marca", modelo.registro_marca); i++;
                @params[i] = new SqlParameter("@tipo_comentario", modelo.tipo_comentario); i++;
                @params[i] = new SqlParameter("@descripcion", modelo.descripcion); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_RegistroMarcaComentario", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean DEL_RegistroMarcaComentario(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "DEL_proc_RegistroMarcaComentario", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_RegistroMarcaComentarioById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_RegistroMarcaComentarioById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_RegistroMarcaComentarioFromId(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_RegistroMarcaComentarioFromId", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        #endregion

        #region RegistroMarca
        public Boolean Cons_proc_RegistroMarcaById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_proc_RegistroMarcaById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_proc_RegistroMarca(out DataTable dt, out String msgError, int tipo_registro, int activo = -1)
        {
            
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);
                i++;
                @params[1] = new SqlParameter("@tipo_registro", tipo_registro);
                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_proc_RegistroMarca", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean INS_proc_RegistroMarca(RegistroMarca modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[68];

                int i = 0;
                //@params[i] = new SqlParameter("@id", modelo.id); i++;
                @params[i] = new SqlParameter("@empresa", modelo.empresa); i++;
                @params[i] = new SqlParameter("@empresa_desc", modelo.empresa_desc); i++;
                @params[i] = new SqlParameter("@empresa_anterior", modelo.empresa_anterior); i++;
                @params[i] = new SqlParameter("@empresa_anterior_desc", modelo.empresa_anterior_desc); i++;

                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@no_registro", modelo.no_registro); i++;
                @params[i] = new SqlParameter("@titulo", modelo.titulo); i++;
                @params[i] = new SqlParameter("@fecha_legal", modelo.fecha_legal); i++;
                @params[i] = new SqlParameter("@fecha_vencimiento", modelo.fecha_vencimiento); i++;

                @params[i] = new SqlParameter("@fecha_concesion", modelo.fecha_concesion); i++;
                @params[i] = new SqlParameter("@clase", modelo.clase); i++;
                @params[i] = new SqlParameter("@clase_desc", modelo.clase_desc); i++;
                @params[i] = new SqlParameter("@tipo_registro", modelo.tipo_registro); i++;
                @params[i] = new SqlParameter("@tipo_registro_desc", modelo.tipo_registro_desc); i++;

                @params[i] = new SqlParameter("@pais", modelo.pais); i++;
                @params[i] = new SqlParameter("@pais_desc", modelo.pais_desc); i++;
                @params[i] = new SqlParameter("@estatus", modelo.estatus); i++;
                @params[i] = new SqlParameter("@estatus_desc", modelo.estatus_desc); i++;
                //@params[i] = new SqlParameter("@solicitud_nombre", modelo.solicitud_nombre); i++;
                //@params[i] = new SqlParameter("@solicitud_data", modelo.solicitud_data); i++;
                //@params[i] = new SqlParameter("@solicitud_content_type", modelo.solicitud_content_type); i++;
                //@params[i] = new SqlParameter("@solicitud_size", modelo.solicitud_size); i++;
                //@params[i] = new SqlParameter("@solicitud_extension", modelo.solicitud_extension); i++;
                //@params[i] = new SqlParameter("@solicitud_nombre_original", modelo.solicitud_nombre_original); i++;
                //@params[i] = new SqlParameter("@solicitud_url", modelo.solicitud_url); i++;
                @params[i] = new SqlParameter("@no_solicitud", modelo.no_solicitud); i++;

                @params[i] = new SqlParameter("@tipo_registro_solicitud", modelo.tipo_registro_solicitud); i++;
                @params[i] = new SqlParameter("@tipo_registro_solicitud_desc", modelo.tipo_registro_solicitud_desc); i++;
                @params[i] = new SqlParameter("@autor_registro", modelo.autor_registro); i++;
                @params[i] = new SqlParameter("@autor_registro_desc", modelo.autor_registro_desc); i++;
                @params[i] = new SqlParameter("@despacho", modelo.despacho); i++;

                @params[i] = new SqlParameter("@despacho_desc", modelo.despacho_desc); i++;
                @params[i] = new SqlParameter("@corresponsal", modelo.corresponsal); i++;
                @params[i] = new SqlParameter("@corresponsal_desc", modelo.corresponsal_desc); i++;
                @params[i] = new SqlParameter("@solicitante_licencia", modelo.solicitante_licencia); i++;
                @params[i] = new SqlParameter("@solicitante_licencia_desc", modelo.solicitante_licencia_desc); i++;

                @params[i] = new SqlParameter("@licencia", modelo.licencia); i++;
                @params[i] = new SqlParameter("@licencia_desc", modelo.licencia_desc); i++;
                @params[i] = new SqlParameter("@solicitante_cesion", modelo.solicitante_cesion); i++;
                @params[i] = new SqlParameter("@solicitante_cesion_desc", modelo.solicitante_cesion_desc); i++;
                @params[i] = new SqlParameter("@cesion", modelo.cesion); i++;

                @params[i] = new SqlParameter("@cesion_desc", modelo.cesion_desc); i++;
                @params[i] = new SqlParameter("@fecha_requerimiento", modelo.fecha_requerimiento); i++;
                @params[i] = new SqlParameter("@fecha_requerimiento_completo", modelo.fecha_requerimiento_completo); i++;
                @params[i] = new SqlParameter("@fecha_instrucciones", modelo.fecha_instrucciones); i++;
                @params[i] = new SqlParameter("@fecha_instrucciones_completo", modelo.fecha_instrucciones_completo); i++;

                @params[i] = new SqlParameter("@fecha_registro", modelo.fecha_registro); i++;
                @params[i] = new SqlParameter("@fecha_registro_completo", modelo.fecha_registro_completo); i++;
                @params[i] = new SqlParameter("@fecha_busqueda", modelo.fecha_busqueda); i++;
                @params[i] = new SqlParameter("@fecha_busqueda_completo", modelo.fecha_busqueda_completo); i++;
                @params[i] = new SqlParameter("@fecha_resultados", modelo.fecha_resultados); i++;

                @params[i] = new SqlParameter("@fecha_resultados_completo", modelo.fecha_resultados_completo); i++;
                @params[i] = new SqlParameter("@fecha_comprobacion", modelo.fecha_comprobacion); i++;
                @params[i] = new SqlParameter("@fecha_comprobacion_completo", modelo.fecha_comprobacion_completo); i++;
                @params[i] = new SqlParameter("@fecha_vencimiento_workflow", modelo.fecha_vencimiento_workflow); i++;
                @params[i] = new SqlParameter("@fecha_vencimiento_workflow_completo", modelo.fecha_vencimiento_workflow_completo); i++;

                @params[i] = new SqlParameter("@fecha_concesion_workflow", modelo.fecha_concesion_workflow); i++;
                @params[i] = new SqlParameter("@fecha_concesion_workflow_completo", modelo.fecha_concesion_workflow_completo); i++;
                @params[i] = new SqlParameter("@fecha_declaracion", modelo.fecha_declaracion); i++;
                @params[i] = new SqlParameter("@fecha_declaracion_completo", modelo.fecha_declaracion_completo); i++;
                //@params[i] = new SqlParameter("@fc", modelo.fc); i++;
                //@params[i] = new SqlParameter("@fu", modelo.fu); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario); i++;
                @params[i] = new SqlParameter("@usuario_desc", modelo.usuario_desc); i++;
                //@params[i] = new SqlParameter("@activo", modelo.activo); i++;
                @params[i] = new SqlParameter("@solicitud", modelo.solicitud); i++;
                @params[i] = new SqlParameter("@solicitud_desc", modelo.solicitud_desc); i++;
                @params[i] = new SqlParameter("@solicitud_tipo", modelo.solicitud_tipo); i++;
                @params[i] = new SqlParameter("@solicitud_tipo_desc", modelo.solicitud_tipo_desc); i++;
                @params[i] = new SqlParameter("@uso", modelo.uso); i++;
                @params[i] = new SqlParameter("@uso_desc", modelo.uso_desc); i++;
                @params[i] = new SqlParameter("@fecha_quinquenio_anualidad", modelo.fecha_quinquenio_anualidad); i++;
                @params[i] = new SqlParameter("@tipo_pago", modelo.tipo_pago); i++;
                @params[i] = new SqlParameter("@tipo_pago_desc", modelo.tipo_pago_desc); i++;
                @params[i] = new SqlParameter("@prioridad", modelo.prioridad); i++;
                @params[i] = new SqlParameter("@fecha_vencimiento_prioridad", modelo.fecha_vencimiento_prioridad); i++;
                @params[i] = new SqlParameter("@autor", modelo.autor); i++;
                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_RegistroMarca", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_RegistroMarca(RegistroMarca modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[82];

                int i = 0;
                @params[i] = new SqlParameter("@id", modelo.id); i++;
                @params[i] = new SqlParameter("@empresa", modelo.empresa); i++;
                @params[i] = new SqlParameter("@empresa_desc", modelo.empresa_desc); i++;
                @params[i] = new SqlParameter("@empresa_anterior", modelo.empresa_anterior); i++;
                @params[i] = new SqlParameter("@empresa_anterior_desc", modelo.empresa_anterior_desc); i++;

                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@no_registro", modelo.no_registro); i++;
                @params[i] = new SqlParameter("@titulo", modelo.titulo); i++;
                @params[i] = new SqlParameter("@fecha_legal", modelo.fecha_legal); i++;
                @params[i] = new SqlParameter("@fecha_vencimiento", modelo.fecha_vencimiento); i++;

                @params[i] = new SqlParameter("@fecha_concesion", modelo.fecha_concesion); i++;
                @params[i] = new SqlParameter("@clase", modelo.clase); i++;
                @params[i] = new SqlParameter("@clase_desc", modelo.clase_desc); i++;
                @params[i] = new SqlParameter("@tipo_registro", modelo.tipo_registro); i++;
                @params[i] = new SqlParameter("@tipo_registro_desc", modelo.tipo_registro_desc); i++;

                @params[i] = new SqlParameter("@pais", modelo.pais); i++;
                @params[i] = new SqlParameter("@pais_desc", modelo.pais_desc); i++;
                @params[i] = new SqlParameter("@estatus", modelo.estatus); i++;
                @params[i] = new SqlParameter("@estatus_desc", modelo.estatus_desc); i++;
                //@params[i] = new SqlParameter("@solicitud_nombre", modelo.solicitud_nombre); i++;
                //@params[i] = new SqlParameter("@solicitud_data", modelo.solicitud_data); i++;
                //@params[i] = new SqlParameter("@solicitud_content_type", modelo.solicitud_content_type); i++;
                //@params[i] = new SqlParameter("@solicitud_size", modelo.solicitud_size); i++;
                //@params[i] = new SqlParameter("@solicitud_extension", modelo.solicitud_extension); i++;
                //@params[i] = new SqlParameter("@solicitud_nombre_original", modelo.solicitud_nombre_original); i++;
                //@params[i] = new SqlParameter("@solicitud_url", modelo.solicitud_url); i++;
                @params[i] = new SqlParameter("@no_solicitud", modelo.no_solicitud); i++;

                @params[i] = new SqlParameter("@tipo_registro_solicitud", modelo.tipo_registro_solicitud); i++;
                @params[i] = new SqlParameter("@tipo_registro_solicitud_desc", modelo.tipo_registro_solicitud_desc); i++;
                @params[i] = new SqlParameter("@autor_registro", modelo.autor_registro); i++;
                @params[i] = new SqlParameter("@autor_registro_desc", modelo.autor_registro_desc); i++;
                @params[i] = new SqlParameter("@despacho", modelo.despacho); i++;

                @params[i] = new SqlParameter("@despacho_desc", modelo.despacho_desc); i++;
                @params[i] = new SqlParameter("@corresponsal", modelo.corresponsal); i++;
                @params[i] = new SqlParameter("@corresponsal_desc", modelo.corresponsal_desc); i++;
                @params[i] = new SqlParameter("@solicitante_licencia", modelo.solicitante_licencia); i++;
                @params[i] = new SqlParameter("@solicitante_licencia_desc", modelo.solicitante_licencia_desc); i++;

                @params[i] = new SqlParameter("@licencia", modelo.licencia); i++;
                @params[i] = new SqlParameter("@licencia_desc", modelo.licencia_desc); i++;
                @params[i] = new SqlParameter("@solicitante_cesion", modelo.solicitante_cesion); i++;
                @params[i] = new SqlParameter("@solicitante_cesion_desc", modelo.solicitante_cesion_desc); i++;
                @params[i] = new SqlParameter("@cesion", modelo.cesion); i++;

                @params[i] = new SqlParameter("@cesion_desc", modelo.cesion_desc); i++;
                @params[i] = new SqlParameter("@fecha_requerimiento", modelo.fecha_requerimiento); i++;
                @params[i] = new SqlParameter("@fecha_requerimiento_completo", modelo.fecha_requerimiento_completo); i++;
                @params[i] = new SqlParameter("@fecha_instrucciones", modelo.fecha_instrucciones); i++;
                @params[i] = new SqlParameter("@fecha_instrucciones_completo", modelo.fecha_instrucciones_completo); i++;

                @params[i] = new SqlParameter("@fecha_registro", modelo.fecha_registro); i++;
                @params[i] = new SqlParameter("@fecha_registro_completo", modelo.fecha_registro_completo); i++;
                @params[i] = new SqlParameter("@fecha_busqueda", modelo.fecha_busqueda); i++;
                @params[i] = new SqlParameter("@fecha_busqueda_completo", modelo.fecha_busqueda_completo); i++;
                @params[i] = new SqlParameter("@fecha_resultados", modelo.fecha_resultados); i++;

                @params[i] = new SqlParameter("@fecha_resultados_completo", modelo.fecha_resultados_completo); i++;
                @params[i] = new SqlParameter("@fecha_comprobacion", modelo.fecha_comprobacion); i++;
                @params[i] = new SqlParameter("@fecha_comprobacion_completo", modelo.fecha_comprobacion_completo); i++;
                @params[i] = new SqlParameter("@fecha_vencimiento_workflow", modelo.fecha_vencimiento_workflow); i++;
                @params[i] = new SqlParameter("@fecha_vencimiento_workflow_completo", modelo.fecha_vencimiento_workflow_completo); i++;

                @params[i] = new SqlParameter("@fecha_concesion_workflow", modelo.fecha_concesion_workflow); i++;
                @params[i] = new SqlParameter("@fecha_concesion_workflow_completo", modelo.fecha_concesion_workflow_completo); i++;
                @params[i] = new SqlParameter("@fecha_declaracion", modelo.fecha_declaracion); i++;
                @params[i] = new SqlParameter("@fecha_declaracion_completo", modelo.fecha_declaracion_completo); i++;
                //@params[i] = new SqlParameter("@fc", modelo.fc); i++;
                //@params[i] = new SqlParameter("@fu", modelo.fu); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario); i++;
                @params[i] = new SqlParameter("@usuario_desc", modelo.usuario_desc); i++;
                //@params[i] = new SqlParameter("@activo", modelo.activo); i++;
                @params[i] = new SqlParameter("@solicitud", modelo.solicitud); i++;
                @params[i] = new SqlParameter("@solicitud_desc", modelo.solicitud_desc); i++;
                @params[i] = new SqlParameter("@solicitud_tipo", modelo.solicitud_tipo); i++;
                @params[i] = new SqlParameter("@solicitud_tipo_desc", modelo.solicitud_tipo_desc); i++;
                @params[i] = new SqlParameter("@notificacion_titulo", modelo.notificacion_titulo); i++;
                @params[i] = new SqlParameter("@notificacion_vencimiento", modelo.notificacion_vencimiento); i++;

                @params[i] = new SqlParameter("@fecha_renovar", modelo.fecha_renovar); i++;
                @params[i] = new SqlParameter("@fecha_renovar_completo", modelo.fecha_renovar_completo); i++;
                @params[i] = new SqlParameter("@fecha_instruccion_corresponsal", modelo.fecha_instruccion_corresponsal); i++;
                @params[i] = new SqlParameter("@fecha_instruccion_corresponsal_completo", modelo.fecha_instruccion_corresponsal_completo); i++;
                @params[i] = new SqlParameter("@fecha_solicitud_empresa", modelo.fecha_solicitud_empresa); i++;
                @params[i] = new SqlParameter("@fecha_solicitud_empresa_completo", modelo.fecha_solicitud_empresa_completo); i++;
                @params[i] = new SqlParameter("@fecha_despacho", modelo.fecha_despacho); i++;
                @params[i] = new SqlParameter("@fecha_despacho_completo", modelo.fecha_despacho_completo); i++;
                @params[i] = new SqlParameter("@oficio_completo", modelo.oficio_completo); i++;
                @params[i] = new SqlParameter("@renovacion", modelo.renovacion); i++;
                @params[i] = new SqlParameter("@uso", modelo.uso); i++;
                @params[i] = new SqlParameter("@uso_desc", modelo.uso_desc); i++;
                @params[i] = new SqlParameter("@fecha_quinquenio_anualidad", modelo.fecha_quinquenio_anualidad); i++;
                @params[i] = new SqlParameter("@tipo_pago", modelo.tipo_pago); i++;
                @params[i] = new SqlParameter("@tipo_pago_desc", modelo.tipo_pago_desc); i++;
                @params[i] = new SqlParameter("@prioridad", modelo.prioridad); i++;
                @params[i] = new SqlParameter("@fecha_vencimiento_prioridad", modelo.fecha_vencimiento_prioridad); i++;
                @params[i] = new SqlParameter("@autor", modelo.autor); i++;
                @params[i] = new SqlParameter("@nueva_fecha_vencimiento", modelo.nueva_fecha_vencimiento); i++;
                @params[i] = new SqlParameter("@notificacion_estatus", modelo.notificacion_estatus); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_RegistroMarca", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_RegistroMarcaDocumento(RegistroMarca modelo, int tipo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[12];

                int i = 0;
                @params[i] = new SqlParameter("@id", modelo.id); i++;

                @params[i] = new SqlParameter("@solicitud_nombre", modelo.solicitud_nombre); i++;
                //@params[i] = new SqlParameter("@solicitud_data", modelo.solicitud_data); i++;
                @params[i] = new SqlParameter("@solicitud_content_type", modelo.solicitud_content_type); i++;
                @params[i] = new SqlParameter("@solicitud_size", modelo.solicitud_size); i++;
                @params[i] = new SqlParameter("@solicitud_extension", modelo.solicitud_extension); i++;

                @params[i] = new SqlParameter("@solicitud_nombre_original", modelo.solicitud_nombre_original); i++;
                @params[i] = new SqlParameter("@solicitud_url", modelo.solicitud_url); i++;
                @params[i] = new SqlParameter("@tipo", tipo); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_RegistroMarcaDocumento", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_RegistroMarca_Activo(RegistroMarca modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_RegistroMarca_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_RegistroMarca_VoBo(RegistroMarca modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);
                @params[1] = new SqlParameter("@vobo", modelo.vobo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_RegistroMarca_VoBo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        #region AvisoComercial
        public Boolean Cons_proc_AvisoComercialById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_proc_AvisoComercialById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_proc_AvisoComercial(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_proc_AvisoComercial", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean INS_proc_AvisoComercial(AvisoComercial modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[13];

                int i = 0;
                @params[i] = new SqlParameter("@tipo_solicitud", modelo.tipo_solicitud); i++;
                @params[i] = new SqlParameter("@tipo_solicitud_nombre", modelo.tipo_solicitud_nombre); i++;
                @params[i] = new SqlParameter("@empresa", modelo.empresa); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@tipo", modelo.tipo); i++;
                @params[i] = new SqlParameter("@pais", modelo.pais); i++;
                @params[i] = new SqlParameter("@productos", modelo.productos); i++;

                @params[i] = new SqlParameter("@fecha_uso", modelo.fecha_usoS); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario); i++;
                @params[i] = new SqlParameter("@empresa_nombre", modelo.empresa_nombre); i++;
                @params[i] = new SqlParameter("@tipo_nombre", modelo.tipo_nombre); i++;
                @params[i] = new SqlParameter("@pais_nombre", modelo.pais_nombre); i++;

                @params[i] = new SqlParameter("@identificador", modelo.identificador); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_AvisoComercial", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_AvisoComercial(AvisoComercial modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[12];

                int i = 0;
                @params[i] = new SqlParameter("@id", modelo.id); i++;

                @params[i] = new SqlParameter("@empresa", modelo.empresa); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@tipo", modelo.tipo); i++;
                @params[i] = new SqlParameter("@pais", modelo.pais); i++;
                @params[i] = new SqlParameter("@productos", modelo.productos); i++;

                @params[i] = new SqlParameter("@fecha_uso", modelo.fecha_usoS); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario); i++;
                @params[i] = new SqlParameter("@empresa_nombre", modelo.empresa_nombre); i++;
                @params[i] = new SqlParameter("@tipo_nombre", modelo.tipo_nombre); i++;
                @params[i] = new SqlParameter("@pais_nombre", modelo.pais_nombre); i++;

                @params[i] = new SqlParameter("@identificador", modelo.identificador); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_AvisoComercial", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_AvisoComercial_Activo(AvisoComercial modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_AvisoComercial_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion


        #region Patente
        public Boolean Cons_proc_PatenteById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_proc_PatenteById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_proc_Patente(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_proc_Patente", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean INS_proc_Patente(Patente modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[19];

                int i = 0;
                @params[i] = new SqlParameter("@tipo_solicitud", modelo.tipo_solicitud); i++;
                @params[i] = new SqlParameter("@tipo_solicitud_nombre", modelo.tipo_solicitud_nombre); i++;
                @params[i] = new SqlParameter("@empresa", modelo.empresa); i++;
                @params[i] = new SqlParameter("@nombre_patente", modelo.nombre_patente); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@prioridad", modelo.prioridad); i++;
                @params[i] = new SqlParameter("@pais", modelo.pais); i++;

                @params[i] = new SqlParameter("@explicacion", modelo.explicacion); i++;
                @params[i] = new SqlParameter("@fecha_nacimiento", modelo.fecha_nacimientoS); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario); i++;
                @params[i] = new SqlParameter("@empresa_nombre", modelo.empresa_nombre); i++;
                @params[i] = new SqlParameter("@prioridad_nombre", modelo.prioridad_nombre); i++;

                @params[i] = new SqlParameter("@pais_nombre", modelo.pais_nombre); i++;
                @params[i] = new SqlParameter("@identificador", modelo.identificador); i++;
                @params[i] = new SqlParameter("@nacionalidad", modelo.nacionalidad); i++;
                @params[i] = new SqlParameter("@domicilio", modelo.domicilio); i++;
                @params[i] = new SqlParameter("@rfc", modelo.rfc); i++;

                @params[i] = new SqlParameter("@curp", modelo.curp); i++;
                @params[i] = new SqlParameter("@lugar_nacimiento", modelo.lugar_nacimiento); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_Patente", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_Patente(Patente modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[18];

                int i = 0;
                @params[i] = new SqlParameter("@id", modelo.id); i++;


                @params[i] = new SqlParameter("@empresa", modelo.empresa); i++;
                @params[i] = new SqlParameter("@nombre_patente", modelo.nombre_patente); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@prioridad", modelo.prioridad); i++;
                @params[i] = new SqlParameter("@pais", modelo.pais); i++;

                @params[i] = new SqlParameter("@explicacion", modelo.explicacion); i++;
                @params[i] = new SqlParameter("@fecha_nacimiento", modelo.fecha_nacimientoS); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario); i++;
                @params[i] = new SqlParameter("@empresa_nombre", modelo.empresa_nombre); i++;
                @params[i] = new SqlParameter("@prioridad_nombre", modelo.prioridad_nombre); i++;

                @params[i] = new SqlParameter("@pais_nombre", modelo.pais_nombre); i++;
                @params[i] = new SqlParameter("@identificador", modelo.identificador); i++;
                @params[i] = new SqlParameter("@nacionalidad", modelo.nacionalidad); i++;
                @params[i] = new SqlParameter("@domicilio", modelo.domicilio); i++;
                @params[i] = new SqlParameter("@rfc", modelo.rfc); i++;

                @params[i] = new SqlParameter("@curp", modelo.curp); i++;
                @params[i] = new SqlParameter("@lugar_nacimiento", modelo.lugar_nacimiento); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_Patente", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_Patente_Activo(Patente modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_Patente_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion


        #region DisenoIndustrial
        public Boolean Cons_proc_DisenoIndustrialById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_proc_DisenoIndustrialById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_proc_DisenoIndustrial(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_proc_DisenoIndustrial", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean INS_proc_DisenoIndustrial(DisenoIndustrial modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[19];

                int i = 0;
                @params[i] = new SqlParameter("@tipo_solicitud", modelo.tipo_solicitud); i++;
                @params[i] = new SqlParameter("@tipo_solicitud_nombre", modelo.tipo_solicitud_nombre); i++;
                @params[i] = new SqlParameter("@empresa", modelo.empresa); i++;
                @params[i] = new SqlParameter("@nombre_patente", modelo.nombre_patente); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@prioridad", modelo.prioridad); i++;
                @params[i] = new SqlParameter("@pais", modelo.pais); i++;

                @params[i] = new SqlParameter("@explicacion", modelo.explicacion); i++;
                @params[i] = new SqlParameter("@fecha_nacimiento", modelo.fecha_nacimientoS); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario); i++;
                @params[i] = new SqlParameter("@empresa_nombre", modelo.empresa_nombre); i++;
                @params[i] = new SqlParameter("@prioridad_nombre", modelo.prioridad_nombre); i++;

                @params[i] = new SqlParameter("@pais_nombre", modelo.pais_nombre); i++;
                @params[i] = new SqlParameter("@identificador", modelo.identificador); i++;
                @params[i] = new SqlParameter("@nacionalidad", modelo.nacionalidad); i++;
                @params[i] = new SqlParameter("@domicilio", modelo.domicilio); i++;
                @params[i] = new SqlParameter("@rfc", modelo.rfc); i++;

                @params[i] = new SqlParameter("@curp", modelo.curp); i++;
                @params[i] = new SqlParameter("@lugar_nacimiento", modelo.lugar_nacimiento); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_DisenoIndustrial", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_DisenoIndustrial(DisenoIndustrial modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[18];

                int i = 0;
                @params[i] = new SqlParameter("@id", modelo.id); i++;


                @params[i] = new SqlParameter("@empresa", modelo.empresa); i++;
                @params[i] = new SqlParameter("@nombre_patente", modelo.nombre_patente); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@prioridad", modelo.prioridad); i++;
                @params[i] = new SqlParameter("@pais", modelo.pais); i++;

                @params[i] = new SqlParameter("@explicacion", modelo.explicacion); i++;
                @params[i] = new SqlParameter("@fecha_nacimiento", modelo.fecha_nacimientoS); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario); i++;
                @params[i] = new SqlParameter("@empresa_nombre", modelo.empresa_nombre); i++;
                @params[i] = new SqlParameter("@prioridad_nombre", modelo.prioridad_nombre); i++;

                @params[i] = new SqlParameter("@pais_nombre", modelo.pais_nombre); i++;
                @params[i] = new SqlParameter("@identificador", modelo.identificador); i++;
                @params[i] = new SqlParameter("@nacionalidad", modelo.nacionalidad); i++;
                @params[i] = new SqlParameter("@domicilio", modelo.domicilio); i++;
                @params[i] = new SqlParameter("@rfc", modelo.rfc); i++;

                @params[i] = new SqlParameter("@curp", modelo.curp); i++;
                @params[i] = new SqlParameter("@lugar_nacimiento", modelo.lugar_nacimiento); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_DisenoIndustrial", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_DisenoIndustrial_Activo(DisenoIndustrial modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_DisenoIndustrial_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion


        #region ModeloUtilidad
        public Boolean Cons_proc_ModeloUtilidadById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_proc_ModeloUtilidadById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_proc_ModeloUtilidad(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_proc_ModeloUtilidad", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean INS_proc_ModeloUtilidad(ModeloUtilidad modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[19];

                int i = 0;
                @params[i] = new SqlParameter("@tipo_solicitud", modelo.tipo_solicitud); i++;
                @params[i] = new SqlParameter("@tipo_solicitud_nombre", modelo.tipo_solicitud_nombre); i++;
                @params[i] = new SqlParameter("@empresa", modelo.empresa); i++;
                @params[i] = new SqlParameter("@nombre_patente", modelo.nombre_patente); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@prioridad", modelo.prioridad); i++;
                @params[i] = new SqlParameter("@pais", modelo.pais); i++;

                @params[i] = new SqlParameter("@explicacion", modelo.explicacion); i++;
                @params[i] = new SqlParameter("@fecha_nacimiento", modelo.fecha_nacimientoS); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario); i++;
                @params[i] = new SqlParameter("@empresa_nombre", modelo.empresa_nombre); i++;
                @params[i] = new SqlParameter("@prioridad_nombre", modelo.prioridad_nombre); i++;

                @params[i] = new SqlParameter("@pais_nombre", modelo.pais_nombre); i++;
                @params[i] = new SqlParameter("@identificador", modelo.identificador); i++;
                @params[i] = new SqlParameter("@nacionalidad", modelo.nacionalidad); i++;
                @params[i] = new SqlParameter("@domicilio", modelo.domicilio); i++;
                @params[i] = new SqlParameter("@rfc", modelo.rfc); i++;

                @params[i] = new SqlParameter("@curp", modelo.curp); i++;
                @params[i] = new SqlParameter("@lugar_nacimiento", modelo.lugar_nacimiento); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_ModeloUtilidad", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_ModeloUtilidad(ModeloUtilidad modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[18];

                int i = 0;
                @params[i] = new SqlParameter("@id", modelo.id); i++;


                @params[i] = new SqlParameter("@empresa", modelo.empresa); i++;
                @params[i] = new SqlParameter("@nombre_patente", modelo.nombre_patente); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@prioridad", modelo.prioridad); i++;
                @params[i] = new SqlParameter("@pais", modelo.pais); i++;

                @params[i] = new SqlParameter("@explicacion", modelo.explicacion); i++;
                @params[i] = new SqlParameter("@fecha_nacimiento", modelo.fecha_nacimientoS); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario); i++;
                @params[i] = new SqlParameter("@empresa_nombre", modelo.empresa_nombre); i++;
                @params[i] = new SqlParameter("@prioridad_nombre", modelo.prioridad_nombre); i++;

                @params[i] = new SqlParameter("@pais_nombre", modelo.pais_nombre); i++;
                @params[i] = new SqlParameter("@identificador", modelo.identificador); i++;
                @params[i] = new SqlParameter("@nacionalidad", modelo.nacionalidad); i++;
                @params[i] = new SqlParameter("@domicilio", modelo.domicilio); i++;
                @params[i] = new SqlParameter("@rfc", modelo.rfc); i++;

                @params[i] = new SqlParameter("@curp", modelo.curp); i++;
                @params[i] = new SqlParameter("@lugar_nacimiento", modelo.lugar_nacimiento); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_ModeloUtilidad", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_ModeloUtilidad_Activo(ModeloUtilidad modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_ModeloUtilidad_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        #region Obra
        public Boolean Cons_proc_ObraById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_proc_ObraById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_proc_Obra(out DataTable dt, out String msgError, int tipo_solicitud, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);
                i++;
                @params[1] = new SqlParameter("@tipo_solicitud", tipo_solicitud);
                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_proc_Obra", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean INS_proc_Obra(Obra modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[20];

                int i = 0;
                @params[i] = new SqlParameter("@tipo_solicitud", modelo.tipo_solicitud); i++;
                @params[i] = new SqlParameter("@tipo_solicitud_nombre", modelo.tipo_solicitud_nombre); i++;
                @params[i] = new SqlParameter("@empresa", modelo.empresa); i++;
                @params[i] = new SqlParameter("@nombre_obra", modelo.nombre_obra); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@rama", modelo.rama); i++;
                @params[i] = new SqlParameter("@pais", modelo.pais); i++;

                @params[i] = new SqlParameter("@productos", modelo.productos); i++;
                @params[i] = new SqlParameter("@fecha_nacimiento", modelo.fecha_nacimientoS); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario); i++;
                @params[i] = new SqlParameter("@empresa_nombre", modelo.empresa_nombre); i++;
                @params[i] = new SqlParameter("@rama_nombre", modelo.rama_nombre); i++;

                @params[i] = new SqlParameter("@pais_nombre", modelo.pais_nombre); i++;
                @params[i] = new SqlParameter("@identificador", modelo.identificador); i++;
                @params[i] = new SqlParameter("@nacionalidad", modelo.nacionalidad); i++;
                @params[i] = new SqlParameter("@domicilio", modelo.domicilio); i++;
                @params[i] = new SqlParameter("@rfc", modelo.rfc); i++;

                @params[i] = new SqlParameter("@curp", modelo.curp); i++;
                @params[i] = new SqlParameter("@lugar_nacimiento", modelo.lugar_nacimiento); i++;
                @params[i] = new SqlParameter("@observaciones", modelo.observaciones); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_Obra", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_Obra(Obra modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[19];

                int i = 0;
                @params[i] = new SqlParameter("@id", modelo.id); i++;

                @params[i] = new SqlParameter("@empresa", modelo.empresa); i++;
                @params[i] = new SqlParameter("@nombre_obra", modelo.nombre_obra); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@rama", modelo.rama); i++;
                @params[i] = new SqlParameter("@pais", modelo.pais); i++;

                @params[i] = new SqlParameter("@productos", modelo.productos); i++;
                @params[i] = new SqlParameter("@fecha_nacimiento", modelo.fecha_nacimientoS); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario); i++;
                @params[i] = new SqlParameter("@empresa_nombre", modelo.empresa_nombre); i++;
                @params[i] = new SqlParameter("@rama_nombre", modelo.rama_nombre); i++;

                @params[i] = new SqlParameter("@pais_nombre", modelo.pais_nombre); i++;
                @params[i] = new SqlParameter("@identificador", modelo.identificador); i++;
                @params[i] = new SqlParameter("@nacionalidad", modelo.nacionalidad); i++;
                @params[i] = new SqlParameter("@domicilio", modelo.domicilio); i++;
                @params[i] = new SqlParameter("@rfc", modelo.rfc); i++;

                @params[i] = new SqlParameter("@curp", modelo.curp); i++;
                @params[i] = new SqlParameter("@lugar_nacimiento", modelo.lugar_nacimiento); i++;
                @params[i] = new SqlParameter("@observaciones", modelo.observaciones); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_Obra", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_Obra_Activo(Obra modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_Obra_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        #region ModeloIndustrial
        public Boolean Cons_proc_ModeloIndustrialById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_proc_ModeloIndustrialById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_proc_ModeloIndustrial(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_proc_ModeloIndustrial", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean INS_proc_ModeloIndustrial(ModeloIndustrial modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[19];

                int i = 0;
                @params[i] = new SqlParameter("@tipo_solicitud", modelo.tipo_solicitud); i++;
                @params[i] = new SqlParameter("@tipo_solicitud_nombre", modelo.tipo_solicitud_nombre); i++;
                @params[i] = new SqlParameter("@empresa", modelo.empresa); i++;
                @params[i] = new SqlParameter("@nombre_patente", modelo.nombre_patente); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@prioridad", modelo.prioridad); i++;
                @params[i] = new SqlParameter("@pais", modelo.pais); i++;

                @params[i] = new SqlParameter("@explicacion", modelo.explicacion); i++;
                @params[i] = new SqlParameter("@fecha_nacimiento", modelo.fecha_nacimientoS); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario); i++;
                @params[i] = new SqlParameter("@empresa_nombre", modelo.empresa_nombre); i++;
                @params[i] = new SqlParameter("@prioridad_nombre", modelo.prioridad_nombre); i++;

                @params[i] = new SqlParameter("@pais_nombre", modelo.pais_nombre); i++;
                @params[i] = new SqlParameter("@identificador", modelo.identificador); i++;
                @params[i] = new SqlParameter("@nacionalidad", modelo.nacionalidad); i++;
                @params[i] = new SqlParameter("@domicilio", modelo.domicilio); i++;
                @params[i] = new SqlParameter("@rfc", modelo.rfc); i++;

                @params[i] = new SqlParameter("@curp", modelo.curp); i++;
                @params[i] = new SqlParameter("@lugar_nacimiento", modelo.lugar_nacimiento); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_ModeloIndustrial", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_ModeloIndustrial(ModeloIndustrial modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[18];

                int i = 0;
                @params[i] = new SqlParameter("@id", modelo.id); i++;


                @params[i] = new SqlParameter("@empresa", modelo.empresa); i++;
                @params[i] = new SqlParameter("@nombre_patente", modelo.nombre_patente); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@prioridad", modelo.prioridad); i++;
                @params[i] = new SqlParameter("@pais", modelo.pais); i++;

                @params[i] = new SqlParameter("@explicacion", modelo.explicacion); i++;
                @params[i] = new SqlParameter("@fecha_nacimiento", modelo.fecha_nacimientoS); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario); i++;
                @params[i] = new SqlParameter("@empresa_nombre", modelo.empresa_nombre); i++;
                @params[i] = new SqlParameter("@prioridad_nombre", modelo.prioridad_nombre); i++;

                @params[i] = new SqlParameter("@pais_nombre", modelo.pais_nombre); i++;
                @params[i] = new SqlParameter("@identificador", modelo.identificador); i++;
                @params[i] = new SqlParameter("@nacionalidad", modelo.nacionalidad); i++;
                @params[i] = new SqlParameter("@domicilio", modelo.domicilio); i++;
                @params[i] = new SqlParameter("@rfc", modelo.rfc); i++;

                @params[i] = new SqlParameter("@curp", modelo.curp); i++;
                @params[i] = new SqlParameter("@lugar_nacimiento", modelo.lugar_nacimiento); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_ModeloIndustrial", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_ModeloIndustrial_Activo(ModeloIndustrial modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_ModeloIndustrial_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        #region TipoArchivo

        public Boolean Cons_TipoArchivoById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_TipoArchivoById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_TipoArchivo(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {

                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_TipoArchivo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        #region Clase
        public Boolean Cons_ClaseById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_ClaseById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_ClaseFromUsuario(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_ClaseFromUsuario", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_Clase(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {

                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_Clase", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean INS_Clase(Clase modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[3];

                int i = 0;
                @params[0] = new SqlParameter("@nombre", modelo.nombre);
                @params[1] = new SqlParameter("@descripcion", modelo.descripcion);

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_cat_Clase", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_Clase(Clase modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[4];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);
                @params[1] = new SqlParameter("@nombre", modelo.nombre);
                @params[2] = new SqlParameter("@descripcion", modelo.descripcion);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_cat_Clase", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_Clase_Activo(Clase modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_cat_Clase_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        #region EstatusCatalogo
        public Boolean Cons_EstatusCatalogoById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_EstatusCatalogoById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_EstatusCatalogoFromUsuario(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_EstatusCatalogoFromUsuario", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_EstatusCatalogo(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {

                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_EstatusCatalogo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean INS_EstatusCatalogo(EstatusCatalogo modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[3];

                int i = 0;
                @params[0] = new SqlParameter("@nombre", modelo.nombre);
                @params[1] = new SqlParameter("@descripcion", modelo.descripcion);

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_cat_EstatusCatalogo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_EstatusCatalogo(EstatusCatalogo modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[4];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);
                @params[1] = new SqlParameter("@nombre", modelo.nombre);
                @params[2] = new SqlParameter("@descripcion", modelo.descripcion);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_cat_EstatusCatalogo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_EstatusCatalogo_Activo(EstatusCatalogo modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_cat_EstatusCatalogo_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        #region TipoRegistro
        public Boolean Cons_TipoRegistroById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_TipoRegistroById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_TipoRegistroFromUsuario(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_TipoRegistroFromUsuario", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_TipoRegistro(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {

                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_TipoRegistro", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean INS_TipoRegistro(TipoRegistro modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[3];

                int i = 0;
                @params[0] = new SqlParameter("@nombre", modelo.nombre);
                @params[1] = new SqlParameter("@descripcion", modelo.descripcion);

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_cat_TipoRegistro", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_TipoRegistro(TipoRegistro modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[4];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);
                @params[1] = new SqlParameter("@nombre", modelo.nombre);
                @params[2] = new SqlParameter("@descripcion", modelo.descripcion);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_cat_TipoRegistro", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_TipoRegistro_Activo(TipoRegistro modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_cat_TipoRegistro_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        #region Archivos
        public Boolean CONS_proc_ArchivoById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_proc_ArchivoById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_proc_RLArchivoMarcaFromId(int id, string tipo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);
                @params[1] = new SqlParameter("@tipo", tipo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_proc_RLArchivoMarcaFromId", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_proc_RLArchivoAvisoComercialFromId(int id, string tipo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);
                @params[1] = new SqlParameter("@tipo", tipo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_proc_RLArchivoAvisoComercialFromId", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_proc_RLArchivoPatenteFromId(int id, string tipo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);
                @params[1] = new SqlParameter("@tipo", tipo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_proc_RLArchivoPatenteFromId", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean CONS_proc_RLArchivoDisenoIndustrialFromId(int id, string tipo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);
                @params[1] = new SqlParameter("@tipo", tipo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_proc_RLArchivoDisenoIndustrialFromId", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean INS_proc_RLArchivoDisenoIndustrial(RLArchivo modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.objeto);
                @params[1] = new SqlParameter("@archivo", modelo.archivo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_RLArchivoDisenoIndustrial", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_proc_RLArchivoModeloUtilidadFromId(int id, string tipo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);
                @params[1] = new SqlParameter("@tipo", tipo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_proc_RLArchivoModeloUtilidadFromId", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean INS_proc_RLArchivoModeloUtilidad(RLArchivo modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.objeto);
                @params[1] = new SqlParameter("@archivo", modelo.archivo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_RLArchivoModeloUtilidad", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_proc_RLArchivoModeloIndustrialFromId(int id, string tipo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);
                @params[1] = new SqlParameter("@tipo", tipo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_proc_RLArchivoModeloIndustrialFromId", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean INS_proc_RLArchivoModeloIndustrial(RLArchivo modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.objeto);
                @params[1] = new SqlParameter("@archivo", modelo.archivo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_RLArchivoModeloIndustrial", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean CONS_proc_RLArchivoObraFromId(int id, string tipo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);
                @params[1] = new SqlParameter("@tipo", tipo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_proc_RLArchivoObraFromId", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }


        public Boolean CONS_proc_RLArchivoRegistroMarcaFromId(int id, string tipo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);
                @params[1] = new SqlParameter("@tipo", tipo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_proc_RLArchivoRegistroMarcaFromId", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean INS_proc_RLArchivoObra(RLArchivo modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.objeto);
                @params[1] = new SqlParameter("@archivo", modelo.archivo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_RLArchivoObra", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean INS_proc_RLArchivoRegistroMarca(RLArchivo modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.objeto);
                @params[1] = new SqlParameter("@archivo", modelo.archivo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_RLArchivoRegistroMarca", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean INS_proc_Archivo(Archivo modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[9];

                int i = 0;
                @params[i] = new SqlParameter("@usuario", modelo.usuario.id);i++;
                @params[i] = new SqlParameter("@file_nombre", modelo.file_nombre); i++;
                @params[i] = new SqlParameter("@file_data", modelo.file_data); i++;
                @params[i] = new SqlParameter("@file_content_type", modelo.file_content_type); i++;
                @params[i] = new SqlParameter("@file_size", modelo.file_size); i++;
                @params[i] = new SqlParameter("@tipo", modelo.tipo); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@file_extension", modelo.file_extension); i++;
                @params[i] = new SqlParameter("@url", modelo.url); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_Archivo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean INS_proc_RLArchivoMarca(RLArchivo modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.objeto);
                @params[1] = new SqlParameter("@archivo", modelo.archivo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_RLArchivoMarca", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean INS_proc_RLArchivoAvisoComercial(RLArchivo modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.objeto);
                @params[1] = new SqlParameter("@archivo", modelo.archivo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_RLArchivoAvisoComercial", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean INS_proc_RLArchivoPatente(RLArchivo modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.objeto);
                @params[1] = new SqlParameter("@archivo", modelo.archivo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_RLArchivoPatente", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        #region ConvenioLicencia

        public Boolean UPD_proc_ConvenioLicenciaDocumento(ConvenioLicencia modelo, int tipo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[12];

                int i = 0;
                @params[i] = new SqlParameter("@id", modelo.id); i++;

                @params[i] = new SqlParameter("@solicitud_nombre", modelo.solicitud_nombre); i++;
                //@params[i] = new SqlParameter("@solicitud_data", modelo.solicitud_data); i++;
                @params[i] = new SqlParameter("@solicitud_content_type", modelo.solicitud_content_type); i++;
                @params[i] = new SqlParameter("@solicitud_size", modelo.solicitud_size); i++;
                @params[i] = new SqlParameter("@solicitud_extension", modelo.solicitud_extension); i++;

                @params[i] = new SqlParameter("@solicitud_nombre_original", modelo.solicitud_nombre_original); i++;
                @params[i] = new SqlParameter("@solicitud_url", modelo.solicitud_url); i++;
                @params[i] = new SqlParameter("@tipo", tipo); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_ConvenioLicenciaDocumento", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_ConvenioLicenciaById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_ConvenioLicenciaById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_ConvenioLicenciaFromUsuario(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_ConvenioLicenciaFromUsuario", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_ConvenioLicencia(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {

                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_ConvenioLicencia", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean INS_ConvenioLicencia(ConvenioLicencia modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[30];

                int i = 0;
                @params[i] = new SqlParameter("@licenciatario", modelo.licenciatario); i++;
                @params[i] = new SqlParameter("@licenciatario_nombre", modelo.licenciatario_nombre); i++;
                @params[i] = new SqlParameter("@licenciante", modelo.licenciante); i++;
                @params[i] = new SqlParameter("@licenciante_nombre", modelo.licenciante_nombre); i++;
                @params[i] = new SqlParameter("@solicitante", modelo.solicitante); i++;

                @params[i] = new SqlParameter("@solicitante_nombre", modelo.solicitante_nombre); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@numero_registro", modelo.numero_registro); i++;
                @params[i] = new SqlParameter("@numero_expediente", modelo.numero_expediente); i++;
                @params[i] = new SqlParameter("@clase", modelo.clase); i++;

                @params[i] = new SqlParameter("@clase_nombre", modelo.clase_nombre); i++;
                @params[i] = new SqlParameter("@pais", modelo.pais); i++;
                @params[i] = new SqlParameter("@pais_nombre", modelo.pais_nombre); i++;
                @params[i] = new SqlParameter("@fecha_instrucciones", modelo.fecha_instruccionesS); i++;
                @params[i] = new SqlParameter("@fecha_instrucciones_completado", modelo.fecha_instrucciones_completadoS); i++;

                @params[i] = new SqlParameter("@fecha_envio_documentos", modelo.fecha_envio_documentosS); i++;
                @params[i] = new SqlParameter("@fecha_envio_documentos_completado", modelo.fecha_envio_documentos_completadoS); i++;
                @params[i] = new SqlParameter("@fecha_solicitud", modelo.fecha_solicitudS); i++;
                @params[i] = new SqlParameter("@fecha_concesion", modelo.fecha_concesionS); i++;
                @params[i] = new SqlParameter("@fecha_legal", modelo.fecha_legalS); i++;

                @params[i] = new SqlParameter("@fecha_vencimiento", modelo.fecha_vencimientoS); i++;
                @params[i] = new SqlParameter("@observaciones", modelo.observaciones); i++;
                @params[i] = new SqlParameter("@despacho", modelo.despacho); i++;
                @params[i] = new SqlParameter("@despacho_nombre", modelo.despacho_nombre); i++;
                @params[i] = new SqlParameter("@corresponsal", modelo.corresponsal); i++;

                @params[i] = new SqlParameter("@corresponsal_nombre", modelo.corresponsal_nombre); i++;
                @params[i] = new SqlParameter("@tipo_cesion", modelo.tipo_cesion); i++;
                @params[i] = new SqlParameter("@tipo_cesion_nombre", modelo.tipo_cesion_nombre); i++;
                @params[i] = new SqlParameter("@licencia_tipo", modelo.licencia_tipo); i++;
                @params[i] = new SqlParameter("@fecha_solicitud_completado", modelo.fecha_solicitud_completadoS); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_ConvenioLicencia", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_ConvenioLicencia(ConvenioLicencia modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[31];

                int i = 0;
                @params[i] = new SqlParameter("@id", modelo.id); i++;

                @params[i] = new SqlParameter("@licenciatario", modelo.licenciatario); i++;
                @params[i] = new SqlParameter("@licenciatario_nombre", modelo.licenciatario_nombre); i++;
                @params[i] = new SqlParameter("@licenciante", modelo.licenciante); i++;
                @params[i] = new SqlParameter("@licenciante_nombre", modelo.licenciante_nombre); i++;
                @params[i] = new SqlParameter("@solicitante", modelo.solicitante); i++;

                @params[i] = new SqlParameter("@solicitante_nombre", modelo.solicitante_nombre); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@numero_registro", modelo.numero_registro); i++;
                @params[i] = new SqlParameter("@numero_expediente", modelo.numero_expediente); i++;
                @params[i] = new SqlParameter("@clase", modelo.clase); i++;

                @params[i] = new SqlParameter("@clase_nombre", modelo.clase_nombre); i++;
                @params[i] = new SqlParameter("@pais", modelo.pais); i++;
                @params[i] = new SqlParameter("@pais_nombre", modelo.pais_nombre); i++;
                @params[i] = new SqlParameter("@fecha_instrucciones", modelo.fecha_instruccionesS); i++;
                @params[i] = new SqlParameter("@fecha_instrucciones_completado", modelo.fecha_instrucciones_completadoS); i++;

                @params[i] = new SqlParameter("@fecha_envio_documentos", modelo.fecha_envio_documentosS); i++;
                @params[i] = new SqlParameter("@fecha_envio_documentos_completado", modelo.fecha_envio_documentos_completadoS); i++;
                @params[i] = new SqlParameter("@fecha_solicitud", modelo.fecha_solicitudS); i++;
                @params[i] = new SqlParameter("@fecha_concesion", modelo.fecha_concesionS); i++;
                @params[i] = new SqlParameter("@fecha_legal", modelo.fecha_legalS); i++;

                @params[i] = new SqlParameter("@fecha_vencimiento", modelo.fecha_vencimientoS); i++;
                @params[i] = new SqlParameter("@observaciones", modelo.observaciones); i++;
                @params[i] = new SqlParameter("@despacho", modelo.despacho); i++;
                @params[i] = new SqlParameter("@despacho_nombre", modelo.despacho_nombre); i++;
                @params[i] = new SqlParameter("@corresponsal", modelo.corresponsal); i++;

                @params[i] = new SqlParameter("@corresponsal_nombre", modelo.corresponsal_nombre); i++;
                @params[i] = new SqlParameter("@tipo_cesion", modelo.tipo_cesion); i++;
                @params[i] = new SqlParameter("@tipo_cesion_nombre", modelo.tipo_cesion_nombre); i++;
                @params[i] = new SqlParameter("@licencia_tipo", modelo.licencia_tipo); i++;
                @params[i] = new SqlParameter("@fecha_solicitud_completado", modelo.fecha_solicitud_completadoS); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_ConvenioLicencia", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_ConvenioLicencia_Activo(ConvenioLicencia modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_ConvenioLicencia_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        #endregion


        #region ContratoCesion
        public Boolean UPD_proc_ContratoCesionDocumento(ContratoCesion modelo, int tipo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[12];

                int i = 0;
                @params[i] = new SqlParameter("@id", modelo.id); i++;

                @params[i] = new SqlParameter("@solicitud_nombre", modelo.solicitud_nombre); i++;
                //@params[i] = new SqlParameter("@solicitud_data", modelo.solicitud_data); i++;
                @params[i] = new SqlParameter("@solicitud_content_type", modelo.solicitud_content_type); i++;
                @params[i] = new SqlParameter("@solicitud_size", modelo.solicitud_size); i++;
                @params[i] = new SqlParameter("@solicitud_extension", modelo.solicitud_extension); i++;

                @params[i] = new SqlParameter("@solicitud_nombre_original", modelo.solicitud_nombre_original); i++;
                @params[i] = new SqlParameter("@solicitud_url", modelo.solicitud_url); i++;
                @params[i] = new SqlParameter("@tipo", tipo); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_ContratoCesionDocumento", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_ContratoCesionById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_ContratoCesionById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_ContratoCesionFromUsuario(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "Cons_ContratoCesionFromUsuario", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_ContratoCesion(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {

                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_ContratoCesion", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean INS_ContratoCesion(ContratoCesion modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[29];

                int i = 0;
                @params[i] = new SqlParameter("@cedente", modelo.cedente); i++;
                @params[i] = new SqlParameter("@cedente_nombre", modelo.cedente_nombre); i++;
                @params[i] = new SqlParameter("@cesionario", modelo.cesionario); i++;
                @params[i] = new SqlParameter("@cesionario_nombre", modelo.cesionario_nombre); i++;
                @params[i] = new SqlParameter("@solicitante", modelo.solicitante); i++;

                @params[i] = new SqlParameter("@solicitante_nombre", modelo.solicitante_nombre); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@numero_registro", modelo.numero_registro); i++;
                @params[i] = new SqlParameter("@numero_expediente", modelo.numero_expediente); i++;
                @params[i] = new SqlParameter("@clase", modelo.clase); i++;

                @params[i] = new SqlParameter("@clase_nombre", modelo.clase_nombre); i++;
                @params[i] = new SqlParameter("@pais", modelo.pais); i++;
                @params[i] = new SqlParameter("@pais_nombre", modelo.pais_nombre); i++;
                @params[i] = new SqlParameter("@fecha_instrucciones", modelo.fecha_instruccionesS); i++;
                @params[i] = new SqlParameter("@fecha_instrucciones_completado", modelo.fecha_instrucciones_completadoS); i++;

                @params[i] = new SqlParameter("@fecha_envio_documentos", modelo.fecha_envio_documentosS); i++;
                @params[i] = new SqlParameter("@fecha_envio_documentos_completado", modelo.fecha_envio_documentos_completadoS); i++;
                @params[i] = new SqlParameter("@fecha_solicitud", modelo.fecha_solicitudS); i++;
                @params[i] = new SqlParameter("@fecha_concesion", modelo.fecha_concesionS); i++;
                @params[i] = new SqlParameter("@fecha_legal", modelo.fecha_legalS); i++;

                @params[i] = new SqlParameter("@fecha_vencimiento", modelo.fecha_vencimientoS); i++;
                @params[i] = new SqlParameter("@observaciones", modelo.observaciones); i++;
                @params[i] = new SqlParameter("@despacho", modelo.despacho); i++;
                @params[i] = new SqlParameter("@despacho_nombre", modelo.despacho_nombre); i++;
                @params[i] = new SqlParameter("@corresponsal", modelo.corresponsal); i++;

                @params[i] = new SqlParameter("@corresponsal_nombre", modelo.corresponsal_nombre); i++;
                @params[i] = new SqlParameter("@tipo_cesion", modelo.tipo_cesion); i++;
                @params[i] = new SqlParameter("@tipo_cesion_nombre", modelo.tipo_cesion_nombre); i++;
                @params[i] = new SqlParameter("@fecha_solicitud_completado", modelo.fecha_solicitud_completadoS); i++;


                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_ContratoCesion", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_ContratoCesion(ContratoCesion modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[30];

                int i = 0;
                @params[i] = new SqlParameter("@id", modelo.id); i++;

                @params[i] = new SqlParameter("@cedente", modelo.cedente); i++;
                @params[i] = new SqlParameter("@cedente_nombre", modelo.cedente_nombre); i++;
                @params[i] = new SqlParameter("@cesionario", modelo.cesionario); i++;
                @params[i] = new SqlParameter("@cesionario_nombre", modelo.cesionario_nombre); i++;
                @params[i] = new SqlParameter("@solicitante", modelo.solicitante); i++;

                @params[i] = new SqlParameter("@solicitante_nombre", modelo.solicitante_nombre); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@numero_registro", modelo.numero_registro); i++;
                @params[i] = new SqlParameter("@numero_expediente", modelo.numero_expediente); i++;
                @params[i] = new SqlParameter("@clase", modelo.clase); i++;

                @params[i] = new SqlParameter("@clase_nombre", modelo.clase_nombre); i++;
                @params[i] = new SqlParameter("@pais", modelo.pais); i++;
                @params[i] = new SqlParameter("@pais_nombre", modelo.pais_nombre); i++;
                @params[i] = new SqlParameter("@fecha_instrucciones", modelo.fecha_instruccionesS); i++;
                @params[i] = new SqlParameter("@fecha_instrucciones_completado", modelo.fecha_instrucciones_completadoS); i++;

                @params[i] = new SqlParameter("@fecha_envio_documentos", modelo.fecha_envio_documentosS); i++;
                @params[i] = new SqlParameter("@fecha_envio_documentos_completado", modelo.fecha_envio_documentos_completadoS); i++;
                @params[i] = new SqlParameter("@fecha_solicitud", modelo.fecha_solicitudS); i++;
                @params[i] = new SqlParameter("@fecha_concesion", modelo.fecha_concesionS); i++;
                @params[i] = new SqlParameter("@fecha_legal", modelo.fecha_legalS); i++;

                @params[i] = new SqlParameter("@fecha_vencimiento", modelo.fecha_vencimientoS); i++;
                @params[i] = new SqlParameter("@observaciones", modelo.observaciones); i++;
                @params[i] = new SqlParameter("@despacho", modelo.despacho); i++;
                @params[i] = new SqlParameter("@despacho_nombre", modelo.despacho_nombre); i++;
                @params[i] = new SqlParameter("@corresponsal", modelo.corresponsal); i++;

                @params[i] = new SqlParameter("@corresponsal_nombre", modelo.corresponsal_nombre); i++;
                @params[i] = new SqlParameter("@tipo_cesion", modelo.tipo_cesion); i++;
                @params[i] = new SqlParameter("@tipo_cesion_nombre", modelo.tipo_cesion_nombre); i++;
                @params[i] = new SqlParameter("@fecha_solicitud_completado", modelo.fecha_solicitud_completadoS); i++;


                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_ContratoCesion", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_ContratoCesion_Activo(ContratoCesion modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_ContratoCesion_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        #endregion

        #region Despacho
        public Boolean Cons_DespachoById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_DespachoById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_Despacho(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {

                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_Despacho", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean INS_Despacho(Despacho modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[6];

                int i = 0;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@telefono", modelo.telefono); i++;
                @params[i] = new SqlParameter("@email", modelo.email); i++;
                @params[i] = new SqlParameter("@abogado", modelo.abogado); i++;
                @params[i] = new SqlParameter("@abogado_nombre", modelo.abogado_nombre); i++;
                @params[i] = new SqlParameter("@abogado_email", modelo.abogado_email); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_Despacho", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_Despacho(Despacho modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[7];

                int i = 0;
                @params[i] = new SqlParameter("@id", modelo.id); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@telefono", modelo.telefono); i++;
                @params[i] = new SqlParameter("@email", modelo.email); i++;
                @params[i] = new SqlParameter("@abogado", modelo.abogado); i++;
                @params[i] = new SqlParameter("@abogado_nombre", modelo.abogado_nombre); i++;
                @params[i] = new SqlParameter("@abogado_email", modelo.abogado_email); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_Despacho", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_Despacho_Activo(Despacho modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_Despacho_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        #region Corresponsal
        public Boolean Cons_CorresponsalById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_CorresponsalById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean Cons_Corresponsal(out DataTable dt, out String msgError, int activo = -1)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {

                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", activo);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_Corresponsal", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean INS_Corresponsal(Corresponsal modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[6];

                int i = 0;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@telefono", modelo.telefono); i++;
                @params[i] = new SqlParameter("@email", modelo.email); i++;
                @params[i] = new SqlParameter("@abogado", modelo.abogado); i++;
                @params[i] = new SqlParameter("@abogado_nombre", modelo.abogado_nombre); i++;
                @params[i] = new SqlParameter("@abogado_email", modelo.abogado_email); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "INS_proc_Corresponsal", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_Corresponsal(Corresponsal modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[7];

                int i = 0;
                @params[i] = new SqlParameter("@id", modelo.id); i++;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@telefono", modelo.telefono); i++;
                @params[i] = new SqlParameter("@email", modelo.email); i++;
                @params[i] = new SqlParameter("@abogado", modelo.abogado); i++;
                @params[i] = new SqlParameter("@abogado_nombre", modelo.abogado_nombre); i++;
                @params[i] = new SqlParameter("@abogado_email", modelo.abogado_email); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_Corresponsal", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean UPD_Corresponsal_Activo(Corresponsal modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_Corresponsal_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion


        #region Recordatorio PI
        public Boolean UPD_proc_RecordatorioPI_Activo(RecordatorioPI modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", modelo.id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_RecordatorioPI_Activo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean INS_RecordatorioPI(RecordatorioPI modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
             dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[10];

                int i = 0;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario); i++;
                @params[i] = new SqlParameter("@asignado", modelo.asignado); i++;
                @params[i] = new SqlParameter("@fecha_recordatorio", modelo.fecha_recordatorio); i++;
                @params[i] = new SqlParameter("@dias_vencimiento", modelo.dias_vencimiento); i++;
                @params[i] = new SqlParameter("@frecuencia", modelo.frecuencia); i++;
                @params[i] = new SqlParameter("@descripcion", modelo.descripcion); i++;
                @params[i] = new SqlParameter("@fecha_fin", modelo.fecha_fin); i++;
                @params[i] = new SqlParameter("@tipo", modelo.tipo); i++;
                @params[i] = new SqlParameter("@aux1", modelo.aux1); i++;

                //i++;
                if (!bd.ExecuteProcedure(conexion, "INS_RecordatorioPI", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_RecordatorioPI(RecordatorioPI modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[9];

                int i = 0;
                @params[i] = new SqlParameter("@nombre", modelo.nombre); i++;
                @params[i] = new SqlParameter("@id", modelo.id); i++;
                @params[i] = new SqlParameter("@usuario", modelo.usuario); i++;
                @params[i] = new SqlParameter("@asignado", modelo.asignado); i++;
                @params[i] = new SqlParameter("@fecha_recordatorio", modelo.fecha_recordatorio); i++;
                @params[i] = new SqlParameter("@dias_vencimiento", modelo.dias_vencimiento); i++;
                @params[i] = new SqlParameter("@frecuencia", modelo.frecuencia); i++;
                @params[i] = new SqlParameter("@descripcion", modelo.descripcion); i++;
                @params[i] = new SqlParameter("@fecha_fin", modelo.fecha_fin); i++;

                //i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_RecordatorioPI", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_RecordatorioPI_PorRegistroFecha(DateTime fecha, int registro, int tipo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[8];

                int i = 0;
                @params[i] = new SqlParameter("@fecha", fecha); i++;
                @params[i] = new SqlParameter("@registro", registro); i++;
                @params[i] = new SqlParameter("@tipo", tipo); i++;

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_RecordatorioPI_PorRegistroFecha", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean DEL_RecordatorioPI(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "DEL_RecordatorioPI", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_RecordatorioPIById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_RecordatoriosPIById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_RecordatorioPIFromId(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_RecordatoriosPIFromId", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean CONS_RecordatorioPI(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_RecordatoriosPI", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_RecordatoriosPI_FromRegistro(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_RecordatoriosPI_FromRegistro", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        public Boolean CONS_cat_Area(out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[0];

                int i = 0;
                //@params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_cat_Area", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_cat_AreaById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_cat_AreaById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_proc_ActaEquipo(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_proc_ActaEquipoByActa", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_proc_ActaEquipoByTipo(int id, string desc, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);
                @params[1] = new SqlParameter("@desc", desc);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_proc_ActaEquipoByTipo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        public Boolean CONS_cat_Rol(out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[0];

                int i = 0;
                //@params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_cat_Rol", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_cat_RolById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_cat_RolById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_proc_ActaEquipoByActa(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_proc_ActaEquipoByActa", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_NotificacionesFromUsuario(string id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_NotificacionesFromUsuario", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_cat_Administracion(string attr, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@attr", attr);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_cat_Administracion", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_cat_Administracion(RespuestaFormato modelo, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[3];

                int i = 0;
                @params[0] = new SqlParameter("@nombre", modelo.data_string.ToUpper());
                @params[1] = new SqlParameter("@valor", modelo.data_string1);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_cat_Administracion", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #region combos

        public Boolean ProbarServicio(string cadena_, int entero_, decimal decimal_, out DataSet ds, out String msgError)
        {
            bool boolProcess = true;
            ds = new DataSet();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[3];

                int i = 0;
                @params[0] = new SqlParameter("@cadena", cadena_);
                @params[1] = new SqlParameter("@entero", entero_);
                @params[2] = new SqlParameter("@decimal", decimal_);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_SPPrueba", @params, out ds, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Ins_Embarque(int estatus, float org_id, string org_name, float vendor_id, string proveedor, string moneda, string rfc, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[7];

                int i = 0;
                @params[0] = new SqlParameter("@estatus", estatus);
                @params[1] = new SqlParameter("@org_id", org_id);
                @params[2] = new SqlParameter("@org_name", org_name);
                @params[3] = new SqlParameter("@vendor_id", vendor_id);
                @params[4] = new SqlParameter("@proveedor", proveedor);
                @params[5] = new SqlParameter("@moneda", moneda);
                @params[6] = new SqlParameter("@rfc", rfc);

                i++;
                if (!bd.ExecuteProcedure(conexion, "ins_Embarque", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Upd_Embarque(int id, string fecha, string destino, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[3];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);
                @params[1] = new SqlParameter("@fecha_embarque", fecha);
                @params[2] = new SqlParameter("@destino", destino);

                i++;
                if (!bd.ExecuteProcedure(conexion, "upd_Embarque", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_EmbarqueById(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_EmbarqueById", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_EmbarqueFromVendor(float vendor, string ouname, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@vendor", vendor);
                @params[1] = new SqlParameter("@ouname", ouname);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_EmbarqueFromVendor", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_Embarque(string estatus, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@estatus", estatus);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_Embarque", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Ins_Documentos(int embarque, byte[] pdf, string xml, int estatusfactura, string uuid, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[5];
                int i = 0;
                @params[0] = new SqlParameter("@embarqueid", embarque);
                @params[1] = new SqlParameter("@pdf", pdf);
                @params[2] = new SqlParameter("@xml", xml);
                @params[3] = new SqlParameter("@estatus", estatusfactura);
                @params[4] = new SqlParameter("@uuid", uuid);

                i++;
                if (!bd.ExecuteProcedure(conexion, "ins_Documento", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_IRS_HeaderFromEmbarque(int embarque, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@embarque", embarque);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_IRS_HeaderFromEmbarque", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_DocumentoFromRFC(string rfc, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@RfcEmisor", rfc);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_DocumentosDisponiblesEmbarque", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Cons_DocumentoFromUUID(string uuid, out DataSet dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataSet();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@UUID", uuid);

                i++;
                if (!bd.ExecuteProcedure(conexion, "cons_DocumentosUUID", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    /*if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }*/
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        #endregion

        public Boolean CONS_ControlDesarrollo(string inicio, string fin, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@inicio", inicio);
                @params[1] = new SqlParameter("@fin", fin);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_ControlDesarrollo", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Ins_NuevaObservacion(int idIncidencia, string descripcion, string usuarioCaptura, out String msgError)
        {
            bool boolProcess = true;

            msgError = string.Empty;
            int i = 0;
            SqlParameter[] @params = new SqlParameter[3];

            @params[i] = new SqlParameter("@idIncidencia", idIncidencia);
            i++;
            @params[i] = new SqlParameter("@UsuarioCaptura", usuarioCaptura);
            i++;
            @params[i] = new SqlParameter("@descripcion", descripcion);
            i++;

            try
            {
                if (!bd.ExecuteProcedure(conexion, "ins_NuevaObservacion", @params, out DataTable dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                        msgError = dt.Rows[0][1].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean Upd_FinalizarTarea(int idTarea, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            int i = 0;
            SqlParameter[] @params = new SqlParameter[1];

            @params[i] = new SqlParameter("@idTarea", idTarea);


            try
            {
                if (!bd.ExecuteProcedure(conexion, "upd_FinalizarTarea", @params, out DataTable dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (!dt.Rows[0][0].ToString().Equals("0"))
                    {
                        boolProcess = false;
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }


        public Boolean CONS_proc_TiempoResumen(out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[0];

                int i = 0;
                //@params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_proc_TiempoResumen", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean UPD_proc_TiemposResumen(string atributo, decimal valor, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[2];

                int i = 0;
                @params[0] = new SqlParameter("@atributo", atributo);
                @params[1] = new SqlParameter("@valor", valor);

                i++;
                if (!bd.ExecuteProcedure(conexion, "UPD_proc_TiemposResumen", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_proc_Tiempos(out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[0];

                int i = 0;
                //@params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_proc_Tiempos", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_proc_TiemposByid(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_proc_TiemposByid", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_proc_TiemposCombinaciones(out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[0];

                int i = 0;
                //@params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_proc_TiemposCombinaciones", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean CONS_proc_TiemposCombinacionesByid(int id, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;

            try
            {
                SqlParameter[] @params = new SqlParameter[1];

                int i = 0;
                @params[0] = new SqlParameter("@id", id);

                i++;
                if (!bd.ExecuteProcedure(conexion, "CONS_proc_TiemposCombinacionesByid", @params, out dt, 1000))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (dt.Rows.Count < 1)
                    {
                        boolProcess = false;
                        msgError = "No hay datos a mostrar";
                    }
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

    }
}
