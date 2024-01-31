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

    public class OBJ_Contrato
    {
        public Contrato contrato { get; set; }
        public List<DocumentoContrato> documentos { get; set; }
        public List<DocumentoContrato> documentos_cliente { get; set; }
        public List<ComentarioContrato> comentarios { get; set; }
        public List<RecordatorioContrato> recordatorios { get; set; }
        public List<ColaboradorContrato> colaboradores { get; set; }

        public bool enviar { get; set; }
        public string usuario { get; set; }
        public OBJ_Contrato()
        {
            enviar = false;
            contrato = new Contrato();
            documentos = new List<DocumentoContrato>();
            comentarios = new List<ComentarioContrato>();
            recordatorios = new List<RecordatorioContrato>();
            colaboradores = new List<ColaboradorContrato>();
            usuario = "";
        }
    }
}
