using FormLogin.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLogin.CapaNegocio
{
    class CNUsuario
    {
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        CDConexion conexion = new CDConexion();

        private CDUsuario Usuario_D = new CDUsuario();
        private String _Usuario;
        private String _Contraseña;
        public String Usuario
        {
            set { _Usuario = value; }
            get { return _Usuario; }
        }
        public String Contraseña
        {
            set { _Contraseña = value; }
            get { return _Contraseña; }
        }

        public void nombreUsuario(Label lbl)
        {
            lbl.Text = Usuario;
        }
        

        public bool logearse(Form frm, Label lblUser, Label lblPass, Label lblLogearse, TextBox user, TextBox pass)
        {

            SqlDataReader Loguear;
            if (Usuario == string.Empty)
            {
                lblUser.Text = "Llene el campo usuario";
                return false;
            }
            else
            {
                lblUser.Text = string.Empty;
            }
            if (Contraseña == string.Empty)
            {
                lblPass.Text = "Llene el campo de contraseña";
                return false;
            }
            else
            {
                lblPass.Text = string.Empty;
            }
            Loguear = Usuario_D.logearse(Usuario, Contraseña);
            if (Loguear.Read() == true)
            {
                frm.Show();
                return true;
            }
            else
            {
                pass.Text = string.Empty;
                lblLogearse.Text = "Usuario o contraseña invalidas, intente de nuevo";
                return false;
            }
        }

        public bool Insertar(TextBox usuario, TextBox pass, string tipo, string empleado)
        {
            int tipoN;
            int empleadoN;

            if(int.TryParse(tipo, out tipoN))
            {
                if(int.TryParse(empleado, out empleadoN))
                {
                    if(usuario.Text != string.Empty)
                    {
                        if(pass.Text != string.Empty)
                        {
                            try
                            {
                                Usuario_D.Insertar(usuario.Text, pass.Text, tipoN, empleadoN);
                                return true;
                            }
                            catch
                            {
                                MessageBox.Show("Puede que el usuario ya este registrado o este empleado ya posea un usuario", "Verifica los datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("La contraseña del usuario no puede estar vacio", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pass.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El nombre de usuario no puede estar vacio", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        usuario.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("El empleado no es valido", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("El tipo de usuario no es valido","Verificar",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                return false;
            }
        }

        public bool Modificar(TextBox usuario, TextBox pass, string tipo, string empleado, string id)
        {
            int tipoN;
            int empleadoN;
            int idN;
            idN = Convert.ToInt32(id);

            if (int.TryParse(tipo, out tipoN))
            {
                if (int.TryParse(empleado, out empleadoN))
                {
                    if (usuario.Text != string.Empty)
                    {
                        if (pass.Text != string.Empty)
                        {
                            try
                            {
                                Usuario_D.Modificar(usuario.Text, pass.Text, tipoN, empleadoN, idN);
                                return true;
                            }
                            catch
                            {
                                MessageBox.Show("Puede que el usuario ya este registrado o este empleado ya posea un usuario", "Verifica los datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("La contraseña del usuario no puede estar vacio", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pass.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El nombre de usuario no puede estar vacio", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        usuario.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("El empleado no es valido", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("El tipo de usuario no es valido", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
        }

        public bool Eliminar(string id)
        {
            int idN;
            idN = Convert.ToInt32(id);
            try
            {
                Usuario_D.Eliminar(idN);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }

        public DataTable Buscar(TextBox busq)
        {
            DataTable tabla = new DataTable();
            tabla = Usuario_D.Buscar(busq.Text);
            return tabla;
        }

        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            tabla = Usuario_D.Mostrar();
            return tabla;
        }

        public void cargarTipos(ComboBox cmb)
        {
            Usuario_D.cargarTipos(cmb);
        }

        public void cargarEmpleados(ComboBox cmb)
        {
            Usuario_D.cargarEmpleados(cmb);
        }
    }
}
