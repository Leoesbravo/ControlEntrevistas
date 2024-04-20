using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Recurso
    {
        public int IdRecurso { get; set; }
        public Usuario Usuario { get; set; }
        public Generacion Generacion { get; set; }
    }
}
