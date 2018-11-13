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
    class CNCategoria
    {
        CDCategoria obj_cat = new CDCategoria();
        
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            tabla = obj_cat.Mostrar();
            return tabla;
        }
        public bool Insertar(TextBox categoria)
        {
            int CatN;
            if (categoria.Text == string.Empty)
            {
                MessageBox.Show("La categoria no puede quedar vacia");
                return false;
            }
            else if(int.TryParse(categoria.Text, out CatN))
            {
                MessageBox.Show("La categoria no puede ser un dato numerico", "Ingrese una categoria valida", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            else
            {
                try
                {
                    obj_cat.Insertar(categoria.Text);
                    return true;
                }
                catch
                {
                    MessageBox.Show("Puede que la categoria ya este registrada","Verifique los datos",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    return false;
                }
            }

        }

        public bool Modificar(TextBox categoria, string id)
        {
            if (categoria.Text == string.Empty)
            {
                MessageBox.Show("La categoria no puede quedar vacia");
                return false;
            }
            else
            {
                try
                {
                    obj_cat.Modificar(categoria.Text, Convert.ToInt32(id));
                    return true;
                }
                catch (Exception e)
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
                obj_cat.Eliminar(Convert.ToInt32(id));
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
            tabla = obj_cat.Buscar(busq);
            return tabla;
        }
    }
}
