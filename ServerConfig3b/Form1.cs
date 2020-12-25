using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceRest3b;
using System.ServiceModel;

namespace ServerConfig3b
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceHost hostObjek = null;

            try
            {
                hostObjek = new ServiceHost(typeof(TI_UMY));
                hostObjek.Open();
                label3.Text = "ON";
                label4.Text = "Klik OFF Untuk Mematikan";
                button1.Enabled = false;
                button2.Enabled = true;
            }
            catch (Exception ex)
            {
                hostObjek = null;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceHost hostObjek;

            try
            {
                hostObjek = new ServiceHost(typeof(TI_UMY));
                hostObjek.Close();
                label3.Text = "OFF";
                label4.Text = "Klik ON Untuk Menghidupkan";
                button1.Enabled = true;
                button2.Enabled = false;
            }
            catch (Exception ex)
            {
                hostObjek = null;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
