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
    public partial class RepresentacionMA : Form
    {
        public char c = 'A';
        public int i = 1;
        public int contOri = 0, contDes = 1;
        public int contRen = 0, contCol = 1, conMulti = 1;

        //Metodo para el constructor e inicialize los dataGRidView
        public RepresentacionMA()
        {           
            InitializeComponent();
        }

        private void RepresentacionMA_Load(object sender, EventArgs e)
        {
            
        }

        /*
         * Este metodo asigna los valores del grafo a los datagridview
         * */
        public void asignaValoresMA(CGrafo grafoR, int tipoMA)
        {
            DataGridViewTextBoxColumn Columna1 = new DataGridViewTextBoxColumn();
            Columna1.HeaderText = "";
            MatAdya.Columns.Add(Columna1);

            DataGridViewTextBoxColumn Columna2 = new DataGridViewTextBoxColumn();
            Columna2.HeaderText = "";
            MatAdyaND.Columns.Add(Columna2);


            foreach (CNodo a in grafoR.listaNodos)//Columnas
            {
                DataGridViewTextBoxColumn Columna3 = new DataGridViewTextBoxColumn();
                Columna3.HeaderText = a.nombre;
                MatAdya.Columns.Add(Columna3);

                DataGridViewTextBoxColumn Columna4 = new DataGridViewTextBoxColumn();
                Columna4.HeaderText = a.nombre;
                MatAdyaND.Columns.Add(Columna4);
            }


            foreach (CNodo a in grafoR.listaNodos)//Filas
            {
                i = MatAdya.Rows.Add();
                MatAdya.Rows[i].Cells[0].Value = a.nombre;  //a.origen.nombre;

                i = MatAdyaND.Rows.Add();
                MatAdyaND.Rows[i].Cells[0].Value = a.nombre;  //a.origen.nombre;

            }


            
            foreach (CNodo a in grafoR.listaNodos)//Rellena de ceros las matris para inicializarla
            {
                foreach (CNodo b in grafoR.listaNodos)
                {
                    if(tipoMA == 0)
                    MatAdyaND.Rows[contRen].Cells[contCol].Value = "0";
                    else
                        MatAdya.Rows[contRen].Cells[contCol].Value = "0";

                    contCol++;
                }
                contCol = 1;
                contRen++;
            }

            
            foreach (CArista a in grafoR.listaArista)//Asigna valores de relaciones de los nodos
            {
                int co = 1;

                while(a.origen.pos != co)
                {
                    contOri++;
                    co++;
                }

                co = 1;

                while(a.destino.pos != co)
                {
                    contDes++;
                    co++;
                }

                co = 1;

                if (tipoMA == 0)
                {
                    MatAdyaND.Rows[contOri].Cells[contDes].Value = conMulti.ToString();
                    MatAdyaND.Rows[contDes - 1].Cells[contOri + 1].Value = conMulti.ToString();
                    conMulti++;
                }
                else
                {
                    MatAdya.Rows[contOri].Cells[contDes].Value = conMulti.ToString();
                    //MatAdya.Rows[contOri].Cells[contDes].Value = a.nombre;

                }

                contOri = 0;
                contDes = 1;
                conMulti = 1;
                

            }


            
        }
    }
}

