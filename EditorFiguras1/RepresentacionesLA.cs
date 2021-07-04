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
    public partial class RepresentacionesLA : Form
    {
        Graphics g;
        int i;

        //Constrctor para inicalizar el dataGridView
        public RepresentacionesLA()
        {
            InitializeComponent();

        }

        public void Ventana_Relaciones_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
        }


        /*
         * Asigna los valores correspondientes a la datagridview
         * */
        public void asignaValorLA(CGrafo grafoR, int tipoLA)
        {
            DataGridViewTextBoxColumn Columna1 = new DataGridViewTextBoxColumn();
            Columna1.HeaderText = "Vertice Inicial";
            LisAdy.Columns.Add(Columna1);

            DataGridViewTextBoxColumn Columna2 = new DataGridViewTextBoxColumn();
            Columna2.HeaderText = "Vertice Final";
            LisAdy.Columns.Add(Columna2);

            DataGridViewTextBoxColumn Columna1D = new DataGridViewTextBoxColumn();
            Columna1D.HeaderText = "Vertice";
            LisAdyDi.Columns.Add(Columna1D);

            DataGridViewTextBoxColumn Columna2D = new DataGridViewTextBoxColumn();
            Columna2D.HeaderText = "Vertices Adyacentes";
            LisAdyDi.Columns.Add(Columna2D);


            string cad = "";
            string nueva = "";

            if (tipoLA == 1)
            {
                foreach (CNodo a in grafoR.listaNodos)
                {
                    i = LisAdy.Rows.Add();
                    LisAdy.Rows[i].Cells[0].Value = a.nombre;
                    foreach (CArista b in grafoR.listaArista)
                    {
                        if (a.nombre == b.origen.nombre)
                            cad += b.destino.nombre;
                    }


                    string ordenado = new String(cad.OrderBy(x => x).ToArray());
                    

                    for (int i = 0; i < ordenado.Length; i++)
                    {
                        nueva += ordenado[i];
                        nueva += ",";
                    }

                    LisAdy.Rows[i].Cells[1].Value = nueva;

                    nueva = "";
                    ordenado = "";
                    cad = "";

                }
            }
            else
            {
                
                foreach (CNodo a in grafoR.listaNodos)
                {
                    i = LisAdyDi.Rows.Add();
                    LisAdyDi.Rows[i].Cells[0].Value = a.nombre;
                    foreach (CArista b in grafoR.listaArista)
                    {
                        if (a.nombre == b.origen.nombre)
                        {
                            cad += b.destino.nombre;
                        }

                        if (a.nombre == b.destino.nombre)
                        {
                            cad += b.origen.nombre;
                        }
                    }

                    string ordenado = new String(cad.OrderBy(x => x).ToArray());
                    
                    for(int i = 0; i <ordenado.Length;i++)
                    {
                        nueva += ordenado[i];
                        nueva += ",";
                    }

                    LisAdyDi.Rows[i].Cells[1].Value = nueva;

                    nueva = "";
                    ordenado = "";
                    cad = "";
                }

               


            }

        }


        public void Relaciones_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
