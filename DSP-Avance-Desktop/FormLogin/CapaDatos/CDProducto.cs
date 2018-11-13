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
    class CDProducto
    {
        private CDConexion conexion = new CDConexion();
        private SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "mostrar_producto";
            comando.CommandType = CommandType.Text;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void cargarProveedor(ComboBox comboBox1)
        {
            comboBox1.ToString();
            CDConexion conexion = new CDConexion();
            DataTable dt = new DataTable();
            using (conexion.AbrirConexion())
            {
                string query = "select * from proveedor order by Proveedor";
                SqlCommand cmd = new SqlCommand(query, conexion.AbrirConexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            comboBox1.DisplayMember = "Proveedor";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = dt;
            conexion.CerrarConexion();
        }

        public void cargarReceptor(ComboBox comboBox1)
        {
            comboBox1.ToString();
            CDConexion conexion = new CDConexion();
            DataTable dt = new DataTable();
            using (conexion.AbrirConexion())
            {
                string query = "select * from empleado order by [Nombre de empleado]";
                SqlCommand cmd = new SqlCommand(query, conexion.AbrirConexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            comboBox1.DisplayMember = "Nombre de empleado";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = dt;
            conexion.CerrarConexion();
        }

        public void cargarCategoria(ComboBox comboBox1)
        {
            comboBox1.ToString();
            CDConexion conexion = new CDConexion();
            DataTable dt = new DataTable();
            using (conexion.AbrirConexion())
            {
                string query = "select * from categoria order by Categoria";
                SqlCommand cmd = new SqlCommand(query, conexion.AbrirConexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            comboBox1.DisplayMember = "Categoria";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = dt;
            conexion.CerrarConexion();
        }

        public void cargarMarca(ComboBox comboBox1)
        {
            comboBox1.ToString();
            CDConexion conexion = new CDConexion();
            DataTable dt = new DataTable();
            using (conexion.AbrirConexion())
            {
                string query = "select * from marca order by Marca";
                SqlCommand cmd = new SqlCommand(query, conexion.AbrirConexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            comboBox1.DisplayMember = "Marca";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = dt;
            conexion.CerrarConexion();
        }

        public void Insertar(string nombre, string descripcion, PictureBox imagen, int proveedor, int receptor, int categoria, int marca, int cantidad, float precio)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "insertar_producto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
            comando.Parameters.Add("@imagen", SqlDbType.Image);
            comando.Parameters.Add("@proveedor", SqlDbType.Int);
            comando.Parameters.Add("@receptor", SqlDbType.Int);
            comando.Parameters.Add("@categoria", SqlDbType.Int);
            comando.Parameters.Add("@marca", SqlDbType.Int);
            comando.Parameters.Add("@cantidad", SqlDbType.Int);
            comando.Parameters.Add("@precio", SqlDbType.Money);

            comando.Parameters["@nombre"].Value = nombre;
            comando.Parameters["@descripcion"].Value = descripcion;

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            imagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            comando.Parameters["@imagen"].Value = ms.GetBuffer();
            comando.Parameters["@proveedor"].Value = proveedor;
            comando.Parameters["@receptor"].Value = receptor;
            comando.Parameters["@categoria"].Value = categoria;
            comando.Parameters["@marca"].Value = marca;
            comando.Parameters["@cantidad"].Value = cantidad;
            comando.Parameters["@precio"].Value = precio;
            
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Modificar(string nombre, string descripcion, PictureBox imagen, int proveedor, int receptor, int categoria, int marca, int cantidad, float precio, int id)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "modificar_producto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
            comando.Parameters.Add("@imagen", SqlDbType.Image);
            comando.Parameters.Add("@proveedor", SqlDbType.Int);
            comando.Parameters.Add("@receptor", SqlDbType.Int);
            comando.Parameters.Add("@categoria", SqlDbType.Int);
            comando.Parameters.Add("@marca", SqlDbType.Int);
            comando.Parameters.Add("@cantidad", SqlDbType.Int);
            comando.Parameters.Add("@precio", SqlDbType.Money);
            comando.Parameters.Add("@id", SqlDbType.Int);

            comando.Parameters["@nombre"].Value = nombre;
            comando.Parameters["@descripcion"].Value = descripcion;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            imagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            comando.Parameters["@imagen"].Value = ms.GetBuffer();
            comando.Parameters["@proveedor"].Value = proveedor;
            comando.Parameters["@receptor"].Value = receptor;
            comando.Parameters["@categoria"].Value = categoria;
            comando.Parameters["@marca"].Value = marca;
            comando.Parameters["@cantidad"].Value = cantidad;
            comando.Parameters["@precio"].Value = precio;
            comando.Parameters["@id"].Value = id;
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int id)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "eliminar_producto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public DataTable Buscar(string busq)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "buscar_producto";
            comando.Parameters.AddWithValue("@busq", busq);
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
