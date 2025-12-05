using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ferreteria_Advengers.Models
{
    internal class Detalle_Compra
    {
        public static DataTable Obtener()
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "SELECT * FROM detalle_compra order by id_detalle_compra desc";
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
        public static bool Guardar(int cantidad, decimal costo_unitario, decimal total)
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "INSERT INTO detalle_compra (cantidad, costo_unitario, total) VALUES (@cantidad, @costo_unitario, @total)";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                comando.Parameters.AddWithValue("@cantidad", cantidad);
                comando.Parameters.AddWithValue("@costo_unitario", costo_unitario);
                comando.Parameters.AddWithValue("@total", total);
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
        public static bool Editar(int id, int cantidad, decimal costo_unitario, decimal total)
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "UPDATE detalle_compra SET cantidad = @cantidad, costo_unitario = @costo_unitario, total = @total WHERE id_detalle_compra = @id";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@cantidad", cantidad);
                comando.Parameters.AddWithValue("@costo_unitario", costo_unitario);
                comando.Parameters.AddWithValue("@total", total);
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
                string consulta = "DELETE FROM detalle_compra WHERE id_detalle_compra = @id";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
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