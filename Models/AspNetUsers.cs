using GISMVC.Data;
using Microsoft.AspNet.Identity;
using dll_Gis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GISMVC.Models
{
    public class UsuarioPortal
    {
        public AspNetUsers usuario { get; set; } = new AspNetUsers();
        public List<AccesoVistas> accesos { get; set; } = new List<AccesoVistas>();
        public List<proc_AccesoUsuarioNegocio> negocios { get; set; } = new List<proc_AccesoUsuarioNegocio>();
    }
    public class UsuarioExtra
    {
        public static string connstring = "";
        public int id { get; set; }
        public string usuario { get; set; }
        public int embajador { set; get; }
        public string referidor { set; get; }
        public int descuento { set; get; }
        public string cb { set; get; }
        public string banco { set; get; }
        public string clabe { set; get; }
        public string titular { set; get; }
        public List<int> l_productos { set; get; }

        public UsuarioExtra()
        {
            id = 0;
            usuario = "";
            referidor = "";
            embajador = 0;
            descuento = 0;
            cb = "";
            clabe = "";
            banco = "";
            titular = "";
            l_productos = new List<int>();
        }

        public static RespuestaFormato Update(UsuarioExtra modelo)
        {
            SqlConnection con = new SqlConnection(connstring);

            RespuestaFormato res = new RespuestaFormato();

            try
            {
                var query = "sd_UpdateUsuarioExtra";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@usuario",
                    Value = modelo.usuario
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@embajador",
                    Value = modelo.embajador
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@referidor",
                    Value = modelo.referidor
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@cb",
                    Value = modelo.cb
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@titular",
                    Value = modelo.titular
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@clabe",
                    Value = modelo.clabe
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@banco",
                    Value = modelo.banco
                };
                cmd.Parameters.Add(param);
                cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;

                int success = cmd.ExecuteNonQuery();
                if (success > 0)
                {
                    int folio = Int32.Parse(cmd.Parameters["@NewId"].Value.ToString());
                    res.flag = true;
                    res.description = "Datos creados correctamente.";
                    res.data_int = folio;
                }
                else
                {
                    res.flag = false;
                    res.description = "No se creo la información.";
                    res.errors.Add("No hay datos a actualizar o ya existe un registro con estos datos");
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

        public static UsuarioExtra GetFromUsuario(string id)
        {
            SqlConnection con = new SqlConnection(connstring);

            RespuestaFormato res = new RespuestaFormato();

            UsuarioExtra item = new UsuarioExtra();

            try
            {
                var query = "select * from dbo.UsuarioExtra where usuario = @Id";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                };
                cmd.Parameters.Add(param);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            item.id = Int32.Parse(reader["id"].ToString());
                            item.usuario = reader["usuario"].ToString();
                            item.referidor = reader["referidor"].ToString();
                            item.cb = reader["cb"].ToString();
                            item.titular = reader["titular"].ToString();
                            item.banco = reader["banco"].ToString();
                            item.clabe = reader["clabe"].ToString();
                            item.embajador = Int32.Parse(reader["embajador"].ToString());
                        }
                    }
                    else
                    {
                        res.errors.Add("No hay datos a mostrar");
                    }
                    reader.Close();
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

            return item;
        }
    }

    public class AspNetUsers
    {
        public string return_url { get; set; }
        public UserManager<ApplicationUser> _manager { get; private set; }
        public string id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string phone { get; set; }
        public string cellphone { get; set; }
        public string role { get; set; }
        public string usuariolg { get; set; }
        public string usuariolg_name { get; set; }
        public FechasFormato fecha_creacion { get; set; }
        public bool activo { get; set; }
        public string preflang { get; set; }
        public string name { get; set; }
        public string imagen { get; set; }
        public string banner { get; set; }
        public string password { get; set; }
        public string puesto { get; set; }
        public string direccion { get; set; }
        public string direccion2 { get; set; }
        public string direccion3 { get; set; }
        public string direccion4 { get; set; }
        public string distribuidor { get; set; }
        public string terminos { get; set; }
        public string notas { get; set; }
        public string formatomail { get; set; }
        public string gispassword { get; set; }
        public int pedidos { get; set; }
        public decimal rating { get; set; }
        public AspNetRoles roles { get; set; }
        public List<string> errors { get; set; }
        public int carrito { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int vendorid { get; set; }
        public Negocio negocio { get; set; }
        //public Permisos permisos { get; set; }
        public UsuarioExtra usuario_extra { get; set; }
        //
        //public List<RLUsuarioCategoria> categorias { get; set; }

        public AspNetUsers()
        {
            return_url = "";
            negocio = new Negocio();
            id = "";
            email = "";
            phone = "";
            cellphone = "";
            username = "";
            fecha_creacion = new FechasFormato();
            role = "";
            usuariolg = "";
            usuariolg_name = "";
            activo = false;
            password = "";
            puesto = "";
            errors = new List<string>();
            name = "No disponible";
            roles = new AspNetRoles();
            pedidos = 0;
            rating = 0;
            imagen = "";
            direccion = "";
            direccion2 = "";
            direccion3 = "";
            direccion4 = "";
            distribuidor = "";
            terminos = "";
            notas = "";
            formatomail = "Casa";
           // categorias = new List<RLUsuarioCategoria>();
            carrito = 0;
            nombre = "";
            apellidos = "";
            //permisos = new Permisos();
            gispassword = "";
            vendorid = 0;
            usuario_extra = new UsuarioExtra();
        }

        //--------------------------------------------------//
        public async Task<RespuestaFormato> AddAspNetUser(AspNetUsers modelo, UserManager<ApplicationUser> manager)
        {
            //SqlConnection con = new SqlConnection(Startup.GetConnectionString());
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                var create = await CreateAsync(modelo, manager);
                if (create.flag != false)
                {
                    var asignRole = await InsertAspNetUserRoles(create.data_string, modelo.role, manager);
                    if (asignRole.flag != false)
                    {
                        res.flag = true;
                        res.description = "Datos agregados correctamente";
                        res.data_string = create.data_string;
                    }
                    else
                    {
                        res.description = "No se pudieron actualizar los datos de rol y no se pudo eliminar el usuario recien creado.";
                    }
                }
                else
                {
                    res = create;
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

        public async Task<RespuestaFormato> CreateAsync(AspNetUsers modelo, UserManager<ApplicationUser> manager)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                var user = new ApplicationUser()
                {
                    UserName = modelo.username,
                    Email = modelo.email,
                    PhoneNumber = modelo.phone,
                    Names = modelo.name,
                    Cellphone = modelo.cellphone,
                    Puesto = modelo.puesto,
                    ///Recepcion = modelo.pedidos,
                    //Rating = modelo.rating,
                    //Direccion = modelo.direccion,
                    //Direccion2 = modelo.direccion2,
                    //Direccion3 = modelo.direccion3,
                    //Direccion4 = modelo.direccion4,
                    Imagen = modelo.imagen,
                    //Distribuidor = modelo.distribuidor,
                    //Terminos = modelo.terminos,
                    Notas = modelo.notas,
                    //FormatoMail = modelo.formatomail,
                    GisPassword = modelo.gispassword,
                    Usuario = modelo.usuariolg,
                    UsuarioNombre = modelo.usuariolg_name
                    //VendorId = modelo.vendorid
                };
                var manager_store = new UserStore<ApplicationUser>(new ApplicationDbContext());
                manager = new UserManager<ApplicationUser>(manager_store);
                IdentityResult result = await manager.CreateAsync(user, modelo.password);
                if (result.Succeeded)
                {
                    var newuser = await manager.FindByNameAsync(modelo.username);
                    res.data_string = newuser.Id;
                    res.flag = true;
                }
                else
                {
                    res.description = "Ocurrió un error.";
                    foreach (var error in result.Errors)
                    {
                        string te = "";
                        switch (error) //.Description
                        {
                            case "Passwords must be at least 6 characters.":
                                te = "La contraseña debe tener al menos 6 caracteres";
                                break;
                            case "Passwords must have at least one non alphanumeric character.":
                                te = "La contraseña debe tener al menos un caracter no alfanumérico";
                                break;
                            case "Passwords must have at least one digit ('0'-'9').":
                                te = "La contraseña debe tener al menos un número ('0'-'9')";
                                break;
                            case "Passwords must have at least one lowercase ('a'-'z').":
                                te = "La contraseña debe tener al menos una letra minúscula ('a'-'z')";
                                break;
                            case "Passwords must have at least one uppercase ('A'-'Z').":
                                te = "La contraseña debe tener al menos una letra mayúscula ('A'-'Z')";
                                break;
                            case "Passwords must use at least 1 different characters.":
                                te = "La contraseña debe tener al menos un caracter diferente";
                                break;

                        }
                        if (error == "DuplicateUserName") //.Code
                        {
                            te = "Ya hay un usuario registrado con este correo electrónico.";
                        }
                        res.errors.Add(te);
                    }
                }
            }
            catch (Exception ex)
            {
                res.errors.Add(ex.Message);
                if (!String.IsNullOrEmpty(ex.InnerException.Message))
                {
                    res.errors.Add(ex.InnerException.Message);
                }
            }

            return res;
        }

        public async Task<RespuestaFormato> InsertAspNetUserRoles(string id, string rol, UserManager<ApplicationUser> manager)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                var manager_store = new UserStore<ApplicationUser>(new ApplicationDbContext());
                manager = new UserManager<ApplicationUser>(manager_store);
                var user = await manager.FindByIdAsync(id);
                IdentityResult result = await manager.AddToRoleAsync(user.Id, rol);
                if (result.Succeeded)
                {
                    res.flag = true;
                    res.description = "Rol asignado correctamente.";
                }
                else
                {
                    res.flag = false;
                    res.description = "No se pudo asignar el rol correctamente.";
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Ocurrió un error al realizar la operación.";
                res.errors.Add(ex.Message);
            }
            finally
            {
            }
            return res;
        }

        public static AspNetUsers GetByNameV2(string id)
        {
            SqlConnection con = new SqlConnection("connectionstring");
            AspNetUsers result = new AspNetUsers();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.AspNetUsers WHERE UserName = @Id", con);
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
                            result = new AspNetUsers();
                            result.id = reader["Id"].ToString();
                            result.email = reader["Email"].ToString();
                            result.username = reader["Username"].ToString();
                            result.phone = reader["PhoneNumber"].ToString();
                            result.cellphone = reader["Cellphone"].ToString();
                            result.fecha_creacion = FechasFormato.GetFormatos(reader["FechaCreacion"].ToString());
                            result.puesto = reader["Puesto"].ToString();
                            result.name = reader["Names"].ToString();
                            result.direccion = reader["Direccion"].ToString();
                            result.direccion2 = reader["Direccion2"].ToString();
                            result.direccion3 = reader["Direccion3"].ToString();
                            result.direccion4 = reader["Direccion4"].ToString();
                            result.imagen = Utility.hosturl + reader["Imagen"].ToString().Replace(Utility.hosturl, "");
                            if (reader["Imagen"].ToString() == "")
                            {
                                result.imagen = Utility.hosturl + "images/default-image.png";
                            }
                            result.roles = AspNetRoles.GetFromUser(result.id);
                            result.pedidos = Int32.Parse(reader["Recepcion"].ToString());
                            result.rating = Decimal.Parse(reader["Rating"].ToString());
                            //switch (result.roles.descripcion)
                            //{
                            //    case "DISTRIBUIDOR":
                            //        result.categorias = RLUsuarioCategoria.GetFromUsuario(result.id);
                            //        break;
                            //}
                            int activo = Int32.Parse(reader["Activo"].ToString());
                            if (activo == 1)
                            {
                                result.activo = true;
                            }
                            result.terminos = reader["Terminos"].ToString();
                            result.notas = reader["Notas"].ToString();
                            result.formatomail = reader["FormatoMail"].ToString();
                            result.gispassword = reader["GisPassword"].ToString();
                            result.vendorid = Int32.Parse(reader["VendorId"].ToString());
                            //result.carrito = Carrito.GetFromUsuarioCount(result.id);
                            //result.permisos = Permisos.GetByUser(result.email);
                            result.usuario_extra = UsuarioExtra.GetFromUsuario(result.id);
                            List<string> nombres = result.name.Split('|').ToList();
                            if (nombres.Count > 0)
                            {
                                result.nombre = nombres[0];
                                if (nombres.Count > 1)
                                {
                                    result.apellidos = nombres[1];
                                }
                                else
                                {
                                    result.apellidos = "Sin especificar";
                                }
                            }
                            else
                            {
                                result.nombre = "Sin especificar";
                                result.apellidos = "Sin especificar";
                            }
                        }
                    }
                    else
                    {
                        result.errors.Add("No hay datos a mostrar");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                result.errors.Add(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return result;
        }


        public static List<Autocompletar> Autocomplete(string id)
        {
            List<Autocompletar> res = new List<Autocompletar>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_UsuarioAutocompletar(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new Autocompletar();
                            item.id = row[idx].ToString(); idx++;
                            item.value = row[idx].ToString();
                            item.label = row[idx].ToString(); idx++;
                            item.name = row[idx].ToString(); idx++;
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
                res = new List<Autocompletar>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<AspNetUsers> Get()
        {
            List<AspNetUsers> res = new List<AspNetUsers>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_Usuarios(out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new AspNetUsers();
                            item.id = row[idx].ToString(); idx++;
                            item.username = row[idx].ToString(); idx++;
                            item.email = row[idx].ToString(); idx++; idx++; idx++; idx++; idx++;
                            item.name = row[idx].ToString();
                            item.nombre = row[idx].ToString(); idx++;

                            item.roles = AspNetRoles.GetFromUser(item.id);

                            if (item.name == "NO NAME")
                            {
                                var split = item.username.Split('@').ToList();
                                if (split.Count > 0)
                                {
                                    item.name = split[0];
                                }
                                else
                                {
                                    item.name = item.username;
                                }
                            }
                            item.nombre = item.name;
                            res.Add(item);
                        }
                    }
                    else
                    {
                        //
                    }
                }
            }
            catch (Exception ex)
            {
                res = new List<AspNetUsers>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static AspNetUsers GetById(string id)
        {
            AspNetUsers res = new AspNetUsers();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_UsuarioById(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];
                        res.id = row[idx].ToString(); idx++;
                        res.email = row[idx].ToString(); idx++;
                        res.username = row[idx].ToString(); idx++;
                        res.phone = row[idx].ToString(); idx++;
                        res.cellphone = row[idx].ToString(); idx++;
                        res.fecha_creacion = FechasFormato.GetFormatos(row[idx].ToString()); idx++;

                        int activo = Int32.Parse(row[idx].ToString()); idx++;
                        if (activo == 1)
                        {
                            res.activo = true;
                        }
                        
                        res.name = row[idx].ToString(); res.nombre = row[idx].ToString(); idx++;
                        //idx++;
                        //idx++;
                        //res.vendorid = Int32.Parse(row[idx].ToString()); idx++;
                        //res.compania = row[idx].ToString(); idx++;

                        res.imagen = row[idx].ToString(); idx++;
                        res.puesto = row[idx].ToString(); idx++;
                        res.notas = row[idx].ToString(); idx++;
                        res.roles = AspNetRoles.GetFromUser(res.id);

                        res.negocio = Negocio.GetFromUsuario(res.id);

                        if (res.name == "NO NAME")
                        {
                            var split = res.username.Split('@').ToList();
                            if (split.Count > 0)
                            {
                                res.name = split[0];
                            }
                            else
                            {
                                res.name = res.username;
                            }
                        }
                        res.nombre = res.name;
                    }
                }
                else
                {
                    //
                }


            }
            catch (Exception ex)
            {
                res = new AspNetUsers();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static RespuestaFormato Update(AspNetUsers modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Upd_Usuario(modelo, out dt, out errores))
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

        public static AspNetUsers GetByName(string id)
        {
            AspNetUsers res = new AspNetUsers();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_UsuarioByName(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        int idx = 0;
                        var row = dt.Rows[0];
                        res.id = row[idx].ToString(); idx++;
                        res.email = row[idx].ToString(); idx++;
                        res.username = row[idx].ToString(); idx++;
                        res.phone = row[idx].ToString(); idx++;
                        res.cellphone = row[idx].ToString(); idx++;
                        res.fecha_creacion = FechasFormato.GetFormatos(row[idx].ToString()); idx++;
                        res.roles = AspNetRoles.GetFromUser(res.id);
                        int activo = Int32.Parse(row[idx].ToString());
                        if (activo == 1)
                        {
                            res.activo = true;
                        }
                        idx++;
                        res.name = row[idx].ToString(); idx++;
                        res.imagen = row[idx].ToString(); idx++;
                        res.puesto = row[idx].ToString(); idx++;
                        //res.direccion = row[idx].ToString(); idx++;
                        //res.direccion2 = row[idx].ToString(); idx++;
                        //res.direccion3 = row[idx].ToString(); idx++;
                        //res.direccion4 = row[idx].ToString(); idx++;
                        //res.distribuidor = row[idx].ToString(); idx++;
                        //res.terminos = row[idx].ToString(); idx++;
                        res.notas = row[idx].ToString(); idx++;
                        //res.formatomail = row[idx].ToString(); idx++;
                        res.gispassword = row[idx].ToString(); idx++;
                        //res.pedidos = Int32.Parse(row[idx].ToString()); idx++;
                        //res.vendorid = Int32.Parse(row[idx].ToString()); idx++;
                        //res.compania = row[idx].ToString(); idx++;
                        //res.rfc = row[idx].ToString(); idx++;
                        List<string> nombres = res.name.Split('|').ToList();
                        if (nombres.Count > 0)
                        {
                            res.nombre = nombres[0];
                            if (nombres.Count > 1)
                            {
                                res.apellidos = nombres[1];
                            }
                            else
                            {
                                res.apellidos = "Sin especificar";
                            }
                        }
                        else
                        {
                            res.nombre = "Sin especificar";
                            res.apellidos = "Sin especificar";
                        }


                        if (res.name == "NO NAME")
                        {
                            var split = res.username.Split('@').ToList();
                            if (split.Count > 0)
                            {
                                res.name = split[0];
                            }
                            else
                            {
                                res.name = res.username;
                            }
                        }
                        res.nombre = res.name;
                    }
                }
                else
                {
                    //
                }


            }
            catch (Exception ex)
            {
                res = new AspNetUsers();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<AspNetUsers> GetByPuesto(string id)
        {
            List<AspNetUsers> res = new List<AspNetUsers>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_UsuarioByPuesto(id.ToUpper(), out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for(int i = 0; i < dt.Rows.Count; i++)
                        {

                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new AspNetUsers();
                            item.id = row[idx].ToString(); idx++;
                            item.email = row[idx].ToString(); idx++;
                            item.username = row[idx].ToString(); idx++;
                            item.phone = row[idx].ToString(); idx++;
                            item.cellphone = row[idx].ToString(); idx++;
                            item.fecha_creacion = FechasFormato.GetFormatos(row[idx].ToString()); idx++;
                            item.roles = AspNetRoles.GetFromUser(item.id);
                            int activo = Int32.Parse(row[idx].ToString());
                            if (activo == 1)
                            {
                                item.activo = true;
                            }
                            idx++;
                            item.name = row[idx].ToString(); idx++;
                            item.imagen = row[idx].ToString(); idx++;
                            item.puesto = row[idx].ToString(); idx++;
                            item.direccion = row[idx].ToString(); idx++;
                            item.direccion2 = row[idx].ToString(); idx++;
                            item.direccion3 = row[idx].ToString(); idx++;
                            item.direccion4 = row[idx].ToString(); idx++;
                            item.distribuidor = row[idx].ToString(); idx++;
                            item.terminos = row[idx].ToString(); idx++;
                            item.notas = row[idx].ToString(); idx++;
                            item.formatomail = row[idx].ToString(); idx++;
                            item.gispassword = row[idx].ToString(); idx++;
                            item.pedidos = Int32.Parse(row[idx].ToString()); idx++;
                            item.vendorid = Int32.Parse(row[idx].ToString()); idx++;
                            //item.compania = row[idx].ToString(); idx++;
                            //item.rfc = row[idx].ToString(); idx++;
                            List<string> nombitem = item.name.Split('|').ToList();
                            if (nombitem.Count > 0)
                            {
                                item.nombre = nombitem[0];
                                if (nombitem.Count > 1)
                                {
                                    item.apellidos = nombitem[1];
                                }
                                else
                                {
                                    item.apellidos = "Sin especificar";
                                }
                            }
                            else
                            {
                                item.nombre = "Sin especificar";
                                item.apellidos = "Sin especificar";
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
                res = new List<AspNetUsers>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static List<AspNetUsers> GetByRol(string id)
        {
            List<AspNetUsers> res = new List<AspNetUsers>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_UsuarioByRol(id, out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new AspNetUsers();
                            item.id = row[idx].ToString(); idx++;
                            item.username = row[idx].ToString(); idx++;
                            item.email = row[idx].ToString(); idx++; idx++; idx++; idx++; idx++;
                            item.name = row[idx].ToString();
                            item.nombre = row[idx].ToString(); idx++;

                            item.roles = AspNetRoles.GetFromUser(item.id);

                            if (item.name == "NO NAME")
                            {
                                var split = item.username.Split('@').ToList();
                                if (split.Count > 0)
                                {
                                    item.name = split[0];
                                }
                                else
                                {
                                    item.name = item.username;
                                }
                            }
                            item.nombre = item.name;
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
                res = new List<AspNetUsers>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

        public static RespuestaFormato Exists(string id)
        {
            SqlConnection con = new SqlConnection("conectionstring");
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM dbo.AspNetUsers WHERE UserName = @Id", con);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                };
                cmd.Parameters.Add(param);

                int success = Int32.Parse(cmd.ExecuteScalar().ToString());
                if(success > 0)
                {
                    res.flag = true;
                }
            }
            catch (Exception ex)
            {
                res.errors.Add(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return res;
        }
        public static List<AspNetUsers> GetAll(string id)
        {
            List<AspNetUsers> res = new List<AspNetUsers>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_Usuarios(out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new AspNetUsers();
                            item.id = row[idx].ToString(); idx++;
                            item.email = row[idx].ToString(); idx++;
                            item.username = row[idx].ToString(); idx++;
                            item.phone = row[idx].ToString(); idx++;
                            item.cellphone = row[idx].ToString(); idx++;
                            item.fecha_creacion = FechasFormato.GetFormatos(row[idx].ToString()); idx++;
                            item.roles = AspNetRoles.GetFromUser(item.id);
                            int activo = Int32.Parse(row[idx].ToString());
                            if (activo == 1)
                            {
                                item.activo = true;
                            }
                            idx++;
                            item.name = row[idx].ToString(); idx++;
                            item.imagen = row[idx].ToString(); idx++;
                            item.puesto = row[idx].ToString(); idx++;
                            //res.direccion = row[idx].ToString(); idx++;
                            //res.direccion2 = row[idx].ToString(); idx++;
                            //res.direccion3 = row[idx].ToString(); idx++;
                            //res.direccion4 = row[idx].ToString(); idx++;
                            //res.distribuidor = row[idx].ToString(); idx++;
                            //res.terminos = row[idx].ToString(); idx++;
                            item.notas = row[idx].ToString(); idx++;
                            //res.formatomail = row[idx].ToString(); idx++;
                            item.gispassword = row[idx].ToString(); idx++;
                            //res.pedidos = Int32.Parse(row[idx].ToString()); idx++;
                            //res.vendorid = Int32.Parse(row[idx].ToString()); idx++;
                            //res.compania = row[idx].ToString(); idx++;
                            //res.rfc = row[idx].ToString(); idx++;
                            List<string> nombres = item.name.Split('|').ToList();
                            if (nombres.Count > 0)
                            {
                                item.nombre = nombres[0];
                                if (nombres.Count > 1)
                                {
                                    item.apellidos = nombres[1];
                                }
                                else
                                {
                                    item.apellidos = "Sin especificar";
                                }
                            }
                            else
                            {
                                item.nombre = "Sin especificar";
                                item.apellidos = "Sin especificar";
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
                res = new List<AspNetUsers>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }


        public static List<AspNetUsers> GetAllV2(string id)
        {
            List<AspNetUsers> res = new List<AspNetUsers>();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Cons_UsuariosV2(out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new AspNetUsers();
                            item.id = row[idx].ToString(); idx++;
                            item.email = row[idx].ToString(); idx++;
                            item.username = row[idx].ToString(); idx++;
                            item.phone = row[idx].ToString(); idx++;
                            item.cellphone = row[idx].ToString(); idx++;
                            item.fecha_creacion = FechasFormato.GetFormatos(row[idx].ToString()); idx++;
                            item.roles = AspNetRoles.GetFromUser(item.id);
                            int activo = Int32.Parse(row[idx].ToString());
                            if (activo == 1)
                            {
                                item.activo = true;
                            }
                            idx++;
                            item.name = row[idx].ToString(); idx++;
                            item.imagen = row[idx].ToString(); idx++;
                            item.puesto = row[idx].ToString(); idx++;
                            //res.direccion = row[idx].ToString(); idx++;
                            //res.direccion2 = row[idx].ToString(); idx++;
                            //res.direccion3 = row[idx].ToString(); idx++;
                            //res.direccion4 = row[idx].ToString(); idx++;
                            //res.distribuidor = row[idx].ToString(); idx++;
                            //res.terminos = row[idx].ToString(); idx++;
                            item.notas = row[idx].ToString(); idx++;
                            //res.formatomail = row[idx].ToString(); idx++;
                            item.gispassword = row[idx].ToString(); idx++;
                            //res.pedidos = Int32.Parse(row[idx].ToString()); idx++;
                            //res.vendorid = Int32.Parse(row[idx].ToString()); idx++;
                            //res.compania = row[idx].ToString(); idx++;
                            //res.rfc = row[idx].ToString(); idx++;
                            List<string> nombres = item.name.Split('|').ToList();
                            if (nombres.Count > 0)
                            {
                                item.nombre = nombres[0];
                                if (nombres.Count > 1)
                                {
                                    item.apellidos = nombres[1];
                                }
                                else
                                {
                                    item.apellidos = "Sin especificar";
                                }
                            }
                            else
                            {
                                item.nombre = "Sin especificar";
                                item.apellidos = "Sin especificar";
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
                res = new List<AspNetUsers>();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
        public static List<AspNetUsers> GetAll()
        {
            SqlConnection con = new SqlConnection("connectionstring");
            List<AspNetUsers> result = new List<AspNetUsers>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.AspNetUsers", con);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var item = new AspNetUsers();
                            item.id = reader["Id"].ToString();
                            item.email = reader["Email"].ToString();
                            item.username = reader["Username"].ToString();
                            item.phone = reader["PhoneNumber"].ToString();
                            item.cellphone = reader["Cellphone"].ToString();
                            item.fecha_creacion = FechasFormato.GetFormatos(reader["FechaCreacion"].ToString());
                            item.puesto = reader["Puesto"].ToString();
                            item.name = reader["Names"].ToString();
                            item.direccion = reader["Direccion"].ToString();
                            item.direccion2 = reader["Direccion2"].ToString();
                            item.direccion3 = reader["Direccion3"].ToString();
                            item.direccion4 = reader["Direccion4"].ToString();
                            item.imagen = Utility.hosturl + reader["Imagen"].ToString().Replace(Utility.hosturl, "");
                            if (reader["Imagen"].ToString() == "")
                            {
                                item.imagen = Utility.hosturl + "images/default-image.png";
                            }
                            item.roles = AspNetRoles.GetFromUser(item.id);
                            item.pedidos = Int32.Parse(reader["Recepcion"].ToString());
                            item.rating = Decimal.Parse(reader["Rating"].ToString());
                            //switch (result.roles.descripcion)
                            //{
                            //    case "DISTRIBUIDOR":
                            //        result.categorias = RLUsuarioCategoria.GetFromUsuario(result.id);
                            //        break;
                            //}
                            int activo = Int32.Parse(reader["Activo"].ToString());
                            if (activo == 1)
                            {
                                item.activo = true;
                            }
                            item.terminos = reader["Terminos"].ToString();
                            item.notas = reader["Notas"].ToString();
                            item.formatomail = reader["FormatoMail"].ToString();
                            item.gispassword = reader["GisPassword"].ToString();
                            item.vendorid = Int32.Parse(reader["VendorId"].ToString());
                            //result.carrito = Carrito.GetFromUsuarioCount(result.id);
                            //result.permisos = Permisos.GetByUser(result.email);
                            item.usuario_extra = UsuarioExtra.GetFromUsuario(item.id);
                            List<string> nombres = item.name.Split('|').ToList();
                            if (nombres.Count > 0)
                            {
                                item.nombre = nombres[0];
                                if (nombres.Count > 1)
                                {
                                    item.apellidos = nombres[1];
                                }
                                else
                                {
                                    item.apellidos = "Sin especificar";
                                }
                            }
                            else
                            {
                                item.nombre = "Sin especificar";
                                item.apellidos = "Sin especificar";
                            }
                            result.Add(item);
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

        public static async Task<RespuestaFormato> ChangePassword(AspNetUsers modelo, UserManager<ApplicationUser> manager)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                var manager_store = new UserStore<ApplicationUser>(new ApplicationDbContext());
                manager = new UserManager<ApplicationUser>(manager_store);
                var user = await manager.FindByIdAsync(modelo.id);
                var remove = await manager.RemovePasswordAsync(user.Id);
                if (!remove.Succeeded)
                {
                    res.description = "No se pudieron actualizar los datos.";
                }
                else
                {
                    var add = await manager.AddPasswordAsync(user.Id, modelo.password);
                    if (!add.Succeeded)
                    {
                        res.description = "No se pudieron crear los datos.";
                        foreach (var error in add.Errors)
                        {
                            string te = "";
                            switch (error)
                            {
                                case "Passwords must be at least 6 characters.":
                                    te = "La contraseña debe tener al menos 6 caracteres";
                                    break;
                                case "Passwords must have at least one non alphanumeric character.":
                                    te = "La contraseña debe tener al menos un caracter no alfanumérico";
                                    break;
                                case "Passwords must have at least one digit ('0'-'9').":
                                    te = "La contraseña debe tener al menos un número ('0'-'9')";
                                    break;
                                case "Passwords must have at least one lowercase ('a'-'z').":
                                    te = "La contraseña debe tener al menos una letra minúscula ('a'-'z')";
                                    break;
                                case "Passwords must have at least one uppercase ('A'-'Z').":
                                    te = "La contraseña debe tener al menos una letra mayúscula ('A'-'Z')";
                                    break;
                                case "Passwords must use at least 1 different characters.":
                                    te = "La contraseña debe tener al menos un caracter diferente";
                                    break;

                            }
                            res.errors.Add(te);
                        }
                    }
                    else
                    {
                        res.flag = true;
                        res.description = "Datos actualizados";
                    }
                }
            }
            catch (Exception ex)
            {
                res.errors.Add(ex.Message);
                res.description = "Ocurrió un error.";
            }
            finally
            {
            }
            return res;
        }

        public static RespuestaFormato UpdateActivo(AspNetUsers modelo)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.Upd_UsuarioActivo(modelo, out dt, out errores))
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
        /*
        

        public static RespuestaFormato UpdateActivo(AspNetUsers modelo)
        {
            SqlConnection con = new SqlConnection(Startup.GetConnectionString());

            RespuestaFormato res = new RespuestaFormato();

            try
            {
                var query = "sd_UpdateUsuarioActivo";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = modelo.id
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

        public static RespuestaFormato UpdateDescuento(AspNetUsers modelo)
        {
            SqlConnection con = new SqlConnection(Startup.GetConnectionString());

            RespuestaFormato res = new RespuestaFormato();

            try
            {
                var query = "sd_UpdateUsuarioDescuento";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = modelo.id
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@descuento",
                    Value = modelo.rating
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
        public static AspNetUsers GetById(string id)
        {
            SqlConnection con = new SqlConnection(Startup.GetConnectionString());
            AspNetUsers result = new AspNetUsers();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.AspNetUsers WHERE Id = @Id", con);
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
                            result = new AspNetUsers();
                            result.id = reader["Id"].ToString();
                            result.email = reader["Email"].ToString();
                            result.username = reader["Username"].ToString();
                            result.phone = reader["PhoneNumber"].ToString();
                            result.cellphone = reader["Cellphone"].ToString();
                            result.fecha_creacion = FechasFormato.GetFormatos(reader["FechaCreacion"].ToString());
                            result.puesto = reader["Puesto"].ToString();
                            result.name = reader["Names"].ToString();

                            List<string> nombres = result.name.Split("|").ToList();
                            if(nombres.Count > 0)
                            {
                                result.nombre = nombres[0];
                                if (nombres.Count > 1)
                                {
                                    result.apellidos = nombres[1];
                                }
                                else
                                {
                                    result.apellidos = "Sin especificar";
                                }
                            }
                            else
                            {
                                result.nombre = "Sin especificar";
                                result.apellidos = "Sin especificar";
                            }

                            result.direccion = reader["Direccion"].ToString();
                            result.direccion2 = reader["Direccion2"].ToString();
                            result.direccion3 = reader["Direccion3"].ToString();
                            result.direccion4 = reader["Direccion4"].ToString();
                            result.imagen = Utility.hosturl + reader["Imagen"].ToString().Replace(Utility.hosturl,"");
                            if(reader["Imagen"].ToString() == "")
                            {
                                result.imagen = Utility.hosturl + "images/default-image.png";
                            }
                            result.roles = AspNetRoles.GetFromuser(result.id);
                            result.pedidos = Int32.Parse(reader["Recepcion"].ToString());
                            result.rating = Decimal.Parse(reader["Rating"].ToString());
                            switch (result.roles.descripcion)
                            {
                                case "DISTRIBUIDOR":
                                    result.categorias = RLUsuarioCategoria.GetFromUsuario(result.id);
                                    break;
                            }
                            result.terminos = reader["Terminos"].ToString();
                            result.notas = reader["Notas"].ToString();
                            result.formatomail = reader["FormatoMail"].ToString();
                            result.usuario_extra = UsuarioExtra.GetFromUsuario(result.id);
                        }
                    }
                    else
                    {
                        result.errors.Add("No hay datos a mostrar");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                result.errors.Add(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return result;
        }


        public static AspNetUsers GetDistribuidor(string id)
        {
            SqlConnection con = new SqlConnection(Startup.GetConnectionString());
            AspNetUsers result = new AspNetUsers();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sd_SelectDistribuidor", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = id
                };
                cmd.Parameters.Add(param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = new AspNetUsers();
                            result.id = reader["Id"].ToString();
                            result.email = reader["Email"].ToString();
                            result.username = reader["Username"].ToString();
                            result.phone = reader["PhoneNumber"].ToString();
                            result.cellphone = reader["Cellphone"].ToString();
                            result.fecha_creacion = FechasFormato.GetFormatos(reader["FechaCreacion"].ToString());
                            result.puesto = reader["Puesto"].ToString();
                            result.name = reader["Names"].ToString();
                            result.direccion = reader["Direccion"].ToString();
                            result.direccion2 = reader["Direccion2"].ToString();
                            result.direccion3 = reader["Direccion3"].ToString();
                            result.direccion4 = reader["Direccion4"].ToString();
                            result.terminos = reader["Terminos"].ToString();
                            result.notas = reader["Notas"].ToString();
                            result.imagen = Utility.hosturl + reader["Imagen"].ToString();
                            if (reader["Imagen"].ToString() == "")
                            {
                                result.imagen = Utility.hosturl + "images/default-image.png";
                            }
                            result.roles = AspNetRoles.GetFromuser(result.id);
                            result.pedidos = Int32.Parse(reader["Recepcion"].ToString());
                            result.rating = Decimal.Parse(reader["Rating"].ToString());
                            switch (result.roles.descripcion)
                            {
                                case "DISTRIBUIDOR":
                                    result.categorias = RLUsuarioCategoria.GetFromUsuario(result.id);
                                    break;
                            }
                            result.formatomail = reader["FormatoMail"].ToString();
                        }
                    }
                    else
                    {
                        result.errors.Add("No hay datos a mostrar");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                result.errors.Add(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static RespuestaFormato Update(AspNetUsers modelo)
        {
            SqlConnection con = new SqlConnection(Startup.GetConnectionString());

            RespuestaFormato res = new RespuestaFormato();

            try
            {
                var query = "sd_UpdateAspNetUser";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = modelo.id
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@nombre",
                    Value = modelo.name
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@email",
                    Value = modelo.email
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@telefono",
                    Value = modelo.phone
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@celular",
                    Value = modelo.cellphone
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@rating",
                    Value = modelo.rating
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@direccion",
                    Value = modelo.direccion
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@direccion2",
                    Value = modelo.direccion2
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@direccion3",
                    Value = modelo.direccion3
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@direccion4",
                    Value = modelo.direccion4
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@imagen",
                    Value = modelo.imagen.Replace(Utility.hosturl, "")
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@terminos",
                    Value = modelo.terminos
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@notas",
                    Value = modelo.notas
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@formatomail",
                    Value = modelo.formatomail
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@puesto",
                    Value = modelo.puesto
                };
                cmd.Parameters.Add(param);
                int success = cmd.ExecuteNonQuery();
                if (success > 0)
                {
                    res.flag = true;
                    res.description = "Datos creados correctamente.";
                    res.data_string = modelo.id;
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
                if(ex.Message.Contains("Cannot insert duplicate key row in object 'dbo.AspNetUsers' with unique index 'UserNameIndex'. The duplicate key value is"))
                {
                    res.errors.Add("Ya hay un usuario registrado con este correo electrónico.");
                }
                res.description = "Ocurrió un error.";
            }
            finally
            {
                con.Close();
            }

            return res;
        }

        public static List<AspNetUsers> GetByRol(string tipo)
        {
            SqlConnection con = new SqlConnection(Startup.GetConnectionString());
            List<AspNetUsers> result = new List<AspNetUsers>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT a.* FROM dbo.AspNetUsers as a, dbo.AspNetUserRoles as b, dbo.AspNetRoles as c where a.Id = b.UserId and b.RoleId = c.Id and c.NormalizedName = @Tipo", con);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@Tipo",
                    Value = tipo
                };
                cmd.Parameters.Add(param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var item = new AspNetUsers();
                            item.id = reader["Id"].ToString();
                            item.email = reader["Email"].ToString();
                            item.username = reader["Username"].ToString();
                            item.phone = reader["PhoneNumber"].ToString();
                            item.cellphone = reader["Cellphone"].ToString();
                            item.fecha_creacion = FechasFormato.GetFormatos(reader["FechaCreacion"].ToString());
                            item.puesto = reader["Puesto"].ToString();
                            item.name = reader["Names"].ToString();
                            item.roles = AspNetRoles.GetFromuser(item.id);
                            item.rating = Decimal.Parse(reader["Rating"].ToString());
                            result.Add(item);
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
        //--------------------------------------------------//


        

        public static AspNetUsers GetByUniqueId(string id)
        {
            SqlConnection con = new SqlConnection(Startup.GetConnectionString());
            AspNetUsers result = new AspNetUsers();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.AspNetUsers WHERE Id = @Id", con);
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
                            result = new AspNetUsers();
                            result.id = reader["Id"].ToString();
                            result.email = reader["Email"].ToString();
                            result.username = reader["Username"].ToString();
                            result.phone = reader["PhoneNumber"].ToString();
                            //result.fecha_creacion = FechasFormato.GetFormatos(reader["CreatedAt"].ToString());
                            //result.role = reader["Role"].ToString();
                            result.name = reader["Names"].ToString();
                            //result.activo = Boolean.Parse(reader["Active"].ToString());
                            //result.imagen = RLImagenUsuario.ImagenFromUsuario(result.id);
                            //result.banner = RLBannerUsuario.ImagenFromUsuario(result.id);
                            result.roles = AspNetRoles.GetFromuser(result.id);
                        }
                    }
                    else
                    {
                        result.errors.Add("No hay datos a mostrar");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                result.errors.Add(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static AspNetUsers GetByName(string id)
        {
            SqlConnection con = new SqlConnection(Startup.GetConnectionString());
            AspNetUsers result = new AspNetUsers();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.AspNetUsers WHERE UserName = @Id", con);
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
                            result = new AspNetUsers();
                            result.id = reader["Id"].ToString();
                            result.email = reader["Email"].ToString();
                            result.username = reader["Username"].ToString();
                            result.phone = reader["PhoneNumber"].ToString();
                            result.cellphone = reader["Cellphone"].ToString();
                            result.fecha_creacion = FechasFormato.GetFormatos(reader["FechaCreacion"].ToString());
                            result.puesto = reader["Puesto"].ToString();
                            result.name = reader["Names"].ToString();
                            result.direccion = reader["Direccion"].ToString();
                            result.direccion2 = reader["Direccion2"].ToString();
                            result.direccion3 = reader["Direccion3"].ToString();
                            result.direccion4 = reader["Direccion4"].ToString();
                            result.imagen = Utility.hosturl + reader["Imagen"].ToString().Replace(Utility.hosturl, "");
                            if (reader["Imagen"].ToString() == "")
                            {
                                result.imagen = Utility.hosturl + "images/default-image.png";
                            }
                            result.roles = AspNetRoles.GetFromuser(result.id);
                            result.pedidos = Int32.Parse(reader["Recepcion"].ToString());
                            result.rating = Decimal.Parse(reader["Rating"].ToString());
                            switch (result.roles.descripcion)
                            {
                                case "DISTRIBUIDOR":
                                    result.categorias = RLUsuarioCategoria.GetFromUsuario(result.id);
                                    break;
                            }
                            int activo = Int32.Parse(reader["Activo"].ToString());
                            if (activo == 1)
                            {
                                result.activo = true;
                            }
                            result.terminos = reader["Terminos"].ToString();
                            result.notas = reader["Notas"].ToString();
                            result.formatomail = reader["FormatoMail"].ToString();
                            result.carrito = Carrito.GetFromUsuarioCount(result.id);
                            result.permisos = Permisos.GetByUser(result.email);
                            result.usuario_extra = UsuarioExtra.GetFromUsuario(result.id);
                            List<string> nombres = result.name.Split("|").ToList();
                            if (nombres.Count > 0)
                            {
                                result.nombre = nombres[0];
                                if (nombres.Count > 1)
                                {
                                    result.apellidos = nombres[1];
                                }
                                else
                                {
                                    result.apellidos = "Sin especificar";
                                }
                            }
                            else
                            {
                                result.nombre = "Sin especificar";
                                result.apellidos = "Sin especificar";
                            }
                        }
                    }
                    else
                    {
                        result.errors.Add("No hay datos a mostrar");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                result.errors.Add(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        

        public static List<AspNetUsers> EmbajadoresReferidos()
        {
            SqlConnection con = new SqlConnection(Startup.GetConnectionString());
            List<AspNetUsers> result = new List<AspNetUsers>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sd_EmbajadoresReferidosDiarios", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var item = new AspNetUsers();
                            item.id = reader["Id"].ToString();
                            item.email = reader["Email"].ToString();
                            item.username = reader["Username"].ToString();
                            item.phone = reader["PhoneNumber"].ToString();
                            //result.fecha_creacion = FechasFormato.GetFormatos(reader["CreatedAt"].ToString());
                            //result.role = reader["Role"].ToString();
                            item.name = reader["Names"].ToString();
                            item.roles = AspNetRoles.GetFromuser(item.id);
                            //result.activo = Boolean.Parse(reader["Active"].ToString());
                            //result.imagen = RLImagenUsuario.ImagenFromUsuario(result.id);
                            //result.banner = RLBannerUsuario.ImagenFromUsuario(result.id);
                            result.Add(item);
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

        public static List<AspNetUsers> ReferidosDiariosEmbajador(string id)
        {
            SqlConnection con = new SqlConnection(Startup.GetConnectionString());
            List<AspNetUsers> result = new List<AspNetUsers>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sd_ReferidosDiariosFromEmbajador", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = id
                };
                cmd.Parameters.Add(param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var item = new AspNetUsers();
                            item.id = reader["Id"].ToString();
                            item.email = reader["Email"].ToString();
                            item.username = reader["Username"].ToString();
                            item.phone = reader["PhoneNumber"].ToString();
                            //result.fecha_creacion = FechasFormato.GetFormatos(reader["CreatedAt"].ToString());
                            //result.role = reader["Role"].ToString();
                            item.name = reader["Names"].ToString();
                            item.roles = AspNetRoles.GetFromuser(item.id);
                            //result.activo = Boolean.Parse(reader["Active"].ToString());
                            //result.imagen = RLImagenUsuario.ImagenFromUsuario(result.id);
                            //result.banner = RLBannerUsuario.ImagenFromUsuario(result.id);
                            result.Add(item);
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

        public static List<AspNetUsers> GetByType(string tipo)
        {
            SqlConnection con = new SqlConnection(Startup.GetConnectionString());
            List<AspNetUsers> result = new List<AspNetUsers>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT a.* FROM dbo.AspNetUsers as a, dbo.AspNetUserRoles as b, dbo.AspNetRoles as c where a.Id = b.UserId and b.RoleId = c.Id and c.NormalizedName = @Tipo", con);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@Tipo",
                    Value = tipo
                };
                cmd.Parameters.Add(param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var item = new AspNetUsers();
                            item.id = reader["Id"].ToString();
                            item.email = reader["Email"].ToString();
                            item.username = reader["Username"].ToString();
                            item.phone = reader["PhoneNumber"].ToString();
                            //result.fecha_creacion = FechasFormato.GetFormatos(reader["CreatedAt"].ToString());
                            //result.role = reader["Role"].ToString();
                            item.name = reader["Names"].ToString();
                            item.roles = AspNetRoles.GetFromuser(item.id);
                            //result.activo = Boolean.Parse(reader["Active"].ToString());
                            //result.imagen = RLImagenUsuario.ImagenFromUsuario(result.id);
                            //result.banner = RLBannerUsuario.ImagenFromUsuario(result.id);
                            result.Add(item);
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

        public static string GetName(string id)
        {
            SqlConnection con = new SqlConnection(Startup.GetConnectionString());
            AspNetUsers result = new AspNetUsers();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.AspNetUsers WHERE Id = @Id", con);
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
                            result.id = reader["Id"].ToString();
                            result.email = reader["Email"].ToString();
                            result.username = reader["Username"].ToString();
                            result.phone = reader["PhoneNumber"].ToString();
                            result.name = reader["Names"].ToString();
                        }
                    }
                    else
                    {
                        result.errors.Add("No hay datos a mostrar");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                result.errors.Add(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return result.name;
        }

        public static string GetId(string username)
        {
            SqlConnection con = new SqlConnection(Startup.GetConnectionString());
            AspNetUsers result = new AspNetUsers();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.AspNetUsers WHERE UserName = @Username", con);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@Username",
                    Value = username
                };
                cmd.Parameters.Add(param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = new AspNetUsers();
                            result.id = reader["Id"].ToString();
                            result.email = reader["Email"].ToString();
                            result.username = reader["Username"].ToString();
                            result.phone = reader["PhoneNumber"].ToString();
                            //result.fecha_creacion = FechasFormato.GetFormatos(reader["CreatedAt"].ToString());
                            //result.role = reader["Role"].ToString();
                            result.name = result.username;// reader["Name"].ToString();
                            //result.activo = Boolean.Parse(reader["Active"].ToString());
                            //result.imagen = RLImagenUsuario.ImagenFromUsuario(result.id);
                            //result.banner = RLBannerUsuario.ImagenFromUsuario(result.id);
                        }
                    }
                    else
                    {
                        result.errors.Add("No hay datos a mostrar");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                result.errors.Add(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return result.id;
        }

        //

        public static RespuestaFormato ActualizaUsuario(AspNetUsers modelo)
        {
            SqlConnection con = new SqlConnection(Startup.GetConnectionString());

            RespuestaFormato res = new RespuestaFormato();

            try
            {
                var query = "sd_ActualizaUsuario";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = modelo.id
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@Names",
                    Value = modelo.name
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@Email",
                    Value = modelo.email
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@Telefono",
                    Value = modelo.phone
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@Rol",
                    Value = modelo.role
                };
                cmd.Parameters.Add(param);
                int success = cmd.ExecuteNonQuery();
                if (success > 0)
                {
                    res.flag = true;
                    res.description = "Datos creados correctamente.";
                    res.data_string = modelo.id;
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

        public static RespuestaFormato UpdateEmpresa(string usuario, int empresa)
        {
            SqlConnection con = new SqlConnection(Startup.GetConnectionString());

            RespuestaFormato res = new RespuestaFormato();

            try
            {
                var query = "update dbo.AspNetUsers set Recepcion = @empresa where Id = @id";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = usuario
                };
                cmd.Parameters.Add(param);
                param = new SqlParameter()
                {
                    ParameterName = "@empresa",
                    Value = empresa
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

        public static RespuestaFormato Eliminar(string usuario)
        {
            SqlConnection con = new SqlConnection(Startup.GetConnectionString());

            RespuestaFormato res = new RespuestaFormato();

            try
            {
                var query = "delete from dbo.AspNetUsers where Id = @id";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = usuario
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

        public static RespuestaFormato ActualizarRol(string usuario, string rol)
        {
            SqlConnection con = new SqlConnection(Startup.GetConnectionString());

            RespuestaFormato res = new RespuestaFormato();

            try
            {
                var roles = AspNetRoles.GetAll("'test'").Where(i=> i.descripcion.ToUpper() == rol.ToUpper()).ToList();
                if(roles.Count > 0)
                {
                    var query = "update dbo.AspNetUserRoles set RoleId = @id where UserId = @usuario";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = roles[0].id
                    };
                    cmd.Parameters.Add(param);
                    param = new SqlParameter()
                    {
                        ParameterName = "@usuario",
                        Value = usuario
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
                else
                {
                    res.flag = false;
                    res.description = "No existe el rol.";
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
        }*/
    }
}
