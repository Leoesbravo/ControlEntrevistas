using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Estatus
    {
        public Estatus()
        {

        }
        public Estatus(List<object> estatusList)
        {
            EstatusList = estatusList;
        }
        public byte IdEstatus { get; set; }
        public string Descripcion { get; set; }
        public List<object> EstatusList { get; set; }
    }
}
