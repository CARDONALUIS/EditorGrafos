using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorFiguras1
{
    [Serializable]
    public class CGrafo
    {
        public List<CNodo> listaNodos;
        public List<CArista> listaArista;
        public List<CArista> listaAristaPro;
        public int[,] matrizAdyacencia;
        public CNodo nodo;
        public Rectangle cua;
        public bool esPlaXColo = false;
        Graphics g;
        Pen pen;
        SolidBrush brocha;

        public CGrafo()
        {
            listaNodos = new List<CNodo>();
            listaArista = new List<CArista>();
            listaAristaPro = new List<CArista>();
            brocha = new SolidBrush(Color.Black);
            cua = new Rectangle();
            pen = new Pen(brocha, 5);
        }

        public CNodo BuscaNodo(Point p)
        {
            double df1,df2, d;

            nodo = null;
            foreach (CNodo n in listaNodos)
            {
                df1 = p.X-n.pc.X;
                df2 = p.Y - n.pc.Y;

                d = Math.Sqrt(Math.Pow(df1, 2) + Math.Pow(df2, 2)); 
                if(d <= (n.rt.Width)/2)
                {
                    nodo = n;
                    break; 
                }
            } 
            return nodo;
        }



        private Rectangle Rectangle(int p1, int p2, int p3, int p4)
        {
            throw new NotImplementedException();
        }

        public void obtenMatriz(int tipo)
        {
            //matrizAdyacencia = 
            matrizAdyacencia = new int[this.listaNodos.Count, this.listaNodos.Count];


            if (tipo == 0)
            {
                int i = 0, j = 0;
                foreach (CNodo a in this.listaNodos)
                {
                    foreach (CNodo b in this.listaNodos)
                    {
                        matrizAdyacencia[i, j] = 0;
                        j++;
                    }
                    j = 0;
                    i++;
                }

                i = 0;
                j = 0;
                char c = 'A';
                int contOri = 0, contDes = 0;
                int conMulti = 1;


                foreach (CArista a in this.listaArista)//Asigna valores de relaciones de los nodos
                {
                    while (a.origen.nombre != c.ToString())
                    {
                        contOri++;
                        c++;
                    }

                    c = 'A';

                    while (a.destino.nombre != c.ToString())
                    {
                        contDes++;
                        c++;
                    }
                    c = 'A';


                    matrizAdyacencia[contOri, contDes] = conMulti;
                    matrizAdyacencia[contDes, contOri] = conMulti;


                    contOri = 0;
                    contDes = 0;
                    conMulti = 1;
                }
            }
            else
            {
                int i = 0, j = 0;
                foreach (CNodo a in this.listaNodos)
                {
                    foreach (CNodo b in this.listaNodos)
                    {
                        matrizAdyacencia[i, j] = 0;
                        j++;
                    }
                    j = 0;
                    i++;
                }

                i = 0;
                j = 0;
                char c = 'A';
                int contOri = 0, contDes = 0;
                int conMulti = 1;


                foreach (CArista a in this.listaArista)//Asigna valores de relaciones de los nodos
                {
                    while (a.origen.nombre != c.ToString())
                    {
                        contOri++;
                        c++;
                    }

                    c = 'A';

                    while (a.destino.nombre != c.ToString())
                    {
                        contDes++;
                        c++;
                    }
                    c = 'A';


                    matrizAdyacencia[contOri, contDes] = conMulti;

                    contOri = 0;
                    contDes = 0;
                    conMulti = 1;
                }
            }
        }

        public void colorarioGrafo()
        {

            int numNodos = 0, numAristas = 0, resCol1, resCol2;

            foreach (CNodo a in this.listaNodos)
                numNodos++;

            foreach (CArista b in this.listaArista)
                numAristas++;

            MessageBox.Show("COLORARIO 1");
            resCol1 = 3 * numNodos - 6;
            MessageBox.Show("E <= 3V - 6\n" +
                numAristas + " <= 3(" + numNodos + ") - 6\n" +
                +numAristas + " <= " + resCol1);


            if (numAristas <= resCol1)
            {
                MessageBox.Show("Su grafo si cumple con el colorario 1");
                MessageBox.Show("COLORARIO 2");
                resCol2 = 2 * numNodos - 4;
                MessageBox.Show("E <= 2V – 4 \n" +
                numAristas + " <= 2(" + numNodos + ") - 4\n" + numAristas + " <= " + resCol2);



                if (numAristas <= resCol2)
                {
                    MessageBox.Show("Su grafo si cumple con el colorario 2, por lo tanto si es plano");
                    esPlaXColo = true;
                }
                else
                    MessageBox.Show("Su grafo no cumple con el colorario 2, por lo tanto no es plano");

            }
            else
                MessageBox.Show("Su grafo no cumple con el colorario 1, por lo tanto no es plano");
        }

        
    }
}
