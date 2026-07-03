using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlzSoft
{
    public class Empresa
    {
        //variable con propiedades avanzadas de clase
        public Int32 id { get; set; }
        public String tipo { get; set; }
        public String subtipo { get; set; }
        public String empresa { get; set; }
        public String ruc { get; set; }
        public String dirreccion { get; set; }
        public String telefono { get; set; }
        public String contacto { get; set; }
        public String correo { get; set; }
        public String informacion { get; set; }
        public String fechacreacion { get; set; }
        public String usuario { get; set; }

        //construsctor sin argumentos
        public Empresa() { }

        //Constructor con argumentos
        Empresa(Int32 id, String tipo, String subtipo, String empresa, String ruc, String dirreccion, String telefono, String contacto, String correo, String informacion, String fechacreacion, String usuario)
        {
            this.id = id;
            this.tipo = tipo;
            this.subtipo = subtipo;
            this.empresa = empresa;
            this.ruc = ruc;
            this.dirreccion = dirreccion;
            this.telefono = telefono;
            this.contacto= contacto;
            this.correo= correo;
            this.informacion= informacion;
            this.fechacreacion= fechacreacion;
            this.usuario= usuario;
            

        }
    }
}
