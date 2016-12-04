namespace Fiori.Windows.VisualProgCNC
{
    partial class frmDefinirEscalaX
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
            this.lblMM = new System.Windows.Forms.Label();
            this.txtMedidaMM = new System.Windows.Forms.TextBox();
            this.lblInformacao = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblEixo = new System.Windows.Forms.Label();
            this.lblEixoValor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMM
            // 
            this.lblMM.AutoSize = true;
            this.lblMM.Location = new System.Drawing.Point(155, 81);
            this.lblMM.Name = "lblMM";
            this.lblMM.Size = new System.Drawing.Size(23, 13);
            this.lblMM.TabIndex = 34;
            this.lblMM.Text = "mm";
            // 
            // txtMedidaMM
            // 
            this.txtMedidaMM.Location = new System.Drawing.Point(80, 78);
            this.txtMedidaMM.MaxLength = 10;
            this.txtMedidaMM.Name = "txtMedidaMM";
            this.txtMedidaMM.Size = new System.Drawing.Size(69, 20);
            this.txtMedidaMM.TabIndex = 33;
            // 
            // lblInformacao
            // 
            this.lblInformacao.AutoSize = true;
            this.lblInformacao.Location = new System.Drawing.Point(12, 50);
            this.lblInformacao.Name = "lblInformacao";
            this.lblInformacao.Size = new System.Drawing.Size(224, 13);
            this.lblInformacao.TabIndex = 36;
            this.lblInformacao.Text = "Digite a medida correspondente em milímetros";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(89, 138);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 37;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblEixo
            // 
            this.lblEixo.AutoSize = true;
            this.lblEixo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEixo.Location = new System.Drawing.Point(12, 9);
            this.lblEixo.Name = "lblEixo";
            this.lblEixo.Size = new System.Drawing.Size(48, 24);
            this.lblEixo.TabIndex = 38;
            this.lblEixo.Text = "Eixo";
            // 
            // lblEixoValor
            // 
            this.lblEixoValor.AutoSize = true;
            this.lblEixoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEixoValor.Location = new System.Drawing.Point(66, 9);
            this.lblEixoValor.Name = "lblEixoValor";
            this.lblEixoValor.Size = new System.Drawing.Size(0, 24);
            this.lblEixoValor.TabIndex = 39;
            // 
            // frmDefinirEscalaX
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 173);
            this.Controls.Add(this.lblEixoValor);
            this.Controls.Add(this.lblEixo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblInformacao);
            this.Controls.Add(this.lblMM);
            this.Controls.Add(this.txtMedidaMM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDefinirEscalaX";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Definir Escala";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMM;
        private System.Windows.Forms.TextBox txtMedidaMM;
        private System.Windows.Forms.Label lblInformacao;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblEixo;
        private System.Windows.Forms.Label lblEixoValor;
    }
}