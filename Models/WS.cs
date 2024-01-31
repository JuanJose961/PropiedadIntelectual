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

    public class WS_RFC
    {
        public bool flag { get; set; }
        public string error { get; set; }
        public string P_RFC { get; set; }
        public int contrato { get; set; }
        public string GIS_CLIENTE_PROV_NOMBRE_FN { get; set; }
        public WS_RFC()
        {
            flag = false;
            error = "";
            P_RFC = "";
            contrato = 0;
            GIS_CLIENTE_PROV_NOMBRE_FN = "";
        }


        public static async Task<WS_RFC> GetByRFC(WS_RFC modelo)
        {
            WS_RFC res = new WS_RFC();
            try
            {
                PortalJuridicoWS_RFC.BPELNomProvClienClient spClient = new PortalJuridicoWS_RFC.BPELNomProvClienClient();
                PortalJuridicoWS_RFC.GisClienProvNomRequest request = new PortalJuridicoWS_RFC.GisClienProvNomRequest();
                PortalJuridicoWS_RFC.GisClienProvNomResponse1 response = new PortalJuridicoWS_RFC.GisClienProvNomResponse1();

                request.P_RFC = modelo.P_RFC;

                response = await spClient.GisClienProvNomAsync(request);

                if (response.GisClienProvNomResponse.GIS_CLIENTE_PROV_NOMBRE_FN != null) {
                    if (response.GisClienProvNomResponse.GIS_CLIENTE_PROV_NOMBRE_FN != "")
                    {
                        res.flag = true;
                        res.GIS_CLIENTE_PROV_NOMBRE_FN = response.GisClienProvNomResponse.GIS_CLIENTE_PROV_NOMBRE_FN;
                    }
                    else
                    {
                        res.error = "El rfc no existe";
                    }
                }
                else
                {
                    res.error = "El resultado es nulo";
                }

            }
            catch (Exception ex)
            {
                res = new WS_RFC();
            }
            finally
            {
                //con.Close();
            }
            return res;
        }
    }
}
