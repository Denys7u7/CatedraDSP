using FormLogin.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLogin.CapaNegocio
{
    class CNProveedor
    {
        CDProveedor obj_pro = new CDProveedor();

        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            tabla = obj_pro.Mostrar();
            return tabla;
        }
        public bool Insertar(TextBox proveedor, TextBox correo, TextBox telefono)
        {
            string val = "^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$";
            int telefonoN;
            if (proveedor.Text == string.Empty)
            {
                MessageBox.Show("El proveedor no puede quedar vacia");
                return false;
            }
            else if(correo.Text == string.Empty)
            {
                MessageBox.Show("El correo no puede quedar vacio");
                return false;
            }
            else if (!(Regex.IsMatch(correo.Text, @val)))
            {
                MessageBox.Show("Ingrese un correo electronico valido");
                return false;
            }
            else if(telefono.Text == string.Empty)
            {
                MessageBox.Show("El telefono no puede quedar vacio");
                return false;
            }
            else if(!(int.TryParse(telefono.Text, out telefonoN))){
                MessageBox.Show("Ingrese un numero de telefono valido");
                return false;
            }
            else
            {
                try
                {
                    obj_pro.Insertar(proveedor.Text, correo.Text, telefonoN);
                    return true;
                }
                catch
                {
                    MessageBox.Show("Puede que la categoria ya este registrada o algun campo ya este registrado", "Verifique los datos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
            }

        }

        public bool Modificar(TextBox proveedor, TextBox correo, TextBox telefono, string id)
        {
            string val = "^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$";
            int telefonoN;
            if (proveedor.Text == string.Empty)
            {
                MessageBox.Show("El proveedor no puede quedar vacia");
                return false;
            }
            else if (correo.Text == string.Empty)
            {
                MessageBox.Show("El correo no puede quedar vacio");
                return false;
            }
            else if (!(Regex.IsMatch(correo.Text, @val)))
            {
                MessageBox.Show("Ingrese un correo electronico valido");
                return false;
            }
            else if (telefono.Text == string.Empty)
            {
                MessageBox.Show("El telefono no puede quedar vacio");
                return false;
            }
            else if (!(int.TryParse(telefono.Text, out telefonoN)))
            {
                MessageBox.Show("Ingrese un numero de telefono valido");
                return false;
            }
            else
            {
                try
                {
                    obj_pro.Modificar(proveedor.Text, correo.Text, telefonoN, Convert.ToInt32(id));
                    return true;
                }
                catch
                {
                    MessageBox.Show("Puede que la categoria ya este registrada", "Verifique los datos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
            }
        }

        public bool Eliminar(string id)
        {
            try
            {
                obj_pro.Eliminar(Convert.ToInt32(id));
                return true;
            }
            catch
            {
                MessageBox.Show("No se pudo eliminar al usuario");
                return false;
            }
        }

        public DataTable buscar(string busq)
        {
            DataTable tabla = new DataTable();
            tabla = obj_pro.Buscar(busq);
            return tabla;
        }
    }
}
