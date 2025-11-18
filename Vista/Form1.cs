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
            string valor = controlador.ObtenerValor(direccion);
            if (valor != null)
                MessageBox.Show($"Valor en {direccion}: {valor}");
            else
                MessageBox.Show("Dirección inválida.");
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
    }
}
