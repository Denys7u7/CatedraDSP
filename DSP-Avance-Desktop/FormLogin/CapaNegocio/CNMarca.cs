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
    class CNMarca
    {
        CDMarca obj_marca = new CDMarca();

        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            tabla = obj_marca.Mostrar();
            return tabla;
        }
        public bool Insertar(TextBox marca)
        {
            int marcaN;
            if (marca.Text == string.Empty)
            {
                MessageBox.Show("La marca no puede quedar vacia");
                return false;
            }
            else if (int.TryParse(marca.Text, out marcaN))
            {
                MessageBox.Show("La marca no puede ser un dato numerico", "Ingrese una marca valida", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            else
            {
                try
                {
                    obj_marca.Insertar(marca.Text);
                    return true;
                }
                catch
                {
                    MessageBox.Show("Puede que la marca ya este registrada", "Verifique los datos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
            }

        }

        public bool Modificar(TextBox marca, string id)
        {
            if (marca.Text == string.Empty)
            {
                MessageBox.Show("La marca no puede quedar vacia");
                return false;
            }
            else
            {
                try
                {
                    obj_marca.Modificar(marca.Text, Convert.ToInt32(id));
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Puede que la marca ya este registrada", "Verifique los datos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
            }
        }

        public bool Eliminar(string id)
        {
            try
            {
                obj_marca.Eliminar(Convert.ToInt32(id));
                return true;
            }
            catch
            {
                MessageBox.Show("No se pudo eliminar la marca");
                return false;
            }
        }

        public DataTable buscar(string busq)
        {
            DataTable tabla = new DataTable();
            tabla = obj_marca.Buscar(busq);
            return tabla;
        }
    }
}
