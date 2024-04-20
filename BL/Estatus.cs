using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estatus
    {
       public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.GestionControlEntrevistasEntities context = new DL.GestionControlEntrevistasEntities())
                {
                    var query = context.Estatus.ToList();
                    if(query.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Estatus estatus = new ML.Estatus();
                            estatus.IdEstatus = item.IdEstatus;
                            estatus.Descripcion = item.Descripcion;

                            result.Objects.Add(estatus);
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
