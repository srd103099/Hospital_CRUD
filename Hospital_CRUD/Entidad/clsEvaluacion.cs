using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_CRUD
{
    internal class clsEvaluacion
    {
        public int Id_Evaluacion {  get; set; }
        public int Id_Doctor { get; set; }
        public int Id_Cita { get; set; }
        public  int Calificacion_Profesional {  get; set; }
        public int Calificasion_Servicio { get; set; }
    }
}
