using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[Linhas, Colunas];
        }

        public Peca Peca(int linha,int coluna)
        {
            return Pecas[linha, coluna];


        }

        public void ColocarPeca(Peca p,Posicao pos)
        {

            Pecas[pos.linha, pos.coluna] = p;

            p.Posicao = pos;

        }
    }
}
