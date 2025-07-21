using System.Reflection.PortableExecutable;
using tabuleiro;

namespace xadrez
{
    internal class PosicaoXadrez
    {
        public char Coluna { get; set; }    
        public int Linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        public Posicao ToPosicao()
        {
            if (Coluna == 'A')
            return new Posicao(8 - Linha, Coluna - 'A');
            return new Posicao(8 - Linha, Coluna - 'a');

        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }

    }
}
