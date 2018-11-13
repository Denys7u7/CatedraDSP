using FormLogin.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FormLogin.CapaNegocio
{
    public class CNEmpleado
    {
        private CDEmpleado Empl_D = new CDEmpleado();
        
        public void cargarGenero(ComboBox cmb)
        {
            Empl_D.cargarGenero(cmb);
        }

        public void cargarMunicipio(ComboBox cmb)
        {
            Empl_D.cargarMunicipio(cmb);
        }
        
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            tabla = Empl_D.Mostrar();
            return tabla;
        }
        public bool Insertar(TextBox nombre, TextBox correo, TextBox DUI, string genero, string municipio)
        {
            string val = "^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$";
            int DUIN;
            if(nombre.Text == string.Empty)
            {
                MessageBox.Show("El nombre no puede quedar vacio");
                nombre.Focus();
                return false;
            }
            else if(correo.Text == string.Empty)
            {
                MessageBox.Show("El correo electronico no puede quedar vacio");
                return false;
            }
            else if(!(Regex.IsMatch(correo.Text, @val)))
            {
                MessageBox.Show("Ingrese un correo electronico valido");
                return false;
            }
            else if(!(int.TryParse(DUI.Text, out DUIN)))
            {
                MessageBox.Show("Ingrese un DUI valido");
                return false;
            }
            else
            {
                try
                {
                    Empl_D.Insertar(nombre.Text, correo.Text, Convert.ToInt32(DUI.Text), Convert.ToInt32(genero), Convert.ToInt32(municipio));
                    return true;
                }
                catch
                {
                    MessageBox.Show("Puede que el correo electronico o el DUI ya esten registrados");
                    return false;
                }
            }
            
        }

        public bool Modificar(TextBox nombre, TextBox correo, TextBox DUI, string genero, string municipio,string id)
        {
            string val = "^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$";
            int DUIN;
            if (nombre.Text == string.Empty)
            {
                MessageBox.Show("El nombre no puede quedar vacio");
                nombre.Focus();
                return false;
            }
            else if (correo.Text == string.Empty)
            {
                MessageBox.Show("El correo electronico no puede quedar vacio");
                return false;
            }
            else if (!(Regex.IsMatch(correo.Text, @val)))
            {
                MessageBox.Show("Ingrese un correo electronico valido");
                return false;
            }
            else if (!(int.TryParse(DUI.Text, out DUIN)))
            {
                MessageBox.Show("Ingrese un DUI valido");
                return false;
            }
            else
            {
                try
                {
                    Empl_D.Modificar(nombre.Text, correo.Text, Convert.ToInt32(DUI.Text), Convert.ToInt32(genero), Convert.ToInt32(municipio),Convert.ToInt32(id));
                    return true;
                }
                catch(Exception e)
                {
                    MessageBox.Show("Puede que el correo electronico o el DUI ya esten registrados");
                    return false;
                }
            }
        }

        public bool Eliminar(string id)
        {
            try
            {
                Empl_D.Eliminar(Convert.ToInt32(id));
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
            tabla = Empl_D.Buscar(busq);
            return tabla;
        }
    }
}
