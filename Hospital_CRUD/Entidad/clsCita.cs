using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_CRUD
{
    internal class clsCita
    {
        public int Id_Cita { get; set; }
        public int Id_Consultorio { get; set; }
        public int Id_Servicios { get; set; }
        public int Id_Cedula { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
    }
}
