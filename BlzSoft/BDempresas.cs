using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BlzSoft
{
    class BDempresas
    {
        public static List<Empresa> BuscarEmpresas(String tipo, String subtipo, String empresa, String ruc)
        {
            List<Empresa> Lista = new List<Empresa>();
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format("exec search_empresas '{0}' , '{1}' , '{2}' , '{3}' ;",tipo,subtipo,empresa,ruc), conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Empresa p = new Empresa();
                    p.id = reader.GetInt32(0);
                    p.tipo = reader.GetString(1);
                    p.subtipo = reader.GetString(2);
                    p.empresa = reader.GetString(3);
                    p.ruc = reader.GetString(4);
                    p.dirreccion = reader.GetString(5);
                    p.telefono = reader.GetString(6);
                    p.contacto = reader.GetString(7);
                    p.correo = reader.GetString(8);
                    p.informacion = reader.GetString(9);
                    p.fechacreacion = Convert.ToString(reader.GetDateTime(10));
                    p.usuario = reader.GetString(11);
                    Lista.Add(p);
                }

                conn.Close();
                return Lista;

            }
        }
        
        public static List<string> ClientList()
        {
            List<string> Lista = new List<string>();
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format("SELECT Empresa  FROM Empresas"), conn);
                SqlDataReader reader = cmd.ExecuteReader();

                string item;
                Lista.Add(" ");
                while (reader.Read())
                {
                    item = reader.GetString(0);
                    Lista.Add(item);
                }

                conn.Close();
                return Lista;

            }
        } 

        public static List<int> IdList()
        {
            List<int> Lista = new List<int>();
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format("SELECT Id  FROM Empresas"), conn);
                SqlDataReader reader = cmd.ExecuteReader();

                int count;
                while (reader.Read())
                {
                    count = reader.GetInt32(0);
                    Lista.Add(count);
                }

                conn.Close();
                return Lista;

            }


        }

        public static int AddEmpresa(Empresa p)
        {
            int key = 0;
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                //carga base de datos con variables enviadas por datos de objeto alumno
                SqlCommand comando = new SqlCommand(string.Format("Insert Into Empresas values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}') ",
                    p.tipo, p.subtipo, p.empresa, p.ruc, p.dirreccion, p.telefono, p.contacto, p.correo, p.informacion, sqlFormattedDate, p.usuario ), conn);
                key= comando.ExecuteNonQuery();
            }
            return key;
                        
        }

        public static int ModEmpresa(Empresa p)
        {
            int key = 0;
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                //carga base de datos con variables enviadas por datos de objeto alumno
                SqlCommand comando = new SqlCommand(string.Format("exec edit_empresa {0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}' ;",
                    p.id,p.tipo, p.subtipo, p.empresa, p.ruc, p.dirreccion, p.telefono, p.contacto, p.correo, p.informacion, sqlFormattedDate, p.usuario), conn);
                key = comando.ExecuteNonQuery();
            }
            return key;

        }

        public static int DeleteEmpresa(int id)
        {
            int key = 0;
            
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                //carga base de datos con variables enviadas por datos de objeto alumno
                SqlCommand comando = new SqlCommand(string.Format("delete from Empresas where Id = {0}",id), conn);
                key = comando.ExecuteNonQuery();
            }
            return key;

        }

        public static Empresa InfoEmpresa(Int64 pId)
        {
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                Empresa p = new Empresa();
                SqlCommand cmd = new SqlCommand(string.Format(
                    "select * from Empresas where Id={0}", pId), conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    p.id = reader.GetInt32(0);
                    p.tipo = reader.GetString(1);
                    p.subtipo = reader.GetString(2);
                    p.empresa = reader.GetString(3);
                    p.ruc = reader.GetString(4);
                    p.dirreccion = reader.GetString(5);
                    p.telefono = reader.GetString(6);
                    p.contacto = reader.GetString(7);
                    p.correo = reader.GetString(8);
                    p.informacion = reader.GetString(9);
                    p.fechacreacion = Convert.ToString(reader.GetDateTime(10));
                    p.usuario = reader.GetString(11);
                }

                conn.Close();
                return p;
            }
        }

        public static Empresa InfoEmpresa(string cliente)
        {
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                Empresa p = new Empresa();
                SqlCommand cmd = new SqlCommand(string.Format(
                    "select * from Empresas where Empresa like '{0}' ", cliente), conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    p.id = reader.GetInt32(0);
                    p.tipo = reader.GetString(1);
                    p.subtipo = reader.GetString(2);
                    p.empresa = reader.GetString(3);
                    p.ruc = reader.GetString(4);
                    p.dirreccion = reader.GetString(5);
                    p.telefono = reader.GetString(6);
                    p.contacto = reader.GetString(7);
                    p.correo = reader.GetString(8);
                    p.informacion = reader.GetString(9);
                    p.fechacreacion = Convert.ToString(reader.GetDateTime(10));
                    p.usuario = reader.GetString(11);
                }

                conn.Close();
                return p;
            }
        }

        public static string LastId()
        {
            string idlast;

            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format("SELECT TOP 1 Id FROM Empresas ORDER BY Id DESC"), conn);

                try
                { idlast = cmd.ExecuteScalar().ToString(); }
                catch
                { idlast = "0"; }

                conn.Close();
                return idlast;
            }

        }

        public static string Client(int id)
        {
            string nameClient;

            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format("SELECT Empresa FROM Empresas WHERE Id = {0}",id), conn);

                nameClient = cmd.ExecuteScalar().ToString();

                conn.Close();
                return nameClient;
            }           

        }

    }
}
