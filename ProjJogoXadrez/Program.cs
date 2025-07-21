using xadrez;
using tabuleiro;
using tabuleiro.Enums;
namespace ProjJogoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);
            try
            {
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 7));
                tab.ColocarPeca(new Torre(tab, Cor.Branca), new Posicao(1, 3));
                tab.ColocarPeca(new Rei(tab, Cor.Branca), new Posicao(2, 4));
                tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(6, 3));
                Tela.ImprimirTabuleiro(tab);
            }
            catch (TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
            }
                Console.ReadLine();

        }
    }
}