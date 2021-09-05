﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoMVC_02
{
    public partial class Form1 : Form
    {
        List<string> ListaDePalavras = new List<string>();
        Model.Jogadores jogada = new Model.Jogadores();

        public Form1()
        {
            InitializeComponent();
            EscreveMatrix();
        }
        public void EscreveMatrix()
        {
            // Matrix será a referencia usada para cada letra usada no tabuleiro

            matrix1.Text = Model.Geradores.iniciaTabuleiro("A", "D");
            matrix2.Text = Model.Geradores.iniciaTabuleiro("E", "F");
            matrix3.Text = Model.Geradores.iniciaTabuleiro("B", "C");

            matrix4.Text = Model.Geradores.iniciaTabuleiro("G", "I", "U");
            matrix5.Text = Model.Geradores.iniciaTabuleiro("H", "J", "V");
            matrix6.Text = Model.Geradores.iniciaTabuleiro("K", "L");

            matrix7.Text = Model.Geradores.iniciaTabuleiro("M", "O", "Q");
            matrix8.Text = Model.Geradores.iniciaTabuleiro("N", "T", "P");
            matrix9.Text = Model.Geradores.iniciaTabuleiro("R", "S", "Z");
        }

        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            textBoxPalavra.Text = textBoxPalavra.Text.ToUpper();

            bool repetido = false;
            string[][] matriztabuleiro = new string[3][];

            for (int i = 0; i < matriztabuleiro.Length; i++)
            {
                matriztabuleiro[i] = new string[3];
            }

            matriztabuleiro[0][0] = matrix1.Text;
            matriztabuleiro[0][1] = matrix2.Text;
            matriztabuleiro[0][2] = matrix3.Text;

            matriztabuleiro[1][0] = matrix4.Text;
            matriztabuleiro[1][1] = matrix5.Text;
            matriztabuleiro[1][2] = matrix6.Text;

            matriztabuleiro[2][0] = matrix7.Text;
            matriztabuleiro[2][1] = matrix8.Text;
            matriztabuleiro[2][2] = matrix9.Text;



            foreach (var item in ListaDePalavras)
            {
                if (item == textBoxPalavra.Text)
                {
                    repetido = true;
                }
            }

            if (repetido == false)
            {
                ListaDePalavras.Add(textBoxPalavra.Text);
                Controller.Controladores.Pontos(matriztabuleiro, textBoxPalavra.Text, out int acertos);

                jogada.Rodada += 1;
                jogada.Palavra = textBoxPalavra.Text;
                jogada.Pontos = acertos;
                jogada.Jogador = Controller.Controladores.Pontos(matriztabuleiro, textBoxPalavra.Text, out acertos);

                dataGridView.Rows.Add(jogada.Rodada, jogada.Palavra, jogada.Pontos, jogada.Jogador);
            }
            else if (repetido == true)
            {
                MessageBox.Show("Palavra Repetida, tente outra!");
            }
        }

        private void buttonResetar_Click(object sender, EventArgs e)
        {
            EscreveMatrix();
            textBoxPalavra.Clear();
            dataGridView.Rows.Clear();
            ListaDePalavras.Clear();
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
