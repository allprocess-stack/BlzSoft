using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlzSoft
{
    public class Producto            
    {
        //variable con propiedades avanzadas de clase
        public Int32 id { get; set; }
        public String producto { get; set; }
        public String descripcion { get; set; }
        
        //construsctor sin argumentos
        public Producto() { }

    }
}
