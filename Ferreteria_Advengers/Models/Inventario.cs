using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria_Advengers.Models
{
    internal class Inventario
    {
        public static DataTable Obtener()
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "SELECT * FROM inventario order by id_inventario desc";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                SqlDataAdapter adaptar = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adaptar.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                return null;
            }
            finally
            {
                ccn.Desconectar();
            }
        }
        public static bool Guardar(string tipo, decimal cantidad, string fecha, string referencia)
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "INSERT INTO inventario (tipo, cantidad, fecha, referencia) VALUES (@tipo, @cantidad, @fecha, @referencia)";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                comando.Parameters.AddWithValue("@ tipo", tipo);
                comando.Parameters.AddWithValue("@cantidad", cantidad);
                comando.Parameters.AddWithValue("@fecha", fecha);
                comando.Parameters.AddWithValue("@referencia", referencia);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                return false;
            }
            finally  
            {
                ccn.Desconectar();
            }
        }
        public static bool Editar(int id, string tipo, decimal cantidad, string fecha, string referencia)
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "UPDATE inventario SET tipo = @tipo, cantidad = @cantidad, fecha = @fecha, referencia = @referencia WHERE id_inventario = @id";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("tipo", tipo);
                comando.Parameters.AddWithValue("@cantidad", cantidad);
                comando.Parameters.AddWithValue("@fecha", fecha);
                comando.Parameters.AddWithValue("@referencia", referencia);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                return false;
            }
            finally
            {
                ccn.Desconectar();
            }
        }
        public static bool Eliminar(int id)
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "DELETE FROM inventario WHERE id_inventario = @id";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                return false;
            }
            finally
            {
                ccn.Desconectar();
            }
        }
    }
}
