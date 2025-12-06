using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria_Advengers.Models
{
    internal class Venta
    {
        public static DataTable Obtener()
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "select * from ventas order by id_venta desc";
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
        public static bool Guardar(string numero_comprobante, string tipo_comprobante, string tipo_pago,
            string fecha_venta, string total, string tipo_venta, string estado)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "INSERT INTO productos (numero_comprobante,tipo_comprobante,tipo_pago,fecha_venta,total, tipo_venta,estado) values (@numero_comprobante,@tipo_comprobante,@tipo_pago,@fecha_venta,@total, @tipo_venta,@estado)";
        SqlCommand comando = new SqlCommand(consulta, cnn.ObtenerConexion());
             comando.Parameters.AddWithValue("@numero_comprobante", numero_comprobante);
             comando.Parameters.AddWithValue("@tipo_comprobante", tipo_comprobante);
             comando.Parameters.AddWithValue("@tipo_pago", tipo_pago);
             comando.Parameters.AddWithValue("@fecha_venta", fecha_venta);
             comando.Parameters.AddWithValue("@total", total);
             comando.Parameters.AddWithValue("@tipo_venta", tipo_venta);
             comando.Parameters.AddWithValue("@estado", estado);
             comando.ExecuteNonQuery();
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
           
        public static bool Editar(int id,string numero_comprobante, string  tipo_comprobante, string tipo_pago, 
            string fecha_venta,string  total, string estado)
             
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
        string consulta = "insert into clientes (numero_comprobante,tipo_comprobante,tipo_pago,fecha_venta,total," +
             "tipo_venta,estado) " + "values (@numero_comprobante,@tipo_comprobante,@tipo_pago,@fecha_venta,@total," +
             "@tipo_venta,@estado)";
                SqlCommand comando = new SqlCommand(consulta,cnn.ObtenerConexion());  
        comando.Parameters.AddWithValue("@numero_comprobante", numero_comprobante);
        comando.Parameters.AddWithValue("@tipo_comprobante", tipo_comprobante);
        comando.Parameters.AddWithValue("@tipo_pago", tipo_pago);
        comando.Parameters.AddWithValue("@fecha_venta", fecha_venta);
        comando.Parameters.AddWithValue("@total", total);
        comando.Parameters.AddWithValue("@tipo_venta", total);
        comando.Parameters.AddWithValue("@estado", estado);
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
        public static bool eliminar(int id)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "delete from clientes where id=@id";
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

