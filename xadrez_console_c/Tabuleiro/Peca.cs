﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro
{
     abstract class Peca
    {
        public Posicao posicao { get; set; }

        public Cor cor { get; protected set; }

        public int qtdMovimentos { get; protected set ; }

        public Tabuleiro tab { get; protected set; }


        public Peca(Cor cor, Tabuleiro tab )
        {
            this.posicao = null;
            this.cor = cor;
            this.tab = tab;
            this.qtdMovimentos = 0;
        }

        public void incrementarQtdMovimentos()
        {
            qtdMovimentos++;
        }

        public void decrementarQteMovimentos()
        {
            qtdMovimentos--;
        }

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

     

        public abstract bool[,] movimentosPossiveis(); 

        public override string ToString()
        {
            return posicao + ", " + cor + ", "+ tab;
        }

        public bool movimentoPossivel(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }
    }
}
