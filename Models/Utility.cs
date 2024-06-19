//using QRCoder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
namespace GISMVC.Models
{
    public class Utility
    {
        public static string hosturl = ConfigurationManager.AppSettings["HostUrl"].ToString();//";
        public static bool accesoGeneral = true;
        //ADRIAN.BUSTOS@SERSA.MX
        //AcSoft$2058
        //public static string hosturl = "https://localhost:44391/";
        //public static string hosturl = hosturl + "";
        //public static string hosturl = "https://fsdev.gis.com.mx/PortalProvIS/";
        //public static string connstring = "Server=LAPTOP-J1OG09AR;Database=softdepo_aguaoptima;Trusted_Connection=True;MultipleActiveResultSets=true;User Id=alexchg;pwd=lmad2014";

        public static long GetDirectorySize(string folderPath)
        {
            long result = 0;
            try
            {
                DirectoryInfo di = new DirectoryInfo(folderPath);
                result = di.EnumerateFiles("*", SearchOption.AllDirectories).Sum(fi => fi.Length);
            }
            catch (Exception ex)
            {
                return result = 0;
            }
            return result;
        }

        public static string GetFriendlyTitle(string title, bool remapToAscii = false, int maxlength = 80)
        {
            if (title == null)
            {
                return string.Empty;
            }

            int length = title.Length;
            bool prevdash = false;
            StringBuilder stringBuilder = new StringBuilder(length);
            char c;

            for (int i = 0; i < length; ++i)
            {
                c = title[i];
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                {
                    stringBuilder.Append(c);
                    prevdash = false;
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    // tricky way to convert to lower-case
                    stringBuilder.Append((char)(c | 32));
                    prevdash = false;
                }
                else if ((c == ' ') || (c == ',') || (c == '.') || (c == '/') ||
                    (c == '\\') || (c == '-') || (c == '_') || (c == '='))
                {
                    if (!prevdash && (stringBuilder.Length > 0))
                    {
                        stringBuilder.Append('-');
                        prevdash = true;
                    }
                }
                else if (c >= 128)
                {
                    int previousLength = stringBuilder.Length;

                    if (remapToAscii)
                    {
                        stringBuilder.Append(RemapInternationalCharToAscii(c));
                    }
                    else
                    {
                        stringBuilder.Append(c);
                    }

                    if (previousLength != stringBuilder.Length)
                    {
                        prevdash = false;
                    }
                }

                if (i == maxlength)
                {
                    break;
                }
            }

            if (prevdash)
            {
                return stringBuilder.ToString().Substring(0, stringBuilder.Length - 1);
            }
            else
            {
                return stringBuilder.ToString();
            }
        }

        private static string RemapInternationalCharToAscii(char character)
        {
            string s = character.ToString().ToLowerInvariant();
            if ("àåáâäãåąā".Contains(s))
            {
                return "a";
            }
            else if ("èéêëę".Contains(s))
            {
                return "e";
            }
            else if ("ìíîïı".Contains(s))
            {
                return "i";
            }
            else if ("òóôõöøőð".Contains(s))
            {
                return "o";
            }
            else if ("ùúûüŭů".Contains(s))
            {
                return "u";
            }
            else if ("çćčĉ".Contains(s))
            {
                return "c";
            }
            else if ("żźž".Contains(s))
            {
                return "z";
            }
            else if ("śşšŝ".Contains(s))
            {
                return "s";
            }
            else if ("ñń".Contains(s))
            {
                return "n";
            }
            else if ("ýÿ".Contains(s))
            {
                return "y";
            }
            else if ("ğĝ".Contains(s))
            {
                return "g";
            }
            else if (character == 'ř')
            {
                return "r";
            }
            else if (character == 'ł')
            {
                return "l";
            }
            else if (character == 'đ')
            {
                return "d";
            }
            else if (character == 'ß')
            {
                return "ss";
            }
            else if (character == 'Þ')
            {
                return "th";
            }
            else if (character == 'ĥ')
            {
                return "h";
            }
            else if (character == 'ĵ')
            {
                return "j";
            }
            else
            {
                return string.Empty;
            }
        }

        public static string CheckStrNull(string s)
        {
            string a = "";
            try
            {

                a = s.Trim();
                if (a.Length <= 0)
                {
                    a = "NO DISPONIBLE";
                }
            }
            catch (Exception ex)
            {
                a = "NO DISPONIBLE";
            }
            return a;
        }

        public static int DateDiff(string s, string f)
        {
            int i = 0;
            try
            {
                DateTime date1 = DateTime.Parse(s);
                DateTime date2 = DateTime.Parse(f);
                i = ((TimeSpan)(date2 - date1)).Days;
            }
            catch (Exception ex)
            {
                i = 0;
            }
            return i;
        }

        public static decimal RandomNumber(int bot, int top)
        {
            try
            {
                Random random = new Random();
                int randomNumber = random.Next(bot, top);
                double randomDouble = random.NextDouble();

                return (decimal)(randomNumber + randomDouble);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            try
            {
                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
                return dtDateTime;
            }
            catch (Exception ex)
            {
                return DateTime.Now;
            }
        }

        public static RespuestaFormato enviaEmail(int tipo, EmailTmp email)
        {
            //RespuestaFormato res = new RespuestaFormato();
            //try
            //{
            //    dll_Gis.Funciones fn = new dll_Gis.Funciones();
            //    int port = 0;
            //    string host = "";
            //    string username = "";
            //    string password = "";
            //    bool ssl = false;
            //    bool defaultCredentials = false;
            //    string deliveryMethod = "";

            //    Int32.TryParse(ConfigurationManager.AppSettings["SMTPPort"].ToString(), out port);
            //    host = fn.Desencriptar(ConfigurationManager.AppSettings["SMTPHost"].ToString());
            //    username = fn.Desencriptar(ConfigurationManager.AppSettings["SMTPUsername"].ToString());
                
            //    Boolean.TryParse(ConfigurationManager.AppSettings["SMTPSSL"].ToString(), out ssl);
            //    Boolean.TryParse(ConfigurationManager.AppSettings["SMTPDefaultCredentials"].ToString(), out defaultCredentials);
            //    deliveryMethod = ConfigurationManager.AppSettings["SMTPDeliveryMethod"].ToString();



            //    MailMessage mail = new MailMessage();
            //    SmtpClient SmtpServer = new SmtpClient(host);

            //    mail.From = new MailAddress(username, "Portal Jurídico");

            //    if (email.to != "")
            //    {
            //        var tos = email.to.Split(',').ToList();
            //        foreach (string to in tos)
            //        {
            //            var copy = new MailAddress(to);
            //            mail.To.Add(email.to);
            //        }
            //    }
            //    //mail.To.Add("alejandro.chairesg@gmail.com");
            //    //mail.To.Add("juanjouaem@gmail.com");
            //    mail.Subject = email.subject;
            //    mail.Body = email.mensaje;
            //    if (email.cc != "")
            //    {
            //        var ccs = email.cc.Split(',').ToList();
            //        foreach (string cci in ccs)
            //        {
            //            var copy = new MailAddress(cci, "CC");
            //            mail.Bcc.Add(copy);
            //        }
            //    }
            //    foreach (var f in email.files)
            //    {
            //        Attachment attachment = new Attachment(f);
            //        mail.Attachments.Add(attachment);
            //    }
            //    mail.IsBodyHtml = true;
            //    mail.ReplyToList.Add(new MailAddress(username, "reply-to"));

            //    SmtpServer.Port = port;
            //    SmtpServer.UseDefaultCredentials = defaultCredentials;
            //    if (deliveryMethod == "Network")
            //    {
            //        SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    }
            //    else
            //    {
            //        password = fn.Desencriptar(ConfigurationManager.AppSettings["SMTPPassword"].ToString());
            //        SmtpServer.Credentials = new System.Net.NetworkCredential(username, password);
            //    }
            //    SmtpServer.EnableSsl = ssl;
            //    //ACTIVAR CORREOS
            //    SmtpServer.Send(mail);
            //    res.flag = true;
            //}
            //catch (Exception ex)
            //{
            //    res.flag = false;
            //    res.errors.Add(ex.Message);
            //}

            //return res;
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("j.delacruz@softdepot.mx", "Sender");
                //mail.To.Add(email.to);
                //mail.To.Add("j.delacruz@softdepot.mx");
                mail.To.Add(email.to);
                mail.Subject = email.subject;
                mail.Body = email.mensaje;
                if (email.cc != "")
                {
                    var ccs = email.cc.Split(',').ToList();
                    foreach (string cci in ccs)
                    {
                        var copy = new MailAddress(cci, "CC");
                        mail.Bcc.Add(copy);
                    }
                }
                foreach (var f in email.files)
                {
                    Attachment attachment = new Attachment(f);
                    mail.Attachments.Add(attachment);
                }
                mail.IsBodyHtml = true;
                mail.ReplyToList.Add(new MailAddress("j.delacruz@softdepot.mx", "reply-to"));

                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = true;
                SmtpServer.Credentials = new System.Net.NetworkCredential("j.delacruz@softdepot.mx", "qamt slev eyla bort");
                SmtpServer.EnableSsl = true;
                //ACTIVAR CORREOS
                SmtpServer.Send(mail);
                res.flag = true;
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.errors.Add(ex.Message);
            }

            return res;

        }

        public static DateTime GetDateTime(string fecha, string formato)
        {
            DateTime _date;
            try
            {
                _date = DateTime.ParseExact(fecha, formato, CultureInfo.InvariantCulture);
            }
            catch(Exception ex)
            {
                _date = DateTime.Parse("1969-01-01");
            }
            return _date;
        }


        public static string GetDateTimeSTR(string fecha, string formatoIn, string formatoOUT)
        {
            string _dateSTR = "";
            DateTime _date;
            try
            {
                _date = DateTime.ParseExact(fecha, formatoIn, CultureInfo.InvariantCulture);
                _dateSTR = _date.ToString(formatoOUT);
            }
            catch (Exception ex)
            {
                _date = DateTime.Parse("1969-01-01");
                _dateSTR = _date.ToString(formatoOUT);
            }
            return _dateSTR;
        }
        public static RespuestaFormato Login_GIS(string username, string password)
        {
            RespuestaFormato res = new RespuestaFormato();
            string outMsg = "";

            try
            {
                dll_Gis.Funciones fn = new dll_Gis.Funciones();
                fn.fs_LogIn(username, password, out outMsg);
                if (outMsg != "")
                {
                    res.flag = false;
                    res.description = outMsg;
                }
                else
                {
                    res.flag = true;
                }
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.errors.Add(ex.Message);
                res.description = "Ocurrió un error.";
            }
            finally
            {
            }

            return res;
        }

        public static string NombreOU(string str)
        {
            string res = str;
            switch (str)
            {
                case "UO_TISAMATIC_R12":
                    /*negocio.IMAGE = Utility.hosturl + "images/iconos/draxton@2x.png";
                    negocio.activo = 1;
                    negocio.COLOR = "#b71234";
                    negocio.NAME = "DRAXTON";*/
                    res = "DRAXTON";
                    break;
                case "UO_CINSA":
                    res = "CINSA";
                    break;
                case "UO_VITROMEX_MFG":
                    res = "VITROMEX";
                    break;
                case "UO_EVERCAST":
                    res = "EVERCAST";
                    break;
                case "UO_GISEDERLAN":
                    res = "GISEDERLAN";
                    break;
                case "UO_AINSA":
                    res = "AINSA";
                    break;
                case "UO_ASGIS":
                    res = "ASGIS";
                    break;
                case "UO_ASGIS_CIFUNSA":
                    res = "ASGIS - CIFUNSA";
                    break;
                case "UO_ASGIS_CINSA":
                    res = "ASGIS - CINSA";
                    break;
                case "UO_ASGIS_TISAMATIC":
                    res = "ASGIS - TISAMATIC";
                    break;
                case "UO_ASGIS_VITROMEX":
                    res = "ASGIS - VITROMEX";
                    break;
                case "UO_AXIMUS_CIFUNSA":
                    res = "AXIMUS - CIFUNSA";
                    break;
                case "UO_AXIMUS_ENASA":
                    res = "AXIMUS - ENASA";
                    break;
                case "UO_AXIMUS_EVERCAST":
                    res = "AXIMUS - EVERCAST";
                    break;
                case "UO_AXIMUS_GISEDERLAN":
                    res = "AXIMUS - GISELDARAN";
                    break;
                case "UO_AXIMUS_TISAMATIC":
                    res = "AXIMUS - TISAMATIC";
                    break;
                case "UO_AZENTI_CERSA":
                    res = "AZENTI - CERSA";
                    break;
                case "UO_AZENTI_VITROMEX":
                    res = "AZENTI - VITROMEX";
                    break;
                case "UO_GISSA_TESO_MXP":
                    res = "GISSA TESSO";
                    break;
                default:
                    res = str;
                    break;
            }
            return res;
        }

        public static string FechaDefault(string str, string originFormat, string retunrFormat)
        {
            DateTime defaultDate = DateTime.Parse("1969-01-01T00:00:00");
            string res = defaultDate.ToString(retunrFormat);

            try
            {
                defaultDate = DateTime.ParseExact(str, originFormat, CultureInfo.InvariantCulture);
                res = defaultDate.ToString(retunrFormat);
            }
            catch(Exception ex)
            {
                defaultDate = DateTime.Parse("1969-01-01T00:00:00");
                res = defaultDate.ToString(retunrFormat);
            }
            return res;
        }

        public static RespuestaFormato GetQR(int embarque)
        {
            RespuestaFormato res = new RespuestaFormato();
            try
            {
                /*
                Embarque item = Embarque.GetById(embarque);
                var funciones = new dll_Gis.Funciones();
                string data = item.ID + "|" + item.ORGANIZACION_ID + "|" + item.ORGANIZACION + "|" + item.PROVEEDOR;
                string qr = "";
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qRCodeData = qrGenerator.CreateQrCode(funciones.Encriptar(data), QRCodeGenerator.ECCLevel.Q);
                QRCode qRCode = new QRCode(qRCodeData);
                Bitmap qRCodeImage = qRCode.GetGraphic(20);
                Byte[] bytes;
                using (MemoryStream stream = new MemoryStream())
                {
                    qRCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    bytes = stream.ToArray();
                }
                qr = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(bytes));

                res.flag = true;
                res.data_string = qr;*/
            }
            catch (Exception ex)
            {
                res.flag = false;
                res.errors.Add(ex.Message);
            }

            return res;
        }

        public static string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        public static string GetContentTypeFromExt(string ext)
        {
            var types = GetMimeTypes();
            ext = ext.ToLowerInvariant();
            return types[ext];
        }

        public static string descifrar(string texto)
        {
            try
            {
                var funciones = new dll_Gis.Funciones();
                return funciones.Desencriptar(texto);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".323", "text/h323"},
                {".3g2", "video/3gpp2"},
                {".3gp", "video/3gpp"},
                {".3gp2", "video/3gpp2"},
                {".3gpp", "video/3gpp"},
                {".7z", "application/x-7z-compressed"},
                {".aa", "audio/audible"},
                {".AAC", "audio/aac"},
                {".aaf", "application/octet-stream"},
                {".aax", "audio/vnd.audible.aax"},
                {".ac3", "audio/ac3"},
                {".aca", "application/octet-stream"},
                {".accda", "application/msaccess.addin"},
                {".accdb", "application/msaccess"},
                {".accdc", "application/msaccess.cab"},
                {".accde", "application/msaccess"},
                {".accdr", "application/msaccess.runtime"},
                {".accdt", "application/msaccess"},
                {".accdw", "application/msaccess.webapplication"},
                {".accft", "application/msaccess.ftemplate"},
                {".acx", "application/internet-property-stream"},
                {".AddIn", "text/xml"},
                {".ade", "application/msaccess"},
                {".adobebridge", "application/x-bridge-url"},
                {".adp", "application/msaccess"},
                {".ADT", "audio/vnd.dlna.adts"},
                {".ADTS", "audio/aac"},
                {".afm", "application/octet-stream"},
                {".ai", "application/postscript"},
                {".aif", "audio/x-aiff"},
                {".aifc", "audio/aiff"},
                {".aiff", "audio/aiff"},
                {".air", "application/vnd.adobe.air-application-installer-package+zip"},
                {".amc", "application/x-mpeg"},
                {".application", "application/x-ms-application"},
                {".art", "image/x-jg"},
                {".asa", "application/xml"},
                {".asax", "application/xml"},
                {".ascx", "application/xml"},
                {".asd", "application/octet-stream"},
                {".asf", "video/x-ms-asf"},
                {".ashx", "application/xml"},
                {".asi", "application/octet-stream"},
                {".asm", "text/plain"},
                {".asmx", "application/xml"},
                {".aspx", "application/xml"},
                {".asr", "video/x-ms-asf"},
                {".asx", "video/x-ms-asf"},
                {".atom", "application/atom+xml"},
                {".au", "audio/basic"},
                {".avi", "video/x-msvideo"},
                {".axs", "application/olescript"},
                {".bas", "text/plain"},
                {".bcpio", "application/x-bcpio"},
                {".bin", "application/octet-stream"},
                {".bmp", "image/bmp"},
                {".c", "text/plain"},
                {".cab", "application/octet-stream"},
                {".caf", "audio/x-caf"},
                {".calx", "application/vnd.ms-office.calx"},
                {".cat", "application/vnd.ms-pki.seccat"},
                {".cc", "text/plain"},
                {".cd", "text/plain"},
                {".cdda", "audio/aiff"},
                {".cdf", "application/x-cdf"},
                {".cer", "application/x-x509-ca-cert"},
                {".chm", "application/octet-stream"},
                {".class", "application/x-java-applet"},
                {".clp", "application/x-msclip"},
                {".cmx", "image/x-cmx"},
                {".cnf", "text/plain"},
                {".cod", "image/cis-cod"},
                {".config", "application/xml"},
                {".contact", "text/x-ms-contact"},
                {".coverage", "application/xml"},
                {".cpio", "application/x-cpio"},
                {".cpp", "text/plain"},
                {".crd", "application/x-mscardfile"},
                {".crl", "application/pkix-crl"},
                {".crt", "application/x-x509-ca-cert"},
                {".cs", "text/plain"},
                {".csdproj", "text/plain"},
                {".csh", "application/x-csh"},
                {".csproj", "text/plain"},
                {".css", "text/css"},
                {".csv", "text/csv"},
                {".cur", "application/octet-stream"},
                {".cxx", "text/plain"},
                {".dat", "application/octet-stream"},
                {".datasource", "application/xml"},
                {".dbproj", "text/plain"},
                {".dcr", "application/x-director"},
                {".def", "text/plain"},
                {".deploy", "application/octet-stream"},
                {".der", "application/x-x509-ca-cert"},
                {".dgml", "application/xml"},
                {".dib", "image/bmp"},
                {".dif", "video/x-dv"},
                {".dir", "application/x-director"},
                {".disco", "text/xml"},
                {".dll", "application/x-msdownload"},
                {".dll.config", "text/xml"},
                {".dlm", "text/dlm"},
                {".doc", "application/msword"},
                {".docm", "application/vnd.ms-word.document.macroEnabled.12"},
                {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
                {".dot", "application/msword"},
                {".dotm", "application/vnd.ms-word.template.macroEnabled.12"},
                {".dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template"},
                {".dsp", "application/octet-stream"},
                {".dsw", "text/plain"},
                {".dtd", "text/xml"},
                {".dtsConfig", "text/xml"},
                {".dv", "video/x-dv"},
                {".dvi", "application/x-dvi"},
                {".dwf", "drawing/x-dwf"},
                {".dwp", "application/octet-stream"},
                {".dxr", "application/x-director"},
                {".eml", "message/rfc822"},
                {".emz", "application/octet-stream"},
                {".eot", "application/octet-stream"},
                {".eps", "application/postscript"},
                {".etl", "application/etl"},
                {".etx", "text/x-setext"},
                {".evy", "application/envoy"},
                {".exe", "application/octet-stream"},
                {".exe.config", "text/xml"},
                {".fdf", "application/vnd.fdf"},
                {".fif", "application/fractals"},
                {".filters", "Application/xml"},
                {".fla", "application/octet-stream"},
                {".flr", "x-world/x-vrml"},
                {".flv", "video/x-flv"},
                {".fsscript", "application/fsharp-script"},
                {".fsx", "application/fsharp-script"},
                {".generictest", "application/xml"},
                {".gif", "image/gif"},
                {".group", "text/x-ms-group"},
                {".gsm", "audio/x-gsm"},
                {".gtar", "application/x-gtar"},
                {".gz", "application/x-gzip"},
                {".h", "text/plain"},
                {".hdf", "application/x-hdf"},
                {".hdml", "text/x-hdml"},
                {".hhc", "application/x-oleobject"},
                {".hhk", "application/octet-stream"},
                {".hhp", "application/octet-stream"},
                {".hlp", "application/winhlp"},
                {".hpp", "text/plain"},
                {".hqx", "application/mac-binhex40"},
                {".hta", "application/hta"},
                {".htc", "text/x-component"},
                {".htm", "text/html"},
                {".html", "text/html"},
                {".htt", "text/webviewhtml"},
                {".hxa", "application/xml"},
                {".hxc", "application/xml"},
                {".hxd", "application/octet-stream"},
                {".hxe", "application/xml"},
                {".hxf", "application/xml"},
                {".hxh", "application/octet-stream"},
                {".hxi", "application/octet-stream"},
                {".hxk", "application/xml"},
                {".hxq", "application/octet-stream"},
                {".hxr", "application/octet-stream"},
                {".hxs", "application/octet-stream"},
                {".hxt", "text/html"},
                {".hxv", "application/xml"},
                {".hxw", "application/octet-stream"},
                {".hxx", "text/plain"},
                {".i", "text/plain"},
                {".ico", "image/x-icon"},
                {".ics", "application/octet-stream"},
                {".idl", "text/plain"},
                {".ief", "image/ief"},
                {".iii", "application/x-iphone"},
                {".inc", "text/plain"},
                {".inf", "application/octet-stream"},
                {".inl", "text/plain"},
                {".ins", "application/x-internet-signup"},
                {".ipa", "application/x-itunes-ipa"},
                {".ipg", "application/x-itunes-ipg"},
                {".ipproj", "text/plain"},
                {".ipsw", "application/x-itunes-ipsw"},
                {".iqy", "text/x-ms-iqy"},
                {".isp", "application/x-internet-signup"},
                {".ite", "application/x-itunes-ite"},
                {".itlp", "application/x-itunes-itlp"},
                {".itms", "application/x-itunes-itms"},
                {".itpc", "application/x-itunes-itpc"},
                {".IVF", "video/x-ivf"},
                {".jar", "application/java-archive"},
                {".java", "application/octet-stream"},
                {".jck", "application/liquidmotion"},
                {".jcz", "application/liquidmotion"},
                {".jfif", "image/pjpeg"},
                {".jnlp", "application/x-java-jnlp-file"},
                {".jpb", "application/octet-stream"},
                {".jpe", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".jpg", "image/jpeg"},
                {".js", "application/x-javascript"},
                {".json", "application/json"},
                {".jsx", "text/jscript"},
                {".jsxbin", "text/plain"},
                {".latex", "application/x-latex"},
                {".library-ms", "application/windows-library+xml"},
                {".lit", "application/x-ms-reader"},
                {".loadtest", "application/xml"},
                {".lpk", "application/octet-stream"},
                {".lsf", "video/x-la-asf"},
                {".lst", "text/plain"},
                {".lsx", "video/x-la-asf"},
                {".lzh", "application/octet-stream"},
                {".m13", "application/x-msmediaview"},
                {".m14", "application/x-msmediaview"},
                {".m1v", "video/mpeg"},
                {".m2t", "video/vnd.dlna.mpeg-tts"},
                {".m2ts", "video/vnd.dlna.mpeg-tts"},
                {".m2v", "video/mpeg"},
                {".m3u", "audio/x-mpegurl"},
                {".m3u8", "audio/x-mpegurl"},
                {".m4a", "audio/m4a"},
                {".m4b", "audio/m4b"},
                {".m4p", "audio/m4p"},
                {".m4r", "audio/x-m4r"},
                {".m4v", "video/x-m4v"},
                {".mac", "image/x-macpaint"},
                {".mak", "text/plain"},
                {".man", "application/x-troff-man"},
                {".manifest", "application/x-ms-manifest"},
                {".map", "text/plain"},
                {".master", "application/xml"},
                {".mda", "application/msaccess"},
                {".mdb", "application/x-msaccess"},
                {".mde", "application/msaccess"},
                {".mdp", "application/octet-stream"},
                {".me", "application/x-troff-me"},
                {".mfp", "application/x-shockwave-flash"},
                {".mht", "message/rfc822"},
                {".mhtml", "message/rfc822"},
                {".mid", "audio/mid"},
                {".midi", "audio/mid"},
                {".mix", "application/octet-stream"},
                {".mk", "text/plain"},
                {".mmf", "application/x-smaf"},
                {".mno", "text/xml"},
                {".mny", "application/x-msmoney"},
                {".mod", "video/mpeg"},
                {".mov", "video/quicktime"},
                {".movie", "video/x-sgi-movie"},
                {".mp2", "video/mpeg"},
                {".mp2v", "video/mpeg"},
                {".mp3", "audio/mpeg"},
                {".mp4", "video/mp4"},
                {".mp4v", "video/mp4"},
                {".mpa", "video/mpeg"},
                {".mpe", "video/mpeg"},
                {".mpeg", "video/mpeg"},
                {".mpf", "application/vnd.ms-mediapackage"},
                {".mpg", "video/mpeg"},
                {".mpp", "application/vnd.ms-project"},
                {".mpv2", "video/mpeg"},
                {".mqv", "video/quicktime"},
                {".ms", "application/x-troff-ms"},
                {".msi", "application/octet-stream"},
                {".mso", "application/octet-stream"},
                {".mts", "video/vnd.dlna.mpeg-tts"},
                {".mtx", "application/xml"},
                {".mvb", "application/x-msmediaview"},
                {".mvc", "application/x-miva-compiled"},
                {".mxp", "application/x-mmxp"},
                {".nc", "application/x-netcdf"},
                {".nsc", "video/x-ms-asf"},
                {".nws", "message/rfc822"},
                {".ocx", "application/octet-stream"},
                {".oda", "application/oda"},
                {".odc", "text/x-ms-odc"},
                {".odh", "text/plain"},
                {".odl", "text/plain"},
                {".odp", "application/vnd.oasis.opendocument.presentation"},
                {".ods", "application/oleobject"},
                {".odt", "application/vnd.oasis.opendocument.text"},
                {".one", "application/onenote"},
                {".onea", "application/onenote"},
                {".onepkg", "application/onenote"},
                {".onetmp", "application/onenote"},
                {".onetoc", "application/onenote"},
                {".onetoc2", "application/onenote"},
                {".orderedtest", "application/xml"},
                {".osdx", "application/opensearchdescription+xml"},
                {".p10", "application/pkcs10"},
                {".p12", "application/x-pkcs12"},
                {".p7b", "application/x-pkcs7-certificates"},
                {".p7c", "application/pkcs7-mime"},
                {".p7m", "application/pkcs7-mime"},
                {".p7r", "application/x-pkcs7-certreqresp"},
                {".p7s", "application/pkcs7-signature"},
                {".pbm", "image/x-portable-bitmap"},
                {".pcast", "application/x-podcast"},
                {".pct", "image/pict"},
                {".pcx", "application/octet-stream"},
                {".pcz", "application/octet-stream"},
                {".pdf", "application/pdf"},
                {".pfb", "application/octet-stream"},
                {".pfm", "application/octet-stream"},
                {".pfx", "application/x-pkcs12"},
                {".pgm", "image/x-portable-graymap"},
                {".pic", "image/pict"},
                {".pict", "image/pict"},
                {".pkgdef", "text/plain"},
                {".pkgundef", "text/plain"},
                {".pko", "application/vnd.ms-pki.pko"},
                {".pls", "audio/scpls"},
                {".pma", "application/x-perfmon"},
                {".pmc", "application/x-perfmon"},
                {".pml", "application/x-perfmon"},
                {".pmr", "application/x-perfmon"},
                {".pmw", "application/x-perfmon"},
                {".png", "image/png"},
                {".pnm", "image/x-portable-anymap"},
                {".pnt", "image/x-macpaint"},
                {".pntg", "image/x-macpaint"},
                {".pnz", "image/png"},
                {".pot", "application/vnd.ms-powerpoint"},
                {".potm", "application/vnd.ms-powerpoint.template.macroEnabled.12"},
                {".potx", "application/vnd.openxmlformats-officedocument.presentationml.template"},
                {".ppa", "application/vnd.ms-powerpoint"},
                {".ppam", "application/vnd.ms-powerpoint.addin.macroEnabled.12"},
                {".ppm", "image/x-portable-pixmap"},
                {".pps", "application/vnd.ms-powerpoint"},
                {".ppsm", "application/vnd.ms-powerpoint.slideshow.macroEnabled.12"},
                {".ppsx", "application/vnd.openxmlformats-officedocument.presentationml.slideshow"},
                {".ppt", "application/vnd.ms-powerpoint"},
                {".pptm", "application/vnd.ms-powerpoint.presentation.macroEnabled.12"},
                {".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation"},
                {".prf", "application/pics-rules"},
                {".prm", "application/octet-stream"},
                {".prx", "application/octet-stream"},
                {".ps", "application/postscript"},
                {".psc1", "application/PowerShell"},
                {".psd", "application/octet-stream"},
                {".psess", "application/xml"},
                {".psm", "application/octet-stream"},
                {".psp", "application/octet-stream"},
                {".pub", "application/x-mspublisher"},
                {".pwz", "application/vnd.ms-powerpoint"},
                {".qht", "text/x-html-insertion"},
                {".qhtm", "text/x-html-insertion"},
                {".qt", "video/quicktime"},
                {".qti", "image/x-quicktime"},
                {".qtif", "image/x-quicktime"},
                {".qtl", "application/x-quicktimeplayer"},
                {".qxd", "application/octet-stream"},
                {".ra", "audio/x-pn-realaudio"},
                {".ram", "audio/x-pn-realaudio"},
                {".rar", "application/octet-stream"},
                {".ras", "image/x-cmu-raster"},
                {".rat", "application/rat-file"},
                {".rc", "text/plain"},
                {".rc2", "text/plain"},
                {".rct", "text/plain"},
                {".rdlc", "application/xml"},
                {".resx", "application/xml"},
                {".rf", "image/vnd.rn-realflash"},
                {".rgb", "image/x-rgb"},
                {".rgs", "text/plain"},
                {".rm", "application/vnd.rn-realmedia"},
                {".rmi", "audio/mid"},
                {".rmp", "application/vnd.rn-rn_music_package"},
                {".roff", "application/x-troff"},
                {".rpm", "audio/x-pn-realaudio-plugin"},
                {".rqy", "text/x-ms-rqy"},
                {".rtf", "application/rtf"},
                {".rtx", "text/richtext"},
                {".ruleset", "application/xml"},
                {".s", "text/plain"},
                {".safariextz", "application/x-safari-safariextz"},
                {".scd", "application/x-msschedule"},
                {".sct", "text/scriptlet"},
                {".sd2", "audio/x-sd2"},
                {".sdp", "application/sdp"},
                {".sea", "application/octet-stream"},
                {".searchConnector-ms", "application/windows-search-connector+xml"},
                {".setpay", "application/set-payment-initiation"},
                {".setreg", "application/set-registration-initiation"},
                {".settings", "application/xml"},
                {".sgimb", "application/x-sgimb"},
                {".sgml", "text/sgml"},
                {".sh", "application/x-sh"},
                {".shar", "application/x-shar"},
                {".shtml", "text/html"},
                {".sit", "application/x-stuffit"},
                {".sitemap", "application/xml"},
                {".skin", "application/xml"},
                {".sldm", "application/vnd.ms-powerpoint.slide.macroEnabled.12"},
                {".sldx", "application/vnd.openxmlformats-officedocument.presentationml.slide"},
                {".slk", "application/vnd.ms-excel"},
                {".sln", "text/plain"},
                {".slupkg-ms", "application/x-ms-license"},
                {".smd", "audio/x-smd"},
                {".smi", "application/octet-stream"},
                {".smx", "audio/x-smd"},
                {".smz", "audio/x-smd"},
                {".snd", "audio/basic"},
                {".snippet", "application/xml"},
                {".snp", "application/octet-stream"},
                {".sol", "text/plain"},
                {".sor", "text/plain"},
                {".spc", "application/x-pkcs7-certificates"},
                {".spl", "application/futuresplash"},
                {".src", "application/x-wais-source"},
                {".srf", "text/plain"},
                {".SSISDeploymentManifest", "text/xml"},
                {".ssm", "application/streamingmedia"},
                {".sst", "application/vnd.ms-pki.certstore"},
                {".stl", "application/vnd.ms-pki.stl"},
                {".sv4cpio", "application/x-sv4cpio"},
                {".sv4crc", "application/x-sv4crc"},
                {".svc", "application/xml"},
                {".swf", "application/x-shockwave-flash"},
                {".t", "application/x-troff"},
                {".tar", "application/x-tar"},
                {".tcl", "application/x-tcl"},
                {".testrunconfig", "application/xml"},
                {".testsettings", "application/xml"},
                {".tex", "application/x-tex"},
                {".texi", "application/x-texinfo"},
                {".texinfo", "application/x-texinfo"},
                {".tgz", "application/x-compressed"},
                {".thmx", "application/vnd.ms-officetheme"},
                {".thn", "application/octet-stream"},
                {".tif", "image/tiff"},
                {".tiff", "image/tiff"},
                {".tlh", "text/plain"},
                {".tli", "text/plain"},
                {".toc", "application/octet-stream"},
                {".tr", "application/x-troff"},
                {".trm", "application/x-msterminal"},
                {".trx", "application/xml"},
                {".ts", "video/vnd.dlna.mpeg-tts"},
                {".tsv", "text/tab-separated-values"},
                {".ttf", "application/octet-stream"},
                {".tts", "video/vnd.dlna.mpeg-tts"},
                {".txt", "text/plain"},
                {".u32", "application/octet-stream"},
                {".uls", "text/iuls"},
                {".user", "text/plain"},
                {".ustar", "application/x-ustar"},
                {".vb", "text/plain"},
                {".vbdproj", "text/plain"},
                {".vbk", "video/mpeg"},
                {".vbproj", "text/plain"},
                {".vbs", "text/vbscript"},
                {".vcf", "text/x-vcard"},
                {".vcproj", "Application/xml"},
                {".vcs", "text/plain"},
                {".vcxproj", "Application/xml"},
                {".vddproj", "text/plain"},
                {".vdp", "text/plain"},
                {".vdproj", "text/plain"},
                {".vdx", "application/vnd.ms-visio.viewer"},
                {".vml", "text/xml"},
                {".vscontent", "application/xml"},
                {".vsct", "text/xml"},
                {".vsd", "application/vnd.visio"},
                {".vsi", "application/ms-vsi"},
                {".vsix", "application/vsix"},
                {".vsixlangpack", "text/xml"},
                {".vsixmanifest", "text/xml"},
                {".vsmdi", "application/xml"},
                {".vspscc", "text/plain"},
                {".vss", "application/vnd.visio"},
                {".vsscc", "text/plain"},
                {".vssettings", "text/xml"},
                {".vssscc", "text/plain"},
                {".vst", "application/vnd.visio"},
                {".vstemplate", "text/xml"},
                {".vsto", "application/x-ms-vsto"},
                {".vsw", "application/vnd.visio"},
                {".vsx", "application/vnd.visio"},
                {".vtx", "application/vnd.visio"},
                {".wav", "audio/wav"},
                {".wave", "audio/wav"},
                {".wax", "audio/x-ms-wax"},
                {".wbk", "application/msword"},
                {".wbmp", "image/vnd.wap.wbmp"},
                {".wcm", "application/vnd.ms-works"},
                {".wdb", "application/vnd.ms-works"},
                {".wdp", "image/vnd.ms-photo"},
                {".webarchive", "application/x-safari-webarchive"},
                {".webtest", "application/xml"},
                {".wiq", "application/xml"},
                {".wiz", "application/msword"},
                {".wks", "application/vnd.ms-works"},
                {".WLMP", "application/wlmoviemaker"},
                {".wlpginstall", "application/x-wlpg-detect"},
                {".wlpginstall3", "application/x-wlpg3-detect"},
                {".wm", "video/x-ms-wm"},
                {".wma", "audio/x-ms-wma"},
                {".wmd", "application/x-ms-wmd"},
                {".wmf", "application/x-msmetafile"},
                {".wml", "text/vnd.wap.wml"},
                {".wmlc", "application/vnd.wap.wmlc"},
                {".wmls", "text/vnd.wap.wmlscript"},
                {".wmlsc", "application/vnd.wap.wmlscriptc"},
                {".wmp", "video/x-ms-wmp"},
                {".wmv", "video/x-ms-wmv"},
                {".wmx", "video/x-ms-wmx"},
                {".wmz", "application/x-ms-wmz"},
                {".wpl", "application/vnd.ms-wpl"},
                {".wps", "application/vnd.ms-works"},
                {".wri", "application/x-mswrite"},
                {".wrl", "x-world/x-vrml"},
                {".wrz", "x-world/x-vrml"},
                {".wsc", "text/scriptlet"},
                {".wsdl", "text/xml"},
                {".wvx", "video/x-ms-wvx"},
                {".x", "application/directx"},
                {".xaf", "x-world/x-vrml"},
                {".xaml", "application/xaml+xml"},
                {".xap", "application/x-silverlight-app"},
                {".xbap", "application/x-ms-xbap"},
                {".xbm", "image/x-xbitmap"},
                {".xdr", "text/plain"},
                {".xht", "application/xhtml+xml"},
                {".xhtml", "application/xhtml+xml"},
                {".xla", "application/vnd.ms-excel"},
                {".xlam", "application/vnd.ms-excel.addin.macroEnabled.12"},
                {".xlc", "application/vnd.ms-excel"},
                {".xld", "application/vnd.ms-excel"},
                {".xlk", "application/vnd.ms-excel"},
                {".xll", "application/vnd.ms-excel"},
                {".xlm", "application/vnd.ms-excel"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsb", "application/vnd.ms-excel.sheet.binary.macroEnabled.12"},
                {".xlsm", "application/vnd.ms-excel.sheet.macroEnabled.12"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".xlt", "application/vnd.ms-excel"},
                {".xltm", "application/vnd.ms-excel.template.macroEnabled.12"},
                {".xltx", "application/vnd.openxmlformats-officedocument.spreadsheetml.template"},
                {".xlw", "application/vnd.ms-excel"},
                {".xml", "text/xml"},
                {".xmta", "application/xml"},
                {".xof", "x-world/x-vrml"},
                {".XOML", "text/plain"},
                {".xpm", "image/x-xpixmap"},
                {".xps", "application/vnd.ms-xpsdocument"},
                {".xrm-ms", "text/xml"},
                {".xsc", "application/xml"},
                {".xsd", "text/xml"},
                {".xsf", "text/xml"},
                {".xsl", "text/xml"},
                {".xslt", "text/xml"},
                {".xsn", "application/octet-stream"},
                {".xss", "application/xml"},
                {".xtp", "application/octet-stream"},
                {".xwd", "image/x-xwindowdump"},
                {".z", "application/x-compress"},
                {".zip", "application/x-zip-compressed"},
            };
        }
        /*
        public static string GetCookieValueFromResponse(HttpResponse response, string cookieName)
        {
            foreach (var headers in response.Headers.Values)
                foreach (var header in headers)
                    if (header.StartsWith($"{cookieName}="))
                    {
                        var p1 = header.IndexOf('=');
                        var p2 = header.IndexOf(';');
                        return header.Substring(p1 + 1, p2 - p1 - 1);
                    }
            return null;
        }*/
    }
    public class EmailTmp
    {
        public string to { get; set; }
        public string cc { get; set; }
        public string from { get; set; }
        public string subject { get; set; }
        public string email { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string puesto { get; set; }
        public string mensaje { get; set; }
        public string fecha_nacimiento { get; set; }
        public string sexo { get; set; }
        public string estado_civil { get; set; }
        public string domicilio { get; set; }
        public string marca { get; set; }
        public string version { get; set; }
        public string anho { get; set; }
        public string detalles { get; set; }
        public string calendario { get; set; }
        public string tema { get; set; }
        public string auto { get; set; }
        public List<string> files { get; set; }

        public EmailTmp()
        {
            to = "";
            from = "";
            email = "";
            nombre = "";
            telefono = "";
            puesto = "";
            mensaje = "";
            fecha_nacimiento = "";
            sexo = "";
            estado_civil = "";
            domicilio = "";
            marca = "";
            version = "";
            anho = "";
            detalles = "";
            calendario = "";
            tema = "";
            auto = "";
            cc = "";
            files = new List<string>();
        }
    }
    public class Administracion
    {
        public static string connstring = "";
        public string NOTIFICACION_ACTA_INICIAL { get; set; }

        public Administracion()
        {
            NOTIFICACION_ACTA_INICIAL = "";
        }

        public static Administracion Get()
        {
            Administracion res = new Administracion();
            Dictionary<string, string> list = new Dictionary<string, string>();
            try
            {
                /*
                DataAccess da = new DataAccess();

                var dt = new System.Data.DataTable();
                var errores = "";
                if (da.CONS_cat_Administracion(out dt, out errores))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int idx = 0;
                            var row = dt.Rows[i];
                            var item = new proc_ActaNacimiento();
                            string keyname = row[idx].ToString(); idx++;
                            string valuename = row[idx].ToString(); idx++;
                            list.Add(keyname, valuename);
                        }
                    }
                    foreach (var item in list)
                    {
                        switch (item.Key)
                        {
                            case "NOTIFICACION_ACTA_INICIAL":
                                res.NOTIFICACION_ACTA_INICIAL = item.Value;
                                break;
                        }
                    }
                }
                else
                {
                    //
                }
                */

            }
            catch (Exception ex)
            {
                res = new Administracion();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }

    }

    public class ZipItem
    {
        public string Name { get; set; }
        public Stream Content { get; set; }
        public ZipItem(string name, Stream content)
        {
            this.Name = name;
            this.Content = content;
        }
        public ZipItem(string name, string contentStr, Encoding encoding)
        {
            // convert string to stream
            var byteArray = encoding.GetBytes(contentStr);
            var memoryStream = new MemoryStream(byteArray);
            this.Name = name;
            this.Content = memoryStream;
        }

        public ZipItem(string name, byte[] bytes)
        {
            // convert string to stream
            var memoryStream = new MemoryStream(bytes);
            this.Name = name;
            this.Content = memoryStream;
        }
    }

    public static class Zipper
    {
        public static Stream Zip(List<ZipItem> zipItems)
        {
            zipItems = zipItems.Where(i => i.Name != "").ToList();
            var zipStream = new MemoryStream();

            using (var zip = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
            {
                foreach (var zipItem in zipItems)
                {
                    var entry = zip.CreateEntry(zipItem.Name);
                    using (var entryStream = entry.Open())
                    {
                        zipItem.Content.CopyTo(entryStream);
                    }
                }
            }
            zipStream.Position = 0;
            return zipStream;
        }
    }
}
