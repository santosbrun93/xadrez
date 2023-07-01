using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro
{
    class Peca
    {
        public Posicao Posicao { get; set; }

        public Cor cor { get; protected set; }

        public int qtdMovimentos { get; protected set ; }

        public Tabuleiro tab { get; protected set; }


        public Peca(Posicao posicao, Cor cor, Tabuleiro tab)
        {
            Posicao = posicao;
            this.cor = cor;
            this.tab = tab;
            this.qtdMovimentos = 0;
        }

        public override string ToString()
        {
            return Posicao + ", " + cor + ", "+ tab;
        }
    }
}
