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

    public class RolPortal
    {
        public AspNetRoles rol { get; set; } = new AspNetRoles();
        public List<AccesoVistas> accesos { get; private set; } = new List<AccesoVistas>();
    }
    public class AspNetRoles
    {
        public RoleManager<IdentityRole> _manager { get; private set; }
        public static string connstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        public string id { get; set; }
        public string descripcion { set; get; }
        public int Activo { set; get; }
        public int Juridico { set; get; }
        public int PI { set; get; }
        public List<string> errors { get; set; }

        public AspNetRoles()
        {
            id = "";
            descripcion = "";
            Activo = 0;
            Juridico = 0;
            PI = 0;
            errors = new List<string>();
        }


        public static AspNetRoles GetById(string id)
        {
            AspNetRoles res = new AspNetRoles();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_RolById(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];
                        res.id = row[idx].ToString(); idx++;
                        res.descripcion = row[idx].ToString(); idx++;
                    }
                }
                else
                {
                    //
                }
            }
            catch (Exception ex)
            {
                res = new AspNetRoles();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static RespuestaFormato Actualizar(AspNetRoles modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Upd_Rol(modelo, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        string id = row[3].ToString();
                        if (id != "")
                        {
                            res.flag = true;
                            res.data_string = id;
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

        public static RespuestaFormato ActualizarActivo(AspNetRoles modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.UPD_Rol_Activo(modelo, out dt, out errores))
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

        public async Task AddRoles(RoleManager<IdentityRole> manager)
        {
            var role = new IdentityRole();
            role.Name = "Administrador";

            var a = await manager.CreateAsync(role);


            var role2 = new IdentityRole();
            role2.Name = "Usuario";
            a = await manager.CreateAsync(role2);
            var i = "";
        }


        public async Task<bool> AddRole(string descripcion, RoleManager<IdentityRole> manager)
        {
            bool flag = false;
            try
            {
                var role = new IdentityRole();
                role.Name = descripcion;

                var a = await manager.CreateAsync(role);
                flag = true;
            }catch(Exception ex)
            {
                flag = false;
            }

            return flag;
        }

        public async Task<RespuestaFormato> Crear(string descripcion, RoleManager<IdentityRole> manager)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                var role = new IdentityRole();
                role.Name = descripcion;

                var a = await manager.CreateAsync(role);
                if(a.Succeeded == true)
                {
                    var rol = await manager.FindByNameAsync(descripcion);
                    res.flag = true;
                    res.data_string = role.Id;
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
            }

            return res;
        }

        public static List<AspNetRoles> GetAll(string id)
        {
            List<AspNetRoles> res = new List<AspNetRoles>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_Rol(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new AspNetRoles();
                            item.id = row[idx].ToString(); idx++;
                            item.descripcion = row[idx].ToString(); idx++;
                            item.Activo = Int32.Parse(row[idx].ToString()); idx++;
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
                res = new List<AspNetRoles>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static AspNetRoles GetFromUser(string id)
        {
            AspNetRoles res = new AspNetRoles();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_UsuarioRol(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];
                        res.id = row[idx].ToString(); idx++;
                        res.descripcion = row[idx].ToString(); idx++;
                    }
                }
                else
                {
                    //
                }
            }
            catch (Exception ex)
            {
                res = new AspNetRoles();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static AspNetRoles GetFromuserV2(string id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            AspNetRoles result = new AspNetRoles();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT a.* FROM dbo.AspNetRoles as a, dbo.AspNetUserRoles as b where a.Id = b.RoleId and b.UserId = @Id", con);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                };
                cmd.Parameters.Add(param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var item = new AspNetRoles();
                            item.id = reader["Id"].ToString();
                            item.descripcion = reader["Name"].ToString();
                            result = item;
                        }
                    }
                    else
                    {
                        //result.errors.Add("No hay datos a mostrar");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                //result.errors.Add(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static RespuestaFormato Update(string id, string descripcion)
        {
            SqlConnection con = new SqlConnection(connstring);

            RespuestaFormato res = new RespuestaFormato();

            try
            {
                var query = "sd_UpdateAspNetRoles";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@Descripcion",
                    Value = descripcion
                };
                cmd.Parameters.Add(param);
                int success = cmd.ExecuteNonQuery();
                if (success > 0)
                {
                    res.flag = true;
                    res.description = "Datos creados correctamente.";
                }
                else
                {
                    res.flag = false;
                    res.description = "No se creo la información.";
                    res.errors.Add("No hay datos a actualizar");
                }
            }
            catch (Exception ex)
            {
                res.errors.Add(ex.Message);
                res.description = "Ocurrió un error.";
            }
            finally
            {
                con.Close();
            }

            return res;
        }
    }
}
