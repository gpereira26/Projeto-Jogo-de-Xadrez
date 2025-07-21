using ProjJogoXadrez.tabuleiro;
using ProjJogoXadrez.tabuleiro.Enums;

namespace ProjJogoXadrez.xadrez
{
    internal class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
