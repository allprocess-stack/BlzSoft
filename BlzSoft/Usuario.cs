using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlzSoft
{
    public class Usuario
    {
        public Int32 id { get; set; }
        public String nombre { get; set; }
        public String user { get; set; }
        public String password { get; set; }
        public String tipo { get; set; }

        //variables asociadas al usuario actulmente registrado
        public static int IDlog;
        public static string NOMBRElog;
        public static string USERlog;
        public static string PASSWORDlog;
        public static string TIPOlog;

        //construsctor sin argumentos
        public Usuario() { }

        //Constructor con argumentos
        Usuario(Int32 id, String nombre, String user, String password, String tipo) 
        {
            this.id = id;
            this.nombre = nombre;
            this.user = nombre;
            this.password = password;
            this.tipo = tipo;
            
        }
    }
}
