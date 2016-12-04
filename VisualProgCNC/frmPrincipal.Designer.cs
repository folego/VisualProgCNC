namespace Fiori.Windows.VisualProgCNC
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.grpImagem = new System.Windows.Forms.GroupBox();
            this.pnlImagem = new System.Windows.Forms.Panel();
            this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.tsmArquivo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiAbrirImagem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsiAbrirProjeto = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiSalvar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiFecharProjeto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsiSair = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEscala = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiDefinirEscalaX = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiDefinirEscalaY = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPontoZero = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiRedefinirPontoZero = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProgramacao = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiVisualizarPrograma = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFerramentas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiFresarRaio = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiTamanhoFresaRaio = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsiRaio = new System.Windows.Forms.ToolStripTextBox();
            this.tsiFresar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiTamanhoFresa = new System.Windows.Forms.ToolStripTextBox();
            this.tsiFurar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiTamanhoBroca = new System.Windows.Forms.ToolStripTextBox();
            this.tsiRoscar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiTamanhoMacho = new System.Windows.Forms.ToolStripTextBox();
            this.imagemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiGirarDireita = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiGirarEsquerda = new System.Windows.Forms.ToolStripMenuItem();
            this.sstStatus = new System.Windows.Forms.StatusStrip();
            this.tlbInformacao = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlbFerramenta = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlbFerramentaValor = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlbPosicao = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlbPosicaoX = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlbX = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlbPosicaoY = new System.Windows.Forms.ToolStripStatusLabel();
            this.tblEscalaX = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlbEscalaXValor = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlbEscalaY = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlbEscalaYValor = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpQuickStart = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grpImagem.SuspendLayout();
            this.mnuPrincipal.SuspendLayout();
            this.sstStatus.SuspendLayout();
            this.grpQuickStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpImagem
            // 
            this.grpImagem.Controls.Add(this.pnlImagem);
            this.grpImagem.Location = new System.Drawing.Point(12, 28);
            this.grpImagem.Name = "grpImagem";
            this.grpImagem.Size = new System.Drawing.Size(1000, 682);
            this.grpImagem.TabIndex = 6;
            this.grpImagem.TabStop = false;
            this.grpImagem.Text = "Imagem";
            // 
            // pnlImagem
            // 
            this.pnlImagem.BackColor = System.Drawing.Color.Black;
            this.pnlImagem.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pnlImagem.Location = new System.Drawing.Point(6, 19);
            this.pnlImagem.Name = "pnlImagem";
            this.pnlImagem.Size = new System.Drawing.Size(988, 657);
            this.pnlImagem.TabIndex = 9;
            this.pnlImagem.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlImagem_Paint);
            this.pnlImagem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlImagem_MouseDown);
            this.pnlImagem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlImagem_MouseMove);
            this.pnlImagem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlImagem_MouseUp);
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmArquivo,
            this.tsmEscala,
            this.tsmPontoZero,
            this.tsmProgramacao,
            this.tsmFerramentas,
            this.imagemToolStripMenuItem});
            this.mnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnuPrincipal.Name = "mnuPrincipal";
            this.mnuPrincipal.Size = new System.Drawing.Size(1239, 24);
            this.mnuPrincipal.TabIndex = 20;
            this.mnuPrincipal.Text = "menuStrip1";
            // 
            // tsmArquivo
            // 
            this.tsmArquivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiAbrirImagem,
            this.toolStripSeparator2,
            this.tsiAbrirProjeto,
            this.tsiSalvar,
            this.tsiFecharProjeto,
            this.toolStripSeparator3,
            this.tsiSair});
            this.tsmArquivo.Name = "tsmArquivo";
            this.tsmArquivo.Size = new System.Drawing.Size(61, 20);
            this.tsmArquivo.Text = "Arquivo";
            // 
            // tsiAbrirImagem
            // 
            this.tsiAbrirImagem.Name = "tsiAbrirImagem";
            this.tsiAbrirImagem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.tsiAbrirImagem.Size = new System.Drawing.Size(198, 22);
            this.tsiAbrirImagem.Text = "Abrir Imagem...";
            this.tsiAbrirImagem.Click += new System.EventHandler(this.tsiAbrirImagem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(195, 6);
            // 
            // tsiAbrirProjeto
            // 
            this.tsiAbrirProjeto.Name = "tsiAbrirProjeto";
            this.tsiAbrirProjeto.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.tsiAbrirProjeto.Size = new System.Drawing.Size(198, 22);
            this.tsiAbrirProjeto.Text = "Abrir Projeto...";
            this.tsiAbrirProjeto.Click += new System.EventHandler(this.tsiAbrirProjeto_Click);
            // 
            // tsiSalvar
            // 
            this.tsiSalvar.Name = "tsiSalvar";
            this.tsiSalvar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsiSalvar.Size = new System.Drawing.Size(198, 22);
            this.tsiSalvar.Text = "Salvar";
            this.tsiSalvar.Click += new System.EventHandler(this.tsiSalvar_Click);
            // 
            // tsiFecharProjeto
            // 
            this.tsiFecharProjeto.Name = "tsiFecharProjeto";
            this.tsiFecharProjeto.Size = new System.Drawing.Size(198, 22);
            this.tsiFecharProjeto.Text = "Fechar Projeto";
            this.tsiFecharProjeto.Click += new System.EventHandler(this.tsiFecharProjeto_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(195, 6);
            // 
            // tsiSair
            // 
            this.tsiSair.Name = "tsiSair";
            this.tsiSair.Size = new System.Drawing.Size(198, 22);
            this.tsiSair.Text = "Sair";
            this.tsiSair.Click += new System.EventHandler(this.tsiSair_Click);
            // 
            // tsmEscala
            // 
            this.tsmEscala.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiDefinirEscalaX,
            this.tsiDefinirEscalaY});
            this.tsmEscala.Name = "tsmEscala";
            this.tsmEscala.Size = new System.Drawing.Size(51, 20);
            this.tsmEscala.Text = "Escala";
            // 
            // tsiDefinirEscalaX
            // 
            this.tsiDefinirEscalaX.Name = "tsiDefinirEscalaX";
            this.tsiDefinirEscalaX.Size = new System.Drawing.Size(163, 22);
            this.tsiDefinirEscalaX.Text = "Definir Escala X...";
            this.tsiDefinirEscalaX.Click += new System.EventHandler(this.tsiDefinirEscalaX_Click);
            // 
            // tsiDefinirEscalaY
            // 
            this.tsiDefinirEscalaY.Name = "tsiDefinirEscalaY";
            this.tsiDefinirEscalaY.Size = new System.Drawing.Size(163, 22);
            this.tsiDefinirEscalaY.Text = "Definir Escala Y...";
            this.tsiDefinirEscalaY.Click += new System.EventHandler(this.tsiDefinirEscalaY_Click);
            // 
            // tsmPontoZero
            // 
            this.tsmPontoZero.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiRedefinirPontoZero});
            this.tsmPontoZero.Name = "tsmPontoZero";
            this.tsmPontoZero.Size = new System.Drawing.Size(78, 20);
            this.tsmPontoZero.Text = "Ponto Zero";
            // 
            // tsiRedefinirPontoZero
            // 
            this.tsiRedefinirPontoZero.CheckOnClick = true;
            this.tsiRedefinirPontoZero.Name = "tsiRedefinirPontoZero";
            this.tsiRedefinirPontoZero.Size = new System.Drawing.Size(183, 22);
            this.tsiRedefinirPontoZero.Text = "Redefinir Ponto Zero";
            // 
            // tsmProgramacao
            // 
            this.tsmProgramacao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiVisualizarPrograma});
            this.tsmProgramacao.Name = "tsmProgramacao";
            this.tsmProgramacao.Size = new System.Drawing.Size(90, 20);
            this.tsmProgramacao.Text = "Programação";
            // 
            // tsiVisualizarPrograma
            // 
            this.tsiVisualizarPrograma.Name = "tsiVisualizarPrograma";
            this.tsiVisualizarPrograma.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.tsiVisualizarPrograma.Size = new System.Drawing.Size(220, 22);
            this.tsiVisualizarPrograma.Text = "Visualizar Programa";
            this.tsiVisualizarPrograma.Click += new System.EventHandler(this.tsiVisualizarPrograma_Click);
            // 
            // tsmFerramentas
            // 
            this.tsmFerramentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiFresarRaio,
            this.tsiFresar,
            this.tsiFurar,
            this.tsiRoscar});
            this.tsmFerramentas.Name = "tsmFerramentas";
            this.tsmFerramentas.Size = new System.Drawing.Size(84, 20);
            this.tsmFerramentas.Text = "Ferramentas";
            // 
            // tsiFresarRaio
            // 
            this.tsiFresarRaio.CheckOnClick = true;
            this.tsiFresarRaio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiTamanhoFresaRaio,
            this.toolStripSeparator1,
            this.tsiRaio});
            this.tsiFresarRaio.Name = "tsiFresarRaio";
            this.tsiFresarRaio.Size = new System.Drawing.Size(158, 22);
            this.tsiFresarRaio.Text = "Fresar com Raio";
            this.tsiFresarRaio.Click += new System.EventHandler(this.tsiFresarRaio_Click);
            // 
            // tsiTamanhoFresaRaio
            // 
            this.tsiTamanhoFresaRaio.AutoSize = false;
            this.tsiTamanhoFresaRaio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsiTamanhoFresaRaio.MaxLength = 25;
            this.tsiTamanhoFresaRaio.Name = "tsiTamanhoFresaRaio";
            this.tsiTamanhoFresaRaio.Size = new System.Drawing.Size(150, 23);
            this.tsiTamanhoFresaRaio.TextChanged += new System.EventHandler(this.tsiTamanhoFresaRaio_TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // tsiRaio
            // 
            this.tsiRaio.AutoSize = false;
            this.tsiRaio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsiRaio.MaxLength = 3;
            this.tsiRaio.Name = "tsiRaio";
            this.tsiRaio.Size = new System.Drawing.Size(50, 23);
            this.tsiRaio.TextChanged += new System.EventHandler(this.tsiRaio_TextChanged);
            // 
            // tsiFresar
            // 
            this.tsiFresar.CheckOnClick = true;
            this.tsiFresar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiTamanhoFresa});
            this.tsiFresar.Name = "tsiFresar";
            this.tsiFresar.Size = new System.Drawing.Size(158, 22);
            this.tsiFresar.Text = "Fresar";
            this.tsiFresar.Click += new System.EventHandler(this.tsiFresar_Click);
            // 
            // tsiTamanhoFresa
            // 
            this.tsiTamanhoFresa.AutoSize = false;
            this.tsiTamanhoFresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsiTamanhoFresa.MaxLength = 25;
            this.tsiTamanhoFresa.Name = "tsiTamanhoFresa";
            this.tsiTamanhoFresa.Size = new System.Drawing.Size(150, 23);
            this.tsiTamanhoFresa.TextChanged += new System.EventHandler(this.tsiTamanhoFresa_TextChanged);
            // 
            // tsiFurar
            // 
            this.tsiFurar.CheckOnClick = true;
            this.tsiFurar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiTamanhoBroca});
            this.tsiFurar.Name = "tsiFurar";
            this.tsiFurar.Size = new System.Drawing.Size(158, 22);
            this.tsiFurar.Text = "Furar";
            this.tsiFurar.Click += new System.EventHandler(this.tsiFurar_Click);
            // 
            // tsiTamanhoBroca
            // 
            this.tsiTamanhoBroca.AutoSize = false;
            this.tsiTamanhoBroca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsiTamanhoBroca.MaxLength = 25;
            this.tsiTamanhoBroca.Name = "tsiTamanhoBroca";
            this.tsiTamanhoBroca.Size = new System.Drawing.Size(150, 23);
            this.tsiTamanhoBroca.TextChanged += new System.EventHandler(this.tsiTamanhoBroca_TextChanged);
            // 
            // tsiRoscar
            // 
            this.tsiRoscar.CheckOnClick = true;
            this.tsiRoscar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiTamanhoMacho});
            this.tsiRoscar.Name = "tsiRoscar";
            this.tsiRoscar.Size = new System.Drawing.Size(158, 22);
            this.tsiRoscar.Text = "Roscar";
            this.tsiRoscar.Click += new System.EventHandler(this.tsiRoscar_Click);
            // 
            // tsiTamanhoMacho
            // 
            this.tsiTamanhoMacho.AutoSize = false;
            this.tsiTamanhoMacho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsiTamanhoMacho.MaxLength = 25;
            this.tsiTamanhoMacho.Name = "tsiTamanhoMacho";
            this.tsiTamanhoMacho.Size = new System.Drawing.Size(150, 23);
            this.tsiTamanhoMacho.TextChanged += new System.EventHandler(this.tsiTamanhoMacho_TextChanged);
            // 
            // imagemToolStripMenuItem
            // 
            this.imagemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiGirarDireita,
            this.tsiGirarEsquerda});
            this.imagemToolStripMenuItem.Name = "imagemToolStripMenuItem";
            this.imagemToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.imagemToolStripMenuItem.Text = "Imagem";
            // 
            // tsiGirarDireita
            // 
            this.tsiGirarDireita.Name = "tsiGirarDireita";
            this.tsiGirarDireita.Size = new System.Drawing.Size(159, 22);
            this.tsiGirarDireita.Text = "Girar a Direita";
            this.tsiGirarDireita.Click += new System.EventHandler(this.tsiGirarDireita_Click);
            // 
            // tsiGirarEsquerda
            // 
            this.tsiGirarEsquerda.Name = "tsiGirarEsquerda";
            this.tsiGirarEsquerda.Size = new System.Drawing.Size(159, 22);
            this.tsiGirarEsquerda.Text = "Girar a Esquerda";
            this.tsiGirarEsquerda.Click += new System.EventHandler(this.tsiGirarEsquerda_Click);
            // 
            // sstStatus
            // 
            this.sstStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlbInformacao,
            this.tlbFerramenta,
            this.tlbFerramentaValor,
            this.tlbPosicao,
            this.tlbPosicaoX,
            this.tlbX,
            this.tlbPosicaoY,
            this.tblEscalaX,
            this.tlbEscalaXValor,
            this.tlbEscalaY,
            this.tlbEscalaYValor});
            this.sstStatus.Location = new System.Drawing.Point(0, 719);
            this.sstStatus.Name = "sstStatus";
            this.sstStatus.Size = new System.Drawing.Size(1239, 22);
            this.sstStatus.TabIndex = 21;
            // 
            // tlbInformacao
            // 
            this.tlbInformacao.AutoSize = false;
            this.tlbInformacao.BackColor = System.Drawing.Color.Transparent;
            this.tlbInformacao.Name = "tlbInformacao";
            this.tlbInformacao.Size = new System.Drawing.Size(320, 17);
            this.tlbInformacao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlbFerramenta
            // 
            this.tlbFerramenta.AutoSize = false;
            this.tlbFerramenta.BackColor = System.Drawing.Color.Transparent;
            this.tlbFerramenta.Name = "tlbFerramenta";
            this.tlbFerramenta.Size = new System.Drawing.Size(80, 17);
            this.tlbFerramenta.Text = "Ferramenta";
            this.tlbFerramenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlbFerramentaValor
            // 
            this.tlbFerramentaValor.AutoSize = false;
            this.tlbFerramentaValor.BackColor = System.Drawing.Color.Transparent;
            this.tlbFerramentaValor.Name = "tlbFerramentaValor";
            this.tlbFerramentaValor.Size = new System.Drawing.Size(130, 17);
            this.tlbFerramentaValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlbPosicao
            // 
            this.tlbPosicao.AutoSize = false;
            this.tlbPosicao.BackColor = System.Drawing.Color.Transparent;
            this.tlbPosicao.Name = "tlbPosicao";
            this.tlbPosicao.Size = new System.Drawing.Size(40, 17);
            this.tlbPosicao.Text = "Posição";
            // 
            // tlbPosicaoX
            // 
            this.tlbPosicaoX.AutoSize = false;
            this.tlbPosicaoX.BackColor = System.Drawing.Color.Transparent;
            this.tlbPosicaoX.Name = "tlbPosicaoX";
            this.tlbPosicaoX.Size = new System.Drawing.Size(70, 17);
            this.tlbPosicaoX.Text = "0,00 mm";
            this.tlbPosicaoX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tlbX
            // 
            this.tlbX.AutoSize = false;
            this.tlbX.BackColor = System.Drawing.Color.Transparent;
            this.tlbX.Name = "tlbX";
            this.tlbX.Size = new System.Drawing.Size(15, 17);
            this.tlbX.Text = "x";
            // 
            // tlbPosicaoY
            // 
            this.tlbPosicaoY.AutoSize = false;
            this.tlbPosicaoY.BackColor = System.Drawing.Color.Transparent;
            this.tlbPosicaoY.Name = "tlbPosicaoY";
            this.tlbPosicaoY.Size = new System.Drawing.Size(80, 17);
            this.tlbPosicaoY.Text = "0,00 mm";
            this.tlbPosicaoY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tblEscalaX
            // 
            this.tblEscalaX.AutoSize = false;
            this.tblEscalaX.BackColor = System.Drawing.Color.Transparent;
            this.tblEscalaX.Name = "tblEscalaX";
            this.tblEscalaX.Size = new System.Drawing.Size(55, 17);
            this.tblEscalaX.Text = "Escala X";
            // 
            // tlbEscalaXValor
            // 
            this.tlbEscalaXValor.AutoSize = false;
            this.tlbEscalaXValor.BackColor = System.Drawing.Color.Transparent;
            this.tlbEscalaXValor.Name = "tlbEscalaXValor";
            this.tlbEscalaXValor.Size = new System.Drawing.Size(90, 17);
            this.tlbEscalaXValor.Text = "0,000 mm / px";
            this.tlbEscalaXValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlbEscalaY
            // 
            this.tlbEscalaY.AutoSize = false;
            this.tlbEscalaY.BackColor = System.Drawing.Color.Transparent;
            this.tlbEscalaY.Name = "tlbEscalaY";
            this.tlbEscalaY.Size = new System.Drawing.Size(55, 17);
            this.tlbEscalaY.Text = "Escala Y";
            // 
            // tlbEscalaYValor
            // 
            this.tlbEscalaYValor.AutoSize = false;
            this.tlbEscalaYValor.BackColor = System.Drawing.Color.Transparent;
            this.tlbEscalaYValor.Name = "tlbEscalaYValor";
            this.tlbEscalaYValor.Size = new System.Drawing.Size(90, 17);
            this.tlbEscalaYValor.Text = "0,000 mm / px";
            this.tlbEscalaYValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpQuickStart
            // 
            this.grpQuickStart.Controls.Add(this.textBox1);
            this.grpQuickStart.Location = new System.Drawing.Point(1018, 28);
            this.grpQuickStart.Name = "grpQuickStart";
            this.grpQuickStart.Size = new System.Drawing.Size(208, 266);
            this.grpQuickStart.TabIndex = 22;
            this.grpQuickStart.TabStop = false;
            this.grpQuickStart.Text = "Quick Start";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(196, 241);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1239, 741);
            this.Controls.Add(this.grpQuickStart);
            this.Controls.Add(this.sstStatus);
            this.Controls.Add(this.mnuPrincipal);
            this.Controls.Add(this.grpImagem);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "VisualProgCNC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrincipal_FormClosed);
            this.grpImagem.ResumeLayout(false);
            this.mnuPrincipal.ResumeLayout(false);
            this.mnuPrincipal.PerformLayout();
            this.sstStatus.ResumeLayout(false);
            this.sstStatus.PerformLayout();
            this.grpQuickStart.ResumeLayout(false);
            this.grpQuickStart.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpImagem;
        private System.Windows.Forms.Panel pnlImagem;
        private System.Windows.Forms.MenuStrip mnuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem tsmArquivo;
        private System.Windows.Forms.ToolStripMenuItem tsiAbrirImagem;
        private System.Windows.Forms.ToolStripMenuItem tsiSair;
        private System.Windows.Forms.ToolStripMenuItem tsmPontoZero;
        private System.Windows.Forms.ToolStripMenuItem tsiRedefinirPontoZero;
        private System.Windows.Forms.ToolStripMenuItem tsmProgramacao;
        private System.Windows.Forms.ToolStripMenuItem tsiVisualizarPrograma;
        private System.Windows.Forms.StatusStrip sstStatus;
        private System.Windows.Forms.ToolStripStatusLabel tlbInformacao;
        private System.Windows.Forms.ToolStripStatusLabel tlbPosicaoX;
        private System.Windows.Forms.ToolStripStatusLabel tlbPosicao;
        private System.Windows.Forms.ToolStripStatusLabel tlbX;
        private System.Windows.Forms.ToolStripStatusLabel tlbPosicaoY;
        private System.Windows.Forms.ToolStripMenuItem tsmEscala;
        private System.Windows.Forms.ToolStripMenuItem tsiDefinirEscalaX;
        private System.Windows.Forms.ToolStripMenuItem tsiDefinirEscalaY;
        private System.Windows.Forms.ToolStripStatusLabel tblEscalaX;
        private System.Windows.Forms.ToolStripStatusLabel tlbEscalaXValor;
        private System.Windows.Forms.ToolStripStatusLabel tlbEscalaY;
        private System.Windows.Forms.ToolStripStatusLabel tlbEscalaYValor;
        private System.Windows.Forms.ToolStripMenuItem tsmFerramentas;
        private System.Windows.Forms.ToolStripMenuItem tsiFresar;
        private System.Windows.Forms.ToolStripMenuItem tsiFurar;
        private System.Windows.Forms.ToolStripMenuItem tsiRoscar;
        private System.Windows.Forms.ToolStripStatusLabel tlbFerramenta;
        private System.Windows.Forms.ToolStripStatusLabel tlbFerramentaValor;
        private System.Windows.Forms.ToolStripTextBox tsiTamanhoFresa;
        private System.Windows.Forms.ToolStripTextBox tsiTamanhoBroca;
        private System.Windows.Forms.ToolStripTextBox tsiTamanhoMacho;
        private System.Windows.Forms.ToolStripMenuItem tsiFresarRaio;
        private System.Windows.Forms.ToolStripTextBox tsiTamanhoFresaRaio;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox tsiRaio;
        private System.Windows.Forms.ToolStripMenuItem tsiSalvar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsiAbrirProjeto;
        private System.Windows.Forms.ToolStripMenuItem imagemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsiGirarDireita;
        private System.Windows.Forms.ToolStripMenuItem tsiGirarEsquerda;
        private System.Windows.Forms.ToolStripMenuItem tsiFecharProjeto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.GroupBox grpQuickStart;
        private System.Windows.Forms.TextBox textBox1;
    }
}

