using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Generacion
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.GestionControlEntrevistasEntities context = new DL.GestionControlEntrevistasEntities())
                {
                    var query = (from g in context.Generacions
                                 join p in context.Perfils on g.IdPerfil equals p.IdPerfil
                                 select new
                                 {
                                     g.IdGeneracion,
                                     g.Nombre,
                                     g.Anio,
                                     NombrePerfil = p.Tipo,
                                     IdPefil = p.IdPerfil
                                 }).ToList();
                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Generacion generacion = new ML.Generacion();
                            generacion.IdGeneracion = item.IdGeneracion;
                            generacion.Nombre = item.Nombre;
                            generacion.Anio = item.Anio;
                            generacion.Perfil = new ML.Perfil();
                            generacion.Perfil.IdPerfil = item.IdPefil;
                            generacion.Perfil.Nombre = item.NombrePerfil;
                            generacion.NombreCompleto =  item.Nombre + " "+ item.NombrePerfil + " " + item.Anio;

                            result.Objects.Add(generacion);
                        }
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Exception = e;
            }
            return result;
        }
    }
}
