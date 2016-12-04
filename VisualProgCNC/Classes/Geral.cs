using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;

namespace Fiori.Windows.VisualProgCNC.Classes
{
    public static class Geral
    {
        public static double? EscalaX = null;
        public static double? EscalaY = null;
        public static double? MedidaMMCalcularEscalaX = null;
        public static double? MedidaMMCalcularEscalaY = null;
        public static Point PontoZero = Point.Empty;
        public static string Eixo = null;
        public static string PathImagem = null;
        public static int? CodigoTipoOperacao = null;
        public static string DescricaoFerramentaSelecionada = null;
        public static double? Raio = null;
        public static DataTable TabelaOperacoes = new DataTable("Operacoes");
        public static string PathArquivoCNC = null;

        public static string DescricaoTipoOperacao
        {
            get
            {
                string _retorno = string.Empty;

                if (CodigoTipoOperacao == 1)
                    _retorno = "Fresar com Raio";
                else if (CodigoTipoOperacao == 2)
                    _retorno = "Fresar";
                else if (CodigoTipoOperacao == 3)
                    _retorno = "Furar";
                else if (CodigoTipoOperacao == 4)
                    _retorno = "Roscar";

                return _retorno;
            }
        }

        public static float LarguraLinhaDesenho = 5; 
        public static Color CorTipoOperacaoFresarComRaio = Color.Red;
        public static Color CorTipoOperacaoFresar = Color.Blue;
        public static Color CorTipoOperacaoFurar = Color.Lime;
        public static Color CorTipoOperacaoRoscar = Color.Yellow;

        public static Color CorTipoOperacao(int? codigoTipoOperacao_)
        {
            Color _retorno = Color.Empty;

            if (codigoTipoOperacao_ == 1) // Fresar com Raio
                _retorno = CorTipoOperacaoFresarComRaio;
            else if (codigoTipoOperacao_ == 2) // Fresar
                _retorno = CorTipoOperacaoFresar;
            else if (codigoTipoOperacao_ == 3) // Furar
                _retorno = CorTipoOperacaoFurar;
            else if (codigoTipoOperacao_ == 4) // Roscar
                _retorno = CorTipoOperacaoRoscar;

            return _retorno;
        }

    }
}
