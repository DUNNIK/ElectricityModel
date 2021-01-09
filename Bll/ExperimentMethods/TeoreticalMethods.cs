using System;
using Data;

namespace Bll.ExperimentMethods
{
    public static class TeoreticalMethods
    {
        private static void CalculateFMax(double l, double c)
        {
            TeoreticalData.FMax = 1 / (2 * Math.PI * Math.Sqrt(l * c/1000000000000000))/1000;
        }

        private static void CalculateQ1R1(double l, double c)
        {
            TeoreticalData.Q1R1 = Math.Sqrt(l / 1000000) / (1 * Math.Sqrt(c / 1000000000));
        }

        private static void CalculateQ2R2(double l, double c)
        {
            TeoreticalData.Q2R2 = Math.Sqrt(l / 1000000) / (3 * Math.Sqrt(c / 1000000000));
        }

        private static void CalculateΩrR1(double l, double c)
        {
            TeoreticalData.ΩrR1 = 1 / Math.Sqrt(l * c / 1000000000000000) / 1000;
        }

        private static void CalculateΩcR1(double l, double c)
        {
            TeoreticalData.ΩcR1 =
                Math.Sqrt(1 - 2 * Math.Pow(1 * Math.Sqrt(l * c / 1000000000000000) / (2 * l / 1000000),
                    2)) / Math.Sqrt(l * c / 1000000000000000) / 1000;
        }

        private static void CalculateΩlR1(double l, double c)
        {
            TeoreticalData.ΩlR1 =
                1 / (Math.Sqrt(l * c / 1000000000000000) * Math.Sqrt(1 - 2 *
                    Math.Pow(1 * Math.Sqrt(l * c / 1000000000000000) / (2 * l / 1000000),
                        2))) / 1000;
        }

        private static void CalculateΩrR3(double l, double c)
        {
            TeoreticalData.ΩrR3 = 1 / Math.Sqrt(l * c / 1000000000000000) / 1000;
        }

        private static void CalculateΩcR3(double l, double c)
        {
            TeoreticalData.ΩcR3 =
                Math.Sqrt(1 - 2 * Math.Pow(3 * Math.Sqrt(l * c / 1000000000000000) / (2 * l / 1000000),
                    2)) / Math.Sqrt(l * c / 1000000000000000) / 1000;
        }

        private static void CalculateΩlR3(double l, double c)
        {
            TeoreticalData.ΩlR3 =
                1 / (Math.Sqrt(l * c / 1000000000000000) * Math.Sqrt(1 - 2 *
                    Math.Pow(3 * Math.Sqrt(l * c / 1000000000000000) / (2 * l / 1000000),
                        2))) / 1000;
        }

        public static void AllTeoreticalCommands(double l, double c)
        {
            CalculateFMax(l, c);
            CalculateQ1R1(l, c);
            CalculateQ2R2(l, c);
            CalculateΩrR1(l, c);
            CalculateΩcR1(l, c);
            CalculateΩlR1(l, c);
            CalculateΩrR3(l, c);
            CalculateΩcR3(l, c);
            CalculateΩlR3(l, c);
        }
    }
}