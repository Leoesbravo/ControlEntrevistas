using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Proceso
    {
        public static ML.Result GetAllByIdRecurso(int idRecurso)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.GestionControlEntrevistasEntities context = new DL.GestionControlEntrevistasEntities())
                {
                    var query = context.ProcesoGetAllByIdRecurso(idRecurso).ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Proceso proceso = new ML.Proceso();

                            proceso.IdProceso = obj.IdProceso;
                            proceso.Empresa = obj.Empresa;
                            proceso.FechaContacto = obj.FechaContacto.Value.ToString("dd-mm-yyyy");
                            proceso.Postulado = obj.Postulado.Value;
                            proceso.Cliente = obj.Cliente;
                            proceso.LigaVacante = obj.LigaVacante;
                            proceso.NumeroContacto = obj.NumeroContacto;

                            proceso.Estatus = new ML.Estatus();
                            proceso.Estatus.IdEstatus = obj.IdEstatus.Value;
                            proceso.Estatus.Descripcion = obj.Descripcion;

                            proceso.BolsaTrabajo = new ML.BolsaTrabajo();
                            proceso.BolsaTrabajo.IdBolsaTrabajo = obj.IdBolsaTrabajo.Value;
                            proceso.BolsaTrabajo.Medio = obj.BolsaNombre;

                            proceso.Recurso = new ML.Recurso();
                            proceso.Recurso.IdRecurso = obj.IdRecurso.Value;

                            result.Objects.Add(proceso);
                        }
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
        public static ML.Result Add(ML.Proceso proceso)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.GestionControlEntrevistasEntities context = new DL.GestionControlEntrevistasEntities())
                {
                    var query = context.ProcesoAdd(proceso.Estatus.IdEstatus, proceso.BolsaTrabajo.IdBolsaTrabajo, proceso.NumeroContacto, proceso.Empresa, proceso.Cliente, proceso.LigaVacante, proceso.Postulado, DateTime.Parse(proceso.FechaContacto), proceso.Recurso.IdRecurso);

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
        public static ML.Result UpdateProceso(ML.Proceso proceso)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.GestionControlEntrevistasEntities context = new DL.GestionControlEntrevistasEntities())
                {
                    var query = context.ProcesoAdd(proceso.Estatus.IdEstatus, proceso.BolsaTrabajo.IdBolsaTrabajo, proceso.NumeroContacto, proceso.Empresa, proceso.Cliente, proceso.LigaVacante, proceso.Postulado, DateTime.Parse(proceso.FechaContacto), proceso.Recurso.IdRecurso);

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
        public static ML.Result GetById(int idProceso)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.GestionControlEntrevistasEntities context = new DL.GestionControlEntrevistasEntities())
                {
                    var obj = context.ProcesoGetById(idProceso).FirstOrDefault();

                    if (obj != null)
                    {

                        ML.Proceso proceso = new ML.Proceso();

                        proceso.IdProceso = obj.IdProceso;
                        proceso.Empresa = obj.Empresa;
                        proceso.FechaContacto = obj.FechaContacto.Value.ToString("dd-mm-yyyy");
                        proceso.Postulado = obj.Postulado.Value;
                        proceso.Cliente = obj.Cliente;
                        proceso.LigaVacante = obj.LigaVacante;
                        proceso.NumeroContacto = obj.NumeroContacto;

                        proceso.Estatus = new ML.Estatus();
                        proceso.Estatus.IdEstatus = obj.IdEstatus.Value;

                        proceso.BolsaTrabajo = new ML.BolsaTrabajo();
                        proceso.BolsaTrabajo.IdBolsaTrabajo = obj.IdBolsaTrabajo.Value;

                        proceso.Recurso = new ML.Recurso();
                        proceso.Recurso.IdRecurso = obj.IdRecurso.Value;

                        result.Object = proceso;
                        result.Correct = true;
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
