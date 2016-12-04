using System;
using System.Collections.Generic;
using System.Text;
//using Fiori.Windows.VisualProgCNC.Classes;
using System.Data;

namespace Fiori.Windows.VisualProgCNC.Classes
{
    public class GeradorProgramaNC
    {
        #region Contrutor
        public GeradorProgramaNC()
        {
        }
        #endregion

        int _numeroLinhaPrograma = 10;

        #region GerarPrograma
        public void GerarPrograma()
        {
            // Inicializar variáveis
            _numeroLinhaPrograma = 10;
            StringBuilder _programa = new StringBuilder();

            // Gerar cabeçalho do programa
            string _cabecalhoPrograma = GerarCabecalhoPrograma();

            // Gerar lista dos pontos zero
            string _listaPontoZero = GerarListaPontoZero();

            // Gerar lista das ferramentas
            string _listaFerramentas = GerarListaFerramentas();

            // MCALL p/ Furação e Roscas
            // Varrer toda a tabela e a cada mudança de ferramenta montar uma nova tabela contendo:
            // codigo do grupo (criar codigo somando 1)     codigo da operacao
            // A cada mudança de código, mudar o MCALL (tabela criada)
            // OBS: Caso tenha uma ferramenta no grupo o MCALL não deve ser usado
            DataTable _grupoFerramentas = GerarGrupoFerramentas();

            // Testar função
            foreach (DataRow _linhaGrupo in _grupoFerramentas.Rows)
            {
                _programa.AppendLine("Cód.Grupo: " + _linhaGrupo[0].ToString() + " Operação(Ordem): " + _linhaGrupo[1].ToString());
            }

            // Varrer o data table e montar o programa
            string _ferramentaAtual = string.Empty;
            int _posicaoFerramenta = 0;
            foreach (DataRow _linha in Geral.TabelaOperacoes.Rows)
            {
                int _codigoTipoOperacao = Convert.ToInt32(_linha[1].ToString());

                // Tratar valores
                double? _raio = null;
                if (_linha[4].ToString() != string.Empty)
                    _raio = Convert.ToDouble(_linha[4].ToString());

                double? _profundidade = 0;
                //double? _profundidade = null;
                //if (_linha[4].ToString() != string.Empty)
                //    _raio = Convert.ToDouble(_linha[4].ToString());

                double? _passeRosca = 0;
                //double? _passeRosca = null;
                //if (_linha[4].ToString() != string.Empty)
                //    _raio = Convert.ToDouble(_linha[4].ToString());

                // Verificar se houve mudança de ferramenta
                if (_ferramentaAtual == string.Empty)
                {
                    _ferramentaAtual = _linha[3].ToString();
                    _posicaoFerramenta = _posicaoFerramenta + 1;
                    _programa.Append(GerarLinhaProgramaTrocaFerramenta(_posicaoFerramenta, _ferramentaAtual));
                }
                else if (_ferramentaAtual != _linha[3].ToString())
                {
                    _ferramentaAtual = _linha[3].ToString();
                    _posicaoFerramenta = _posicaoFerramenta + 1;
                    _programa.Append(GerarLinhaProgramaTrocaFerramenta(_posicaoFerramenta, _ferramentaAtual));
                }

                // ÚLTIMO PARAMETRO PARA CONTROLE DO MCALL
                _programa.Append(GerarLinhaPrograma(_codigoTipoOperacao, Convert.ToDouble(_linha[6].ToString()), Convert.ToDouble(_linha[8].ToString()), Convert.ToInt32(_linha[13].ToString()), Convert.ToInt32(_linha[14].ToString()), _raio, _profundidade, _passeRosca, false));
            }

            // Gerar últimas linhas do programa (mover a ferramenta até o zero)
            string _fimPrograma = GerarFimPrograma();

            System.Windows.Forms.Clipboard.SetText(_cabecalhoPrograma + _listaPontoZero + _listaFerramentas + _programa.ToString() + _fimPrograma);
        }
        #endregion

        #region GerarCabecalhoPrograma
        private string GerarCabecalhoPrograma()
        {
            // Exemplo:
            //%_N_TAMPA_003_MPF                     --> Nome do programa
            //;$PATH=/_N_WKS_DIR/_N_SPICA_MTU_WPD   --> Diretório de trabalho
            //N10 G90 G17 G71 G94 G64               --> Inicializar variáveis

            StringBuilder _cabecalho = new StringBuilder();
            _cabecalho.AppendLine("%_N_<NOME DO PROGRAMA>");
            _cabecalho.AppendLine(";$PATH=/_N_WKS_DIR/<DIRETORIO DO PROGRAMA>");
            _cabecalho.AppendLine("N" + _numeroLinhaPrograma.ToString() + " G90 G17 G71 G94 G64");
            _numeroLinhaPrograma = _numeroLinhaPrograma + 10;

            return _cabecalho.ToString();
        }
        #endregion

        #region GerarListaPontoZero
        private string GerarListaPontoZero()
        {
            // PONTO ZERO
            // A cada G?? é utilizado um ponto zero
            // G54 ATÉ G57
            // DEPOIS: G505 ATÉ G???

            // A CADA PONTO ZERO CRIADO CRIAR UMA LINHA COMO A LINHA ABAIXO:
            // N70 $P_UIFR[1]=CTRANS(X,-254.700,Y,-219.100);M30 54
            // N80 $P_UIFR[2]=CTRANS(X,-976.600,Y,-375.500);M26 55
            // N90 $P_UIFR[3]=CTRANS(X,-631.100,Y,-350.100);M8 56
            // N100 $P_UIFR[4]=CTRANS(X,-562.500,Y,-84.100);M16 57
            // N110 $P_UIFR[5]=CTRANS(X,-192.700,Y,-118.000);FRESAR 505
            // N120 $P_UIFR[6]=CTRANS(X,-192.700,Y,-143.900);SPOT FACE 506

            return string.Empty;
        }
        #endregion

        #region GerarListaFerramentas
        private string GerarListaFerramentas()
        {
            // A cada ferramenta criar uma linha como abaixo:
            // N130 $TC_DP3[1,1]=-373.000;BROCA TMAX 28
            // N140 $TC_DP3[2,1]=-368.000;MACHO M30X2
            // N150 $TC_DP3[3,1]=-340.000;FRESA 80 M26
            // N160 $TC_DP3[3,2]=-278.000;FRESA  M8 1X
            // N170 $TC_DP3[3,3]=-445.000;FRESA  M16
            // N180 $TC_DP3[3,4]=-436.300;FRESA  9.5
            // --> N999 $TC_DP3[<NÚMERO DA FERRAMENTA>,<NÚMERO DO "D">]=-100.000;<FERRAMENTA>
            // Exemplo: A terceira ferramenta possui três alturas possíveis, no programa a descrição não está sobre a ferramenta e sim sobre o que ela faz ex: fresar onde faz o M16

            // Refrigeração
            // M7 -> Liga a refrigeração pelo centro da ferramenta
            // M8 -> Liga a refrigeração pela lateral da ferramenta
            // M9 -> Desliga tudo

            StringBuilder _listaFerramentas = new StringBuilder();
            int _quantidadeFerramentas = 1;

            // Varrer o data table e montar o programa
            DataTable _ferramentas = SelectDistinct("Operacoes", Geral.TabelaOperacoes, "Ferramenta");
            foreach (DataRow _linha in _ferramentas.Rows)
            {
                _listaFerramentas.AppendLine("N" + _numeroLinhaPrograma.ToString() + " $TC_DP3[" + _quantidadeFerramentas.ToString() + ",1]=-100.000; " + _linha[0].ToString().ToUpper());
                _numeroLinhaPrograma = _numeroLinhaPrograma + 10;
                _quantidadeFerramentas = _quantidadeFerramentas + 1;
            }

            return _listaFerramentas.ToString();
        }
        #endregion

        #region GerarLinhaPrograma
        private string GerarLinhaPrograma(int codigoTipoOperacao_, double posicaoX_, double posicaoY, int avanco_, int velocidade_, double? raio_, double? profundidade_, double? passeRosca_, bool usarBloco_)
        {
            StringBuilder _comando = new StringBuilder();

            if (codigoTipoOperacao_ == 1) // Fresar com Raio
            {
                // Sintaxe do comando G1:
                // G1 X Y F S
                // G1 X-150 Y-23 RND=20 F6000 S6000
                _comando.AppendLine("N" + _numeroLinhaPrograma.ToString() + " G0 X" + posicaoX_.ToString("0.00").Replace(",", ".") + " Y" + posicaoY.ToString("0.00").Replace(",", ".") + " RND=" + raio_ + " F" + avanco_.ToString() + " S" + velocidade_);
                _numeroLinhaPrograma = _numeroLinhaPrograma + 10;
            }
            else if (codigoTipoOperacao_ == 2) // Fresar
            {
                // G1 X-150 Y-23 F6000
                _comando.AppendLine("N" + _numeroLinhaPrograma.ToString() + " G0 X" + posicaoX_.ToString("0.00").Replace(",", ".") + " Y" + posicaoY.ToString("0.00").Replace(",", ".") + " F" + avanco_.ToString() + " S" + velocidade_);
                _numeroLinhaPrograma = _numeroLinhaPrograma + 10;
            }
            else if (codigoTipoOperacao_ == 3) // Furar
            {
                // Sintaxe do comando CYCLE83
                // CYCLE83( RTP, RFP, SDIS, DP, DPR, FDEP, FDPR, DAM, DTB, DTS, FRF, VARI, _AXN, _MDEP, _VRT, _DTD, _DIS1)
                // RTP - Plano de retorno absoluto (altura em mm que a broca sobre antes de ir para outro furo)
                // RFP - Plano de referência absoluto
                // SDIS - Distância segura (sem sinal)
                // DP - Profundidade final de furação (absoluta) (profundidade total do furo)
                // DPR - Profundidade final de furação relativa ao plano de referência (sem sinal)
                // FDEP - Primeira profundidade de furação (absoluta) (Quanto a broca fura antes que o "pica-pau" seja feito)
                // FDPR - Primeira profundidade de furação relativa ao plano de referência (sem sinal) (a cada Xmm ela recua - pica-pau)
                // DAM - Valor de degressão (sem sinal) ???
                //       Valores: >0 valor de degressão
                //                <0 fator de degressão
                //                =0 sem degreção
                // DTB - Tempo de espera na profundidade final de furação (quebrar cavacos)
                //       Valores: >0 em segundos <0 em rotações
                // DTS - Tempo de espera no ponto inicial e na eliminação de cavacos
                //       Valores: >0 em segundos <0 em rotações
                // FRF - Fator de avanço para a primeira profundidade de furação (sem sinal) (a broca sobe para que os cavacos sejam eliminados da broca - pica-pau)
                //       Game de Valores: 0.001 ... 1
                // VARI - Modo de trabalho
                //        Valores: 0 quebrar cavacos 1 para eliminar cavacos
                // _AXN - Eixa da ferramenta
                //        Valores: 1 = primeiro eixo geométrico 2 = segundo eixo geométrico ou qualquer = terceiro eixo geométrico
                // _MDEP - Profundidade mínima de furação
                // _VRT - Distância variável de retração para quebra de cavacos (VARI = 0)
                //        Valores: >0 é distância de retração
                //                 0 = selecionado é 1mm
                // _DTD - Tempo de espera da profundidade final de furação
                //        Valores: >0 em segundos
                //                 <0 em rotações
                //                 =0 valor para DTB
                // _DIS1 - Distância limite programável na re-inserção no furo (VARI = 1 para eliminar cavacos)
                //         Valores: >0 valores programáveis aplicados
                //                  =0 Calculo Automático
                // Exemplo: N1620 CYCLE83(10,  0,   0,    -5, 0,   -15,  0,    20,  0,   0,   1,   0)
                //                        RTP, RFP, SDIS, DP, DPR, FDEP, FDPR, DAM, DTB, DTS, FRF, VARI, _AXN, _MDEP, _VRT, _DTD, _DIS1)
                // Gerar comando de posicionamento
                _comando.AppendLine("N" + _numeroLinhaPrograma.ToString() + " G54 G0 D1 X" + posicaoX_.ToString("0.00").Replace(",", ".") + " Y" + posicaoY.ToString("0.00").Replace(",", ".") + " F" + avanco_.ToString() + " S" + velocidade_.ToString() + " M3");
                _numeroLinhaPrograma = _numeroLinhaPrograma + 10;
                // Gerar comando de furação
                _comando.AppendLine("N" + _numeroLinhaPrograma.ToString() + " CYCLE83(10, 0, 0, " + profundidade_.Value.ToString("0.00").Replace(",", ".") + ", 0, -15, 0, 20, 0, 0, 1, 0)");
                _numeroLinhaPrograma = _numeroLinhaPrograma + 10;
            }
            else if (codigoTipoOperacao_ == 4) // Roscar
            {
                // Sintaxe do comando CYCLE84
                // CYCLE84( RTP, RFP, SDIS, DP, DPR, DTB, SDAC, MPIT, PIT, POSS, SST,SST1)
                // RTP - Plano de retorno absoluto
                // RFP - Plano de referência absoluto
                // SDIS - Distância segura (sem sinal)
                // DP - Profundidade final de furação (absoluta) (profundidade total da rosca)
                // DPR - Profundidade final de furação relativa ao plano de referência (sem sinal)
                // DTB - Tempo de espera no fundo da rosca
                // SDAC - Sentido do giro após fim do ciclo (3, 4 ou 5) (sentido da rosca - sempre 3)
                // MPIT - Passo da Rosca como tamanho da Rosca (com sinal)
                //        Área do valor: 3 (para M3)... 48 (para M48), o sinal define o sentido de giro da rosca
                // PIT - Passo da Rosca como valor (com sinal)
                //       Gama de Valores: 0.001 ... 2000.000 mm, o sinal determina o sentido de giro na rosca
                // POSS - Posição do fuso para a parada orientada do fuso no ciclo (em graus)
                // SST - Rotação para rosqueamento
                // SST1 - Rotação para retorno
                // Exemplo: N2330 CYCLE84(5,  5,  1,   -20.0, 0,  0,  3,   0,   1.25, 0,   1000, 1000)
                //                        RTP RFP SDIS DP     DFR DTB SDAC MPIT PIT   POSS SST   SST1
                // Gerar comando de posicionamento
                _comando.AppendLine("N" + _numeroLinhaPrograma.ToString() + " G54 G0 D1 X" + posicaoX_.ToString("0.00").Replace(",", ".") + " Y" + posicaoY.ToString("0.00").Replace(",", ".") + " S0 M3");
                _numeroLinhaPrograma = _numeroLinhaPrograma + 10;
                // Gerar comando de rosqueamento
                _comando.AppendLine("N" + _numeroLinhaPrograma.ToString() + " CYCLE84(10, 5, 1, " + profundidade_.Value.ToString("0.00").Replace(",", ".") + ", 0, 0, 3, 0, " + passeRosca_.Value.ToString("0.00").Replace(",", ".") + ", 0, " + avanco_.ToString() + ", " + avanco_.ToString() + ")");
                _numeroLinhaPrograma = _numeroLinhaPrograma + 10;
            }

            // O comando não reconhece virgulas
            return _comando.ToString();
        }
        #endregion

        #region GerarLinhaProgramaTrocaFerramenta
        private string GerarLinhaProgramaTrocaFerramenta(int posicaoFerramenta_, string nomeFerramenta_)
        {
            // PARA TROCAR FERRAMENTAS
            // N580 M5 M9
            // N590 G53 G0 Z-100 D0
            // N600 T3; <nome da ferramenta>
            // N610 M6

            StringBuilder _comando = new StringBuilder();

            _comando.AppendLine("N" + _numeroLinhaPrograma.ToString() + " M5 M9");
            _numeroLinhaPrograma = _numeroLinhaPrograma + 10;
            _comando.AppendLine("N" + _numeroLinhaPrograma.ToString() + " G53 G0 Z-100 D0");
            _numeroLinhaPrograma = _numeroLinhaPrograma + 10;
            _comando.AppendLine("N" + _numeroLinhaPrograma.ToString() + " T" + posicaoFerramenta_.ToString() + "; " + nomeFerramenta_);
            _numeroLinhaPrograma = _numeroLinhaPrograma + 10;
            _comando.AppendLine("N" + _numeroLinhaPrograma.ToString() + " M6");
            _numeroLinhaPrograma = _numeroLinhaPrograma + 10;

            return _comando.ToString();
        }
        #endregion

        #region GerarFimPrograma
        private string GerarFimPrograma()
        {
            // N2800 T0
            // N2810 M6
            // N2820 M30

            StringBuilder _fimPrograma = new StringBuilder();

            _fimPrograma.AppendLine("N" + _numeroLinhaPrograma.ToString() + " T0");
            _numeroLinhaPrograma = _numeroLinhaPrograma + 10;
            _fimPrograma.AppendLine("N" + _numeroLinhaPrograma.ToString() + " M6");
            _numeroLinhaPrograma = _numeroLinhaPrograma + 10;
            _fimPrograma.AppendLine("N" + _numeroLinhaPrograma.ToString() + " M30");
            _numeroLinhaPrograma = _numeroLinhaPrograma + 10;

            return _fimPrograma.ToString();
        }
        #endregion

        #region DataTable Distinct
        private bool ColumnEqual(object A, object B)
        {

            // Compares two values to see if they are equal. Also compares DBNULL.Value.
            // Note: If your DataTable contains object fields, then you must extend this
            // function to handle them in a meaningful way if you intend to group on them.

            if (A == DBNull.Value && B == DBNull.Value) //  both are DBNull.Value
                return true;
            if (A == DBNull.Value || B == DBNull.Value) //  only one is DBNull.Value
                return false;
            return (A.Equals(B));  // value type standard comparison
        }
        private DataTable SelectDistinct(string TableName, DataTable SourceTable, string FieldName)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable(TableName);
            dt.Columns.Add(FieldName, SourceTable.Columns[FieldName].DataType);

            object LastValue = null;
            foreach (DataRow dr in SourceTable.Select("", FieldName))
            {
                if (LastValue == null || !(ColumnEqual(LastValue, dr[FieldName])))
                {
                    LastValue = dr[FieldName];
                    dt.Rows.Add(new object[] { LastValue });
                }
            }
            if (ds != null)
                ds.Tables.Add(dt);
            return dt;
        }
        #endregion

        #region GerarGrupoFerramentas
        /// <summary>
        /// Gera uma lista com um identificador e as operações que pertecem ao grupo.
        /// Usado para o MCALL, quando se tem mais de uma operação usando a mesma ferramenta usa-se o MCALL para 
        /// economizar linhas de programa e melhorar a visualização.
        /// Válido somente para ferramentas de furo ou rosca.
        /// Identificador do Grupo      Código da Operação
        /// 1                           0001
        /// 1                           0002
        /// 2                           0003
        /// 2                           0004
        /// 2                           0005
        /// </summary>
        /// <returns>DataTable contendo a estrutura descrita.</returns>
        private DataTable GerarGrupoFerramentas()
        {
            // Criar estrutra de saída
            DataTable _agrupador = new DataTable();
            _agrupador.Columns.Add("CodigoGrupo");
            _agrupador.Columns.Add("Ordem");

            string _ferramenta = string.Empty;
            int _codigoGrupo = 1;

            // Varrer todas as operação e agrupar
            foreach (DataRow _linha in Geral.TabelaOperacoes.Rows)
            {
                int _codigoTipoOperacao = Convert.ToInt32(_linha[1].ToString());

                // Somente para furo (3) e rosca (4)
                if (_codigoTipoOperacao == 3 || _codigoTipoOperacao == 4)
                {
                    if (_ferramenta == string.Empty)
                        _ferramenta = _linha[3].ToString();

                    if (_ferramenta != _linha[3].ToString())
                    {
                        // Quebrar bloco
                        _ferramenta = _linha[3].ToString();
                        _codigoGrupo = _codigoGrupo + 1;
                    }

                    // Adicionar operação ao grupo
                    _agrupador.Rows.Add(_codigoGrupo, _linha[0].ToString());
                }

            }

            return _agrupador;
        }
        #endregion


    }
}
