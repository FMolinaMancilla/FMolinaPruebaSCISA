using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Cita
    {
        public int IdCita { get; set; }
        [DisplayName("Fecha Cita:")]
        public string Fecha { get; set; }
        [DisplayName("Fecha:")]
        public string Hora { get; set; }
        [DisplayName("Observaciones:")]
        public string Observaciones { get; set; }
        public List<object> Citas { get; set; }
        public ML.Doctor Doctor { get; set; }
        public ML.Paciente Paciente { get; set; }

    }
}
