using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronSingleton.Clases
{
    public sealed class ConexionSQLServer
    {
        private string stringConexion;
        private SqlConnection conexion;

        public ConexionSQLServer(string stringConexion)
        {
            this.stringConexion = stringConexion;
            this.conexion = new SqlConnection(stringConexion);
            this.conexion.Open();
        }

        public SqlConnection CrearConexion()
        {
            return this.conexion;
        }

        public void EliminarConexion()
        {
            this.conexion.Dispose();
        }
    }
}
