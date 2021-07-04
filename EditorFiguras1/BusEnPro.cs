using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorFiguras1
{
    class BusEnPro
    {
        float numAris = 1;
        int p = 0;
        int nivel = 1;
        int arbol = 1;
        int index = 0;

        public void buscaNodosCa(CGrafo gra, CNodo r)
        {

           p = 0;
            foreach(CNodo a in gra.listaNodos)
            {
                if(a == r)
                {
                    nivel = 1;
                    r.visitado = true;
                    p = 0;
                    asignaVisi(gra,r);
                    break;
                }

            }

            foreach(CNodo b in gra.listaNodos)
            {

                if(b.visitado == false)
                { 
                    nivel = 1;
                    arbol++;
                    b.arbol = arbol;
                    b.nivelBEP = nivel;
                    p = 0;
                    buscaNodosCa(gra, b);
                    break;
                }
            }
        }

        public void asignaVisi(CGrafo gra, CNodo r)
        {
            p = 0;
            index = 0;

            foreach(CNodo a in r.listaNodosAdya)
            {
                p = 0;
                nivel = r.nivelBEP;
                
                if (a.visitado == true)
                {
                    p = 0;
                    
                    
                }
                else//decencientes directos
                {
                    nivel++;
                    CArista ar = new CArista(r, a, numAris);
                    numAris++;
                    gra.listaAristaPro.Add(ar);
                    a.visitado = true;
                    a.nivelBEP = nivel;
                    a.arbol = arbol;
                    p = 0;
                    asignaVisi(gra, a);
                    
                }
                index++;
            }

            int v = 0;
        }
    }
}
