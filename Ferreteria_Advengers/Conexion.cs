using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria_Advengers
{
    internal class Conexion
    {
        SqlConnection connection = new SqlConnection("Data Source=172.16.0.20;User Id=sa;Password=Hyp3r10nPr0_;DataBase=ferreteria_advengers1;TrustServerCertificate=True");
        public void Conectar()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }
        public void Desconectar()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }

        }
        public SqlConnection ObtenerConexion()
        {
            return connection;
        }
    }
}
   