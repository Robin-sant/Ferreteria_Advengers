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
        SqlConnection connection = new SqlConnection("Data Source=192.168.10.2;user id=sa; Password=Hyp3r10nPr0_;DataBase=ferreteria_advengers1;TrustServerCertificate=True");
        public SqlConnection Conectar()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }
        public void Desconectar()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
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
