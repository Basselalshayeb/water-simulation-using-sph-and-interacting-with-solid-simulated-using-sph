using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace Water_and_Solid
{
    class Particile
    {
        public int id;

        //0.0078
        public double Radius = 0.0078;

        public double Mass = 0.02;
        public static double Row0_Den = 998.29,meo = 0.001003,k = 3.0;
        public double Density, Pressure, MassDensity;
        Glu.GLUquadric q = Glu.gluNewQuadric();


        public Vector CurrPosition, LastPosition, LastVelocity, CurrVeclocity, LastAcceleration, CurrAcceleration, Force;
        public string color = "blue";
      
        public void Draw()
        {

            Gl.glPushMatrix();
            Gl.glTranslated((float)CurrPosition.x, (float)CurrPosition.y, (float)CurrPosition.z);
            if (color == "blue")
                Gl.glColor3f(0, 0, 1);
               
            else
                Gl.glColor3f(0.5f, 0.5f, 0.5f);
            
            Glu.gluSphere(q, Radius,20, 20);

            Gl.glPopMatrix();
        }

        public Particile()
        {
            CurrPosition = new Vector();
            LastPosition = new Vector();
            LastVelocity = new Vector();
            CurrVeclocity = new Vector();
            LastAcceleration = new Vector();
            CurrAcceleration = new Vector();
            Force = new Vector(0,0,0); 

        }
        public Particile(int id, Vector Currposition)
        {
            this.id = id;
            this.CurrPosition = CurrPosition;
            this.CurrVeclocity = new Vector(0, 0, 0);
            this.CurrAcceleration = new Vector(0, 0, 0);

        }
        public Particile(int id, Vector Currposition, double mass, double radius)
        {

            this.id = id;
            this.CurrPosition = new Vector(Currposition.x, Currposition.y, Currposition.z);
            this.Mass = mass;
            this.Radius = radius;
            this.color = "white";
        }
       public Particile(int id, Vector Currposition, double mass, double radius, Vector speed)
        {

            this.id = id;
            Force = new Vector();
            this.CurrPosition = new Vector(Currposition.x, Currposition.y, Currposition.z);
            this.Mass = mass;
            this.Radius = radius;
            this.color = "white";
            this.CurrVeclocity = new Vector(speed.x, speed.y, speed.z);
        }
    }
}
