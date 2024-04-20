//Para poder acceder a  atributos y metodos de una clase
//lo hacemos a traves de objetos(instancias)

using ConsoleApp2;

//crear un objeto
Persona persona = new Persona();

persona.Saludar();

//Cuando uso static, puedo acceder al metodo sin necesidad de un objeto

Persona.Saludar();