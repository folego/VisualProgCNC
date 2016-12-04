namespace Fiori.Windows.VisualProgCNC
{
    partial class frmOperacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpOperacoes = new System.Windows.Forms.GroupBox();
            this.dgdOperacao = new System.Windows.Forms.DataGridView();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnGerarPrograma = new System.Windows.Forms.Button();
            this.grpOperacoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdOperacao)).BeginInit();
            this.SuspendLayout();
            // 
            // grpOperacoes
            // 
            this.grpOperacoes.Controls.Add(this.dgdOperacao);
            this.grpOperacoes.Location = new System.Drawing.Point(12, 12);
            this.grpOperacoes.Name = "grpOperacoes";
            this.grpOperacoes.Size = new System.Drawing.Size(831, 477);
            this.grpOperacoes.TabIndex = 11;
            this.grpOperacoes.TabStop = false;
            this.grpOperacoes.Text = "Operações";
            // 
            // dgdOperacao
            // 
            this.dgdOperacao.AllowUserToAddRows = false;
            this.dgdOperacao.AllowUserToResizeRows = false;
            this.dgdOperacao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgdOperacao.ColumnHeadersHeight = 22;
            this.dgdOperacao.Location = new System.Drawing.Point(6, 15);
            this.dgdOperacao.MultiSelect = false;
            this.dgdOperacao.Name = "dgdOperacao";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdOperacao.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgdOperacao.RowHeadersWidth = 25;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgdOperacao.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgdOperacao.Size = new System.Drawing.Size(819, 456);
            this.dgdOperacao.TabIndex = 11;
            this.dgdOperacao.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgdOperacao_CellEndEdit);
            this.dgdOperacao.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgdOperacao_DataBindingComplete);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(495, 495);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 38;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnGerarPrograma
            // 
            this.btnGerarPrograma.Location = new System.Drawing.Point(285, 495);
            this.btnGerarPrograma.Name = "btnGerarPrograma";
            this.btnGerarPrograma.Size = new System.Drawing.Size(108, 23);
            this.btnGerarPrograma.TabIndex = 39;
            this.btnGerarPrograma.Text = "Gerar Programa";
            this.btnGerarPrograma.UseVisualStyleBackColor = true;
            this.btnGerarPrograma.Click += new System.EventHandler(this.btnGerarPrograma_Click);
            // 
            // frmOperacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 530);
            this.Controls.Add(this.btnGerarPrograma);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.grpOperacoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOperacao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Operações Cadastradas";
            this.Activated += new System.EventHandler(this.frmOperacao_Activated);
            this.grpOperacoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgdOperacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpOperacoes;
        private System.Windows.Forms.DataGridView dgdOperacao;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnGerarPrograma;

    }
}