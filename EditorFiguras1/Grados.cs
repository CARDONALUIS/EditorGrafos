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
    
    public partial class Grados : Form
    {
        int i = 0, contNodo = 0, contNodoEn = 0, contNodoSa=0, contGrafo = 0;

        //Constructor para inicializar los datagridview
        public Grados()
        {
            InitializeComponent();

            DataGridViewTextBoxColumn Columna1 = new DataGridViewTextBoxColumn();
            Columna1.HeaderText = "Nodo";
            GradosNoDi.Columns.Add(Columna1);

            DataGridViewTextBoxColumn Columna2 = new DataGridViewTextBoxColumn();
            Columna2.HeaderText = "Grados";
            GradosNoDi.Columns.Add(Columna2);


            DataGridViewTextBoxColumn Columna3 = new DataGridViewTextBoxColumn();
            Columna3.HeaderText = "Nodo";
            GradosDiri.Columns.Add(Columna3);

            DataGridViewTextBoxColumn Columna4 = new DataGridViewTextBoxColumn();
            Columna4.HeaderText = "Grado";
            GradosDiri.Columns.Add(Columna4);

            DataGridViewTextBoxColumn Columna5 = new DataGridViewTextBoxColumn();
            Columna5.HeaderText = "Nodo";
            GradosDiri.Columns.Add(Columna5);

            DataGridViewTextBoxColumn Columna6 = new DataGridViewTextBoxColumn();
            Columna6.HeaderText = "Grado";
            GradosDiri.Columns.Add(Columna6);

        }

        private void Grados_Load(object sender, EventArgs e)
        {

        }

        //Metodo para asignara los valores correspondientes al datagidview
        public void asignaValorGRA(CGrafo grafoR, int tipoLA)
        {

            if (tipoLA == 0)
            {
                foreach (CNodo a in grafoR.listaNodos)
                {
                    foreach (CArista b in grafoR.listaArista)
                    {
                        if (a.nombre == b.origen.nombre)
                        {
                            contNodo++;
                            contGrafo++;
                        }


                        if (a.nombre == b.destino.nombre)
                        {
                            contNodo++;
                            contGrafo++;
                        }

                    }
                    i = GradosNoDi.Rows.Add();
                    GradosNoDi.Rows[i].Cells[0].Value = a.nombre;
                    GradosNoDi.Rows[i].Cells[1].Value = contNodo;
                    contNodo = 0;
                    label4.Text = "Grado del grafo: " + contGrafo;
                }
                
            }
            else
            {
                foreach (CNodo a in grafoR.listaNodos)
                {
                    foreach (CArista b in grafoR.listaArista)
                    {
                        if (a.nombre == b.origen.nombre)
                            contNodoEn++;

                        if (a.nombre == b.destino.nombre)
                        {
                            contNodoSa++;
                            contGrafo++;
                        }
                            
                    }
                    i = GradosDiri.Rows.Add();
                    GradosDiri.Rows[i].Cells[0].Value = a.nombre;
                    GradosDiri.Rows[i].Cells[2].Value = a.nombre;
                    GradosDiri.Rows[i].Cells[3].Value = contNodoEn;
                    GradosDiri.Rows[i].Cells[1].Value = contNodoSa;

                    contNodoEn = 0;
                    contNodoSa = 0;
                    label4.Text = "Grado del grafo: " +contGrafo;
                    

                }
                

            }
            
            
        }

    }

}
