﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using xadrez;

namespace xadrez
{
    class PartidaXadrez
    {

        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }
        public Peca vulneravelEnPassant { get; private set; }

        public PartidaXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            xeque = false;
            vulneravelEnPassant = null;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }



        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).movimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca rei(Cor cor)
        {
            foreach (Peca x in pecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executaMovimento(origem, destino);

            Peca p = tab.peca(destino);


        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }


        private void colocarPecas()
        {
            colocarNovaPeca('a', 1, new Torre   (Cor.Branca, tab ));
            colocarNovaPeca('b', 1, new Cavalo  (Cor.Branca, tab));
            colocarNovaPeca('c', 1, new Bispo   (Cor.Branca, tab));
            colocarNovaPeca('d', 1, new Rainha  (Cor.Branca, tab));
            colocarNovaPeca('e', 1, new Rei     (Cor.Branca, tab));
            colocarNovaPeca('f', 1, new Bispo   (Cor.Branca, tab));
            colocarNovaPeca('g', 1, new Cavalo  (Cor.Branca, tab));
            colocarNovaPeca('h', 1, new Torre   (Cor.Branca, tab));
            colocarNovaPeca('a', 2, new Peao    (Cor.Branca, tab));
            colocarNovaPeca('b', 2, new Peao    (Cor.Branca, tab));
            colocarNovaPeca('c', 2, new Peao    (Cor.Branca, tab));
            colocarNovaPeca('d', 2, new Peao    (Cor.Branca, tab));
            colocarNovaPeca('e', 2, new Peao    (Cor.Branca, tab));
            colocarNovaPeca('f', 2, new Peao    (Cor.Branca, tab));
            colocarNovaPeca('g', 2, new Peao    (Cor.Branca, tab));
            colocarNovaPeca('h', 2, new Peao    (Cor.Branca, tab));

            colocarNovaPeca('a', 8, new Torre   (Cor.Preta, tab ));
            colocarNovaPeca('b', 8, new Cavalo  (Cor.Preta, tab ));
            colocarNovaPeca('c', 8, new Bispo   (Cor.Preta, tab ));
            colocarNovaPeca('d', 8, new Rainha  (Cor.Preta, tab ));
            colocarNovaPeca('e', 8, new Rei     (Cor.Preta, tab ));
            colocarNovaPeca('f', 8, new Bispo   (Cor.Preta, tab ));
            colocarNovaPeca('g', 8, new Cavalo  (Cor.Preta, tab ));
            colocarNovaPeca('h', 8, new Torre   (Cor.Preta, tab ));
            colocarNovaPeca('a', 7, new Peao    (Cor.Preta, tab ));
            colocarNovaPeca('b', 7, new Peao    (Cor.Preta, tab ));
            colocarNovaPeca('c', 7, new Peao    (Cor.Preta, tab ));
            colocarNovaPeca('d', 7, new Peao    (Cor.Preta, tab ));
            colocarNovaPeca('e', 7, new Peao    (Cor.Preta, tab ));
            colocarNovaPeca('f', 7, new Peao    (Cor.Preta, tab ));
            colocarNovaPeca('g', 7, new Peao    (Cor.Preta, tab ));
            colocarNovaPeca('h', 7, new Peao    (Cor.Preta, tab));
        }

        public Peca executaMovimento(Posicao origem, Posicao destino) {

            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }

            return pecaCapturada;
        }
    }
}