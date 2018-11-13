using FormLogin.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLogin.CapaNegocio
{
    class CNProducto
    {
        private CDProducto obj_producto = new CDProducto();

        public void cargarProveedor(ComboBox cmb)
        {
            obj_producto.cargarProveedor(cmb);
        }

        public void cargarReceptor(ComboBox cmb)
        {
            obj_producto.cargarReceptor(cmb);
        }

        public void cargarCategoria(ComboBox cmb)
        {
            obj_producto.cargarCategoria(cmb);
        }

        public void cargarMarca(ComboBox cmb)
        {
            obj_producto.cargarMarca(cmb);
        }

        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            tabla = obj_producto.Mostrar();
            return tabla;
        }
        public bool Insertar(TextBox nombre, TextBox descripcion, PictureBox imagen, string proveedor, string receptor, string categoria, string marca, TextBox cantidad, TextBox precio)
        {
            int cantidadN;
            float precioN;
            if (nombre.Text == string.Empty)
            {
                MessageBox.Show("El nombre no puede quedar vacio");
                nombre.Focus();
                return false;
            }
            else if (descripcion.Text == string.Empty)
            {
                MessageBox.Show("La descripcion no puede quedar vacia");
                return false;
            }
            else if (imagen.Image == null)
            {
                MessageBox.Show("Ingrese una imagen");
                return false;
            }
            else if(cantidad.Text == string.Empty)
            {
                MessageBox.Show("La cantidad no puede quedar vacia");
                return false;
            }
            else if(!(int.TryParse(cantidad.Text, out cantidadN)))
            {
                MessageBox.Show("Ingrese una cantidad numerica");
                return false;
            }
            else if(cantidadN < 0)
            {
                MessageBox.Show("La cantidad de existencias no puede ser menor que cero");
                return false;
            }
            else if (precio.Text == string.Empty)
            {
                MessageBox.Show("El precio no puede quedar vacio");
                return false;
            }
            else if (!(float.TryParse(precio.Text, out precioN)))
            {
                MessageBox.Show("Ingrese una precio numerico valido");
                return false;
            }
            else if (precioN < 0)
            {
                MessageBox.Show("El precio no puede ser menor que cero");
                return false;
            }
            else
            {
                //try
                //{
                    obj_producto.Insertar(nombre.Text, descripcion.Text, imagen, Convert.ToInt32(proveedor), Convert.ToInt32(receptor), Convert.ToInt32(categoria), Convert.ToInt32(marca), cantidadN, precioN);
                    return true;
                //}
                //catch
                //{
                //    MessageBox.Show("ERROR XD");
                //    return false;
                //}
            }
        }

        public bool Modificar(TextBox nombre, TextBox descripcion, PictureBox imagen, string proveedor, string receptor, string categoria, string marca, TextBox cantidad, TextBox precio, string id)
        {
            int cantidadN;
            float precioN;
            if (nombre.Text == string.Empty)
            {
                MessageBox.Show("El nombre no puede quedar vacio");
                nombre.Focus();
                return false;
            }
            else if (descripcion.Text == string.Empty)
            {
                MessageBox.Show("La descripcion no puede quedar vacia");
                return false;
            }
            else if (imagen.Image == null)
            {
                MessageBox.Show("Ingrese una imagen");
                return false;
            }
            else if (cantidad.Text == string.Empty)
            {
                MessageBox.Show("La cantidad no puede quedar vacia");
                return false;
            }
            else if (!(int.TryParse(cantidad.Text, out cantidadN)))
            {
                MessageBox.Show("Ingrese una cantidad numerica");
                return false;
            }
            else if (cantidadN < 0)
            {
                MessageBox.Show("La cantidad de existencias no puede ser menor que cero");
                return false;
            }
            else if (precio.Text == string.Empty)
            {
                MessageBox.Show("El precio no puede quedar vacio");
                return false;
            }
            else if (!(float.TryParse(precio.Text, out precioN)))
            {
                MessageBox.Show("Ingrese una precio numerico valido");
                return false;
            }
            else if (precioN < 0)
            {
                MessageBox.Show("El precio no puede ser menor que cero");
                return false;
            }
            else
            {
                try
                {
                    obj_producto.Modificar(nombre.Text, descripcion.Text, imagen, Convert.ToInt32(proveedor), Convert.ToInt32(receptor), Convert.ToInt32(categoria), Convert.ToInt32(marca), cantidadN, precioN, Convert.ToInt32(id));
                    return true;
                }
                catch
                {
                    MessageBox.Show("ERROR XD");
                    return false;
                }
            }
        }

        public bool Eliminar(string id)
        {
            try
            {
                obj_producto.Eliminar(Convert.ToInt32(id));
                return true;
            }
            catch
            {
                MessageBox.Show("No se pudo eliminar el producto");
                return false;
            }
        }

        public DataTable buscar(string busq)
        {
            DataTable tabla = new DataTable();
            tabla = obj_producto.Buscar(busq);
            return tabla;
        }
    }
}
