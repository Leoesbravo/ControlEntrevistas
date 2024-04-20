using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Filtro
    {
        public Filtro()
        {

        }
        public Filtro(List<object> filtros)
        {
            Filtros = filtros;
        }
        public byte IdFiltro { get; set; }
        public string Descripcion { get; set; }
        public List<object> Filtros { get; set; }
    }
}
