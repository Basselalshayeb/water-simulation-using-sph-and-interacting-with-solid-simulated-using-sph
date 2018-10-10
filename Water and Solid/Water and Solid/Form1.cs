using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;
namespace Water_and_Solid
{
    public partial class Form1 : Form
    {
        // r = 0.015
        //v came from here m=row*V/n 
        //h =sqrt(3*V*x/(4*pi*n),3);  v size of the fluid n number of Particiles x number of supported partecles
        //it have to be 0.457 for m=0.02
        //--------------Variable--------------------//
        double delT, T, h, length;
        Particile[] p;
        int q, loopCounter;
        Wall[] w;
        int id;
        double l_threshold = 7.068;
        double Surface_Segma = .00000000728;
        Solid cube;
        float PARTICLE_SPACING;
        public Form1()
        {
            InitializeComponent();
            // Initialize View
            SetView();

            // Initialize Variables
            InitVar();
        }
        public void SetView()
        {
            Gl.glShadeModel(Gl.GL_SMOOTH);                            // Enable Smooth Shading
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.5f);               // Black Background
            Gl.glClearDepth(1.0f);                                 // Depth Buffer Setup
            Gl.glEnable(Gl.GL_DEPTH_TEST);                            // Enables Depth Testing
            Gl.glDepthFunc(Gl.GL_LEQUAL);                             // The Type Of Depth Testing To Do
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);	// Really Nice Perspective Calculations
            int height = simpleOpenGlControl1.Height;
            int width = simpleOpenGlControl1.Width;
            simpleOpenGlControl1.InitializeContexts();
            Gl.glViewport(0, 0, width, height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45.0f, (double)width / (double)height, 0.01f, 5000.0f);
            Glut.glutInit();

        }
        int table,floor,wall;
        // Initalize all variable
        public void InitVar()
        {
            table = TextureLoader.LoadTextureNormal("D:\\lib3\\7.bmp");
            floor = TextureLoader.LoadTextureNormal("D:\\lib3\\6.bmp");
            wall = TextureLoader.LoadTextureNormal("D:\\lib3\\5.bmp");
            cube = new Solid();
            /*for (double i = 0.002; i >= 0.0001; i-= 0.0001)
                domainUpDown1.Items.Add(i.ToString());*/
            textBox2.Text = Particile.Row0_Den.ToString();
            textBox3.Text = Particile.meo.ToString();
            /*domainUpDown1.SelectedIndex = 0;*/
            textBox1.Text = "400";
            textBox6.Text = "0.02";
           // textBox7.Text = "2.7";
            delT = 0.0004;
            T = 0;
            id = 0;
            h = 0.03;
            textBox5.Text = h.ToString();

            loopCounter = 0;
            length = 0.15;
            PARTICLE_SPACING = .02255f;
            q = 0;
            textBox4.Text = Particile.k.ToString();

            p = new Particile[3000];
            w = new Wall[5];
            for (int i = 0; i < 3000; i++)
                p[i] = new Particile();
            for (int i = 0; i < 5; i++)
                w[i] = new Wall();
            //FRONT
            w[0].lenght = length; w[0].MidPoint = new Vector(0, -w[0].lenght / 2, w[0].lenght / 2); w[0].Normal = new Vector(0, 0, 1);
            //RIGHT
            w[1].lenght = length; w[1].MidPoint = new Vector(w[0].lenght / 2, -w[0].lenght / 2, 0); w[1].Normal = new Vector(1, 0, 0);
            //BOTTOM
            w[2].lenght = length; w[2].MidPoint = new Vector(0, -w[0].lenght, 0); w[2].Normal = new Vector(0, -1, 0);
            //back
            w[3].lenght = length; w[3].MidPoint = new Vector(0, -w[0].lenght / 2, -w[0].lenght / 2); w[3].Normal = new Vector(0, 0, -1);
            //LEFT
            w[4].lenght = length; w[4].MidPoint = new Vector(-w[0].lenght / 2, -w[0].lenght / 2, 0); w[4].Normal = new Vector(-1, 0, 0);
            int N = 5;
            for (int j = 0; j <= N + 15; j++)
            {

                //x loop
                for (int i = 0; i <= N; i++)
                {
                    //z loop
                    for (int k = 0; k <= N; k++)
                    {
                        double x = -w[0].lenght / 2 + p[0].Radius + i * PARTICLE_SPACING;
                        double y = 0.1 + -w[0].lenght + j * PARTICLE_SPACING;
                        double z = -w[0].lenght / 2 + p[0].Radius + k * PARTICLE_SPACING;
                        p[id].CurrPosition = new Vector(x, y, z);
                        p[id].CurrAcceleration = new Vector(0, 0, 0);
                        p[id].CurrVeclocity = new Vector(0, 0, 0);
                        id++;

                    }

                }
            }
        }
        void Collision_Box_Cube(int i)
        {
        
            //collision detection and handling
            for (int j = 0; j < 5; j++)
            {

                // Detection with bottom
                if (w[j].Normal.y == -1 && cube.p[i].CurrPosition.y <= w[j].MidPoint.y + cube.p[i].Radius)
                {
                    for (int k = 0; k < 27; k++)
                    {//dot
                        double dottemp = cube.p[k].CurrVeclocity.dot(w[j].Normal);
                        //dot 
                        Vector temp2, temp1;
                        temp1 = w[j].Normal * ((-2) * dottemp) * 0.7;
                        cube.p[k].LastVelocity = cube.p[k].CurrVeclocity;
                        cube.p[k].LastPosition = cube.p[k].CurrPosition;
                        cube.p[k].CurrVeclocity = cube.p[k].CurrVeclocity + temp1;
                        cube.p[k].CurrPosition = cube.p[k].CurrPosition + cube.p[k].CurrVeclocity * delT;
                        if (cube.p[k].CurrPosition.y < w[j].MidPoint.y + cube.p[k].Radius)
                            cube.p[k].CurrPosition.y = w[j].MidPoint.y + cube.p[k].Radius;
                    }
                }
                // Detection Front & Back
                if (w[j].Normal.z != 0
                    && ((w[j].Normal.z == 1 && cube.p[i].CurrPosition.z >= w[j].MidPoint.z - cube.p[i].Radius)
                    || (w[j].Normal.z == -1 && cube.p[i].CurrPosition.z <= w[j].MidPoint.z + cube.p[i].Radius)
                    ))
                {
                    //dot
                    double dottemp = cube.p[i].CurrVeclocity.dot(w[j].Normal);
                    //dot 
                    Vector temp2, temp1;
                    temp1 = w[j].Normal * ((-2) * dottemp) * 0.7;
                    cube.p[i].LastVelocity = cube.p[i].CurrVeclocity;
                    cube.p[i].LastPosition = cube.p[i].CurrPosition;
                    cube.p[i].CurrVeclocity = cube.p[i].CurrVeclocity + temp1;
                    cube.p[i].CurrPosition = cube.p[i].CurrPosition + cube.p[i].CurrVeclocity * delT;
                    // Front
                    if (w[j].Normal.z == 1 && cube.p[i].CurrPosition.z > w[j].MidPoint.z - cube.p[i].Radius)
                        cube.p[i].CurrPosition.z = w[j].MidPoint.z - cube.p[i].Radius;
                    // Back
                    if (w[j].Normal.z == -1 && cube.p[i].CurrPosition.z < w[j].MidPoint.z + cube.p[i].Radius)
                        cube.p[i].CurrPosition.z = w[j].MidPoint.z + cube.p[i].Radius;

                }
                // Detection  right && Left
                if (w[j].Normal.x != 0
                    && ((w[j].Normal.x == 1 && cube.p[i].CurrPosition.x >= w[j].MidPoint.x - cube.p[i].Radius)
                    || (w[j].Normal.x == -1 && cube.p[i].CurrPosition.x <= w[j].MidPoint.x + cube.p[i].Radius)
                    ))
                {
                    //dot
                    double dottemp = cube.p[i].CurrVeclocity.dot(w[j].Normal);
                    //dot 
                    Vector temp2, temp1;
                    temp1 = w[j].Normal * ((-2) * dottemp) * 0.7;
                    cube.p[i].LastVelocity = cube.p[i].CurrVeclocity;
                    cube.p[i].LastPosition = cube.p[i].CurrPosition;
                    cube.p[i].CurrVeclocity = cube.p[i].CurrVeclocity + temp1;
                    cube.p[i].CurrPosition = cube.p[i].CurrPosition + cube.p[i].CurrVeclocity * delT;
                    // right
                    if (w[j].Normal.x == 1 && cube.p[i].CurrPosition.x > w[j].MidPoint.x - cube.p[i].Radius)
                        cube.p[i].CurrPosition.x = w[j].MidPoint.x - cube.p[i].Radius;
                    // left
                    if (w[j].Normal.x == -1 && cube.p[i].CurrPosition.x < w[j].MidPoint.x + cube.p[i].Radius)
                        cube.p[i].CurrPosition.x = w[j].MidPoint.x + cube.p[i].Radius;
                }


            }
        }
         
        private void ComputeMassDensity()
        {
            for (int i = 0; i < loopCounter; i++)
            {
                Particile CurrParticile = p[i];
                CurrParticile.MassDensity = 0;
                for (int j = 0; j < loopCounter; j++)
                {
                    if (i == j) continue;

                    Vector r = CurrParticile.CurrPosition - p[j].CurrPosition;
                    if (r.AbsSquare() < h)
                    {
                        //original
                        CurrParticile.MassDensity += (p[j].Mass * DefaultKernal(r));
                    }
                }
                CurrParticile.Pressure = Particile.k * (CurrParticile.MassDensity - Particile.Row0_Den);
                //CurrParticile.MassDensity = CurrParticile.MassDensity / 0.00005;

                p[i] = CurrParticile;
            }
        }
        private Vector ComputePressureForce(Particile pa, int i)
        {
            Vector PressForce = new Vector(0, 0, 0);
            for (int j = 0; j < loopCounter; j++)
            {
                if (j == i) continue;
                Vector r = pa.CurrPosition - p[j].CurrPosition;
                if (r.AbsSquare() < h)
                {
                    //for not setting the density 0 and divide on 0
                    if (p[j].MassDensity != 0)
                    {
                        //old way pi+pj)*mj/2 roj

                        double temp = (pa.Pressure + p[j].Pressure);
                        temp = ((temp * p[j].Mass) / (2.0 * p[j].MassDensity));

                        //----test new way
                        //double temp = (p[i].Pressure + p[j].Pressure) / (2.0*p[j].MassDensity);

                        //!---test new way
                        Vector temp2 = SpikyKernal(r);
                        temp2 = temp2 * temp;
                        PressForce = PressForce + temp2;
                    }
                }
            }
            PressForce = PressForce * -1;
            return PressForce;
        }
        private Vector ComputeViscocityForce(Particile pa, int i)
        {
            Vector v = new Vector(0, 0, 0);
            for (int j = 0; j < loopCounter; j++)
            {
                if (j == i) continue;
                Vector r = p[i].CurrPosition - p[j].CurrPosition;
                if (r.AbsSquare() < h)
                {
                    Vector value = p[j].CurrVeclocity - pa.CurrVeclocity;
                    value = value * p[j].Mass;
                    value = value * ViscKernal(pa.CurrPosition - p[j].CurrPosition);
                    v = v + value;
                }

            }
            v = v / pa.MassDensity;
            v = v * Particile.meo;
            return v;
        }
        double DefaultKernal(Vector r)
        {
            //if rab
            double pi = 3.1428571428571428571428571428571;
            // h ^ 9
            double constant = (315) / (64 * pi * Math.Pow(h, 9));
            double value = (Math.Pow(h, 2) - Math.Pow(r.AbsSquare(), 2));
            double value2 = value * value * value;
            return value2 * constant;
        }
        //Default kernal gradiant
        Vector DefaultKernalGradiant(Vector r)
        {
            double pi = 3.1428571428571428571428571428571;
            double lefttemp = -945 / (32 * pi * Math.Pow(h, 9));
            Vector righttemp = r * Math.Pow((Math.Pow(h, 2) - r.AbsSquare() * r.AbsSquare()), 2);
            return righttemp * lefttemp;
        }
        double DefaultKernalLaplaciant(Vector r)
        {
            double pi = 3.1428571428571428571428571428571;
            double lefttemp = -945 / (32 * Math.PI * Math.Pow(h, 9));
            double righttemp = (Math.Pow(h, 2) - r.AbsSquare() * r.AbsSquare()) * (3 * Math.Pow(h, 2) - r.AbsSquare() * r.AbsSquare() * 7);
            return lefttemp * righttemp;
        }
        // for Pressure Force
        Vector SpikyKernal(Vector r)
        {
            double pi = 3.1428571428571428571428571428571;
            double value = ((-45) / (Math.PI * r.AbsSquare() * Math.Pow(h, 6)));
            //Vector value2 = r * value;
            //double value3 = powl((h - r.AbsSquare()), 2);
            Vector value2 = r * Math.Pow((h - r.AbsSquare()), 2);
            return (value2 * value);
        }
        // for Viscocity Force
        double ViscKernal(Vector r)
        {
            double pi = 3.1428571428571428571428571428571;
            double value = ((45) / (Math.PI * Math.Pow(h, 6)));
            double value3 = h - r.AbsSquare();
            return value * value3;
        }
        bool Collision_Detection_Ball(Particile Fball, Particile Sball)
        {
            Vector rad = Sball.CurrPosition - Fball.CurrPosition;
            //cout << " rad " << rad.ToString()<<" Fball "<<Fball.CurrPosition.ToString()<<" Sbal "<<Sball.CurrPosition.ToString()<<endl;
            //test let it <  it was <=
            if (rad.AbsSquare() <= Sball.Radius + Fball.Radius)
            {
                return true;
            }
            return false;
        }
        //sphere vs particile
        void CollisionHandling(Particile Fball, Particile Sball)
        {
            Vector u1 = Fball.CurrVeclocity, u2 = Sball.CurrVeclocity, v1, v2;
            double m1 = Fball.Mass, m2 = Sball.Mass;

            v1 = (u1 * (m1 - m2) + u2 * 2 * m2) / (m1 + m2);
            v2 = (u2 * (m2 - m1) + u1 * 2 * m1) / (m1 + m2);
            //cout <<" v1 "<< v1.ToString() <<" v2 "<< v2.ToString();

            Fball.CurrVeclocity = v1; Sball.CurrVeclocity = v2;
            Fball.CurrPosition = Fball.CurrPosition + (Fball.CurrVeclocity * delT);
            Sball.CurrPosition = Sball.CurrPosition + (Sball.CurrVeclocity * delT);
        }
        //Compute Surface force
        Vector Compute_Surface_force(int i)
        {
            Vector normal = new Vector(0, 0, 0), Surface_force = new Vector(), smoothed_color_field = new Vector();
            for (int j = 0; j < loopCounter; j++)
            {
                if (j == i)
                    continue;
                //compute the normal
                Vector r = p[i].CurrPosition - p[j].CurrPosition;
                if (r.AbsSquare() < h)
                {
                    normal = normal + DefaultKernalGradiant(r) * (p[j].Mass / p[j].MassDensity);
                    smoothed_color_field = smoothed_color_field + DefaultKernalLaplaciant(r) * (p[j].Mass / p[j].MassDensity);
                }

            }
            if (normal.AbsSquare() > l_threshold)
            {
                Surface_force = smoothed_color_field * (normal / normal.AbsSquare()) * -1 * Surface_Segma;
            }
            else
            {
                Surface_force = new Vector(0, 0, 0);
            }
            return Surface_force;
        }
        void Leap_Frog(int i)
        {
            // Compute Acc from force
            //old acceleration
            p[i].CurrAcceleration = (p[i].Force / p[i].Mass);
            //new acceleration with row
            //p[i].CurrAcceleration = (p[i].Force / p[i].MassDensity);

            //Compute new speed using leap frog
            p[i].CurrVeclocity = p[i].CurrVeclocity + (p[i].CurrAcceleration * delT);

            //final position full
            p[i].CurrPosition = p[i].CurrPosition + (p[i].CurrVeclocity * delT);

        }
        bool Detect_Collision_Bottom(int i, int j)
        {
            return (w[j].Normal.y == -1 && p[i].CurrPosition.y <= w[j].MidPoint.y + p[i].Radius);
        }
        bool Detect_Collision_Left_Right(int i, int j)
        {
            return (w[j].Normal.x != 0
                && ((w[j].Normal.x == 1 && p[i].CurrPosition.x >= w[j].MidPoint.x - p[i].Radius)
                    || (w[j].Normal.x == -1 && p[i].CurrPosition.x <= w[j].MidPoint.x + p[i].Radius)
                    ));
        }
        bool Detect_Collision_Front_Back(int i, int j)
        {
            return (w[j].Normal.z != 0
                && ((w[j].Normal.z == 1 && p[i].CurrPosition.z >= w[j].MidPoint.z - p[i].Radius)
                    || (w[j].Normal.z == -1 && p[i].CurrPosition.z <= w[j].MidPoint.z + p[i].Radius)
                    ));
        }
        private void Handle_Collision_Left_Right(int i, int j)
        {
            //dot
            double dottemp = p[i].CurrVeclocity.dot(w[j].Normal);
            //dot 
            Vector temp2, temp1;
            temp1 = w[j].Normal * ((-2) * dottemp) * 0.7;
            p[i].LastVelocity = p[i].CurrVeclocity;
            p[i].LastPosition = p[i].CurrPosition;
            p[i].CurrVeclocity = p[i].CurrVeclocity + temp1;
            p[i].CurrPosition = p[i].CurrPosition + p[i].CurrVeclocity * delT;
            // right
            if (w[j].Normal.x == 1 && p[i].CurrPosition.x > w[j].MidPoint.x - p[i].Radius)
                p[i].CurrPosition.x = w[j].MidPoint.x - p[i].Radius;
            // left
            if (w[j].Normal.x == -1 && p[i].CurrPosition.x < w[j].MidPoint.x + p[i].Radius)
                p[i].CurrPosition.x = w[j].MidPoint.x + p[i].Radius;

        }

        private void Handle_Collision_Front_Back(int i, int j)
        {
            //dot
            double dottemp = p[i].CurrVeclocity.dot(w[j].Normal);
            //dot 
            Vector temp2, temp1;
            temp1 = w[j].Normal * ((-2) * dottemp) * 0.7;
            p[i].LastVelocity = p[i].CurrVeclocity;
            p[i].LastPosition = p[i].CurrPosition;
            p[i].CurrVeclocity = p[i].CurrVeclocity + temp1;
            p[i].CurrPosition = p[i].CurrPosition + p[i].CurrVeclocity * delT;
            // Front
            if (w[j].Normal.z == 1 && p[i].CurrPosition.z > w[j].MidPoint.z - p[i].Radius)
                p[i].CurrPosition.z = w[j].MidPoint.z - p[i].Radius;
            // Back
            if (w[j].Normal.z == -1 && p[i].CurrPosition.z < w[j].MidPoint.z + p[i].Radius)
                p[i].CurrPosition.z = w[j].MidPoint.z + p[i].Radius;

        }

        private void Handle_Collision_Bottom(int i, int j)
        {
            //dot
            double dottemp = p[i].CurrVeclocity.dot(w[j].Normal);
            //dot 
            Vector temp2, temp1;
            temp1 = w[j].Normal * ((-2) * dottemp) * 0.7;
            p[i].LastVelocity = p[i].CurrVeclocity;
            p[i].LastPosition = p[i].CurrPosition;
            p[i].CurrVeclocity = p[i].CurrVeclocity + temp1;
            p[i].CurrPosition = p[i].CurrPosition + p[i].CurrVeclocity * delT;
            if (p[i].CurrPosition.y < w[j].MidPoint.y + p[i].Radius)
                p[i].CurrPosition.y = w[j].MidPoint.y + p[i].Radius;
        }
        Vector Compute_Collision_For_Cube(int k)
        {
            Vector collision_f = new Vector();
            for (int i = 0; i < 5; i++)
            {
                Wall wall = w[i];
                Vector wallNormal = wall.Normal * -1;
                double depth = wallNormal.dot((wall.MidPoint - cube.p[k].CurrPosition)) + p[i].Radius;//+ particle radius
                if (depth > 0.0f)
                {
                    //testing the cube velocity
                    collision_f += wallNormal * Wall.Damping * wallNormal.dot(cube.p[k].CurrVeclocity) + wallNormal * Wall.k * depth;
                }
            }
            return collision_f;
        }
        double xrot, yrot, zrot = 0;
        float movX = 0, movY = 0, movZ = 0, lX = 0, lY = 0;

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Particile.Row0_Den = double.Parse(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Particile.meo = double.Parse(textBox3.Text);
        }

        private void Inc_btn_Click(object sender, EventArgs e)
        {
            if (delT<0.0004)
            delT *= 10;
        }

        private void Dic_btn_Click(object sender, EventArgs e)
        {
            delT /= 10;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Particile.k = double.Parse(textBox4.Text);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            h = double.Parse(textBox5.Text);
        }

        private void Push_btn_Click(object sender, EventArgs e)
        {
            loopCounter = 0;
            Reset_btn.PerformClick();
            loopCounter = int.Parse(textBox1.Text);
        }
        bool kkk = false;

  
        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            for(int i=0;i<loopCounter;i++)
            {
                p[i].Mass = double.Parse(textBox6.Text);
            }
        }

        private void Cameras_Enter(object sender, EventArgs e)
        {

        }

        private void Cube_btn_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
            {
                kkk = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cube.Mass = 2.5;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cube.Mass = 10.8;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cube.Mass = 15;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void NewPar_btn_Click(object sender, EventArgs e)
        {
            q += 10;
            p[loopCounter].CurrPosition = new Vector(0.000300, -0.005000, -0.044700);
            p[loopCounter + 1].CurrPosition = new Vector(0.000300, -0.005000, -0.022200);
            p[loopCounter + 2].CurrPosition = new Vector(0.000300, -0.005000, 0.000300);
            p[loopCounter + 3].CurrPosition = new Vector(-0.067200, -0.017500, -0.067200);
            p[loopCounter + 4].CurrPosition = new Vector(-0.067200, 0.017500, -0.044700);
            p[loopCounter + 5].CurrPosition = new Vector(-0.067200, 0.017500, -0.022200);
            p[loopCounter + 6].CurrPosition = new Vector(-0.067200, 0.017500, -0.000300);
            p[loopCounter + 7].CurrPosition = new Vector(-0.044700, 0.017500, -0.067200);
            p[loopCounter + 8].CurrPosition = new Vector(-0.044700, 0.017500, -0.044700);
            p[loopCounter + 9].CurrPosition = new Vector(-0.044700, 0.017500, -0.022200);
            loopCounter += 10;
        }

        private void Reset_btn_Click(object sender, EventArgs e)
        {
            id = 0;
            kkk = false;
            cube = new Solid();
            int N = 5;
            loopCounter -= q;
            //y loop
            for (int j = 0; j <= N + 15; j++)
            {
                //x loop
                for (int i = 0; i <= N; i++)
                {
                    //z loop
                    for (int k = 0; k <= N; k++)
                    {
                        double x = -w[0].lenght / 2 + p[0].Radius + i * PARTICLE_SPACING;
                        double y = 0.1 + -w[0].lenght + j * PARTICLE_SPACING;
                        double z = -w[0].lenght / 2 + p[0].Radius + k * PARTICLE_SPACING;
                        p[id].CurrPosition = new Vector(x, y, z);
                        p[id].CurrAcceleration = new Vector(0, 0, 0);
                        p[id].CurrVeclocity = new Vector(0, 0, 0);
                        id++;

                    }

                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void simpleOpenGlControl1_KeyDown(object sender, KeyEventArgs e)
        {
            // Glu.gluLookAt(movX, movY, movZ, lX, lY, -5, 0, 1, 0);
            if (e.KeyCode == Keys.D)
                movX += 0.01f;
            if (e.KeyCode == Keys.A)
                movX -= 0.01f;
            if (e.KeyCode == Keys.W)
                movY += 0.01f;
            if (e.KeyCode == Keys.S)
                movY -= 0.01f;
            if (e.KeyCode == Keys.Z)
                movZ += 0.01f;
            if (e.KeyCode == Keys.X)
                movZ -= 0.01f;
            if (e.KeyCode == Keys.Left)
                lX += 0.4f;
            if (e.KeyCode == Keys.Right)
                lX -= 0.4f;
            if (e.KeyCode == Keys.Up)
                lY += 0.4f;
            if (e.KeyCode == Keys.Down)
                lY -= 0.4f;
            simpleOpenGlControl1.Invalidate();

        }
        void DrawWall2()
        {
            Gl.glLineWidth(4);
            for (int i = 0; i < 5; i++)
                w[i].Draw();
        }
        void DrawLib()
        {
            // Draw Back Wall
            Gl.glColor3f(1, 1, 1);
            Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_FILL);
            Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_FILL);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, wall);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0);
            Gl.glVertex3d(0.5, 0.3, -0.5);
            Gl.glTexCoord2d(1, 0);
            Gl.glVertex3d(-0.5, 0.3, -0.5);
            Gl.glTexCoord2d(1, 1);
            Gl.glVertex3d(-0.5, -0.3, -0.5);
            Gl.glTexCoord2d(0, 1);
            Gl.glVertex3d(0.5, -0.3, -0.5);
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glEnd();
            // Draw Right Wall
            Gl.glColor3f(1, 1, 1);
            Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_FILL);
            Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_FILL);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, wall);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0);
            Gl.glVertex3d(0.5, 0.3, 0.5);
            Gl.glTexCoord2d(1, 0);
            Gl.glVertex3d(0.5, 0.3, -0.5);
            Gl.glTexCoord2d(1, 1);
            Gl.glVertex3d(0.5, -0.3, -0.5);
            Gl.glTexCoord2d(0, 1);
            Gl.glVertex3d(0.5, -0.3, 0.5);
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glEnd();
            // Draw Left Wall
            Gl.glColor3f(1, 1, 1);
            Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_FILL);
            Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_FILL);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, wall);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0);
            Gl.glVertex3d(-0.5, 0.3, 0.5);
            Gl.glTexCoord2d(1, 0);
            Gl.glVertex3d(-0.5, 0.3, -0.5);
            Gl.glTexCoord2d(1, 1);
            Gl.glVertex3d(-0.5, -0.3, -0.5);
            Gl.glTexCoord2d(0, 1);
            Gl.glVertex3d(-0.5, -0.3, 0.5);
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glEnd();
            // Draw Front Wall
            Gl.glColor3f(1, 1, 1);
            Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_FILL);
            Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_FILL);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, wall);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0);
            Gl.glVertex3d(0.5, 0.3, 0.5);
            Gl.glTexCoord2d(1, 0);
            Gl.glVertex3d(-0.5, 0.3, 0.5);
            Gl.glTexCoord2d(1, 1);
            Gl.glVertex3d(-0.5, -0.3, 0.5);
            Gl.glTexCoord2d(0, 1);
            Gl.glVertex3d(0.5, -0.3, 0.5);
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glEnd();
            // Draw Ground 
            Gl.glColor3f(1, 1, 1);
            Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_FILL);
            Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_FILL);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, floor);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0);
            Gl.glVertex3d(0.5, -0.3, 0.5);
            Gl.glTexCoord2d(1, 0);
            Gl.glVertex3d(-0.5, -0.3, 0.5);
            Gl.glTexCoord2d(1, 1);
            Gl.glVertex3d(-0.5, -0.3, -0.5);
            Gl.glTexCoord2d(0, 1);
            Gl.glVertex3d(0.5, -0.3, -0.5);
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glEnd();
        }
        void DrawTable()
        {
            // Draw leg
            Gl.glColor3d(0.3882, 0.0941, 0.0594);
            Gl.glLineWidth(6);
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex3d(0.15, -0.15, 0.075);
            Gl.glVertex3d(0.15, -0.3, 0.075);
            Gl.glVertex3d(0.15, -0.15, -0.075);
            Gl.glVertex3d(0.15, -0.3, -0.075);
            Gl.glVertex3d(-0.15, -0.15, -0.075);
            Gl.glVertex3d(-0.15, -0.3, -0.075);
            Gl.glVertex3d(-0.15, -0.15, 0.075);
            Gl.glVertex3d(-0.15, -0.3, 0.075);
            Gl.glEnd();
            // Draw Table
            Gl.glColor3f(1, 1, 1);
            Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_FILL);
            Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_FILL);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, table);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            //Right Side
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0);
            Gl.glVertex3d(0.15, -0.15, 0.075);
            Gl.glTexCoord2d(1, 0);
            Gl.glVertex3d(0.075, -0.15, 0.075);
            Gl.glTexCoord2d(1, 1);
            Gl.glVertex3d(0.075, -0.15, -0.075);
            Gl.glTexCoord2d(0, 1);
            Gl.glVertex3d(0.15, -0.15, -0.075);
            Gl.glEnd();
            //Left Side
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, table);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0);
            Gl.glVertex3d(-0.15, -0.15, 0.075);
            Gl.glTexCoord2d(1, 0);
            Gl.glVertex3d(-0.075, -0.15, 0.075);
            Gl.glTexCoord2d(1, 1);
            Gl.glVertex3d(-0.075, -0.15, -0.075);
            Gl.glTexCoord2d(0, 1);
            Gl.glVertex3d(-0.15, -0.15, -0.075);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);

        }
        void Camera()
        {
            Glu.gluLookAt(movX, movY, movZ, lX, lY, -5, 0, 1, 0);
            simpleOpenGlControl1.Invalidate();
        }
       
        private void simpleOpenGlControl1_Paint_1(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT); //clear buffers to preset values
                                                                         // Gl.glClearColor(0.5f, 0.5f, 0.5f, 1);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();               // load the identity matrix
          
            if (radioCam1.Checked)
                Glu.gluLookAt(movX, movY, movZ, 0, 0, -5, 0, 1, 0);
            if (radioCam2.Checked)
            {
                Gl.glTranslated(0, -0.5, -0.1);
                 Glu.gluLookAt(movX, 0.24, 0.2, lX, -30, -5, 0, 1, 0);

            }
            Gl.glTranslated(0, +0.07, -0.27);
           
           
            //moves our figure (x,y,z)
          Glu.gluLookAt(movX, movY, movZ,lX, lY, -5, 0, 1, 0);
            // Draw Wall and Ground
            DrawLib();
          //  Console.WriteLine(movX + " " + movY + " " + movZ + " " + lX + "  " + lY);
            //  simpleOpenGlControl1.Update();
            //-------------------- Compute MassDensity For Fluid --------------------

            ComputeMassDensity();

            //-------------------- Compute MassDensity For Fluid --------------------

            //------------------------Gravity Forces for the Solid------------
            if(kkk)
            for (int i = 0; i < 27; i++)
            {
                cube.p[i].Force = new Vector(0, -9.8*cube.p[i].Mass, 0);
            }
            //------------------------Gravity Forces for the Solid------------

            //COMPUTE internal forces
            for (int i = 0; i < loopCounter; i++)
            {

                //-----------------------gravity force-------------------- 
                Vector Gravity_f = new Vector();
                //original gravity
                Gravity_f.y = -9.8;

                // -----------------------Pressure Force----------------------- 
                Vector PressForce = ComputePressureForce(p[i], i);
                //Reduced the Pressur to see the effect in a good view  
                PressForce = PressForce * p[i].Mass * 0.009;
                //------------------------Balls Pressur Force-----------------
                Vector PressurForceCommingFromBalls = new Vector(0, 0, 0);
                if(kkk)
                for (int k = 0; k < 27; k++)
                {
                    //put the clicked shite
                    if (Collision_Detection_Ball(cube.p[k], p[i]))
                    {
                        //original pressure code
                        Vector r = p[i].CurrPosition - cube.p[k].CurrPosition;
                        double temp = -1 * ( p[i].Pressure);
                        //test now using the pressure from the mrj3 
                        temp = ((temp * cube.p[k].Mass * p[i].Mass) / (p[i].MassDensity * p[i].MassDensity));

                        Vector temp2 = SpikyKernal(r);
                        temp2 = temp2 * temp;
                        PressurForceCommingFromBalls = PressurForceCommingFromBalls + temp2  ;
                        cube.p[k].Force = cube.p[k].Force + (PressurForceCommingFromBalls * -1 );
                            
                    }
                }
                // ----------------------Visco Force-----------------------------
                Vector Visco_f = new Vector();
                if (p[i].MassDensity != 0)
                    Visco_f = ComputeViscocityForce(p[i], i);
                //-----------------------Visco Comming from the Balls--------------
                Vector ViscoCommingFromtheBalls = new Vector();
                if(kkk)
                for (int k = 0; k < 27; k++)
                {
                    //put the clicked shite
                    if (Collision_Detection_Ball(cube.p[k], p[i]))
                    {
                        Vector value = cube.p[k].CurrVeclocity - p[i].CurrVeclocity;
                        //USED p[k].mass maybe i should use cube mass
                        value = value * cube.p[k].Mass * Particile.meo * ViscKernal(p[i].CurrPosition - cube.p[k].CurrPosition);
                        value = value / p[i].MassDensity;
                        ViscoCommingFromtheBalls = value ;
                       cube.p[k].Force = cube.p[k].Force + ViscoCommingFromtheBalls*-1;
                    }
                }
                //----------------------Surface Tension------------------
                Vector Surface_f = new Vector(0, 0, 0);
                if(Surface_Ten.Checked)
                Surface_f = Compute_Surface_force(i);

                // all forces
                //add the Balls pressure and the Balls Visco
                p[i].Force = Gravity_f + Visco_f + PressForce + Surface_f + PressurForceCommingFromBalls + ViscoCommingFromtheBalls;

            }
            //Leap Frog
            for (int i = 0; i < loopCounter; i++)
            {
                // Compute Acc & Veclocity & position
                Leap_Frog(i);

                //collision detection and handling
                for (int j = 0; j < 5; j++)
                {
                    if (Detect_Collision_Bottom(i, j))
                        Handle_Collision_Bottom(i, j);

                    if (Detect_Collision_Front_Back(i, j))
                        Handle_Collision_Front_Back(i, j);

                    if (Detect_Collision_Left_Right(i, j))
                        Handle_Collision_Left_Right(i, j);

                }
           
            }
            for (int i = 0; i < 27; i++)
            {
                Vector collisionForceForCube = Compute_Collision_For_Cube(i);
                cube.p[i].Force = cube.p[i].Force + collisionForceForCube;
            }
            T += delT;

            //Draw All
            DrawTable();
           
            Gl.glLineWidth(5);
            w[3].Draw();
            w[1].Draw();
            w[2].Draw();
            w[4].Draw();
            Gl.glLineWidth(1);
            if (radioCam1.Checked)
            {
                if (kkk == true)
                {
                    cube.Calculate_the_NewCM_Position();
                     
                }
                Gl.glColor3d(1, 1, 1);
                for (int i = 0; i < loopCounter; i++)
                {
                    p[i].Draw();
                }
            }
            if(radioCam2.Checked)
            {
                for (int i = 0; i < loopCounter; i++)
                {
                    p[i].Draw();
                }
                if (kkk == true)
                {
                    cube.Calculate_the_NewCM_Position();
                    //  for (int i = 0; i < 27; i++)
                    //    Collision_Box_Cube(i);
                }
            }
          
            w[0].Draw();
           

            simpleOpenGlControl1.Invalidate();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //SceneSet();
        }
    }
}
