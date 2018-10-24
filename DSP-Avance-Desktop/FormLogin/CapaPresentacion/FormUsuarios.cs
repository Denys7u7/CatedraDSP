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
using CapaPresentacion;

namespace FormLogin.CapaPresentacion
{
    public partial class FormUsuarios : Form
    {
        CNEmpleado objetoCN = new CNEmpleado();
        private string idUser = null;
        private bool Editar = false;
        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("¿Seguro que desea eliminar al usuario/empleado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    idUser = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                    objetoCN.EliminarUser(idUser);
                    MostrarUser();
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtDUI.Text = dataGridView1.CurrentRow.Cells["DUI"].Value.ToString();
                txtUsuario.Text = dataGridView1.CurrentRow.Cells["nomUser"].Value.ToString();
                txtContrasenia.Text = dataGridView1.CurrentRow.Cells["pass"].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                txtEmail.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells["telefono"].Value.ToString();
                txtTipo.Text = dataGridView1.CurrentRow.Cells["tipo"].Value.ToString();
                idUser = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Editar)
            {
                    objetoCN.InsertarUser(txtDUI.Text, txtUsuario.Text, txtContrasenia.Text, txtNombre.Text, txtEmail.Text, txtTelefono.Text, txtTipo.Text);
                    MessageBox.Show("Producto Agregado correctamente", "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MostrarUser();
                    limpiarForm();
                
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("¿Seguro desea modificar los datos del usuario?", "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    objetoCN.EditarUser(txtDUI.Text, txtUsuario.Text, txtContrasenia.Text, txtNombre.Text, txtEmail.Text, txtTelefono.Text, txtTipo.Text, idUser);
                    MessageBox.Show("Producto modificado correctamente", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MostrarUser();
                    limpiarForm();
                    Editar = false;
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
        }

        private void limpiarForm()
        {
            txtDUI.Clear();
            txtUsuario.Clear();
            txtContrasenia.Clear();
            txtNombre.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtTipo.Clear();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            MostrarUser();
        }

        private void MostrarUser()
        {
            CNEmpleado objeto = new CNEmpleado();
            dataGridView1.DataSource = objeto.MostrarUser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain frm = new FormMain();
            frm.Show();
            this.Dispose();
        }
    }
}
