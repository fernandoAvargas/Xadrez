
using tabuleiro;

namespace xadrez_console.xadrez
{
    class Rainha : Peca
    {
        public Rainha(Tabuleiro tab,Cor cor): base(tab, cor) { }

        public override bool[,] MovimentosPossiveis()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return "R";
        }
    }

}
