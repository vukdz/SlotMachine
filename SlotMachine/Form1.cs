using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SlotMachine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int score = 1000;
        int defScore = 100;         
       
        static string wDir = Directory.GetCurrentDirectory();
        static string pDir = Directory.GetParent(wDir).Parent.FullName;
        string[] fields = Directory.GetFiles(pDir + @"\Resources", "*.png");                  

        private void button1_Click(object sender, EventArgs e)
        {            
            Random random = new Random();

            int n = random.Next(0, 9);
            int n1 = random.Next(0, 9);
            int n2 = random.Next(0, 9);
            
            Image im = Image.FromFile(fields[n]);
            Image im1 = Image.FromFile(fields[n1]);
            Image im2 = Image.FromFile(fields[n2]);

            pictureBox1.Image = im;
            pictureBox2.Image = im1;
            pictureBox3.Image = im2;

            if (n == n1 && n == n2)
            {
                switch(n)
                {
                    case 0:
                        score += (defScore / 100) * 200;
                        scoreTB.Text = "$" + score.ToString();
                        break;
                    case 1:
                        score += (defScore / 100) * 300;
                        scoreTB.Text = "$" + score.ToString();
                        break;
                    case 2:
                        score += (defScore / 100) * 400;
                        scoreTB.Text = "$" + score.ToString();
                        break;
                    case 3:
                        score += (defScore / 100) * 500;
                        scoreTB.Text = "$" + score.ToString();
                        break;
                    case 4:
                        score += (defScore / 100) * 1000;
                        scoreTB.Text = "$" + score.ToString();
                        break;
                    case 5:
                        score += (defScore / 100) * 2000;
                        scoreTB.Text = "$" + score.ToString();
                        break;
                    case 6:
                        score += (defScore / 100) * 3000;
                        scoreTB.Text = "$" + score.ToString();
                        break;
                    case 7:
                        score += (defScore / 100) * 5000;
                        scoreTB.Text = "$" + score.ToString();
                        break;
                    case 8:                        
                        score += (defScore / 100) * 10000;                        
                        scoreTB.Text = "$" + score.ToString();
                        break;
                }
            }
            else
            {
                score -= defScore;
                scoreTB.Text = "$" + score.ToString();
            }

            if (score <= 0)
            {
                MessageBox.Show("No more credit", "Game Over");
                newGame();
            }

            if (score < defScore)
            {
                defScore = score;               
                defScoreTB.Text = "$" + defScore.ToString();
            }            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Color hexColor = Color.FromArgb(0xf8c08f);
            Color rbgColor = Color.FromArgb(hexColor.R, hexColor.G, hexColor.B);
            panel1.BackColor = rbgColor;
            Image bImage = new Bitmap(pDir + @"\background.jpg");
            this.BackgroundImage = bImage;
            newGame();
        }

        private void newGame()
        {
            score = 1000;
            defScore = 100;
            label1.Text = "Credit";
            label1.BackColor = System.Drawing.Color.Transparent;
            scoreTB.Text = "$" + score.ToString();
            defScoreTB.Text = "$" + defScore.ToString();
            
            pictureBox1.Image = Image.FromFile(pDir + @"\dollar.png");
            pictureBox1.BackColor = System.Drawing.Color.Transparent; 
            
            pictureBox2.Image = Image.FromFile(pDir + @"\dollar.png");
            pictureBox2.BackColor = System.Drawing.Color.Transparent;

            pictureBox3.Image = Image.FromFile(pDir + @"\dollar.png");
            pictureBox3.BackColor = System.Drawing.Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)
        {                       
            if (defScore < score)
            {
                defScore += 10;
                defScoreTB.Text = "$" + defScore.ToString();
            }
            else
            {
                MessageBox.Show("Not enough credit");
                defScore = score;
                defScoreTB.Text = "$" + defScore.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (defScore > 10)
            {
                defScore -= 10;
                defScoreTB.Text = "$" + defScore.ToString();
            }
            else
            {
                MessageBox.Show("Minimum bet is $10");
                defScore = 10;
                defScoreTB.Text = "$" + defScore.ToString();
            }         
        }                                  
    }
}
