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
    public class CTMCatalogo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fc { get; set; }
        public DateTime fu { get; set; }
        public int activo { get; set; }
        public string updated_by { get; set; }
        public int orden { get; set; }
        public string rfc { get; set; }
        public string tipo { get; set; }
        //
        public string telefono { get; set; }
        public string email { get; set; }
        public string abogado { get; set; }
        public string abogado_nombre { get; set; }
        public string abogado_email { get; set; }
        //------------------

        public int cedente { get; set; }
        public string cedente_nombre { get; set; }
        public int cesionario { get; set; }
        public string cesionario_nombre { get; set; }

        public int licenciatario { get; set; }
        public string licenciatario_nombre { get; set; }
        public int licenciante { get; set; }
        public string licenciante_nombre { get; set; }
        public string solicitante { get; set; }
        public string solicitante_nombre { get; set; }
        public string numero_registro { get; set; }
        public string numero_expediente { get; set; }
        public int clase { get; set; }
        public string clase_nombre { get; set; }
        public int pais { get; set; }
        public string pais_nombre { get; set; }
        public DateTime fecha_instrucciones { get; set; }
        public DateTime fecha_instrucciones_completado { get; set; }
        public DateTime fecha_envio_documentos { get; set; }
        public DateTime fecha_envio_documentos_completado { get; set; }
        public DateTime fecha_solicitud { get; set; }
        public DateTime fecha_concesion { get; set; }
        public DateTime fecha_legal { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public string observaciones { get; set; }
        public int despacho { get; set; }
        public string despacho_nombre { get; set; }
        public int corresponsal { get; set; }
        public string corresponsal_nombre { get; set; }
        public int tipo_cesion { get; set; }
        public string tipo_cesion_nombre { get; set; }
        public byte[] solicitud_data { get; set; }
        public string solicitud_filename { get; set; }
        public int solicitud_size { get; set; }
        public string solicitud_nombre { get; set; }
        public string solicitud_content_type { get; set; }
        public string solicitud_extension { get; set; }
        public DateTime solicitud_fecha { get; set; }
        public string solicitud_fechaS { get; set; }
        public byte[] oficio_data { get; set; }
        public string oficio_filename { get; set; }
        public int oficio_size { get; set; }
        public string oficio_nombre { get; set; }
        public string oficio_content_type { get; set; }
        public string oficio_extension { get; set; }
        public DateTime oficio_fecha { get; set; }
        public string oficio_fechaS { get; set; }
        public byte[] contrato_data { get; set; }
        public string contrato_filename { get; set; }
        public int contrato_size { get; set; }
        public string contrato_nombre { get; set; }
        public string contrato_content_type { get; set; }
        public string contrato_extension { get; set; }
        public DateTime contrato_fecha { get; set; }
        public string contrato_fechaS { get; set; }
        public string fecha_instruccionesS { get; set; }
        public string fecha_instrucciones_completadoS { get; set; }
        public string fecha_envio_documentosS { get; set; }
        public string fecha_envio_documentos_completadoS { get; set; }
        public string fecha_solicitudS { get; set; }
        public string fecha_concesionS { get; set; }
        public string fecha_legalS { get; set; }
        public string fecha_vencimientoS { get; set; }
        public string licencia_tipo { get; set; }
        public DateTime fecha_solicitud_completado { get; set; }
        public string fecha_solicitud_completadoS { get; set; }
        public string usuario { get; set; } = "";
        public string usuario_nombre { get; set; } = "";
        public CTMCatalogo()
        {
            id = 0;
            nombre = "";
            descripcion = "";
            fc = DateTime.Parse("1969-01-01");
            fu = DateTime.Parse("1969-01-01");
            activo = 0;
            updated_by = "";
            orden = 0;
            rfc = "";
            tipo = "";
            telefono = "";
            email = "";
            abogado = "";
            abogado_nombre = "";
            abogado_email = "";
            //

            cedente = 0;
            cedente_nombre = "";
            cesionario = 0;
            cesionario_nombre = "";

            licenciatario = 0;
            licenciatario_nombre = "";
            licenciante = 0;
            licenciante_nombre = "";
            solicitante = "";
            solicitante_nombre = "";
            numero_registro = "";
            numero_expediente = "";
            clase = 0;
            clase_nombre = "";
            pais = 0;
            pais_nombre = "";
            fecha_instrucciones = DateTime.Parse("1969-01-01");
            fecha_instrucciones_completado = DateTime.Parse("1969-01-01");
            fecha_envio_documentos = DateTime.Parse("1969-01-01");
            fecha_envio_documentos_completado = DateTime.Parse("1969-01-01");
            fecha_solicitud = DateTime.Parse("1969-01-01");
            fecha_concesion = DateTime.Parse("1969-01-01");
            fecha_legal = DateTime.Parse("1969-01-01");
            fecha_vencimiento = DateTime.Parse("1969-01-01");
            observaciones = "";
            despacho = 0;
            despacho_nombre = "";
            corresponsal = 0;
            corresponsal_nombre = "";
            tipo_cesion = 0;
            tipo_cesion_nombre = "";
            //solicitud_data = new byte { 0 };
            solicitud_filename = "";
            solicitud_size = 0;
            solicitud_nombre = "";
            solicitud_content_type = "";
            solicitud_extension = "";
            solicitud_fecha = DateTime.Parse("1969-01-01");
            //oficio_data = new byte { 0 };
            oficio_filename = "";
            oficio_size = 0;
            oficio_nombre = "";
            oficio_content_type = "";
            oficio_extension = "";
            oficio_fecha = DateTime.Parse("1969-01-01");
            //contrato_data = new byte { 0 };
            contrato_filename = "";
            contrato_size = 0;
            contrato_nombre = "";
            contrato_content_type = "";
            contrato_extension = "";
            contrato_fecha = DateTime.Parse("1969-01-01");

            fecha_instruccionesS = "";
            fecha_instrucciones_completadoS = "";
            fecha_envio_documentosS = "";
            fecha_envio_documentos_completadoS = "";
            fecha_solicitudS = "";
            fecha_concesionS = "";
            fecha_legalS = "";
            fecha_vencimientoS = "";

            solicitud_fechaS = "";
            oficio_fechaS = "";
            contrato_fechaS = "";
            licencia_tipo = "";
            fecha_solicitud_completado = DateTime.Parse("1969-01-01");
            fecha_solicitud_completadoS = "";
            usuario = "";
            usuario_nombre = "";
        }

        public NegocioPI ToNegocioPI()
        {
            NegocioPI res = new NegocioPI();
            try
            {
                res.id = this.id;
                res.nombre = this.nombre;
                res.descripcion = this.descripcion;
                res.fc = this.fc;
                res.fc = this.fc;
                res.activo = this.activo;
                res.updated_by = this.updated_by;
                res.orden = this.orden;
                res.rfc = this.rfc;
                res.usuario = this.usuario;
                res.usuario_nombre = this.usuario_nombre;
            }
            catch (Exception ex)
            {
                res = new NegocioPI();
            }
            return res;
        }


        public TipoCatalogo ToTipoCatalogo()
        {
            TipoCatalogo res = new TipoCatalogo();
            try
            {
                res.id = this.id;
                res.nombre = this.nombre;
                res.descripcion = this.descripcion;
                res.fc = this.fc;
                res.fc = this.fc;
                res.activo = this.activo;
                res.updated_by = this.updated_by;
                res.orden = this.orden;
            }
            catch (Exception ex)
            {
                res = new TipoCatalogo();
            }
            return res;
        }

        public Clase ToClase()
        {
            Clase res = new Clase();
            try
            {
                res.id = this.id;
                res.nombre = this.nombre;
                res.descripcion = this.descripcion;
                res.fc = this.fc;
                res.fc = this.fc;
                res.activo = this.activo;
                res.updated_by = this.updated_by;
                res.orden = this.orden;
                res.usuario = this.usuario;
                res.usuario_nombre = this.usuario_nombre;
            }
            catch (Exception ex)
            {
                res = new Clase();
            }
            return res;
        }

        public TipoRegistro ToTipoRegistro()
        {
            TipoRegistro res = new TipoRegistro();
            try
            {
                res.id = this.id;
                res.nombre = this.nombre;
                res.descripcion = this.descripcion;
                res.fc = this.fc;
                res.fc = this.fc;
                res.activo = this.activo;
                res.updated_by = this.updated_by;
                res.orden = this.orden;
                res.usuario = this.usuario;
                res.usuario_nombre = this.usuario_nombre;
            }
            catch (Exception ex)
            {
                res = new TipoRegistro();
            }
            return res;
        }
        public EstatusCatalogo ToEstatusCatalogo()
        {
            EstatusCatalogo res = new EstatusCatalogo();
            try
            {
                res.id = this.id;
                res.nombre = this.nombre;
                res.descripcion = this.descripcion;
                res.fc = this.fc;
                res.fc = this.fc;
                res.activo = this.activo;
                res.updated_by = this.updated_by;
                res.orden = this.orden;
                res.usuario = this.usuario;
                res.usuario_nombre = this.usuario_nombre;
            }
            catch (Exception ex)
            {
                res = new EstatusCatalogo();
            }
            return res;
        }

        public Pais ToPais()
        {
            Pais res = new Pais();
            try
            {
                res.id = this.id;
                res.nombre = this.nombre;
                res.descripcion = this.descripcion;
                res.fc = this.fc;
                res.fc = this.fc;
                res.activo = this.activo;
                res.updated_by = this.updated_by;
                res.orden = this.orden;
                res.usuario = this.usuario;
                res.usuario_nombre = this.usuario_nombre;
            }
            catch (Exception ex)
            {
                res = new Pais();
            }
            return res;
        }
        public Despacho ToDespacho()
        {
            Despacho res = new Despacho();
            try
            {
                res.id = this.id;
                res.nombre = this.nombre;
                res.telefono = this.telefono;
                res.fc = this.fc;
                res.fc = this.fc;
                res.activo = this.activo;
                res.email = this.email;
                res.orden = this.orden;
                res.abogado = this.abogado;
                res.abogado_nombre = this.abogado_nombre;
                res.abogado_email = this.abogado_email;
                res.usuario = this.usuario;
                res.usuario_nombre = this.usuario_nombre;
            }
            catch (Exception ex)
            {
                res = new Despacho();
            }
            return res;
        }
        public Corresponsal ToCorresponsal()
        {
            Corresponsal res = new Corresponsal();
            try
            {
                res.id = this.id;
                res.nombre = this.nombre;
                res.telefono = this.telefono;
                res.fc = this.fc;
                res.fc = this.fc;
                res.activo = this.activo;
                res.email = this.email;
                res.orden = this.orden;
                res.abogado = this.abogado;
                res.abogado_nombre = this.abogado_nombre;
                res.abogado_email = this.abogado_email;
                res.usuario = this.usuario;
                res.usuario_nombre = this.usuario_nombre;
            }
            catch (Exception ex)
            {
                res = new Corresponsal();
            }
            return res;
        }


        public ConvenioLicencia ToConvenioLicencia()
        {
            ConvenioLicencia res = new ConvenioLicencia();
            try
            {
                res.id = this.id;
                res.licenciatario = this.licenciatario;
                res.licenciatario_nombre = this.licenciatario_nombre;
                res.licenciante = this.licenciante;
                res.licenciante_nombre = this.licenciante_nombre;
                res.solicitante = this.solicitante;
                res.solicitante_nombre = this.solicitante_nombre;
                res.nombre = this.nombre;
                res.numero_registro = this.numero_registro;
                res.numero_expediente = this.numero_expediente;
                res.fc = this.fc;
                res.fu = this.fu;
                res.activo = this.activo;
                res.clase = this.clase;
                res.orden = this.orden;
                res.clase_nombre = this.clase_nombre;
                res.pais = this.pais;
                res.pais_nombre = this.pais_nombre;
                res.fecha_instrucciones = this.fecha_instrucciones;
                res.fecha_instrucciones_completado = this.fecha_instrucciones_completado;
                res.fecha_envio_documentos = this.fecha_envio_documentos;
                res.fecha_envio_documentos_completado = this.fecha_envio_documentos_completado;
                res.fecha_solicitud = this.fecha_solicitud;
                res.fecha_concesion = this.fecha_concesion;
                res.fecha_legal = this.fecha_legal;
                res.fecha_vencimiento = this.fecha_vencimiento;
                res.observaciones = this.observaciones;
                res.despacho = this.despacho;
                res.despacho_nombre = this.despacho_nombre;
                res.corresponsal = this.corresponsal;
                res.corresponsal_nombre = this.corresponsal_nombre;
                res.tipo_cesion = this.tipo_cesion;
                res.tipo_cesion_nombre = this.tipo_cesion_nombre;
                
                res.solicitud_data = this.solicitud_data;
                res.solicitud_filename = this.solicitud_filename;
                res.solicitud_size = this.solicitud_size;
                res.solicitud_nombre = this.solicitud_nombre;
                res.solicitud_content_type = this.solicitud_content_type;
                res.solicitud_extension = this.solicitud_extension;
                res.solicitud_fecha = this.solicitud_fecha;
                res.solicitud_fechaS = this.solicitud_fechaS;

                res.oficio_data = this.oficio_data;
                res.oficio_filename = this.oficio_filename;
                res.oficio_size = this.oficio_size;
                res.oficio_nombre = this.oficio_nombre;
                res.oficio_content_type = this.oficio_content_type;
                res.oficio_extension = this.oficio_extension;
                res.oficio_fecha = this.oficio_fecha;
                res.oficio_fechaS = this.oficio_fechaS;

                res.contrato_data = this.contrato_data;
                res.contrato_filename = this.contrato_filename;
                res.contrato_size = this.contrato_size;
                res.contrato_nombre = this.contrato_nombre;
                res.contrato_content_type = this.contrato_content_type;
                res.contrato_extension = this.contrato_extension;
                res.contrato_fecha = this.contrato_fecha;
                res.contrato_fechaS = this.contrato_fechaS;


                res.fecha_instruccionesS = this.fecha_instruccionesS;
                res.fecha_instrucciones_completadoS = this.fecha_instrucciones_completadoS;
                res.fecha_envio_documentosS = this.fecha_envio_documentosS;
                res.fecha_envio_documentos_completadoS = this.fecha_envio_documentos_completadoS;
                res.fecha_solicitudS = this.fecha_solicitudS;
                res.fecha_concesionS = this.fecha_concesionS;
                res.fecha_legalS = this.fecha_legalS;
                res.fecha_vencimientoS = this.fecha_vencimientoS;
                res.licencia_tipo = this.licencia_tipo;
                res.fecha_solicitud_completado = this.fecha_solicitud_completado;
                res.fecha_solicitud_completadoS = this.fecha_solicitud_completadoS;
                res.usuario = this.usuario;
                res.usuario_nombre = this.usuario_nombre;
            }
            catch (Exception ex)
            {
                res = new ConvenioLicencia();
            }
            return res;
        }

        public ContratoCesion ToContratoCesion()
        {
            ContratoCesion res = new ContratoCesion();
            try
            {
                res.id = this.id;
                res.cedente = this.cedente;
                res.cedente_nombre = this.cedente_nombre;
                res.cesionario = this.cesionario;
                res.cesionario_nombre = this.cesionario_nombre;
                res.solicitante = this.solicitante;
                res.solicitante_nombre = this.solicitante_nombre;
                res.nombre = this.nombre;
                res.numero_registro = this.numero_registro;
                res.numero_expediente = this.numero_expediente;
                res.fc = this.fc;
                res.fu = this.fu;
                res.activo = this.activo;
                res.clase = this.clase;
                res.orden = this.orden;
                res.clase_nombre = this.clase_nombre;
                res.pais = this.pais;
                res.pais_nombre = this.pais_nombre;
                res.fecha_instrucciones = this.fecha_instrucciones;
                res.fecha_instrucciones_completado = this.fecha_instrucciones_completado;
                res.fecha_envio_documentos = this.fecha_envio_documentos;
                res.fecha_envio_documentos_completado = this.fecha_envio_documentos_completado;
                res.fecha_solicitud = this.fecha_solicitud;
                res.fecha_concesion = this.fecha_concesion;
                res.fecha_legal = this.fecha_legal;
                res.fecha_vencimiento = this.fecha_vencimiento;
                res.observaciones = this.observaciones;
                res.despacho = this.despacho;
                res.despacho_nombre = this.despacho_nombre;
                res.corresponsal = this.corresponsal;
                res.corresponsal_nombre = this.corresponsal_nombre;
                res.tipo_cesion = this.tipo_cesion;
                res.tipo_cesion_nombre = this.tipo_cesion_nombre;

                res.solicitud_data = this.solicitud_data;
                res.solicitud_filename = this.solicitud_filename;
                res.solicitud_size = this.solicitud_size;
                res.solicitud_nombre = this.solicitud_nombre;
                res.solicitud_content_type = this.solicitud_content_type;
                res.solicitud_extension = this.solicitud_extension;
                res.solicitud_fecha = this.solicitud_fecha;
                res.solicitud_fechaS = this.solicitud_fechaS;

                res.oficio_data = this.oficio_data;
                res.oficio_filename = this.oficio_filename;
                res.oficio_size = this.oficio_size;
                res.oficio_nombre = this.oficio_nombre;
                res.oficio_content_type = this.oficio_content_type;
                res.oficio_extension = this.oficio_extension;
                res.oficio_fecha = this.oficio_fecha;
                res.oficio_fechaS = this.oficio_fechaS;

                res.contrato_data = this.contrato_data;
                res.contrato_filename = this.contrato_filename;
                res.contrato_size = this.contrato_size;
                res.contrato_nombre = this.contrato_nombre;
                res.contrato_content_type = this.contrato_content_type;
                res.contrato_extension = this.contrato_extension;
                res.contrato_fecha = this.contrato_fecha;
                res.contrato_fechaS = this.contrato_fechaS;


                res.fecha_instruccionesS = this.fecha_instruccionesS;
                res.fecha_instrucciones_completadoS = this.fecha_instrucciones_completadoS;
                res.fecha_envio_documentosS = this.fecha_envio_documentosS;
                res.fecha_envio_documentos_completadoS = this.fecha_envio_documentos_completadoS;
                res.fecha_solicitudS = this.fecha_solicitudS;
                res.fecha_concesionS = this.fecha_concesionS;
                res.fecha_legalS = this.fecha_legalS;
                res.fecha_vencimientoS = this.fecha_vencimientoS;
                res.fecha_solicitud_completado = this.fecha_solicitud_completado;
                res.fecha_solicitud_completadoS = this.fecha_solicitud_completadoS;
                res.usuario = this.usuario;
                res.usuario_nombre = this.usuario_nombre;
            }
            catch (Exception ex)
            {
                res = new ContratoCesion();
            }
            return res;
        }
    }
}
