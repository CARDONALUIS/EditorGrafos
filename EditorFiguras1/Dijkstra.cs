using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace EditorFiguras1
{
    class Dijkstra
    {
        public int[,] matDij;
        public int[] pesoNR;
        public List<int> s;
        int contOri = 0, contDes = 0;

        public void creaMatriz(CGrafo grafo)
        {
            matDij = new int[grafo.listaNodos.Count, grafo.listaNodos.Count];

            for (int fila = 0; fila < grafo.listaNodos.Count; fila++)//Saca los valores de la matriz de adyacencia 1
            {

                for (int col = 0; col < grafo.listaNodos.Count; col++)
                {
                    if (fila != col && grafo.matrizAdyacencia[fila, col] == 0)
                    {
                        matDij[fila, col] = 999999;
                    }
                    else
                        matDij[fila, col] = grafo.matrizAdyacencia[fila, col];
                }
            }

            foreach (CArista a in grafo.listaArista)//Asigna valores de relaciones de los nodos
            {
                int co = 1;

                while (a.origen.pos != co)
                {
                    contOri++;
                    co++;
                }

                co = 1;

                while (a.destino.pos != co)
                {
                    contDes++;
                    co++;
                }
                co = 1;

                matDij[contOri, contDes] = Convert.ToInt32(a.nombre);

                contOri = 0;
                contDes = 0;

            }
        }

        public void pesosNR(CNodo ra, CGrafo grafo)
        {
            pesoNR = new int[grafo.listaNodos.Count];

            for (int i = 0; i < grafo.listaNodos.Count; i++)
            {
                for (int j = 0; j < grafo.listaNodos.Count; j++)
                {
                    if (ra.pos - 1 == i)
                    {
                        pesoNR[j] = matDij[i, j];
                    }
                }
            }
        }

        public void creaPesos(CNodo ra, CGrafo grafo)
        {
            s = new List<int>();
            bool bandEncon = false;
            int menor = 9999, posTemp = 0, pos = 0;
            int i = 0, k = 0;
            s.Add(ra.pos);

            int r = 0;

            while (s.Count < grafo.listaNodos.Count)
            {
                r = 0;
                r = 0;
                k = 0;
                while (k < pesoNR.Length)
                {
                    r = 0;

                    if (pesoNR[k] != 0 && pesoNR[k] < menor)
                    {
                        r = 0;
                        posTemp = k;
                        foreach (int j in s)
                        {
                            r = 0;
                            if (posTemp + 1 == j)
                            {
                                r = 0;
                                bandEncon = true;
                            }
                        }

                        if (bandEncon == false)
                        {
                            r = 0;
                            pos = posTemp;
                            menor = pesoNR[k];

                        }
                        r = 0;

                    }
                    if (bandEncon == true)
                        bandEncon = false;

                    k++;
                }

                menor = 9999;

                r = 0;
                if (bandEncon == false)
                {
                    s.Add(pos + 1);
                    r = 0;
                    foreach (CNodo a in grafo.listaNodos)
                    {
                        r = 0;
                        if (a.pos == pos + 1)
                        {
                            r = 0;
                            foreach (CNodo b in a.listaNodosAdya)
                            {
                                r = 0;

                                if (pesoNR[b.pos - 1] > pesoNR[a.pos - 1] + matDij[a.pos - 1, b.pos - 1])
                                {
                                    r = 0;
                                    pesoNR[b.pos - 1] = pesoNR[a.pos - 1] + matDij[a.pos - 1, b.pos - 1];
                                    r = 0;
                                }

                            }
                            break;
                        }
                    }
                }
                else
                {
                    r = 0;
                    bandEncon = false;
                }

            }

            r = 0;


        }

        public int buscaMenor(int[] pesos)
        {
            int menor = 99999, i = 0, pos = 0;

            while (i < pesos.Length)
            {
                if (pesos[i] != 0 && pesos[i] < menor)
                {
                    menor = pesos[i];
                    pos = i;

                }
                i++;
            }

            return pos;
        }

        public void imprimeResu(CNodo nR,CGrafo grafo)
        {
            string dij = "";
            MessageBox.Show("Caminos mas cortos de " + nR.nombre+" a");
            for (int i = 0; i < pesoNR.Length; i++)
            {
                dij += (Convert.ToChar(i + 65)).ToString() + " -> " + pesoNR[i]+"\n";
            }
            MessageBox.Show(dij);
            dij = "";
        }

    }
}
