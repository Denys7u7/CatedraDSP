using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormLogin.CapaDatos
{
    class CDMarca
    {
        private CDConexion conexion = new CDConexion();
        private SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();



        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "mostrar_marca";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string marca)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "insertar_marca";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Marca", marca);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Modificar(string marca, int id)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "modificar_marca";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Marca", marca);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int id)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "eliminar_marca";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public DataTable Buscar(string busq)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "buscar_marca";
            comando.Parameters.AddWithValue("@busq", busq);
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
