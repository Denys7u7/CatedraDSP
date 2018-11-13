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
    public partial class FormUsuario : Form
    {
        CNUsuario objetoCN = new CNUsuario();
        private string idUser = null;
        string Tipo;
        string Empleado;
        string usuario;
        private bool Editar = false;
        public FormUsuario(string usuario)
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
                DialogResult dialogResult = MessageBox.Show("¿Seguro que desea eliminar al usuario?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    idUser = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                    objetoCN.Eliminar(idUser);
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
                txtUsuario.Text = dataGridView1.CurrentRow.Cells["Usuario"].Value.ToString();
                txtPass.Text = dataGridView1.CurrentRow.Cells["Contraseña"].Value.ToString();
                cmbEmpleado.Text = dataGridView1.CurrentRow.Cells["Empleado"].Value.ToString();
                cmbTipos.Text = dataGridView1.CurrentRow.Cells["Tipo de usuario"].Value.ToString();
                idUser = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Tipo = cmbTipos.SelectedValue.ToString();
            Empleado = cmbEmpleado.SelectedValue.ToString();

            bool band = false;

            if (!Editar)
            {
                band = objetoCN.Insertar(txtUsuario, txtPass, Tipo, Empleado);
                if (band)
                {
                    MessageBox.Show("Usuario Agregado correctamente", "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MostrarUser();
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
                DialogResult dialogResult = MessageBox.Show("¿Seguro desea modificar los datos del usuario?", "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    band = objetoCN.Modificar(txtUsuario, txtPass, Tipo, Empleado, idUser);
                    if (band)
                    {
                        MessageBox.Show("Usuario modificado correctamente", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MostrarUser();
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

        private void limpiarForm()
        {
            txtUsuario.Clear();
            txtPass.Clear();
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
            objetoCN.cargarEmpleados(cmbEmpleado);
            objetoCN.cargarTipos(cmbTipos);
            label5.Text = usuario;
        }

        private void MostrarUser()
        {
            CNUsuario objeto = new CNUsuario();
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

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
            Tipo = cmbTipos.SelectedValue.ToString();
            Empleado = cmbEmpleado.SelectedValue.ToString();

            bool band = false;

            if (Editar == false)
            {
                band = objetoCN.Insertar(txtUsuario, txtPass, Tipo, Empleado);
                if (band == true)
                {
                    MessageBox.Show("Usuario Agregado correctamente", "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MostrarUser();
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
                DialogResult dialogResult = MessageBox.Show("¿Seguro desea modificar los datos del usuario?", "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    band = objetoCN.Modificar(txtUsuario, txtPass, Tipo, Empleado, idUser);
                    if (band == true)
                    {
                        MessageBox.Show("Usuario modificado correctamente", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MostrarUser();
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
            CNUsuario objeto = new CNUsuario();
            dataGridView1.DataSource = objeto.Buscar(txtBusq);
        }
    }
}
