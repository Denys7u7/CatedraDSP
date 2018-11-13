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
    class CDUsuario
    {
        private CDConexion conexion = new CDConexion();
        private SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public SqlDataReader logearse(string user, string pass)
        {

            SqlCommand comando = new SqlCommand("logearse", conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", user);
            comando.Parameters.AddWithValue("@pass", pass);

            leer = comando.ExecuteReader();
            comando.Parameters.Clear();
            return leer;
        }

        public SqlDataReader logearseUsuario(string user, string pass)
        {

            SqlCommand comando = new SqlCommand("logearse_usuario", conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", user);
            comando.Parameters.AddWithValue("@pass", pass);

            leer = comando.ExecuteReader();
            comando.Parameters.Clear();
            return leer;
        }

        public DataTable Mostrar()
        {
            tabla.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "mostrar_usuario";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string usuario, string pass, int tipo, int empleado)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "insertar_usuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@pass", pass);
            comando.Parameters.AddWithValue("@tipo", tipo);
            comando.Parameters.AddWithValue("@empleado", empleado);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void Modificar(string usuario, string pass, int tipo, int empleado, int id)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "modificar_usuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@pass", pass);
            comando.Parameters.AddWithValue("@tipo", tipo);
            comando.Parameters.AddWithValue("@empleado", empleado);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void Eliminar(int id)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "eliminar_usuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public DataTable Buscar(string busq)
        {
            tabla.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "buscar_usuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@busq", busq);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void cargarTipos(ComboBox cmb)
        {
            cmb.ToString();
            CDConexion conexion = new CDConexion();
            DataTable dt = new DataTable();
            using (conexion.AbrirConexion())
            {
                string query = "select * from tipoUsuario";
                SqlCommand cmd = new SqlCommand(query, conexion.AbrirConexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            cmb.DisplayMember = "Tipo de usuario";
            cmb.ValueMember = "id";
            cmb.DataSource = dt;
            conexion.CerrarConexion();
        }

        public void cargarEmpleados(ComboBox cmb)
        {
            cmb.ToString();
            CDConexion conexion = new CDConexion();
            DataTable dt = new DataTable();
            using (conexion.AbrirConexion())
            {
                string query = "select * from empleado order by [Nombre de Empleado]";
                SqlCommand cmd = new SqlCommand(query, conexion.AbrirConexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            cmb.DisplayMember = "Nombre de Empleado";
            cmb.ValueMember = "id";
            cmb.DataSource = dt;
            conexion.CerrarConexion();
        }
    }
}
