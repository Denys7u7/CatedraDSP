using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FormLogin.CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CNEmpleado objEmpleado = new CNEmpleado();
            SqlDataReader Loguear;
            objEmpleado.Usuario = txtUsuario.Text;
            objEmpleado.Contraseña = txtPass.Text;

            if(txtUsuario.Text == string.Empty)
            {
                lblErrorUsuario.Text = "Llene el campo usuario";
                return;
            }
            else
            {
                lblErrorUsuario.Text = string.Empty;
            }
            if(txtPass.Text == string.Empty)
            {
                lblErrorPass.Text = "Llene el campo de contraseña";
                return;
            }
            else
            {
                lblErrorPass.Text = string.Empty;
            }
            if (objEmpleado.Usuario == txtUsuario.Text)
            {
                lblErrorUsuario.Visible = false;

                if (objEmpleado.Contraseña == txtPass.Text)
                {
                    lblErrorPass.Visible = false;
                    Loguear = objEmpleado.IniciarSesion();

                    if (Loguear.Read() == true)
                    {
                        LimpiarForm();
                        this.Hide();
                        FormMain ObjFP = new FormMain();
                        ObjFP.Show();
                    }
                    else
                    {
                        lblErrorLogin.Text = "Usuario o contraseña invalidas, intente de nuevo";
                        lblErrorLogin.Visible = true;
                        txtPass.Text = "";
                        lblErrorUsuario.Focus();
                    }
                }
                else
                {
                    lblErrorPass.Text = objEmpleado.Contraseña;
                    lblErrorPass.Visible = true;
                }
            }
            else
            {
                lblErrorUsuario.Text = objEmpleado.Usuario;
                lblErrorUsuario.Visible = true;
            }
        }

        private void LimpiarForm()
        {
            txtPass.Clear();
            txtUsuario.Clear();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
    }
}
