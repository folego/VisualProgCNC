using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fiori.Windows.VisualProgCNC.Classes;
using System.Runtime.InteropServices;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;

namespace Fiori.Windows.VisualProgCNC
{
    public partial class frmPrincipal : Form
    {
        #region API
        // Usar GDI+ para criar uma linha "apagável"
        class GDI32_DLL
        {
            [DllImport("gdi32.dll")]
            public static extern bool LineTo(IntPtr HDC, int x, int y);
            [DllImport("gdi32.dll")]
            public static extern bool SetROP2(IntPtr HDC, int drawMode);
            [DllImport("gdi32.dll")]
            public static extern bool MoveToEx(IntPtr HDC, int x, int y, IntPtr lpPoint);
        }
        #endregion

        #region Variáveis
        bool _desenhar = false;
        Point _posicaoInicialCursor = Point.Empty;
        Point _ultimaPosicaoInicialLinha = Point.Empty;
        #endregion

        #region frmPrincipal
        public frmPrincipal()
        {
            InitializeComponent();
        }
        #endregion

        #region Mouse - Eventos

        #region pnlImagem_MouseMove
        private void pnlImagem_MouseMove(object sender, MouseEventArgs e)
        {
            if (_desenhar)
            {
                // Verificar o tipo de operação exibe ou não a linha
                bool _exibirLinha = true;

                if (Geral.CodigoTipoOperacao != null)
                {
                    if (Geral.CodigoTipoOperacao > 2)
                        _exibirLinha = false;
                }

                if (_exibirLinha)
                {
                    Graphics _graficos = pnlImagem.CreateGraphics();

                    // Get Device context of form 
                    IntPtr HDC = _graficos.GetHdc();

                    // Use XOR Pen 
                    GDI32_DLL.SetROP2(HDC, 6);

                    // Apaga a linha anterior
                    if (_ultimaPosicaoInicialLinha != Point.Empty)
                    {
                        GDI32_DLL.MoveToEx(HDC, _posicaoInicialCursor.X, _posicaoInicialCursor.Y, IntPtr.Zero);
                        GDI32_DLL.LineTo(HDC, _ultimaPosicaoInicialLinha.X, _ultimaPosicaoInicialLinha.Y);
                    }

                    // Desenha a linha atual
                    GDI32_DLL.MoveToEx(HDC, _posicaoInicialCursor.X, _posicaoInicialCursor.Y, IntPtr.Zero);
                    GDI32_DLL.LineTo(HDC, e.X, e.Y);

                    // Release Device context 
                    _graficos.ReleaseHdc(HDC);

                    #region Versão Antiga
                    // Apaga a linha anterior
                    //Pen _apagador = new Pen(Color.White, 1);
                    //_graficos.DrawLine(_apagador, _posicaoInicialCursor, _ultimaPosicaoInicialLinha);

                    // Mostra a linha atual
                    //Pen _caneta = new Pen(Color.Red, 1);
                    //_graficos.DrawLine(_caneta, _posicaoInicialCursor, e.Location);
                    #endregion

                    _ultimaPosicaoInicialLinha = e.Location;
                }
            }

            // Atualizar informação de posição
            if (Geral.EscalaX != null && Geral.EscalaY != null)
            {
                // Atualizar informação de posição do cursor de acordo com a escala na barra de status
                double _posicaoXmm = (e.X - Geral.PontoZero.X) * Geral.EscalaX.Value;
                double _posicaoYmm = -(e.Y - Geral.PontoZero.Y) * Geral.EscalaY.Value;
                tlbPosicaoX.Text = _posicaoXmm.ToString("0.00") + " mm";
                tlbPosicaoY.Text = _posicaoYmm.ToString("0.00") + " mm";
            }

        }
        #endregion

        #region pnlImagem_MouseDown
        private void pnlImagem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Verifica se o usuário já selecionou uma imagem de trabalho
                if (Geral.PathImagem != null)
                {
                    if (Geral.EscalaX != null && Geral.EscalaY != null || (Geral.MedidaMMCalcularEscalaX != null || Geral.MedidaMMCalcularEscalaY != null))
                    {
                        // Verifica se o usuário já definiu uma escala
                        _posicaoInicialCursor = e.Location;
                        _desenhar = true;
                    }
                    else
                        MessageBox.Show("Defina a escala", "Aviso");
                }
                else
                    MessageBox.Show("Selecione uma imagem", "Aviso");
            }
        }
        #endregion

        #region pnlImagem_MouseUp
        private void pnlImagem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _desenhar = false;

                if (Geral.MedidaMMCalcularEscalaX == null && Geral.MedidaMMCalcularEscalaY == null)
                {
                    if (!tsiRedefinirPontoZero.Checked)
                    {
                        if (Geral.CodigoTipoOperacao != null)
                        {
                            // Inserir operação definida pelo usuário na tabela
                            double _posicaoInicialXmm = (_posicaoInicialCursor.X - Geral.PontoZero.X) * Geral.EscalaX.Value;
                            double _posicaoFinalXmm = (e.X - Geral.PontoZero.X) * Geral.EscalaX.Value;
                            double _posicaoInicialYmm = -(_posicaoInicialCursor.Y - Geral.PontoZero.Y) * Geral.EscalaY.Value;
                            double _posicaoFinalYmm = -(e.Y - Geral.PontoZero.Y) * Geral.EscalaY.Value;

                            if (Geral.TabelaOperacoes.Columns.Count == 0)
                                CarregarEstruturaTabelaOperacoes();

                            // Inserir comando no DataTable
                            InserirOperacaoTabela(_posicaoInicialXmm, _posicaoFinalXmm, _posicaoInicialYmm, _posicaoFinalYmm, e.Location);

                            // Desenhar as operações
                            DesenharOperacoes();

                            // Zerar último ponto
                            _ultimaPosicaoInicialLinha = Point.Empty;
                        }
                        else
                            MessageBox.Show("Selecione uma operação", "Aviso");
                    }
                    else
                    {
                        if (Geral.PathImagem != null)
                        {

                            // Guardar a localização do novo ponto zero
                            Geral.PontoZero = e.Location;
                            tsiRedefinirPontoZero.Checked = false;
                            MessageBox.Show("Ponto Zero definido com sucesso.", "Informação");
                            // Zerar último ponto
                            _ultimaPosicaoInicialLinha = Point.Empty;
                        }
                        else
                            MessageBox.Show("Selecione uma imagem", "Aviso");
                    }
                }
                else if (Geral.MedidaMMCalcularEscalaX != null)
                {
                    // Calcular a Escala - Fazer a proporção de X
                    AtualizarValorEscalaX(e.Location.X);

                    Geral.MedidaMMCalcularEscalaX = null;
                    MessageBox.Show("Escala do Eixo X definida com sucesso.", "Informação");
                    // Zerar último ponto
                    _ultimaPosicaoInicialLinha = Point.Empty;
                }
                else if (Geral.MedidaMMCalcularEscalaY != null)
                {
                    // Calcular a Escala - Fazer a proporção de X
                    AtualizarValorEscalaY(e.Location.Y);

                    Geral.MedidaMMCalcularEscalaY = null;
                    MessageBox.Show("Escala do Eixo Y definida com sucesso.", "Informação");
                    // Zerar último ponto
                    _ultimaPosicaoInicialLinha = Point.Empty;
                }
            }
        }

        private void InserirOperacaoTabela(double posicaoInicialXmm_, double posicaoFinalXmm_, double posicaoInicialYmm_, double posicaoFinalYmm_, Point cursorLocation_)
        {
            // Inserir a operação de acordo com as opções informadas
            DataRow _operacao = Geral.TabelaOperacoes.NewRow();
            _operacao[0] = Convert.ToInt32(Geral.TabelaOperacoes.Rows.Count + 1).ToString("0000");
            _operacao[1] = Geral.CodigoTipoOperacao;
            _operacao[2] = Geral.DescricaoTipoOperacao;
            _operacao[3] = Geral.DescricaoFerramentaSelecionada;
            _operacao[4] = Geral.Raio.ToString();
            _operacao[5] = posicaoInicialXmm_.ToString("0.00");
            _operacao[6] = posicaoFinalXmm_.ToString("0.00");
            _operacao[7] = posicaoInicialYmm_.ToString("0.00");
            _operacao[8] = posicaoFinalYmm_.ToString("0.00");
            _operacao[9] = _posicaoInicialCursor.X.ToString();
            _operacao[10] = cursorLocation_.X.ToString();
            _operacao[11] = _posicaoInicialCursor.Y.ToString();
            _operacao[12] = cursorLocation_.Y.ToString();

            // Verificar tipo de operação para determinar avanço e velicidade padrão
            if (Geral.CodigoTipoOperacao == 1 || Geral.CodigoTipoOperacao == 2) // Fresar com ou sem raio
            {
                // Avanço
                _operacao[13] = "6000";
                _operacao[14] = "6000";
            }
            else if (Geral.CodigoTipoOperacao == 3 || Geral.CodigoTipoOperacao == 4) // Furar ou Roscar
            {
                // Avanço
                _operacao[13] = "800";
                _operacao[14] = "800";
            }

            Geral.TabelaOperacoes.Rows.Add(_operacao);
        }
        #endregion

        #region AtualizarValorEscalaX(int posicaoX_)
        private void AtualizarValorEscalaX(int posicaoX_)
        {
            double _posicaoX = Convert.ToDouble(System.Math.Abs(posicaoX_ - _posicaoInicialCursor.X));
            Geral.EscalaX = Geral.MedidaMMCalcularEscalaX / _posicaoX;
            tlbEscalaXValor.Text = Geral.EscalaX.Value.ToString("0.0000") + " mm / px";
        }
        private void AtualizarValorEscalaX(double posicaoX_)
        {
            Geral.EscalaX = posicaoX_;
            tlbEscalaXValor.Text = Geral.EscalaX.Value.ToString("0.0000") + " mm / px";
        }
        #endregion

        #region AtualizarValorEscalaY(int posicaoY_)
        private void AtualizarValorEscalaY(int posicaoY_)
        {
            double _posicaoY = Convert.ToDouble(System.Math.Abs(posicaoY_ - _posicaoInicialCursor.Y));
            Geral.EscalaY = Geral.MedidaMMCalcularEscalaY / _posicaoY;
            tlbEscalaYValor.Text = Geral.EscalaY.Value.ToString("0.0000") + " mm / px";
        }
        private void AtualizarValorEscalaY(double posicaoY_)
        {
            Geral.EscalaY = posicaoY_;
            tlbEscalaYValor.Text = Geral.EscalaY.Value.ToString("0.0000") + " mm / px";
        }
        #endregion

        #endregion

        #region CarregarEstruturaTabelaOperacoes
        private void CarregarEstruturaTabelaOperacoes()
        {
            Geral.TabelaOperacoes.Columns.Add("Ordem");
            Geral.TabelaOperacoes.Columns.Add("Cód. Tipo Operação");
            Geral.TabelaOperacoes.Columns.Add("Tipo Operação");
            Geral.TabelaOperacoes.Columns.Add("Ferramenta");
            Geral.TabelaOperacoes.Columns.Add("Raio");
            Geral.TabelaOperacoes.Columns.Add("Posição Inicial X");
            Geral.TabelaOperacoes.Columns.Add("Posição Final X");
            Geral.TabelaOperacoes.Columns.Add("Posição Inicial Y");
            Geral.TabelaOperacoes.Columns.Add("Posição Final Y");
            Geral.TabelaOperacoes.Columns.Add("PosicaoInicialXpx");
            Geral.TabelaOperacoes.Columns.Add("PosicaoFinalXpx");
            Geral.TabelaOperacoes.Columns.Add("PosicaoInicialYpx");
            Geral.TabelaOperacoes.Columns.Add("PosicaoFinalYpx");
            Geral.TabelaOperacoes.Columns.Add("Avanço");
            Geral.TabelaOperacoes.Columns.Add("Velocidade");
        }
        #endregion

        #region Menu

        #region tsiAbrirImagem_Click
        private void tsiAbrirImagem_Click(object sender, EventArgs e)
        {
            string _nomeArquivo = string.Empty;
            string _pathArquivo = string.Empty;

            // Usuário seleciona o arquivo a ser aberto
            OpenFileDialog _ofdAbrirArquivo = new OpenFileDialog();
            _ofdAbrirArquivo.CheckFileExists = true;
            _ofdAbrirArquivo.CheckPathExists = true;
            _ofdAbrirArquivo.DefaultExt = "jpg";
            _ofdAbrirArquivo.Filter = "Imagens Jpeg (*.jpg)|*.jpg|Imagens Gif (*.gif)|*.gif|Imagens Tif (*.tif)|*.tif|Imagens Bmp (*.bmp)|*bmp";
            _ofdAbrirArquivo.Multiselect = false;
            _ofdAbrirArquivo.Title = "Selecione a imagem";
            if (_ofdAbrirArquivo.ShowDialog() == DialogResult.OK)
            {
                _nomeArquivo = System.IO.Path.GetFileName(_ofdAbrirArquivo.FileName);
                _nomeArquivo = System.IO.Path.GetDirectoryName(_ofdAbrirArquivo.FileName);
            }

            // Colocar a imagem no picture box
            if (_ofdAbrirArquivo.FileName != string.Empty)
            {
                Geral.PathImagem = _ofdAbrirArquivo.FileName;
                Image _imagem = Image.FromFile(Geral.PathImagem);
                pnlImagem.BackgroundImage = _imagem;
                pnlImagem.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
                Geral.PathImagem = null;
        }
        #endregion

        #region tsiSair_Click
        private void tsiSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region tsiDefinirEscalaX_Click
        private void tsiDefinirEscalaX_Click(object sender, EventArgs e)
        {
            if (Geral.PathImagem != null)
            {
                Geral.Eixo = "X";
                Form _definirEscala = new frmDefinirEscalaX();
                _definirEscala.Show(this);
            }
            else
            {
                MessageBox.Show("Selecione uma imagem", "Aviso");
            }
        }
        #endregion

        #region tsiDefinirEscalaY_Click
        private void tsiDefinirEscalaY_Click(object sender, EventArgs e)
        {
            if (Geral.PathImagem != null)
            {
                Geral.Eixo = "Y";
                Form _definirEscala = new frmDefinirEscalaX();
                _definirEscala.Show(this);
            }
            else
            {
                MessageBox.Show("Selecione uma imagem", "Aviso");
            }
        }
        #endregion

        #region DesmarcarFerramentasMenu
        private void DesmarcarFerramentasMenu()
        {
            tsiFresarRaio.Checked = false;
            tsiFresar.Checked = false;
            tsiFurar.Checked = false;
            tsiRoscar.Checked = false;

            AtualizarFerramenta();
        }
        #endregion

        #region AtualizarFerramenta
        private void AtualizarFerramenta()
        {
            tlbFerramentaValor.Text = Geral.DescricaoFerramentaSelecionada;
        }
        #endregion

        #region tsiFresarRaio_Click
        private void tsiFresarRaio_Click(object sender, EventArgs e)
        {
            // Guardar o código da ferramenta selecionada
            Geral.CodigoTipoOperacao = 1;
            Geral.DescricaoFerramentaSelecionada = tsiTamanhoFresaRaio.Text;
            if (tsiRaio.Text.Trim().Length > 0)
                Geral.Raio = Convert.ToDouble(tsiRaio.Text);
            DesmarcarFerramentasMenu();
            tsiFresarRaio.Checked = true;
        }
        #endregion

        #region tsiFresar_Click
        private void tsiFresar_Click(object sender, EventArgs e)
        {
            // Guardar o código da ferramenta selecionada
            Geral.CodigoTipoOperacao = 2;
            Geral.DescricaoFerramentaSelecionada = tsiTamanhoFresa.Text;
            Geral.Raio = null;
            DesmarcarFerramentasMenu();
            tsiFresar.Checked = true;
        }
        #endregion

        #region tsiFurar_Click
        private void tsiFurar_Click(object sender, EventArgs e)
        {
            // Guardar o código da ferramenta selecionada
            Geral.CodigoTipoOperacao = 3;
            Geral.DescricaoFerramentaSelecionada = tsiTamanhoBroca.Text;
            Geral.Raio = null;
            DesmarcarFerramentasMenu();
            tsiFurar.Checked = true;
        }
        #endregion

        #region tsiRoscar_Click
        private void tsiRoscar_Click(object sender, EventArgs e)
        {
            // Guardar o código da ferramenta selecionada
            Geral.CodigoTipoOperacao = 4;
            Geral.DescricaoFerramentaSelecionada = tsiTamanhoMacho.Text;
            Geral.Raio = null;
            DesmarcarFerramentasMenu();
            tsiRoscar.Checked = true;
        }
        #endregion

        #region tsiTamanhoFresaRaio_TextChanged
        private void tsiTamanhoFresaRaio_TextChanged(object sender, EventArgs e)
        {
            if (tsiFresarRaio.Checked)
            {
                Geral.DescricaoFerramentaSelecionada = tsiTamanhoFresaRaio.Text;
                AtualizarFerramenta();
            }
        }
        #endregion

        #region tsiRaio_TextChanged
        private void tsiRaio_TextChanged(object sender, EventArgs e)
        {
            if (tsiFresarRaio.Checked)
            {
                if (tsiRaio.Text.Trim().Length > 0)
                {
                    try
                    {
                        Geral.Raio = Convert.ToDouble(tsiRaio.Text);
                    }
                    catch
                    {
                        Geral.Raio = null;
                    }
                }
            }
        }
        #endregion

        #region tsiTamanhoFresa_TextChanged
        private void tsiTamanhoFresa_TextChanged(object sender, EventArgs e)
        {
            if (tsiFresar.Checked)
            {
                Geral.DescricaoFerramentaSelecionada = tsiTamanhoFresa.Text;
                AtualizarFerramenta();
            }
        }
        #endregion

        #region tsiTamanhoBroca_TextChanged
        private void tsiTamanhoBroca_TextChanged(object sender, EventArgs e)
        {
            if (tsiFurar.Checked)
            {
                Geral.DescricaoFerramentaSelecionada = tsiTamanhoBroca.Text;
                AtualizarFerramenta();
            }
        }
        #endregion

        #region tsiTamanhoMacho_TextChanged
        private void tsiTamanhoMacho_TextChanged(object sender, EventArgs e)
        {
            if (tsiRoscar.Checked)
            {
                Geral.DescricaoFerramentaSelecionada = tsiTamanhoMacho.Text;
                AtualizarFerramenta();
            }
        }
        #endregion

        #region tsiVisualizarPrograma
        private void tsiVisualizarPrograma_Click(object sender, EventArgs e)
        {
            Form _operacoesCadastradas = new frmOperacao();
            _operacoesCadastradas.Show(this);
        }
        #endregion

        #region tsiSalvar_Click
        private void tsiSalvar_Click(object sender, EventArgs e)
        {
            bool _gravarProjeto = true;
            string _nomeArquivo = string.Empty;
            string _diretorioArquivo = string.Empty;

            // Caso já ocaminho já esteja determinado, gravar
            if (Geral.PathArquivoCNC == null)
            {
                // Abrir a janela de dialogo para que o usuário insira a localização do arquivo
                SaveFileDialog _salvarArquivo = new SaveFileDialog();
                _salvarArquivo.CheckPathExists = true;
                _salvarArquivo.AddExtension = true;
                _salvarArquivo.DefaultExt = ".cnc";
                _salvarArquivo.InitialDirectory = Application.StartupPath;
                _salvarArquivo.OverwritePrompt = true;
                _salvarArquivo.Filter = "Arquivos VisualProgCNC (*.cnc)|*.cnc";
                _salvarArquivo.Title = "Salvar";
                if (_salvarArquivo.ShowDialog() == DialogResult.OK)
                {
                    _nomeArquivo = Path.GetFileName(_salvarArquivo.FileName);
                    _diretorioArquivo = Path.GetDirectoryName(_salvarArquivo.FileName);
                    Geral.PathArquivoCNC = _salvarArquivo.FileName;
                }
                else
                    _gravarProjeto = false;
            }
            else
            {
                _nomeArquivo = Path.GetFileName(Geral.PathArquivoCNC);
                _diretorioArquivo = Path.GetDirectoryName(Geral.PathArquivoCNC);
            }

            if (_gravarProjeto)
            {
                // Recuperar o path do programa
                string _pathInicial = Application.StartupPath;

                // Criar um diretório temporário baseado na data atual (cuidado para não existir a possibilidade de criar duplicidade)
                string _diretorioTemporario = _pathInicial + "/" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "tmp";
                Directory.CreateDirectory(_diretorioTemporario);

                // Copiar a imagem
                if (Geral.PathImagem != null)
                {
                    FileInfo _imagem = new FileInfo(Geral.PathImagem);
                    File.Copy(Geral.PathImagem, _diretorioTemporario + "/" + _imagem.Name.ToString());
                }

                // Gravar o conteúdo do datatable em um arquivo xml
                Geral.TabelaOperacoes.WriteXml(_diretorioTemporario + "/prog.xml");

                // Criar arquivo mestre contendo as informações do pacote
                StreamWriter _sw = File.CreateText(_diretorioTemporario + "/guia.txt");
                _sw.WriteLine("VER:" + Application.ProductVersion);
                if (Geral.PathImagem != null)
                {
                    FileInfo _imagem = new FileInfo(Geral.PathImagem);
                    _sw.WriteLine("IMG:" + _imagem.Name.ToString());
                }
                if (Geral.EscalaX != null)
                    _sw.WriteLine("ECX:" + Geral.EscalaX.ToString());
                if (Geral.EscalaY != null)
                    _sw.WriteLine("ECY:" + Geral.EscalaY.ToString());
                if (Geral.PontoZero != null)
                {
                    _sw.WriteLine("PTX:" + Geral.PontoZero.X.ToString());
                    _sw.WriteLine("PTY:" + Geral.PontoZero.Y.ToString());
                }
                //_sw.WriteLine("PRG:" + "prog.xml");
                _sw.Flush();
                _sw.Close();

                // Zipar
                FastZip z = new ICSharpCode.SharpZipLib.Zip.FastZip();
                z.CreateEmptyDirectories = true;
                z.CreateZip(_diretorioArquivo + "/" + Path.ChangeExtension(_nomeArquivo, ".zip"), _diretorioTemporario, true, "");
                string _arquivoZipCriado = _diretorioArquivo + "/" + Path.ChangeExtension(_nomeArquivo, ".zip");

                // Renomear o zip para .cnc
                string _arquivoCNCCriado = _diretorioArquivo + "/" + _nomeArquivo;
                FileInfo _fileInfo = new FileInfo(_arquivoZipCriado);
                if (File.Exists(_arquivoCNCCriado))
                    File.Delete(_arquivoCNCCriado);
                _fileInfo.MoveTo(_arquivoCNCCriado);
                File.Delete(_arquivoZipCriado);

                // Remover o diretório temporário
                Directory.Delete(_diretorioTemporario, true);
            }
        }
        #endregion

        #region tsiAbrirProjeto_Click
        private void tsiAbrirProjeto_Click(object sender, EventArgs e)
        {
            string _nomeArquivo = string.Empty;
            string _pathArquivo = string.Empty;

            // Usuário seleciona o arquivo a ser aberto
            OpenFileDialog _abrirProjeto = new OpenFileDialog();
            _abrirProjeto.CheckFileExists = true;
            _abrirProjeto.CheckPathExists = true;
            _abrirProjeto.DefaultExt = "cnc";
            _abrirProjeto.Filter = "Arquivos VisualProgCNC (*.cnc)|*.cnc";
            _abrirProjeto.Multiselect = false;
            _abrirProjeto.Title = "Selecione o projeto";
            if (_abrirProjeto.ShowDialog() == DialogResult.OK)
            {
                _nomeArquivo = System.IO.Path.GetFileName(_abrirProjeto.FileName);
                _nomeArquivo = System.IO.Path.GetDirectoryName(_abrirProjeto.FileName);
            }

            // Descompactar o projeto e carregá-lo
            if (_abrirProjeto.FileName != string.Empty)
            {
                // Criar diretório temporário
                string _diretorioTemporario = Application.StartupPath + "/" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "tmp";
                Directory.CreateDirectory(_diretorioTemporario);
               
                // Copiar o arquivo para o diretório temporário
                string _arquivoCNC = _abrirProjeto.FileName;
                string _arquivoZip = Path.ChangeExtension(_abrirProjeto.FileName, ".zip");
                _arquivoZip = _diretorioTemporario + "/" + Path.GetFileName(_arquivoZip);
                if (File.Exists(_arquivoZip))
                    File.Delete(_arquivoZip);
                File.Copy(_arquivoCNC, _arquivoZip);
                
                // Descompactar os arquivos e excluir o zip
                FastZip _zip = new FastZip();
                _zip.ExtractZip(_arquivoZip, _diretorioTemporario, "");
                File.Delete(_arquivoZip);

                // Carregar a imagem
                string _nomeArquivoImagem = RecuperarParametroArquivoMestre(_diretorioTemporario + "/guia.txt", "IMG");
                Geral.PathImagem = _diretorioTemporario + "/" + _nomeArquivoImagem;
                Image _imagem = Image.FromFile(Geral.PathImagem);
                pnlImagem.BackgroundImage = _imagem;
                pnlImagem.BackgroundImageLayout = ImageLayout.Stretch;
                
                // Carregar o DataTable
                Geral.TabelaOperacoes = new DataTable("Operacoes");
                Geral.TabelaOperacoes.ReadXmlSchema(_diretorioTemporario + "/prog.xml");
                Geral.TabelaOperacoes.ReadXml(_diretorioTemporario + "/prog.xml");
                File.Delete(_diretorioTemporario + "/prog.xml");
                
                // Carregar Escala e Ponto Zero
                double _escalaX = Convert.ToDouble(RecuperarParametroArquivoMestre(_diretorioTemporario + "/guia.txt", "ECX"));
                double _escalaY = Convert.ToDouble(RecuperarParametroArquivoMestre(_diretorioTemporario + "/guia.txt", "ECY"));
                Point _pontoZero = Point.Empty;
                _pontoZero.X = Convert.ToInt32(RecuperarParametroArquivoMestre(_diretorioTemporario + "/guia.txt", "PTX"));
                _pontoZero.Y = Convert.ToInt32(RecuperarParametroArquivoMestre(_diretorioTemporario + "/guia.txt", "PTY"));
                Geral.PontoZero = _pontoZero;
                AtualizarValorEscalaX(_escalaX);
                AtualizarValorEscalaY(_escalaY);
                
                // Setar o arquivo como padrão para gravação
                File.Delete(_diretorioTemporario + "/guia.txt");
                Geral.PathArquivoCNC = _abrirProjeto.FileName;
            }
            else
                Geral.PathImagem = null;
        }
        #endregion

        #region tsiFecharProjeto_Click
        private void tsiFecharProjeto_Click(object sender, EventArgs e)
        {
            // Fechar o projeto atual
            pnlImagem.BackgroundImage = null;
            Geral.CodigoTipoOperacao = null;
            Geral.DescricaoFerramentaSelecionada = null;
            Geral.EscalaX = null;
            Geral.EscalaY = null;
            Geral.MedidaMMCalcularEscalaX = null;
            Geral.MedidaMMCalcularEscalaY = null;
            Geral.PathArquivoCNC = null;
            Geral.PathImagem = null;
            Geral.PontoZero = Point.Empty;
            Geral.Raio = null;
            Geral.TabelaOperacoes = new DataTable("Operacoes");

            // Limpar labels
            tlbFerramentaValor.Text = string.Empty;
            tlbPosicaoX.Text = "0,00 mm";
            tlbPosicaoY.Text = "0,00 mm";
            tlbEscalaXValor.Text = "0,000 mm / px";
            tlbEscalaYValor.Text = "0,000 mm / px";

            // Desescolher as opções no menu
        }
        #endregion

        #region RecuperarParametroArquivoMestre
        private string RecuperarParametroArquivoMestre(string pathArquivoMestre_, string parametro_)
        {
            StreamReader _sr = File.OpenText(pathArquivoMestre_);
            string _linha = string.Empty;
            string _retorno = string.Empty;
            while (!_sr.EndOfStream)
            {
                _linha = _sr.ReadLine();
                if (_linha.Substring(0, 3) == parametro_)
                    _retorno = _linha.Substring(4, _linha.Length - 4);
            }
            _sr.Close();

            return _retorno;
        }
        #endregion

        #endregion

        #region DesenharOperacoes
        private void DesenharOperacoes()
        {
            // Desenhar
            Graphics _graficos = pnlImagem.CreateGraphics();
            Pen _caneta = new Pen(Color.Empty, Geral.LarguraLinhaDesenho);

            foreach (DataRow _linha in Geral.TabelaOperacoes.Rows)
            {
                Point _pontoInicial = Point.Empty;
                Point _pontoFinal = Point.Empty;

                _pontoInicial = new Point(Convert.ToInt32(_linha[9].ToString()), Convert.ToInt32(_linha[11].ToString()));
                _pontoFinal = new Point(Convert.ToInt32(_linha[10].ToString()), Convert.ToInt32(_linha[12].ToString()));

                // Verificar qual o tipo de operação e alterar a cor
                int _codigoTipoOperacao = Convert.ToInt32(_linha[1].ToString());
                _caneta.Color = Geral.CorTipoOperacao(_codigoTipoOperacao);

                if (_codigoTipoOperacao == 1 || _codigoTipoOperacao == 2)
                    _graficos.DrawLine(_caneta, _pontoInicial, _pontoFinal);
                else if (_codigoTipoOperacao == 3 || _codigoTipoOperacao == 4)
                    _graficos.DrawEllipse(_caneta, _pontoFinal.X - (Geral.LarguraLinhaDesenho / 2), _pontoFinal.Y - (Geral.LarguraLinhaDesenho / 2), Geral.LarguraLinhaDesenho, Geral.LarguraLinhaDesenho);
            }

        }
        #endregion

        #region pnlImagem_Paint
        private void pnlImagem_Paint(object sender, PaintEventArgs e)
        {
            DesenharOperacoes();
        }
        #endregion

        #region frmPrincipal_FormClosed
        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Image _imagem = pnlImagem.BackgroundImage;
            if (_imagem != null)
                _imagem.Dispose();
            pnlImagem.BackgroundImage = null;
        }
        #endregion

        #region IMAGEM !!!!!!!!!
        private void button1_Click(object sender, EventArgs e)
        {
            if (pnlImagem.BackgroundImage != null)
            {
                Image _imagemFundo = pnlImagem.BackgroundImage;
                _imagemFundo.RotateFlip(RotateFlipType.Rotate90FlipX);
                //Graphics _graficos = pnlImagem.CreateGraphics();
                //_graficos.DrawImage(_imagemFundo, 0, 0);
                pnlImagem.BackgroundImage = _imagemFundo;
            }
        }

        private void tsiGirarDireita_Click(object sender, EventArgs e)
        {

        }

        private void tsiGirarEsquerda_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void opçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}