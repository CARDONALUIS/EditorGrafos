using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace EditorFiguras1
{
    public partial class Form1 : Form
    {
        public int tipoKura;
        Euler eu;
        float exceFloyGra;
        int fig, tipo, contNodoEn = 0, contaAri = 0;
        Graphics g;
        Graphics g2;
        SolidBrush brocha, fondoCir, broProf;
        Font fuente,fuenteProf;
        Point pt1, pt2;
        bool band, bandArista, bandEtique, bandProfun, bandExcentri, bandEM;
        int bandEspe;
        Pen pen, pen2, pen3, penEul, penEulDi, penProRet, penProAva;
        int tamNodo;
        Bitmap bmp;
        bool bancolo;
        int aLinea;
        Bitmap bmp1;
        Color color, colorRelleno;
        CNodo nodo, nOrigen, nDestino, nodoRa;
        CArista arista;
        RepresentacionesLA rel;
        RepresentacionMA relMA;
        RepresentacionMI relMI;
        kuraElec elecKura;
        bool bandNodoRa;
        Grados grado;
        CGrafo grafo;
        Form2 Fo2;
        KuraIntera kI;
        PideDato peso;
        public List<int> camEuler;
        public List<string> Acicli;
        bool bandEuler = false, bandEulerDi = false;
        List<float> lisExntr;
       
        public Form1()
        {
            InitializeComponent();
            CNodo.c2 = 'A';
            CArista.c2 = '1';
            CNodo.posi = 1;
        }

        //Incializo alguna variables
        private void Form1_Load(object sender, EventArgs e)
        {
            bandEM = false;
            lisExntr = new List<float>();
            band = false;
            bandArista = false;
            bandEtique = false;
            bandExcentri = false;
            eu = new Euler();
            camEuler = new List<int>();
            Acicli = new List<string>();
            bandEspe = 0;
            tamNodo= 50;
            bancolo = false;
            bandNodoRa = false;
            bandProfun = false;
            fig = 0;
            tipo = 0;
            fuente = new Font("Times New Roman",15);
            fuenteProf = new Font("Times New Roman", 10);
            aLinea = 1;
            bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
            color = Color.Black;
            colorRelleno = BackColor;
            bmp1 = new Bitmap(ClientSize.Width,ClientSize.Height);
            brocha = new SolidBrush(color);
            fondoCir = new SolidBrush(Color.Red);
            pen = new Pen(brocha, aLinea);
            pen2 = new Pen(Color.White, 1);
            pen3 = new Pen(Color.Black, 5);
            penEul = new Pen(Color.Red, 5);
            penEulDi = new Pen(Color.Blue, 5);
            penProRet = new Pen(Color.Green, 5);
            penProAva = new Pen(Color.Yellow, 5);
            broProf = new SolidBrush(Color.Blue);
            pen3.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            pt1 = new Point();
            pt2 = new Point();
            g = CreateGraphics();
            g2 = CreateGraphics();
            grafo = new CGrafo();
            rel = new RepresentacionesLA();
            relMA = new RepresentacionMA();
            relMI = new RepresentacionMI();
            elecKura = new kuraElec();
            grado = new Grados();
            Fo2 = new Form2();
            kI = new KuraIntera();
            peso = new PideDato();
            exceFloyGra = 0;
            
        }


        //Muestro la ventana de lista de adyacencia
        private void ListaAdyacenciaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rel.asignaValorLA(grafo, tipo);
            rel.ShowDialog();

            rel.LisAdy.Rows.Clear();
            rel.LisAdy.Columns.Clear();
            rel.LisAdyDi.Rows.Clear();
            rel.LisAdyDi.Columns.Clear();
        }

        //Muestro la ventan de matriz de adyacencia
        private void matrizAdyacenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            relMA.asignaValoresMA(grafo, tipo);
            relMA.ShowDialog();         
            relMA.c = 'A';
            relMA.i = 1;
            relMA.contOri = 0;
            relMA.contDes = 1;
            relMA.contRen = 0;
            relMA.contCol = 1;
            relMA.conMulti = 1;

            relMA.MatAdya.Columns.Clear();
            relMA.MatAdyaND.Columns.Clear();
            relMA.MatAdyaND.Rows.Clear();
            relMA.MatAdya.Rows.Clear();
        }

        //Muestro la matriz de incidencia
        private void matrizIncidenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            relMI.asignaValoresMI(grafo, tipo);
            relMI.ShowDialog();
            relMI.MatInci.Rows.Clear();
            relMI.MatInci.Columns.Clear();
            relMI.MatInciD.Rows.Clear();
            relMI.MatInciD.Columns.Clear();

            relMI.i = 1;
            relMI.contOri1 = 0;
            relMI.contOri2 = 0;
            relMI.contDes = 1;
            relMI.contArista = 0;
            relMI.contRen = 0;
            relMI.contCol = 1;
            relMI.c1 = 'A';
            relMI.c2 = '1';
        }

        //Muestro un mensaje de ayuda
        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para crear aristas tienes que pulsar el boton izquierdo del raton" +
                "\ndentro del vertice origen y arrastrar hacia el vertice destino\ny soltar el raton\n");

            
        }

        //Desifro el orden y tamaño del nodo
        private void tamañoYOrdenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int conOrdNod = 0;
            int conTamAri = 0;

            foreach(CNodo a in grafo.listaNodos)
            {
                conOrdNod++;
            }
            foreach(CArista b in grafo.listaArista)
            {
                conTamAri++;
            }
            MessageBox.Show("Orden del grafo: " + conOrdNod+" Tamaño del grafo: "+conTamAri);
        }



        //Mando llamar la  ventana de isomorfismo
        private void isomorfismoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tipo == 0)
            {
                CNodo.c2 = 'A';
                CArista.c2 = '1';
                Fo2.VerificaIso(grafo);
                Fo2.ShowDialog();
            }
            else
                MessageBox.Show("Tu grafo es dirigido, Borralo y elige un no dirigido");

        }

        //Elimina el grafo actual
        private void borrarGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bandEspe = 0;
            grafo.listaNodos.Clear();
            grafo.listaArista.Clear();
            CNodo.c = 'A';
            CArista.c = '1';
            CNodo.posi = 1;
            bandProfun = false;
            Form1_Paint(this, null);
            
        }

        //Habro la ventana de grados
        private void gradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grado.asignaValorGRA(grafo, tipo);
            grado.ShowDialog();
        }

        //Este es un metodo que me analiza si los vertices son pendiente o aislados
        private void verticesEspecialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool bandPen = false;

            foreach (CNodo a in grafo.listaNodos)
            {
                foreach (CArista b in grafo.listaArista)
                {
                    contaAri++;
                    if (a.nombre == b.origen.nombre || a.nombre == b.destino.nombre)
                        contNodoEn++;
                }
                if(contNodoEn == 0)
                    MessageBox.Show(a.nombre + " Es aislado");
                if (contaAri == 1)
                {
                    bandPen = true;
                    MessageBox.Show("Es pendiente");
                }
                contNodoEn = 0;
            }
            if(bandPen == false)
                MessageBox.Show("No es pendiente");

            if (contaAri == 0)
            {
                MessageBox.Show("Es un grafo nulo");
            }
        }

        #region Manejador menu
        //Evento de clik del mause dentro del las figuras que podemos incluir
        private void shapes_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            band = false;
            switch (e.ClickedItem.AccessibleName)
            {
                case "Nodo":
                    fig = 1;
                break;
                case "Line":
                    fig = 2;
                    bandArista = true;
                break;
                default:
                    band = true;
                break;
            }
        }

        //Evento donde dando un clik le das el tipo de grafo
        private void Tipo_Cliked(object sender, ToolStripItemClickedEventArgs e)
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

        //Esta es la ventana de pintado
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //if (bandEM == true)
              //  Invalidate();

            Graphics pagina = CreateGraphics();
            g = Graphics.FromImage(bmp);
            g.Clear(BackColor);


            if (bandProfun == true)
            {
                muestraAristaBEP();
            }
            else
            if (band)
            {
                switch (fig)
                {
                    case 1://Dibuja Nodo
                        if (bandEspe == 0)
                        {
                           
                            g.DrawEllipse(pen, pt1.X - (tamNodo / 2), pt1.Y - (tamNodo / 2), tamNodo, tamNodo);
                            band = false;
                            nodo = new CNodo(pt1, tamNodo);
                            g.DrawString(nodo.nombre, fuente, brocha, nodo.pc.X - 15 / 2, nodo.pc.Y - 15 / 2);
                            grafo.listaNodos.Add(nodo);

                            
                        }
                    break;
                    case 2://Dibuja Arista                        
                        g.DrawLine(pen, pt1.X, pt1.Y ,  pt2.X, pt2.Y );
                        break;
                }
            }

            

            foreach (CArista a in grafo.listaArista)
            {

                if (a.origen != null)
                {                   
                    if(a.origen.nombre != a.destino.nombre)//Si no es oreja
                    {
                        
                        g.DrawLine(pen, a.origen.pc.X, a.origen.pc.Y, a.destino.pc.X, a.destino.pc.Y);
                        if(bandEspe == 0)
                        g.DrawString(a.nombre, fuente, brocha, a.dismedx, a.dismedy);
                    }
                    else //si es oreja
                    {
                        if (bandEspe == 0)
                            g.DrawString(a.nombre, fuente, brocha, a.origen.pc.X - tamNodo, a.destino.pc.Y);
                        g.DrawArc(pen, a.origen.pc.X - (tamNodo), a.origen.pc.Y - tamNodo, 50, 50, 90, 270);
                        if(tipo == 1)
                        {
                            g.DrawEllipse(pen3, a.origen.pc.X, a.origen.pc.Y - (tamNodo / 2), 4, 4);


                        }
                    }
                    if (tipo == 1)
                    {
                        g.DrawLine(pen2, a.interx, a.intery, a.destino.pc.X, a.destino.pc.Y);
                        g.DrawEllipse(pen3, a.interx - 2, a.intery-2, 4, 4);
                    }
                }
                
            }

            letrasEspeciales();

            if(bancolo == true)
            {
                coloreaNodos();
            }

            if (bandEuler == true)
            {
                if (bandEulerDi == false)
                {
                    for (int i = 0; i < camEuler.Count; i++)
                    {

                        foreach (CArista a in grafo.listaArista)
                        {

                            if (i + 1 < camEuler.Count)
                            {
                                if ((Convert.ToChar(camEuler.ElementAt(i) + 65)).ToString() == a.origen.nombre && (Convert.ToChar(camEuler.ElementAt(i + 1) + 65)).ToString() == a.destino.nombre)
                                {
                                    g.DrawLine(penEul, a.origen.pc, a.destino.pc);
                                }

                                if ((Convert.ToChar(camEuler.ElementAt(i) + 65)).ToString() == a.destino.nombre && (Convert.ToChar(camEuler.ElementAt(i + 1) + 65)).ToString() == a.origen.nombre)
                                {
                                    g.DrawLine(penEul, a.origen.pc, a.destino.pc);
                                }
                            }
                        }

                    }
                }
                else
                    for (int i = 0; i < camEuler.Count; i++)
                    {

                        foreach (CArista a in grafo.listaArista)
                        {

                            if (i + 1 < camEuler.Count)
                            {
                                if ((Convert.ToChar(camEuler.ElementAt(i) + 65)).ToString() == a.origen.nombre && (Convert.ToChar(camEuler.ElementAt(i + 1) + 65)).ToString() == a.destino.nombre)
                                {
                                    g.DrawLine(penEulDi, a.origen.pc, a.destino.pc);
                                }

                                if ((Convert.ToChar(camEuler.ElementAt(i) + 65)).ToString() == a.destino.nombre && (Convert.ToChar(camEuler.ElementAt(i + 1) + 65)).ToString() == a.origen.nombre)
                                {
                                    g.DrawLine(penEulDi, a.origen.pc, a.destino.pc);
                                }
                            }
                        }

                    }

            }

            
            

            pagina.DrawImage(bmp, 0, 0);
        }

        public void muestraAristaBEP()
        {
            string nodosRet = "";
            bool encRet = false;

            g.DrawString("Arco Arbol= rojo\nArco cruzado = azul\nArco retroceso = verde\nArco de avanze =  Negro", fuenteProf, brocha, 15, 50);
            //Arcos de arbol(rojo)
            foreach(CArista r in grafo.listaAristaPro)
            {
                g.DrawLine(penEul, r.origen.pc.X, r.origen.pc.Y, r.destino.pc.X, r.destino.pc.Y);
                g.DrawString(r.nombre, fuente, broProf, r.dismedx-25, r.dismedy-25);
            }
            int e = 0;
            //arcos cruzados(azul)

            if (tipo == 1)
            {
                foreach (CNodo s in grafo.listaNodos)
                {
                    foreach (CNodo t in grafo.listaNodos)
                    {
                        //Cruzados arbol a arbol
                        e = 0;
                        if (s.nombre != t.nombre && s.arbol != t.arbol)
                        {
                            foreach (CNodo u in s.listaNodosAdya)
                            {
                                e = 0;
                                if (u.arbol != s.arbol)
                                {
                                    e = 0;
                                    g.DrawLine(penEulDi, s.pc.X, s.pc.Y, u.pc.X, u.pc.Y);
                                }
                            }
                        }
                        //Cruzado
                        if (s.nivelBEP == t.nivelBEP && s.nombre != t.nombre)
                        {
                            foreach (CNodo u in s.listaNodosAdya)
                            {
                                if (u == t)
                                {
                                    g.DrawLine(penEulDi, s.pc.X, s.pc.Y, u.pc.X, u.pc.Y);
                                }
                            }
                        }

                        bool repe = false;
                        //Retroceso
                        if (s.arbol == t.arbol)
                        {
                            if (s.nivelBEP > t.nivelBEP)
                            {
                                foreach (CNodo u in s.listaNodosAdya)
                                {
                                    if (u == t)
                                    {
                                        g.DrawLine(penProRet, s.pc.X, s.pc.Y, u.pc.X, u.pc.Y);
                                        foreach(CArista ar in grafo.listaAristaPro)
                                        {
                                            foreach(string ca in Acicli)
                                            {
                                                if (ca == ar.origen.nombre)
                                                    repe = true;
                                            }

                                            if (repe == false)
                                            {
                                                Acicli.Add(ar.origen.nombre);
                                                Acicli.Add("-");
                                            }
                                            repe = false;
                                            if(ar.destino.nombre == s.nombre)
                                            {
                                                Acicli.Add(ar.destino.nombre);
                                                break;
                                            }
                                        }
                                        Acicli.Add("-");
                                        Acicli.Add(t.nombre);
                                        foreach (string ca in Acicli)
                                        {
                                            nodosRet += ca;
                                        }
                                        nodosRet += ", ";
                                        Acicli.Clear();
                                        encRet = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (s.nivelBEP > t.nivelBEP)
                            {
                                foreach (CNodo u in s.listaNodosAdya)
                                {
                                    if (u == t)
                                    {
                                        g.DrawLine(penEulDi, s.pc.X, s.pc.Y, u.pc.X, u.pc.Y);
                                    }
                                }
                            }
                        }
                    }
                }

                

                grafo.listaAristaPro.Clear();
                if (encRet == true)
                {
                    MessageBox.Show("Encontre arco de retroceso y su ciclo son " + nodosRet + " Por lo tanto hay un ciclo y no se considera un grafo aciclico");
                }
                else
                    if(tipo == 1 )
                    MessageBox.Show("En su grafo no hay arcos de retroceso por lo tanto su grafo es aciclico");
            }
            else
            {
                foreach (CNodo s in grafo.listaNodos)
                {
                    foreach (CNodo t in grafo.listaNodos)
                    {
                        //Cruze entre arboles
                        if (s.nombre != t.nombre && s.arbol != t.arbol)
                        {
                            foreach (CNodo u in s.listaNodosAdya)
                            {
                                e = 0;
                                if (u.arbol != s.arbol)
                                {
                                    e = 0;
                                    g.DrawLine(penEulDi, s.pc.X, s.pc.Y, u.pc.X, u.pc.Y);
                                }
                            }
                        }
                        //Cruzado
                        if (s.arbol == t.arbol && s.nombre != t.nombre)
                        {
                            foreach (CNodo u in s.listaNodosAdya)
                            {
                                if (u == t)
                                {
                                   g.DrawLine(penEulDi, s.pc.X, s.pc.Y, u.pc.X, u.pc.Y);
                                }
                            }
                        }
                        

                    }
                }

                /*if (tipo == 0)
                {
                    foreach (CArista r in grafo.listaAristaPro)
                    {
                        g.DrawLine(penEul, r.origen.pc.X, r.origen.pc.Y, r.destino.pc.X, r.destino.pc.Y);
                        g.DrawString(r.nombre, fuente, broProf, r.dismedx - 25, r.dismedy - 25);
                    }
                }*/
            }


            //No dirigido
            /*
            if (tipo == 1)
            foreach (CNodo s in grafo.listaNodos)
            {
                foreach (CNodo u in s.listaNodosAdya)
                {
                    if(s.nivelBEP+1 < u.nivelBEP)
                    {
                        int r = 0;
                        MessageBox.Show("Encontre un ciclo " + s.nombre + "," + u.nombre);
                    }
                }
            }*/


            foreach (CArista r in grafo.listaAristaPro)
            {
                g.DrawLine(penEul, r.origen.pc.X, r.origen.pc.Y, r.destino.pc.X, r.destino.pc.Y);
                g.DrawString(r.nombre, fuente, broProf, r.dismedx - 25, r.dismedy - 25);
            }

            encRet = false;
            nodosRet = "";
        }

        public void coloreaNodos()
        {
            
            foreach (CNodo n in grafo.listaNodos)
            {
                switch(n.colCrom)
                {
                    case 1:
                        fondoCir = new SolidBrush(Color.Red);
                        break;
                    case 2:
                        fondoCir = new SolidBrush(Color.Blue);
                        break;
                    case 3:
                        fondoCir = new SolidBrush(Color.Green);
                        break;
                    case 4:
                        fondoCir = new SolidBrush(Color.Purple);
                        break;
                    case 5:
                        fondoCir = new SolidBrush(Color.Yellow);
                        break;
                    case 6:
                        fondoCir = new SolidBrush(Color.Brown);
                        break;
                }
                 g.FillEllipse(fondoCir, n.pc.X - (tamNodo / 2), n.pc.Y - (tamNodo / 2), n.rt.Width, n.rt.Height);
                 g.DrawString(n.nombre, fuente, brocha, n.pc.X - 15 / 2, n.pc.Y - 15 / 2);

            }

            bancolo = false;

            

            /*foreach (CNodo n in grafo.listaNodos)
            {

            }*/
        }

        public void letrasEspeciales()
        {
            foreach (CNodo n in grafo.listaNodos)
            {
                //g.FillEllipse(fondoCir, pt1.X - (tamNodo / 2), pt1.Y - (tamNodo / 2), tamNodo, tamNodo);
                g.DrawEllipse(pen, n.pc.X - (tamNodo / 2), n.pc.Y - (tamNodo / 2), n.rt.Width, n.rt.Height);
                
                switch (bandEspe)
                {
                    case 1:
                        g.DrawEllipse(pen, n.px - (tamNodo / 2), n.py - (tamNodo / 2), 50, 50);
                        g.DrawLine(pen, 625, 0, 625, 350);
                        g.DrawLine(pen, 0, 350, 900, 350);
                        g.DrawString("2 regular", fuente, brocha, 200, 50);
                        g.DrawString("3 regular", fuente, brocha, 700, 50);
                        g.DrawString("4 regular", fuente, brocha, 200, 400);
                        break;
                    case 2:
                        g.DrawEllipse(pen, n.px - (tamNodo / 2), n.py - (tamNodo / 2), 50, 50);
                        g.DrawString("K1", fuente, brocha, 90, 250);
                        g.DrawString("K2", fuente, brocha, 250, 250);
                        g.DrawString("K3", fuente, brocha, 450, 250);
                        g.DrawString("K4", fuente, brocha, 650, 250);
                        g.DrawString("K5", fuente, brocha, 900, 300);
                        g.DrawString("K6", fuente, brocha, 90, 600);
                        g.DrawString("K7", fuente, brocha, 380, 600);
                        break;
                    case 3:
                        g.DrawEllipse(pen, n.px - (tamNodo / 2), n.py - (tamNodo / 2), 50, 50);
                        g.DrawString("C3", fuente, brocha, 100, 250);
                        g.DrawString("C4", fuente, brocha, 350, 250);
                        g.DrawString("C5", fuente, brocha, 600, 250);
                        g.DrawString("C6", fuente, brocha, 900, 350);
                        g.DrawString("C7", fuente, brocha, 100, 500);
                        break;
                    case 4:
                        g.DrawEllipse(pen, n.px - (tamNodo / 2), n.py - (tamNodo / 2), 50, 50);
                        g.DrawString("W3", fuente, brocha, 100, 300);
                        g.DrawString("W4", fuente, brocha, 500, 300);
                        g.DrawString("W5", fuente, brocha, 900, 300);
                        g.DrawString("W6", fuente, brocha, 100, 600);
                        g.DrawString("W7", fuente, brocha, 550, 650);
                        break;
                    case 5:
                        g.DrawEllipse(pen, n.px - (tamNodo / 2), n.py - (tamNodo / 2), 50, 50);
                        g.DrawString("Q1", fuente, brocha, 100, 150);
                        g.DrawString("Q2", fuente, brocha, 300, 250);
                        g.DrawString("Q3", fuente, brocha, 100, 650);
                        g.DrawString("Q4", fuente, brocha, 500, 600);
                        break;

                }
                if (bandEspe == 0 || bandEspe == 5)
                {
                    if (bandEspe == 5)
                        g.DrawString(n.nombre, fuente, brocha, (n.pc.X - 15 / 2), (n.pc.Y - 15 / 2) + 5);
                    else
                        g.DrawString(n.nombre, fuente, brocha, n.pc.X - 15 / 2, n.pc.Y - 15 / 2);
                }
            }
        }



        //Boton de caminos
        public void caminoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int r = 0;
            bool banEulUll = false;

            cromatico cr = new cromatico();

            cr.buscaAdy(grafo, tipo);
            Stack<CNodo> nodoPri = new Stack<CNodo>();

            foreach (CNodo a in grafo.listaNodos)
            {
                if((a.listaNodosAdya.Count() % 2) != 0)
                {
                    //Stack <CNodo> no = new()       
                    r = 0;
                    nodoPri.Push(a);
                    nodoPri = generaCamino(nodoPri, a.pos-1);
                    r = 0;
                    banEulUll = true;//camino
                    break;

                }
            }


            r = 0;


            if (banEulUll == false)//circuito
            {
                r = 0;
                nodoPri.Push(grafo.listaNodos.First());
                nodoPri = generaCamino(nodoPri, grafo.listaNodos.First().pos-1);
                r = 0;
            }

            r = 0;


            for (int i = 0; i < nodoPri.Count; i++)
            {
                camEuler.Add(nodoPri.ElementAt(i).pos - 1);
            }

            int z = 0;
            string orden;
            orden = "";

            while (z < camEuler.Count)
            {
                orden += (Convert.ToChar(camEuler.ElementAt(z) + 65)).ToString();
                orden += ",";
                z++;
            }


            if (camEuler.ElementAt(0) == camEuler.ElementAt(camEuler.Count()-1) || banEulUll == false)
            {
                MessageBox.Show("Listo... Encontre un Circuito " + orden);
                bandEuler = false;
                camEuler.Clear();
            }
            else
            if (banEulUll == true)
            {
                MessageBox.Show("Listo... Encontre un Camino " + orden);
                bandEuler = false;
                camEuler.Clear();
            }



            bandEuler = true;

            for (int i = 0; i < nodoPri.Count; i++)
            {
                camEuler.Add(nodoPri.ElementAt(i).pos-1);
                r = 0;
                Form1_Paint(this, null);
                Thread.Sleep(1000);
            }

            camEuler.Clear();
            nodoPri.Clear();

            
        }

        public Stack<CNodo> generaCamino(Stack<CNodo> caminoTemp, int inicio)
        {
            int numVertices = grafo.listaNodos.Count();
            Stack<CNodo> caminoFinal = new Stack<CNodo>();
            ///Matriz de adyacencia temporal
            int[,] MtrzAdy = new int[numVertices, numVertices];
            //generaMatrizAdyacencia();

            MtrzAdy = grafo.matrizAdyacencia;

            int r = 0;

            try
            {
                if (tipo == 0)
                {
                    while (caminoTemp.Count != 0)
                    {
                        for (int i = 0; i < numVertices; i++)
                        {
                            if (MtrzAdy[inicio, i] == 1)
                            {
                                caminoTemp.Push(grafo.listaNodos[i]);
                                
                                MtrzAdy[inicio, i] = 0;
                                MtrzAdy[i, inicio] = 0;
                                if (!tieneVecino(caminoTemp.Peek(), MtrzAdy))
                                {
                                    while (!tieneVecino(caminoTemp.Peek(), MtrzAdy))
                                    {
                                        caminoFinal.Push(caminoTemp.Pop());
                                    }
                                    inicio = grafo.listaNodos.IndexOf(caminoTemp.Peek());
                                }
                                else
                                {
                                    inicio = i;
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (tipo == 1)
                {
                    while (caminoTemp.Count != 0)
                    {
                        for (int i = 0; i < numVertices; i++)
                        {
                            if (MtrzAdy[inicio, i] == 1)
                            {
                                caminoTemp.Push(grafo.listaNodos[i]);
                                
                                MtrzAdy[inicio, i] = 0;
                                
                                if (!tieneVecino(caminoTemp.Peek(), MtrzAdy))
                                {
                                    while (!tieneVecino(caminoTemp.Peek(), MtrzAdy))
                                    {
                                        caminoFinal.Push(caminoTemp.Pop());
                                    }
                                    inicio = grafo.listaNodos.IndexOf(caminoTemp.Peek());
                                }
                                else
                                {
                                    inicio = i;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception) { }

            return caminoFinal;
        }


        public Boolean tieneVecino(CNodo v, int[,] matriz)
        {
            int indice = grafo.listaNodos.IndexOf(v);
            for (int i = 0; i < grafo.listaNodos.Count(); i++)
            {
                if (matriz[indice, i] == 1)
                {
                    return true;
                }
            }
            return false;
        }


        #endregion fin Manejador Menu

        #region Manejador Mouse

        //Este es un evento del mause cuando se preciona el boton del mause
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            brocha.Color = color;
            pen.Brush = brocha;
            pen.Width = aLinea;
            pt1 = e.Location;

            switch (fig)
            {
                case 1: band = true;
                    Form1_Paint(this, null);
                    break;
                case 2:
                    if ((nOrigen = grafo.BuscaNodo(pt1)) != null)
                    {
                        pt1 = nOrigen.pc;
                        band = true;
                        bandArista = true;


                    }
                    if (bandNodoRa == true && (nodoRa = grafo.BuscaNodo(pt1)) != null)
                    {
                        MessageBox.Show("Has elegido el nodo:" + nodoRa.nombre+", Ahora da clik en mostrar caminos");

                    }
                break;
            }
        }
        
        //Redimensiona 
        private void Form1_Resize(object sender, EventArgs e)
        {
            bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
        }

        private void mosotrarCaminosBEAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafo.listaAristaPro.Clear();
            int y = 0;
            if (nodoRa != null && tipo == 0)
            {
                cromatico cr = new cromatico();
                cr.buscaAdy(grafo, 0);
                
                BusEnAm b = new BusEnAm();
                b.buscaNodosCa(grafo, nodoRa);
                bandProfun = true;
                

                y = 0;

                
                foreach(CNodo a in grafo.listaNodos)
                {
                    if (a.visitado == false)
                    {
                        a.arbol++;
                        y = 0;
                        b.buscaNodosCa(grafo, a);
                    }
                }

                y = 0;
                
                Form1_Paint(this, null);
                bandNodoRa = false;

            }
        }

        private void mostrarArbolToolStripMenuItem_Click(object sender, EventArgs e)//Kruskal
        {
            Kruskal gk = new Kruskal();

            nodoRa = grafo.listaNodos.ElementAt(0);
            if (nodoRa != null && bandEtique == true)
            {
                gk.asignaGrafo(grafo, nodoRa);
                gk.buscaArbol(grafo);
                
                grafo = gk.grafoFin;
                band = false;
               // bandEM = true;

                Form1_Paint(this, null);

                ///band = true;
                //bandEM = false;

                band = true;///

                float cont = 0;
                foreach(CArista a in gk.grafoFin.listaArista)
                {
                    cont += Convert.ToSingle(a.nombre);
                }

                MessageBox.Show("Peso del arbol: " + cont);

                
            }
            bandNodoRa = false;
            bandEtique = false;
        }

        /*private void kruskalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }*/

        private void caminToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void etiquetarAristaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para Habilitar esta opcion tienes que primero poner solo los nodos\n,despues tiene que seleccionar la opcion de Tipo\n" +
                "Ahora ya nadamas crea aristas");
            bandEtique = true;
            //tipo = 1;
        }

        private void matrizesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Floyd f = new Floyd();

            if(bandEtique == true && tipo == 1)
            {
                f.creaMatriz(grafo);
                bandExcentri = true;
                exceFloyGra = f.excentr;
                lisExntr = f.lisExF;

            }
            
        }

        private void mostrarCaminosToolStripMenuItem_Click(object sender, EventArgs e)//Dijstra
        {
            if (bandEtique == true && tipo == 1)
            {
                Dijkstra dij = new Dijkstra();
                cromatico cr = new cromatico();

                
                dij.creaMatriz(grafo);
                dij.pesosNR(nodoRa,grafo);
                cr.buscaAdy(grafo, 1);
                dij.creaPesos(nodoRa, grafo);
                dij.imprimeResu(nodoRa, grafo);
                bandNodoRa = false;
            }
        }

        private void excentrisidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bandExcentri == true)
            {
                Floyd fm = new Floyd();

               
                string lis = "";

                foreach(float a in lisExntr)
                {
                    lis += a.ToString();
                    lis += ",";
                }

                MessageBox.Show("Excentricidad del grafo: " + exceFloyGra+" de la lista "+ lis);
            }
            else
                MessageBox.Show("Para sacar extentrisidad, tienes que haber hecho floyd y sacar sus matrizes");
        }



        private void elegirNodoRaizToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //if (tipo == 1)
            //{
                MessageBox.Show("Elige un nodo");
                bandNodoRa = true;

            /*}
            else
                MessageBox.Show("Tu grafo es no dirigido");*/

        }

        private void mostrarCaminosBEPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafo.listaAristaPro.Clear();
            if(nodoRa != null /*&& tipo == 1*/)
            {
                cromatico cr = new cromatico();
                if (tipo == 1)
                {
                    
                    cr.buscaAdy(grafo, 1);
                
                }
                else
                {
                    cr.buscaAdy(grafo, 0);
                }

                BusEnPro b = new BusEnPro();
                b.buscaNodosCa(grafo, nodoRa);
                //int fg = 0;
                bandProfun = true;
                Form1_Paint(this, null);
                bandNodoRa = false;

            }
        }

        //Evento de  donde se suelta el boton del mouse
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {   
            pt2 = e.Location;
            if (fig == 2 && (nDestino = grafo.BuscaNodo(pt2)) != null && nOrigen != null)
            {
                pt2 = nDestino.pc;
                if (bandEtique == false)
                {
                    arista = new CArista(nOrigen, nDestino);
                    arista.CalInterseccion(nOrigen, nDestino);
                    arista.compMultiAri(grafo, nOrigen, nDestino);
                    grafo.listaArista.Add(arista);
                    grafo.obtenMatriz(tipo);
                    eu.grafo = grafo;
                    Form1_Paint(this, null);
                }
                else
                {
                    //if (tipo == 1)
                    //{
                        peso.ShowDialog();//
                        arista = new CArista(nOrigen, nDestino, peso.peso);//
                        arista.CalInterseccion(nOrigen, nDestino);
                        arista.compMultiAri(grafo, nOrigen, nDestino);
                        grafo.listaArista.Add(arista);
                        grafo.obtenMatriz(tipo);
                        eu.grafo = grafo;
                        Form1_Paint(this, null);
                    /*}
                    else
                    {
                        //MessageBox.Show("Tu grafo es no dirigido");
                    }*/
                }
                
            }

            if (fig == 3)
            {
                nOrigen = null;
            }
        }

        private void cromaticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cromatico cro = new cromatico();
            int numeroCroma;
            cro.buscaAdy(grafo,0);
            cro.ordeAdya(grafo);
            cro.asignaColo(grafo);
            bancolo = true;
            Form1_Paint(this, null);
            numeroCroma = cro.numCromGra(grafo);
            MessageBox.Show("Su grafo tiene un numero cromatico de " + numeroCroma);
            if(numeroCroma == 4)
            {
                MessageBox.Show("Su grafo cumple con el teorema de los 4 colores");
            }
        }

        //Evento para saber si hubo movimento mientras se precionaba el mouse
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {   
            switch (fig)
            {
                case 2:
                    if(MouseButtons.Left.Equals(e.Button) && bandArista == true)
                    {
                        pt2 = e.Location;
                        Form1_Paint(this, null);
                    }
                break;
                case 3:
                if (MouseButtons.Left.Equals(e.Button))// && grafo.BuscaNodo(e.Location) != null)
                    {
                        if (nOrigen != null)
                        {
                            pt1 = e.Location;
                            nOrigen.MoverNodo(pt1);
                            Form1_Paint(this, null);
                        }
                    }
                break;
            }  
        }

        #endregion Fin Manejador Mouse


        private bool ptInRect(Point pt, Rectangle rt)
        {
            return rt.Contains(pt);
        }


        /**
         * Enseguida biene todos los diferentes grafos especiales con los valores que defenia desde un principio
         * */
        private void k7ToolStripMenuItem_Click(object sender, EventArgs e)//Grafo completo
        {
            Especiales k = new Especiales();
            grafo = k.creaK(grafo);
            bandEspe = 2;
            Form1_Paint(this, null);
        }

        private void nRegularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Especiales nReg = new Especiales();
            grafo = nReg.creaNreg(grafo);
            bandEspe = 1;
            Form1_Paint(this, null);

        }

        private void grafoCiclo_Click(object sender, EventArgs e)
        {
            Especiales ciclo = new Especiales();
            grafo = ciclo.creaCic(grafo);
            bandEspe = 3;
            Form1_Paint(this, null);
        }

        private void grafoVolanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Especiales volante = new Especiales();
            grafo = volante.creaVolante(grafo);
            bandEspe = 4;
            Form1_Paint(this, null);
        }

        private void grafoQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Especiales Q = new Especiales();
            grafo = Q.creaQ(grafo);
            bandEspe = 5;
            Form1_Paint(this, null);
        }


        //Imprime las regiones
        private void regionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int r = 2 + grafo.listaArista.Count - grafo.listaNodos.Count;

            MessageBox.Show("Su grafo posee " + r + " regiones");

        }


        //Este metodo compara las regiones
        public List<List <int>> compRegiones(List<List<int>> posRegiones)
        {
            List<int> Reg = new List<int>();
            List<int> InReg = new List<int>();
            List<List<int>> FReg = new List<List<int>>();
            bool igual = false;

            for (int i = 0; i < posRegiones.Count; i++)
            {
                if (FReg.Count() == 0)
                {
                    for (int j = 0; j < posRegiones.ElementAt(i).Count; j++)
                    {
                        Reg.Add(posRegiones.ElementAt(i).ElementAt(j));
                    }
                    FReg.Add(Reg);
                }
                else
                {
                    for(int k = 0; k <FReg.Count; k++)
                    {

                        for(int l = 0, des = FReg.ElementAt(k).Count; l < FReg.ElementAt(k).Count-1 && igual == false; l++,des--)//Comparar numero por numero
                        {
                            if(FReg.ElementAt(k).ElementAt(l+1) == posRegiones.ElementAt(i).ElementAt(l+1))
                            {
                                igual = true;
                            }
                            else
                            {
                                igual = false;
                            }
                        }

                    }
                }
            }
            return FReg;
            
        }


        //Este es el boton del click para llamar kuratoski automatico
        private void automaticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int difeNodo = 0;
            int difArista = 0;
            elecKura.ShowDialog();

            if (elecKura.tipo == 1)//K5
            {
                if (grafo.listaNodos.Count < 5)
                    MessageBox.Show("Tienes muy pocos nodos, no puedo proseguir");
                else
                {
                    if (grafo.listaArista.Count < 10)
                    {
                        MessageBox.Show("Tienes muy pocas aristas, no puedo proseguir");
                    }
                    else
                    {
                        difeNodo = grafo.listaNodos.Count() - 5;
                        difArista = grafo.listaArista.Count() - 10;
                        MessageBox.Show("Tu grafo le quitaremos " + difeNodo + " nodos y " + difArista + " aristas");

                        int iNo = 0, gra = 0, idN = 0;
                        bool elimi = false;

                        while (idN < difeNodo)
                        {
                            foreach (CNodo a in grafo.listaNodos)
                            {
                                foreach (CArista b in grafo.listaArista)
                                {
                                    if (a.nombre == b.origen.nombre || a.nombre == b.destino.nombre)
                                    {
                                        gra++;
                                    }
                                }

                                if (gra < 4)
                                {
                                    kI.eliminaNodo(grafo.listaNodos.ElementAt(iNo).nombre, grafo);
                                    elimi = true;
                                    break;
                                }
                                if (elimi == true)
                                    break;

                                gra = 0;
                                iNo++;
                            }
                            elimi = false;
                            iNo = 0;
                            idN++;
                        }
                        idN = 0;



                    }
                }
              
                MessageBox.Show("Este algoritmo de automatico no lo alcanze a terminar");
                Form1_Paint(this, null);
            }
            else
            {
                if (elecKura.tipo == 2)//K 33
                {
                    if (grafo.listaNodos.Count < 6)
                        MessageBox.Show("Tienes muy pocos nodos");
                    if (grafo.listaArista.Count < 9)
                    {
                        MessageBox.Show("Tienes muy pocas aristas, no puedo proseguir");
                    }
                    else
                    {

                        difeNodo = grafo.listaNodos.Count() - 6;
                        difArista = grafo.listaArista.Count() - 9;
                        MessageBox.Show("Tu grafo le quitaremos " + difeNodo + " nodos y " + difArista + " aristas");

                        
                    }
                }
            }
            
        }


        //Este metodo me abre la opcion de interactivo en kuratoski
        private void interactivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int difeNodo = 0;
            int difArista = 0;
            elecKura.ShowDialog();

            if (elecKura.tipo == 1)//K5
            {

                        difeNodo = grafo.listaNodos.Count() - 5;
                        difArista = grafo.listaArista.Count() - 10;
                        MessageBox.Show("Tu grafo le quitaremos " + difeNodo + " nodos y " + difArista + " aristas");

                    CGrafo graCop;
                    graCop = grafo;
                    
                    kI.asignaValor(graCop);
                    kI.tipoG = 1;
                    kI.Show();
                    
            }
            else
            {
                
                difeNodo = grafo.listaNodos.Count() - 6;
                        difArista = grafo.listaArista.Count() - 9;
                        MessageBox.Show("Tu grafo le quitale " + difeNodo + " nodos y " + difArista + " aristas");
                   
                    CGrafo graCop;
                    graCop = grafo;

                    kI.asignaValor(graCop);
                    kI.tipoG = 2;
                    kI.Show();
                    
                
            }
        }


        //Este metodo me comprueba si esta fuertemente conectado
        private void ConectadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool seguir = true;

            if (tipo == 1)
            {
                List<List<int>> conexion = new List<List<int>>();

                for (int k = 0; k <grafo.listaNodos.Count && seguir == true; k++)
                {
                    for(int l = 0; l < grafo.listaNodos.Count && seguir == true; l++)
                    {
                        if (k != l)
                        {
                            conexion = eu.HayCamino(k, l, grafo.matrizAdyacencia, grafo.listaNodos.Count);
                            if (conexion.Count == 0)
                            {
                                MessageBox.Show("No hay conexion entre el nodo " + Convert.ToChar(k + 65) + " y " + Convert.ToChar(l + 65)+" \nPor lo tanto es un grafo debilmente conectado");
                                seguir = false;
                            }
                        }
                    }
                }
                if (seguir == true)
                    MessageBox.Show("Hay conexion entre cada par de nodos de su grafo, por lo tanto es un grafo fuertemente conectado");
            }
            else
                MessageBox.Show("No puedo hacer la accion con un grafo no dirigido");
        }

        

        //Comprueba los colorarios
        private void colorariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafo.colorarioGrafo();
        }
    }
}


