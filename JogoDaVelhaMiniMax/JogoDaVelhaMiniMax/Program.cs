using System;

namespace JogoDaVelhaIA
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("==== JOGO DA VELHA ====");
            Console.WriteLine("Você é o X | IA é o O");
            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para começar.");
            Console.ReadLine();

            Jogo jogo = new Jogo();
            jogo.Iniciar();
        }
    }
}