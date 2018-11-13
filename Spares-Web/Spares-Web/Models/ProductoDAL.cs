using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Spares_Web.Models
{
    public class ProductoDAL
    {
        IDbConnection _conn = DBCommon.Conexion();

        public List<ProductoEN> Catalogo()
        {
            _conn.Open();
            SqlCommand comando = new SqlCommand("mostrar_producto_web", _conn as SqlConnection);
            comando.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = comando.ExecuteReader();
            List<ProductoEN> lista = new List<ProductoEN>();
            while (_reader.Read())
            {
                ProductoEN pEN = new ProductoEN();
                pEN.id = _reader.GetInt32(0);
                pEN.Producto = _reader.GetString(1);
                pEN.Imagen = (byte[])_reader.GetValue(2);
                pEN.Descripcion = _reader.GetString(3);
                pEN.Categoria = _reader.GetString(4);
                pEN.Marca = _reader.GetString(5);
                pEN.Precio = _reader.GetDecimal(6);

                lista.Add(pEN);
            }

            _conn.Close();
            return lista;
        }
    }
}