using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorFiguras1
{
    public partial class kuraElec : Form
    {
        public int tipo;
        Form1 manda;

        public kuraElec()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile("K5.png");
            pictureBox2.Image = Image.FromFile("K33.png");
            manda = new Form1();
        }

        //Boton para seleccionar k5
        private void button1_Click(object sender, EventArgs e)
        {
            tipo = 1;
            this.Close();
        }

        //Boton para seleccionar k33
        private void button2_Click(object sender, EventArgs e)
        {
            tipo = 2;
            this.Close();
        }
    }
}
