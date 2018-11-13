using CapaPresentacion;
using FormLogin.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLogin.CapaPresentacion
{
    public partial class FormProveedor : Form
    {
        string usuario;
        CNProveedor proveedor = new CNProveedor();
        private string id = null;
        bool Editar;
        public FormProveedor(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
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

        private void button2_Click(object sender, EventArgs e)
        {
            FormMain frm = new FormMain(usuario);
            frm.Show();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CNProveedor objeto = new CNProveedor();
            dataGridView1.DataSource = objeto.buscar(txtBusq.Text);
        }

        private void limpiarForm()
        {
            txtProveedor.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
        }

        private void FormProveedor_Load(object sender, EventArgs e)
        {
            mostrar();
            label5.Text = usuario;
        }

        private void mostrar()
        {
            CNProveedor objeto = new CNProveedor();
            dataGridView1.DataSource = objeto.Mostrar();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool band = false;

            if (Editar == false)
            {
                band = proveedor.Insertar(txtProveedor, txtCorreo, txtTelefono);
                if (band == true)
                {
                    MessageBox.Show("Proveedor Agregado correctamente", "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    mostrar();
                    limpiarForm();
                    band = false;
                }
                else
                {
                    return;
                }


            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("¿Seguro desea modificar los datos del proveedor?", "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    band = proveedor.Modificar(txtProveedor, txtCorreo, txtTelefono,id);
                    if (band == true)
                    {
                        MessageBox.Show("Proveedor modificado correctamente", "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        mostrar();
                        limpiarForm();
                        band = false;
                        Editar = false;
                    }
                    else
                    {
                        return;
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtProveedor.Text = dataGridView1.CurrentRow.Cells["Proveedor"].Value.ToString();
                txtCorreo.Text = dataGridView1.CurrentRow.Cells["Correo electronico"].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells["Telefono"].Value.ToString();
                id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                Editar = true;
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("¿Seguro que desea eliminar al usuario?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                    proveedor.Eliminar(id);
                    mostrar();
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }
    }
}
