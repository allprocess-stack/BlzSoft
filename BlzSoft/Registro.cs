using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlzSoft
{
    public class Registro
    {
        public Int32 Id { get; set; }
        public String Guia { get; set; }
        public String Estado { get; set; }
        public String Placa { get; set; }
        public String Cliente { get; set; }
        public String Ruc { get; set; }
        public String Chofer { get; set; }        
        public String Producto { get; set; }
        public String Origen { get; set; }
        public String Destino { get; set; }
        public String GuiaRemision { get; set; }
        public String PesoIn { get; set; }
        public String PesoOut { get; set; }
        public String PesoNeto { get; set; }        
        public String Modo { get; set; }
        public String Observacion { get; set; }
        public String FechaEntrada { get; set; }
        public String FechaSalida { get; set; }
        public String Usuario { get; set; }
        public String RutaFotoEntrada { get; set; }
        public String RutaFotoSalida { get; set; }

        public Registro() { }
    }
}
