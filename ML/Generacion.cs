using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Generacion
    {
        public int IdGeneracion { get; set; }
        public string Nombre { get; set; }
        public string NombreCompleto { get; set; }
        public string Anio { get; set; }
        public Perfil Perfil { get; set; }
        public List<object> Generaciones { get; set; }
    }
}
