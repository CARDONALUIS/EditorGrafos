using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorFiguras1
{
    public class Euler
    {
        public CGrafo grafo;

        public List<List<int>> Euler_Fleury(int[,] MR)
        {
            int x = 0;
            if (CaminoEuler(MR))
                return null;
            int[,] mr_org = new int[grafo.listaNodos.Count, grafo.listaNodos.Count];

            int count = grafo.listaNodos.Count;
            List<List<int>> circuitos = new List<List<int>>(); ;
            if (!EsConexo(MR, grafo.listaNodos.Count)) return circuitos;

            int[] grados = CalculaGrados(grafo.listaNodos.Count, MR);
            for (int i = 0; i < grados.Length; i++)
                if (grados[i] % 2 != 0)
                    return circuitos;
            // termino de comprobar si puede existir trayectoria euleriana
            for (int i = 0; i < grafo.listaNodos.Count; i++)
            {
                mr_org = (int[,])MR.Clone();
                CreaTrayectoriaFleury(circuitos, new List<int>(), i, i, mr_org, grafo.listaNodos.Count);
            }

            return circuitos;

        }

        // Crea una trayectoria de fleury
        public void CreaTrayectoriaFleury(List<List<int>> caminos, List<int> camino, int n1, int n2, int[,] MR, int count)
        {
            camino.Add(n1);
            if (TodoDesconectado(MR, count))
            {
                caminos.Add(camino);
                return;
            }
            List<int[]> puentes = EncuentraPuentes(MR, count);
            for (int i = 0; i < count; i++)
                if (MR[n1, i] == 1 && !EsPuente(new int[] { n1, i }, puentes))
                {
                    MR[n1, i] = 0;
                    MR[i, n1] = 0;
                    List<int> c = new List<int>();
                    for (int j = 0; j < camino.Count; j++)
                        c.Add(camino[j]);
                    CreaTrayectoriaFleury(caminos, c, i, n1, (int[,])MR.Clone(), count);
                    MR[n1, i] = 1;
                    MR[i, n1] = 1;
                }
                else if (MR[n1, i] == 1 && UltimaArista(MR, n1, count))
                {
                    MR[n1, i] = 0;
                    MR[i, n1] = 0;
                    List<int> c = new List<int>();
                    for (int j = 0; j < camino.Count; j++)
                        c.Add(camino[j]);
                    CreaTrayectoriaFleury(caminos, c, i, n1, (int[,])MR.Clone(), count);
                    MR[n1, i] = 1;
                    MR[i, n1] = 1;
                }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Sig Camino");
        }


        //Checa ultima arista
        public bool UltimaArista(int[,] mrel, int nodo, int count)
        {
            int aristas = 0;
            for (int i = 0; i < count; i++)
                aristas += mrel[nodo, i];
            if (aristas == 1)
                return true;
            else
                return false;
        }


        //Todo esta desconectado
        public bool TodoDesconectado(int[,] mrel, int count)
        {
            List<int[]> pesos = CalculaPeso(mrel, count);
            foreach (int p in pesos[0])
                if (p != 0)
                    return false;
            return true;
        }

        //rel es del formato 01, indicando que el nodo 0 se relaciona con el nodo 1
        public bool EsPuente(int[] rel, List<int[]> puentes)
        {
            foreach (int[] r in puentes)
                if (r[0] == rel[0] && r[1] == rel[1] || (r[0] == rel[1] && r[1] == rel[0]))
                    return true;
            return false;
        }

        //Busca caminos de euler
        public bool CaminoEuler(int[,] MR)
        {
            if (!EsConexo(MR, grafo.listaNodos.Count)) return false;

            int g_impar = 0;
            int[] grados = CalculaGrados(grafo.listaNodos.Count, MR);
            for (int i = 0; i < grados.Length; i++)
                if (grados[i] % 2 != 0)
                    g_impar++;
            if (g_impar != 2) return false;


            return true;
        }

        //Encuentra puentes en el grafo
        public List<int[]> EncuentraPuentes(int[,] mr, int count)
        {
            List<int[]> puentes = new List<int[]>();

            for (int i = 0; i < count; i++)
                for (int j = i + 1; j < count; j++)
                    if (mr[i, j] == 1)
                    {
                        mr[i, j] = 0;
                        mr[j, i] = 0;
                        if (!EsConexo(mr, count))
                            puentes.Add(new int[] { i, j });
                        mr[i, j] = 1;
                        mr[j, i] = 1;
                    }
            return puentes;
        }


        //Comprueba si es conexo
        public bool EsConexo(int[,] mrel, int count)
        {
            List<List<int>> caminos;
            for (int i = 1; i < count; i++)
                if ((caminos = HayCamino(0, i, mrel, count)).Count == 0)
                    return false;
            return true;
        }



        //busca un camino entre el indice del nodo n1 y n2 de un grafo
        public List<List<int>> HayCamino(int n1, int n2, int[,] MR, int count)
        {

            List<List<int>> caminos = new List<List<int>>();

            for (int i = 0; i < count; i++)
                if (MR[n1, i] == 1)
                    CreaCamino(caminos, new List<int> { n1 }, i, n2, MR, count);

            if (n1 == n2)//para circuitos
            {
                int limpiando = caminos.Count;
                while (limpiando != 0)
                {
                    for (int i = 0; i < caminos.Count; i++)
                        if (caminos[i].Count < 4)
                        {
                            caminos.RemoveAt(i);
                            break;
                        }
                    limpiando--;
                }
            }


            return caminos;


        }

        //Va creando caminos en el grafo
        public void CreaCamino(List<List<int>> caminos, List<int> camino, int n1, int n2, int[,] MR, int count)
        {
            if (camino.Contains(n1))
            {
                if (n1 == n2)
                {
                    camino.Add(n1);
                    caminos.Add(camino);
                    return;
                }
                camino.Add(n1);
                return;
            }
            camino.Add(n1);
            if (n1 == n2)
            {
                caminos.Add(camino);
                return;
            }

            for (int i = 0; i < count; i++)
            {

                if (MR[n1, i] == 1)
                {
                    List<int> c = new List<int>();
                    for (int j = 0; j < camino.Count; j++)
                        c.Add(camino[j]);
                    CreaCamino(caminos, c, i, n2, MR, count);
                }
            }
        }

        //retorna una lista de dos arreglos de int, con los pesos de renglon y columna
        public List<int[]> CalculaPeso(int[,] MR, int count)
        {
            int[] pesoC = new int[count], pesoR = new int[count];
            List<int[]> pesos = new List<int[]>();

            for (int i = 0; i < count; i++)
                for (int j = 0; j < count; j++)
                {
                    pesoR[i] += MR[i, j];
                    pesoC[j] += MR[j, i];
                }
            pesos.Add(pesoR);
            pesos.Add(pesoC);
            return pesos;
        }


        //Calcula los grados
        public int[] CalculaGrados(int Count, int[,] MR)
        {
            int[] grados = new int[25];

            for (int i = 0; i < Count; i++)
            {
                grados[i] = 0;
                for (int j = 0; j < Count; j++)
                    if (i != j)
                        grados[i] += MR[i, j] + MR[j, i];
            }
            return grados;
        }
    }
}
