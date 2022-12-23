using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        [DisplayName("Nombre:")]
        public string Nombre { get; set; }
        [DisplayName("Apellido Paterno:")]
        public string ApellidoPaterno { get; set; }
        [DisplayName("Apellido Materno:")]
        public string ApellidoMaterno { get; set; }
        public string NombreCompleto { get; set; }
        [DisplayName("Sexo:")]
        public string Sexo { get; set; }
        [DisplayName("NSS: ")]
        public string NSS { get; set; }
        [DisplayName("Email:")]
        public string Email { get; set; }
        [DisplayName("Contraseña:")]
        public string Password { get; set; }
        [DisplayName("Telefono:")]
        public string Telefono { get; set; }
        [DisplayName("Direccion:")]
        public string Direccion { get; set; }
        [DisplayName("Fecha Nacimiento:")]
        public string FechaNacimiento { get; set; }
        [DisplayName("Fotografia:")]
        public byte[] Imagen { get; set; }
        public List<object> Pacientes { get; set; }
    }
}
