using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Paciente
    {
        public static ML.Result Add(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaPruebaSCISAEntities context = new DL.FMolinaPruebaSCISAEntities())
                {
                    var query = context.PacienteAdd(paciente.Nombre, paciente.ApellidoPaterno, paciente.ApellidoMaterno, paciente.Sexo, paciente.NSS, paciente.Email, Encrypt.Encrypt.GetSHA256(paciente.Password), paciente.Telefono, paciente.Direccion, paciente.FechaNacimiento, paciente.Imagen);
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

        public static ML.Result Update(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaPruebaSCISAEntities context = new DL.FMolinaPruebaSCISAEntities())
                {
                    var query = context.PacienteUpdate(paciente.IdPaciente, paciente.Nombre, paciente.ApellidoPaterno, paciente.ApellidoMaterno, paciente.Sexo, paciente.NSS, paciente.Email, Encrypt.Encrypt.GetSHA256(paciente.Password), paciente.Telefono, paciente.Direccion, paciente.FechaNacimiento, paciente.Imagen);
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
                    var query = context.PacienteGetAll().ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Paciente paciente = new ML.Paciente();

                            paciente.IdPaciente = obj.IdPaciente;
                            paciente.Nombre = obj.Nombre;
                            paciente.ApellidoPaterno = obj.ApellidoPaterno;
                            paciente.ApellidoMaterno = obj.ApellidoMaterno;
                            paciente.Sexo = obj.Sexo;
                            paciente.NSS = obj.NSS;
                            paciente.Email = obj.Email;
                            paciente.Password = obj.Password;
                            paciente.Telefono = obj.Telefono;
                            paciente.Direccion = obj.Direccion;
                            paciente.FechaNacimiento = obj.FechaNacimiento.ToString("dd-MM-yyyy");
                            paciente.Imagen = obj.Imagen;
                            paciente.NombreCompleto = obj.Nombre + " " + obj.ApellidoPaterno + " " + obj.ApellidoMaterno;

                            result.Objects.Add(paciente);
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

        public static ML.Result GetById(int IdPaciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaPruebaSCISAEntities context = new DL.FMolinaPruebaSCISAEntities())
                {
                    var query = context.PacienteGetById(IdPaciente).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Paciente paciente = new ML.Paciente();

                        paciente.IdPaciente = query.IdPaciente;
                        paciente.Nombre = query.Nombre;
                        paciente.ApellidoPaterno = query.ApellidoPaterno;
                        paciente.ApellidoMaterno = query.ApellidoMaterno;
                        paciente.Sexo = query.Sexo;
                        paciente.NSS = query.NSS;
                        paciente.Email = query.Email;
                        paciente.Password = query.Password;
                        paciente.Telefono = query.Telefono;
                        paciente.Direccion = query.Direccion;
                        paciente.FechaNacimiento = query.FechaNacimiento.ToString("dd-MM-yyyy");
                        paciente.Imagen = query.Imagen;

                        result.Object = paciente;
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

        public static ML.Result Delete (ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaPruebaSCISAEntities context = new DL.FMolinaPruebaSCISAEntities())
                {
                    var query = context.PacienteDelete(paciente.IdPaciente);
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
