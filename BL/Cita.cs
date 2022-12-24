using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Cita
    {
        public static ML.Result Add(ML.Cita cita)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaPruebaSCISAEntities context = new DL.FMolinaPruebaSCISAEntities())
                {
                    var query = context.AgendarCita(cita.Doctor.IdDoctor, cita.Paciente.IdPaciente,cita.Fecha, cita.Observaciones, cita.Hora);
                    if (query > 0)
                    {
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
        public static ML.Result Update(ML.Cita cita)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaPruebaSCISAEntities context = new DL.FMolinaPruebaSCISAEntities())
                {
                    var query = context.UpdateCita(cita.IdCita, cita.Doctor.IdDoctor, cita.Paciente.IdPaciente, cita.Fecha, cita.Observaciones, cita.Hora);
                    if (query > 0)
                    {
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaPruebaSCISAEntities context = new DL.FMolinaPruebaSCISAEntities())
                {
                    var query = context.CitaGetAll().ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Cita cita = new ML.Cita();

                            cita.IdCita = obj.IdCita;
                           

                            cita.Doctor = new ML.Doctor();
                            cita.Doctor.IdDoctor = obj.IdDoctor;
                            cita.Doctor.Nombre = obj.DoctorNombre;
                            cita.Doctor.ApellidoPaterno = obj.DoctorAP;
                            cita.Doctor.ApellidoMaterno = obj.DoctorAM;


                            cita.Paciente = new ML.Paciente();

                            cita.Paciente.IdPaciente = obj.IdPaciente;
                            cita.Paciente.Nombre = obj.PacienteNombre;
                            cita.Paciente.ApellidoPaterno = obj.PacienteAP;
                            cita.Paciente.ApellidoMaterno = obj.PacienteAM;



                            cita.Fecha = obj.Fecha.ToString("dd-MM-yyyy");

                            cita.Observaciones = obj.Observaciones;

                            cita.Hora = obj.Hora.ToString();

                            result.Objects.Add(cita);
                            result.Correct = true;
                        }
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
        public static ML.Result GetById(int IdCita)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaPruebaSCISAEntities context = new DL.FMolinaPruebaSCISAEntities())
                {
                    var query = context.CitaGetById(IdCita).FirstOrDefault();
                    if (query != null)
                    {
                        ML.Cita cita = new ML.Cita();


                        cita.IdCita = query.IdCita;
                        

                        cita.Doctor = new ML.Doctor();
                        cita.Doctor.IdDoctor = query.IdDoctor;
                        cita.Doctor.Nombre = query.DoctorNombre;
                        cita.Doctor.ApellidoPaterno = query.DoctorAP;
                        cita.Doctor.ApellidoMaterno = query.DoctorAM;

                       

                        cita.Paciente = new ML.Paciente();
                        cita.Paciente.IdPaciente = query.IdPaciente;
                        cita.Paciente.Nombre = query.PacienteNombre;
                        cita.Paciente.ApellidoPaterno = query.PacienteAP;
                        cita.Paciente.ApellidoMaterno = query.PacienteAM;

                        cita.Fecha = query.Fecha.ToString("dd-MM-yyyy");
                        cita.Hora = query.Hora.ToString();


                        cita.Observaciones = query.Observaciones;
                        result.Object = cita;
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

        public static ML.Result Delete(ML.Cita cita)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaPruebaSCISAEntities context = new DL.FMolinaPruebaSCISAEntities())
                {
                    var query = context.DeleteCita(cita.IdCita);
                    if (query > 0)
                    {
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
