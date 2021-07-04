using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorFiguras1
{
    [Serializable]
    public class CNodo
    {
        public static char c = 'A';
        public static char c2 = 'A';
        public static char c3 = 'A';
        public static int posi = 1;
        public int arbol = 1;
        public int nivelBEP = 1;
        public bool visitado = false;
        public bool niveCompl = false;
        //public CArista profundidad;

        private int POS;
        public int pos { get { return POS; } set { POS = value; } }
        private String NOMBRE;
        public String nombre { get { return NOMBRE; } set { NOMBRE = value; } }
        private Point PC;
        public Point pc { get { return PC; } set { PC = value; } }
        private Rectangle RT;
        public Rectangle rt { get { return RT; } set { RT = value; } }
        private int TAM;
        public int tam { get { return TAM; } set { TAM = value; } }
        private float PX;
        public float px { get { return PX; } set { PX = value; } }
        private float PY;
        public float py { get { return PY; } set { PY = value; } }

        public int numAdya;
        public List<CNodo> listaNodosAdya =  new List<CNodo>();
        public int colCrom = 0;

        
        public String obtenNombre()
        {
            return NOMBRE;
        }


        public CNodo(Point pt, int tam)
        {
            NOMBRE = c.ToString();
            pc = pt;
            rt = new Rectangle(pt.X - (tam / 2), pt.Y - (tam / 2), tam, tam);
            c++;
            this.TAM = tam;
            POS = posi;
            posi++;
        }

        public CNodo(Point pt, int tam, int dos)
        {
            if (dos == 1)
            {
                NOMBRE = c2.ToString();
                pc = pt;
                rt = new Rectangle(pt.X - (tam / 2), pt.Y - (tam / 2), tam, tam);
                c2++;
                this.TAM = tam;
                POS = posi;
                posi++;
            }
            else
            if(dos == 2)
            {
                int r = 0;
                NOMBRE = c3.ToString();
                pc = pt;
                rt = new Rectangle(pt.X - (tam / 2), pt.Y - (tam / 2), tam, tam);
                c3++;
                this.TAM = tam;
                POS = posi;
                posi++;
            }
        }


        public CNodo(float cx, float cy, int tam)
        {

            NOMBRE = c.ToString();
            px = cx;
            py = cy;
            pc = new Point((int)cx, (int)cy);
            c++;
            this.TAM = tam;
            POS = posi;
            posi++;
        }
        public CNodo(float cx, float cy, int tam, int dos)
        {
            if (dos == 1)
            {
                NOMBRE = c2.ToString();
                px = cx;
                py = cy;
                pc = new Point((int)cx, (int)cy);
                c2++;
                this.TAM = tam;
                POS = posi;
                posi++;
            }
            else
            if (dos == 2)
            {
                int r = 0;
                NOMBRE = c3.ToString();
                px = cx;
                py = cy;
                pc = new Point((int)cx, (int)cy);
                c3++;
                this.TAM = tam;
                POS = posi;
                posi++;
            }
            
        }

        public CNodo(float cx, float cy, int tam, string nom)
        {
            this.NOMBRE = nom;
            px = cx;
            py = cy;
            pc = new Point((int)cx, (int)cy);
            c++;
            this.TAM = tam;
            POS = posi;
            posi++;
        }


        public void MoverNodo(Point pc)
        {
            this.PC = pc;
            this.RT.X = this.PC.X - (this.TAM / 2);
            this.RT.Y = this.PC.Y - (this.TAM / 2);
           
        }

        /*public void BuscaAdy(CNodo n, List<CNodo> lisNo)
        {

        }*/
    }
}
