using ModeloMemoriaRam.Controlador;
using System;
using System.Windows.Forms;

namespace ModeloMemoriaRam.Vista
{
    public partial class Form1 : Form
    {
        private MemoryController controlador;

        public Form1()
        {
            InitializeComponent();
            controlador = new MemoryController();
            CargarTabla();
        }

        private void CargarTabla()
        {
            dataGridView1.Rows.Clear();
            foreach (var celda in controlador.ObtenerTodaLaMemoria())
            {
                dataGridView1.Rows.Add(celda.Key, celda.Value);
            }
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            string direccion = txtDireccion.Text;

            if (string.IsNullOrWhiteSpace(direccion))
            {
                MessageBox.Show("Ingresa una dirección de memoria.");
                return;
            }

            string valor = controlador.ObtenerValor(direccion);
            if (valor == null)
            {
                MessageBox.Show("Dirección inválida o no encontrada.");
                return;
            }

            // Muestra el valor y actualiza la UI si hace falta
            txtResultado.Text = valor;
            SeleccionarFilaPorDireccion(direccion);
            MessageBox.Show($"Valor leído: {valor}");
        }

        private void btnEscribir_Click(object sender, EventArgs e)
        {
            string direccion = txtDireccion.Text;
            string valor = txtValor.Text;
            if (controlador.AsignarValor(direccion, valor))
            {
                CargarTabla();
                MessageBox.Show("Valor escrito correctamente.");
            }
            else
            {
                MessageBox.Show("Dirección inválida.");
            }
        }

        private void SeleccionarFilaPorDireccion(string direccion)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value?.ToString() == direccion)
                {
                    row.Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }
    }
}
