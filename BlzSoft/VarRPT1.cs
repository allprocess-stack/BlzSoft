using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlzSoft
{
    //variables  a mostrar en reporte de clientes
    public class VarRPT1
    {
        public Int32 numRegistros { get; set; }
        public String Fecha { get; set; }
        public String Usuario { get; set; }
        public String Tipo { get; set; }

        //construsctor sin argumentos
        public VarRPT1() { }

        /*
        //Constructor con argumentos
        VRptCliente(Int32 registros, String fecha)
        {
            this.numRegistros = registros;
            this.Fecha = fecha;
            
        }
        */
    }
}
