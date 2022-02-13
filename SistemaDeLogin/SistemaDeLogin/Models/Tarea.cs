using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeLogin.Models
{
    public class Tarea
    {
        public int TareaID { get; set; }
        public string Descripcion { get; set; }
        public bool Realizada { get; set; }
        public string UserName { get; set; }
    }
}
