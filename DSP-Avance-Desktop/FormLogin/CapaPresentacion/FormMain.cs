using FormLogin.CapaPresentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormLogin.CapaNegocio;
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class FormMain : Form
    {
        private string usuario;
        public FormMain(string usuario)
        {
            InitializeComponent();
            label1.Text = usuario;
            this.usuario = usuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FromProducto frm = new FromProducto(usuario);
            frm.Show();
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormMarca frm = new FormMarca(usuario);
            frm.Show();
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormUsuario frm = new FormUsuario(usuario);
            frm.Show();
            this.Dispose();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro quiere cerrar la sesion?", "Cerrar Sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (dialogResult == DialogResult.Yes)
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Dispose();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCategoria frm = new FormCategoria(usuario);
            frm.Show();
            this.Dispose();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        public void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormUsuarios frm = new FormUsuarios(usuario);
            frm.Show();
            this.Dispose();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FormProveedor frm = new FormProveedor(usuario);
            frm.Show();
            this.Dispose();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormMarca frm = new FormMarca(usuario);
            frm.Show();
            this.Dispose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormUsuarios frm = new FormUsuarios(usuario);
            frm.Show();
            this.Dispose();
        }
    }
}