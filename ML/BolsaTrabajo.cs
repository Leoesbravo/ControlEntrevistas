using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class BolsaTrabajo
    {
        public BolsaTrabajo()
        {

        }
        public BolsaTrabajo(List<object> medioList)
        {
            MedioList = medioList;
        }
        public byte IdBolsaTrabajo { get; set; }
        public string Medio { get; set; }
        public List<object> MedioList { get; set; }
    }
}
