using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_CRUD
{
    internal class clsConsultorio
    {
       public int Id_Consultorio { get; set; }
       public int Id_Hospital { get; set; }
       public string Nombre { get; set; }
       public string Disponibilidad { get; set; }
    }
}
