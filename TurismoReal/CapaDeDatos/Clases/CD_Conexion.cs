using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Clases
{
    public class CD_Conexion
    {

        private readonly SqlConnection con = new SqlConnection("Data Source=EC2AMAZ-3QFQOA2; initial catalog=TurismoReal; integrated security=true;");


        public SqlConnection AbrirConexion()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public SqlConnection CerrarConexion()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return con;
        }
    }
}
