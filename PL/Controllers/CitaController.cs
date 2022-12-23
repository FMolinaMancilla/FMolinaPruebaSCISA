using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class CitaController : Controller
    {
        // GET: Cita
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Cita.GetAll();
            ML.Cita cita = new ML.Cita();
            if (result.Correct)
            {
                cita.Citas = result.Objects;

            }
            else
            {
                result.Correct = false;
            }
            return View(cita);
        }

        [HttpGet]
        public ActionResult Form(int? IdCita)
        {
            ML.Cita cita = new ML.Cita();
            cita.Doctor = new ML.Doctor();
            cita.Paciente = new ML.Paciente();

            ML.Result resultDoctor = BL.Doctor.GetAll();
            ML.Result resultPaciente = BL.Paciente.GetAll();

            if (IdCita == null)
            {
                cita.Doctor.Doctores = resultDoctor.Objects;
                cita.Paciente.Pacientes = resultPaciente.Objects;
                return View(cita);
            }
            else
            {
                ML.Result result = BL.Cita.GetById(IdCita.Value);
                cita = (ML.Cita)result.Object;

                cita.Doctor.Doctores = resultDoctor.Objects;
                cita.Paciente.Pacientes = resultPaciente.Objects;
                return View(cita);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Cita cita)
        {
            
            ML.Result result = new ML.Result();

            if (cita.IdCita == 0)
            {
                result = BL.Cita.Add(cita);
                if (result.Correct)
                {
                    ViewBag.Message = "Registro Exitoso";
                }
                else
                {
                    ViewBag.Message = "Error al registrar" + result.ErrorMessage;
                }
            }
            else
            {
                result = BL.Cita.Update(cita);
                if (result.Correct)
                {
                    ViewBag.Message = "Registro Actualizado";
                }
                else
                {
                    ViewBag.Message = "Error al actualizar" + result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }


        [HttpGet]
        public ActionResult Delete(ML.Cita cita)
        {
            ML.Result result = BL.Cita.Delete(cita);

            if (result.Correct)
            {
                ViewBag.Message = "¡Registro eliminado!";
            }
            else
            {
                ViewBag.Message = "¡No se elimino el registro!" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }

    }
}