using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BlzSoft
{
    class BDregistros
    {
        public static List<Registro> readList(SqlDataReader reader)
        {
            List<Registro> Lista = new List<Registro>();

            while (reader.Read())
            {
                Registro p = new Registro();

                p.Id = reader.GetInt32(0);
                p.Guia = reader.IsDBNull(1) ? "" : reader.GetString(1);
                p.Estado = reader.IsDBNull(2) ? "" : reader.GetString(2);
                p.Placa = reader.IsDBNull(3) ? "" : reader.GetString(3);
                p.Cliente = reader.IsDBNull(4) ? "" : reader.GetString(4);
                p.Ruc = reader.IsDBNull(5) ? "" : reader.GetString(5);
                p.Chofer = reader.IsDBNull(6) ? "" : reader.GetString(6);
                p.Producto = reader.IsDBNull(7) ? "" : reader.GetString(7);
p.Origen = reader.IsDBNull(8) ? "" : reader.GetString(8);
                p.Destino = reader.IsDBNull(9) ? "" : reader.GetString(9);
                p.GuiaRemision = reader.IsDBNull(10) ? "" : reader.GetString(10);
                p.PesoIn = reader.IsDBNull(11) ? "" : reader.GetString(11);
                p.PesoOut = reader.IsDBNull(12) ? "" : reader.GetString(12);
                p.PesoNeto = reader.IsDBNull(13) ? "" : reader.GetString(13);
                p.Modo = reader.IsDBNull(14) ? "" : reader.GetString(14);
                p.Observacion = reader.IsDBNull(15) ? "" : reader.GetString(15);
                if (reader.IsDBNull(16))
                { p.FechaEntrada = ""; }
                else
                { p.FechaEntrada = Convert.ToString(reader.GetValue(16)); }
                if (reader.IsDBNull(17))
                { p.FechaSalida = ""; }
                else
                {
                    string temp = Convert.ToString(reader.GetValue(17));
                    if (temp.StartsWith("1900"))
                    { p.FechaSalida = "---"; }
                    else
                    { p.FechaSalida = temp; }
                }
                p.Usuario = reader.IsDBNull(18) ? "" : reader.GetString(18);
                p.RutaFotoEntrada = reader.IsDBNull(19) ? "" : reader.GetString(19);
                p.RutaFotoSalida = reader.IsDBNull(20) ? "" : reader.GetString(20);

                Lista.Add(p);
            }

            return Lista;

        }

        public static Registro readRegistro(SqlDataReader reader)
        {
            Registro p = new Registro();

            while (reader.Read())
            {
                p.Id = reader.GetInt32(0);
                p.Guia = reader.IsDBNull(1) ? "" : reader.GetString(1);
                p.Estado = reader.IsDBNull(2) ? "" : reader.GetString(2);
                p.Placa = reader.IsDBNull(3) ? "" : reader.GetString(3);
                p.Cliente = reader.IsDBNull(4) ? "" : reader.GetString(4);
                p.Ruc = reader.IsDBNull(5) ? "" : reader.GetString(5);
                p.Chofer = reader.IsDBNull(6) ? "" : reader.GetString(6);
                p.Producto = reader.IsDBNull(7) ? "" : reader.GetString(7);
                p.Origen = reader.IsDBNull(8) ? "" : reader.GetString(8);
                p.Destino = reader.IsDBNull(9) ? "" : reader.GetString(9);
                p.GuiaRemision = reader.IsDBNull(10) ? "" : reader.GetString(10);
                p.PesoIn = reader.IsDBNull(11) ? "" : reader.GetString(11);
                p.PesoOut = reader.IsDBNull(12) ? "" : reader.GetString(12);
                p.PesoNeto = reader.IsDBNull(13) ? "" : reader.GetString(13);
                p.Modo = reader.IsDBNull(14) ? "" : reader.GetString(14);
                p.Observacion = reader.IsDBNull(15) ? "" : reader.GetString(15);
                if (reader.IsDBNull(16))
                { p.FechaEntrada = ""; }
                else
                { p.FechaEntrada = Convert.ToString(reader.GetValue(16)); }
                if (reader.IsDBNull(17))
                { p.FechaSalida = ""; }
                else
                {
                    string temp = Convert.ToString(reader.GetValue(17));
                    if (temp.StartsWith("1900"))
                    { p.FechaSalida = "---"; }
                    else
                    { p.FechaSalida = temp; }
                }

                p.Usuario = reader.IsDBNull(18) ? "" : reader.GetString(18);
                p.RutaFotoEntrada = reader.IsDBNull(19) ? "" : reader.GetString(19);
                p.RutaFotoSalida = reader.IsDBNull(20) ? "" : reader.GetString(20);
            }

            return p;

        }

        public static List<Registro> Buscar(String cliente, String placa)
        {
            List<Registro> Lista = new List<Registro>();
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format("select * from Registros where Cliente like '{0}' and Placa like '{1}' ;", cliente, placa), conn);
                SqlDataReader reader = cmd.ExecuteReader();                               

                Lista = readList(reader);

                conn.Close();
                return Lista;

            }
        }

        public static List<Registro> Buscar(String cliente, String placa, String estado)
        {
            List<Registro> Lista = new List<Registro>();
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format("select * from Registros where Cliente like '{0}' and Placa like '{1}' and Estado like '{2}'; ", cliente, placa, estado), conn);
                SqlDataReader reader = cmd.ExecuteReader();

                Lista = readList(reader);

                conn.Close();
                return Lista;

            }
        }

        public static List<Registro> Buscar(String cliente, String placa, String estado, DateTime fechaInferior, DateTime fechaSuperior, Int16 evento )
        {
            List<Registro> Lista = new List<Registro>();
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                string fi, fo;
                fi = Convert.ToDateTime(fechaInferior).ToString("yyyy-MM-dd");
                fo = Convert.ToDateTime(fechaSuperior).ToString("yyyy-MM-dd");
                fo = fo + " 23:59:59.999";

                SqlCommand cmd = new SqlCommand(string.Format("exec search_registro_interval '{0}' , '{1}' , '{2}' , '{3}' , '{4}' , {5};", cliente, placa, estado, fi, fo, evento ), conn);
                SqlDataReader reader = cmd.ExecuteReader();

                Lista = readList(reader);

                conn.Close();
                return Lista;

            }
        }

        public static int AddRE(Registro p)
        {
            int key = 0;

            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand comando = new SqlCommand(string.Format(
                    "Insert into Registros (Guia, Estado, Placa, Cliente, Ruc, Chofer, Producto, Origen, Destino, GuiaRemision, PesoIn, PesoOut, PesoNeto, Modo, Observacion, FechaEntrada, FechaSalida, Usuario, RutaFotoEntrada, RutaFotoSalida) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}')",
                    p.Guia, p.Estado, p.Placa, p.Cliente, p.Ruc, p.Chofer, p.Producto, p.Origen, p.Destino, p.GuiaRemision, p.PesoIn, p.PesoOut, p.PesoNeto, p.Modo, p.Observacion, p.FechaEntrada, p.FechaSalida, p.Usuario, p.RutaFotoEntrada, p.RutaFotoSalida),
                    conn);
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
                SqlCommand comando = new SqlCommand(string.Format("delete from Registros where Id = {0}", id), conn);
                key = comando.ExecuteNonQuery();
            }
            return key;

        }

        public static Registro Info(Int64 pId)
        {
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                Registro p = new Registro();
                SqlCommand cmd = new SqlCommand(string.Format(
                    "select * from Registros where Id={0}", pId), conn);
                SqlDataReader reader = cmd.ExecuteReader();

                p = readRegistro(reader);

                conn.Close();
                return p;
            }
        }

        public static Registro LastCheckIn(String placa)
        {
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                Registro p = new Registro();
                SqlCommand cmd = new SqlCommand(string.Format(
                    "select TOP 1 * from Registros Where Placa = '{0}'  and Estado = 'ENTRADA'  ORDER BY Id DESC", placa), conn);
                SqlDataReader reader = cmd.ExecuteReader();                               

                p = readRegistro(reader);

                conn.Close();
                return p;
            }
        }
                
        public static int Mod(Registro p)
        {
            int key = 0;
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                //carga base de datos con variables enviadas por datos de objeto alumno
                SqlCommand comando = new SqlCommand(string.Format(
                    "UPDATE Registros SET " +
                    "Guia = '{0}', Estado = '{1}', Placa = '{2}', Cliente = '{3}', Ruc = '{4}', Chofer = '{5}', Producto = '{6}', Origen = '{7}', Destino = '{8}', GuiaRemision = '{9}', PesoIn = '{10}', PesoOut = '{11}', PesoNeto = '{12}', Modo = '{13}', Observacion = '{14}', FechaEntrada = '{15}', FechaSalida = '{16}', Usuario = '{17}', RutaFotoEntrada = '{18}', RutaFotoSalida = '{19}' " +
                    "WHERE Id={20};",                    
                    p.Guia, p.Estado, p.Placa, p.Cliente, p.Ruc, p.Chofer, p.Producto, p.Origen, p.Destino, p.GuiaRemision, p.PesoIn, p.PesoOut, p.PesoNeto, p.Modo, p.Observacion, Convert.ToDateTime(p.FechaEntrada).ToString("yyyy-MM-dd HH:mm:ss.fff"), Convert.ToDateTime(p.FechaSalida).ToString("yyyy-MM-dd HH:mm:ss.fff"), p.Usuario, p.RutaFotoEntrada, p.RutaFotoSalida,
                    p.Id), conn);
                                    
                key = comando.ExecuteNonQuery();
            }
            return key;

        }

        public static List <string> IDlist()
        {
            List<string> Lista = new List<string> () ;

            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                //carga base de datos con variables enviadas por datos de objeto alumno
                SqlCommand cmd = new SqlCommand("select ID from Registros where Estado like 'ENTRADA'", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Lista.Add(reader.GetInt32(0).ToString());
                }

                conn.Close();
                return Lista;
            }
        }

        public static List<string> Guialist()
        {
            List<string> Lista = new List<string>();

            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                //carga base de datos con variables enviadas por datos de objeto alumno
                SqlCommand cmd = new SqlCommand("select Guia from Registros where Estado like 'ENTRADA'", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Lista.Add(reader.GetString(0).ToString());
                }

                conn.Close();
                return Lista;
            }
        }

        public static string NextId()
        {
            string idnext;

            //Retorna id siguiente cero si hubo problemas en la lectura

            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format("exec next_id;"), conn);
                
                idnext= cmd.ExecuteScalar().ToString();

                conn.Close();
                return idnext;
          
            }
               
        }

        public static string LastGuia()
        {
            string guia;

            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format("SELECT TOP 1 Guia FROM Registros ORDER BY Id DESC"), conn);

                guia = cmd.ExecuteScalar().ToString();

                conn.Close();
                return guia;

            }

        }

        public static List<Registro> HysGeneral(String tipo, String subtipo)
        {
            List<Registro> Lista = new List<Registro>();
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format(
                    "select * from Registros where Cliente In (select Empresa from Empresas where Tipo like '{0}' and SubTipo like '{1}' )",
                        tipo, subtipo), conn);
                                                            
                SqlDataReader reader = cmd.ExecuteReader();

                Lista = readList(reader);

                conn.Close();
                return Lista;

            }
        }
        
        public static List<Registro> HysGeneral(String tipo, String subtipo, DateTime fechaInferior, DateTime fechaSuperior )
        {
            List<Registro> Lista = new List<Registro>();
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                string fi, fo;
                fi = Convert.ToDateTime(fechaInferior).ToString("yyyy-MM-dd");
                fo = Convert.ToDateTime(fechaSuperior).ToString("yyyy-MM-dd");
                fo = fo + " 23:59:59.999";

                SqlCommand cmd;

                if ((tipo == "%") && (subtipo == "%"))
                {
                    cmd = new SqlCommand(string.Format(
                     "select * from Registros where ( (  FechaEntrada between '{0}'and'{1}') or (FechaSalida between '{0}'and'{1}' ) )   ", fi, fo), conn);
                }
                else
                {
                    cmd = new SqlCommand(string.Format(
                        "select * from Registros where Cliente In (select Empresa from Empresas where Tipo like '{0}' and SubTipo like '{1}') and ( (  FechaEntrada between '{2}'and'{3}') or (FechaSalida between '{2}'and'{3}' ) )   ",
                            tipo, subtipo, fi, fo), conn);
                }

                SqlDataReader reader = cmd.ExecuteReader();

                Lista = readList(reader);

                conn.Close();
                return Lista;

            }
        }

        public static List <string> PlacasList(string cliente)
        {
            //obtiene la lista de placas, ordenadas y sin repetirse

            List<string> Lista = new List<string>();
            int index = 0;
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format("select  DISTINCT Placa from Registros where Cliente like '{0}'", cliente), conn);
                SqlDataReader reader = cmd.ExecuteReader();

                string item;
                Lista.Add(" ");
                while (reader.Read())
                {
                    item = reader.GetString(0);
                    Lista.Add(item);
                }

                conn.Close();

                //ordena lista
                Lista = Lista.OrderBy(q => q).ToList();
                //elimina placas repetidas
                while (index < Lista.Count - 1)
                {
                    if (Lista[index] == Lista[index + 1])
                        Lista.RemoveAt(index);
                    else
                        index++;
                }

                return Lista;

            }
        }

        public static List<string> PlacasList()
        {
            //obtiene la lista de placas, ordenadas y sin repetirse

            List<string> Lista = new List<string>();
            int index = 0;
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format("select  DISTINCT Placa from Registros"), conn);
                SqlDataReader reader = cmd.ExecuteReader();

                string item;
                Lista.Add(" ");
                while (reader.Read())
                {
                    item = reader.GetString(0);
                    Lista.Add(item);
                }

                conn.Close();

                //ordena lista
                Lista = Lista.OrderBy(q => q).ToList();
                //elimina placas repetidas
                while (index < Lista.Count - 1)
                {
                    if (Lista[index] == Lista[index + 1])
                        Lista.RemoveAt(index);
                    else
                        index++;
                }

                return Lista;
            }
        }

        public static List<string> ChoferesList()
        {
            //obtiene la lista de placas, ordenadas y sin repetirse

            List<string> Lista = new List<string>();
            int index = 0;
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format("select  DISTINCT Chofer from Registros"), conn);
                SqlDataReader reader = cmd.ExecuteReader();

                string item;
                Lista.Add(" ");
                while (reader.Read())
                {
                    item = reader.GetString(0);
                    Lista.Add(item);
                }

                conn.Close();

                //ordena lista
                Lista = Lista.OrderBy(q => q).ToList();
                //elimina placas repetidas
                while (index < Lista.Count - 1)
                {
                    if (Lista[index] == Lista[index + 1])
                        Lista.RemoveAt(index);
                    else
                        index++;
                }

                return Lista;
            }
        }

        public static List<string> PlacasListIN()
        {
            //obtiene la lista de placas, ordenadas y sin repetirse

            List<string> Lista = new List<string>();
            int index = 0;
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format("SELECT DISTINCT  Placa from Registros Where Estado = 'ENTRADA'  "), conn);
                SqlDataReader reader = cmd.ExecuteReader();

                string item;
                Lista.Add(" ");
                while (reader.Read())
                {
                    item = reader.GetString(0);
                    Lista.Add(item);
                }

                conn.Close();

                //ordena lista
                Lista = Lista.OrderBy(q => q).ToList();
                //elimina placas repetidas
                while (index < Lista.Count - 1)
                {
                    if (Lista[index] == Lista[index + 1])
                        Lista.RemoveAt(index);
                    else
                        index++;
                }

                return Lista;

            }

        }

        public static string ClientByPlaca(string placa)
        {
            string nameClient;

            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format("SELECT TOP 1 Cliente FROM Registros WHERE Placa like '{0}' order by Id desc", placa), conn);

                try
                { nameClient = cmd.ExecuteScalar().ToString(); }
                catch
                { nameClient = ""; }

                conn.Close();
                return nameClient;
            }

        }
        
        public static List<Registro> HysSearch(string clase, string search)
        {
            List<Registro> Lista = new List<Registro>();
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                SqlCommand cmd = new SqlCommand(string.Format(
                    "select * from Registros where {0} like '{1}'",clase, search), conn);

                SqlDataReader reader = cmd.ExecuteReader();

                Lista = readList(reader);

                conn.Close();
                return Lista;

            }

        }

        public static List<Registro> HysSearch(string clase, string search, DateTime fechaInferior, DateTime fechaSuperior)
        {
            List<Registro> Lista = new List<Registro>();
            using (SqlConnection conn = BDconnection.ObtenerConexion())      //Obtiene el enlace de conexion
            {
                string fi, fo;
                fi = Convert.ToDateTime(fechaInferior).ToString("yyyy-MM-dd");
                fo = Convert.ToDateTime(fechaSuperior).ToString("yyyy-MM-dd");
                fo = fo + " 23:59:59.999";

                SqlCommand cmd = new SqlCommand(string.Format(
                    "select * from Registros where {0} like '{1}' and (  (FechaSalida between '{2}' and '{3}') or (FechaEntrada between '{2}'and'{3}')  ) ", clase, search, fi, fo), conn);

                SqlDataReader reader = cmd.ExecuteReader();

                Lista = readList(reader);

                conn.Close();
                return Lista;

            }

        }


    }

}
