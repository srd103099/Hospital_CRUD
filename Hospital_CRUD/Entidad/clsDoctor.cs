using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_CRUD
{
    internal class clsDoctor
    {
        public int Id_Doctor { get; set; }
        public int Id_UsuarioDoctor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Especialidad { get; set; }
        public int Id_Consultorio { get; set; }

      
    }
}
