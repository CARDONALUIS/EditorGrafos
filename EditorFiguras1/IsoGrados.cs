using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorFiguras1
{
    public partial class IsoGrados : Form
    {
        int i = 0, contNodo = 0;
        public List<int> gradosG1;
        public List<int> gradosG2;
        public List<int> numMat1;
        public List<int> numMat2;
        public List<int> conver;
        CGrafo grafoS;
        CGrafo grafoP;
        int[,] MG1, MI1;
        int[,] MG2, MI2;
        int[] ordBiy, ordBiyAris;
        bool bandIgual = false;
        bool isomorfismo, isoInci = false;
        public int numNEli = 0;
        public bool hacerInsi = true;


        /*
         * El constructor inicializa algunas variables y tambien datasgridview
         */
        public IsoGrados()
        {
            InitializeComponent();
            gradosG1 = new List<int>();
            gradosG2 = new List<int>();
            numMat1 = new List<int>();
            numMat2 = new List<int>();
            conver = new List<int>();


            DataGridViewTextBoxColumn Columna1 = new DataGridViewTextBoxColumn();
            Columna1.HeaderText = "Nodo";
            GradosGP.Columns.Add(Columna1);

            DataGridViewTextBoxColumn Columna2 = new DataGridViewTextBoxColumn();
            Columna2.HeaderText = "Grados";
            GradosGP.Columns.Add(Columna2);

            DataGridViewTextBoxColumn Columna3 = new DataGridViewTextBoxColumn();
            Columna3.HeaderText = "Nodo";
            GradosGS.Columns.Add(Columna3);

            DataGridViewTextBoxColumn Columna4 = new DataGridViewTextBoxColumn();
            Columna4.HeaderText = "Grados";
            GradosGS.Columns.Add(Columna4);


            DataGridViewTextBoxColumn Columna5 = new DataGridViewTextBoxColumn();
            Columna5.HeaderText = "";
            MatAdyaG1.Columns.Add(Columna5);

            DataGridViewTextBoxColumn Columna7 = new DataGridViewTextBoxColumn();
            Columna7.HeaderText = "";
            MatAdyaG2.Columns.Add(Columna7);

            DataGridViewTextBoxColumn Columna8 = new DataGridViewTextBoxColumn();
            Columna8.HeaderText = "Antes";
            tablaBiye.Columns.Add(Columna8);
            //.Columns.Add(Columna8);

            DataGridViewTextBoxColumn Columna9 = new DataGridViewTextBoxColumn();
            Columna9.HeaderText = "Despues";
            tablaBiye.Columns.Add(Columna9);

            DataGridViewTextBoxColumn Columna10 = new DataGridViewTextBoxColumn();
            Columna10.HeaderText = "";
            MatIns1.Columns.Add(Columna10);

            DataGridViewTextBoxColumn Columna11 = new DataGridViewTextBoxColumn();
            Columna11.HeaderText = "";
            MatIns2.Columns.Add(Columna11);

            DataGridViewTextBoxColumn Columna12 = new DataGridViewTextBoxColumn();
            Columna12.HeaderText = "Antes";
            tablaBiyeAris.Columns.Add(Columna12);
            //.Columns.Add(Columna8);

            DataGridViewTextBoxColumn Columna13 = new DataGridViewTextBoxColumn();
            Columna13.HeaderText = "Despues";
            tablaBiyeAris.Columns.Add(Columna13);


        }


        //Metodo donde se asignan a las diferentes datagridview la informacion que deben de tener
        public void asignaValorGraIso(CGrafo g1, CGrafo g2)
        {
            ///////Matriz de adyacencia
            MG1 = new int[g1.listaNodos.Count, g1.listaNodos.Count];
            MG2 = new int[g2.listaNodos.Count, g2.listaNodos.Count];
            MI1 = new int[g1.listaNodos.Count, g1.listaArista.Count];
            MI2 = new int[g2.listaNodos.Count, g2.listaArista.Count];
            grafoP = g1;
            grafoS = g2;
            ordBiy = new int[grafoP.listaArista.Count];
            int i = 1;
            int contRen = 0, contCol = 1;
            char c = 'A';
            int contOri = 0, contDes = 1;
            int conMulti = 1;
            int  contOri1 = 0, contOri2 = 0, contArista = 0;
            char c1 = 'A', c2 = '1';

            int f = 0, co = 0, z = 0 ;

            foreach (CNodo a in g1.listaNodos)//Columnas Grafo1 Adya
            {
                DataGridViewTextBoxColumn Columna1 = new DataGridViewTextBoxColumn();
                Columna1.HeaderText = a.nombre;
                MatAdyaG1.Columns.Add(Columna1);
            }

            foreach (CNodo a in g1.listaNodos)//Filas Grafo1 Adya
            {
                i = MatAdyaG1.Rows.Add();
                MatAdyaG1.Rows[i].Cells[0].Value = a.nombre;  //a.origen.nombre;
            }

            foreach (CNodo a in g2.listaNodos)//Columnas Grafo2 adya
            {
                DataGridViewTextBoxColumn Columna1 = new DataGridViewTextBoxColumn();
                Columna1.HeaderText = a.nombre;
                MatAdyaG2.Columns.Add(Columna1);
            }
            foreach (CNodo a in g2.listaNodos)//Filas Grafo 2 adya
            {
                i = MatAdyaG2.Rows.Add();
                MatAdyaG2.Rows[i].Cells[0].Value = a.nombre;  //a.origen.nombre;


            }

            if (hacerInsi == true)
            {
                foreach (CArista a in g1.listaArista)//Columnas 
                {
                    DataGridViewTextBoxColumn Columna1 = new DataGridViewTextBoxColumn();
                    Columna1.HeaderText = a.nombre;
                    MatIns1.Columns.Add(Columna1);

                    DataGridViewTextBoxColumn Columna2 = new DataGridViewTextBoxColumn();
                    Columna2.HeaderText = a.nombre;
                    MatIns2.Columns.Add(Columna2);
                    contArista++;
                }
                int contArista2 = contArista;

                foreach (CNodo a in g1.listaNodos)//Filas
                {
                    i = MatIns1.Rows.Add();
                    MatIns1.Rows[i].Cells[0].Value = a.nombre;  //a.origen.nombre;

                    i = MatIns2.Rows.Add();
                    MatIns2.Rows[i].Cells[0].Value = a.nombre;

                    //i++;
                }

                foreach (CNodo a in g1.listaNodos)//Rellena de ceros las matris para inicializarla
                {
                    foreach (CArista b in g1.listaArista)
                    {

                        MatIns1.Rows[contRen].Cells[contCol].Value = "0";
                        MatIns2.Rows[contRen].Cells[contCol].Value = "0";

                        contCol++;
                    }
                    contCol = 1;
                    contRen++;
                }



                contRen = 0;
                contCol = 1;

                z = 0;
                //Asigna a matriz de incidencia
                foreach (CArista a in g1.listaArista)//Asigna valores de relaciones de los nodos
                {
                    while (a.origen.nombre != c1.ToString())
                    {

                        contOri1++;
                        c1++;
                    }

                    c1 = 'A';

                    while (a.destino.nombre != c1.ToString())
                    {
                        contOri2++;
                        c1++;
                    }
                    c1 = 'A';

                    while (a.nombre != c2.ToString())
                    {
                        contDes++;
                        c2++;
                    }
                    c2 = '1';


                    MatIns1.Rows[contOri1].Cells[contDes].Value = "1";
                    if (contOri2 <= contArista)
                        MatIns1.Rows[contOri2].Cells[contDes].Value = "1";




                    contOri1 = 0;
                    contOri2 = 0;
                    contDes = 1;
                }

                f = 0;
                co = 0;

                for (int fila = 0; fila < MatIns1.Rows.Count - 1; fila++)//Saca los valores de la matriz de adyacencia 1
                {

                    for (int col = 0; col < MatIns1.Rows[fila].Cells.Count; col++)
                    {
                        if (col != 0)
                        {
                            string valor = MatIns1.Rows[fila].Cells[col].Value.ToString();
                            MI1[f, co] = Convert.ToInt32(valor);
                            co++;
                        }

                    }
                    co = 0;
                    f++;
                }


                contOri1 = 0; contOri2 = 0; contArista = 0;
                c1 = 'A'; c2 = '1';

                //Asigna a matriz de incidencia 2

                foreach (CArista a in g2.listaArista)//Asigna valores de relaciones de los nodos
                {

                    while (a.origen.nombre != c1.ToString())
                    {

                        contOri1++;
                        c1++;
                    }

                    c1 = 'A';

                    while (a.destino.nombre != c1.ToString())
                    {
                        contOri2++;
                        c1++;
                    }
                    c1 = 'A';

                    while (a.nombre != c2.ToString())
                    {
                        contDes++;
                        c2++;
                    }
                    c2 = '1';





                    MatIns2.Rows[contOri1].Cells[contDes].Value = "1";
                    if (contOri2 <= contArista2)
                        MatIns2.Rows[contOri2].Cells[contDes].Value = "1";




                    contOri1 = 0;
                    contOri2 = 0;
                    contDes = 1;
                }

                contOri1 = 0; contOri2 = 0; contArista = 0;
                c1 = 'A'; c2 = '1';


                //sacamos los valores del data gridview/////////////////

                //Matriz 2 Incis

                f = 0; co = 0;
                int e = 0;
                for (int fila = 0; fila < MatIns2.Rows.Count - 1; fila++)//Saca los valores de la matriz de adyacencia 1
                {

                    for (int col = 0; col < MatIns2.Rows[fila].Cells.Count; col++)
                    {
                        if (col != 0)
                        {

                            string valor = MatIns2.Rows[fila].Cells[col].Value.ToString();
                            MI2[f, co] = Convert.ToInt32(valor);
                            co++;
                            e = 0;
                        }

                    }
                    co = 0;
                    f++;
                }
            }

            //Asigna sus valores de la matris 1 adyacencia
            contOri = 0;
            contDes = 1;

            foreach (CNodo a in g1.listaNodos)//Rellena de ceros las matris para inicializarla
            {
                foreach (CNodo b in g1.listaNodos)
                {
                    MatAdyaG1.Rows[contRen].Cells[contCol].Value = "0";
                    contCol++;
                }
                contCol = 1;
                contRen++;
            }


            int s = 0;
            foreach (CArista a in g1.listaArista)//Asigna valores de relaciones de los nodos
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

                int z1 = 0;
                MatAdyaG1.Rows[contOri].Cells[contDes].Value = conMulti.ToString();//////////
                MatAdyaG1.Rows[contDes - 1].Cells[contOri + 1].Value = conMulti.ToString();
                conMulti++;

                contOri = 0;
                contDes = 1;
                conMulti = 1;
            }

            

            f = 0;
            co = 0;

            for (int fila = 0; fila < MatAdyaG1.Rows.Count - 1; fila++)//Saca los valores de la matriz de adyacencia 1
            {
               
                for (int col = 0; col < MatAdyaG1.Rows[fila].Cells.Count; col++)
                {
                    if(col != 0)
                    {
                        string valor = MatAdyaG1.Rows[fila].Cells[col].Value.ToString();
                        MG1[f,co] = Convert.ToInt32(valor);
                        co++;
                    }
                    
                }
                co = 0;
                f++;
            }
            //////////////////////////////////
           
            contRen = 0;
            contCol = 1;

            foreach (CNodo a in g2.listaNodos)//Rellena de ceros las matris para inicializarla
            {
                foreach (CNodo b in g2.listaNodos)
                {
                    MatAdyaG2.Rows[contRen].Cells[contCol].Value = "0";
                    contCol++;
                }
                contCol = 1;
                contRen++;
            }


            if (hacerInsi == false)
            {
                foreach (CArista a in g1.listaArista)//Asigna valores de relaciones de los nodos
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

                    MatAdyaG2.Rows[contOri].Cells[contDes].Value = conMulti.ToString();
                    MatAdyaG2.Rows[contDes - 1].Cells[contOri + 1].Value = conMulti.ToString();
                    conMulti++;

                    contOri = 0;
                    contDes = 1;
                    conMulti = 1;
                }
            }
            else
            {
                foreach (CArista a in g2.listaArista)//Asigna valores de relaciones de los nodos
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


                    MatAdyaG2.Rows[contOri].Cells[contDes].Value = conMulti.ToString();
                    MatAdyaG2.Rows[contDes - 1].Cells[contOri + 1].Value = conMulti.ToString();
                    conMulti++;


                    contOri = 0;
                    contDes = 1;
                    conMulti = 1;
                }
            }


            f = 0;
            co = 0;

            for (int fila = 0; fila < MatAdyaG2.Rows.Count - 1; fila++)//Saca los valores de la matriz de adyacencia 2
            {
                for (int col = 0; col < MatAdyaG2.Rows[fila].Cells.Count; col++)
                {
                    if (col != 0)
                    {
                        string valor = MatAdyaG2.Rows[fila].Cells[col].Value.ToString();
                        MG2[f, co] = Convert.ToInt32(valor);
                        co++;
                    }

                }
                co = 0;
                f++;
            }


            
            ////////// Grados
            foreach (CNodo a in g1.listaNodos)
            {
                foreach (CArista b in g1.listaArista)
                {
                    if (a.nombre == b.origen.nombre)
                    {
                        contNodo++;
                    }


                    if (a.nombre == b.destino.nombre)
                    {
                        contNodo++;
                    }

                }
                i = GradosGP.Rows.Add();
                GradosGP.Rows[i].Cells[0].Value = a.nombre;
                GradosGP.Rows[i].Cells[1].Value = contNodo;
                gradosG1.Add(contNodo);
                contNodo = 0;
            }
            
            foreach (CNodo a in g2.listaNodos)
            {
                foreach (CArista b in g2.listaArista)
                {
                    if (a.nombre == b.origen.nombre)
                    {
                        contNodo++;
                    }


                    if (a.nombre == b.destino.nombre)
                    {
                        contNodo++;
                    }

                }
                i = GradosGS.Rows.Add();
                GradosGS.Rows[i].Cells[0].Value = a.nombre;
                GradosGS.Rows[i].Cells[1].Value = contNodo;
                gradosG2.Add(contNodo);
                contNodo = 0;
            }


            //isoInci=  FuerzaBrutaB(MI1, MI2, grafoP.listaArista.Count);
            isomorfismo = FuerzaBruta(MG1, MG2, grafoP.listaNodos.Count);

            if (isomorfismo == true || isoInci == true)
            {
                if (isoInci == false)
                {
                    MessageBox.Show("Mi algoritmo tuvó problemas para encontrar la convinacion de matriz de incidencia con sus grafos, " +
                        "pero concluyo por matriz adyacencia que si hay convinacion pol lo tanto si es isomorfico");
                    if(hacerInsi == false)
                    {
                        MessageBox.Show("Tu grafo resulto ser isomorfo al grafo que elegiste por lo tanto no es plano");
                    }
                }
                else
                    MessageBox.Show("Es Isomorfo");
            }
            else
                MessageBox.Show("No es isomorfo");

            

           
        }

        //Este metodo es el evento en el cual ya podremos checar como quearian las biyecciones
        private void button1_Click(object sender, EventArgs e)
        {
            if (isomorfismo == true)
            {
                int contRen = 0, contCol = 1, conRenM = 0, contColM = 0;

                for (int i = 0; i < 1; i++)
                {
                    DataGridViewTextBoxColumn Columna1R = new DataGridViewTextBoxColumn();
                    Columna1R.HeaderText = "";
                    MatrizResu.Columns.Add(Columna1R);

                    DataGridViewTextBoxColumn Columna2R = new DataGridViewTextBoxColumn();
                    Columna2R.HeaderText = "";
                    MatResAr.Columns.Add(Columna2R);
                }

                if (bandIgual == false)
                {
                    //aqui acomodo mis valores de matriz adyacente resultante de columnas
                    for (int i = 0; i < grafoP.listaNodos.Count; i++)
                    {
                        DataGridViewTextBoxColumn Columna1R = new DataGridViewTextBoxColumn();
                        Columna1R.HeaderText = (Convert.ToChar(ordBiy[i] + 65)).ToString();//nom.ToString();// (nom + (char)17).ToString();
                        MatrizResu.Columns.Add(Columna1R);
                    }

                    //aqui acomodo mis valores de matriz adyacente resultante de renglones
                    for (int i = 0; i < grafoP.listaNodos.Count; i++)
                    {
                        i = MatrizResu.Rows.Add();
                        MatrizResu.Rows[i].Cells[0].Value = (Convert.ToChar(ordBiy[i] + 65)).ToString();
                    }

                    //
                    if(hacerInsi == true)
                    foreach (CNodo a in grafoP.listaNodos)//biyeccion vertices
                    {
                        i = tablaBiye.Rows.Add();
                        tablaBiye.Rows[i].Cells[0].Value = a.nombre;
                        tablaBiye.Rows[i].Cells[1].Value = (Convert.ToChar(ordBiy[i] + 65)).ToString();

                    }

                  
                   

                    //aqui acomodo mis valores de matriz incidencia resultante de renglones
                    for (int i = 0; i < grafoP.listaNodos.Count; i++)
                    {
                        //char nom = (Convert.ToChar(ordBiy[i]));
                        i = MatResAr.Rows.Add();
                        MatResAr.Rows[i].Cells[0].Value = (Convert.ToChar(ordBiy[i] + 65)).ToString();
                    }

                    if(isoInci == false)
                    {
                        foreach (CArista a in grafoP.listaArista)//biyeccion aristas
                        {
                            int t = 0;
                            i = tablaBiyeAris.Rows.Add();
                            tablaBiyeAris.Rows[i].Cells[0].Value = a.nombre;
                            tablaBiyeAris.Rows[i].Cells[1].Value = 404; //(Convert.ToChar(ordBiyAris[i] + 49)).ToString();
                        }

                    }
                    else
                    foreach (CArista a in grafoP.listaArista)//biyeccion aristas
                    {
                        int t = 0;
                        i = tablaBiyeAris.Rows.Add();
                        tablaBiyeAris.Rows[i].Cells[0].Value = a.nombre;
                        tablaBiyeAris.Rows[i].Cells[1].Value = (Convert.ToChar(ordBiyAris[i] + 49)).ToString();
                    }

                    //aqui acomodo mis valores de matriz incidencia resultante de columnas
                    if(isoInci == false)
                    {
                        for (int i = 0; i < grafoP.listaArista.Count; i++)
                        {
                            DataGridViewTextBoxColumn Columna1R = new DataGridViewTextBoxColumn();
                            Columna1R.HeaderText = "Error 404";// (Convert.ToChar(ordBiyAris[i] + 49)).ToString();//nom.ToString();// (nom + (char)17).ToString();
                            MatResAr.Columns.Add(Columna1R);
                        }
                    }
                    else
                    for (int i = 0; i < grafoP.listaArista.Count; i++)
                    {
                        DataGridViewTextBoxColumn Columna1R = new DataGridViewTextBoxColumn();
                        Columna1R.HeaderText = (Convert.ToChar(ordBiyAris[i] + 49)).ToString();//nom.ToString();// (nom + (char)17).ToString();
                        MatResAr.Columns.Add(Columna1R);
                    }

                }
                else
                {
                    for (int i = 0; i < grafoP.listaNodos.Count; ordBiy[i] = i, i++) ;

                    for (int i = 0; i < grafoP.listaNodos.Count; i++)
                    {
                        DataGridViewTextBoxColumn Columna1R = new DataGridViewTextBoxColumn();
                        Columna1R.HeaderText = (Convert.ToChar(ordBiy[i] + 65)).ToString();//nom.ToString();// (nom + (char)17).ToString();
                        MatrizResu.Columns.Add(Columna1R);

                    }

                    for (int i = 0; i < grafoP.listaNodos.Count; i++)
                    {
                        //char nom = (Convert.ToChar(ordBiy[i]));
                        i = MatrizResu.Rows.Add();
                        MatrizResu.Rows[i].Cells[0].Value = (Convert.ToChar(ordBiy[i] + 65)).ToString();
                    }

                    if(hacerInsi == true)
                    foreach (CNodo a in grafoP.listaNodos)//biyeccion vertices
                    {
                        i = tablaBiye.Rows.Add();
                        tablaBiye.Rows[i].Cells[0].Value = a.nombre;
                        tablaBiye.Rows[i].Cells[1].Value = a.nombre;
                    }

                    //Para la matriz de incidencia columnas
                    if (hacerInsi == true && isoInci == true)
                    {
                        for (int i = 0; i < grafoP.listaArista.Count; i++)
                        {
                            DataGridViewTextBoxColumn Columna1R = new DataGridViewTextBoxColumn();
                            Columna1R.HeaderText = (Convert.ToChar(ordBiyAris[i] + 49)).ToString();//nom.ToString();// (nom + (char)17).ToString();
                            MatResAr.Columns.Add(Columna1R);
                        }

                        //Para la matriz de incidencia columnas renglones
                        for (int i = 0; i < grafoP.listaNodos.Count; i++)
                        {
                            //char nom = (Convert.ToChar(ordBiy[i]));
                            i = MatResAr.Rows.Add();
                            MatResAr.Rows[i].Cells[0].Value = (Convert.ToChar(ordBiy[i] + 65)).ToString();
                        }
                    }
                }

                //Coloca los valores en la matriz de adyacencia resultante
                foreach (CNodo a in grafoS.listaNodos)
                {
                    foreach (CNodo b in grafoS.listaNodos)
                    {

                        MatrizResu.Rows[contRen].Cells[contCol].Value = MG1[conRenM, contColM];
                        contCol++;
                        contColM++;
                    }
                    contCol = 1;
                    contRen++;
                    contColM = 0;
                    conRenM++;
                }

                contRen = 0; contCol = 1; conRenM = 0; contColM = 0;

                //Coloca los valores en la matriz de adyacencia resultante
                if (isoInci == true && hacerInsi == true)
                {
                    foreach (CNodo a in grafoS.listaNodos)
                    {
                        foreach (CArista b in grafoS.listaArista)
                        {
                            MatResAr.Rows[contRen].Cells[contCol].Value = MI1[conRenM, contColM];
                            contCol++;
                            contColM++;
                        }
                        contCol = 1;
                        contRen++;
                        contColM = 0;
                        conRenM++;
                    }
                }
            }
            
        }

        
        public bool FuerzaBruta(int[,] g1, int[,] g2, int count)
        {


            if (count > 14)
                MessageBox.Show("SonMuchos nodos");
            long[] fact = { 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800,
                           39916800, 479001600, 6227020800, 87178291200};//cantidad maxima de veces a permutar
            int[] indice = new int[count]; //indices a permutar
            //creando el arreglo de indices
            for (int i = 0; i < count; indice[i] = i, i++) ;

            
            //si las matrices son iguales, sin permutar nada, return
            if (MatricesIguales(g1, g2, count))
            {
                bandIgual = true;
                return true;
            }

            //creamos una permutacion y la probamos
            
            for (int i = 0; i < fact[count]; i++)
            {
                NextPermutation(indice);
                if (PruebaPermutacion(g1, g2, indice) == true)
                {
                    ordBiy = indice;
                    return true;  
                    
                }
            }
            return false;
        }

        public bool PruebaPermutacion(int[,] M1, int[,] M2, int[] permutacion)
        {
            for (int i = 0; i < permutacion.Length; i++)
                for (int j = 0; j < permutacion.Length; j++)
                {
                    if (M1[i, j] != M2[permutacion[i], permutacion[j]])
                    {
                        return false;
                    }  
                }
            return true;
        }

        private static bool NextPermutation(int[] numList)
        {
            /* 
             * Este ALgoritmo se investigo, sirve para que nos de los diferentes indices que deberiamos de permutar
            Knuths 
            1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation. 
            2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l. 
            3. Swap a[j] with a[l]. 
            4. Reverse the sequence from a[j + 1] up to and including the final element a[n]. 
            */
            var largestIndex = -1;
            for (var i = numList.Length - 2; i >= 0; i--)
            {
                if (numList[i] < numList[i + 1])
                {
                    largestIndex = i;
                    break;
                }
            }
            if (largestIndex < 0) return false;
            var largestIndex2 = -1;
            for (var i = numList.Length - 1; i >= 0; i--)
            {
                if (numList[largestIndex] < numList[i])
                {
                    largestIndex2 = i;
                    break;
                }
            }
            var tmp = numList[largestIndex];
            numList[largestIndex] = numList[largestIndex2];
            numList[largestIndex2] = tmp;
            for (int i = largestIndex + 1, j = numList.Length - 1; i < j; i++, j--)
            {
                tmp = numList[i];
                numList[i] = numList[j];
                numList[j] = tmp;
            }
            return true;
        }


        //PERMUTACIONES CON ARISTAS
        public bool FuerzaBrutaB(int[,] g1, int[,] g2, int count)
        {


            if (count > 14)
                MessageBox.Show("Demasiados nodos, ¿Me quiéres matar?");
            long[] fact = { 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800,
                           39916800, 479001600, 6227020800, 87178291200};//cantidad maxima de veces a permutar
            int[] indiceA = new int[count]; //indices a permutar
            //creando el arreglo de indices
            for (int i = 0; i < count; indiceA[i] = i, i++) ;


            //si las matrices son iguales, sin permutar nada, return
            if (MatricesIguales(g1, g2, count))
            {
                bandIgual = true;
                return true;
            }

            //creamos una permutacion y la probamos

            for (int i = 0; i < fact[count]; i++)
            {
                NextPermutation(indiceA);
                if (PruebaPermutacionB(g1, g2, indiceA) == true)
                {
                    ordBiyAris = indiceA;
                    return true;
                }
            }
            return false;
        }

        public bool PruebaPermutacionB(int[,] M1A, int[,] M2A, int[] permutacion)
        {
            for (int i = 0; i < grafoS.listaNodos.Count; i++)
                for (int j = 0; j < grafoS.listaArista.Count; j++)
                {
                    int d = 0;
                    if (permutacion[i] < grafoS.listaNodos.Count)
                    {
                        if (M1A[i, j] != M2A[permutacion[i], permutacion[j]])
                        {
                            return false;
                        }
                    }
                }
            return true;
        }


        public bool MatricesIguales(int[,] u, int[,] v, int count)
        {
            for (int i = 0; i < count; i++)
                for (int j = 0; j < count; j++)
                    if (u[i, j] != v[i, j])
                        return false;
            return true;
        }

    }
}


