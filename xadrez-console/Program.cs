using System;
using tabuleiro;
using xadrez;
using xadrez_console.xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    Console.Clear();

                    Tela.ImprimirTabuleiro(partida.tab);

                    Console.WriteLine();

                    Console.WriteLine("Origem: ");

                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                    Console.WriteLine("Destino: ");

                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partida.ExecutaMovimento(origem, destino);

                }



                Tela.ImprimirTabuleiro(partida.tab);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();           
        }
    }
}
