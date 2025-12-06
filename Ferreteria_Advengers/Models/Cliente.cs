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
    internal class Cliente
    {
        public static DataTable Obtener()
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "SELECT * FROM clientes order by id_cliente desc";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
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
        public static bool Guardar(string documento, string nombre, string telefono, string direccion)
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "INSERT INTO clientes (documento, nombre, telefono, direccion) VALUES (@documento, @nombre, @telefono, @direccion)";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                comando.Parameters.AddWithValue("@documento", documento);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@direccion", direccion);
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
        public static bool Editar(int id_cliente, string documento, string nombre, string telefono, string direccion)
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "UPDATE clientes SET documento = @documento, nombre = @nombre, telefono = @telefono, direccion = @direccion WHERE id_cliente = @id_cliente";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                comando.Parameters.AddWithValue("@id_cliente", id_cliente);
                comando.Parameters.AddWithValue("@documento", documento);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@direccion", direccion);
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
        public static bool Eliminar(int id_cliente)
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "DELETE FROM clientes WHERE id_cliente = @id_cliente";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                comando.Parameters.AddWithValue("@id_cliente", id_cliente);
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
