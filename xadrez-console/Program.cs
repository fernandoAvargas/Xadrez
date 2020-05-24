using System;
using tabuleiro;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Tabuleiro tab = new Tabuleiro(8, 8);

            Tela.ImprimirTabuleiro(tab);


            Console.ReadLine();

            //Posicao P;

            //P = new Posicao(3, 4);

            //Console.WriteLine("Posição: " + P);

            //Console.ReadLine();

            //Tabuleiro tab = new Tabuleiro(8, 8);

            //Console.WriteLine("--------------------------------");

            //Console.ReadLine();

        }
    }
}
