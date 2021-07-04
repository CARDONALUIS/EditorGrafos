using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorFiguras1
{
    public partial class FloydMat : Form
    {
        int i = 1;
        int contRen = 0, contCol = 1;
        int contOri = 0, contDes = 1;
        public int[,] matFloyd;
        public int[,] pos;
        public float exentri;
        int enco = 0;
        public int tamaño;
        public CGrafo graFloyd;
        public List<float> lisEx = new List<float>();
        string camiFlo;


        public FloydMat()
        {
            InitializeComponent();
            DataGridViewTextBoxColumn Columna1 = new DataGridViewTextBoxColumn();
            Columna1.HeaderText = "";
            matOri.Columns.Add(Columna1);

            DataGridViewTextBoxColumn Columna2 = new DataGridViewTextBoxColumn();
            Columna2.HeaderText = "";
            matRes.Columns.Add(Columna2);

            DataGridViewTextBoxColumn Columna3 = new DataGridViewTextBoxColumn();
            Columna3.HeaderText = "";
            matP.Columns.Add(Columna3);
        }

        public void asignaValor(CGrafo grafo)
        {
            //int i = 1;
            graFloyd = grafo;
            matFloyd = new int[grafo.listaNodos.Count, grafo.listaNodos.Count];

            foreach (CNodo a in grafo.listaNodos)//Columnas
            {
                DataGridViewTextBoxColumn Columna1 = new DataGridViewTextBoxColumn();
                Columna1.HeaderText = a.nombre;
                matOri.Columns.Add(Columna1);

                DataGridViewTextBoxColumn Columna2 = new DataGridViewTextBoxColumn();
                Columna2.HeaderText = a.nombre;
                matRes.Columns.Add(Columna2);

                DataGridViewTextBoxColumn Columna3 = new DataGridViewTextBoxColumn();
                Columna3.HeaderText = a.nombre;
                matP.Columns.Add(Columna3);
            }


            foreach (CNodo a in grafo.listaNodos)//Filas
            {
                i = matOri.Rows.Add();
                matOri.Rows[i].Cells[0].Value = a.nombre;  //a.origen.nombre;

                i = matRes.Rows.Add();
                matRes.Rows[i].Cells[0].Value = a.nombre;  //a.origen.nombre;

                i = matP.Rows.Add();
                matP.Rows[i].Cells[0].Value = a.nombre;  //a.origen.nombre;

            }

            foreach (CNodo a in grafo.listaNodos)//Rellena de ceros las matris para inicializarla
            {
                foreach (CNodo b in grafo.listaNodos)
                {
                    matOri.Rows[contRen].Cells[contCol].Value = "0";
                    matRes.Rows[contRen].Cells[contCol].Value = "0";
                    matP.Rows[contRen].Cells[contCol].Value = "0";

                    contCol++;
                }
                contCol = 1;
                contRen++;
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

                matOri.Rows[contOri].Cells[contDes].Value = a.nombre;

                contOri = 0;
                contDes = 1;

            }

            int f = 0;
            int c = 0;

            for (int fila = 0; fila < matOri.Rows.Count - 1; fila++)//Saca los valores de la matriz de adyacencia 1
            {

                for (int col = 0; col < matOri.Rows[fila].Cells.Count; col++)
                {
                    if (col != 0)
                    {
                        string valor = matOri.Rows[fila].Cells[col].Value.ToString();
                        matFloyd[f, c] = Convert.ToInt32(valor);
                        if(fila+1 == col)
                        {
                            matOri.Rows[fila].Cells[col].Value = "0";
                            matFloyd[f, c] = 0;

                        }
                        if (fila + 1 != col)
                            if (Convert.ToInt32(valor) == 0)
                            {
                                matOri.Rows[fila].Cells[col].Value = "&";
                                matFloyd[f, c] = 999999;
                            }

                        c++;
                    }

                }
                c = 0;
                f++;
            }
            obtenResul(matFloyd, grafo.listaNodos.Count);
            imprimeResul(pos);

        }

        public void obtenResul(int[,] matriz, int tam)
        {
            int a = 0, b = 0, c = 0, ren = 0;
            int w = 0;
            tamaño = tam;

            pos = new int[15, 4];

            for (int k = 0; k < tam; k++)
            {
                for (int i = 0; i < tam; i++)
                {
                    for (int j = 0; j < tam; j++)
                    {
                        a = matriz[i, j];
                        b = matriz[i, k];
                        c = matriz[k, j];
                        w++;
                        int r = 0;
                        
                        if (b + c < a)
                        {
                            r = 0;
                            matriz[i, j] = b + c;
                            pos[ren, 0] = i + 1;
                            pos[ren, 1] = j + 1;
                            pos[ren, 2] = b + c;
                            pos[ren, 3] = k + 1;
                            ren++;
                        }

                    }
                }
            }
            enco = ren;

        }

        public void encExcentri()
        {
            int mayorCol = 0, colExtr = 0;
            int f = 0;
            int c = 0;

            while (lisEx.Count < tamaño)
            {
                for (int fila = 0; fila < matOri.Rows.Count - 1; fila++)//Saca los valores de la matriz de adyacencia 1
                {

                    for (int col = 0; col < matOri.Rows[fila].Cells.Count; col++)
                    {
                        if (col != 0)
                        {

                            int valor = Convert.ToInt32(matRes.Rows[fila].Cells[col].Value);
                            if (fila == colExtr)
                            {
                                if (valor > mayorCol)
                                    mayorCol = valor;
                            }
                            c++;
                        }

                    }

                    c = 0;
                    f++;
                }
                colExtr++;
                lisEx.Add(mayorCol);
                mayorCol = 0;
                f = 0;
                c = 0;
            }

            int m = 0;
            
            float menor = 9999;
            while (m < tamaño)
            {
                if (lisEx[m] < menor)
                {
                    menor = lisEx[m];
                }
                m++;
            }

            exentri = menor;
        }

        public void imprimeResul(int[,] res)
        {
            int f = 0;
            int c = 0;
            int ren = 0;
            int o = 0;
            int cont = 0;

            for (int fila = 0; fila < matOri.Rows.Count - 1; fila++)//Saca los valores de la matriz de adyacencia 1
            {

                for (int col = 0; col < matOri.Rows[fila].Cells.Count; col++)
                {
                    if (col != 0)
                    {

                            matRes.Rows[fila].Cells[col].Value = matFloyd[f, c];
                        
                        c++;
                    }

                }
                c = 0;
                f++;
            }

            f = 0;
            c = 0;

            while (cont < enco)
            {
                for (int fila = 0; fila < matRes.Rows.Count - 1; fila++)//Saca los valores de la matriz de adyacencia 1
                {

                    for (int col = 0; col < matRes.Rows[fila].Cells.Count; col++)
                    {
                        if (col != 0)
                        {
                            o = 0;
                            
                            if (f + 1 == res[ren, 0] && c + 1 == res[ren, 1])
                            {
                                o = 0;
                                matRes.Rows[fila].Cells[col].Value = res[ren, 2];
                                matP.Rows[fila].Cells[col].Value = res[ren, 3];

                            }

                            c++;
                        }

                    }
                    c = 0;
                    f++;
                }
                ren++;
                cont++;
                c = 0;
                f = 0;
            }

            encExcentri();


            MessageBox.Show("Voy a imprimir los caminos mas cortos\nDespues te mostrare las matrises: ");
            


            foreach(CNodo a in graFloyd.listaNodos)
            {
                foreach(CNodo b in graFloyd.listaNodos)
                {

                    if (a.pos != b.pos) 
                    {
                        camiFlo +="Origen: "+a.nombre+" Destino: "+b.nombre+ " = "+ a.nombre+"->";
                        camino(a.pos, b.pos);
                        camiFlo += b.nombre;
                        camiFlo += "\n";
                        
                    }
                }
            }
            MessageBox.Show(camiFlo);
            camiFlo = "";
        }


        public void camino(int i, int j)
        {

            int k = Convert.ToInt32(matP.Rows[i-1].Cells[j].Value), c;

 
            if (k == 0)
            {
                if (Convert.ToInt32(matRes.Rows[i - 1].Cells[j].Value) == 999999)
                {
                    camiFlo += "Error->";

                }
                else
                {
                   
                }
            }
            else
            {
                camiFlo+= (Convert.ToChar(k + 64)).ToString() +"->";
                camino(i, k);
            }
        }
    }
}
