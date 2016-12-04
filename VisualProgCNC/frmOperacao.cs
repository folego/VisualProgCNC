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
    public partial class frmOperacao : Form
    {
        #region Contrutor
        public frmOperacao()
        {
            InitializeComponent();
        }
        #endregion

        #region frmOperacao_Activated
        private void frmOperacao_Activated(object sender, EventArgs e)
        {
            dgdOperacao.DataSource = Geral.TabelaOperacoes;
        }
        #endregion

        #region btnOK_Click
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region dgdOperacao_DataBindingComplete
        private void dgdOperacao_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (Geral.TabelaOperacoes.Rows.Count > 0)
            {
                dgdOperacao.Columns[1].Visible = false;
                dgdOperacao.Columns[9].Visible = false;
                dgdOperacao.Columns[10].Visible = false;
                dgdOperacao.Columns[11].Visible = false;
                dgdOperacao.Columns[12].Visible = false;

                // Retirar a opção de ordenaçãode todas as colunas exceto a primeira
                int _numeroColunas = dgdOperacao.Columns.Count;
                int _cont;
                for (_cont = 1; _cont < _numeroColunas; _cont++)
                {
                    dgdOperacao.Columns[_cont].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }
        #endregion

        #region btnGerarPrograma_Click
        private void btnGerarPrograma_Click(object sender, EventArgs e)
        {
            // Gerar programa NC (será armazenado na memória)
            GeradorProgramaNC _geradorPrograma = new GeradorProgramaNC();
            _geradorPrograma.GerarPrograma();

            // Iniciar o Notepad para edição do programa
            System.Diagnostics.Process.Start("notepad.exe");

            MessageBox.Show("Cole o programa e faça os ajustes necessários");

            // MELHORIA: Criar um editor com cores para cada tipo de operação
        }

        #endregion

        #region dgdOperacao_CellEndEdit
        private void dgdOperacao_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Atualizar as medidas de x e y (pixels) para redesenhar nas posições corretas

            // Verificar se a coluna é relativa a posição de X
            if (e.ColumnIndex == 5)
            {
                // Buscar a linha e atualizar o valor da posição do x em pixels
                DataRow _linha = Geral.TabelaOperacoes.Rows[e.RowIndex];
                _linha[9] = Convert.ToInt32((Convert.ToDouble(_linha[5].ToString()) + (Geral.PontoZero.X * Geral.EscalaX)) / Geral.EscalaX);
            }
            else if (e.ColumnIndex == 6)
            {
                // Buscar a linha e atualizar o valor da posição do x em pixels
                DataRow _linha = Geral.TabelaOperacoes.Rows[e.RowIndex];
                _linha[10] = Convert.ToInt32((Convert.ToDouble(_linha[6].ToString()) + (Geral.PontoZero.X * Geral.EscalaX)) / Geral.EscalaX);
            }

            // Verificar se a coluna é relativa a posição de Y
            if (e.ColumnIndex == 7)
            {
                // Buscar a linha e atualizar o valor da posição do x em pixels
                DataRow _linha = Geral.TabelaOperacoes.Rows[e.RowIndex];
                _linha[11] = Convert.ToInt32((-Convert.ToDouble(_linha[7].ToString()) + (Geral.PontoZero.Y * Geral.EscalaY)) / Geral.EscalaY);
            }
            else if (e.ColumnIndex == 8)
            {
                // Buscar a linha e atualizar o valor da posição do x em pixels
                DataRow _linha = Geral.TabelaOperacoes.Rows[e.RowIndex];
                _linha[12] = Convert.ToInt32((-Convert.ToDouble(_linha[8].ToString()) + (Geral.PontoZero.Y * Geral.EscalaY)) / Geral.EscalaY);
            }



        }
        #endregion
    }
}