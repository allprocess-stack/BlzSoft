using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace BlzSoft
{
    class BDproductos
    {
        public static List<Producto> BuscarProductos(string name)
        {
            List<Producto> Lista = new List<Producto>();
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format("select * from Productos where Producto like '{0}'", name), conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producto p = new Producto();
                    p.id = reader.GetInt32(0);
                    p.producto = reader.GetString(1);
                    p.descripcion = reader.GetString(2);
                    Lista.Add(p);
                }

                conn.Close();
                return Lista;

            }
        }

        public static List<Producto> BuscarProductos(int id)
        {
            List<Producto> Lista = new List<Producto>();
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format("select * from Productos where Id = {0}", id), conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producto p = new Producto();
                    p.id = reader.GetInt32(0);
                    p.producto = reader.GetString(1);
                    p.descripcion = reader.GetString(2);
                    Lista.Add(p);
                }

                conn.Close();
                return Lista;

            }
        }

        public static List<Producto> BuscarProductos()
        {
            List<Producto> Lista = new List<Producto>();
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format("select * from Productos"), conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producto p = new Producto();
                    p.id = reader.GetInt32(0);
                    p.producto = reader.GetString(1);
                    p.descripcion = reader.GetString(2);
                    Lista.Add(p);
                }

                conn.Close();
                return Lista;

            }
        }

        public static List<string> ProductsList()
        {
            List<string> Lista = new List<string>();
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format("SELECT Producto FROM Productos"), conn);
                SqlDataReader reader = cmd.ExecuteReader();

                string item;
                while (reader.Read())
                {
                    item = reader.GetString(0);
                    Lista.Add(item);
                }

                conn.Close();
                return Lista;

            }
        }

        public static int AddProduct(string [] p)
        {
            int key = 0;
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                //carga base de datos con variables enviadas por datos de objeto alumno
                SqlCommand comando = new SqlCommand(string.Format("Insert Into Productos values('{0}','{1}') ",p[0], p[1]), conn);
                key = comando.ExecuteNonQuery();
            }
            return key;

        }

        public static Producto Info(Int64 pId)
        {
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                Producto p = new Producto();
                SqlCommand cmd = new SqlCommand(string.Format(
                    "select * from Productos where Id={0}", pId), conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    p.id = reader.GetInt32(0);
                    p.producto = reader.GetString(1);
                    p.descripcion = reader.GetString(2);                    
                }

                conn.Close();
                return p;
            }
        }

        public static int Mod(Producto p)
        {
            int key = 0;
            
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                //carga base de datos con variables enviadas por datos de objeto alumno
                SqlCommand comando = new SqlCommand(string.Format("exec edit_producto {0},'{1}','{2}';", p.id, p.producto, p.descripcion), conn);
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
                SqlCommand comando = new SqlCommand(string.Format("delete from Productos where Id = {0}", id), conn);
                key = comando.ExecuteNonQuery();
            }
            return key;

        }

    }
}
