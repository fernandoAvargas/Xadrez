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


            //PosicaoXadrez pos1 = new PosicaoXadrez('a', 1);


            //Console.WriteLine(pos1);

            //Console.WriteLine(pos1.ToPosicao());

            //PosicaoXadrez pos2 = new PosicaoXadrez('b', 7);

            //Console.WriteLine(pos2.ToPosicao());

            //PosicaoXadrez pos3 = new PosicaoXadrez('c', 7);

            //Console.WriteLine(pos3.ToPosicao());


            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 2));
                tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(2, 4));

                tab.ColocarPeca(new Torre(tab, Cor.Branca), new Posicao(3, 5));
                tab.ColocarPeca(new Cavalo(tab, Cor.Branca), new Posicao(7, 2));

                Tela.ImprimirTabuleiro(tab);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();           
        }
    }
}
