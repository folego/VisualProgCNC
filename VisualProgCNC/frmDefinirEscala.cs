using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fiori.Windows.VisualProgCNC.Classes;

namespace Fiori.Windows.VisualProgCNC
{
    public partial class frmDefinirEscalaX : Form
    {
        public frmDefinirEscalaX()
        {
            InitializeComponent();
            lblEixoValor.Text = Geral.Eixo;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtMedidaMM.Text.Trim() != string.Empty)
            {
                try
                {
                    if (Geral.Eixo == "X")
                        Geral.MedidaMMCalcularEscalaX = Convert.ToDouble(txtMedidaMM.Text);
                    else if (Geral.Eixo == "Y")
                        Geral.MedidaMMCalcularEscalaY = Convert.ToDouble(txtMedidaMM.Text);
                    Geral.Eixo = null;
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Digite um número válido", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("Digite um número válido", "Aviso");
            }
        }
    }
}