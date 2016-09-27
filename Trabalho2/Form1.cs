using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho2
{
    public partial class Form1 : Form
    {
        private int[] tab = new int[9];
        private int[,] combos = new int[8, 3];
        private int dificuldade, numJogadasX = 0, numJogadasO = 0, vez = 1;
        private int vitoriasX = 0, vitoriasO = 0, empates = 0;

        public Form1()
        {
            InitializeComponent();
            Array.Clear(tab, 0, tab.Length);

            combos[0, 0] = 0;
            combos[0, 1] = 1;
            combos[0, 2] = 2;

            combos[1, 0] = 3;
            combos[1, 1] = 4;
            combos[1, 2] = 5;

            combos[2, 0] = 6;
            combos[2, 1] = 7;
            combos[2, 2] = 8;

            combos[3, 0] = 0;
            combos[3, 1] = 3;
            combos[3, 2] = 6;

            combos[4, 0] = 1;
            combos[4, 1] = 4;
            combos[4, 2] = 7;

            combos[5, 0] = 2;
            combos[5, 1] = 5;
            combos[5, 2] = 8;

            combos[6, 0] = 0;
            combos[6, 1] = 4;
            combos[6, 2] = 8;

            combos[7, 0] = 2;
            combos[7, 1] = 4;
            combos[7, 2] = 6;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "")
            {
                button1.Text = "X";
                tab[0] = 1;
                jogadaUsuario();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "")
            {
                button2.Text = "X";
                tab[1] = 1;
                jogadaUsuario();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "")
            {
                button3.Text = "X";
                tab[2] = 1;
                jogadaUsuario();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "")
            {
                button4.Text = "X";
                tab[3] = 1;
                jogadaUsuario();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "")
            {
                button5.Text = "X";
                tab[4] = 1;
                jogadaUsuario();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "")
            {
                button6.Text = "X";
                tab[5] = 1;
                jogadaUsuario();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "")
            {
                button7.Text = "X";
                tab[6] = 1;
                jogadaUsuario();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.Text == "")
            {
                button8.Text = "X";
                tab[7] = 1;
                jogadaUsuario();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Text == "")
            {
                button9.Text = "X";
                tab[8] = 1;
                jogadaUsuario();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            vitoriasX = 0;
            vitoriasO = 0;
            empates = 0;
            vez = 1;
            atualizaJogo();
        }

        private void novoJogo()
        {
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";

            button1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            button2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            button3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            button4.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            button5.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            button6.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            button7.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            button8.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            button9.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;

            Array.Clear(tab, 0, tab.Length);

            if (radioButton1.Checked)
            {
                dificuldade = 1;
            }
            else if (radioButton2.Checked)
            {
                dificuldade = 2;
            }
            else if (radioButton3.Checked)
            {
                dificuldade = 3;
            }

            numJogadasX = 0;
            numJogadasO = 0;
        }

        private void atualizaJogo()
        {
            lb_vitorias.Text = vitoriasX.ToString();
            lb_empates.Text = empates.ToString();
            lb_derrotas.Text = vitoriasO.ToString();

            novoJogo();

            if (vez == 2)
                jogadaPC();
        }


        private void jogadaUsuario()
        {
            bool resUsuario = verificaTrinca(1);

            if (resUsuario)
            {
                MessageBox.Show("PARABENS VOCE VENCEU!!!");
                vez = 1;
                vitoriasX++;
                atualizaJogo();
            }
            else
            {
                //INCREMENTA A JOGADA DO USUARIO - X
                numJogadasX++;
                jogadaPC();
            }
        }

        private void jogadaPC()
        {
            bool tentativaPC;

            if (dificuldade == 1)
            {
                tentativaPC = jogadaPCFacil();
            }
            else if (dificuldade == 2)
            {
                tentativaPC = jogadaPCIntermediario();
            }
            else
            {
                tentativaPC = jogadaPCDificil();
            }

            
            if (tentativaPC)
            {
                bool resPC = verificaTrinca(2);

                if (resPC)
                {
                    MessageBox.Show("VOCE PERDEU");
                    vez = 2;
                    vitoriasO++;
                    atualizaJogo();
                }
                else
                {
                    //INCREMENTA A JOGADA DO PC - O
                    numJogadasO++;

                    if (numJogadasO == 5)
                        deuVelha();
                }
            }
            else
            {
                deuVelha();   
            }   
        }

        //EMPATE
        private void deuVelha()
        {
            MessageBox.Show("DEU VELHA");
            //INVERTE A VEZ
            if (vez == 1)
            {
                vez = 2;
            }
            else
            {
                vez = 1;
            }
            empates++;
            atualizaJogo();
        }

        //VERIFICA SE HOUVE UMA TRINCA
        private bool verificaTrinca(int valor)
        {
            for (int i = 0; i < 8; i++)
            {
                int j;
                for (j = 0; j < 3; j++)
                {
                    if (tab[combos[i, j]] != valor)
                        break;
                }
                if (j == 3)
                {
                    atualizaCoresGanhador(i);
                    return true;
                }
            }
            return false;
        }

        //VERIFICA SE HOUVE UMA DUPLA (usada no nivel dicil apenas)
        private bool verificaDupla(int valor)
        {
            for (int i = 0; i < 8; i++)
            {
                int count = 0;
                int posJogada = -1;
                for (int j = 0; j < 3; j++)
                {
                    if (tab[combos[i, j]] == valor)
                    {
                        count++;
                    }
                    else
                    {
                        posJogada = combos[i, j];
                    }
                }
                if (count == 2 && tab[posJogada] == 0)
                {
                    tab[posJogada] = 2;
                    atualizaJogadaPC(posJogada);
                    return true;
                }
            }
            return false;
        }

        private bool jogadaPCFacil()
        {
            for (int i = 0; i < 9; i++)
            {
                if (tab[i] < 1)
                {
                    tab[i] = 2;
                    atualizaJogadaPC(i);
                    return true;
                }
            }
            return false;
        }

        private bool jogadaPCIntermediario()
        {
            List<int> posVazias = new List<int>();

            for (int i = 0; i < 9; i++)
            {
                if (tab[i] == 0)
                    posVazias.Add(i);
            }

            //CONVERTE A List PRA UM ARRAY
            int[] aPosVazias = posVazias.ToArray();

            if (aPosVazias.Length > 0)
            {
                Random random = new Random();
                int randPos = random.Next(0, aPosVazias.Length);
                tab[aPosVazias[randPos]] = 2;
                atualizaJogadaPC(aPosVazias[randPos]);
                return true;
            }            
            return false;
        }

        private bool jogadaPCDificil()
        {
            bool controle = false;

            int[] cantos = new int[4];
            cantos[0] = 0;
            cantos[1] = 2;
            cantos[2] = 6;
            cantos[3] = 8;

            if (tab[4] == 0)
            {
                tab[4] = 2;
                atualizaJogadaPC(4);
                controle = true;
            }
            else
            {
                if(numJogadasX < 2)
                {
                    List<int> posVazias = new List<int>();

                    for (int i = 0; i < 4; i++)
                    {
                        if (tab[cantos[i]] == 0)
                            posVazias.Add(cantos[i]);
                    }

                    //CONVERTE A List PRA UM ARRAY
                    int[] aPosVazias = posVazias.ToArray();

                    if (aPosVazias.Length > 0)
                    {
                        //JOGA NO PRIMEIRO CANTO QUE O RANDOM ACHAR
                        Random random = new Random();
                        int randomCanto;
                        randomCanto = random.Next(0, aPosVazias.Length);
                        tab[aPosVazias[randomCanto]] = 2;
                        atualizaJogadaPC(aPosVazias[randomCanto]);
                        controle = true;
                    }
                }
                //TENTA FORMAR UMA TRINCA
                else if (numJogadasO > 1)
                {
                    controle = verificaDupla(2);
                }
            }

            //TENTA BLOQUEAR A TRINCA DO USUARIO
            if (controle == false)
            {
                controle = verificaDupla(1);
            }

            if (controle)
                return true;

            //TENTA JOGAR NO NIVEL INTERMEDIARIO
            return jogadaPCIntermediario();   
        }

        private void atualizaJogadaPC(int posJogada)
        {
            switch(posJogada)
            {
                case 0: button1.Text = "O";
                        button1.ForeColor = System.Drawing.Color.FromArgb(178, 34, 34);
                        break;
                case 1: button2.Text = "O";
                        button2.ForeColor = System.Drawing.Color.FromArgb(178, 34, 34);
                        break;
                case 2: button3.Text = "O";
                        button3.ForeColor = System.Drawing.Color.FromArgb(178, 34, 34);
                        break;
                case 3: button4.Text = "O";
                        button4.ForeColor = System.Drawing.Color.FromArgb(178, 34, 34);
                        break;
                case 4: button5.Text = "O";
                        button5.ForeColor = System.Drawing.Color.FromArgb(178, 34, 34);
                        break;
                case 5: button6.Text = "O";
                        button6.ForeColor = System.Drawing.Color.FromArgb(178, 34, 34);
                        break;
                case 6: button7.Text = "O";
                        button7.ForeColor = System.Drawing.Color.FromArgb(178, 34, 34);
                        break;
                case 7: button8.Text = "O";
                        button8.ForeColor = System.Drawing.Color.FromArgb(178, 34, 34);
                        break;
                case 8: button9.Text = "O";
                        button9.ForeColor = System.Drawing.Color.FromArgb(178, 34, 34);
                        break;
                default: MessageBox.Show("ERRO AO ATUALIZAR JOGADA"); novoJogo(); break;
            }
        }

        private void atualizaCoresGanhador(int i)
        {
            for (int j = 0; j < 3; j++)
            {
                switch(combos[i, j])
                {
                    case 0:
                        button1.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
                        break;
                    case 1:
                        button2.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
                        break;
                    case 2:
                        button3.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
                        break;
                    case 3:
                        button4.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
                        break;
                    case 4:
                        button5.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
                        break;
                    case 5:
                        button6.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
                        break;
                    case 6:
                        button7.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
                        break;
                    case 7:
                        button8.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
                        break;
                    case 8:
                        button9.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
                        break;
                    default: MessageBox.Show("ERRO AO ATUALIZAR JOGADA"); novoJogo(); break;
                }
            }
        }
    }
}
