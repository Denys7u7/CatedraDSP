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
    public partial class FormInventario : Form
    {
        CNProductos objetoCN = new CNProductos();
        private string idProducto = null;
        private bool Editar = false;

        public FormInventario()
        {
            InitializeComponent();
        }

        private void FormInventario_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            CNProductos objeto = new CNProductos();
            dataGridView1.DataSource = objeto.MostrarProd();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Editar)
            {
                try
                {
                    objetoCN.InsertarPRod(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtCantidad.Text, txtCategoria.Text);
                    MessageBox.Show("Producto Agregado correctamente", "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MostrarProductos();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo insertar los datos por: " + ex);
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("¿Realizar modificacion del producto?", "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        objetoCN.EditarProd(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtCategoria.Text, txtPrecio.Text, txtCantidad.Text, idProducto);
                        MessageBox.Show("Producto modificado correctamente", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MostrarProductos();
                        limpiarForm();
                        Editar = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("no se pudo insertar los datos por: " + ex);
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
                Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtCategoria.Text = dataGridView1.CurrentRow.Cells["categoria"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["marca"].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtCantidad.Text = dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }
        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("¿Seguro quiere borrar el producto?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    idProducto = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                    objetoCN.EliminarProd(idProducto);
                    MostrarProductos();
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void limpiarForm()
        {
            txtDescripcion.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
            txtNombre.Clear();
            txtCategoria.Clear();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain frm = new FormMain();
            this.Dispose();
            frm.Show();
        }
    }
}
