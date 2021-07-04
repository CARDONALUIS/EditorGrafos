using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorFiguras1
{
    class BusEnAm
    {
        float numAris = 1;
        int p = 0;
        int nivel = 1;
        public int arbol = 1;
        int index = 0;
        int nivelCom = 1;

        public void buscaNodosCa(CGrafo gra, CNodo r)
        {

            p = 0;
            arbol = r.arbol;

            if (r.niveCompl == false)
            {
                foreach (CNodo a in gra.listaNodos)
                {
                    if (a == r)
                    {

                        nivel = a.nivelBEP;
                        r.visitado = true;
                        
                        asignaVisi(gra, a);
                        a.niveCompl = true;

                        p = 0;
                        foreach (CNodo b in a.listaNodosAdya)
                        {
                           p = 0;
                            b.visitado = true;
                            asignaVisi(gra, b);
                            
                           
                        }
                        foreach(CNodo c in a.listaNodosAdya)
                        {
                            p = 0;
                            buscaNodosCa(gra, c);

                        }
                        break;
                        
                    }

                }
            }

        }

        public void asignaVisi(CGrafo gra, CNodo r)
        {
            p = 0;
            index = 0;

            foreach (CNodo a in r.listaNodosAdya)
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
                    asignaVisi(gra, r);

                }
                index++;
            }

            int v = 0;
        }
    }
}
