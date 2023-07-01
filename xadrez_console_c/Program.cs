using tabuleiro;
using System;

namespace xadrez_console_c
{
    class Program
    {
        static void Main(string[] args)
        {
            Posicao p = new Posicao(3, 4);

            Tabuleiro tab = new Tabuleiro(8,8);

            Peca peca = new Peca(p, Cor.Preta, tab);

            Console.WriteLine("Posição: " + p.ToString());
            Console.WriteLine("Tabuleiro: " + tab.ToString());
            Console.WriteLine("Peca: " + peca.ToString());

            Tela.imprimirTabuleiro(tab);
        }
    }

}