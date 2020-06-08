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

                    try
                    {
                        Console.Clear();

                        Tela.ImprimirTabuleiro(partida.Tab);

                        Console.WriteLine();

                        Console.WriteLine("Turno: " + partida.Turno);

                        Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);

                        Console.WriteLine("Origem: ");

                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                        partida.ValidarPosicaoDeOrigem(origem);

                        bool[,] movimentosPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();

                        Console.Clear();

                        Tela.ImprimirTabuleiro(partida.Tab, movimentosPossiveis);

                        Console.WriteLine();

                        Console.WriteLine("Destino: ");

                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                        partida.ValidarPosicaoDestino(origem, destino);

                        partida.RealizarJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);

                        Console.ReadLine();
                    }

                }



                Tela.ImprimirTabuleiro(partida.Tab);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();           
        }
    }
}
