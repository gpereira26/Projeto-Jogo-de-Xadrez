﻿using ProjJogoXadrez.tabuleiro;
using tabuleiro;
namespace ProjJogoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            Tela.ImprimirTabuleiro(tab);
            Console.ReadLine();
        }
    }
}