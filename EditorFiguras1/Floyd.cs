using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorFiguras1
{
    public class Floyd
    {
        public float excentr = 0;
        public List<float> lisExF = new List<float>();

        public void creaMatriz(CGrafo gFloyd)
        {
            FloydMat fm = new FloydMat();

            fm.asignaValor(gFloyd);

            fm.ShowDialog();
            excentr = fm.exentri;
            lisExF = fm.lisEx;


        }

        public void algoritmoFloyd()
        {

        }

       


    }
}
