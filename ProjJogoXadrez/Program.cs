using xadrez;
using tabuleiro;
using tabuleiro.Enums;
namespace ProjJogoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PosicaoXadrez pos = new PosicaoXadrez('a', 1);
                Console.WriteLine(pos.ToPosicao());
            }
            catch (TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
            }
                Console.ReadLine();

        }
    }
}