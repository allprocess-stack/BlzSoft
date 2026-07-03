using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace BlzSoft
{
    class BDconnection
    {
        //metodo que opera como funcion de inicializacion de conexion
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conn = new SqlConnection();
            ConnFile.Load();
            conn.ConnectionString =
            "Data Source= " + ConnFile.SERVIDOR +               //nombre de servidor
            ";Initial Catalog=" + ConnFile.BD +                 //nombre de la base de datos 
            ";User Id=" + ConnFile.userAccess +                                    //";Integrated Security=True;" cuando no se usa contraseña                 
            ";Password=" + ConnFile.password + ";";
            conn.Open();
            return conn;
        }
    }
}







