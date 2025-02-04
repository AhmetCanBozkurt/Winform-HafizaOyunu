using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Görsel3RastgeleButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void doldur(int[] dizi,int boyut)
        {

            int sayac = 1;
            for (int i = 0; i < boyut; i++)
            {
                dizi[i] = sayac;

                if (sayac == boyut/2)
                {
                    sayac = 0;

                }
                sayac++;
            }

        }
        Panel pnl = new Panel();
        private void button1_Click(object sender, EventArgs e)
        {
            pnl.Controls.Clear();
            int boyutX, boyutY, sayac = 0;
            boyutX = Convert.ToInt32(comboBox1.SelectedItem); //satır
            boyutY = Convert.ToInt32(comboBox2.SelectedItem);//sütün

            Random rnd = new Random();

            int[] dizi = new int[boyutX* boyutY];
            doldur(dizi, boyutX * boyutY);

            int[,] matris = new int[boyutX, boyutY];

            int maxDizi = boyutX * boyutY ;

            for (int i = 0; i < boyutX; i++)
            {
                for (int j = 0; j < boyutY; j++)
                {
                    matris[i, j] = rnd.Next(0, maxDizi);

                    for (int a = 0; a < boyutX; a++)
                    {
                        for (int c = 0; c < boyutY; c++)
                        {
                            if (matris[i,j] == matris[a,c])
                            {
                                sayac++;
                            }

                          
                        }
                    }

                    if (sayac > 1)
                    {
                        sayac = 0;
                        j--;
                    }
                }
            }
            if (this.Controls.Count == 4)
            {
                this.Controls.RemoveAt(3);
            }
           
            pnl.Width = 90 * boyutX;
            pnl.Height = 70 * boyutY;
            pnl.BackColor = Color.Red;
            pnl.Top = 70;
            pnl.Left = 3;
            this.Controls.Add(pnl);

            for (int i = 1; i <= boyutX; i++)
            {
                for (int t = 1; t <= boyutY; t++)
                {
                    Button btn = new Button();
                    btn.Click += new EventHandler(btn_Click);
                    btn.BackColor = Color.Blue;
                    btn.ForeColor = Color.White;
                    btn.Top = 50 * i;
                    btn.Left = 50 + t * 60;
                    btn.Width = 50;
                    
                    btn.Text = dizi[matris[i - 1, t - 1]].ToString();
                    pnl.Controls.Add(btn);

                }
            }
        }
        int sayac = 0;
        int ilkdeger = 0;
        int ikincideger = 0;
        int skor = 0;
        private Button ilkbuttun;

        private void btn_Click(object sender,EventArgs e)
        {
            Button yeni = (sender as Button);
            //yeni.BackColor = Color.Black;

          
           
            if (sayac ==0)
            {
                ilkdeger = Convert.ToInt32(yeni.Text);
                ilkbuttun = yeni;
                sayac++;
            }
            else
            {
                 ikincideger = Convert.ToInt32(yeni.Text);

            }

            yeni.Enabled = false;


            if (ilkdeger == ikincideger)
            {
                yeni.BackColor = Color.Black;

                ilkbuttun.BackColor = Color.Black;
                sayac = 0;
                skor++;
               
                label4.Text = skor.ToString();

                int alan = Convert.ToInt32(comboBox1.SelectedItem) * Convert.ToInt32(comboBox2.SelectedItem);
                if (skor==(alan/2))
                {
                    MessageBox.Show("Oyunu Kazandınız");
                    pnl.Controls.Clear();
                    skor = 0;
                    
                }

               
            }
           
        }
    }
}
