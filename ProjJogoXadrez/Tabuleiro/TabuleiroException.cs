using System;
namespace ProjJogoXadrez.tabuleiro
{
    internal class TabuleiroException : Exception
    {
        public TabuleiroException(string message) : base(message)
        {
        }
    }
}
