using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BlzSoft
{
    class BDuser
    {
        public static DataTable login(String pUser, String pPass)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format(
                    "Select Id, Nombre, Usuario, Password, Tipo from Usuarios where usuario like '{0}' and Password like '{1}' ", pUser, pPass), conn);
                SqlDataAdapter sqldata = new SqlDataAdapter(cmd);
                sqldata.Fill(dt);
                conn.Close();
                return dt;                
            }
        }

        public static List<Usuario> Buscar()
        {
            List<Usuario> Lista = new List<Usuario>();
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format("Select * from Usuarios"), conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario p = new Usuario();
                    p.id = reader.GetInt32(0);
                    p.nombre = reader.GetString(1);
                    p.user = reader.GetString(2);
                    p.password = reader.GetString(3);
                    p.tipo = reader.GetString(4);
                                        
                    Lista.Add(p);
                }

                conn.Close();
                return Lista;

            }
        }

        public static int Add(string[] p)
        {
            int key = 0;
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                //carga base de datos con variables enviadas por datos de objeto alumno
                SqlCommand comando = new SqlCommand(string.Format("Insert Into Usuarios values('{0}','{1}','{2}','{3}') ", p[0], p[1], p[2], p[3]), conn);
                key = comando.ExecuteNonQuery();
            }
            return key;

        }

        public static Usuario Info(Int64 pId)
        {
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                Usuario p = new Usuario();
                SqlCommand cmd = new SqlCommand(string.Format(
                    "select * from Usuarios where Id={0}", pId), conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    p.id = reader.GetInt32(0);
                    p.nombre = reader.GetString(1);
                    p.user = reader.GetString(2);
                    p.password = reader.GetString(3);
                    p.tipo = reader.GetString(4);
                }

                conn.Close();
                return p;
            }
        }


        public static int Mod(int id, string[] p)
        {
            int key = 0;

            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                //carga base de datos con variables enviadas por datos de objeto alumno
                SqlCommand comando = new SqlCommand(string.Format("update Usuarios set Nombre='{0}',Usuario ='{1}',Password='{2}',Tipo='{3}'  where Id = {4};",
                                                        p[0],p[1],p[2],p[3],id), conn);
                key = comando.ExecuteNonQuery();
            }
            return key;
        }

        public static int Delete(int id)
        {
            int key = 0;

            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                //carga base de datos con variables enviadas por datos de objeto alumno
                SqlCommand comando = new SqlCommand(string.Format("delete from Usuarios where Id = {0}", id), conn);
                key = comando.ExecuteNonQuery();
            }
            return key;

        }

    }
}
