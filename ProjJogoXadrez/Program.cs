using ProjJogoXadrez.tabuleiro;
using ProjJogoXadrez.xadrez;
using tabuleiro;
using ProjJogoXadrez.tabuleiro.Enums;
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
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
                tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(2, 4));
                bool test = tab.ExistePeca(new Posicao(0, 0));
                Console.WriteLine(test);
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