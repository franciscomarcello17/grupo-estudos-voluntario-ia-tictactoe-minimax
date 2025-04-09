using System;

namespace JogoDaVelhaIA
{
    class Tabuleiro
    {
        public char[,] tabuleiro = new char[3, 3];

        public Tabuleiro()
        {
            // Inicializa o tabuleiro vazio
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    tabuleiro[i, j] = ' ';
        }

        // Exibe o tabuleiro no console
        public void Mostrar()
        {
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("     |     |     ");
                Console.WriteLine($"  {tabuleiro[i, 0]}  |  {tabuleiro[i, 1]}  |  {tabuleiro[i, 2]}");
                Console.WriteLine("     |     |     ");
                if (i < 2)
                    Console.WriteLine("-----+-----+-----");
            }
            Console.WriteLine();
        }

        // Verifica se há um vencedor ou empate
        public char VerificarVencedor()
        {
            // Verifica linhas e colunas
            for (int i = 0; i < 3; i++)
            {
                if (tabuleiro[i, 0] == tabuleiro[i, 1] && tabuleiro[i, 1] == tabuleiro[i, 2] && tabuleiro[i, 0] != ' ')
                    return tabuleiro[i, 0];
                if (tabuleiro[0, i] == tabuleiro[1, i] && tabuleiro[1, i] == tabuleiro[2, i] && tabuleiro[0, i] != ' ')
                    return tabuleiro[0, i];
            }

            // Verifica diagonais
            if (tabuleiro[0, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 2] && tabuleiro[0, 0] != ' ')
                return tabuleiro[0, 0];
            if (tabuleiro[0, 2] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 0] && tabuleiro[0, 2] != ' ')
                return tabuleiro[0, 2];

            // Verifica empate
            foreach (char c in tabuleiro)
                if (c == ' ') return ' ';

            return 'E'; // Empate
        }

        // Verifica se uma posição está vazia
        public bool PosicaoVazia(int linha, int coluna)
        {
            return tabuleiro[linha, coluna] == ' ';
        }

        // Faz uma jogada no tabuleiro
        public void FazerJogada(int linha, int coluna, char simbolo)
        {
            tabuleiro[linha, coluna] = simbolo;
        }
    }
}