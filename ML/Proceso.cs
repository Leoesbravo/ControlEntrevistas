using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Proceso
    {
        public int IdProceso { get; set; }
        public Recurso Recurso { get; set; }
        public Estatus Estatus { get; set; }
        public BolsaTrabajo BolsaTrabajo { get; set; }
        public Historico Historico { get; set; }
        public string NumeroContacto { get; set; }
        public string Empresa { get; set; }
        public string Cliente { get; set; }
        public string FechaContacto { get; set; }
        public string LigaVacante { get; set; }
        public bool Postulado { get; set; }
        public decimal OfertaEconomica { get; set; }
        public string ContactoRH { get; set; }
        public string CorreoRH { get; set; }
        public string DuracionProceso { get; set; }
        public string DireccionVacante { get; set; }
        public List<object> Procesos { get; set; }
    }
}
