using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class PacienteController : Controller
    {
        // GET: Paciente
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Paciente.GetAll();
            ML.Paciente paciente = new ML.Paciente();

            if (result.Correct)
            {
                paciente.Pacientes = result.Objects;
            }
            else
            {
                result.Correct = false;
            }

            return View(paciente);
        }

        [HttpGet]
        public ActionResult Form(int? IdPaciente)
        {
            ML.Paciente paciente = new ML.Paciente();

            if (IdPaciente == null)
            {
                return View(paciente);
            }
            else
            {
                ML.Result result = BL.Paciente.GetById(IdPaciente.Value);
                paciente = (ML.Paciente)result.Object;

                return View(paciente);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Paciente paciente)
        {

            ML.Result result = new ML.Result();

            HttpPostedFileBase file = Request.Files["ImagenData"];
            if (file.ContentLength > 0)
            {
                paciente.Imagen = ConvertToBytes(file);
            }

            if (paciente.IdPaciente == 0)
            {
                result = BL.Paciente.Add(paciente);
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
                result = BL.Paciente.Update(paciente);
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
        public ActionResult Delete(ML.Paciente paciente)
        {
            ML.Result result = BL.Paciente.Delete(paciente);

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

        //Metodo para convertir imagen
        public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            data = reader.ReadBytes((int)Imagen.ContentLength);

            return data;
        }
    }
}