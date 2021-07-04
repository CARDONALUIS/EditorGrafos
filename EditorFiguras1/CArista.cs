using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorFiguras1
{
    [Serializable]
    public class CArista
    {
        float ninterx, nintery;
        double pend, ang, radians, angF, ag, pfx, pfy;

        public static char c = '1';
        public static char c2 = '1';
        public static char c3 = '1';
        public bool puesta = false;
        private String NOMBRE;
        public String nombre { get { return NOMBRE; } set { NOMBRE = value; } }
        private Color COLOR;
        public Color color { get { return COLOR; } set { COLOR = value; } }
        private CNodo ORIGEN;
        public CNodo origen { get { return ORIGEN; } set { ORIGEN = value; } }
        private CNodo DESTINO;
        public CNodo destino { get { return DESTINO; } set { DESTINO = value; } }
        private float INTERX;
        public float interx { get { return INTERX; } set { INTERX = value; } }
        private float INTERY;
        public float intery { get { return INTERY; } set { INTERY = value; } }
        private float DISMEDX;
        public float dismedx { get { return DISMEDX; } set { DISMEDX = value; } }
        private float DISMEDY;
        public float dismedy { get { return DISMEDY; } set { DISMEDY = value; } }

        public CArista(CNodo ori, CNodo des)
        {
            NOMBRE = c.ToString();
            ORIGEN  = ori;
            DESTINO = des;
            //INTERX = interx;
            //INTERY = intery;
            if (des != null && ori != null)
            {
                dismedx = des.pc.X + ((ori.pc.X - des.pc.X) / 2);
                dismedy = des.pc.Y + ((ori.pc.Y - des.pc.Y) / 2);
            }
            else
            {
                dismedx = -5;
                dismedy = -5;
            }
            c++;
        }

        public CArista(CNodo ori, CNodo des, float pesoA)
        {
            int p = 0;
            NOMBRE = pesoA.ToString();
            ORIGEN = ori;
            DESTINO = des;
            //INTERX = interx;
            //INTERY = intery;
            if (des != null && ori != null)
            {
                dismedx = des.pc.X + ((ori.pc.X - des.pc.X) / 2);
                dismedy = des.pc.Y + ((ori.pc.Y - des.pc.Y) / 2);
            }
            else
            {
                dismedx = -5;
                dismedy = -5;
            }
            
        }

        public CArista(CNodo ori, CNodo des, int dos)
        {
            if (dos == 1)
            {
                NOMBRE = c2.ToString();
                ORIGEN = ori;
                DESTINO = des;
                //INTERX = interx;
                //INTERY = intery;
                dismedx = des.pc.X + ((ori.pc.X - des.pc.X) / 2);
                dismedy = des.pc.Y + ((ori.pc.Y - des.pc.Y) / 2);
                c2++;
            }
            else
            {
                NOMBRE = c3.ToString();
                ORIGEN = ori;
                DESTINO = des;
                //INTERX = interx;
                //INTERY = intery;
                dismedx = des.pc.X + ((ori.pc.X - des.pc.X) / 2);
                dismedy = des.pc.Y + ((ori.pc.Y - des.pc.Y) / 2);
                c3++;
            }
        }

        public void CalInterseccion(CNodo nOri, CNodo nDes)
        {
            pend = ((double)(nDes.pc.Y - nOri.pc.Y)) / ((double)(nDes.pc.X - nOri.pc.X));
            radians = Math.Atan(pend);
            ang = (radians * (180 / Math.PI));
            if (pend < 0 && nDes.pc.Y < nOri.pc.Y)
            {
                angF = Math.Abs(ang) + 180;
            }
            else
                if (pend > 0 && nDes.pc.Y < nOri.pc.Y)
            {
                angF = 360 - ang;
            }
            else
                    if (nDes.pc.Y > nOri.pc.Y && pend > 0)
            {
                angF = 90 + ang;
            }
            else
            {
                angF = Math.Abs(ang);
            }

            if (angF <= 180 && angF >= 90)
            {
                ag = 180 - angF;
                pfx = Math.Sin(ag * 2.0 * Math.PI / 360.0) * (50 / 2);
                ninterx = (float)(nDes.pc.X - pfx);
                pfy = Math.Cos(ag * 2.0 * Math.PI / 360.0) * (50 / 2);
                nintery = (float)(nDes.pc.Y - pfy);
            }
            else
                if (angF <= 90 && angF >= 0)
            {
                ag = angF;
                pfx = Math.Cos(ag * 2.0 * Math.PI / 360.0) * (50 / 2);
                ninterx = (float)(nDes.pc.X + pfx);
                pfy = Math.Sin(ag * 2.0 * Math.PI / 360.0) * (50 / 2);
                nintery = (float)(nDes.pc.Y - pfy);
            }
            else
                if (angF <= 270 && angF >= 180)
            {
                ag = Math.Abs(180 - angF);
                pfx = Math.Cos(ag * 2.0 * Math.PI / 360.0) * (50 / 2);
                ninterx = (float)(nDes.pc.X - pfx);
                pfy = Math.Sin(ag * 2.0 * Math.PI / 360.0) * (50 / 2);
                nintery = (float)(nDes.pc.Y + pfy);
            }
            else
            {
                ag = 360 - angF;
                pfx = Math.Cos(ag * 2.0 * Math.PI / 360.0) * (50 / 2);
                ninterx = (float)(nDes.pc.X + pfx);
                pfy = Math.Sin(ag * 2.0 * Math.PI / 360.0) * (50 / 2);
                nintery = (float)(nDes.pc.Y + pfy);
            }

            this.INTERX = ninterx;
            this.INTERY = nintery;
        }

        public void compMultiAri(CGrafo grafoA, CNodo nOri, CNodo nDes)
        {

            //int p = 0;
            foreach(CArista b in grafoA.listaArista)
            {
                if((nOri.nombre == b.origen.nombre && nDes.nombre == b.destino.nombre) || (nOri.nombre == b.destino.nombre && nDes.nombre== b.origen.nombre))
                {                  
                    b.dismedy += 15;
                    this.dismedx -= 15;

                }
            }
        }


    }
}
