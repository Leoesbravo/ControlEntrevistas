using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Recurso
    {
        public static ML.Result GetByIdUsuario(string idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.GestionControlEntrevistasEntities context = new DL.GestionControlEntrevistasEntities())
                {
                    var query = context.Recursoes.FirstOrDefault(u => u.IdUsuario == idUsuario);
                    if (query != null)
                    {
                        ML.Recurso recurso = new ML.Recurso();
                        recurso.IdRecurso = query.IdRecurso;

                        result.Object = recurso;
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
        public static ML.Result GetByEmail(string email)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.GestionControlEntrevistasEntities context = new DL.GestionControlEntrevistasEntities())
                {
                    var query = context.AspNetUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = query.Id;

                        result.Object = usuario;
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
        public static ML.Result Add(ML.Recurso recurso)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL.GestionControlEntrevistasEntities context = new DL.GestionControlEntrevistasEntities())
                {
                    var query = context.RecursoAdd(recurso.Usuario.IdUsuario, recurso.Generacion.IdGeneracion, recurso.Empresa.IdEmpresa,recurso.CURP);

                    if (query <= 0)
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
        public static ML.Result GetAll(int? idEmpresa, int? idGeneracion)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.GestionControlEntrevistasEntities context = new DL.GestionControlEntrevistasEntities())
                {
                    var query = context.RecursoGetAll(idGeneracion, idEmpresa).ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var obj in query)
                        {
                            ML.Recurso recurso = new ML.Recurso();
                            //recurso.IdRecurso = query.IdRecurso;
                            recurso.Usuario = new Usuario();
                            recurso.Usuario.Nombre = obj.Nombre;
                            recurso.Usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            recurso.Usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            recurso.Usuario.IdUsuario = obj.Id;
                            recurso.Usuario.Email = obj.Email;
                            recurso.Generacion = new ML.Generacion();
                            recurso.Generacion.Anio = obj.Anio;
                            recurso.Generacion.Nombre = obj.GeneracionNombre;
                            recurso.Generacion.Perfil = new Perfil();
                            recurso.Generacion.Perfil.Nombre = obj.Tipo;
                            recurso.Empresa = new ML.Empresa();
                            recurso.Empresa.IdEmpresa = obj.IdEmpresa;
                            recurso.Empresa.Nombre = obj.NombreEmpresa;
                            recurso.CURP = obj.CURP;
                            recurso.IdRecurso = obj.IdRecurso;

                            result.Objects.Add(recurso);
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
