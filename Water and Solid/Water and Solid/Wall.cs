using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;
namespace Water_and_Solid
{
    class Wall
    {
        public Vector Normal, MidPoint;
        public double lenght;
        public static double k = 75, Damping = -1.0111;
        public Wall()
        {

        }
        public Wall(Vector Normal, Vector MidPoint, double lenght)
        {
            this.lenght = lenght;
            this.MidPoint = MidPoint;
            this.Normal = Normal;
        }
        
     
        public void Draw()
        {
            if (Normal.z != 0)
            {
                Gl.glPolygonMode(Gl.GL_FRONT,Gl.GL_LINE);
                Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_LINE);
                Gl.glColor3f(0, 1, 1);
                Gl.glBegin(Gl.GL_QUADS);
                Gl.glVertex3d(MidPoint.x + lenght / 2, MidPoint.y + lenght / 2, MidPoint.z);
                Gl.glVertex3d(MidPoint.x - lenght / 2, MidPoint.y + lenght / 2, MidPoint.z);
                Gl.glVertex3d(MidPoint.x - lenght / 2, MidPoint.y - lenght / 2, MidPoint.z);
                Gl.glVertex3d(MidPoint.x + lenght / 2, MidPoint.y - lenght / 2, MidPoint.z);
                Gl.glEnd();
            }
            if (Normal.y != 0)
            {
                if (Normal.y == -1)
                {
                    Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_FILL);
                    Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_FILL);
                    Gl.glColor3f(0, 1, 1);
                }
                else
                {
                    Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_LINE);
                    Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_LINE);
                }
                Gl.glBegin(Gl.GL_QUADS);

                Gl.glVertex3d(MidPoint.x + lenght / 2, MidPoint.y, MidPoint.z + lenght / 2);
                Gl.glVertex3d(MidPoint.x - lenght / 2, MidPoint.y, MidPoint.z + lenght / 2);
                Gl.glVertex3d(MidPoint.x - lenght / 2, MidPoint.y, MidPoint.z - lenght / 2);
                Gl.glVertex3d(MidPoint.x + lenght / 2, MidPoint.y, MidPoint.z - lenght / 2);
                Gl.glEnd();
            }
            if (Normal.x != 0)
            {
                Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_LINE);
                Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_LINE);
                Gl.glBegin(Gl.GL_QUADS);
                Gl.glVertex3d(MidPoint.x, MidPoint.y + lenght / 2, MidPoint.z + lenght / 2);
                Gl.glVertex3d(MidPoint.x, MidPoint.y - lenght / 2, MidPoint.z + lenght / 2);
                Gl.glVertex3d(MidPoint.x, MidPoint.y - lenght / 2, MidPoint.z - lenght / 2);
                Gl.glVertex3d(MidPoint.x, MidPoint.y + lenght / 2, MidPoint.z - lenght / 2);
                Gl.glEnd();
            }
        }
    }
}
