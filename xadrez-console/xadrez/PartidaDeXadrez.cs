using System;
using System.Collections.Generic;
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

        private HashSet<Peca> pecas;

        private HashSet<Peca> capturadas;

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();

        }

        public void ExecutarMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);

            p.IcrementarQtdeMovimentos();

            Peca pecaCapiturada = Tab.RetirarPeca(destino);

            Tab.ColocarPeca(p, destino);

            if (pecaCapiturada != null)
            {
                capturadas.Add(pecaCapiturada);
            }
        }

        public void RealizarJogada(Posicao origem, Posicao destino)
        {
            ExecutarMovimento(origem, destino);
            Turno++;
            MudarJogador();
        }


        public void ValidarPosicaoDeOrigem(Posicao pos)
        {

            if (Tab.Peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }

            if (JogadorAtual != Tab.Peca(pos).Cor)
            {
                if ("Vermelha" != (Tab.Peca(pos).Cor).ToString())
                {
                    throw new TabuleiroException("A peça que você escolheu não é sua!");
                }
            }

            if (!Tab.Peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não existe movimentos possíveis para a peça escolhida!");
            }

        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.Peca(origem).PodeMoverParaDestino(destino))
            {
                throw new TabuleiroException("Posição de destino inválida");

            }
        }

        private void MudarJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        //public void ExecutaMovimentos(Posicao origem, Posicao destino)
        //{
        //    Peca p = Tab.RetirarPeca(origem);
        //    p.IcrementarQtdeMovimentos();
        //    Peca pecaCapiturada = Tab.RetirarPeca(destino);
        //    Tab.ColocarPeca(p, destino);
        //}

        public void ColocarNovaPeca(int linha, char coluna, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(linha, coluna).ToPosicao());
            pecas.Add(peca);

        }

        public HashSet<Peca>PecasCapturadas(Cor cor) {

            HashSet<Peca> aux = new HashSet<Peca>();

            cor = cor == Cor.Preta?Cor.Vermelha:Cor.Branca;

            foreach(Peca x in capturadas)
            {
                if(x.Cor == cor){

                    aux.Add(x);
                }
            }

            return aux;        
        }


        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in pecas)
            {
                if (x.Cor == cor)
                {

                    aux.Add(x);
                }
            }

            aux.ExceptWith(PecasCapturadas(cor));

            return aux;
        }
        public void ColocarPecas()
        {
            // Colocar todas as peças no tabuleiro        

            for (int i = 0; i <= 15; i++)
            {
                var coluna = (i <= 7) ? (Casas)i : (Casas)i - 8;

                var cor = (i <= 7) ? Cor.Branca : Cor.Vermelha;

                var linha = (i <= 7) ? 2 : 7;

                ColocarNovaPeca(linha, char.Parse(coluna.ToString()), new Peao(Tab, cor));

                linha = (i <= 7) ? 1 : 8;

                if (i == 0 || i == 7 || i == 8 || i == 15)

                    ColocarNovaPeca(linha, char.Parse(coluna.ToString()), new Torre(Tab, cor));

                if (i == 1 || i == 6 || i == 9 || i == 14)

                    ColocarNovaPeca(linha, char.Parse(coluna.ToString()), new Cavalo(Tab, cor));

                if (i == 2 || i == 5 || i == 10 || i == 13)

                    ColocarNovaPeca(linha, char.Parse(coluna.ToString()), new Bispo(Tab, cor));

                if (i == 3 || i == 11)
                {
                    ColocarNovaPeca(linha, char.Parse(coluna.ToString()), new Rainha(Tab, cor));
                }
                else if (i == 4 || i == 12)
                {
                    ColocarNovaPeca(linha, char.Parse(coluna.ToString()), new Rei(Tab, cor));
                }
            }
        }
    }
}

