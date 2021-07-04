using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorFiguras1
{
    class Kruskal
    {
        CGrafo grKr;
        CNodo noRa;
        
        int p = 0;
        CArista ari;
        bool bandCic = false;
        public CGrafo grafoFin = new CGrafo();
        List<CArista> arisDes;


        public void asignaGrafo(CGrafo g, CNodo n)
        {
            grKr = g;
            noRa = n;


            arisDes = new List<CArista>();
            cromatico cr = new cromatico();
            cr.buscaAdy(grKr, 0);
            int p = 0;
            foreach(CNodo a in g.listaNodos)
            {
                grafoFin.listaNodos.Add(a);
                grafoFin.listaNodos.ElementAt(a.pos - 1).listaNodosAdya.Clear();
            }
        }

        public void buscaArbol(CGrafo g)
        {
            int menor = 99999;
            int valorNod = 0;
            bool bandMini = false;

            p = 0;

            foreach (CArista a in g.listaArista)
            {
                valorNod = Convert.ToInt32(a.nombre);
                p = 0;
                if(valorNod <= menor)
                {

                    p = 0;
                    foreach (CArista b in grafoFin.listaArista)
                    {
                        p = 0;
                        if (a.puesta == false)
                        {
                            p = 0;
                            bandMini = false;
                        }
                        else
                            bandMini = true;


                    }

                    if (bandMini == false)
                    {
                        p = 0;
                        menor = valorNod;
                        ari = a;
                    }

                    bandMini = false;
                }

            }

            p = 0;
            ari.puesta = true;
            pruebaCiclo(ari);

        }

        public void pruebaCiclo(CArista a)
        {
            CArista arista = new CArista(a.origen, a.destino,Convert.ToSingle(a.nombre));
            grafoFin.listaArista.Add(arista);


            p = 0;
            BusEnPro bn = new BusEnPro();
            cromatico cr = new cromatico();
            cr.buscaAdy(grafoFin, 0);
            p = 0;
            foreach(CNodo de in grafoFin.listaNodos)
            {
                de.visitado = false;
            }
            bn.buscaNodosCa(grafoFin, noRa);
            bandCic = hayCiclo(grafoFin);
            p= 0;
            if(bandCic == true)
            {
                p = 0;
                grafoFin.listaArista.Remove(arista);
                p = 0;
                arisDes.Add(arista);
                p = 0;

            }
            
            bandCic = false;
            if (grafoFin.listaArista.Count < grafoFin.listaNodos.Count - 1)
            {
                p = 0;
                buscaArbol(grKr);
            }
                


        }

        public bool hayCiclo(CGrafo g)
        {
            p = 0;
            foreach (CNodo s in g.listaNodos)
            {
                foreach (CNodo u in s.listaNodosAdya)
                {
                    if (s.nivelBEP + 1 < u.nivelBEP)
                    {
                        p = 0;
                        bandCic = true;
                    }
                }
            }


                return bandCic;
        }
        
    }
}
