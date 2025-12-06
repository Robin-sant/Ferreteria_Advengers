using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ferreteria_Advengers;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Ferreteria_Advengers.Models
{
    internal class Cuenta_Cobrar
    {
        public static DataTable Obtener()
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "SELECT * FROM Cuentas_Cobrar order by id_cxc desc";
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
        public static bool Guardar(string fecha_vencimiento, decimal monto_total, decimal monto_pendiente, string estado)
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "INSERT INTO Cuentas_Cobrar (fecha_vencimiento, monto_total monto_pendiente, estado) VALUES (@fecha_vencimiento, @monto_total @monto_pendiente, @estado)";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                comando.Parameters.AddWithValue("@fecha_vencimiento", fecha_vencimiento);
                comando.Parameters.AddWithValue("@monto_total", monto_total);
                comando.Parameters.AddWithValue("@monto_pendiente", monto_pendiente);
                comando.Parameters.AddWithValue("@estado", estado);
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
        public static bool Editar(int id_cxc, string fecha_vencimiento, decimal monto_total, decimal monto_pendiente, string estado)
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "UPDATE Cuentas_Cobrar SET fecha_vencimiento=@fecha_vencimiento, monto_total=@monto_total, monto_pendiente=@monto_pendiente, estado=@estado WHERE id_cxc=@id_cxc";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                comando.Parameters.AddWithValue("@id_cxc", id_cxc);
                comando.Parameters.AddWithValue("@fecha_vencimiento", fecha_vencimiento);
                comando.Parameters.AddWithValue("@monto_total", monto_total);
                comando.Parameters.AddWithValue("@monto_pendiente", monto_pendiente);
                comando.Parameters.AddWithValue("@estado", estado);
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
        public static bool Eliminar(int id_cxc)
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "DELETE FROM Cuentas_Cobrar WHERE id_cxc = @id_cxc";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                comando.Parameters.AddWithValue("@id_cxc", id_cxc);
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
