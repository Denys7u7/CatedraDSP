using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLogin.CapaDatos
{
    public class CDEmpleado
        {
            private CDConexion conexion = new CDConexion();
            private SqlDataReader leer;
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();

        
        
       public DataTable Mostrar()
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "mostrar_empleado";
                comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                conexion.CerrarConexion();
                return tabla;
            }

        public void cargarGenero(ComboBox comboBox1)
        {
            comboBox1.ToString();
            CDConexion conexion = new CDConexion();
            DataTable dt = new DataTable();
            using (conexion.AbrirConexion())
            {
                string query = "select * from genero order by Genero";
                SqlCommand cmd = new SqlCommand(query, conexion.AbrirConexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            comboBox1.DisplayMember = "Genero";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = dt;
            conexion.CerrarConexion();
        }

        public void cargarMunicipio(ComboBox comboBox1)
        {
            comboBox1.ToString();
            CDConexion conexion = new CDConexion();
            DataTable dt = new DataTable();
            using (conexion.AbrirConexion())
            {
                string query = "select * from municipio order by Municipio";
                SqlCommand cmd = new SqlCommand(query, conexion.AbrirConexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            comboBox1.DisplayMember = "Municipio";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = dt;
            conexion.CerrarConexion();
        }

        public void Insertar(string nombre, string correo, int DUI, int genero, int municipio)
            {
                comando.Parameters.Clear();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "insertar_empleado";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@DUI", DUI);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@correo", correo);
                comando.Parameters.AddWithValue("@genero", genero);
                comando.Parameters.AddWithValue("@municipio", municipio);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
            }

            public void Modificar(string nombre, string correo, int DUI, int genero, int municipio, int id)
            {
                comando.Parameters.Clear();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "modificar_empleado";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@DUI", DUI);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@correo", correo);
                comando.Parameters.AddWithValue("@genero", genero);
                comando.Parameters.AddWithValue("@municipio", municipio);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
            }

            public void Eliminar(int id)
            {
                comando.Parameters.Clear();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "eliminar_empleado";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
        }

        public DataTable Buscar(string busq)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "buscar_empleado";
            comando.Parameters.AddWithValue("@busq", busq);
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
