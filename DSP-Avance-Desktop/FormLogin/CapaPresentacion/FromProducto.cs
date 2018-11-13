using CapaPresentacion;
using FormLogin.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLogin.CapaPresentacion
{
    public partial class FromProducto : Form
    {
        CNProducto producto = new CNProducto();
        private string id = null;
        bool Editar;
        string usuario;
        public FromProducto(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void FromProducto_Load(object sender, EventArgs e)
        {
            label5.Text = usuario;
            mostrar();
            producto.cargarCategoria(cmbCategoria);
            producto.cargarMarca(cmbMarca);
            producto.cargarProveedor(cmbProveedor);
            producto.cargarReceptor(cmbReceptor);
            
        }
        private void mostrar()
        {
            CNProducto objeto = new CNProducto();
            dataGridView1.DataSource = objeto.Mostrar();
        }

        private void limpiarForm()
        {
            txtProducto.Clear();
            txtDescripcion.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            preview.Image = FormLogin.Properties.Resources._default;
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

        private void button3_Click(object sender, EventArgs e)
        {
            subir.ShowDialog(); //Se obtiene la Imagen
            subir.Filter = "JPEG|*.jpg";
            if (subir.FileName != "")
            {
                try
                {
                    preview.Image = Image.FromFile(subir.FileName);
                }
                catch
                {
                    MessageBox.Show("El archivo seleccionado no es valido, seleccione una imagen","Archivo invalido",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool band = false;
            string proveedor = cmbProveedor.SelectedValue.ToString();
            string receptor = cmbReceptor.SelectedValue.ToString();
            string categoria = cmbCategoria.SelectedValue.ToString();
            string marca = cmbMarca.SelectedValue.ToString();
            if (Editar == false)
            {
                band = producto.Insertar(txtProducto,txtDescripcion,preview,proveedor,receptor,categoria,marca,txtCantidad,txtPrecio);
                if (band == true)
                {
                    MessageBox.Show("Producto agregado correctamente", "Adicion completada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                DialogResult dialogResult = MessageBox.Show("Si lo hace los datos actuales se perderan", "¿Seguro desea modificar esta categoria?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    band = producto.Modificar(txtProducto, txtDescripcion, preview, proveedor, receptor, categoria, marca, txtCantidad, txtPrecio, id);
                    if (band == true)
                    {
                        MessageBox.Show("Producto modificado correctamente", "Modificacion completada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                CapaDatos.CDConexion conn = new CapaDatos.CDConexion();
                txtProducto.Text = dataGridView1.CurrentRow.Cells["Producto"].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                cmbProveedor.Text = dataGridView1.CurrentRow.Cells["Proveedor"].Value.ToString();
                cmbReceptor.Text = dataGridView1.CurrentRow.Cells["Receptor"].Value.ToString();
                cmbCategoria.Text = dataGridView1.CurrentRow.Cells["Categoria"].Value.ToString();
                cmbMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio Compra"].Value.ToString();
                txtCantidad.Text = dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString();
                id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();

                SqlCommand comando = new SqlCommand("select imagen from producto where id='" + id + "'", conn.AbrirConexion());
                SqlDataAdapter dp = new SqlDataAdapter(comando);
                DataSet ds = new DataSet("producto");
                dp.Fill(ds, "producto");
                byte[] Datos = new byte[0];
                DataRow DR = ds.Tables["producto"].Rows[0];
                Datos = (byte[])DR["imagen"];
                System.IO.MemoryStream ms = new System.IO.MemoryStream(Datos);
                preview.Image = System.Drawing.Bitmap.FromStream(ms);

                Editar = true;
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Si lo hace todos se borrara el producto permanentemente", "¿Seguro que desea eliminar la el producto?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                    producto.Eliminar(id);
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