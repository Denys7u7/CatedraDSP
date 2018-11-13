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
    public partial class FormMarca : Form
    {
        CNMarca marca = new CNMarca();
        private string id = null;
        bool Editar;
        string usuario;
        public FormMarca(string usuario)
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

        private void FormMarca_Load(object sender, EventArgs e)
        {
            label5.Text = usuario;
            mostrar();
        }

        private void mostrar()
        {
            CNMarca objeto = new CNMarca();
            dataGridView1.DataSource = objeto.Mostrar();
        }

        private void limpiarForm()
        {
            txtMarca.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool band = false;

            if (Editar == false)
            {
                band = marca.Insertar(txtMarca);
                if (band == true)
                {
                    MessageBox.Show("Marca agregada correctamente", "Adicion completada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                DialogResult dialogResult = MessageBox.Show("Si lo hace todos los productos asociados se alteraran", "¿Seguro desea modificar esta marca?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    band = marca.Modificar(txtMarca, id);
                    if (band == true)
                    {
                        MessageBox.Show("Marca modificada correctamente", "Modificacion completada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                txtMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
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
                DialogResult dialogResult = MessageBox.Show("Si lo hace todos los productos asociados a esta marca se eliminaran", "¿Seguro que desea eliminar la marca?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                    marca.Eliminar(id);
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

        private void button1_Click(object sender, EventArgs e)
        {
            CNMarca objeto = new CNMarca();
            dataGridView1.DataSource = objeto.buscar(txtBusq.Text);
        }
    }
}
