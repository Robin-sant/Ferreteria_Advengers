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
    internal class Usuario
    {
        public static DataTable Obtener()
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "select * from usuarios order by id_usuario desc";
                SqlCommand comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return null;
            }
            finally
            {
                cnn.Desconectar();
            }
        }
        public static bool Guardar(string nombre_usuario, string password, string nombre_completo, string rol, string estado, string fecha)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "INSERT INTO usuarios (nombre_usuario, password, nombre_completo, rol, estado, fecha) VALUES (@nombre_usuario, @password, @nombre_completo, @rol, @estado, @fecha)";
                SqlCommand comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                comando.Parameters.AddWithValue("@nombre_usuario", nombre_usuario);
                comando.Parameters.AddWithValue("@password", password);
                comando.Parameters.AddWithValue("@nombre_completo", nombre_completo);
                comando.Parameters.AddWithValue("@rol", rol);
                comando.Parameters.AddWithValue("@estado", estado);
                comando.Parameters.AddWithValue("@fecha", fecha);
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
                cnn.Desconectar();
            }
        }
        public static bool Editar(int id, string nombre_usuario, string password, string nombre_completo, string rol, string estado, string fecha)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "UPDATE usuarios SET nombre_usuario = @nombre_usuario, password = @password, nombre_completo = @nombre_completo, rol = @rol, estado = @estado, fecha = @fecha WHERE id_usuario = @id";
                SqlCommand comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nombre_usuario", nombre_usuario);
                comando.Parameters.AddWithValue("@password", password);
                comando.Parameters.AddWithValue("@nombre_completo", nombre_completo);
                comando.Parameters.AddWithValue("@rol", rol);
                comando.Parameters.AddWithValue("@estado", estado);
                comando.Parameters.AddWithValue("@fecha", fecha);
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
                cnn.Desconectar();
            }
        }
        public static bool Eliminar(int id)
        {
            Conexion cnn = new Conexion();

            try
            {
                cnn.Conectar();
                string consulta = "DELETE FROM usuarios WHERE id_usuario = @id";
                SqlCommand comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return false;
            }
            finally
            {
                cnn.Desconectar();
            }
        }
    }
}


