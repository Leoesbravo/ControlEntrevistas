﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Historico
    {
        public static ML.Result Add(ML.Proceso proceso)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.GestionControlEntrevistasEntities context = new DL.GestionControlEntrevistasEntities())
                {
                    var query = context.HistoricoAdd(proceso.Historico.Filtro.IdFiltro,proceso.IdProceso,proceso.Historico.Detalle, proceso.Estatus.IdEstatus);

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
    }
}
