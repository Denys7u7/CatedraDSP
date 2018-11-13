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
        string Genero;
        string Municipio;
        string usuario;
        private bool Editar = false;
        public FormUsuarios(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
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
                DialogResult dialogResult = MessageBox.Show("¿Seguro que desea eliminar al empleado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    idUser = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                    objetoCN.Eliminar(idUser);
                    MostrarEmpleados();
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
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Empleado"].Value.ToString();
                txtCorreo.Text = dataGridView1.CurrentRow.Cells["E-mail"].Value.ToString();
                txtDUI.Text = dataGridView1.CurrentRow.Cells["DUI"].Value.ToString();
                cmbGenero.Text = dataGridView1.CurrentRow.Cells["Genero"].Value.ToString();
                cmbMunicipio.Text = dataGridView1.CurrentRow.Cells["Municipio"].Value.ToString();
                idUser = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        
        private void limpiarForm()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtDUI.Clear();
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            MostrarEmpleados();
            objetoCN.cargarGenero(cmbGenero);
            objetoCN.cargarMunicipio(cmbMunicipio);
            label5.Text = usuario;
        }

        private void MostrarEmpleados()
        {
            CNEmpleado objeto = new CNEmpleado();
            dataGridView1.DataSource = objeto.Mostrar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain frm = new FormMain(usuario);
            frm.Show();
            this.Dispose();
        }

        private void txtContrasenia_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormMain frm = new FormMain(usuario);
            frm.Show();
            this.Dispose();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void button5_Click_1(object sender, EventArgs e)
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

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FormMain frm = new FormMain(usuario);
            frm.Show();
            this.Dispose();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            Municipio = cmbMunicipio.SelectedValue.ToString();
            Genero = cmbGenero.SelectedValue.ToString();

            bool band = false;

            if (!Editar)
            {
                band = objetoCN.Insertar(txtNombre, txtCorreo,txtDUI, Genero, Municipio);
                if (band)
                {
                    MessageBox.Show("Empleado Agregado correctamente", "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MostrarEmpleados();
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
                DialogResult dialogResult = MessageBox.Show("¿Seguro desea modificar los datos del empleado?", "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    band = objetoCN.Modificar(txtNombre, txtCorreo, txtDUI, Genero, Municipio, idUser);
                    if (band)
                    {
                        MessageBox.Show("Empleado modificado correctamente", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MostrarEmpleados();
                        limpiarForm();
                        Editar = false;
                        band = false;
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            CNEmpleado objeto = new CNEmpleado();
            dataGridView1.DataSource = objeto.buscar(txtBusq.Text);
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtDUI_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBusq_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }
    }
}
