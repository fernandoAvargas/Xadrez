﻿
using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;
using xadrez_console.xadrez;

namespace xadrez_console
{
    class Tela
    {

        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.Tab);

            Console.WriteLine();

            ImprimirPecasCapturadas(partida);

            Console.WriteLine();

            Console.WriteLine("Turno: " + partida.Turno);

            Console.WriteLine();

            Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
        }
        
        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida) {

            Console.WriteLine("Peças capturadas: ");

            Console.WriteLine();

            Console.Write("Brancas: ");

            ImprimirConjuntoPartida(partida.PecasCapturadas(Cor.Branca));

            Console.WriteLine();

            Console.Write("Pretas: ");

            ImprimirConjuntoPartida(partida.PecasCapturadas(Cor.Preta));
        }

        public static void ImprimirConjuntoPartida(HashSet<Peca> conjunto)
        {
            Console.Write("[");

            foreach (Peca x in conjunto)
            {
                Console.Write( x + " ");
            }

            Console.Write("]");

            Console.WriteLine();
        }
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {

            for(int i=0;i<tab.Linhas; i++)
            {
                Console.Write(8 - i + "-> ");

                for(int j=0;j<tab.Colunas; j++)
                {

                    ImprimirPeca(tab.Peca(i, j));

                }

                Console.WriteLine();               

            }

            Console.WriteLine("    | | | | | | | |");
            Console.WriteLine("    A B C D E F G H");

        }


        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,]movimentosPossiveis)
        {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + "-> ");

                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (movimentosPossiveis[i, j])
                    {

                        Console.BackgroundColor = fundoAlterado;

                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }



                    ImprimirPeca(tab.Peca(i, j));

                }

                Console.WriteLine();

            }

            Console.WriteLine("    | | | | | | | |");
            Console.WriteLine("    A B C D E F G H");

            Console.BackgroundColor = fundoOriginal;

        }
        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();

            char coluna = s[0];
            int linha = int.Parse(s[1] + "");

            return new PosicaoXadrez(linha,coluna);
        }

        public static void ImprimirPeca(Peca peca)
        {

            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }

                Console.Write(" ");
            }

        }

    }

}
