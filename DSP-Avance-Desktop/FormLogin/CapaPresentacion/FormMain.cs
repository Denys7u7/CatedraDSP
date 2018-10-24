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

namespace CapaPresentacion
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormInventario frm = new FormInventario();
            frm.Show();
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Seguro quiere salir del sistema","Salir",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormUsuarios frm = new FormUsuarios();
            frm.Show();
            this.Dispose();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta sección aun no esta lista", "Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
