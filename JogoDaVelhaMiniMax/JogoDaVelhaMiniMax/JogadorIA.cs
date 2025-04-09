using System;

namespace JogoDaVelhaIA
{
    class JogadorIA
    {
        private Tabuleiro tabuleiro;

        public JogadorIA(Tabuleiro tabuleiro)
        {
            this.tabuleiro = tabuleiro;
        }

        // Implementação do algoritmo Minimax
        public int Minimax(bool maximizando)
        {
            char resultado = tabuleiro.VerificarVencedor();
            if (resultado == 'O') return 1;
            if (resultado == 'X') return -1;
            if (resultado == 'E') return 0;

            if (maximizando)
            {
                int melhorPontuacao = int.MinValue;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        if (tabuleiro.PosicaoVazia(i, j))
                        {
                            tabuleiro.FazerJogada(i, j, 'O');
                            int pontuacao = Minimax(false);
                            tabuleiro.FazerJogada(i, j, ' ');
                            melhorPontuacao = Math.Max(pontuacao, melhorPontuacao);
                        }
                    }
                return melhorPontuacao;
            }
            else
            {
                int melhorPontuacao = int.MaxValue;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        if (tabuleiro.PosicaoVazia(i, j))
                        {
                            tabuleiro.FazerJogada(i, j, 'X');
                            int pontuacao = Minimax(true);
                            tabuleiro.FazerJogada(i, j, ' ');
                            melhorPontuacao = Math.Min(pontuacao, melhorPontuacao);
                        }
                    }
                return melhorPontuacao;
            }
        }

        // Encontra a melhor jogada para a IA
        public Tuple<int, int> MelhorJogada()
        {
            int melhorValor = int.MinValue;
            Tuple<int, int> melhorMovimento = null;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (tabuleiro.PosicaoVazia(i, j))
                    {
                        tabuleiro.FazerJogada(i, j, 'O');
                        int valor = Minimax(false);
                        tabuleiro.FazerJogada(i, j, ' ');
                        if (valor > melhorValor)
                        {
                            melhorValor = valor;
                            melhorMovimento = Tuple.Create(i, j);
                        }
                    }
                }

            return melhorMovimento;
        }
    }
}