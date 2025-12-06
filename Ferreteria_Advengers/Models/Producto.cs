using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Ferreteria_Advengers;
using System.Windows.Forms;
using System.Data.SqlClient;
using Ferreteria_Advengers.Models;

namespace Ferreteria_Advengers.Models
{
    internal class Producto
    {
        public static DataTable Obtener()
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "SELECT * FROM productos order by Id_producto desc";
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
        public static bool Guardar(int codigo_barra, string nombre, string descripcion, string color, string unidad_medida, int stock_actual, int stock_minimo,
            decimal costo_actual, decimal precio_minorista, decimal precio_mayorista)
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "INSERT INTO productos (codigo_barras, nombre, descripcion, color, unidad_medida, stock_actual, stock_minimo, costo_actual, precio_minorista, precio_mayorista) VALUES" +
                " (@codigo_barra, @nombre, @descripcion, @color, @unidad_medida, @stock_actual, @stock_minimo, @costo_actual, @precio_minorista, @precio_mayorista)";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                comando.Parameters.AddWithValue("@codigo_barra", codigo_barra);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@color", color);
                comando.Parameters.AddWithValue("@unidad_medida", unidad_medida);
                comando.Parameters.AddWithValue("@stock_actual", stock_actual);
                comando.Parameters.AddWithValue("@stock_minimo", stock_minimo);
                comando.Parameters.AddWithValue("@costo_actual", costo_actual);
                comando.Parameters.AddWithValue("@precio_minorista", precio_minorista);
                comando.Parameters.AddWithValue("@precio_mayorista", precio_mayorista);
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
        public static bool Editar(int id, int codigo_barra, string nombre, string descripcion, string color, string unidad_medida, int stock_actual, int stock_minimo,
            decimal costo_actual, decimal precio_minorista, decimal precio_mayorista)
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "UPDATE productos SET codigo_barra=@codigo_barra, nombre=@nombre, descripcion=@descripcion, color=@color, unidad_medida=@unidad_medida, " +
                    "stock_actual=@stock_actual, stock_minimo=@stock_minimo, costo_actual=@costo_actual, precio_minorista=@precio_minorista, precio_mayorista=@precio_mayorista WHERE id=@id";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                comando.Parameters.AddWithValue("@codigo_barra", codigo_barra);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@color", color);
                comando.Parameters.AddWithValue("@unidad_medida", unidad_medida);
                comando.Parameters.AddWithValue("@stock_actual", stock_actual);
                comando.Parameters.AddWithValue("@stock_minimo", stock_minimo);
                comando.Parameters.AddWithValue("@costo_actual", costo_actual);
                comando.Parameters.AddWithValue("@precio_minorista", precio_minorista);
                comando.Parameters.AddWithValue("@precio_mayorista", precio_mayorista);
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
        public static bool Eliminar(int id)
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "DELETE FROM productos WHERE id=@id";
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
