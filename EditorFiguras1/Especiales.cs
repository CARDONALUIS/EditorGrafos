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
    public class Especiales
    {
        public CGrafo creaK(CGrafo k)
        {
            CNodo nodo2, nodo3, nodo4, nodo5, nodoIni, nodo6, nodo7;
            CArista arista2, arista3;

            k.listaNodos.Clear();
            k.listaArista.Clear();
            CNodo.c = 'A';
            CArista.c = '1';


            /*
             * Grafo K1
             * */
            nodoIni = new CNodo(100, 200, 50);
            k.listaNodos.Add(nodoIni);
            /*
             * Grafo K2
             * */
            nodoIni = new CNodo(200, 200, 50);
            k.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(300, 200, 50);
            k.listaNodos.Add(nodo2);
            arista2 = new CArista(nodoIni, nodo2);
            k.listaArista.Add(arista2);
            /*
             * Grafo K3
             * */
            nodoIni = new CNodo(400, 200, 50);
            k.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(500, 200, 50);
            k.listaNodos.Add(nodo2);
            arista2 = new CArista(nodoIni, nodo2);
            k.listaArista.Add(arista2);
            nodo3 = new CNodo(450, 100, 50);
            k.listaNodos.Add(nodo3);
            arista2 = new CArista(nodo2, nodo3);
            k.listaArista.Add(arista2);
            arista3 = new CArista(nodoIni, nodo3);
            k.listaArista.Add(arista3);
            /*
             * Grafo K4
             * */
            nodoIni = new CNodo(600, 200, 50);
            k.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(750, 200, 50);
            k.listaNodos.Add(nodo2);
            arista2 = new CArista(nodoIni, nodo2);
            k.listaArista.Add(arista2);
            nodo3 = new CNodo(750, 100, 50);
            k.listaNodos.Add(nodo3);
            arista2 = new CArista(nodo2, nodo3);
            k.listaArista.Add(arista2);
            nodo4 = new CNodo(600, 100, 50);
            k.listaNodos.Add(nodo4);
            arista2 = new CArista(nodo3, nodo4);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo4);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo3);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo4);
            k.listaArista.Add(arista2);
            /*
             * Grafo K5
             * */
            nodoIni = new CNodo(850, 150, 50);
            k.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(1000, 150, 50);
            k.listaNodos.Add(nodo2);
            arista2 = new CArista(nodoIni, nodo2);
            k.listaArista.Add(arista2);
            nodo3 = new CNodo(850, 250, 50);
            k.listaNodos.Add(nodo3);
            nodo4 = new CNodo(1000, 250, 50);
            k.listaNodos.Add(nodo4);
            arista2 = new CArista(nodo3, nodo4);
            k.listaArista.Add(arista2);
            nodo5 = new CNodo(925, 75, 50);
            k.listaNodos.Add(nodo5);
            arista2 = new CArista(nodoIni, nodo3);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo4);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo5);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo5);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodo5);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo5);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo4);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo3);
            k.listaArista.Add(arista2);
            /*
             * Grafo K6
             * */
            nodoIni = new CNodo(100, 450, 50);
            k.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(250, 450, 50);
            k.listaNodos.Add(nodo2);
            arista2 = new CArista(nodoIni, nodo2);
            k.listaArista.Add(arista2);
            nodo3 = new CNodo(100, 550, 50);
            k.listaNodos.Add(nodo3);
            nodo4 = new CNodo(250, 550, 50);
            k.listaNodos.Add(nodo4);
            arista2 = new CArista(nodo3, nodo4);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo3);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo4);
            k.listaArista.Add(arista2);
            nodo5 = new CNodo(175, 400, 50);
            k.listaNodos.Add(nodo5);
            nodo6 = new CNodo(175, 600, 50);
            k.listaNodos.Add(nodo6);
            arista2 = new CArista(nodo2, nodo6);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo6);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodo5);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo5);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo6, nodo5);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo6);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodo6);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodo2);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodoIni);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo5);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo5);
            k.listaArista.Add(arista2);
            /*
            * Grafo K7
            * */
            nodoIni = new CNodo(450, 400, 50);
            k.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(650, 400, 50);
            k.listaNodos.Add(nodo2);
            nodo3 = new CNodo(550, 350, 50);
            k.listaNodos.Add(nodo3);
            nodo4 = new CNodo(400, 500, 50);
            k.listaNodos.Add(nodo4);
            nodo5 = new CNodo(700, 500, 50);
            k.listaNodos.Add(nodo5);
            nodo6 = new CNodo(450, 600, 50);
            k.listaNodos.Add(nodo6);
            nodo7 = new CNodo(650, 600, 50);
            k.listaNodos.Add(nodo7);

            arista2 = new CArista(nodoIni, nodo3);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo2);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo5);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo7);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo6);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo4);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo3);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo5);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo7);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo6);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo4);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodo4);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodo6);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodo7);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodo5);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo5);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo7);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo6);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo6);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo7);
            k.listaArista.Add(arista2);
            arista2 = new CArista(nodo6, nodo7);
            k.listaArista.Add(arista2);

            return k;
        }


        public CGrafo creaNreg(CGrafo nReg)
        {
            nReg.listaNodos.Clear();
            nReg.listaArista.Clear();
            CNodo.c = 'A';
            CArista.c = '1';


            CNodo nodo2, nodo3, nodo4, nodo5, nodoIni, nodo6;
            CArista arista2;



            //  Grafo 2 regular

            ////////
            nodoIni = new CNodo(200, 200, 50);
            nReg.listaNodos.Add(nodoIni);
            nodo3 = new CNodo(300, 100, 50);
            nReg.listaNodos.Add(nodo3);
            arista2 = new CArista(nodoIni, nodo3);
            nReg.listaArista.Add(arista2);
            nodo2 = new CNodo(400, 100, 50);
            nReg.listaNodos.Add(nodo2);
            arista2 = new CArista(nodo3, nodo2);
            nReg.listaArista.Add(arista2);
            nodo3 = new CNodo(500, 200, 50);
            nReg.listaNodos.Add(nodo3);
            arista2 = new CArista(nodo2, nodo3);
            nReg.listaArista.Add(arista2);
            nodo2 = new CNodo(350, 300, 50);
            nReg.listaNodos.Add(nodo2);
            arista2 = new CArista(nodo3, nodo2);
            nReg.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodoIni);
            nReg.listaArista.Add(arista2);
            ///////////

            //  Grafo 3 regular

            nodo2 = new CNodo(750, 100, 50);
            nReg.listaNodos.Add(nodo2);
            nodo3 = new CNodo(750, 200, 50);
            nReg.listaNodos.Add(nodo3);
            arista2 = new CArista(nodo2, nodo3);
            nReg.listaArista.Add(arista2);
            nodo4 = new CNodo(670, 300, 50);
            nReg.listaNodos.Add(nodo4);
            arista2 = new CArista(nodo4, nodo2);
            nReg.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo3);
            nReg.listaArista.Add(arista2);
            nodo5 = new CNodo(830, 300, 50);
            nReg.listaNodos.Add(nodo5);
            arista2 = new CArista(nodo5, nodo2);
            nReg.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo3);
            nReg.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo5);
            nReg.listaArista.Add(arista2);
            ///

            //  Grafo 4 regular

            nodo2 = new CNodo(300, 500, 50);
            nReg.listaNodos.Add(nodo2);
            nodo3 = new CNodo(400, 400, 50);
            nReg.listaNodos.Add(nodo3);
            arista2 = new CArista(nodo2, nodo3);
            nReg.listaArista.Add(arista2);
            nodo4 = new CNodo(500, 400, 50);
            nReg.listaNodos.Add(nodo4);
            arista2 = new CArista(nodo3, nodo4);
            nReg.listaArista.Add(arista2);
            nodo5 = new CNodo(600, 500, 50);
            nReg.listaNodos.Add(nodo5);
            arista2 = new CArista(nodo5, nodo4);
            nReg.listaArista.Add(arista2);
            nodo6 = new CNodo(450, 600, 50);
            nReg.listaNodos.Add(nodo6);
            arista2 = new CArista(nodo6, nodo5);
            nReg.listaArista.Add(arista2);
            arista2 = new CArista(nodo6, nodo2);
            nReg.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo4);
            nReg.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo5);
            nReg.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodo5);
            nReg.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodo6);
            nReg.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo6);
            nReg.listaArista.Add(arista2);

            return nReg;
        }

        public CGrafo creaCic(CGrafo ciclo)
        {
            ciclo.listaNodos.Clear();
            ciclo.listaArista.Clear();
            CNodo.c = 'A';
            CArista.c = '1';


            CNodo nodo2, nodo3, nodo4, nodo5, nodoIni, nodo6, nodo7;
            CArista arista2;

            //1
            nodoIni = new CNodo(200, 100, 50);
            ciclo.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(150, 200, 50);
            ciclo.listaNodos.Add(nodo2);
            nodo3 = new CNodo(250, 200, 50);
            ciclo.listaNodos.Add(nodo3);
            arista2 = new CArista(nodoIni, nodo2);
            ciclo.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo3);
            ciclo.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo3);
            ciclo.listaArista.Add(arista2);
            //2
            nodoIni = new CNodo(350, 100, 50);
            ciclo.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(550, 100, 50);
            ciclo.listaNodos.Add(nodo2);
            nodo3 = new CNodo(350, 200, 50);
            ciclo.listaNodos.Add(nodo3);
            nodo4 = new CNodo(550, 200, 50);
            ciclo.listaNodos.Add(nodo4);
            arista2 = new CArista(nodoIni, nodo2);
            ciclo.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo4);
            ciclo.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodoIni);
            ciclo.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo3);
            ciclo.listaArista.Add(arista2);
            //3
            nodoIni = new CNodo(650, 150, 50);
            ciclo.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(850, 150, 50);
            ciclo.listaNodos.Add(nodo2);
            nodo3 = new CNodo(700, 250, 50);
            ciclo.listaNodos.Add(nodo3);
            nodo4 = new CNodo(800, 250, 50);
            ciclo.listaNodos.Add(nodo4);
            nodo5 = new CNodo(750, 75, 50);
            ciclo.listaNodos.Add(nodo5);
            arista2 = new CArista(nodoIni, nodo5);
            ciclo.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo3);
            ciclo.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo2);
            ciclo.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo4);
            ciclo.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo3);
            ciclo.listaArista.Add(arista2);
            //4
            nodoIni = new CNodo(950, 200, 50);
            ciclo.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(1050, 100, 50);
            ciclo.listaNodos.Add(nodo2);
            nodo3 = new CNodo(1150, 100, 50);
            ciclo.listaNodos.Add(nodo3);
            nodo4 = new CNodo(1250, 200, 50);
            ciclo.listaNodos.Add(nodo4);
            nodo6 = new CNodo(1050, 300, 50);
            ciclo.listaNodos.Add(nodo6);
            nodo5 = new CNodo(1150, 300, 50);
            ciclo.listaNodos.Add(nodo5);
            arista2 = new CArista(nodoIni, nodo2);
            ciclo.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo6);
            ciclo.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo3);
            ciclo.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodo4);
            ciclo.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo5);
            ciclo.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo6);
            ciclo.listaArista.Add(arista2);
            //5
            nodoIni = new CNodo(100, 600, 50);
            ciclo.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(200, 500, 50);
            ciclo.listaNodos.Add(nodo2);
            nodo3 = new CNodo(300, 500, 50);
            ciclo.listaNodos.Add(nodo3);
            nodo4 = new CNodo(400, 600, 50);
            ciclo.listaNodos.Add(nodo4);
            nodo6 = new CNodo(200, 700, 50);
            ciclo.listaNodos.Add(nodo6);
            nodo5 = new CNodo(300, 700, 50);
            ciclo.listaNodos.Add(nodo5);
            nodo7 = new CNodo(250, 400, 50);
            ciclo.listaNodos.Add(nodo7);
            arista2 = new CArista(nodoIni, nodo2);
            ciclo.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo6);
            ciclo.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodo4);
            ciclo.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo5);
            ciclo.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo6);
            ciclo.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo7);
            ciclo.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodo7);
            ciclo.listaArista.Add(arista2);

            return ciclo;
        }

        public CGrafo creaVolante(CGrafo vol)
        {
            vol.listaNodos.Clear();
            vol.listaArista.Clear();
            CNodo.c = 'A';
            CArista.c = '1';

            CNodo nodo2, nodo3, nodo4, nodo5, nodoIni, nodo6, nodo7, nodo8;
            CArista arista2;

            //w3
            nodoIni = new CNodo(200, 100, 50);
            vol.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(100, 250, 50);
            vol.listaNodos.Add(nodo2);
            nodo3 = new CNodo(300, 250, 50);
            vol.listaNodos.Add(nodo3);
            nodo4 = new CNodo(200, 200, 50);
            vol.listaNodos.Add(nodo4);
            arista2 = new CArista(nodo2, nodoIni);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo3);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodo2);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo4);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodoIni);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo3);
            vol.listaArista.Add(arista2);
            //w4
            nodoIni = new CNodo(450, 100, 50);
            vol.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(650, 100, 50);
            vol.listaNodos.Add(nodo2);
            nodo3 = new CNodo(450, 250, 50);
            vol.listaNodos.Add(nodo3);
            nodo4 = new CNodo(650, 250, 50);
            vol.listaNodos.Add(nodo4);
            nodo5 = new CNodo(550, 175, 50);
            vol.listaNodos.Add(nodo5);
            arista2 = new CArista(nodoIni, nodo2);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo5);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo3);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo5);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo4);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo3);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo4);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodo4);
            vol.listaArista.Add(arista2);
            //w5
            nodoIni = new CNodo(850, 150, 50);
            vol.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(1050, 150, 50);
            vol.listaNodos.Add(nodo2);
            nodo3 = new CNodo(850, 300, 50);
            vol.listaNodos.Add(nodo3);
            nodo4 = new CNodo(1050, 300, 50);
            vol.listaNodos.Add(nodo4);
            nodo5 = new CNodo(950, 225, 50);
            vol.listaNodos.Add(nodo5);
            nodo6 = new CNodo(950, 75, 50);
            vol.listaNodos.Add(nodo6);
            arista2 = new CArista(nodoIni, nodo6);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo3);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodo4);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo2);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo6);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo4);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo3);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodoIni);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo6);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo2);
            vol.listaArista.Add(arista2);
            //W6
            nodoIni = new CNodo(150, 400, 50);
            vol.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(350, 400, 50);
            vol.listaNodos.Add(nodo2);
            nodo3 = new CNodo(150, 550, 50);
            vol.listaNodos.Add(nodo3);
            nodo4 = new CNodo(350, 550, 50);
            vol.listaNodos.Add(nodo4);
            nodo5 = new CNodo(250, 475, 50);
            vol.listaNodos.Add(nodo5);
            nodo6 = new CNodo(50, 475, 50);
            vol.listaNodos.Add(nodo6);
            nodo7 = new CNodo(450, 475, 50);
            vol.listaNodos.Add(nodo7);
            arista2 = new CArista(nodo6, nodoIni);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo6, nodo3);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo2);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo7);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo7, nodo4);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo3);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo6);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodoIni);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo2);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo7);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo4);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo3);
            vol.listaArista.Add(arista2);
            //w7
            nodoIni = new CNodo(650, 500, 50);
            vol.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(850, 500, 50);
            vol.listaNodos.Add(nodo2);
            nodo3 = new CNodo(650, 650, 50);
            vol.listaNodos.Add(nodo3);
            nodo4 = new CNodo(850, 650, 50);
            vol.listaNodos.Add(nodo4);
            nodo5 = new CNodo(750, 575, 50);
            vol.listaNodos.Add(nodo5);
            nodo6 = new CNodo(550, 575, 50);
            vol.listaNodos.Add(nodo6);
            nodo7 = new CNodo(950, 575, 50);
            vol.listaNodos.Add(nodo7);
            nodo8 = new CNodo(750, 400, 50);
            vol.listaNodos.Add(nodo8);
            arista2 = new CArista(nodo6, nodoIni);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo6, nodo3);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo7);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo7, nodo4);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo3);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo6);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodoIni);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo2);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo7);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo4);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo3);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo8);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo8);
            vol.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo8);
            vol.listaArista.Add(arista2);

            return vol;

        }

        public CGrafo creaQ(CGrafo Q)
        {
            Q.listaNodos.Clear();
            Q.listaArista.Clear();
            CNodo.c = 'A';
            CArista.c = '1';

            CNodo nodo2, nodo3, nodo4, nodo5, nodoIni, nodo6, nodo7, nodo8, nodo9, nodo10, nodo11, nodo12, nodo13, nodo14, nodo15, nodo16;
            CArista arista2;

            //Q1
            nodoIni = new CNodo(100, 100, 50, "0");
            Q.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(200, 100, 50, "1");
            Q.listaNodos.Add(nodo2);
            arista2 = new CArista(nodoIni, nodo2);
            Q.listaArista.Add(arista2);
            //Q2
            nodoIni = new CNodo(300, 200, 50, "10");
            Q.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(400, 200, 50, "11");
            Q.listaNodos.Add(nodo2);
            nodo3 = new CNodo(400, 100, 50, "01");
            Q.listaNodos.Add(nodo3);
            nodo4 = new CNodo(300, 100, 50, "00");
            Q.listaNodos.Add(nodo4);
            arista2 = new CArista(nodoIni, nodo2);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo3);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo4);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo3);
            Q.listaArista.Add(arista2);
            //Q3
            nodoIni = new CNodo(150, 550, 50, "010");
            Q.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(250, 550, 50, "011");
            Q.listaNodos.Add(nodo2);
            nodo3 = new CNodo(250, 450, 50, "111");
            Q.listaNodos.Add(nodo3);
            nodo4 = new CNodo(150, 450, 50, "110");
            Q.listaNodos.Add(nodo4);
            nodo5 = new CNodo(50, 350, 50, "100");
            Q.listaNodos.Add(nodo5);
            nodo6 = new CNodo(350, 350, 50, "101");
            Q.listaNodos.Add(nodo6);
            nodo7 = new CNodo(350, 650, 50, "001");
            Q.listaNodos.Add(nodo7);
            nodo8 = new CNodo(50, 650, 50, "000");
            Q.listaNodos.Add(nodo8);
            arista2 = new CArista(nodoIni, nodo2);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodo3);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodoIni, nodo4);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo3);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo6);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo8);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo4);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo8, nodoIni);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo8, nodo7);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo7, nodo6);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo7, nodo2);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo6, nodo3);
            Q.listaArista.Add(arista2);
            //Q4(c1)
            nodoIni = new CNodo(500, 500, 50, "0100");
            Q.listaNodos.Add(nodoIni);
            nodo2 = new CNodo(700, 500, 50, "0101");
            Q.listaNodos.Add(nodo2);
            nodo3 = new CNodo(700, 300, 50, "1101");
            Q.listaNodos.Add(nodo3);
            nodo4 = new CNodo(500, 300, 50, "1100");
            Q.listaNodos.Add(nodo4);
            //c2
            nodo5 = new CNodo(650, 350, 50, "0110");
            Q.listaNodos.Add(nodo5);
            nodo6 = new CNodo(850, 350, 50, "0111");
            Q.listaNodos.Add(nodo6);
            nodo8 = new CNodo(650, 150, 50, "1110");
            Q.listaNodos.Add(nodo8);
            nodo7 = new CNodo(850, 150, 50, "1111");
            Q.listaNodos.Add(nodo7);
            //c3
            nodo9 = new CNodo(800, 500, 50, "0010");
            Q.listaNodos.Add(nodo9);
            nodo10 = new CNodo(1000, 500, 50, "0011");
            Q.listaNodos.Add(nodo10);
            nodo11 = new CNodo(1000, 300, 50, "1011");
            Q.listaNodos.Add(nodo11);
            nodo12 = new CNodo(800, 300, 50, "1010");
            Q.listaNodos.Add(nodo12);
            //c4
            nodo13 = new CNodo(650, 650, 50, "0000");
            Q.listaNodos.Add(nodo13);
            nodo14 = new CNodo(850, 650, 50, "0001");
            Q.listaNodos.Add(nodo14);
            nodo15 = new CNodo(850, 450, 50, "1001");
            Q.listaNodos.Add(nodo15);
            nodo16 = new CNodo(650, 450, 50, "1000");
            Q.listaNodos.Add(nodo16);
            //c1a
            arista2 = new CArista(nodoIni, nodo4);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo3);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo3, nodo2);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo2, nodoIni);
            Q.listaArista.Add(arista2);
            //c2a
            arista2 = new CArista(nodo5, nodo8);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo8, nodo7);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo7, nodo6);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo6, nodo5);
            Q.listaArista.Add(arista2);
            //c3a
            arista2 = new CArista(nodo9, nodo12);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo12, nodo11);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo11, nodo10);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo10, nodo9);
            Q.listaArista.Add(arista2);
            //c4a
            arista2 = new CArista(nodo13, nodo16);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo16, nodo15);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo15, nodo14);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo14, nodo13);
            Q.listaArista.Add(arista2);
            //cfuera
            arista2 = new CArista(nodo4, nodo8);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo4, nodo16);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo8, nodo12);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo7, nodo3);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo7, nodo11);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo11, nodo15);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo10, nodo6);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo10, nodo14);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo6, nodo5);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo14, nodo2);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo13, nodo9);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo13, nodoIni);
            Q.listaArista.Add(arista2);
            //cDentro
            arista2 = new CArista(nodo5, nodoIni);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo5, nodo9);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo6, nodo2);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo16, nodo12);
            Q.listaArista.Add(arista2);
            arista2 = new CArista(nodo15, nodo3);
            Q.listaArista.Add(arista2);

            return Q;
        }
        
    }
}
