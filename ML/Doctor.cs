using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Doctor
    {
        public int IdDoctor { get; set; }
        [DisplayName("Nombre:")]
        public string Nombre { get; set; }
        [DisplayName("Apellido Paterno:")]
        public string ApellidoPaterno { get; set; }
        [DisplayName("Apellido Materno:")]
        public string ApellidoMaterno { get; set; }
        [DisplayName("Sexo:")]
        public string Sexo { get; set; }
        [DisplayName("Email:")]
        public string Email { get; set; }
        [DisplayName("Contraseña:")]
        public string Password { get; set; }
        [DisplayName("Telefono:")]

        [StringLength(10)]
        public string Telefono { get; set; }
        [DisplayName("Especialidad:")]
        public int IdEspecialidad { get; set; }

        [DisplayName("Fotografia:")]
        public byte[] Imagen { get; set; }
        public List<object> Doctores { get; set; }
        public ML.Especialidad Especialidad { get; set; }
        public string NombreCompleto { get; set; }
    }
}
