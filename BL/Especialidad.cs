using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Especialidad
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaPruebaSCISAEntities context = new DL.FMolinaPruebaSCISAEntities())
                {
                    var query = context.EspecialidadGetAll().ToList();
                    result.Objects = new List<object>();
                    if(query != null)
                    {
                        foreach(var obj in query)
                        {
                            ML.Especialidad especialidad = new ML.Especialidad();

                            especialidad.IdEspecialidad = obj.IdEspecialidad;
                            especialidad.Nombre = obj.Nombre;

                            result.Objects.Add(especialidad);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false; 
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
