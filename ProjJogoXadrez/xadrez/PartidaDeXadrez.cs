using System.Reflection.PortableExecutable;
using tabuleiro;
using tabuleiro.Enums;

namespace xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;
        public bool Xeque { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Xeque = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQtdMovimentos();
            Peca PecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if (PecaCapturada != null) Capturadas.Add(PecaCapturada);
            return PecaCapturada;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecacapturada)
        {
            Peca p = Tab.RetirarPeca(destino);
            p.DecrementarQtdMovimentos();
            if (pecacapturada != null)
            {
                Tab.ColocarPeca(pecacapturada, destino);
                Capturadas.Remove(pecacapturada);
            }
            Tab.ColocarPeca(p, origem);
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca PecaCapturada = ExecutaMovimento(origem, destino);
            if (EstaEmCheque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, PecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }
            if (EstaEmCheque(Adversaria(JogadorAtual))) Xeque = true;
            else Xeque = false;
            Turno++;
            MudaJogador();
        }
        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca) JogadorAtual = Cor.Preta;
            else JogadorAtual = Cor.Branca;
        }

        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if (Tab.peca(pos) == null) throw new TabuleiroException("Não existe peça na posição de origem escolhida");
            if (JogadorAtual != Tab.peca(pos).Cor) throw new TabuleiroException("A peça de origem escolhida não é sua!");
            if (!Tab.peca(pos).ExisteMovimentosPossiveis()) throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhidas");
        }
        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.peca(origem).PodeMoverPara(destino)) throw new TabuleiroException("Posição de destino inválida!");
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if (x.Cor == cor) aux.Add(x);
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecas)
            {
                if (x.Cor == cor) aux.Add(x);
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        private Cor Adversaria(Cor cor)
        {
            if (cor == Cor.Branca) return Cor.Preta;
            else return Cor.Branca;
        }

        private Peca Rei (Cor cor)
        {
            foreach (Peca x in PecasEmJogo(cor))
            {
                if (x is Rei) return x;
            }
            return null;
        }

        public bool EstaEmCheque(Cor cor)
        {
            Peca R = Rei(cor);
            if (R == null) throw new TabuleiroException($"Não tem rei da cor {cor} no Tabuleiro!");
            foreach (Peca x in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = x.MovimentosPossiveis();
                if (mat[R.Posicao.Linha, R.Posicao.Coluna]) return true;
            }
            return false;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }
        private void ColocarPecas()
        {
            ColocarNovaPeca('a', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('b', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('c', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('e', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('f', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('g', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('h', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rei(Tab, Cor.Preta));

            ColocarNovaPeca('a', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('b', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('c', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('e', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('f', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('g', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('h', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branca));
        }
    }
}
