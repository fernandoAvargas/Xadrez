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

        public Peca Peca(Posicao pos)
        {
            return Pecas[pos.linha, pos.coluna];
        }

        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);

            return Peca(pos) != null;
        }

        public Peca Peca(int linha,int coluna)
        {
            return Pecas[linha, coluna];
        }

        public void ColocarPeca(Peca p,Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");

            }

                Pecas[pos.linha, pos.coluna] = p;

                p.Posicao = pos;

            

        }

        public bool PosicaoValida(Posicao pos) {

            if (pos.linha<0 || pos.linha>=Linhas||pos.coluna<0 || pos.coluna>=Colunas)
            {

                return false;
            }

            return true;
        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida!");

            }


        }
    }
}
