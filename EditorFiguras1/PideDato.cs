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
    public partial class PideDato : Form
    {
        public float peso;

        public PideDato()
        {
            InitializeComponent();
        }

        /*private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            String s = textBox1.Text;
            peso = (float)Convert.ToDouble(s);
            MessageBox.Show("Introduciste el dato " + peso);
            textBox1.Text = "";
            this.Close();
        }
    }
}
