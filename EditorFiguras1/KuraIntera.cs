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
    public partial class KuraIntera : Form
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
        CGrafo grafo2, grafo1, grafoK5, grafoK33;
        List<int> B1;
        List<int> B2;
        bool eliNodo = false;
        CNodo ori;
        CNodo des;
        CArista aris;
        IsoGrados comIso;
        Form2 meIso;
        bool esIso = false;
        bool bandG = false;
        public int tipoG;


        //Inicializa variables de kuratoski
        private void KuraIntera_Load(object sender, EventArgs e)
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

            g = CreateGraphics();
            B1 = new List<int>();
            B2 = new List<int>();
            comIso = new IsoGrados();
            meIso = new Form2();
            grafoK5 = new CGrafo();
            grafoK33 = new CGrafo();


            //tipoG = new kuraElec();

            creaK5();
            creaK33();
            int r = 0;
            comIso.hacerInsi = false;
        }

       
        //Buton para eliminar nodo
        private void button1_Click(object sender, EventArgs e)
        {
            String s = textBox1.Text;
            MessageBox.Show("voy a eliminar el nodo " + s);
            eliminaNodo(s, grafo2);
            comIso.numNEli++;
            KuraIntera_Paint(this, null);
        }

        //Elimina nodo
        public void eliminaNodo(string ln, CGrafo gra)
        {
            int iN = 0, iA = 0, cAe = 0, iEa = 0;
            int z = 0;

            foreach (CNodo a in gra.listaNodos)
            {
                if (a.nombre == ln)
                {
                    gra.listaNodos.RemoveAt(iN);
                    break;
                }
                iN++;
            }



            foreach (CArista b in gra.listaArista)
            {
                if (ln == b.origen.nombre || ln == b.destino.nombre)
                {
                    cAe++;
                }

            }



            while (iEa < cAe)
            {
                foreach (CArista b in gra.listaArista)
                {
                    if (ln == b.origen.nombre || ln == b.destino.nombre)
                    {
                        gra.listaArista.RemoveAt(iA);
                        break;
                    }
                    iA++;
                }
                iA = 0;
                iEa++;
            }
        }

        //Agrega vertice de corte
        public void verticeCorte(string s)
        {
            CArista a1, a2;
            int iNo = 0, iNd = 0, iAe = 0 ;
            CNodo nu, nodo2;
            bool bandAdd = false;

            string nodo;

            foreach(CArista b in grafo2.listaArista)
            {
                if(b.nombre == s)
                {
                    foreach(CNodo a in grafo2.listaNodos)
                    {
                        

                        if (b.destino.nombre == a.nombre)
                        {
                            int z = 0;
                            //b.dismedx - 25, b.dismedy - 25, 50
                            nu = new CNodo(b.dismedx - 25, b.dismedy - 25, 50);
                            nodo = nu.nombre;
                            a1 = new CArista(b.destino, nu);
                            grafo2.listaNodos.Add(nu);
                            grafo2.listaArista.Add(a1);
                            z = 0;
                            bandAdd = true;
                            break;
                        }

                    }                    
                }
                if (bandAdd == true)
                {
                    break;
                }
                iAe++;     
            }

            
            int inAgre = iAe;

            iAe = 0;
            bandAdd = false;


            foreach (CArista b in grafo2.listaArista)
            {
                if (b.nombre == s)
                {
                    foreach (CNodo a in grafo2.listaNodos)
                    {
                        if (b.origen.nombre == a.nombre)
                        {
                            int z = 0;
                            a2 = new CArista(b.origen, grafo2.listaNodos.ElementAt(grafo2.listaNodos.Count-1));
                            
                            grafo2.listaArista.Add(a2);
                            z = 0;
                            bandAdd = true;
                            break;
                        }

                    }
                }
                if (bandAdd == true)
                {
                    break;
                }
                iAe++;
            }

           
            int conAri = 0;
            foreach(CArista d in grafo2.listaArista)
            {
                if(iAe == conAri)
                {
                    grafo2.listaArista.RemoveAt(iAe);
                    break;
                }
                conAri++;
            }

        }


        //Boton de eliminar arista
        private void button2_Click(object sender, EventArgs e)
        {
            String s = textBox2.Text;
            MessageBox.Show("voy a eliminar el arista " + s);
            eliminaArista(s);

            KuraIntera_Paint(this, null);
        }

        //Metodo elimina arista
        public void eliminaArista(string la)
        {
            int iA = 0;

            int z = 0;
            foreach (CArista a in grafo2.listaArista)
            {
                if (la == a.nombre)
                {
                    grafo2.listaArista.RemoveAt(iA);
                    break;
                    z = 0;
                }

                iA++;
            }

            z = 0;

        }

        //boton de elimnar nodo puente
        private void button3_Click(object sender, EventArgs e)
        {
            string s = textBox3.Text;
            MessageBox.Show("voy a eliminar el nodo " + s);
            eliminaNodoPuente(s);
            KuraIntera_Paint(this, null);

        }

        //Metodo eliminar nodo puente
        public void eliminaNodoPuente(string s)
        {
            int iN = 0, grEl = 0;

            foreach (CNodo a in grafo2.listaNodos)
            {
                if (s == a.nombre)
                {
                    foreach (CArista b in grafo2.listaArista)
                    {
                        if (a.nombre == b.origen.nombre || a.nombre == b.destino.nombre)
                        {
                            grEl++;
                        }
                    }
                }
            }

            string d = "", o = "";
            if (grEl == 2)
            {
                foreach (CNodo a in grafo2.listaNodos)
                {
                    if (s == a.nombre)
                    {

                        foreach (CArista b in grafo2.listaArista)
                        {
                            if (s == b.origen.nombre)
                            {
                                o = b.destino.nombre;
                                break;
                            }

                        }

                        foreach (CArista c in grafo2.listaArista)
                        {
                            if (s == c.destino.nombre)
                            {
                                d = c.origen.nombre;
                                break;
                            }

                        }
                    }
                }

                foreach (CNodo f in grafo2.listaNodos)
                {
                    if (d == f.nombre)
                    {
                        des = f;
                    }

                    if (o == f.nombre)
                    {
                        ori = f;
                    }
                }


                aris = new CArista(ori, des);
                grafo2.listaArista.Add(aris);
                eliminaNodo(s, grafo2);

                MessageBox.Show("Añadi una arista de" + d + " a " + o);


            }
            else
            {
                MessageBox.Show("No podemos eliminar tu nodo ya que no es puente");
            }
        }


        //Boton para abrir la ventana  de datos de comparacion
        private void comprobarKuratoskiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int contNodoP = 0, contNodo2 = 0;
            int contArisP = 0, contAris2 = 0;


            if (tipoG == 1)
            {
                
                foreach (CNodo n in grafoK5.listaNodos)
                {
                    contNodoP++;
                }

                foreach (CNodo n in grafo2.listaNodos)
                {
                    contNodo2++;
                }


                foreach (CArista n in grafoK5.listaArista)
                {
                    contArisP++;
                }

                foreach (CArista n in grafo2.listaArista)
                {
                    contAris2++;
                }

                if (contNodoP == contNodo2)
                {
                    MessageBox.Show("La cantidad de nodos en grafo que elegiste y grafo secundario son iguales a " + contNodoP);
                    if (contArisP == contAris2)
                    {
                        MessageBox.Show("La cantidad de aristas en grafo que elegiste y grafo secundario son iguales a " + contArisP);
                        comIso.asignaValorGraIso(grafoK5, grafo2);
                        bandG = meIso.compGrados(comIso.gradosG1, comIso.gradosG2);

                        if (bandG == false)
                            MessageBox.Show("Sus grafos contienen nodos que no coinciden en sus grados, por lo tanto no es isomorfico");

                        else
                        {

                            comIso.ShowDialog();
                        }


                    }
                    else
                        MessageBox.Show("La cantidad de aristas en grafo principla y grafo secundario son diferentes");
                }
                else
                    MessageBox.Show("La cantidad de nodo en grafo principla y grafo secundario son diferentes");
            }
            else
            {
                foreach (CNodo n in grafoK33.listaNodos)
                {
                    contNodoP++;
                }

                foreach (CNodo n in grafo2.listaNodos)
                {
                    contNodo2++;
                }


                foreach (CArista n in grafoK33.listaArista)
                {
                    contArisP++;
                }

                foreach (CArista n in grafo2.listaArista)
                {
                    contAris2++;
                }



                if (contNodoP == contNodo2)
                {
                    MessageBox.Show("La cantidad de nodos en grafo que elegiste y grafo secundario son iguales a " + contNodoP);
                    if (contArisP == contAris2)
                    {
                        MessageBox.Show("La cantidad de aristas en grafo que elegiste y grafo secundario son iguales a " + contArisP);
                        comIso.asignaValorGraIso(grafoK33, grafo2);
                        bandG = meIso.compGrados(comIso.gradosG1, comIso.gradosG2);

                        if (bandG == false)
                            MessageBox.Show("Sus grafos contienen nodos que no coinciden en sus grados, por lo tanto no es isomorfico");

                        else
                        {

                            comIso.ShowDialog();
                        }


                    }
                    else
                        MessageBox.Show("La cantidad de aristas en grafo principla y grafo secundario son diferentes");
                }
                else
                    MessageBox.Show("La cantidad de nodo en grafo principla y grafo secundario son diferentes");
            }
        }


        //Boton para agregar vertice corte
        private void button4_Click(object sender, EventArgs e)
        {
            string s = textBox4.Text;
            MessageBox.Show("voy a agregar un vertice en la arista" + s);
            verticeCorte(s);
            KuraIntera_Paint(this, null);
        }

        //Inicializador
        public KuraIntera()
        {
            InitializeComponent();

        }


        //Da el valor a mi grafo actual del anterior
        public void asignaValor(CGrafo gr)
        {
            grafo2 = gr;
            CNodo.c3 = Convert.ToChar(gr.listaNodos.Last().nombre);
            CNodo.c3++;
            CArista.c3 = Convert.ToChar(gr.listaArista.Last().nombre);
            CArista.c3++;

        }

        //Almacena el grafo
        public void guardaGrafo1(CGrafo gr)
        {
            grafo1 = gr;
        }

        //ventana de botones de figuras
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


        //ventana de pintado
        private void KuraIntera_Paint(object sender, PaintEventArgs e)
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
                        nodo = new CNodo(pt1, tamNodo, 2);
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

        //Evento mause
        private void KuraIntera_MouseDown(object sender, MouseEventArgs e)
        {
            brocha.Color = color;
            pen.Brush = brocha;
            pen.Width = aLinea;
            pt1 = e.Location;

            switch (fig)
            {
                case 1:
                    band = true;
                    KuraIntera_Paint(this, null);
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


        //evento de rezize
        private void KuraIntera_Resize(object sender, EventArgs e)
        {
            bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
        }

        //evento de mouse up
        private void KuraIntera_MouseUp(object sender, MouseEventArgs e)
        {
            pt2 = e.Location;
            if (fig == 2 && (nDestino = grafo2.BuscaNodo(pt2)) != null && nOrigen != null)
            {
                pt2 = nDestino.pc;
                arista = new CArista(nOrigen, nDestino, 2);
                arista.CalInterseccion(nOrigen, nDestino);
                arista.compMultiAri(grafo2, nOrigen, nDestino);
                grafo2.listaArista.Add(arista);
                KuraIntera_Paint(this, null);
            }

            if (fig == 3)
            {
                nOrigen = null;
            }
        }


        //evento de mover raton
        private void KuraIntera_MouseMove(object sender, MouseEventArgs e)
        {
            switch (fig)
            {
                case 2:
                    if (MouseButtons.Left.Equals(e.Button) && bandArista == true)
                    {
                        pt2 = e.Location;
                        KuraIntera_Paint(this, null);
                    }
                    break;
                case 3:
                    if (MouseButtons.Left.Equals(e.Button))// && grafo.BuscaNodo(e.Location) != null)
                    {
                        if (nOrigen != null)
                        {
                            pt1 = e.Location;
                            nOrigen.MoverNodo(pt1);
                            KuraIntera_Paint(this, null);
                        }
                    }
                    break;
            }
        }

        //crea k5
        public void creaK5()
        {
            CNodo nodo2, nodo3, nodo4, nodo5, nodoIni;
            CArista arista2;
            CNodo.c2 = 'A';
            CArista.c2 = '1';

            nodoIni = new CNodo(850, 150, 50, 1);
            grafoK5.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(1000, 150, 50, 1);
            grafoK5.listaNodos.Add(nodo2);
            arista2 = new CArista(nodoIni, nodo2, 1);
            grafoK5.listaArista.Add(arista2);
            nodo3 = new CNodo(850, 250, 50, 1);
            grafoK5.listaNodos.Add(nodo3);
            nodo4 = new CNodo(1000, 250, 50, 1);
            grafoK5.listaNodos.Add(nodo4);
            arista2 = new CArista(nodo3, nodo4, 1);
            grafoK5.listaArista.Add(arista2);
            nodo5 = new CNodo(925, 75, 50, 1);
            grafoK5.listaNodos.Add(nodo5);
            arista2 = new CArista(nodoIni, nodo3, 1);
            grafoK5.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo4, 1);
            grafoK5.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo5, 1);
            grafoK5.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo5, 1);
            grafoK5.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodo5, 1);
            grafoK5.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo5, 1);
            grafoK5.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo4, 1);
            grafoK5.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo3, 1);
            grafoK5.listaArista.Add(arista2);
        }

        //creak33
        public void creaK33()
        {
            CNodo nodo2, nodo3, nodo4, nodo5, nodo6 , nodoIni;
            CArista arista2;
            CNodo.c2 = 'A';
            CArista.c2 = '1';

            nodoIni = new CNodo(850, 150, 50, 1);//
            grafoK33.listaNodos.Add(nodoIni);//
            nodo2 = new CNodo(1000, 150, 50, 1);//
            grafoK33.listaNodos.Add(nodo2);//
            arista2 = new CArista(nodoIni, nodo2, 1);//
            grafoK33.listaArista.Add(arista2);//
            nodo3 = new CNodo(850, 250, 50, 1);//
            grafoK33.listaNodos.Add(nodo3);//
            nodo4 = new CNodo(1000, 250, 50, 1);//
            grafoK33.listaNodos.Add(nodo4);//
            arista2 = new CArista(nodo3, nodo4, 1);//
            grafoK33.listaArista.Add(arista2);//
            nodo5 = new CNodo(925, 75, 50, 1);//
            grafoK33.listaNodos.Add(nodo5);//
            nodo6 = new CNodo(950, 75, 50, 1);//
            grafoK33.listaNodos.Add(nodo6);//
            arista2 = new CArista(nodoIni, nodo4, 1);//
            grafoK33.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo6, 1);//
            grafoK33.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodo2, 1);
            grafoK33.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodo6, 1);
            grafoK33.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo2, 1);
            grafoK33.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo4, 1);
            grafoK33.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo6, 1);
            grafoK33.listaArista.Add(arista2);
        }
    }
}
