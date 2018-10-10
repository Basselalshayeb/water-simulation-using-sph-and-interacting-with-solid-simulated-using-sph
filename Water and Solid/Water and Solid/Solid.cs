using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Water_and_Solid
{
    class Solid
    {
        public Particile[] p;
        public int N = 27;
        public double delT = 0.0005;
        public Vector L, Torque, Force_Cm, R_Cm, Curr_velocity, Curr_acceleration, angular_velecoty_w;
        public double[][] InverseInertia, InverseInertia0, Rotate, Rotate_T;
        public double  Side = 0.0078 * 6;
        public  double Mass = 15;
        public double[] quatranion = new double[4];
        //testing shite
        Vector w_by_alma = new Vector();
        Vector[] R_Local = new Vector[27];
        public double[][] InitArray(double[][] a, int r, int c)
        {
            a = new double[r][];
            for (int i = 0; i < r; i++)
            {
                a[i] = new double[c];
                for (int j = 0; j < c; j++)
                {
                    a[i][j] = new double();
                }
            }
            return a;
        }
        public Solid()
        {

            //initlize the quatranion
            for (int i = 0; i < 4; i++)
                quatranion[i] = 0;

            p = new Particile[N];
            for (int i = 0; i < 27; i++)
                p[i] = new Particile();
            int NN = 3, id2 = 0;
            //initlize ballz shite
            Vector v = new Vector(-0.05, 0, 0);
            p[0] = new Particile(-1, v, Mass/27, 0.0078, new Vector(0, 0, 0));
            //y loop
            for (int j = 0; j < NN; j++)
            {

                //x loop
                for (int i = 0; i < NN; i++)
                {
                    //z loop
                    for (int k = 0; k < NN; k++)
                    {
                        v.x = v.x + p[0].Radius * 2;
                        //Mass for the Ballz shite

                        p[id2] = new Particile(-1, v, Mass / 27, 0.0078, new Vector(0, 0, 0));

                        //  Console.WriteLine(p[id2].CurrPosition.ToString());
                        id2++;

                    }
                    v.y = v.y + p[0].Radius * 2;
                    v.x = -0.05;

                }
                v.x = -0.05;
                v.y = 0;
                v.z = v.z + p[0].Radius * 2;
            }
            InverseInertia = InitArray(InverseInertia, 3, 3);

            InverseInertia0 = InitArray(InverseInertia0, 3, 3);
            for (int i = 0; i < 3; i++)
                InverseInertia0[i][i] = 6 / (Mass * Side * Side);
            Mass = p[0].Mass * N;
            Force_Cm = new Vector();
            R_Cm = new Vector();
            L = new Vector();
            Torque = new Vector();
            R_Cm = p[13].CurrPosition;
            Curr_acceleration = new Vector();
            Curr_velocity = new Vector();
            Rotate = InitArray(Rotate, 3, 3);

            //Calculate the Rotation 
            Rotation_Calculate();

            //Rotation Transform
            TransArray();

            //initilize R_CM
            R_Cm = new Vector();
            for (int i = 0; i < 27; i++)
            {
                R_Cm += (p[i].CurrPosition * p[i].Mass);
            }
            R_Cm = R_Cm / Mass;

            //inilitze the R local
            for (int i = 0; i < 27; i++)
            {
                R_Local[i] = p[i].CurrPosition - R_Cm;
            }
        }

        //the Trans Array dont return a value it just rotate and set the Rotate_T
        public void TransArray()
        {
            Rotate_T = InitArray(Rotate_T, 3, 3);
            Rotate_T[0][0] = Rotate[0][0];
            Rotate_T[1][1] = Rotate[1][1];
            Rotate_T[2][2] = Rotate[2][2];
            Rotate_T[1][0] = Rotate[0][1];
            Rotate_T[2][0] = Rotate[0][2];
            Rotate_T[2][1] = Rotate[1][2];

        }

        //update angular momentum
        public void Update_Angulare_Momentum()
        {
            L = L + Torque * delT;
        }
        // I_1
        public void Update_Invers_Inertia()
        {
            InverseInertia = InitArray(InverseInertia, 3, 3);

            //use the multi 

            //***

            //bu using the mrj3
            double a = Rotate[0][0];
            double b = Rotate[0][1];
            double c = Rotate[0][2];
            double d = Rotate[1][0];
            double e = Rotate[1][1];
            double f = Rotate[1][2];
            double g = Rotate[2][0];
            double h = Rotate[2][1];
            double i = Rotate[2][2];
            double u = InverseInertia0[0][0];
            double v = InverseInertia0[1][1];
            double w = InverseInertia0[2][2];

            InverseInertia[0][0] = u * a * a + b * b * v + c * c * w;
            InverseInertia[0][1] = a * d * u + b * e * v + c * f * w;
            InverseInertia[0][2] = a * g * u + b * h * v + c * i * w;
            InverseInertia[1][0] = a * d * u + b * e * v + c * f * w;
            InverseInertia[1][1] = u * d * d + e * e * v + f * f * w;
            InverseInertia[1][2] = d * g * u + e * h * v + f * i * w;
            InverseInertia[2][0] = a * g * u + b * h * v + c * i * w;
            InverseInertia[2][1] = d * g * u + e * h * v + f * i * w;
            InverseInertia[2][2] = u * g * g + h * h * v + i * i * w;

        }


        //update angular velo
        public void Update_Angular_velo()
        {
            angular_velecoty_w = L * InverseInertia;
        }
        //Update Quatration 
        public void Update_qautration()
        {

            double Angular_size = angular_velecoty_w.AbsSquare();
            Vector RotatAxis = new Vector();
            if (Angular_size > 0.0)
            {
                RotatAxis = angular_velecoty_w / Angular_size;
            }
            double RotateAng = Angular_size * delT;
            double ds = Math.Cos(RotateAng / 2.0);
            Vector q = new Vector(quatranion[1], quatranion[2], quatranion[3]);
            Vector dq = RotatAxis * Math.Sin(RotateAng / 2.0);
            double s = quatranion[0];
            quatranion[0] = (s * ds - q.dot(dq));
            Vector temp = (dq * s + q * ds + dq * q);
            quatranion[1] = temp.x;
            quatranion[2] = temp.y;
            quatranion[3] = temp.z;

        }
        //Calculate the Rotate and then the quadrenion **
        public void Rotation_Calculate()
        {
            double vx = quatranion[1], vy = quatranion[2], vz = quatranion[3];
            Rotate[0][0] = 1 - 2 * Math.Pow(vy, 2) - 2 * Math.Pow(vz, 2);
            Rotate[0][1] = 2 * vx * vy - 2 * quatranion[0] * vz;
            Rotate[0][2] = 2 * vx * vz + 2 * quatranion[0] * vy;
            //Rotate[1]
            Rotate[1][0] = 2 * vx * vy + 2 * quatranion[0] * vz;
            Rotate[1][1] = 1 - 2 * vx * vx - 2 * vz * vz;
            Rotate[1][2] = 2 * vy * vz - 2 * quatranion[0] * vx;
            //Rotate[2]
            Rotate[2][0] = 2 * vx * vz - 2 * quatranion[0] * vy;
            Rotate[2][1] = 2 * vy * vz + 2 * quatranion[0] * vx;
            Rotate[2][2] = 1 - 2 * vx * vx - 2 * vy * vy;


        }
        //new way to calculate the W from Amal's report
        public void Calculate_New_AngularVelocity_W()
        {
            double I = 0;//;6/(Mass*Side*Side);

            for (int i = 0; i < 27; i++)
            {
                Vector relative = p[i].CurrPosition - R_Cm;
                I = I + p[i].Mass * (relative.AbsSquare() * relative.AbsSquare());
            }
            w_by_alma = L / I;

        }
        //Calculate the Force of the Solid CM and then the acceleration and the the velocity
        public void Calculate_the_NewCM_Position()
        {
            Force_Cm = new Vector(0, 0, 0);
            Torque = new Vector(0, 0, 0);
            for (int i = 0; i < N; i++)
            {
                //all particles
                Force_Cm = Force_Cm + p[i].Force;

                //calculate the Torque
                Torque = Torque + p[i].Force * (p[i].CurrPosition - R_Cm);
            }
            // Leap Frog + Collotion handling for Soild + L
            //acceleration for CM
            //Console.WriteLine(Mass.ToString());
            Curr_acceleration = (Force_Cm / Mass);

            //Compute new speed using leap frog for CM
            Curr_velocity = Curr_velocity + (Curr_acceleration * delT);

            //final position CM 
            R_Cm = R_Cm + (Curr_velocity * delT);



            //update angular momentum L
            Update_Angulare_Momentum();

            //update Inverse inertia I_1
            // Update_Invers_Inertia();

            //update angular velo w
            // Update_Angular_velo();

            //updateQuatration
            // Update_qautration();

            //Calculate the Rotation 
            // Rotation_Calculate();

            //Rotation Transform
            // TransArray();

            //new way to calculate the W from Amal's report
            Calculate_New_AngularVelocity_W();

            //Calculate the new Position of the Particiles
            for (int i = 0; i < 27; i++)
            {
                Vector relative_position = p[i].CurrPosition - R_Cm;
                //Original Code is Multi by angularVelocity_W // replaced with w by alma 
                //Original Code +1  used to have the relative pos now it have steady initial relative pos
                p[i].CurrVeclocity = Curr_velocity + relative_position * w_by_alma; //relative_position*angular_velecoty_w;//*W the angular momentom
                p[i].CurrPosition = p[i].CurrPosition + (p[i].CurrVeclocity * delT);
            }
            Draw();
        }

        double[][] Result;

        public double[][] Multi_Array(double[][] a, double[][] b, int r1, int c1, int c2)
        {
            Result = InitArray(Result, r1, c2);
            for (int i = 0; i < 3; i++) Result[i] = new double[3];
            for (int i = 0; i < r1; i++)
                for (int j = 0; j < c2; j++)
                    for (int k = 0; k < c1; k++)
                    {
                        Result[i][j] += a[i][k] * b[k][j];
                    }
            return Result;
        }
        public void Draw()
        {
            for (int i = 0; i < 27; i++)
            {
                p[i].Draw();
                //  Console.WriteLine(p[i].CurrPosition.ToString());
            }
        }
    }
}
