using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Doctor
    {
        public static ML.Result Add(ML.Doctor doctor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaPruebaSCISAEntities context = new DL.FMolinaPruebaSCISAEntities())
                {
                    var query = context.DoctorAdd(doctor.Nombre, doctor.ApellidoPaterno, doctor.ApellidoMaterno, doctor.Sexo, doctor.Email, Encrypt.Encrypt.GetSHA256(doctor.Password), doctor.Telefono, doctor.Especialidad.IdEspecialidad, doctor.Imagen);
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

        public static ML.Result Update(ML.Doctor doctor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaPruebaSCISAEntities context = new DL.FMolinaPruebaSCISAEntities())
                {
                    var query = context.DoctorUpdate(doctor.IdDoctor, doctor.Nombre, doctor.ApellidoPaterno, doctor.ApellidoMaterno, doctor.Sexo, doctor.Email, Encrypt.Encrypt.GetSHA256(doctor.Password), doctor.Telefono, doctor.Especialidad.IdEspecialidad, doctor.Imagen);
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
                    var query = context.DoctorGetAll().ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Doctor doctor = new ML.Doctor();

                            doctor.IdDoctor = obj.IdDoctor;
                            doctor.Nombre = obj.DoctorNombre;
                            doctor.ApellidoPaterno = obj.ApellidoPaterno;
                            doctor.ApellidoMaterno = obj.ApellidoMaterno;
                            doctor.Sexo = obj.Sexo;
                            doctor.Email = obj.Email;
                            doctor.Password =obj.Password;
                            doctor.Telefono = obj.Telefono;

                            doctor.Especialidad = new ML.Especialidad();
                            doctor.Especialidad.IdEspecialidad = obj.IdEspecialidad;
                            doctor.Especialidad.Nombre = obj.EspecialidadNombre;

                            doctor.Imagen = obj.Imagen;

                            doctor.NombreCompleto = obj.DoctorNombre + " " + obj.ApellidoPaterno + " " + obj.ApellidoMaterno;


                            result.Objects.Add(doctor);
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

        public static ML.Result GetById(int IdDoctor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaPruebaSCISAEntities context = new DL.FMolinaPruebaSCISAEntities())
                {
                    var query = context.DoctorGetById(IdDoctor).FirstOrDefault();
                    if (query != null)
                    {

                        ML.Doctor doctor = new ML.Doctor();

                        doctor.IdDoctor = query.IdDoctor;
                        doctor.Nombre = query.DoctorNombre;
                        doctor.ApellidoPaterno = query.ApellidoPaterno;
                        doctor.ApellidoMaterno = query.ApellidoMaterno;
                        doctor.Sexo = query.Sexo;
                        doctor.Email = query.Email;
                        doctor.Password = query.Password;
                        doctor.Telefono = query.Telefono;

                        doctor.Especialidad = new ML.Especialidad();
                        doctor.Especialidad.IdEspecialidad = query.IdEspecialidad;
                        doctor.Especialidad.Nombre = query.EspecialidadNombre;

                        doctor.Imagen = query.Imagen;

                        result.Object = doctor;
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

        public static ML.Result Delete(ML.Doctor doctor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaPruebaSCISAEntities context = new DL.FMolinaPruebaSCISAEntities())
                {
                    var query = context.DoctorDelete(doctor.IdDoctor);
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

        public static ML.Result GetByEmail(string email)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaPruebaSCISAEntities context = new DL.FMolinaPruebaSCISAEntities())
                {
                    var query = context.GetByEmail(email).FirstOrDefault();
                    if (query != null)
                    {
                        ML.Doctor doctor = new ML.Doctor();

                        doctor.Email = query.Email;
                        doctor.Password = Encrypt.Encrypt.GetSHA256(query.Password);

                        result.Object = doctor;
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
