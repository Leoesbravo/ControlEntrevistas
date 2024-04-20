using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Historico
    {
        public int IdHistorico { get; set; }
        public Filtro Filtro { get; set; }
        public string FechaModificacion  { get; set; }
        public string Detalle  { get; set; }
    }
}
