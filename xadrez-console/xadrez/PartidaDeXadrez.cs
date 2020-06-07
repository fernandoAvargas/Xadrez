using System;
using tabuleiro;
using xadrez;
using xadrez_console.xadrez.Enum;

namespace xadrez_console.xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            ColocarPecas();

        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IcrementarQtdeMovimentos();
            Peca pecaCapiturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
        }

        public void ColocarPecas()
        {
            // Colocar todas as peças no tabuleiro            

            for (int i = 0; i <= 15; i++)
            {
                var coluna = (i <= 7) ? (Casas)i : (Casas)i - 8;

                var cor = (i <= 7) ? Cor.Branca : Cor.Vermelha;

                var linha = (i <= 7) ? 2 : 7;

                tab.ColocarPeca(new Peao(tab, cor), new PosicaoXadrez(linha,char.Parse(coluna.ToString())).ToPosicao());

                linha = (i <= 7) ? 1 : 8;

                if (i == 0 || i == 7 || i == 8 || i == 15)

                    tab.ColocarPeca(new Torre(tab, cor), new PosicaoXadrez(linha,char.Parse(coluna.ToString())).ToPosicao());

                if (i == 1 || i == 6 || i == 9 || i == 14)

                    tab.ColocarPeca(new Cavalo(tab, cor), new PosicaoXadrez(linha,char.Parse(coluna.ToString())).ToPosicao());

                if (i == 2 || i == 5 || i == 10 || i == 13)

                    tab.ColocarPeca(new Bispo(tab, cor), new PosicaoXadrez(linha,char.Parse(coluna.ToString())).ToPosicao());

                if (i == 3 || i == 11)
                {
                    tab.ColocarPeca(new Rainha(tab, cor), new PosicaoXadrez(linha,char.Parse(coluna.ToString())).ToPosicao());
                }
                else if(i == 4 || i == 12)
                {
                    tab.ColocarPeca(new Rei(tab, cor), new PosicaoXadrez(linha,char.Parse(coluna.ToString())).ToPosicao());
                }
            }
        }
    }
}

