using ProjJogoXadrez.tabuleiro;
using ProjJogoXadrez.tabuleiro.Enums;

namespace ProjJogoXadrez.xadrez
{
    internal class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
