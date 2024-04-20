using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public Persona()
        {

        }
        public Persona(string nombre, string apellidoMaterno, string apellidoPaterno)
        {
            Nombre = nombre;
            ApellidoPaterno = apellidoMaterno;
            ApellidoMaterno = apellidoPaterno;
        }
        public static string Saludar(Persona persona)
        {
            return "Hola" + persona.Nombre;
        }
        public static List<object> CrearLista()
        {
            return new List<object>();
        }
    }
}
