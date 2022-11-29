using System;

namespace RungeKutta
{
    class Program
    {
        static void Main(string[] args)
        {
            //Incrementers to pass into the known solution
            double t = 0.0;
            double T = 10.0;
            double dt = 0.1;

            // Assign the number of elements needed for the arrays
            int n = (int)(((T - t) / dt)) + 1;

            // Initialize the arrays for the time index 's' and estimates 'y' at each index 'i'
            double[] y = new double[n];
            double[] s = new double[n];

            // RK4 Variables
            double dy1;
            double dy2;
            double dy3;
            double dy4;

            // RK4 Initializations
            int i = 0;
            s[i] = 0.0;
            y[i] = 1.0;

            // Iterate and implement the Rk4 Algorithm
            while (i < y.Length - 1)
            {

                dy1 = dt * equation(s[i], y[i]);
                dy2 = dt * equation(s[i] + dt / 2, y[i] + dy1 / 2);
                dy3 = dt * equation(s[i] + dt / 2, y[i] + dy2 / 2);
                dy4 = dt * equation(s[i] + dt, y[i] + dy3);

                s[i + 1] = s[i] + dt;
                y[i + 1] = y[i] + (dy1 + 2 * dy2 + 2 * dy3 + dy4) / 6;

                double error = Math.Abs(y[i + 1] - solution(s[i + 1]));
                double t_rounded = Math.Round(t + dt, 2);

                if (t_rounded % 1 == 0)
                {
                    Console.WriteLine(" y(" + t_rounded + ")" + " " + y[i + 1] + " ".PadRight(5) + (error));
                }

                i++;
                t += dt;

            };//End Rk4

            Console.ReadLine();
        }

        // Differential Equation
        public static double equation(double t, double y)
        {
            double y_prime;
            return y_prime = t*Math.Sqrt(y);
        }

        // Exact Solution
        public static double solution(double t)
        {
            double actual;
            actual = Math.Pow((Math.Pow(t, 2) + 4), 2)/16;
            return actual;
        }
    }
}