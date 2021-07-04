using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorFiguras1
{
    public class cromatico
    {
        public List<CNodo> listaNodosOrde = new List<CNodo>();
        int colInt = 1;
        bool encon = false;

        public void buscaAdy(CGrafo gCro, int tipo)
        {
            foreach (CNodo a in gCro.listaNodos)
            {
                a.listaNodosAdya.Clear();
                foreach (CArista b in gCro.listaArista)
                {
                    if (tipo == 0)
                    {
                        if (a.nombre == b.origen.nombre)
                            a.listaNodosAdya.Add(b.destino);
                        if (a.nombre == b.destino.nombre)
                            a.listaNodosAdya.Add(b.origen);
                    }
                    else
                    {
                        if (a.nombre == b.origen.nombre)
                            a.listaNodosAdya.Add(b.destino);
                    }
                }
                //int u = 0;
                a.listaNodosAdya = OrdenaLista(a.listaNodosAdya);
                a.numAdya = a.listaNodosAdya.Count();
            }
        }

        public List<CNodo> OrdenaLista(List<CNodo> lista)
        {
            lista = lista.OrderBy(o => o.nombre).ToList();

            return lista;
        }

        public void ordeAdya(CGrafo gCro)
        {
            int i = 1, j = 0, k = 0;
            this.listaNodosOrde.Add(gCro.listaNodos.First());

            while (i < gCro.listaNodos.Count)
            {
                while (j < this.listaNodosOrde.Count)
                {
                    if (gCro.listaNodos.ElementAt(i).numAdya < this.listaNodosOrde.ElementAt(j).numAdya)
                    {
                        k++;
                    }
                    j++;
                }
                this.listaNodosOrde.Insert(k, gCro.listaNodos.ElementAt(i));
                j = 0;
                k = 0;
                i++;
            }
        }

        public void asignaColo(CGrafo gCro)
        {         
            int numLim = 6;

            foreach (CNodo a in this.listaNodosOrde)
            {
                while (a.colCrom == 0)
                {
                    foreach (CNodo b in a.listaNodosAdya)
                    {
                        if (colInt == b.colCrom)
                        {
                            encon = true;
                            numLim = 0;
                            break;

                        }
                        numLim = 0;
                    }
                    if (encon == false)
                    {
                        a.colCrom = colInt;
                        numLim = 0;
                        colInt = 1;

                    }
                    else
                    {
                        numLim = 0;
                        encon = false;
                        colInt++;

                    }
                }
               

            }
        }

        public bool comprueba(List<CNodo> lsNo)
        {
            int numLim = 0;

            foreach (CNodo b in lsNo)
            {
                if (colInt == b.colCrom)
                {
                    encon = true;
                    numLim = 0;
                    break;

                }
                numLim = 0;
            }

            return encon;
        }

        public int numCromGra(CGrafo gCro)
        {
            int num = 0;

            foreach(CNodo a in gCro.listaNodos)
            {
                if(a.colCrom > num)
                {
                    num = a.colCrom;
                }
            }

            return num;
        }


    }
}
