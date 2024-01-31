using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GISMVC.Models
{
    public class TemplateGenerartor
    {
        public static RespuestaFormato Notificacion_RevisionPorAbogado_Usuario(Contrato contrato)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                RespuestaFormato template = RespuestaFormato.Get("NOTIFICACION REVISIÓN ABOGADO - USUARIO");
                string datos_contrato = "";
                if(template.flag != false)
                {
                    res.data_string = template.data_string;
                }
                else
                {
                    res.data_string = "<!DOCTYPE html>" +
                            "<html>" +
                            "<head>" +
                            "<link href='https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap' rel='stylesheet'><title></title>" +
                            "<style type='text/css'>body,body * {font-family: 'Lato', sans-serif;} strong { font-weight:600; }</style>" +
                            "</head>" +
                            "<body>" +
                            "<div style='border-top: 25px solid #003e74; padding: 20px 20px; border-radius: 7px; box-shadow: 0px 2px 2px 2px #ddd; width: 450px;border-bottom: 1px solid #ddd;border-right: 1px solid #ddd;border-left: 1px solid #ddd;'>" +
                            "<img src='https://www.gis.com.mx/wp-content/themes/GIS/images/gislogo1.png' style='width: 100px;'>" +
                            "<br>" +
                            "<p style='font-size: 20px;'>Se ha iniciado un flujo para la atención de su solicitud de contrato <strong>@CONTRATO_FOLIO</strong></p>" +
                            "<br>" +
                            "@DATOS_CONTRATO" +
                            "<p>Su solicitud se le asignó al abogado: <strong>@ABOGADO_NOMBRE</strong></p>" +
                            "<p>Datos del contrato: @CONTRATO_DESCRIPCION</p>" +
                            "<br>" +
                            "<p>Para ver el detalle del contrato, dar click <a href='@CONTRATO_PERMALINK'>aquí</a></p>" +
                            "<br>" +
                            "<br>" +
                            "<small><i>No respondas a este mensaje, ha sido generado automáticamente.</i></small>" +
                            "</div>" +
                            "</body>" +
                            "</html>";
                }

                res.data_string.Replace("@ABOGADO_NOMBRE", contrato.abogado_nombre)
                    .Replace("@CONTRATO_DESCRIPCION", contrato.descripcion)
                    .Replace("@CONTRATO_FOLIO", contrato.folio)
                    .Replace("@DATOS_CONTRATO", datos_contrato)
                    .Replace("@CONTRATO_PERMALINK", contrato.permalink);
                res.flag = true;
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
