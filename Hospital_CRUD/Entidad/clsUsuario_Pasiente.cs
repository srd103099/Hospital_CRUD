using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_CRUD.Entidad
{
    internal class clsUsuario_Pasiente
    {
        //Atributos de la clase
        public int Id_Hospital {  get; set; }
        public int Id_Pasiente { get; set; }
        public string Usuario_Pasiente { get; set; }
        public string Contrasena { get; set; }
    }
}
