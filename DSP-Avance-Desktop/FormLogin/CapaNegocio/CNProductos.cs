using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using FormLogin.CapaDatos;

namespace FormLogin.CapaNegocio
{
    class CNProductos
    {
        private CDProductos objetoCD = new CDProductos();

        public DataTable MostrarProd()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarPRod(string nombre, string desc, string marca, string precio, string cantidad, string categoria)
        {

            objetoCD.Insertar(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(cantidad), categoria);
        }

        public void EditarProd(string nombre, string descripcion, string marca, string categoria, string precio, string cantidad, string id)
        {
            objetoCD.Editar(nombre, descripcion, marca, categoria, Convert.ToDouble(precio), Convert.ToInt32(cantidad), Convert.ToInt32(id));
        }

        public void EliminarProd(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }
    }
}
