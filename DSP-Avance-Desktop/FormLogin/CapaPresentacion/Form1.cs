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
using FormLogin.CapaPresentacion;

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
            CNUsuario objEmpleado = new CNUsuario();
            objEmpleado.Usuario = txtUsuario.Text;
            objEmpleado.Contraseña = txtPass.Text;
            bool band = false;
            bool band2 = false;

            FormMain ObjFP = new FormMain(txtUsuario.Text);
            band = objEmpleado.logearse(ObjFP, lblErrorUsuario, lblErrorPass, lblErrorLogin,txtUsuario, txtPass);
            if (band == true)
            {
                this.Hide();
                LimpiarForm();
            }
            if (band2 == true)
            {
                this.Hide();
                LimpiarForm();
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Seguro quiere salir del sistema", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
