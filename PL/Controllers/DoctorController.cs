using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Content
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Doctor.GetAll();
            ML.Doctor doctor = new ML.Doctor();

            if (result.Correct)
            {
                doctor.Doctores = result.Objects;
            }
            else
            {
                result.Correct = false;
            }
            return View(doctor);
        }

        [HttpGet]
        public ActionResult Form(int? IdDoctor)
        {
            ML.Doctor doctor = new ML.Doctor();

            doctor.Especialidad = new ML.Especialidad();
            ML.Result resultEsp = BL.Especialidad.GetAll();

            if (IdDoctor == null)
            {
                doctor.Especialidad.Especialidades = resultEsp.Objects;
                return View(doctor);
            }
            else
            {
                ML.Result result = BL.Doctor.GetById(IdDoctor.Value);
                doctor = (ML.Doctor)result.Object;

                doctor.Especialidad.Especialidades = resultEsp.Objects;

                return View(doctor);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Doctor doctor)
        {
        
            ML.Result result = new ML.Result();

            HttpPostedFileBase file = Request.Files["ImagenData"];
            if (file.ContentLength > 0)
            {
                doctor.Imagen = ConvertToBytes(file);
            }

            if (doctor.IdDoctor == 0)
            {
                result = BL.Doctor.Add(doctor);
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
                result = BL.Doctor.Update(doctor);
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
        public ActionResult Delete(ML.Doctor doctor)
        {
            ML.Result result = BL.Doctor.Delete(doctor);

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