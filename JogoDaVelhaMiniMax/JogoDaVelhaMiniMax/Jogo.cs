using System;
using System.Collections.Generic;

namespace JogoDaVelhaIA
{
    class Jogo
    {
        private Tabuleiro tabuleiro;
        private JogadorIA ia;
        private bool turnoJogador;

        public Jogo()
        {
            tabuleiro = new Tabuleiro();
            ia = new JogadorIA(tabuleiro);
            turnoJogador = true;
        }

        public void Iniciar()
        {
            while (true)
            {
                Console.Clear();
                tabuleiro.Mostrar();

                char resultado = tabuleiro.VerificarVencedor();
                if (resultado != ' ')
                {
                    Console.WriteLine();
                    Console.WriteLine(resultado == 'E' ? "Empate!" : (resultado == 'X' ? "Você venceu!" : "A IA venceu!"));
                    break;
                }

                if (turnoJogador)
                {
                    JogadaHumano();
                }
                else
                {
                    JogadaIA();
                }
            }

            Console.WriteLine("\nJogo finalizado. Pressione qualquer tecla para sair.");
            Console.ReadKey();
        }

        private void JogadaHumano()
        {
            Console.Write("Escolha uma posição (1-9): ");
            int pos;
            bool valido = int.TryParse(Console.ReadLine(), out pos);
            if (!valido || pos < 1 || pos > 9)
                return;

            int linha = (pos - 1) / 3;
            int coluna = (pos - 1) % 3;

            if (!tabuleiro.PosicaoVazia(linha, coluna))
            {
                Console.WriteLine("Posição ocupada! Pressione qualquer tecla...");
                Console.ReadKey();
                return;
            }

            tabuleiro.FazerJogada(linha, coluna, 'X');
            turnoJogador = false;
        }

        private void JogadaIA()
        {
            Console.Clear();
            tabuleiro.Mostrar();
            Console.WriteLine("IA está avaliando jogadas com o algoritmo Minimax...\n");

            // Mostrar valores minimax para cada posição (opcional)
            MostrarAvaliacoesMinimax();

            Console.WriteLine("\nPressione Enter para a IA jogar...");
            Console.ReadLine();

            // Faz a melhor jogada com base no Minimax
            var melhor = ia.MelhorJogada();
            tabuleiro.FazerJogada(melhor.Item1, melhor.Item2, 'O');
            turnoJogador = true;
        }

        private void MostrarAvaliacoesMinimax()
        {
            var avaliacoes = new Dictionary<(int, int), int>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tabuleiro.PosicaoVazia(i, j))
                    {
                        tabuleiro.FazerJogada(i, j, 'O');
                        int pontuacao = ia.Minimax(false);
                        tabuleiro.FazerJogada(i, j, ' ');
                        avaliacoes[(i, j)] = pontuacao;
                        Console.WriteLine($"Posição ({i + 1}, {j + 1}) → Valor Minimax: {pontuacao}");
                    }
                }
            }
        }
    }
}