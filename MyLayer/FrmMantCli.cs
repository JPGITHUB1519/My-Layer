using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Data;

namespace MyLayer
{
    public partial class FrmMantCli : Form
    {
        public FrmMantCli()
        {
            InitializeComponent();
        }

        Cliente cliente = new Cliente();

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cliente.Idcliente = Convert.ToInt32(txtidcliente.Text.Trim());
            cliente.Nombre = txtnombre.Text.Trim();
            cliente.Apellido = txtapellido.Text.Trim();
            cliente.Telefono = txtnombre.Text.Trim();
            cliente.Direccion = txtdireccion.Text.Trim();
            cliente.Email = txtdireccion.Text.Trim();
            cliente.Act_Cliente(cliente);
        }

        private void FrmMantCli_Load(object sender, EventArgs e)
        {

        }
    }
}
