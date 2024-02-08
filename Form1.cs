using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F1_sexo_perez_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        Graphics redbullRuedas, ferrariRuedas, mercedesRuedas, ferrariCarroseria, redbullCarroseria, mercedesCarroseria;
        Pen plumaBlue = new Pen(Color.Blue, 2);
        Pen plumaRed = new Pen(Color.Red, 2);
        Pen plumaGreen = new Pen(Color.Green, 2);
        Random random = new Random();

        Thread HiloBlue;
        Thread HiloRed;
        Thread HiloGreen;

        private void button1_Click(object sender, EventArgs e)
        {
            
                if (lblganando.Text != "")
                {

                    lblPrimer_Puesto.Text = "";
                    lblSegundo_Puesto.Text = "";
                    lblTercer_Puesto.Text = "";
                    VelBull = 0;
                    VelFerrari = 0;
                    VelMercedes = 0;
                    lblganando.Text = "";
                    HiloRed.Abort();
                    HiloBlue.Abort();
                    HiloGreen.Abort();
                  


                }
                else
                {

                    HiloRed = new Thread(Ferrari);
                    HiloBlue = new Thread(Redbull);
                    HiloGreen = new Thread(Aston_martin);
                    HiloRed.Start();
                    HiloBlue.Start();
                    HiloGreen.Start();
                button1.Enabled = false;    
                }
            

        }

        int VelBull;
        int VelFerrari;
        int VelMercedes;


        private void Form1_Load(object sender, EventArgs e)
        {
            redbullCarroseria=this.CreateGraphics();
            ferrariCarroseria = this.CreateGraphics();
            mercedesCarroseria = this.CreateGraphics(); 
            redbullRuedas=this.CreateGraphics();    
            ferrariRuedas = this.CreateGraphics();
            mercedesRuedas = this.CreateGraphics();
        }

        void Redbull()
        {               
            for (int i = 0;i<600;i++) 
            {
               
                redbullCarroseria.DrawRectangle(plumaBlue, VelBull, 90, 50,25);
                redbullRuedas.DrawEllipse(plumaBlue, VelBull-10, 110,20,20);
                redbullRuedas.DrawEllipse(plumaBlue, VelBull +40, 110,20,20);

                VelBull += Convert.ToInt32(random.Next(7));

                if(VelBull>600)
                {
                    break;
                }

                Thread.Sleep(3);
                redbullCarroseria.Clear(Color.White);
                if (VelBull > VelFerrari && VelBull > VelMercedes)
                {
                    lblganando.Text = "Redbull";    
                    lblganando.ForeColor = Color.Blue;
                }
                else if (VelFerrari > VelBull && VelFerrari > VelMercedes)
                {
                    lblganando.Text = "Ferrari";
                    lblganando.ForeColor = Color.Red;
                }
                else if (VelMercedes > VelBull && VelMercedes > VelFerrari)
                {
                    lblganando.Text = "Aston martin";
                    lblganando.ForeColor = Color.Green;
                }
            }
            podio("Redbull");
        }

        void Ferrari()
        {
            for (int i = 0; i < 600; i++)
            {
                ferrariCarroseria.DrawRectangle(plumaRed, VelFerrari, 190, 50, 25);
                ferrariRuedas.DrawEllipse(plumaRed, VelFerrari - 10, 210, 20, 20);
                ferrariRuedas.DrawEllipse(plumaRed, VelFerrari + 40, 210, 20, 20);

                VelFerrari += Convert.ToInt32(random.Next(7));
                if (VelFerrari > 600)
                {
                    break;
                }

                Thread.Sleep(3);
                ferrariCarroseria.Clear(Color.White);
                if (VelBull > VelFerrari && VelBull > VelMercedes)
                {
                    lblganando.Text = "Redbull";
                    lblganando.ForeColor = Color.Blue;
                }
                else if (VelFerrari > VelBull && VelFerrari > VelMercedes)
                {
                    lblganando.Text = "Ferrari";
                    lblganando.ForeColor = Color.Red;
                }
                else if (VelMercedes > VelBull && VelMercedes > VelFerrari)
                {
                    lblganando.Text = "Aston martin";
                    lblganando.ForeColor = Color.Green;
                }
            }
            podio("Ferrari");
        }


        void Aston_martin()
        {
            for (int i = 0; i < 600; i++)
            {
                mercedesCarroseria.DrawRectangle(plumaGreen, VelMercedes, 290, 50, 25);
            mercedesRuedas.DrawEllipse(plumaGreen, VelMercedes - 10, 310, 20, 20);
               mercedesRuedas.DrawEllipse(plumaGreen, VelMercedes + 40, 310, 20, 20);

                VelMercedes += Convert.ToInt32(random.Next(7));
                if (VelMercedes > 600)
                {
                    break;
                }

                Thread.Sleep(3);
                mercedesCarroseria.Clear(Color.White);

                if (VelBull > VelFerrari && VelBull > VelMercedes)
                {
                    lblganando.Text = "Redbull";
                    lblganando.ForeColor = Color.Blue;
                }
                else if (VelFerrari > VelBull && VelFerrari > VelMercedes)
                {
                    lblganando.Text = "Ferrari";
                    lblganando.ForeColor = Color.Red;
                }
                else if (VelMercedes > VelBull && VelMercedes > VelFerrari)
                {
                    lblganando.Text = "Aston martin";
                    lblganando.ForeColor = Color.Green;
                }

            }
            podio("Aston Martin");
        }


        void podio(string lugar)
        {
            if (lblPrimer_Puesto.Text == "")
            {
                lblPrimer_Puesto.Text = lugar;
                if (lugar == "Redbull")
                {
                    lblPrimer_Puesto.ForeColor = Color.Blue;
                }
                else if (lugar == "Ferrari")
                { 
                    lblPrimer_Puesto.ForeColor= Color.Red;
                }
                else
                {
                    lblPrimer_Puesto.ForeColor=Color.Green; 
                }
                button1.Enabled = true;
            }

           else if (lblSegundo_Puesto.Text == "")
            {
                lblSegundo_Puesto.Text = lugar;
                if (lugar == "Redbull")
                {
                    lblSegundo_Puesto.ForeColor = Color.Blue;
                }
                else if (lugar == "Ferrari")
                {
                    lblSegundo_Puesto.ForeColor = Color.Red;
                }
                else
                {
                    lblSegundo_Puesto.ForeColor = Color.Green;
                }
            }

            else
            {
                lblTercer_Puesto.Text = lugar;
                if (lugar == "Redbull")
                {
                    lblTercer_Puesto.ForeColor = Color.Blue;
                }
                else if (lugar == "Ferrari")
                {
                    lblTercer_Puesto.ForeColor = Color.Red;
                }
                else
                {
                    lblTercer_Puesto.ForeColor = Color.Green;
                }
            }
        }


        
    }
}
