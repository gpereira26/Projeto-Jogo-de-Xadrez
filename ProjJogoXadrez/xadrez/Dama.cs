using tabuleiro;
using tabuleiro.Enums;

namespace xadrez
{
    internal class Dama : Peca
    {
        public Dama(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p == null || p.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // nordeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor) break;

                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }
            // noroeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                //testar se da para tirar esse if
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor) break;

                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }

            // sudeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor) break;

                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }

            // sudoeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor) break;

                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }
            //norte
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                while (Tab.PosicaoValida(pos) && PodeMover(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                    if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor) break;

                    pos.DefinirValores(pos.Linha - 1, pos.Coluna);
                }
                // sul
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                while (Tab.PosicaoValida(pos) && PodeMover(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                    //testar se da para tirar esse if
                    if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor) break;

                    pos.DefinirValores(pos.Linha + 1, pos.Coluna);
            }

                // leste
                pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
                while (Tab.PosicaoValida(pos) && PodeMover(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                    if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor) break;

                    pos.DefinirValores(pos.Linha, pos.Coluna + 1);
            }

                // oeste
                pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
                while (Tab.PosicaoValida(pos) && PodeMover(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                    if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor) break;

                    pos.DefinirValores(pos.Linha, pos.Coluna - 1);
            }

                return mat;
        }
        public override string ToString()
        {
            return "D";
        }
    }
}
