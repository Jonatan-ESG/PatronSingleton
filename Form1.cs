using Microsoft.Data.SqlClient;
using PatronSingleton.Clases;

namespace PatronSingleton
{
    public partial class Form1 : Form
    {
        string stringConexion = "Server=tcp:tests.database.windows.net,1433;Initial Catalog=db;Persist Security Info=False;User ID=usuario;Password=contra;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        ConexionSQLServer administradorConexiones;
        public Form1()
        {
            InitializeComponent();
            administradorConexiones = new ConexionSQLServer(stringConexion);
        }

        private void btnMostrarClientes_Click(object sender, EventArgs e)
        {
            SqlConnection conexionBaseDeDatos = administradorConexiones.CrearConexion();

            string consulta = "SELECT TOP 5 nombre, apellido, correo_electronico FROM dbo.Clientes";

            using (SqlCommand comando = new SqlCommand(consulta, conexionBaseDeDatos)) { 
                
                using(SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        MessageBox.Show($"{lector.GetString(0)} {lector.GetString(1)} {lector.GetString(2)}");
                    }
                }
            
            }
        }
    }
}