

using tabuleiro;

namespace xadrez_console.xadrez
{
    class Peao : Peca
    {       
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor) {  }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != Cor;

        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // var cor = this.Cor;

            if (this.Cor == Cor.Branca)
            {

                //no

                pos.DefinirValores(Posicao.linha - 1, Posicao.coluna);

                if (Tab.PosicaoValida(pos) && PodeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //ne

                pos.DefinirValores(Posicao.linha - 2, Posicao.coluna);
                if (Tab.PosicaoValida(pos) && PodeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            else
            {

                //no

                pos.DefinirValores(Posicao.linha + 1, Posicao.coluna);

                if (Tab.PosicaoValida(pos) && PodeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //ne

                pos.DefinirValores(Posicao.linha + 2, Posicao.coluna);
                if (Tab.PosicaoValida(pos) && PodeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }

            return mat;

        }

        public override string ToString()
        {
            return "P";
        }
    }
}
