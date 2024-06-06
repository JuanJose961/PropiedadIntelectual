using GISMVC.Data;
using GISMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;

namespace GISMVC.Controllers
{
    public class WebAPIController : ApiController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public WebAPIController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)//, IHostingEnvironment env, SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger, IConverter converter
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            /*this._env = env;
            _converter = converter;
            _signInManager = signInManager;
            _logger = logger;*/
        }

        public WebAPIController()//, IHostingEnvironment env, SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger, IConverter converter
        {
        }

        [Route("api/WebAPI/Login")]
        [HttpPost]
        public async Task<RespuestaFormato> Login([FromBody] AspNetUsers modelo)
        {
            dll_Gis.Funciones fn = new dll_Gis.Funciones();
            var res = new RespuestaFormato();
            //--------------------
            try
            {   //HACER LOGIN EN LA APLICACION
                var appcontext = new ApplicationDbContext();
                var userStore = new UserStore<ApplicationUser>(appcontext);
                var manager = new UserManager<ApplicationUser>(userStore);
                var user = manager.Find(modelo.username, modelo.password);

                //SI EL USUARIO EXISTE
                if(user != null)
                {
                    var rol = AspNetUsers.GetByName(modelo.username);
                    if (rol.activo != false)
                    {
                        var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                        var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                        authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

                        var appuserv1 = new ApplicationUser()
                        {
                            UserName = rol.username,
                            Names = rol.name,
                            Email = rol.email,
                            Id = rol.id,
                            Imagen = ""
                        };

                        var accesos = AccesoVistas.GetFromUsuario(rol.id);
                        var negocios = proc_AccesoUsuarioNegocio.GetFromUsuario(rol.id);

                        UsuarioPortal appuser = new UsuarioPortal();
                        appuser.usuario = rol;
                        appuser.accesos = accesos;
                        appuser.negocios = negocios;
                        AuthHelper.SignInV2(appuser);

                        //INICIAR SESION
                        res.flag = true;
                        res.description = "Usuario loggeado";
                        res.content.Add(rol);
                        return res;
                    }
                    else
                    {
                        //DESLOGUEAR SI NO ES UN USUARIO ACTIVO
                        res.flag = false;
                        res.description = "El usuario está bloqueado";
                        return res;
                    }
                }
                else
                {
                    //SI NO SE PUDO INICIAR SESION, REVISAR SI EL USUARIO YA EXISTE
                    var userExists = AspNetUsers.GetByName(modelo.username);
                    if (userExists.id != "")
                    {
                        //SI EL USUARIO EXISTE, SU CONTRASENA ES INCORRECTA

                        List<string> dominios = new List<string>() { "@vitromex.com", "@gisederlan.com", "@draxton.com", "@evercast.com", "@cinsa.com", "@gis.com" };
                        //REVISAR SI SU CORREO ES PARTE DE LOS DOMINIOS
                        if (dominios.Any(modelo.username.Contains))
                        {
                            //SI FORMA PARE DE LOS DOMINIOS, REVISAR LOGIN CON GIS
                            var tryLogin_Gis = Utility.Login_GIS(modelo.username, modelo.password);
                            if (tryLogin_Gis.flag != false)
                            {
                                //SI SE PUDO HACER LOGIN, PREPARAR USUARIO PARA APLICACION
                                var info = userExists;
                                info.notas = fn.Desencriptar(info.gispassword);
                                user = manager.Find(modelo.username, info.notas);
                                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

                                var appuser = new ApplicationUser()
                                {
                                    UserName = info.username,
                                    Names = info.name,
                                    Email = info.email,
                                    Id = info.id,
                                    Imagen = ""
                                };
                                AuthHelper.SignIn(appuser);

                                //INICIAR SESION
                                res.flag = true;
                                res.description = "Usuario loggeado";
                                res.content.Add(info);
                                return res;
                            }
                            else
                            {
                                //SI NO SE PUDO HACER LOGIN EN GIS, ENVIAR MENSAJE DE ERROR
                                res.flag = false;
                                res.description = "No se pudo iniciar sesión, intentalo más tarde";
                                res.errors.Add(tryLogin_Gis.description);
                                return res;
                            }
                        }
                        else
                        {
                            res.flag = false;
                            res.errors.Add("Inicio de sesión inválido");
                            //res.errors.Add("Inicio de sesión inválido");
                            return res;
                        }
                        /**/
                    }
                    else
                    {
                        //SI EL USUARIO NO EXISTE, REVISAR SI ES USUARIO GIS O ISUPPLIER
                        var split = modelo.username.Split('@').ToList();
                        if (split.Count > 0)
                        {
                            modelo.name = split[0];
                        }
                        else
                        {
                            modelo.name = modelo.username;
                        }
                        AspNetUsers usuario = new AspNetUsers();
                        usuario = new AspNetUsers()
                        {
                            username = modelo.username,
                            phone = "0000000000",
                            email = modelo.username,
                            cellphone = "0000000000",
                            puesto = "USUARIO",
                            password = modelo.password,
                            role = "USUARIO",
                            name = modelo.name,
                            nombre = modelo.name,
                            gispassword = fn.Encriptar(modelo.password)
                        };
                        List<string> dominios = new List<string>() { "@vitromex.com", "@gisederlan.com", "@draxton.com", "@evercast.com", "@cinsa.com", "@gis.com" };
                        //REVISAR SI SU CORREO ES PARTE DE LOS DOMINIOS
                        if (dominios.Any(modelo.username.Contains))
                        {
                            //SI FORMA PARE DE LOS DOMINIOS, REVISAR LOGIN CON GIS
                            var tryLogin_Gis = Utility.Login_GIS(modelo.username, modelo.password);
                            if (tryLogin_Gis.flag != false)
                            {
                                //SI SE PUDO HACER LOGIN, PREPARAR USUARIO PARA APLICACION
                                usuario.puesto = "USUARIO GIS";
                            }
                            else
                            {
                                //SI NO SE PUDO HACER LOGIN EN GIS, ENVIAR MENSAJE DE ERROR
                                res.flag = false;
                                res.description = "No se pudo iniciar sesión, intentalo más tarde";
                                res.errors.Add(tryLogin_Gis.description);
                                return res;
                            }
                        }
                        else
                        {
                            res.flag = false;
                            res.description = "No se pudo acceder al portal";
                            res.errors.Add("No se pudo acceder al portal");
                            return res;
                        }

                        //REVISAR SI HAY UN USUARIO PARA CREAR EN APLICACION
                        if (usuario.username != "")
                        {
                            //INTENTAR CREAR USUARIO
                            var tryCrearUsuario = await new AspNetUsers().AddAspNetUser(usuario, userManager);
                            if (tryCrearUsuario.flag != false)
                            {
                                usuario.id = tryCrearUsuario.data_string;
                                //ENVIAR CORREO DE DATOS DE ACCESO
                                var email = new EmailTmp();
                                email.subject = "Confirmación de acceso a Portal de PI GIS";
                                email.mensaje = "<!DOCTYPE html>" +
                                "<html>" +
                                "<head>" +
                                "<link href='https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap' rel='stylesheet'><title></title>" +
                                "<style type='text/css'>body,body * {font-family: 'Lato', sans-serif;}</style>" +
                                "</head>" +
                                "<body>" +
                                "<div style='border-top: 25px solid #003e74; padding: 20px 20px; border-radius: 7px; box-shadow: 0px 2px 2px 2px #ddd; width: 450px;border-bottom: 1px solid #ddd;border-right: 1px solid #ddd;border-left: 1px solid #ddd;'>" +
                                "<img src='https://www.gis.com.mx/wp-content/themes/GIS/images/gislogo1.png' style='width: 100px;'>" +
                                "<br>" +
                                "<h1 style='font-size: 20px;'>Bienvenido al portal de PI, estos son tus datos:</h1>" +
                                "<br>" +
                                "<h2 style='font-size: 16px;'>Datos de acceso</h2>" +
                                "<label style='font-size: 12px;display: block;color: #ababab;'>Usuario</label>" +
                                "<p style='font-size: 14px;'>" + modelo.username + "</p>" +
                                "<label style='font-size: 12px;display: block;color: #ababab;'>Contrase&ntilde;a</label>" +
                                "<p style='font-size: 14px;'>" + modelo.password + "</p>" +
                                "<br>" +
                                "<small><i>No respondas a este mensaje, ha sido generado automáticamente.</i></small>" +
                                "</div>" +
                                "</body>" +
                                "</html>";
                                email.to = modelo.username;
                                email.from = "noreply@portalproveedores.com";
                                //email.cc = "r.villanueva@softdepot.mx";
                                
                                
                                //Utility.enviaEmailPruebasProveedoresOffice(0, email);

                                //SI EL USUARIO SE CREO, PROCEDER AL LOGIN
                                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                                user = manager.Find(modelo.username, modelo.password);
                                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

                                var appuser = new ApplicationUser()
                                {
                                    UserName = usuario.username,
                                    Names = usuario.name,
                                    Email = usuario.email,
                                    Id = usuario.id,
                                    Imagen = ""
                                };
                                AuthHelper.SignIn(appuser);

                                //INICIAR SESION
                                res.flag = true;
                                res.description = "Usuario loggeado";
                                res.content.Add(usuario);
                                return res;
                            }
                            else
                            {
                                //SI NO SE PUDO CREAR AL USUARIO, ENVIAR MENSAJE DE ERROR
                                res.flag = false;
                                res.description = "Error no se pudo crear al usuario, intentalo más tarde";
                                return res;
                            }
                        }
                        else
                        {
                            //SI NO HAY CUENTAS POR CREAR, ENVIAR MENSAJE DE ERROR
                            res.flag = false;
                            res.description = "Ocurrió un error al general la cuenta del usuario";
                            return res;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/LoginV2")]
        [HttpPost]
        public async Task<RespuestaFormato> LoginV2([FromBody] AspNetUsers modelo)
        {
            dll_Gis.Funciones fn = new dll_Gis.Funciones();
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                /*------------*/
                List<string> dominios = new List<string>() { "@vitromex.com", "@gisederlan.com", "@draxton.com", "@evercast.com", "@cinsa.com", "@gis.com" };
                //REVISAR SI SU CORREO ES PARTE DE LOS DOMINIOS
                if (dominios.Any(modelo.username.Contains))
                {
                    //SI FORMA PARE DE LOS DOMINIOS, REVISAR LOGIN CON GIS
                    var tryLogin_Gis = Utility.Login_GIS(modelo.username, modelo.password);
                    if (tryLogin_Gis.flag != false)
                    {
                        var usuario = AspNetUsers.GetByName(modelo.username);
                        if (usuario.id != "")
                        {
                            //ACTUALIZAR CONTRASENA
                            modelo.id = usuario.id;
                            var updPass = await AspNetUsers.ChangePassword(modelo, userManager);
                            if(updPass.flag != false)
                            {
                                //HACER LOGIN EN LA APLICACION
                                var appcontext = new ApplicationDbContext();
                                var userStore = new UserStore<ApplicationUser>(appcontext);
                                var manager = new UserManager<ApplicationUser>(userStore);
                                var user = manager.Find(modelo.username, modelo.password);
                                if (user != null)
                                {
                                    if (usuario.activo != false)
                                    {
                                        var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                                        var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                                        authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

                                        var appuser = new ApplicationUser()
                                        {
                                            UserName = usuario.username,
                                            Names = usuario.name,
                                            Email = usuario.email,
                                            Id = usuario.id,
                                            Imagen = ""
                                        };
                                        AuthHelper.SignIn(appuser);

                                        //INICIAR SESION
                                        res.flag = true;
                                        res.description = "Usuario loggeado";
                                        res.content.Add(usuario);
                                        return res;
                                    }
                                    else
                                    {
                                        //DESLOGUEAR SI NO ES UN USUARIO ACTIVO
                                        res.flag = false;
                                        res.description = "El usuario está bloqueado";
                                        res.errors.Add("El usuario está bloqueado");
                                        return res;
                                    }
                                }
                                else
                                {
                                    res.flag = false;
                                    res.description = "No se pudo iniciar sesión, revisa tu usuario y contraseña";
                                    res.errors.Add("No se pudo iniciar sesión, revisa tu usuario y contraseña");
                                    return res;
                                }
                            }
                            else
                            {
                                res.flag = false;
                                res.description = "Hubo un error al obtener la contraseña, intentalo más tarde";
                                res.errors.Add("Hubo un error al obtener la contraseña, intentalo más tarde");
                                return res;
                            }
                        }
                        else
                        {
                            res.flag = false;
                            res.description = "No existe el usuario";
                            res.errors.Add("No existe el usuario");
                            return res;
                        }
                    }
                    else
                    {
                        res.flag = false;
                        res.description = "No se pudo iniciar sesión con tu cuenta de GIS";
                        res.errors.Add("No se pudo iniciar sesión con tu cuenta de GIS");
                        return res;
                    }
                }
                else
                {
                    res.flag = false;
                    res.description = "No es un usuario de GIS";
                    res.errors.Add("No es un usuario de GIS");
                    return res;
                }
                /*------------*/
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        #region Usuario
        [Route("api/WebAPI/AddUser")]
        [HttpPost]
        public async Task<RespuestaFormato> AddUser([FromBody] AspNetUsers modelo)
        {
            dll_Gis.Funciones fn = new dll_Gis.Funciones();
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                if (modelo.id != "")
                {
                    res = AspNetUsers.Update(modelo);
                    if(res.flag != false)
                    {
                        proc_RLUsuarioNegocio negocio = new proc_RLUsuarioNegocio();
                        negocio.usuario = modelo.id;
                        negocio.negocio = modelo.negocio.id;
                        proc_RLUsuarioNegocio.Actualizar(negocio);
                    }
                }
                else
                {
                    AspNetUsers usuario = new AspNetUsers()
                    {
                        username = modelo.username,
                        phone = "1010101010",
                        email = modelo.username,
                        cellphone = "1010101010",
                        puesto = modelo.puesto,
                        pedidos = 0,
                        rating = 0,
                        direccion = "",
                        direccion2 = "",
                        direccion3 = "",
                        direccion4 = "",
                        imagen = "",
                        distribuidor = "",
                        terminos = "",
                        notas = "",
                        formatomail = "",
                        password = modelo.password,
                        role = modelo.role,
                        name = modelo.name,
                        nombre = modelo.name,
                        gispassword = fn.Encriptar(modelo.password)
                    };
                    AspNetUsers user = new AspNetUsers();
                    res = await user.AddAspNetUser(usuario, userManager);
                    if (res.flag != false)
                    {
                        proc_RLUsuarioNegocio negocio = new proc_RLUsuarioNegocio();
                        negocio.usuario = res.data_string;
                        negocio.negocio = modelo.negocio.id;
                        proc_RLUsuarioNegocio.Actualizar(negocio);
                    }
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/AddUserV2")]
        [HttpPost]
        public async Task<RespuestaFormato> AddUserV2([FromBody] UsuarioPortal modelo)
        {
            dll_Gis.Funciones fn = new dll_Gis.Funciones();
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                if (modelo.usuario.id != "")
                {
                    res = AspNetUsers.Update(modelo.usuario);
                    if (res.flag != false)
                    {
                        proc_RLUsuarioNegocio negocio = new proc_RLUsuarioNegocio();
                        negocio.usuario = modelo.usuario.id;
                        negocio.negocio = modelo.usuario.negocio.id;
                        proc_RLUsuarioNegocio.Actualizar(negocio);
                    }
                }
                else
                {
                    AspNetUsers usuario = new AspNetUsers()
                    {
                        username = modelo.usuario.username,
                        phone = "1010101010",
                        email = modelo.usuario.username,
                        cellphone = "1010101010",
                        puesto = modelo.usuario.puesto,
                        pedidos = 0,
                        rating = 0,
                        direccion = "",
                        direccion2 = "",
                        direccion3 = "",
                        direccion4 = "",
                        imagen = "",
                        distribuidor = "",
                        terminos = "",
                        notas = "",
                        formatomail = "",
                        password = modelo.usuario.password,
                        role = modelo.usuario.role,
                        name = modelo.usuario.name,
                        nombre = modelo.usuario.name,
                        gispassword = ""
                    };
                    AspNetUsers user = new AspNetUsers();
                    res = await user.AddAspNetUser(usuario, userManager);
                    if (res.flag != false)
                    {
                        proc_RLUsuarioNegocio negocio = new proc_RLUsuarioNegocio();
                        negocio.usuario = res.data_string;
                        negocio.negocio = modelo.usuario.negocio.id;
                        proc_RLUsuarioNegocio.Actualizar(negocio);
                    }
                }



                //actualizar accesos
                if(res.data_string != "")
                {
                    foreach(var item in modelo.accesos)
                    {
                        item.usuario = res.data_string;
                        var acceso = AccesoVistas.ActualizarUsuario(item);
                        if(acceso.flag != true)
                        {
                            res.errors.Add("No se pudo actualizar el acceso a la vista [" + item.descripcion + "]");
                        }
                    }


                    foreach (var item in modelo.negocios)
                    {
                        item.usuario = res.data_string;
                        var acceso = proc_AccesoUsuarioNegocio.Actualizar(item.usuario, item.negocio, item.activo);
                        if (acceso.flag != true)
                        {
                            res.errors.Add("No se pudo actualizar el acceso a la vista [" + item.descripcion + "]");
                        }
                    }
                }
                //
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }


        [Route("api/WebAPI/SelectUsuarioById")]
        [HttpPost]
        public RespuestaFormato SelectUsuarioById([FromBody] AspNetUsers modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = AspNetUsers.GetById(modelo.id);
                if (data.id != "")
                {
                    res.flag = true;
                    res.content.Add(data);
                }
                else
                {
                    res.flag = false;
                    res.description = "El usuario no existe";
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/SelectUsuarioByIdV2")]
        [HttpPost]
        public RespuestaFormato SelectUsuarioByIdV2([FromBody] AspNetUsers modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = AspNetUsers.GetById(modelo.id);
                if (data.id != "")
                {
                    var accesos = AccesoVistas.GetFromUsuario(data.id);
                    var negocios = proc_AccesoUsuarioNegocio.GetFromUsuario(data.id);
                    res.flag = true;
                    res.content.Add(data);
                    res.content.Add(accesos);
                    res.content.Add(negocios);
                }
                else
                {
                    res.flag = false;
                    res.description = "El usuario no existe";
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }


        [Route("api/WebAPI/CambiarPassword")]
        [HttpPost]
        public async Task<RespuestaFormato> CambiarPassword([FromBody] AspNetUsers modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                AspNetUsers user = new AspNetUsers();
                var result = await AspNetUsers.ChangePassword(modelo, userManager);
                res = result;
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }


        [Route("api/WebAPI/UpdateUsuarioActivo")]
        [HttpPost]
        public RespuestaFormato UpdateUsuarioActivo([FromBody] AspNetUsers modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try

            {
                res = AspNetUsers.UpdateActivo(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }
        #endregion

        #region Roles

        [Route("api/WebAPI/SelectRolById")]
        [HttpPost]
        public async Task<RespuestaFormato> SelectRolById([FromBody] AspNetRoles modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = AspNetRoles.GetById(modelo.id);
                if (data.id == "")
                {
                    res.flag = false;
                    res.description = "No existe el rol";
                }
                else
                {
                    res.flag = true;
                    res.content.Add(data);
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }
        [Route("api/WebAPI/SelectRolByIdV2")]
        [HttpPost]
        public async Task<RespuestaFormato> SelectRolByIdV2([FromBody] AspNetRoles modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = AspNetRoles.GetById(modelo.id);
                if (data.id == "")
                {
                    res.flag = false;
                    res.description = "No existe el rol";
                }
                else
                {
                    var accesos = AccesoVistas.GetFromRol(modelo.id);
                    res.flag = true;
                    res.content.Add(data);
                    res.content.Add(accesos);
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/SelectAccesoVistaByRol")]
        [HttpPost]
        public async Task<RespuestaFormato> SelectAccesoVistaByRol([FromBody] AspNetRoles modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = AccesoVistas.GetFromRol(modelo.id);
                if (data.Count <= 0)
                {
                    res.flag = false;
                    res.description = "No existe el rol";
                }
                else
                {
                    res.flag = true;
                    res.content.Add(data);
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/ActualizarRol")]
        [HttpPost]
        public async Task<RespuestaFormato> ActualizarRol([FromBody] AspNetRoles modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                if(modelo.id != "")
                {
                    var data = AspNetRoles.Actualizar(modelo);
                    res = data;
                }
                else
                {
                    var rolestore = new RoleStore<IdentityRole>(new ApplicationDbContext());
                    var rolemanager = new RoleManager<IdentityRole>(rolestore);
                    var rol = new AspNetRoles();
                    res = await rol.Crear(modelo.descripcion, rolemanager);
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/ActualizarRolV2")]
        [HttpPost]
        public async Task<RespuestaFormato> ActualizarRolV2([FromBody] RolPortal modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                if (modelo.rol.id != "")
                {
                    var data = AspNetRoles.Actualizar(modelo.rol);
                    res = data;
                }
                else
                {
                    var rolestore = new RoleStore<IdentityRole>(new ApplicationDbContext());
                    var rolemanager = new RoleManager<IdentityRole>(rolestore);
                    var rol = new AspNetRoles();
                    res = await rol.Crear(modelo.rol.descripcion, rolemanager);
                    modelo.rol.id = res.data_string;
                }


                if (res.data_string != "")
                {
                    foreach (var item in modelo.accesos)
                    {
                        item.rol = modelo.rol.id;
                        var acceso = AccesoVistas.ActualizarRol(item);
                        if (acceso.flag != true)
                        {
                            res.errors.Add("No se pudo actualizar el acceso a la vista [" + item.descripcion + "]");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }


        [Route("api/WebAPI/ActualizarRolActivo")]
        [HttpPost]
        public async Task<RespuestaFormato> ActualizarRolActivo([FromBody] AspNetRoles modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = AspNetRoles.ActualizarActivo(modelo);
                res = data;
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }
        #endregion

        #region Contrato

        [Route("api/WebAPI/BuscarContratos")]
        [HttpPost]
        public async Task<RespuestaFormato> BuscarContratos([FromBody] BusquedaContrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var inicio_vigencia = DateTime.ParseExact(modelo.inicio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var termino_vigencia = DateTime.ParseExact(modelo.fin, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var fecha_modificacion = DateTime.ParseExact(modelo.modificacion, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                modelo.inicio = inicio_vigencia.ToString("yyyy-MM-dd") + " 00:00:00";
                modelo.fin = termino_vigencia.ToString("yyyy-MM-dd") + " 23:59:59";
                modelo.modificacion = fecha_modificacion.ToString("yyyy-MM-dd") + " 00:00:00";

                if (modelo.abogado == "Sin especificar")
                {
                    modelo.abogado = "";
                }
                if (modelo.dueno == "Sin especificar")
                {
                    modelo.dueno = "";
                }
                if (modelo.folio == "Sin especificar")
                {
                    modelo.folio = "";
                }
                if (modelo.rfc == "Sin especificar")
                {
                    modelo.rfc = "";
                }
                if (modelo.contraparte == "Sin especificar")
                {
                    modelo.contraparte = "";
                }
                int total = 0;
                var data = Contrato.GetBusqueda(modelo, out total);
                if(data.Count > 0)
                {
                    res.flag = true;
                    res.content.Add(data);
                    if(modelo.indicadores > 0)
                    {
                        var indicadores = Indicadores.Get(modelo.usuario, modelo.inicio, modelo.fin);
                        res.content.Add(indicadores);
                    }
                    res.data_int = total;
                }
                else
                {
                    res.flag = false;
                    res.description = "No hay información disponible";
                    res.errors.Add("No hay información disponible");
                }
                //var documentos_pendientes = 
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/BuscarContratosDashboard")]
        [HttpPost]
        public async Task<RespuestaFormato> BuscarContratosDashboard([FromBody] BusquedaContrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var inicio_vigencia = DateTime.ParseExact(modelo.inicio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var termino_vigencia = DateTime.ParseExact(modelo.fin, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                modelo.inicio = inicio_vigencia.ToString("yyyy-MM-dd") + " 00:00:00";
                modelo.fin = termino_vigencia.ToString("yyyy-MM-dd") + " 23:59:59";
                if (modelo.abogado == "Sin especificar")
                {
                    modelo.abogado = "";
                }
                var data = Contrato.GetBusquedaDashboard(modelo);
                if (data.Count > 0)
                {
                    res.flag = true;
                    res.content.Add(data);
                    if (modelo.indicadores > 0)
                    {
                        var indicadores = Indicadores.Get(modelo.usuario, modelo.inicio, modelo.fin);
                        res.content.Add(indicadores);
                    }
                }
                else
                {
                    res.flag = false;
                    res.description = "No hay información disponible";
                    res.errors.Add("No hay información disponible");
                }
                //var documentos_pendientes = 
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/UpdateObjContrato")]
        [HttpPost]
        public async Task<RespuestaFormato> UpdateObjContrato([FromBody] OBJ_Contrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                CambioEstatusValidacion cambioEstatusValidacion = new CambioEstatusValidacion();
                CambioEstatus cambioEstatus = new CambioEstatus();
                cambioEstatusValidacion.usuario = modelo.usuario;
                cambioEstatus.usuario = modelo.usuario;

                RegistroActividad actividad = new RegistroActividad();
                actividad.usuario.id = modelo.usuario;
                actividad.titulo = "CONTRATO";

                if (modelo.contrato.inicio_vigencia.yyyymmdd2 == "")
                {
                    modelo.contrato.inicio_vigencia.yyyymmdd2 = "01/01/1969";
                }
                if (modelo.contrato.termino_contrato.yyyymmdd2 == "")
                {
                    modelo.contrato.termino_contrato.yyyymmdd2 = "01/01/1969";
                }

                var inicio_vigencia = DateTime.ParseExact(modelo.contrato.inicio_vigencia.yyyymmdd2, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                modelo.contrato.inicio_vigencia.yyyymmdd2 = inicio_vigencia.ToString("yyyy-MM-dd");

                var termino_contrato = DateTime.ParseExact(modelo.contrato.termino_contrato.yyyymmdd2, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                modelo.contrato.termino_contrato.yyyymmdd2 = termino_contrato.ToString("yyyy-MM-dd");

                var negocio = Negocio.GetById(modelo.contrato.negocio);
                modelo.contrato.folio = negocio.descripcion;
                if (modelo.contrato.id > 0)
                {
                    var data = Contrato.Actualizar(modelo.contrato);
                    res = data;
                    if (res.flag != false)
                    {

                        Contrato.ActualizarComentario(modelo.contrato.id, modelo.contrato.comentario);
                        string comentario_mail = "";
                        if (modelo.contrato.comentario != "")
                        {
                            comentario_mail = "<p>Comentario: " + modelo.contrato.comentario + "</p>";
                            var comentario = new ComentarioContrato();
                            comentario.contrato = modelo.contrato.id;
                            comentario.usuario.id = modelo.usuario;
                            comentario.descripcion = "Comentario en el cambio de estatus: " + modelo.contrato.comentario;
                            var ncomentario = ComentarioContrato.Crear(comentario);
                        }

                        var contrato = Contrato.GetById(modelo.contrato.id);

                        //
                        if(modelo.contrato.cambio_abogado == 1 && contrato.estatus > 1)
                        {
                            var email = new EmailTmp();
                            email.subject = contrato.folio + ". Cambio de abogado.";
                            email.mensaje = "<!DOCTYPE html>" +
                            "<html>" +
                            "<head>" +
                            "<link href='https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap' rel='stylesheet'><title></title>" +
                            "<style type='text/css'>body,body * {font-family: 'Lato', sans-serif;} strong { font-weight:600; }</style>" +
                            "</head>" +
                            "<body>" +
                            "<div style='border-top: 25px solid #003e74; padding: 20px 20px; border-radius: 7px; box-shadow: 0px 2px 2px 2px #ddd; width: 450px;border-bottom: 1px solid #ddd;border-right: 1px solid #ddd;border-left: 1px solid #ddd;'>" +
                            "<img src='https://www.gis.com.mx/wp-content/themes/GIS/images/gislogo1.png' style='width: 100px;'>" +
                            "<br>" +
                            "<p style='font-size: 20px;'>Se te han asignado las tareas referentes al contrato con folio: <strong>" + contrato.folio + "</strong></p>" +
                            "<br>" +
                            "<p>Puedes revisar los datos del contrato accediendo al portal.</p>" +
                            "<p>Si no puedes visualizar el contrato en el portal solicita ayuda con un administrador.</p>" +
                            "<br>" +
                            "<br>" +
                            "<small><i>No respondas a este mensaje, ha sido generado automáticamente.</i></small>" +
                            "</div>" +
                            "</body>" +
                            "</html>";
                            email.to = contrato.abogado_email;
                            email.from = "noreply@portalproveedores.com";
                            var enviaUsuario = Utility.enviaEmail(0, email);
                        }
                        //
                        if(modelo.contrato.cambio_rfc == 1)
                        {
                            //var eliminaDoc = DocumentoContrato.EliminarTodos(modelo.contrato.id, 6);

                            var documentosRFC = DocumentoCliente.RFCExiste(modelo.contrato.rfc);
                            if (documentosRFC.flag != true)
                            {
                                var docs = DocumentoProveedor.GetArchivos(modelo.contrato.rfc);
                                if (docs.Count > 0)
                                {
                                    foreach (var doc in docs)
                                    {
                                        doc.contrato = res.data_int;
                                        doc.usuario.id = modelo.contrato.usuario.id;
                                        doc.tipo_archivo.id = 6;
                                        //doc.tipo = "cliente precarga";
                                        var addDoc = DocumentoCliente.Cargar(doc, modelo.contrato.rfc);
                                    }
                                }
                            }
                            else
                            {
                                //ya existen archivos
                            }
                        }
                        //

                        actividad.descripcion = "Actualización de datos del contrato";
                        actividad.contrato = res.data_int;
                        actividad.Crear();
                        res.data_string = contrato.folio;
                        if (modelo.enviar == true)
                        {
                            cambioEstatusValidacion.estatus_nuevo = 2;
                            cambioEstatusValidacion.devolucion = 0;
                            cambioEstatusValidacion.contrato = modelo.contrato.id;
                            cambioEstatusValidacion.Crear();

                            Contrato.ActualizarEstatusValidacion(data.data_int, 2);
                            actividad.descripcion = "Contrato enviado a revisión con abogado";
                            actividad.titulo = "ESTATUS";
                            actividad.aux_int = 2;
                            actividad.contrato = modelo.contrato.id;
                            actividad.Crear();

                            AspNetUsers abogado = AspNetUsers.GetById(contrato.abogado);
                            var datos_contrato = Contrato.DatosContrato(contrato);
                            string revision = "";
                            if(contrato.revision > 1)
                            {
                                revision = "<p>Revisión no. " + contrato.revision + " del contrato en su versión no." + contrato.doc_numero + "</p><br>";
                            }
                            var email = new EmailTmp();
                            email.subject = contrato.folio + ". Solicitud de revisión de Contrato.";
                            email.mensaje = "<!DOCTYPE html>" +
                            "<html>" +
                            "<head>" +
                            "<link href='https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap' rel='stylesheet'><title></title>" +
                            "<style type='text/css'>body,body * {font-family: 'Lato', sans-serif;} strong { font-weight:600; }</style>" +
                            "</head>" +
                            "<body>" +
                            "<div style='border-top: 25px solid #003e74; padding: 20px 20px; border-radius: 7px; box-shadow: 0px 2px 2px 2px #ddd; width: 450px;border-bottom: 1px solid #ddd;border-right: 1px solid #ddd;border-left: 1px solid #ddd;'>" +
                            "<img src='https://www.gis.com.mx/wp-content/themes/GIS/images/gislogo1.png' style='width: 100px;'>" +
                            "<br>" +
                            "<p style='font-size: 20px;'>Se ha iniciado un flujo para la atención de su solicitud de contrato <strong>" + contrato.folio + "</strong></p>" +
                            "<br>" +
                            "<p>Su solicitud se le asignó al abogado: <strong>" + abogado.name + "</strong></p>" +
                            "<p>Datos del contrato: " + datos_contrato.data_string + "</p>" +
                            "<p>En breve el departamento jurídico se pondrá en contacto con usted.</p>" +
                            "<br>" +
                            comentario_mail + 
                            "<br>" +
                            revision +
                            "<p>Para ver el detalle del contrato, dar click <a href='" + contrato.permalink + "'>aquí</a></p>" +
                            "<br>" +
                            "<br>" +
                            "<small><i>No respondas a este mensaje, ha sido generado automáticamente.</i></small>" +
                            "</div>" +
                            "</body>" +
                            "</html>";
                            email.to = contrato.usuario.email;
                            email.from = "noreply@portalproveedores.com";
                            var enviaUsuario = Utility.enviaEmail(0, email);

                            email = new EmailTmp();
                            email.subject = contrato.folio + ". Solicitud de revisión inicial de Contrato.";
                            if (contrato.revision > 1)
                            {
                                email.subject = contrato.folio + ". Solicitud de revisión no. " + contrato.revision + " del contrato en su versión no." + contrato.doc_numero;
                            }
                            email.mensaje = "<!DOCTYPE html>" +
                            "<html>" +
                            "<head>" +
                            "<link href='https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap' rel='stylesheet'><title></title>" +
                            "<style type='text/css'>body,body * {font-family: 'Lato', sans-serif;} strong { font-weight:600; }</style>" +
                            "</head>" +
                            "<body>" +
                            "<div style='border-top: 25px solid #003e74; padding: 20px 20px; border-radius: 7px; box-shadow: 0px 2px 2px 2px #ddd; width: 450px;border-bottom: 1px solid #ddd;border-right: 1px solid #ddd;border-left: 1px solid #ddd;'>" +
                            "<img src='https://www.gis.com.mx/wp-content/themes/GIS/images/gislogo1.png' style='width: 100px;'>" +
                            "<br>" +
                            "<p style='font-size: 20px;'>El usuario <strong>" + contrato.usuario.name + "</strong> solicita la revisión del contrato con el folio <strong>" + contrato.folio + "</strong>, con estas observaciones:</p>" +
                            "<br>" +
                            comentario_mail +
                            "<br>" +
                            "<p>Datos del contrato: " + datos_contrato.data_string + "</p>" +
                            "<p>En breve el departamento jurídico se pondrá en contacto con usted.</p>" +
                            "<br>" +
                            "<p>Para ver el detalle del contrato, dar click <a href='" + contrato.permalink + "'>aquí</a></p>" +
                            "<br>" +
                            "<br>" +
                            "<small><i>No respondas a este mensaje, ha sido generado automáticamente.</i></small>" +
                            "</div>" +
                            "</body>" +
                            "</html>";
                            email.to = abogado.username;
                            email.from = "noreply@portalproveedores.com";
                            var enviaAbogado = Utility.enviaEmail(0, email);

                            //actividad.descripcion = "Contrato enviado a revisión.";
                            //actividad.Crear();
                        }
                    }
                }
                else
                {
                    res = Contrato.Crear(modelo.contrato);


                    if (res.flag != false)
                    {
                        //
                        var documentosRFC = DocumentoCliente.RFCExiste(modelo.contrato.rfc);
                        if (documentosRFC.flag != true)
                        {
                            var docs = DocumentoProveedor.GetArchivos(modelo.contrato.rfc);
                            if (docs.Count > 0)
                            {
                                foreach (var doc in docs)
                                {
                                    doc.contrato = res.data_int;
                                    doc.usuario.id = modelo.contrato.usuario.id;
                                    doc.tipo_archivo.id = 6;
                                    //doc.tipo = "cliente precarga";
                                    var addDoc = DocumentoCliente.Cargar(doc, modelo.contrato.rfc);
                                }
                            }
                        }
                        else
                        {
                            //ya existen archivos
                        }
                        //
                        var contrato = Contrato.GetById(res.data_int);
                        actividad.descripcion = "Creación de contrato";
                        actividad.contrato = res.data_int;
                        actividad.Crear();

                        //
                        cambioEstatus.estatus = 1;
                        cambioEstatus.contrato = res.data_int;
                        cambioEstatus.Crear();
                        cambioEstatusValidacion.estatus_nuevo = 1;
                        cambioEstatusValidacion.devolucion = 0;
                        cambioEstatusValidacion.contrato = res.data_int;
                        cambioEstatusValidacion.Crear();



                        res.data_string = contrato.folio;
                        if (modelo.enviar == true)
                        {
                            Contrato.ActualizarEstatusValidacion(res.data_int, 2);
                            AspNetUsers abogado = AspNetUsers.GetById(contrato.abogado);
                            var email = new EmailTmp();
                            email.subject = "Contrato por Revisar";
                            email.mensaje = "<!DOCTYPE html>" +
                            "<html>" +
                            "<head>" +
                            "<link href='https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap' rel='stylesheet'><title></title>" +
                            "<style type='text/css'>body,body * {font-family: 'Lato', sans-serif;}</style>" +
                            "</head>" +
                            "<body>" +
                            "<div style='border-top: 25px solid #003e74; padding: 20px 20px; border-radius: 7px; box-shadow: 0px 2px 2px 2px #ddd; width: 450px;border-bottom: 1px solid #ddd;border-right: 1px solid #ddd;border-left: 1px solid #ddd;'>" +
                            "<img src='https://www.gis.com.mx/wp-content/themes/GIS/images/gislogo1.png' style='width: 100px;'>" +
                            "<br>" +
                            "<p style='font-size: 20px;'>Contrato pendiente de revisión por abogado. FOLIO: " + contrato.folio + "</strong></p>" +
                            "<br>" +
                            "<small><i>No respondas a este mensaje, ha sido generado automáticamente.</i></small>" +
                            "</div>" +
                            "</body>" +
                            "</html>";
                            email.to = abogado.username;
                            email.from = "noreply@portalproveedores.com";
                            //email.cc = "r.villanueva@softdepot.mx";


                            Utility.enviaEmail(0, email);
                            actividad.descripcion = "Contrato enviado a revisión.";
                            actividad.Crear();
                        }
                        else
                        {
                        }
                    }
                }

                //var documentos_pendientes = 
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            
            return res;
        }

        [Route("api/WebAPI/UpdateContrato")]
        [HttpPost]
        public async Task<RespuestaFormato> UpdateContrato([FromBody] Contrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                if (modelo.id > 0)
                {
                    var data = Contrato.Actualizar(modelo);
                    res = data;
                }
                else
                {
                    res = Contrato.Crear(modelo);
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/EnviarNotificacionFirmado")]
        [HttpPost]
        public async Task<RespuestaFormato> EnviarNotificacionFirmado([FromBody] Contrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var contrato = Contrato.GetById(modelo.id);
                var datos_contrato = Contrato.DatosContrato(contrato);
                var email = new EmailTmp();
                email.subject = contrato.folio + ". Se ha subido contrato Firmado";
                email.mensaje = "<!DOCTYPE html>" +
                "<html>" +
                "<head>" +
                "<link href='https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap' rel='stylesheet'><title></title>" +
                "<style type='text/css'>body,body * {font-family: 'Lato', sans-serif;}</style>" +
                "</head>" +
                "<body>" +
                "<div style='border-top: 25px solid #003e74; padding: 20px 20px; border-radius: 7px; box-shadow: 0px 2px 2px 2px #ddd; width: 450px;border-bottom: 1px solid #ddd;border-right: 1px solid #ddd;border-left: 1px solid #ddd;'>" +
                "<img src='https://www.gis.com.mx/wp-content/themes/GIS/images/gislogo1.png' style='width: 100px;'>" +
                "<br>" +
                "<p>El usuario " + contrato.usuario.nombre + " subío el contrato con el número de folio: <strong>" + contrato.folio + "</strong> totalmente firmado.<p>" +
                "<br>" +
                "<p>Datos del contrato: " + datos_contrato.data_string + "</p>" +
                "<br>" +
                "<p>Por favor revise si efectivamente el contrato ha sido totalmente firmado para que usted concluya con la solicitud.</p>" +
                "<p>Para ver el detalle del contrato, dar click <a href='" + contrato.permalink + "'>aquí</a></p>" +
                "<br>" +
                "<br>" +
                "<small><i>No respondas a este mensaje, ha sido generado automáticamente.</i></small>" +
                "</div>" +
                "</body>" +
                "</html>";
                email.from = "noreply@portalproveedores.com";
                email.to = contrato.abogado_email;
                res = Utility.enviaEmail(0, email);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }



        [Route("api/WebAPI/TestCorreo")]
        [HttpPost]
        public async Task<string> TestCorreo([FromBody] AspNetUsers modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var email = new EmailTmp();
                email.to = modelo.email;
                email.mensaje = "<!DOCTYPE html>" +
                    "<html>" +
                    "<head>" +
                    "<link href='https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap' rel='stylesheet'><title></title>" +
                    "<style type='text/css'>body,body * {font-family: 'Lato', sans-serif;}</style>" +
                    "</head>" +
                    "<body>" +
                    "prueba servidor" +
                    "</body>" +
                    "</html>";
                email.subject = "prueba servidor";
                email.from = "noreply@dnp.com";
                res = Utility.enviaEmail(0, email);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return JsonConvert.SerializeObject(res);
        }

        [Route("api/WebAPI/EstatusValidacionContrato")]
        [HttpPost]
        public async Task<RespuestaFormato> EstatusValidacionContrato([FromBody] Contrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var preupdate = Contrato.GetById(modelo.id);
                int estatusValidacion = modelo.estatus_validacion;

                CambioEstatusValidacion cambioEstatusValidacion = new CambioEstatusValidacion();
                cambioEstatusValidacion.usuario = modelo.usuario.id;
                cambioEstatusValidacion.contrato = preupdate.id;
                cambioEstatusValidacion.estatus_anterior = preupdate.estatus_validacion;

                RegistroActividad actividad = new RegistroActividad();
                actividad.usuario.id = modelo.usuario.id;
                actividad.titulo = "CONTRATO";
                actividad.contrato = modelo.id;
                res = Contrato.ActualizarEstatusValidacion(modelo.id, modelo.estatus_validacion);
                if(res.flag == true)
                {
                    actividad.titulo = "ESTATUS";
                    actividad.aux_int = modelo.estatus_validacion;
                    Contrato.ActualizarComentario(modelo.id, modelo.comentario);

                    if(modelo.comentario != "")
                    {
                        var comentario = new ComentarioContrato();
                        comentario.contrato = modelo.id;
                        comentario.usuario.id = modelo.usuario.id;
                        comentario.descripcion = "Comentario en el cambio de estatus: " + modelo.comentario;
                        var ncomentario = ComentarioContrato.Crear(comentario);
                    }

                    var estatus = EstatusValidacion.GetById(modelo.estatus_validacion);
                    var contrato = Contrato.GetById(modelo.id);
                    var email = new EmailTmp();
                    var abogado = new AspNetUsers();

                    var datos_contrato = Contrato.DatosContrato(contrato);
                    switch (modelo.estatus_validacion)
                    {
                        case 1:
                            actividad.descripcion = "Solicitud devuelta a usuario para revisión";
                            if(modelo.comentario != "")
                            {
                                actividad.descripcion += ". Comentario: " + modelo.comentario;
                            }
                            actividad.Crear();
                            Contrato.ActualizarRevision(contrato.id);
                            //--cambio estatus validacion
                            cambioEstatusValidacion.estatus_nuevo = 1;
                            cambioEstatusValidacion.devolucion = 1;
                            cambioEstatusValidacion.Crear();
                            //---
                            //

                            email.subject = contrato.folio + ". Solicitud con observaciones";
                            email.subject = contrato.folio + ". Se solicita revisión no. " + contrato.revision + " del contrato en su versión no." + contrato.doc_numero;
                            email.mensaje = "<!DOCTYPE html>" +
                            "<html>" +
                            "<head>" +
                            "<link href='https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap' rel='stylesheet'><title></title>" +
                            "<style type='text/css'>body,body * {font-family: 'Lato', sans-serif;}</style>" +
                            "</head>" +
                            "<body>" +
                            "<div style='border-top: 25px solid #003e74; padding: 20px 20px; border-radius: 7px; box-shadow: 0px 2px 2px 2px #ddd; width: 450px;border-bottom: 1px solid #ddd;border-right: 1px solid #ddd;border-left: 1px solid #ddd;'>" +
                            "<img src='https://www.gis.com.mx/wp-content/themes/GIS/images/gislogo1.png' style='width: 100px;'>" +
                            "<br>" +
                            //"<p>La solicitud de contrato con el folio " + contrato.folio + " (" + contrato.descripcion + "), tiene observaciones por parte del área Jurídica. Favor de atenderlas y volver a enviar la solicitud a revisión.<p>" +
                            "<p>El abogado " + abogado.nombre + " solicita la revisión del contrato con el folio " + contrato.folio + " con estos comentarios.<p>" +
                            "<p>" + modelo.comentario + "<p>" +
                            "<br>" +
                            "<p>Revisión no. " + contrato.revision + " del contrato en su versión no." + contrato.doc_numero + "<p>" +
                            "<br>" +
                            "<p>Para ver el detalle del contrato, dar click <a href='" + contrato.permalink + "'>aquí</a></p>" +
                            "<br>" +
                            "<br>" +
                            "<small><i>No respondas a este mensaje, ha sido generado automáticamente.</i></small>" +
                            "</div>" +
                            "</body>" +
                            "</html>";
                            email.from = "noreply@portalproveedores.com";
                            email.to = contrato.usuario.email;
                            Utility.enviaEmail(0, email);
                            //
                            ColaboradorContrato.ResetEstatus(contrato.id);
                            break;
                        case 2:
                            if (preupdate.estatus_validacion == 3)
                            {
                                actividad.descripcion = "Solicitud devuelta a usuario para revisión";
                                if (modelo.comentario != "")
                                {
                                    actividad.descripcion += ". Comentario: " + modelo.comentario;
                                }
                                actividad.Crear();
                                Contrato.ActualizarRevision(contrato.id);
                                //--cambio estatus validacion
                                cambioEstatusValidacion.estatus_nuevo = 2;
                                cambioEstatusValidacion.devolucion = 1;
                                cambioEstatusValidacion.Crear();
                                //---
                                //

                                email.subject = contrato.folio + ". Solicitud con observaciones";
                                email.mensaje = "<!DOCTYPE html>" +
                                "<html>" +
                                "<head>" +
                                "<link href='https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap' rel='stylesheet'><title></title>" +
                                "<style type='text/css'>body,body * {font-family: 'Lato', sans-serif;}</style>" +
                                "</head>" +
                                "<body>" +
                                "<div style='border-top: 25px solid #003e74; padding: 20px 20px; border-radius: 7px; box-shadow: 0px 2px 2px 2px #ddd; width: 450px;border-bottom: 1px solid #ddd;border-right: 1px solid #ddd;border-left: 1px solid #ddd;'>" +
                                "<img src='https://www.gis.com.mx/wp-content/themes/GIS/images/gislogo1.png' style='width: 100px;'>" +
                                "<br>" +
                                "<p>La solicitud de contrato con el folio " + contrato.folio + " (" + contrato.descripcion + "), tiene observaciones por parte del área Jurídica. Favor de atenderlas y volver a enviar la solicitud a revision.<p>" +
                                "<p>" + modelo.comentario + "<p>" +
                                "<br>" +
                                "<br>" +
                                "<p>Para ver el detalle del contrato, dar click <a href='" + contrato.permalink + "'>aquí</a></p>" +
                                "<br>" +
                                "<br>" +
                                "<small><i>No respondas a este mensaje, ha sido generado automáticamente.</i></small>" +
                                "</div>" +
                                "</body>" +
                                "</html>";
                                email.from = "noreply@portalproveedores.com";
                                email.to = contrato.abogado_email;
                                Utility.enviaEmail(0, email);
                            }
                            
                            //
                            ColaboradorContrato.ResetEstatus(contrato.id);
                            break;
                        case 3:
                            if (preupdate.estatus_validacion == 2)
                            {
                                actividad.descripcion = "Contrato enviado a revisión por usuarios";

                                if (modelo.comentario != "")
                                {
                                    actividad.descripcion += ". Comentario: " + modelo.comentario;
                                }
                                actividad.Crear();


                                //--cambio estatus validacion
                                cambioEstatusValidacion.estatus_nuevo = 3;
                                cambioEstatusValidacion.devolucion = 0;
                                cambioEstatusValidacion.Crear();
                                //---

                                email.subject = contrato.folio + ". Se solicita revisión no. " + contrato.revision + " del contrato en su versión #" + contrato.doc_numero;
                                email.mensaje = "<!DOCTYPE html>" +
                                "<html>" +
                                "<head>" +
                                "<link href='https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap' rel='stylesheet'><title></title>" +
                                "<style type='text/css'>body,body * {font-family: 'Lato', sans-serif;}</style>" +
                                "</head>" +
                                "<body>" +
                                "<div style='border-top: 25px solid #003e74; padding: 20px 20px; border-radius: 7px; box-shadow: 0px 2px 2px 2px #ddd; width: 450px;border-bottom: 1px solid #ddd;border-right: 1px solid #ddd;border-left: 1px solid #ddd;'>" +
                                "<img src='https://www.gis.com.mx/wp-content/themes/GIS/images/gislogo1.png' style='width: 100px;'>" +
                                "<br>" +
                                "<p>El abogado <strong>" + contrato.abogado_nombre + "</strong> solicita la colaboración en el contrato con el folio <strong>" + contrato.folio + "</strong>, con estos comentarios adicionales:</p>" +
                                "<p>" + modelo.comentario + "<p>" +
                                "<br>" +
                                "<p>Para ver el detalle del contrato, dar click <a href='" + contrato.permalink + "'>aquí</a></p>" +
                                "<br>" +
                                "<br>" +
                                "<small><i>No respondas a este mensaje, ha sido generado automáticamente.</i></small>" +
                                "</div>" +
                                "</body>" +
                                "</html>";
                                email.from = "noreply@portalproveedores.com";
                                var colaboradores = ColaboradorContrato.GetFromId(contrato.id);
                                foreach (var colaborador in colaboradores)
                                {
                                    email.to = colaborador.usuario.email;
                                    Utility.enviaEmail(0, email);
                                }
                            }
                            break;
                        case 5:
                            actividad.descripcion = "Contrato firmado, proceso terminado";

                            if (modelo.comentario != "")
                            {
                                actividad.descripcion += ". Comentario: " + modelo.comentario;
                            }
                            actividad.Crear();

                            //--cambio estatus validacion
                            cambioEstatusValidacion.estatus_nuevo = 5;
                            cambioEstatusValidacion.devolucion = 0;
                            cambioEstatusValidacion.Crear();
                            //---
                            string es_indefinido = "";
                            if(contrato.termino_indefinido != 1) {
                                es_indefinido = "<p>Usted recibirá un recordatorio con 15 días de anticipación antes de la fecha de terminación de este Contrato. En cuanto reciba el recordatorio por favor póngase en contacto con el departamento Jurídico en caso de requerirse un nuevo Contrato.<p>";
                            }
                            email.subject = contrato.folio + ". Solicitud de revisión concluida";
                            email.mensaje = "<!DOCTYPE html>" +
                            "<html>" +
                            "<head>" +
                            "<link href='https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap' rel='stylesheet'><title></title>" +
                            "<style type='text/css'>body,body * {font-family: 'Lato', sans-serif;}</style>" +
                            "</head>" +
                            "<body>" +
                            "<div style='border-top: 25px solid #003e74; padding: 20px 20px; border-radius: 7px; box-shadow: 0px 2px 2px 2px #ddd; width: 450px;border-bottom: 1px solid #ddd;border-right: 1px solid #ddd;border-left: 1px solid #ddd;'>" +
                            "<img src='https://www.gis.com.mx/wp-content/themes/GIS/images/gislogo1.png' style='width: 100px;'>" +
                            "<br>" +
                            "<p>Se ha concluido con su solicitud de contrato con el folio <strong>" + contrato.folio + "</strong>, con los siguientes comentarios:</p>" +
                            "<br>" +
                            "<p>Datos del contrato: " + datos_contrato.data_string + "</p>" +
                            "<br>" +
                            es_indefinido + 
                            "<br>" +
                            "<p>" + modelo.comentario + "<p>" +
                            "<br>" +
                            "<p>Para ver el detalle del contrato, dar click <a href='" + contrato.permalink + "'>aquí</a></p>" +
                            "<br>" +
                            "<br>" +
                            "<small><i>No respondas a este mensaje, ha sido generado automáticamente.</i></small>" +
                            "</div>" +
                            "</body>" +
                            "</html>";
                            email.from = "noreply@portalproveedores.com";
                            email.to = contrato.usuario.email;
                            Utility.enviaEmail(0, email);
                            email.to = contrato.abogado_email;
                            Utility.enviaEmail(0, email);
                            break;

                        case 4:
                            actividad.descripcion = "Contrato aprobado para firmas";

                            if (modelo.comentario != "")
                            {
                                actividad.descripcion += ". Comentario: " + modelo.comentario;
                            }
                            actividad.Crear();


                            //--cambio estatus validacion
                            cambioEstatusValidacion.estatus_nuevo = 4;
                            cambioEstatusValidacion.devolucion = 0;
                            cambioEstatusValidacion.Crear();
                            //---
                            email.subject = contrato.folio + ". Contrato aprobado para firmas";
                            email.mensaje = "<!DOCTYPE html>" +
                            "<html>" +
                            "<head>" +
                            "<link href='https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap' rel='stylesheet'><title></title>" +
                            "<style type='text/css'>body,body * {font-family: 'Lato', sans-serif;}</style>" +
                            "</head>" +
                            "<body>" +
                            "<div style='border-top: 25px solid #003e74; padding: 20px 20px; border-radius: 7px; box-shadow: 0px 2px 2px 2px #ddd; width: 450px;border-bottom: 1px solid #ddd;border-right: 1px solid #ddd;border-left: 1px solid #ddd;'>" +
                            "<img src='https://www.gis.com.mx/wp-content/themes/GIS/images/gislogo1.png' style='width: 100px;'>" +
                            "<br>" +
                            "<p>Se ha aprobado su solicitud de contrato. <strong>" + contrato.abogado_nombre + "</strong> solicita la revisión del contrato con el folio <strong>" + contrato.folio + "</strong>, con los siguientes comentarios:</p>" +
                            "<p>" + modelo.comentario + "<p>" +
                            "<br>" +
                            "<p>Agradecemos suba al portal el Contrato aprobado firmado por las partes en un plazo no mayor de 30 días.<p>" +
                            "<br>" +
                            "<p>Para ver el detalle del contrato, dar click <a href='" + contrato.permalink + "'>aquí</a></p>" +
                            "<br>" +
                            "<br>" +
                            "<small><i>No respondas a este mensaje, ha sido generado automáticamente.</i></small>" +
                            "</div>" +
                            "</body>" +
                            "</html>";
                            email.from = "noreply@portalproveedores.com";
                            email.to = contrato.usuario.email;
                            Utility.enviaEmail(0, email);
                            //email.to = contrato.abogado_email;
                            //Utility.enviaEmail(0, email);
                            break;
                    }
                    //email.cc = "r.villanueva@softdepot.mx";


                    //Utility.enviaEmail(0, email);
                }

            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }
        
        [Route("api/WebAPI/EstatusContrato")]
        [HttpPost]
        public async Task<RespuestaFormato> EstatusContrato([FromBody] Contrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                res = Contrato.ActualizarEstatus(modelo.id, modelo.estatus);
                if(res.flag != false)
                {
                    RegistroActividad actividad = new RegistroActividad();
                    actividad.usuario.id = modelo.usuario.id;
                    actividad.titulo = "ESTATUS CONTRATO";
                    actividad.contrato = modelo.id;

                    CambioEstatus cambioEstatus = new CambioEstatus();
                    cambioEstatus.estatus = modelo.estatus;
                    cambioEstatus.contrato = modelo.id;
                    cambioEstatus.usuario = modelo.usuario.id;
                    cambioEstatus.Crear();

                    EmailTmp email = new EmailTmp();

                    Contrato contrato = Contrato.GetById(modelo.id);
                    AspNetUsers autor = AspNetUsers.GetById(modelo.usuario.id);
                    string contenido = "";
                    string asunto = "Solicitud";
                    if(autor.roles.id == "a78f7e2f-69af-43aa-9e41-4df768bf24b1")
                    {
                        contenido = "El usuario ha procedido a ";
                    }
                    else if (autor.roles.id == "e9d0046c-3c62-4e91-81d5-8c8bc2a5c16b")
                    {
                        contenido = "El abogado ha procedido a ";
                    }
                    else
                    {
                        contenido = "El administrador ha procedido a ";
                    }

                    if (modelo.estatus == 1)
                    {
                        actividad.descripcion = "Cambió el estatus del contrato a ACTIVADO";
                        contenido += "ACTIVAR la solicitud de contrato";
                        asunto += " activada";
                    }
                    else if (modelo.estatus == 2)
                    {
                        actividad.descripcion = "Cambió el estatus del contrato a CANCELADO";
                        contenido += "CANCELAR la solicitud de contrato";
                        asunto += " cancelada";
                    }
                    else if (modelo.estatus == 3)
                    {
                        actividad.descripcion = "Cambió el estatus del contrato a SUSPENDIDO";
                        contenido += "SUSPENDER la solicitud de contrato";
                        asunto += " suspendida";
                    }
                    else
                    {
                        actividad.descripcion = "Cambió el estatus del contrato";
                    }
                    contenido += " con folio <strong>" + contrato.folio + "</strong>";

                    email.subject = contrato.folio + ". " + asunto;
                    email.mensaje = "<!DOCTYPE html>" +
                    "<html>" +
                    "<head>" +
                    "<link href='https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap' rel='stylesheet'><title></title>" +
                    "<style type='text/css'>body,body * {font-family: 'Lato', sans-serif;}</style>" +
                    "</head>" +
                    "<body>" +
                    "<div style='border-top: 25px solid #003e74; padding: 20px 20px; border-radius: 7px; box-shadow: 0px 2px 2px 2px #ddd; width: 450px;border-bottom: 1px solid #ddd;border-right: 1px solid #ddd;border-left: 1px solid #ddd;'>" +
                    "<img src='https://www.gis.com.mx/wp-content/themes/GIS/images/gislogo1.png' style='width: 100px;'>" +
                    "<br>" +
                    "<p>" + contenido + "<p>" +
                    "<br>" +
                    "<p>Para ver el detalle del contrato, dar click <a href='" + contrato.permalink + "'>aquí</a></p>" +
                    "<br>" +
                    "<br>" +
                    "<small><i>No respondas a este mensaje, ha sido generado automáticamente.</i></small>" +
                    "</div>" +
                    "</body>" +
                    "</html>";
                    email.from = "noreply@portalproveedores.com";
                    email.to = contrato.usuario.email + "," + contrato.abogado_email;
                    Utility.enviaEmail(0, email);


                    actividad.Crear();
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/EstatusColaborador")]
        [HttpPost]
        public async Task<RespuestaFormato> EstatusColaborador([FromBody] ColaboradorContrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var colaborador = ColaboradorContrato.GetById(modelo.id);
                res = ColaboradorContrato.ActualizarEstatus(modelo);
                if(res.flag != false)
                {
                    RegistroActividad actividad = new RegistroActividad();
                    actividad.usuario.id = modelo.usuario.id;
                    actividad.titulo = "ESTATUS COLABORADOR";
                    actividad.contrato = colaborador.contrato;
                    actividad.aux_int = colaborador.id;

                    if (modelo.aprobado == 1)
                    {
                        actividad.descripcion = "Dió visto bueno al contrato";
                    }
                    else
                    {
                        actividad.descripcion = "No aprobó el contrato";
                    }
                    actividad.Crear();
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }


        [Route("api/WebAPI/SelectContratoById")]
        [HttpPost]
        public async Task<RespuestaFormato> SelectContratoById([FromBody] Contrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = Contrato.GetById(modelo.id);
                if(data.id > 0)
                {
                    var documentos = DocumentoContrato.GetFromId(data.id, "");
                    var comentarios = ComentarioContrato.GetFromId(data.id);
                    var recordatorios = RecordatorioContrato.GetFromId(data.id);
                    var colaboradores = ColaboradorContrato.GetFromId(data.id);
                    var tipo = TipoArchivo.Get();
                    var documentosTipo = DocumentoContrato.GetFromIdDesgloseTipoArchivo(documentos);

                    var documentosRFC = DocumentoCliente.GetFromIdToDocumentoContrato(data.rfc, "");
                    var documentosCliente = new List<DocumentoContrato>();
                    documentosCliente = documentos.Where(i => i.tipo_archivo.id == 6 || i.tipo_archivo.nombre == "Documento Cliente" || i.tipo_archivo.id == 7 || i.tipo_archivo.nombre == "Documento Cliente Manual").ToList();
                    documentosCliente = documentosCliente.Concat(documentosRFC).ToList();
                    /*if(documentos.Count <= 0)
                    {
                        documentosCliente = new List<DocumentoContrato>();
                    }*/
                    res.flag = true;
                    res.content.Add(data);
                    res.content.Add(documentosTipo);
                    res.content.Add(comentarios);
                    res.content.Add(recordatorios);
                    res.content.Add(colaboradores);
                    res.content.Add(tipo);
                    res.content.Add(documentos);
                    res.content.Add(documentosCliente);
                }
                else
                {
                    res.flag = false;
                    res.errors.Add("No hay información disponible");
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }



        [Route("api/WebAPI/SelectDocumentosFromContrato")]
        [HttpPost]
        public async Task<RespuestaFormato> SelectDocumentosFromContrato([FromBody] Contrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var documentos = DocumentoContrato.GetFromId(modelo.id, "");
                var tipo = TipoArchivo.Get();
                var documentosTipo = DocumentoContrato.GetFromIdDesgloseTipoArchivo(documentos);


                var documentosRFC = DocumentoCliente.GetFromIdToDocumentoContrato(modelo.rfc, "");
                var documentosCliente = new List<DocumentoContrato>();
                documentosCliente = documentos.Where(i => i.tipo_archivo.id == 6 || i.tipo_archivo.nombre == "Documento Cliente" || i.tipo_archivo.id == 7 || i.tipo_archivo.nombre == "Documento Cliente Manual").ToList();
                documentosCliente = documentosCliente.Concat(documentosRFC).ToList();
                /*if (documentos.Count <= 0)
                {
                    documentosCliente = new List<DocumentoContrato>();
                }*/
                res.flag = true;
                res.content.Add(documentosTipo);
                res.content.Add(tipo);
                res.content.Add(documentos);
                res.content.Add(documentosCliente);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }


        [Route("api/WebAPI/AddComentarioContrato")]
        [HttpPost]
        public async Task<RespuestaFormato> AddComentarioContrato([FromBody] ComentarioContrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = ComentarioContrato.Crear(modelo);
                if (data.flag != false)
                {
                    RegistroActividad actividad = new RegistroActividad();
                    actividad.usuario.id = modelo.usuario.id;
                    actividad.titulo = "COMENTARIO";
                    actividad.descripcion = "Creó de un comentario: " + modelo.descripcion;
                    actividad.contrato = modelo.contrato;
                    actividad.aux_int = data.data_int;
                    actividad.Crear();

                    res = data;
                    var comentario = ComentarioContrato.GetById(data.data_int);
                    res.content.Add(comentario);
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/EliminarComentario")]
        [HttpPost]
        public async Task<RespuestaFormato> EliminarComentario([FromBody] ComentarioContrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var comentario = ComentarioContrato.GetById(modelo.id);
                var data = ComentarioContrato.Eliminar(modelo);
                res = data;
                if(data.flag != false)
                {

                    RegistroActividad actividad = new RegistroActividad();
                    actividad.usuario.id = modelo.usuario.id;
                    actividad.titulo = "COMENTARIO";
                    actividad.descripcion = "Se eliminó un comentario: " + modelo.descripcion;
                    actividad.contrato = comentario.contrato;
                    actividad.aux_int = comentario.id;
                    actividad.Crear();
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/EliminarRecordatorio")]
        [HttpPost]
        public async Task<RespuestaFormato> EliminarRecordatorio([FromBody] RecordatorioContrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var recordatorio = RecordatorioContrato.GetById(modelo.id);
                var data = RecordatorioContrato.Eliminar(modelo);
                if(data.flag != false)
                {
                    RegistroActividad actividad = new RegistroActividad();
                    actividad.usuario.id = modelo.usuario.id;
                    actividad.titulo = "RECORDATORIO";
                    actividad.descripcion = "Se eliminó un recordatorio: " + recordatorio.descripcion;
                    actividad.contrato = recordatorio.contrato;
                    actividad.aux_int = recordatorio.id;
                    actividad.Crear();
                }
                res = data;
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/AddRecordatorioContrato")]
        [HttpPost]
        public async Task<RespuestaFormato> AddRecordatorioContrato([FromBody] RecordatorioContrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var FR_d = DateTime.ParseExact(modelo.FR_d, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                modelo.FR_d = FR_d.ToString("yyyy-MM-dd");
                var data = RecordatorioContrato.Crear(modelo);
                if (data.flag != false)
                {

                    RegistroActividad actividad = new RegistroActividad();
                    actividad.usuario.id = modelo.autor.id;
                    actividad.titulo = "RECORDATORIO";
                    actividad.descripcion = "Creó un recordatorio: " + modelo.FR_d + " | " + modelo.asignado.nombre;
                    actividad.contrato = modelo.contrato;
                    actividad.aux_int = data.data_int;
                    actividad.Crear();

                    res = data;
                    var comentario = RecordatorioContrato.GetById(data.data_int);
                    res.content.Add(comentario);
                    if (modelo.colaborador == 1)
                    {
                        var colab = new ColaboradorContrato();
                        colab.contrato = modelo.contrato;
                        colab.autor.id = modelo.autor.id;
                        colab.usuario.id = modelo.asignado.id;
                        colab.usuario.nombre = modelo.asignado.nombre;
                        var addColab = ColaboradorContrato.CrearIf(colab);

                        if (addColab.flag != false)
                        {
                            actividad = new RegistroActividad();
                            actividad.usuario.id = modelo.autor.id;
                            actividad.titulo = "COLABORADOR";
                            actividad.descripcion = "Se agregó a un colaborador: " + modelo.asignado.nombre;
                            actividad.contrato = modelo.contrato;
                            actividad.aux_int = addColab.data_int;
                            actividad.Crear();


                            var colaborador = ColaboradorContrato.GetById(addColab.data_int);
                            res.content.Add(colaborador);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/AddColaboradorContrato")]
        [HttpPost]
        public async Task<RespuestaFormato> AddColaboradorContrato([FromBody] ColaboradorContrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var colaborador = ColaboradorContrato.GetById(modelo.id);
                if (modelo.id > 0)
                {
                    var data = ColaboradorContrato.Actualizar(modelo);
                    if (data.flag != false)
                    {
                        if (colaborador.usuario.id != modelo.usuario.id)
                        {
                            RegistroActividad actividad = new RegistroActividad();
                            actividad.usuario.id = modelo.autor.id;
                            actividad.titulo = "COLABORADOR";
                            actividad.descripcion = "Se modificó a un colaborador: " + colaborador.usuario.email + " CAMBIÓ A " +  modelo.usuario.nombre;
                            actividad.contrato = modelo.contrato;
                            actividad.aux_int = data.data_int;
                            actividad.Crear();
                        }

                        res = data;
                        var comentario = ColaboradorContrato.GetById(data.data_int);
                        res.content.Add(comentario);
                    }
                }
                else
                {
                    var data = ColaboradorContrato.Crear(modelo);
                    if (data.flag != false)
                    {
                        RegistroActividad actividad = new RegistroActividad();
                        actividad.usuario.id = modelo.autor.id;
                        actividad.titulo = "COLABORADOR";
                        actividad.descripcion = "Se agregó a un colaborador: " + modelo.usuario.nombre;
                        actividad.contrato = modelo.contrato;
                        actividad.aux_int = data.data_int;
                        actividad.Crear();
                        res = data;
                        var comentario = ColaboradorContrato.GetById(data.data_int);
                        res.content.Add(comentario);
                    }
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/BuscarCliente")]
        [HttpPost]
        public async Task<RespuestaFormato> BuscarCliente([FromBody] WS_RFC modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var cliente = await WS_RFC.GetByRFC(modelo);
                if(cliente.flag != false)
                {
                    res.flag = true;
                    res.data_string = cliente.GIS_CLIENTE_PROV_NOMBRE_FN;
                    if (modelo.contrato > 0)
                    {

                        var documentosRFC = DocumentoCliente.GetFromIdToDocumentoContrato(modelo.P_RFC, "");
                        if (documentosRFC.Count <= 0)
                        {
                            var docs = DocumentoProveedor.GetArchivos(modelo.P_RFC);
                            res.content.Add(docs);
                        }
                        else
                        {
                            res.content.Add(documentosRFC);
                        }
                    }else
                    {
                        res.content.Add(new List<DocumentoContrato>());
                    }
                }
                else
                {
                    res.flag = false;
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/BuscarClienteDocumentos")]
        [HttpPost]
        public async Task<RespuestaFormato> BuscarClienteDocumentos([FromBody] WS_RFC modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                res.flag = true;
                var docs = DocumentoProveedor.GetArchivos(modelo.P_RFC);
                res.content.Add(docs);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }
        #endregion

        #region Documento Contrato
        [Route("api/WebAPI/AddDocumentoContrato")]
        [HttpPost]
        public async Task<RespuestaFormato> AddDocumentoContrato([FromBody] DocumentoContrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = DocumentoContrato.Carga(modelo);
                if (data.flag != false)
                {
                    if(modelo.comentario != "")
                    {
                        var comentario = new DocumentoComentario();
                        comentario.documento = modelo.id;
                        comentario.contrato = modelo.contrato;
                        comentario.descripcion = modelo.comentario;
                        comentario.usuario.id = modelo.usuario.id;
                        var addComentario = DocumentoComentario.Crear(comentario);
                        if (addComentario.flag != true)
                        {
                            res.errors.Add("No se pudo agregar el comentario, inténtalo más tarde");
                        }
                    }
                    if (modelo.tipo == "firmado")
                    {
                        var firmado = DocumentoContrato.ActualizarTipo(modelo);
                    }
                    var documento = DocumentoContrato.GetById(modelo.id);
                    res.flag = true;
                    if (documento.id > 0)
                    {
                        documento.file_data = new byte[0];
                        res.content.Add(documento);
                    }
                }
                else
                {
                    res = data;
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/SelectDocumentoById")]
        [HttpPost]
        public async Task<RespuestaFormato> SelectDocumentoById([FromBody] DocumentoContrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = DocumentoContrato.GetById(modelo.id);
                if (data.id > 0)
                {
                    var comentarios = DocumentoComentario.GetFromId(data.id);
                    var versionamiento = DocumentoContrato.GetFromIdVersionamiento(data.contrato, data.tipo_archivo.id);
                    versionamiento = versionamiento.OrderByDescending(i => i.versionamiento).ToList();
                    res.flag = true;
                    res.content.Add(data);
                    res.content.Add(comentarios);
                    res.content.Add(versionamiento);
                }
                else
                {
                    res.flag = false;
                    res.errors.Add("No hay información disponible");
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/EliminarDocumento")]
        [HttpPost]
        public async Task<RespuestaFormato> EliminarDocumento([FromBody] DocumentoContrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var documento = DocumentoContrato.GetById(modelo.id);
                var data = DocumentoContrato.Eliminar(documento);
                res = data;
                if (res.flag != false)
                {
                    RegistroActividad actividad = new RegistroActividad();
                    actividad.usuario.id = modelo.usuario.id;
                    actividad.titulo = "DOCUMENTO";
                    actividad.descripcion = "Se eliminó un documento: " + documento.file_nombre;
                    actividad.contrato = documento.contrato;
                    actividad.aux_int = documento.id;
                    actividad.Crear();


                    if (res.data_int > 0)
                    {
                        modelo = DocumentoContrato.GetById(res.data_int);
                    }
                    else
                    {
                        modelo = new DocumentoContrato();
                        modelo.tipo_archivo = documento.tipo_archivo;
                    }
                    res.content.Add(modelo);
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/EliminarDocumentoCliente")]
        [HttpPost]
        public async Task<RespuestaFormato> EliminarDocumentoCliente([FromBody] DocumentoContrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var documento = DocumentoCliente.GetById(modelo.id);
                var data = DocumentoCliente.Eliminar(documento);
                res = data;
                if (res.flag != false)
                {
                    RegistroActividad actividad = new RegistroActividad();
                    actividad.usuario.id = modelo.usuario.id;
                    actividad.titulo = "DOCUMENTO CLIENTE";
                    actividad.descripcion = "Se eliminó un documento de cliente: " + documento.file_nombre;
                    actividad.aux_str = documento.rfc;
                    actividad.aux_int = documento.id;
                    actividad.Crear();
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/InsReporteActividad")]
        [HttpPost]
        public async Task<RespuestaFormato> InsReporteActividad([FromBody] RespuestaFormato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                RegistroActividad actividad = new RegistroActividad();
                actividad.usuario.id = modelo.data_string2;
                actividad.titulo = "CONTRATO";
                actividad.contrato = modelo.data_int;
                switch (modelo.data_string)
                {
                    case "historialContrato":
                        actividad.descripcion = "Reporte de actividad descargado";
                        break;
                    default:
                        actividad.descripcion = "_";
                        break;
                }
                actividad.Crear();
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/SelectColaboradorById")]
        [HttpPost]
        public async Task<RespuestaFormato> SelectColaboradorById([FromBody] ColaboradorContrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = ColaboradorContrato.GetById(modelo.id);
                if (data.id > 0)
                {
                    res.flag = true;
                    res.content.Add(data);
                }
                else
                {
                    res.flag = false;
                    res.errors.Add("No hay información disponible");
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/EliminarColaborador")]
        [HttpPost]
        public async Task<RespuestaFormato> EliminarColaborador([FromBody] ColaboradorContrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var colaborador = ColaboradorContrato.GetById(modelo.id);
                var data = ColaboradorContrato.Eliminar(modelo);
                res = data;
                if(res.flag != false)
                {
                    RegistroActividad actividad = new RegistroActividad();
                    actividad.usuario.id = modelo.usuario.id;
                    actividad.titulo = "COLABORADOR";
                    actividad.descripcion = "Se eliminó a un colaborador: " + colaborador.usuario.nombre;
                    actividad.contrato = colaborador.contrato;
                    actividad.aux_int = colaborador.id;
                    actividad.Crear();
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/RegistroActividadContrato")]
        [HttpPost]
        public async Task<RespuestaFormato> RegistroActividadContrato([FromBody] Contrato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = RegistroActividad.GetFromId(modelo.id);
                res.flag = true;
                res.content.Add(data);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        #endregion

        //------
        #region catalogos

        [Route("api/WebAPI/AddCatalogo")]
        [HttpPost]
        public RespuestaFormato AddCatalogo([FromBody] CTMCatalogo modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                object obj = new object();
                if (modelo.tipo == "NegocioPI")
                {
                    obj = modelo.ToNegocioPI();
                    res = NegocioPI.Crear((NegocioPI)obj);
                }
                else if (modelo.tipo == "Pais")
                {
                    obj = modelo.ToPais();
                    res = Pais.Crear((Pais)obj);
                }
                else if (modelo.tipo == "TipoCatalogo")
                {
                    obj = modelo.ToTipoCatalogo();
                    res = TipoCatalogo.Crear((TipoCatalogo)obj);
                }
                else if (modelo.tipo == "TipoRegistro")
                {
                    obj = modelo.ToTipoRegistro();
                    res = TipoRegistro.Crear((TipoRegistro)obj);
                }
                else if (modelo.tipo == "Clase")
                {
                    obj = modelo.ToClase();
                    res = Clase.Crear((Clase)obj);
                }
                else if (modelo.tipo == "EstatusCatalogo")
                {
                    obj = modelo.ToEstatusCatalogo();
                    res = EstatusCatalogo.Crear((EstatusCatalogo)obj);
                }
                else if (modelo.tipo == "Despacho")
                {
                    obj = modelo.ToDespacho();
                    res = Despacho.Crear((Despacho)obj);
                }
                else if (modelo.tipo == "Corresponsal")
                {
                    obj = modelo.ToCorresponsal();
                    res = Corresponsal.Crear((Corresponsal)obj);
                }
                else if (modelo.tipo == "ConvenioLicencia")
                {
                    modelo.fecha_instruccionesS = Utility.FechaDefault(modelo.fecha_instruccionesS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_instrucciones_completadoS = Utility.FechaDefault(modelo.fecha_instrucciones_completadoS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_envio_documentosS = Utility.FechaDefault(modelo.fecha_envio_documentosS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_envio_documentos_completadoS = Utility.FechaDefault(modelo.fecha_envio_documentos_completadoS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_solicitudS = Utility.FechaDefault(modelo.fecha_solicitudS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_concesionS = Utility.FechaDefault(modelo.fecha_concesionS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_legalS = Utility.FechaDefault(modelo.fecha_legalS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_vencimientoS = Utility.FechaDefault(modelo.fecha_vencimientoS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_solicitud_completadoS = Utility.FechaDefault(modelo.fecha_solicitud_completadoS, "dd/MM/yyyy", "yyyy-MM-dd");
                    obj = modelo.ToConvenioLicencia();
                    res = ConvenioLicencia.Crear((ConvenioLicencia)obj);
                }
                else if (modelo.tipo == "ContratoCesion")
                {
                    modelo.fecha_instruccionesS = Utility.FechaDefault(modelo.fecha_instruccionesS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_instrucciones_completadoS = Utility.FechaDefault(modelo.fecha_instrucciones_completadoS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_envio_documentosS = Utility.FechaDefault(modelo.fecha_envio_documentosS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_envio_documentos_completadoS = Utility.FechaDefault(modelo.fecha_envio_documentos_completadoS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_solicitudS = Utility.FechaDefault(modelo.fecha_solicitudS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_concesionS = Utility.FechaDefault(modelo.fecha_concesionS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_legalS = Utility.FechaDefault(modelo.fecha_legalS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_vencimientoS = Utility.FechaDefault(modelo.fecha_vencimientoS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_solicitud_completadoS = Utility.FechaDefault(modelo.fecha_solicitud_completadoS, "dd/MM/yyyy", "yyyy-MM-dd");
                    obj = modelo.ToContratoCesion();
                    res = ContratoCesion.Crear((ContratoCesion)obj);
                }
                else
                {
                    res.flag = false;
                    res.description = "No existe el tipo";
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/UpdateCatalogo")]
        [HttpPost]
        public RespuestaFormato UpdateCatalogo([FromBody] CTMCatalogo modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                object obj = new object();
                if (modelo.tipo == "NegocioPI")
                {
                    obj = modelo.ToNegocioPI();
                    res = NegocioPI.Actualizar((NegocioPI)obj);
                }
                else if (modelo.tipo == "TipoCatalogo")
                {
                    obj = modelo.ToTipoCatalogo();
                    res = TipoCatalogo.Actualizar((TipoCatalogo)obj);
                }
                else if (modelo.tipo == "TipoRegistro")
                {
                    obj = modelo.ToTipoRegistro();
                    res = TipoRegistro.Actualizar((TipoRegistro)obj);
                }
                else if (modelo.tipo == "Clase")
                {
                    obj = modelo.ToClase();
                    res = Clase.Actualizar((Clase)obj);
                }
                else if (modelo.tipo == "EstatusCatalogo")
                {
                    obj = modelo.ToEstatusCatalogo();
                    res = EstatusCatalogo.Actualizar((EstatusCatalogo)obj);
                }
                else if (modelo.tipo == "Despacho")
                {
                    obj = modelo.ToDespacho();
                    res = Despacho.Actualizar((Despacho)obj);
                }
                else if (modelo.tipo == "Corresponsal")
                {
                    obj = modelo.ToCorresponsal();
                    res = Corresponsal.Actualizar((Corresponsal)obj);
                }
                else if (modelo.tipo == "Pais")
                {
                    obj = modelo.ToPais();
                    res = Pais.Actualizar((Pais)obj);
                }
                else if (modelo.tipo == "ConvenioLicencia")
                {
                    modelo.fecha_instruccionesS = Utility.FechaDefault(modelo.fecha_instruccionesS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_instrucciones_completadoS = Utility.FechaDefault(modelo.fecha_instrucciones_completadoS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_envio_documentosS = Utility.FechaDefault(modelo.fecha_envio_documentosS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_envio_documentos_completadoS = Utility.FechaDefault(modelo.fecha_envio_documentos_completadoS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_solicitudS = Utility.FechaDefault(modelo.fecha_solicitudS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_concesionS = Utility.FechaDefault(modelo.fecha_concesionS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_legalS = Utility.FechaDefault(modelo.fecha_legalS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_vencimientoS = Utility.FechaDefault(modelo.fecha_vencimientoS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_solicitud_completadoS = Utility.FechaDefault(modelo.fecha_solicitud_completadoS, "dd/MM/yyyy", "yyyy-MM-dd");
                    obj = modelo.ToConvenioLicencia();
                    res = ConvenioLicencia.Actualizar((ConvenioLicencia)obj);
                }
                else if (modelo.tipo == "ContratoCesion")
                {
                    modelo.fecha_instruccionesS = Utility.FechaDefault(modelo.fecha_instruccionesS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_instrucciones_completadoS = Utility.FechaDefault(modelo.fecha_instrucciones_completadoS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_envio_documentosS = Utility.FechaDefault(modelo.fecha_envio_documentosS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_envio_documentos_completadoS = Utility.FechaDefault(modelo.fecha_envio_documentos_completadoS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_solicitudS = Utility.FechaDefault(modelo.fecha_solicitudS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_concesionS = Utility.FechaDefault(modelo.fecha_concesionS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_legalS = Utility.FechaDefault(modelo.fecha_legalS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_vencimientoS = Utility.FechaDefault(modelo.fecha_vencimientoS, "dd/MM/yyyy", "yyyy-MM-dd");
                    modelo.fecha_solicitud_completadoS = Utility.FechaDefault(modelo.fecha_solicitud_completadoS, "dd/MM/yyyy", "yyyy-MM-dd");
                    obj = modelo.ToContratoCesion();
                    res = ContratoCesion.Actualizar((ContratoCesion)obj);
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/UpdateCatalogoActivo")]
        [HttpPost]
        public RespuestaFormato UpdateCatalogoActivo([FromBody] CTMCatalogo modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                object obj = new object();
                if (modelo.tipo == "NegocioPI")
                {
                    obj = modelo.ToNegocioPI();
                    res = NegocioPI.ActualizarActivo((NegocioPI)obj);
                }
                else if (modelo.tipo == "TipoCatalogo")
                {
                    obj = modelo.ToTipoCatalogo();
                    res = TipoCatalogo.ActualizarActivo((TipoCatalogo)obj);
                }
                else if (modelo.tipo == "TipoRegistro")
                {
                    obj = modelo.ToTipoRegistro();
                    res = TipoRegistro.ActualizarActivo((TipoRegistro)obj);
                }
                else if (modelo.tipo == "Clase")
                {
                    obj = modelo.ToClase();
                    res = Clase.ActualizarActivo((Clase)obj);
                }
                else if (modelo.tipo == "EstatusCatalogo")
                {
                    obj = modelo.ToEstatusCatalogo();
                    res = EstatusCatalogo.ActualizarActivo((EstatusCatalogo)obj);
                }
                else if (modelo.tipo == "Despacho")
                {
                    obj = modelo.ToDespacho();
                    res = Despacho.ActualizarActivo((Despacho)obj);
                }
                else if (modelo.tipo == "Corresponsal")
                {
                    obj = modelo.ToCorresponsal();
                    res = Corresponsal.ActualizarActivo((Corresponsal)obj);
                }
                else if (modelo.tipo == "Pais")
                {
                    obj = modelo.ToPais();
                    res = Pais.ActualizarActivo((Pais)obj);
                }
                else if (modelo.tipo == "ConvenioLicencia")
                {
                    obj = modelo.ToConvenioLicencia();
                    res = ConvenioLicencia.ActualizarActivo((ConvenioLicencia)obj);
                }
                else if (modelo.tipo == "ContratoCesion")
                {
                    obj = modelo.ToContratoCesion();
                    res = ContratoCesion.ActualizarActivo((ContratoCesion)obj);
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }


        [Route("api/WebAPI/SelectCatalogoById")]
        [HttpPost]
        public RespuestaFormato SelectCatalogoById([FromBody] CTMCatalogo modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                if (modelo.tipo == "NegocioPI")
                {
                    res.content.Add(NegocioPI.GetById(modelo.id));
                }
                else if (modelo.tipo == "Pais")
                {
                    res.content.Add(Pais.GetById(modelo.id));
                }
                else if (modelo.tipo == "TipoCatalogo")
                {
                    res.content.Add(TipoCatalogo.GetById(modelo.id));
                }
                else if (modelo.tipo == "TipoRegistro")
                {
                    res.content.Add(TipoRegistro.GetById(modelo.id));
                }
                else if (modelo.tipo == "Clase")
                {
                    res.content.Add(Clase.GetById(modelo.id));
                }
                else if (modelo.tipo == "EstatusCatalogo")
                {
                    res.content.Add(EstatusCatalogo.GetById(modelo.id));
                }
                else if (modelo.tipo == "Despacho")
                {
                    res.content.Add(Despacho.GetById(modelo.id));
                }
                else if (modelo.tipo == "Corresponsal")
                {
                    res.content.Add(Corresponsal.GetById(modelo.id));
                }
                else if (modelo.tipo == "ConvenioLicencia")
                {
                    res.content.Add(ConvenioLicencia.GetById(modelo.id));
                }
                else if (modelo.tipo == "ContratoCesion")
                {
                    res.content.Add(ContratoCesion.GetById(modelo.id));
                }

                res.flag = true;
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }
        #endregion
        //

        #region Marca

        [Route("api/WebAPI/AddMarca")]
        [HttpPost]
        public RespuestaFormato AddMarca([FromBody] Marca modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                if(modelo.fecha_usoS == "")
                {
                    modelo.fecha_usoS = "01/01/1969";
                }
                modelo.fecha_usoS = Utility.FechaDefault(modelo.fecha_usoS, "dd/MM/yyyy", "yyyy-MM-dd");
                res = Marca.Crear(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/UpdateMarca")]
        [HttpPost]
        public RespuestaFormato UpdateMarca([FromBody] Marca modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                if (modelo.fecha_usoS == "")
                {
                    modelo.fecha_usoS = "01/01/1969";
                }
                modelo.fecha_usoS = Utility.FechaDefault(modelo.fecha_usoS, "dd/MM/yyyy", "yyyy-MM-dd");
                res = Marca.Actualizar(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/UpdateMarcaActivo")]
        [HttpPost]
        public RespuestaFormato UpdateMarcaActivo([FromBody] Marca modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                res = Marca.ActualizarActivo(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/SelectMarcaById")]
        [HttpPost]
        public RespuestaFormato SelectMarcaById([FromBody] Marca modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = Marca.GetById(modelo.id);
                if (data.id > 0)
                {
                    res.flag = true;
                    res.content.Add(data);
                }
                else
                {
                    res.description = "No existe la información";
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }
        #endregion

        #region AvisoComercial

        [Route("api/WebAPI/AddAvisoComercial")]
        [HttpPost]
        public RespuestaFormato AddAvisoComercial([FromBody] AvisoComercial modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                if (modelo.fecha_usoS == "")
                {
                    modelo.fecha_usoS = "01/01/1969";
                }
                modelo.fecha_usoS = Utility.FechaDefault(modelo.fecha_usoS, "dd/MM/yyyy", "yyyy-MM-dd");
                res = AvisoComercial.Crear(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/UpdateAvisoComercial")]
        [HttpPost]
        public RespuestaFormato UpdateAvisoComercial([FromBody] AvisoComercial modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                res = AvisoComercial.Actualizar(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/UpdateAvisoComercialActivo")]
        [HttpPost]
        public RespuestaFormato UpdateAvisoComercialActivo([FromBody] AvisoComercial modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                res = AvisoComercial.ActualizarActivo(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/SelectAvisoComercialById")]
        [HttpPost]
        public RespuestaFormato SelectAvisoComercialById([FromBody] AvisoComercial modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = AvisoComercial.GetById(modelo.id);
                if (data.id > 0)
                {
                    res.flag = true;
                    res.content.Add(data);
                }
                else
                {
                    res.description = "No existe la información";
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }
        #endregion


        #region Patente

        [Route("api/WebAPI/AddPatente")]
        [HttpPost]
        public RespuestaFormato AddPatente([FromBody] Patente modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                if (modelo.fecha_nacimientoS == "")
                {
                    modelo.fecha_nacimientoS = "01/01/1969";
                }
                modelo.fecha_nacimientoS = Utility.FechaDefault(modelo.fecha_nacimientoS, "dd/MM/yyyy", "yyyy-MM-dd");
                res = Patente.Crear(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/UpdatePatente")]
        [HttpPost]
        public RespuestaFormato UpdatePatente([FromBody] Patente modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                if (modelo.fecha_nacimientoS == "")
                {
                    modelo.fecha_nacimientoS = "01/01/1969";
                }
                modelo.fecha_nacimientoS = Utility.FechaDefault(modelo.fecha_nacimientoS, "dd/MM/yyyy", "yyyy-MM-dd");
                res = Patente.Actualizar(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/UpdatePatenteActivo")]
        [HttpPost]
        public RespuestaFormato UpdatePatenteActivo([FromBody] Patente modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                res = Patente.ActualizarActivo(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/SelectPatenteById")]
        [HttpPost]
        public RespuestaFormato SelectPatenteById([FromBody] Patente modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = Patente.GetById(modelo.id);
                if (data.id > 0)
                {
                    res.flag = true;
                    res.content.Add(data);
                }
                else
                {
                    res.description = "No existe la información";
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }
        #endregion


        #region ModeloIndustrial

        [Route("api/WebAPI/AddModeloIndustrial")]
        [HttpPost]
        public RespuestaFormato AddModeloIndustrial([FromBody] ModeloIndustrial modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                if (modelo.fecha_nacimientoS == "")
                {
                    modelo.fecha_nacimientoS = "01/01/1969";
                }
                modelo.fecha_nacimientoS = Utility.FechaDefault(modelo.fecha_nacimientoS, "dd/MM/yyyy", "yyyy-MM-dd");
                res = ModeloIndustrial.Crear(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/UpdateModeloIndustrial")]
        [HttpPost]
        public RespuestaFormato UpdateModeloIndustrial([FromBody] ModeloIndustrial modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                if (modelo.fecha_nacimientoS == "")
                {
                    modelo.fecha_nacimientoS = "01/01/1969";
                }
                modelo.fecha_nacimientoS = Utility.FechaDefault(modelo.fecha_nacimientoS, "dd/MM/yyyy", "yyyy-MM-dd");
                res = ModeloIndustrial.Actualizar(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/UpdateModeloIndustrialActivo")]
        [HttpPost]
        public RespuestaFormato UpdateModeloIndustrialActivo([FromBody] ModeloIndustrial modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                res = ModeloIndustrial.ActualizarActivo(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/SelectModeloIndustrialById")]
        [HttpPost]
        public RespuestaFormato SelectModeloIndustrialById([FromBody] ModeloIndustrial modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = ModeloIndustrial.GetById(modelo.id);
                if (data.id > 0)
                {
                    res.flag = true;
                    res.content.Add(data);
                }
                else
                {
                    res.description = "No existe la información";
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }
        #endregion

        #region DisenoIndustrial

        [Route("api/WebAPI/AddDisenoIndustrial")]
        [HttpPost]
        public RespuestaFormato AddDisenoIndustrial([FromBody] DisenoIndustrial modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                if (modelo.fecha_nacimientoS == "")
                {
                    modelo.fecha_nacimientoS = "01/01/1969";
                }
                modelo.fecha_nacimientoS = Utility.FechaDefault(modelo.fecha_nacimientoS, "dd/MM/yyyy", "yyyy-MM-dd");
                res = DisenoIndustrial.Crear(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/UpdateDisenoIndustrial")]
        [HttpPost]
        public RespuestaFormato UpdateDisenoIndustrial([FromBody] DisenoIndustrial modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                if (modelo.fecha_nacimientoS == "")
                {
                    modelo.fecha_nacimientoS = "01/01/1969";
                }
                modelo.fecha_nacimientoS = Utility.FechaDefault(modelo.fecha_nacimientoS, "dd/MM/yyyy", "yyyy-MM-dd");
                res = DisenoIndustrial.Actualizar(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/UpdateDisenoIndustrialActivo")]
        [HttpPost]
        public RespuestaFormato UpdateDisenoIndustrialActivo([FromBody] DisenoIndustrial modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                res = DisenoIndustrial.ActualizarActivo(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/SelectDisenoIndustrialById")]
        [HttpPost]
        public RespuestaFormato SelectDisenoIndustrialById([FromBody] DisenoIndustrial modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = DisenoIndustrial.GetById(modelo.id);
                if (data.id > 0)
                {
                    res.flag = true;
                    res.content.Add(data);
                }
                else
                {
                    res.description = "No existe la información";
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }
        #endregion

        #region ModeloUtilidad

        [Route("api/WebAPI/AddModeloUtilidad")]
        [HttpPost]
        public RespuestaFormato AddModeloUtilidad([FromBody] ModeloUtilidad modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                if (modelo.fecha_nacimientoS == "")
                {
                    modelo.fecha_nacimientoS = "01/01/1969";
                }
                modelo.fecha_nacimientoS = Utility.FechaDefault(modelo.fecha_nacimientoS, "dd/MM/yyyy", "yyyy-MM-dd");
                res = ModeloUtilidad.Crear(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/UpdateModeloUtilidad")]
        [HttpPost]
        public RespuestaFormato UpdateModeloUtilidad([FromBody] ModeloUtilidad modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                res = ModeloUtilidad.Actualizar(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/UpdateModeloUtilidadActivo")]
        [HttpPost]
        public RespuestaFormato UpdateModeloUtilidadActivo([FromBody] ModeloUtilidad modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                res = ModeloUtilidad.ActualizarActivo(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/SelectModeloUtilidadById")]
        [HttpPost]
        public RespuestaFormato SelectModeloUtilidadById([FromBody] ModeloUtilidad modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = ModeloUtilidad.GetById(modelo.id);
                if (data.id > 0)
                {
                    res.flag = true;
                    res.content.Add(data);
                }
                else
                {
                    res.description = "No existe la información";
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }
        #endregion


        #region Obra

        [Route("api/WebAPI/AddObra")]
        [HttpPost]
        public RespuestaFormato AddObra([FromBody] Obra modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                if (modelo.fecha_nacimientoS == "")
                {
                    modelo.fecha_nacimientoS = "01/01/1969";
                }
                modelo.fecha_nacimientoS = Utility.FechaDefault(modelo.fecha_nacimientoS, "dd/MM/yyyy", "yyyy-MM-dd");
                res = Obra.Crear(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/UpdateObra")]
        [HttpPost]
        public RespuestaFormato UpdateObra([FromBody] Obra modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                if (modelo.fecha_nacimientoS == "")
                {
                    modelo.fecha_nacimientoS = "01/01/1969";
                }
                modelo.fecha_nacimientoS = Utility.FechaDefault(modelo.fecha_nacimientoS, "dd/MM/yyyy", "yyyy-MM-dd");
                res = Obra.Actualizar(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/UpdateObraActivo")]
        [HttpPost]
        public RespuestaFormato UpdateObraActivo([FromBody] Obra modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                res = Obra.ActualizarActivo(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/SelectObraById")]
        [HttpPost]
        public RespuestaFormato SelectObraById([FromBody] Obra modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = Obra.GetById(modelo.id);
                if (data.id > 0)
                {
                    res.flag = true;
                    res.content.Add(data);
                }
                else
                {
                    res.description = "No existe la información";
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }
        #endregion


        #region Obra

        [Route("api/WebAPI/AddRecordatorioPI")]
        [HttpPost]
        public RespuestaFormato AddRecordatorioPI([FromBody] RecordatorioPI modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                if (modelo.fecha_recordatorioS == "")
                {
                    modelo.fecha_recordatorioS = "01/01/1969";
                }
                modelo.fecha_recordatorio = DateTime.ParseExact(modelo.fecha_recordatorioS, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (modelo.fecha_finS == "")
                {
                    modelo.fecha_finS = "01/01/1969";
                }
                modelo.fecha_fin = DateTime.ParseExact(modelo.fecha_finS, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                res = RecordatorioPI.Crear(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/UpdateRecordatorioPI")]
        [HttpPost]
        public RespuestaFormato UpdateRecordatorioPI([FromBody] RecordatorioPI modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                if (modelo.fecha_recordatorioS == "")
                {
                    modelo.fecha_recordatorioS = "01/01/1969";
                }
                modelo.fecha_recordatorio = DateTime.ParseExact(modelo.fecha_recordatorioS, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (modelo.fecha_finS == "")
                {
                    modelo.fecha_finS = "01/01/1969";
                }
                modelo.fecha_fin = DateTime.ParseExact(modelo.fecha_finS, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                res = RecordatorioPI.Actualizar(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/UpdateRegistroPIActivo")]
        [HttpPost]
        public RespuestaFormato UpdateRegistroPIActivo([FromBody] RecordatorioPI modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                res = RecordatorioPI.ActualizarActivo(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/SelectRecordatorioPI")]
        [HttpPost]
        public RespuestaFormato SelectRecordatorioPI([FromBody] RecordatorioPI modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = RecordatorioPI.GetById(modelo.id);
                if (data.id > 0)
                {
                    res.flag = true;
                    res.content.Add(data);
                }
                else
                {
                    res.description = "No existe la información";
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }
        #endregion

        #region RegistroMarca

        [Route("api/WebAPI/UpdateOBJRegistroMarca")]
        [HttpPost]
        public RespuestaFormato UpdateOBJRegistroMarca([FromBody] RegistroMarcaOBJ modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {

                modelo.registro.fecha_legal = Utility.GetDateTime(modelo.registro.fecha_legalS, "dd/MM/yyyy");
                modelo.registro.fecha_vencimiento = Utility.GetDateTime(modelo.registro.fecha_vencimientoS, "dd/MM/yyyy");
                modelo.registro.fecha_concesion = Utility.GetDateTime(modelo.registro.fecha_concesionS, "dd/MM/yyyy");
                modelo.registro.fecha_quinquenio_anualidad = Utility.GetDateTime(modelo.registro.fecha_quinquenio_anualidadS, "dd/MM/yyyy");
                modelo.registro.fecha_vencimiento_prioridad = Utility.GetDateTime(modelo.registro.fecha_vencimiento_prioridadS, "dd/MM/yyyy");

                modelo.registro.fecha_requerimiento = Utility.GetDateTime(modelo.registro.fecha_requerimientoS, "dd/MM/yyyy");
                modelo.registro.fecha_requerimiento_completo = Utility.GetDateTime(modelo.registro.fecha_requerimiento_completoS, "dd/MM/yyyy");
                modelo.registro.fecha_instrucciones = Utility.GetDateTime(modelo.registro.fecha_instruccionesS, "dd/MM/yyyy");
                modelo.registro.fecha_instrucciones_completo = Utility.GetDateTime(modelo.registro.fecha_instrucciones_completoS, "dd/MM/yyyy");
                modelo.registro.fecha_registro = Utility.GetDateTime(modelo.registro.fecha_registroS, "dd/MM/yyyy");
                modelo.registro.fecha_registro_completo = Utility.GetDateTime(modelo.registro.fecha_registro_completoS, "dd/MM/yyyy");
                modelo.registro.fecha_busqueda = Utility.GetDateTime(modelo.registro.fecha_busquedaS, "dd/MM/yyyy");
                modelo.registro.fecha_busqueda_completo = Utility.GetDateTime(modelo.registro.fecha_busqueda_completoS, "dd/MM/yyyy");
                modelo.registro.fecha_resultados = Utility.GetDateTime(modelo.registro.fecha_resultadosS, "dd/MM/yyyy");
                modelo.registro.fecha_resultados_completo = Utility.GetDateTime(modelo.registro.fecha_resultados_completoS, "dd/MM/yyyy");
                modelo.registro.fecha_comprobacion = Utility.GetDateTime(modelo.registro.fecha_comprobacionS, "dd/MM/yyyy");
                modelo.registro.fecha_comprobacion_completo = Utility.GetDateTime(modelo.registro.fecha_comprobacion_completoS, "dd/MM/yyyy");
                modelo.registro.fecha_vencimiento_workflow = Utility.GetDateTime(modelo.registro.fecha_vencimiento_workflowS, "dd/MM/yyyy");
                modelo.registro.fecha_vencimiento_workflow_completo = Utility.GetDateTime(modelo.registro.fecha_vencimiento_workflow_completoS, "dd/MM/yyyy");
                modelo.registro.fecha_concesion_workflow = Utility.GetDateTime(modelo.registro.fecha_concesion_workflowS, "dd/MM/yyyy");
                modelo.registro.fecha_concesion_workflow_completo = Utility.GetDateTime(modelo.registro.fecha_concesion_workflow_completoS, "dd/MM/yyyy");
                modelo.registro.fecha_declaracion = Utility.GetDateTime(modelo.registro.fecha_declaracionS, "dd/MM/yyyy");
                modelo.registro.fecha_declaracion_completo = Utility.GetDateTime(modelo.registro.fecha_declaracion_completoS, "dd/MM/yyyy");

                modelo.registro.fecha_renovar = Utility.GetDateTime(modelo.registro.fecha_renovarS, "dd/MM/yyyy");
                modelo.registro.fecha_renovar_completo = Utility.GetDateTime(modelo.registro.fecha_renovar_completoS, "dd/MM/yyyy");
                modelo.registro.fecha_instruccion_corresponsal = Utility.GetDateTime(modelo.registro.fecha_instruccion_corresponsalS, "dd/MM/yyyy");
                modelo.registro.fecha_instruccion_corresponsal_completo = Utility.GetDateTime(modelo.registro.fecha_instruccion_corresponsal_completoS, "dd/MM/yyyy");
                modelo.registro.fecha_solicitud_empresa = Utility.GetDateTime(modelo.registro.fecha_solicitud_empresaS, "dd/MM/yyyy");
                modelo.registro.fecha_solicitud_empresa_completo = Utility.GetDateTime(modelo.registro.fecha_solicitud_empresa_completoS, "dd/MM/yyyy");
                modelo.registro.fecha_despacho = Utility.GetDateTime(modelo.registro.fecha_despachoS, "dd/MM/yyyy");
                modelo.registro.fecha_despacho_completo = Utility.GetDateTime(modelo.registro.fecha_despacho_completoS, "dd/MM/yyyy");
                modelo.registro.oficio_completo = Utility.GetDateTime(modelo.registro.oficio_completoS, "dd/MM/yyyy");

                if (modelo.registro.id > 0)
                {
                    var preupdate = RegistroMarca.GetById(modelo.registro.id);
                    //actualizar
                    res = RegistroMarca.Actualizar(modelo.registro);
                    if (res.flag != false)
                    {
                        modelo.registro.id = res.data_int;

                        if(preupdate.estatus != modelo.registro.estatus
                            && modelo.registro.estatus == 2)
                        {
                            modelo.enviar_correo_registro = true;
                        }
                    }
                    else
                    {
                        res.description = "Error al crear el registro";
                        res.errors.Add("No se pudo crear el registro en el portal");
                    }
                }
                else
                {
                    //crear
                    res = RegistroMarca.Crear(modelo.registro);
                    if(res.flag != false)
                    {
                        modelo.registro.id = res.data_int;
                        if (modelo.registro.estatus == 2)
                        {
                            modelo.enviar_correo_registro = true;
                        }
                    }
                    else
                    {
                        res.description = "Error al crear el registro";
                        res.errors.Add("No se pudo crear el registro en el portal");
                    }
                }

                //if(modelo.correo_registro == true)
                if (modelo.enviar_correo_registro == true)
                {
                    //correo de que ya esta en registro

                    var email = new EmailTmp();
                    email.subject = "Solicitud en registro";
                    email.mensaje = "<!DOCTYPE html>" +
                    "<html>" +
                    "<head>" +
                    "<link href='https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap' rel='stylesheet'><title></title>" +
                    "<style type='text/css'>body,body * {font-family: 'Lato', sans-serif;} strong { font-weight:600; }</style>" +
                    "</head>" +
                    "<body>" +
                    "<div style='border-top: 25px solid #003e74; padding: 20px 20px; border-radius: 7px; box-shadow: 0px 2px 2px 2px #ddd; width: 450px;border-bottom: 1px solid #ddd;border-right: 1px solid #ddd;border-left: 1px solid #ddd;'>" +
                    "<img src='https://www.gis.com.mx/wp-content/themes/GIS/images/gislogo1.png' style='width: 100px;'>" +
                    "<br>" +
                    "<p style='font-size: 20px;'>Definir contenido</p>" +
                    "<br>" +
                    "<p>Puedes revisar los datos del contrato accediendo al portal.</p>" +
                    "<p>Si no puedes visualizar el contrato en el portal solicita ayuda con un administrador.</p>" +
                    "<br>" +
                    "<br>" +
                    "<small><i>No respondas a este mensaje, ha sido generado automáticamente.</i></small>" +
                    "</div>" +
                    "</body>" +
                    "</html>";
                    //email.to = "alejandro.chairesg@gmail.com";// contrato.abogado_email;
                    email.to = "juanjouaem@gmail.com";// contrato.abogado_email;
                    //email.from = "noreply@portalproveedores.com";
                    email.from = "j.delacruz@softdepot.mx";
                    var enviaUsuario = Utility.enviaEmail(0, email);
                }
                res.flag = true;
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }


        [Route("api/WebAPI/UpdateRegistroMarcaVoBo")]
        [HttpPost]
        public RespuestaFormato UpdateRegistroMarcaVoBo([FromBody] RegistroMarca modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                res = RegistroMarca.ActualizarVoBo(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }


        [Route("api/WebAPI/UpdateRegistroMarcaActivo")]
        [HttpPost]
        public RespuestaFormato UpdateRegistroMarcaActivo([FromBody] RegistroMarca modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                res = RegistroMarca.ActualizarActivo(modelo);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/SelectRegistroMarcaById")]
        [HttpPost]
        public RespuestaFormato SelectRegistroMarcaById([FromBody] RegistroMarca modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = RegistroMarca.GetById(modelo.id);
                if (data.id > 0)
                {
                    var comentarios = RegistroMarcaComentario.GetFromId(data.id);
                    var archivos = RLArchivo.GetFromRegistroMarca(data.id, "");
                    res.flag = true;
                    res.content.Add(data);
                    res.content.Add(comentarios);
                    res.content.Add(archivos);
                }
                else
                {
                    res.description = "No existe la información";
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/SelectRegistrMarcaoArchivos")]
        [HttpPost]
        public RespuestaFormato SelectRegistrMarcaoArchivos([FromBody] RegistroMarca modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = RLArchivo.GetFromRegistroMarca(modelo.id, modelo.nombre);

                res.flag = true;
                res.content.Add(data);
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        [Route("api/WebAPI/AddRegistroMarcaComentario")]
        [HttpPost]
        public async Task<RespuestaFormato> AddRegistroMarcaComentario([FromBody] RegistroMarcaComentario modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var addComentario = RegistroMarcaComentario.Crear(modelo);
                if (addComentario.flag != true)
                {
                    res.errors.Add("No se pudo agregar el comentario, inténtalo más tarde");
                }
                else
                {
                    var comentario = RegistroMarcaComentario.GetById(addComentario.data_int);
                    res.flag = true;
                    res.content.Add(comentario);
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }


        [Route("api/WebAPI/EliminarRegistroMarcaComentario")]
        [HttpPost]
        public async Task<RespuestaFormato> EliminarRegistroMarcaComentario([FromBody] RegistroMarcaComentario modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var comentario = RegistroMarcaComentario.GetById(modelo.id);
                var data = RegistroMarcaComentario.Eliminar(modelo);
                res = data;
                if (data.flag != false)
                {
                    /*
                    RegistroActividad actividad = new RegistroActividad();
                    actividad.usuario.id = modelo.usuario.id;
                    actividad.titulo = "COMENTARIO";
                    actividad.descripcion = "Se eliminó un comentario: " + modelo.descripcion;
                    actividad.contrato = comentario.contrato;
                    actividad.aux_int = comentario.id;
                    actividad.Crear();*/
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }

        #endregion



        [Route("api/WebAPI/UpdateAdministracion")]
        [HttpPost]
        public async Task<RespuestaFormato> UpdateAdministracion([FromBody] RespuestaFormato modelo)
        {
            var res = new RespuestaFormato();
            //--------------------
            try
            {
                var data = RespuestaFormato.ActualizarAdministracion(modelo);
                res = data;
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.description = "Error: " + ex.Message;
            }
            finally
            {
            }
            //--------------------
            //--------------------
            return res;
        }
    }
}
