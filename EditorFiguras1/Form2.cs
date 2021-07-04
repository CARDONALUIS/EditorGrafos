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
    public partial class Form2 : Form
    {
        int fig, tipo;
        Graphics g;
        SolidBrush brocha;
        Font fuente;
        Point pt1, pt2;
        bool band, bandArista;
        Pen pen, pen2, pen3;
        int tamNodo;
        Bitmap bmp;
        int aLinea;
        Bitmap bmp1;
        Color color, colorRelleno;
        CNodo nodo, nOrigen, nDestino;
        CArista arista;
        CGrafo grafo2;
        CGrafo grafoP;
        IsoGrados graIso;
        List<int> B1;
        List<int> B2;
        bool bandG = false;



        public Form2()
        {
            InitializeComponent();
            
        }

        //Constructor para incializar variables
        private void Form2_Load(object sender, EventArgs e)
        {
            band = false;
            bandArista = false;
            tamNodo = 50;
            fig = 0;
            tipo = 0;
            fuente = new Font("Times New Roman", 15);
            aLinea = 1;
            bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
            color = Color.Black;
            colorRelleno = BackColor;
            bmp1 = new Bitmap(ClientSize.Width, ClientSize.Height);
            brocha = new SolidBrush(color);
            pen = new Pen(brocha, aLinea);
            pen2 = new Pen(Color.White, 1);
            pen3 = new Pen(Color.Black, 5);
            pen3.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            pt1 = new Point();
            pt2 = new Point();
            grafo2 = new CGrafo();
            g = CreateGraphics();
            graIso = new IsoGrados();
            B1 = new List<int>();
            B2 = new List<int>();
        }


        //Este meotodo compara los grados de cada uno de los nodos y 
        public void comprobarIsomorfismoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerificaIso(grafoP);
            int contNodoP = 0, contNodo2 = 0;
            int contArisP = 0, contAris2 = 0;
            

            foreach (CNodo n in grafoP.listaNodos)
            {
                contNodoP++;
            }

            foreach (CNodo n in grafo2.listaNodos)
            {
                contNodo2++;
            }


            foreach (CArista n in grafoP.listaArista)
            {
                contArisP++;
            }

            foreach (CArista n in grafo2.listaArista)
            {
                contAris2++;
            }


            if (contNodoP == contNodo2)
            {
                MessageBox.Show("La cantidad de nodos en grafo principal y grafo secundario son iguales a " + contNodoP);
                if(contArisP == contAris2)
                {
                    MessageBox.Show("La cantidad de aristas en grafo principla y grafo secundario son iguales a " + contArisP);
                    graIso.asignaValorGraIso(grafoP, grafo2);
                    bandG = compGrados(graIso.gradosG1, graIso.gradosG2);

                    if (bandG == false)
                        MessageBox.Show("Sus grafos contienen nodos que no coinciden en sus grados, por lo tanto no es isomorfico");
                        
                    else
                    {
                        graIso.ShowDialog();
                        
                    }
                    
                    
                }
                else
                    MessageBox.Show("La cantidad de aristas en grafo principla y grafo secundario son diferentes");
            }
            else
                MessageBox.Show("La cantidad de nodo en grafo principla y grafo secundario son diferentes");
        }

        //Compara los grados de los grafos
        public bool compGrados(List<int> gra1, List<int> gra2)
        {
            int i = 0, j = 0, cont = 0;
            bool isoGrados1 = true, isoGrados2 = true, confGrados = true ;

            foreach(int a in gra1)
            {
                foreach(int b in gra2)
                {
                    if (a == b)
                    {
                        cont++;     
                    }
                    j++;
                }
                if (cont == 0)
                    isoGrados1 = false;

                cont = 0;
                j = 0;
                i++;
            }

            foreach (int a in gra2)
            {
                foreach (int b in gra1)
                {
                    if (a == b)
                    {
                        cont++;
                    }
                }
                if (cont == 0)
                    isoGrados2 = false;

                cont = 0;
            }

            if (isoGrados1 == false || isoGrados2 == false)
                confGrados = false;

            return confGrados;
        }

        //regresa un documento de tipo grafo el cual sigue contenido todos sus cambios
        public void VerificaIso(CGrafo grafo1)
        {
            grafoP = grafo1;
        }

        //Este metodo eliminar el grafo actual
        private void borrarGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafo2.listaNodos.Clear();
            grafo2.listaArista.Clear();
            CNodo.c2 = 'A';
            CArista.c2 = '1';
            Form2_Paint(this, null);
        }

        //diferentes formas de dibujar
        private void Shapes_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            band = false;
            switch (e.ClickedItem.AccessibleName)
            {
                case "Nodo":
                    fig = 1;
                    break;
                case "Arista":
                    fig = 2;
                    bandArista = true;
                    break;
                default:
                    band = true;
                    break;
            }
        }
        //Comprueba de que tipo de grafofo se va a utilizar
        private void Tipo_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.AccessibleName)//ON_COMMAND_RANGE
            {
                case "NoDirigido":
                    tipo = 0;
                    break;
                case "Dirigido":
                    tipo = 1;
                    break;
            }
        }

        //Sirve como la area de pintado
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics pagina = CreateGraphics();
            g = Graphics.FromImage(bmp);
            g.Clear(BackColor);

            if (band)
            {
                switch (fig)
                {
                    case 1://Dibuja Nodo
                        g.DrawEllipse(pen, pt1.X - (tamNodo / 2), pt1.Y - (tamNodo / 2), tamNodo, tamNodo);
                        band = false;
                        nodo = new CNodo(pt1, tamNodo, 1);
                        g.DrawString(nodo.nombre, fuente, brocha, nodo.pc.X - 15 / 2, nodo.pc.Y - 15 / 2);
                        grafo2.listaNodos.Add(nodo);
                        break;
                    case 2://Dibuja Arista
                        g.DrawLine(pen, pt1.X, pt1.Y, pt2.X, pt2.Y);
                        break;
                }
            }
            foreach (CArista a in grafo2.listaArista)
            {
                if (a.origen != null)
                {
                    if (a.origen.nombre != a.destino.nombre)//Si no es oreja
                    {
                        g.DrawLine(pen, a.origen.pc.X, a.origen.pc.Y, a.destino.pc.X, a.destino.pc.Y);
                        g.DrawString(a.nombre, fuente, brocha, a.dismedx, a.dismedy);
                    }
                    else //si es oreja
                    {
                        g.DrawString(a.nombre, fuente, brocha, a.origen.pc.X - tamNodo, a.destino.pc.Y);
                        g.DrawArc(pen, a.origen.pc.X - (tamNodo), a.origen.pc.Y - tamNodo, 50, 50, 90, 270);
                        if (tipo == 1)
                        {
                            g.DrawEllipse(pen3, a.origen.pc.X, a.origen.pc.Y - (tamNodo / 2), 4, 4);
                        }
                    }
                    if (tipo == 1)
                    {
                        g.DrawLine(pen2, a.interx, a.intery, a.destino.pc.X, a.destino.pc.Y);
                        g.DrawEllipse(pen3, a.interx - 2, a.intery - 2, 4, 4);
                    }
                }

            }

            foreach (CNodo n in grafo2.listaNodos)
            {
                g.DrawEllipse(pen, n.pc.X - (tamNodo / 2), n.pc.Y - (tamNodo / 2), n.rt.Width, n.rt.Height);
                g.DrawString(n.nombre, fuente, brocha, n.pc.X - 15 / 2, n.pc.Y - 15 / 2);
            }

            pagina.DrawImage(bmp, 0, 0);
        }

        //Evento del mause para crear un nodo
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            brocha.Color = color;
            pen.Brush = brocha;
            pen.Width = aLinea;
            pt1 = e.Location;

            switch (fig)
            {
                case 1:
                    band = true;
                    Form2_Paint(this, null);
                    break;
                case 2:
                    if ((nOrigen = grafo2.BuscaNodo(pt1)) != null)
                    {
                        pt1 = nOrigen.pc;
                        band = true;
                        bandArista = true;
                    }
                    break;
            }
        }

        private void From2_Resize(object sender, EventArgs e)
        {
            bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
        }

        //Evento para saber si se dejo de prcionar el mouse y hacer el nodo destion
        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            pt2 = e.Location;
            if (fig == 2 && (nDestino = grafo2.BuscaNodo(pt2)) != null && nOrigen != null)
            {
                pt2 = nDestino.pc;
                arista = new CArista(nOrigen, nDestino,1);
                arista.CalInterseccion(nOrigen, nDestino);
                arista.compMultiAri(grafo2, nOrigen, nDestino);
                grafo2.listaArista.Add(arista);
                Form2_Paint(this, null);
            }

            if (fig == 3)
            {
                nOrigen = null;
            }
        }

        //Evento del mause para checar si se esta moviendo
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            switch (fig)
            {
                case 2:
                    if (MouseButtons.Left.Equals(e.Button) && bandArista == true)
                    {
                        pt2 = e.Location;
                        Form2_Paint(this, null);
                    }
                    break;
                case 3:
                    if (MouseButtons.Left.Equals(e.Button))// && grafo.BuscaNodo(e.Location) != null)
                    {
                        if (nOrigen != null)
                        {
                            pt1 = e.Location;
                            nOrigen.MoverNodo(pt1);
                            Form2_Paint(this, null);
                        }
                    }
                    break;
            }
        }
 
    }
}
