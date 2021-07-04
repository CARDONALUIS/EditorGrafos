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
    public partial class RepresentacionMI : Form
    {
        public int i = 1, contOri1 = 0, contOri2 = 0, contDes = 1, contArista = 0, contRen = 0, contCol = 1;
        public char c1 = 'A',c2 = '1';

        //Este constructor sirve para inicializar las coumnas de los dataGrid
        public RepresentacionMI()
        {
            InitializeComponent();

            
            /*
            DataGridViewTextBoxColumn Columna1 = new DataGridViewTextBoxColumn();
            Columna1.HeaderText = "";
            MatInci.Columns.Add(Columna1);

            DataGridViewTextBoxColumn Columna2 = new DataGridViewTextBoxColumn();
            Columna2.HeaderText = "";
            MatInciD.Columns.Add(Columna2);
            */
        }

        /*Metodo que asigna los valores del graofo a las diferentes dataGridView*/
        public void asignaValoresMI(CGrafo grafoR, int tipoMI)
        {
            DataGridViewTextBoxColumn Columna1 = new DataGridViewTextBoxColumn();
            Columna1.HeaderText = "";
            MatInci.Columns.Add(Columna1);

            DataGridViewTextBoxColumn Columna2 = new DataGridViewTextBoxColumn();
            Columna2.HeaderText = "";
            MatInciD.Columns.Add(Columna2);

            foreach (CArista a in grafoR.listaArista)//Columnas
            {
                DataGridViewTextBoxColumn Columna3 = new DataGridViewTextBoxColumn();
                Columna3.HeaderText = a.nombre;
                MatInci.Columns.Add(Columna3);

                DataGridViewTextBoxColumn Columna4 = new DataGridViewTextBoxColumn();
                Columna4.HeaderText = a.nombre;
                MatInciD.Columns.Add(Columna4);
                contArista++;
            }
            
            foreach (CNodo a in grafoR.listaNodos)//Filas
            {
                i = MatInci.Rows.Add();
                MatInci.Rows[i].Cells[0].Value = a.nombre;  //a.origen.nombre;

                i = MatInciD.Rows.Add();
                MatInciD.Rows[i].Cells[0].Value = a.nombre;

                i++;
            }

            foreach (CNodo a in grafoR.listaNodos)//Rellena de ceros las matris para inicializarla
            {
                foreach (CArista b in grafoR.listaArista)
                {
                    if (tipoMI == 0)
                        MatInci.Rows[contRen].Cells[contCol].Value = "0";
                    else
                        MatInciD.Rows[contRen].Cells[contCol].Value = "0";

                    contCol++;
                }
                contCol = 1;
                contRen++;
            }


            foreach (CArista a in grafoR.listaArista)//Asigna valores de relaciones de los nodos
            {
                i = MatInci.Rows.Add();

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

                if (tipoMI == 1)
                {
                    MatInciD.Rows[contOri1].Cells[contDes].Value = "1";
                    if (contOri2 <= contArista)
                        MatInciD.Rows[contOri2].Cells[contDes].Value = "-1";
                }
                else
                {
                    MatInci.Rows[contOri1].Cells[contDes].Value = "1";
                    if (contOri2 <= contArista)
                        MatInci.Rows[contOri2].Cells[contDes].Value = "1";
                }

                contOri1 = 0;
                contOri2 = 0;
                contDes = 1;
            }
            
        }
    }
}
