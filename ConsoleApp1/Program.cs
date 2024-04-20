using ConsoleApp1;

Persona persona = new Persona();
persona.Nombre = "Leonardo";
persona.ApellidoMaterno = "Escogido";
persona.ApellidoPaterno = "Bravo";

Persona persona1 = new Persona("leo","bravo","sanchez");

var lista = Persona.CrearLista();

lista.Add(persona);
lista.Add(persona1);

foreach(Persona persona3 in lista)
{
    Persona.Saludar(persona3);
}