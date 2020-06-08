using System;
using System.Data;
using tabuleiro;
using xadrez;
using xadrez_console.xadrez.Enum;

namespace xadrez_console.xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            terminada = false;
            ColocarPecas();

        }

        public void RealizarJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudarJogador();
        }


        public void ValidarPosicaoDeOrigem(Posicao pos)
        {

            if (Tab.Peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }

            if(JogadorAtual != Tab.Peca(pos).Cor)
            {
                throw new TabuleiroException("A peça que você escolheu não é sua!");
            }

            if (!Tab.Peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não existe movimentos possíveis para a peça escolhida!");
            }

        }

        public void ValidarPosicaoDestino(Posicao origem,Posicao destino)
        {
            if (!Tab.Peca(origem).PodeMoverParaDestino(destino))
            {
                throw new TabuleiroException("Posição de destino inválida");

            }


        }


        private void MudarJogador()
        {
            if(JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IcrementarQtdeMovimentos();
            Peca pecaCapiturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
        }

        public void ColocarPecas()
        {
            // Colocar todas as peças no tabuleiro            

            for (int i = 0; i <= 15; i++)
            {
                var coluna = (i <= 7) ? (Casas)i : (Casas)i - 8;

                var cor = (i <= 7) ? Cor.Branca : Cor.Vermelha;

                var linha = (i <= 7) ? 2 : 7;

                Tab.ColocarPeca(new Peao(Tab, cor), new PosicaoXadrez(linha,char.Parse(coluna.ToString())).ToPosicao());

                linha = (i <= 7) ? 1 : 8;

                if (i == 0 || i == 7 || i == 8 || i == 15)

                    Tab.ColocarPeca(new Torre(Tab, cor), new PosicaoXadrez(linha,char.Parse(coluna.ToString())).ToPosicao());

                if (i == 1 || i == 6 || i == 9 || i == 14)

                    Tab.ColocarPeca(new Cavalo(Tab, cor), new PosicaoXadrez(linha,char.Parse(coluna.ToString())).ToPosicao());

                if (i == 2 || i == 5 || i == 10 || i == 13)

                    Tab.ColocarPeca(new Bispo(Tab, cor), new PosicaoXadrez(linha,char.Parse(coluna.ToString())).ToPosicao());

                if (i == 3 || i == 11)
                {
                    Tab.ColocarPeca(new Rainha(Tab, cor), new PosicaoXadrez(linha,char.Parse(coluna.ToString())).ToPosicao());
                }
                else if(i == 4 || i == 12)
                {
                    Tab.ColocarPeca(new Rei(Tab, cor), new PosicaoXadrez(linha,char.Parse(coluna.ToString())).ToPosicao());
                }
            }
        }
    }
}

