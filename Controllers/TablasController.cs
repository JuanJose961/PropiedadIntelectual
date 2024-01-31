using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using GISMVC.Models;
using System.Web.Mvc;

namespace GISMVC.Controllers
{
    public class TablasController : ApiController
    {
        public class PARAMS
        {
            public int ID { get; set; }
            public string STR { get; set; }
            public string START_DATE { get; set; }
            public string END_DATE { get; set; }
            public string TIPO { get; set; }
        }

        [System.Web.Http.HttpGet]
        public async Task<object> Get(DataSourceLoadOptions loadOptions, string _params)
        {
            PARAMS parametros = JsonConvert.DeserializeObject<PARAMS>(_params);

            IEnumerable<object> ocl = new List<object>();
            switch (parametros.TIPO)
            {
                case "Roles":
                    ocl = AspNetRoles.GetAll("");
                    break;
                case "Usuarios":
                    ocl = AspNetUsers.GetAll("");
                    break;
                case "Colaboradores":
                    ocl = ColaboradorContrato.GetFromId(parametros.ID);
                    break;
                case "NegocioPI":
                    ocl = NegocioPI.Get();
                    break;
                case "TipoCatalogo":
                    ocl = TipoCatalogo.Get();
                    break;
                case "EstatusCatalogo":
                    ocl = EstatusCatalogo.Get();
                    break;
                case "Pais":
                    ocl = Pais.Get();
                    break;
                case "TipoRegistro":
                    ocl = TipoRegistro.Get();
                    break;
                case "Clase":
                    ocl = Clase.Get();
                    break;
                case "Despacho":
                    ocl = Despacho.Get();
                    break;
                case "Corresponsal":
                    ocl = Corresponsal.Get();
                    break;
                case "ConvenioLicencia":
                    ocl = ConvenioLicencia.Get();
                    break;
                case "ContratoCesion":
                    ocl = ContratoCesion.Get();
                    break;
                case "Marca":
                    ocl = Marca.Get();
                    break;
                case "AvisoComercial":
                    ocl = AvisoComercial.Get();
                    break;
                case "Patente":
                    ocl = Patente.Get();
                    break;
                case "DisenoIndustrial":
                    ocl = DisenoIndustrial.Get();
                    break;
                case "ModeloUtilidad":
                    ocl = ModeloUtilidad.Get();
                    break;
                case "ModeloIndustrial":
                    ocl = ModeloIndustrial.Get();
                    break;
                case "Obra":
                    ocl = Obra.Get();
                    break;
                case "RegistroMarca":
                    ocl = RegistroMarca.Get();
                    break;
                case "RecordatorioPI":
                    ocl = RecordatorioPI.Get();
                    break;
                case "UsuariosV2":
                    ocl = AspNetUsers.GetAllV2("");
                    break;
            }
            return Request.CreateResponse(DataSourceLoader.Load(ocl, loadOptions));
        }
    }
}
