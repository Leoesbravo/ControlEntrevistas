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
    }
}
