using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormLogin.CapaDatos
{
    public class CDEmpleado
        {
            private CDConexion conexion = new CDConexion();
            private SqlDataReader leer;
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();

        public SqlDataReader iniciarSesion(string user, string pass)
            {

                SqlCommand comando = new SqlCommand("buscarUser", conexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nomUser", user);
                comando.Parameters.AddWithValue("@pass", pass);

                leer = comando.ExecuteReader();
                comando.Parameters.Clear();
                return leer;
            }
        
            public DataTable Mostrar()
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "mostrarUsuarios";
                comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                conexion.CerrarConexion();
                return tabla;
            }

            public void Insertar(int DUI, string nomUsuario, string password, string nombre, string email, int telefono, string tipo)
            {
                //PROCEDIMNIENTO

                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "insertarUsuario";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@DUI", DUI);
                comando.Parameters.AddWithValue("@nomUsuario", nomUsuario);
                comando.Parameters.AddWithValue("@password", password);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@tipo", tipo);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();

            }

            public void Editar(int DUI, string nomUsuario, string password, string nombre, string email, int telefono, string tipo, int id)
            {

                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "editarUsuario";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@DUI", DUI);
                comando.Parameters.AddWithValue("@nomUsuario", nomUsuario);
                comando.Parameters.AddWithValue("@password", password);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@tipo", tipo);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
            }

            public void Eliminar(int id)
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "eliminarUsuario";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
        }
    }
}
