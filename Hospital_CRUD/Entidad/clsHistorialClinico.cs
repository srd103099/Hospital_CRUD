using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_CRUD.Entidad
{
    internal class clsHistorialClinico
    {
        public int Id_Historial { get; set; }
        public int Id_Cedula {  get; set; }
        public string Descripcion { get; set;}
    }
}
