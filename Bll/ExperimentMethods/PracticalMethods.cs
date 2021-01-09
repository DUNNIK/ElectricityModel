using System;
using Bll.DataMethods;
using Data;

namespace Bll.ExperimentMethods
{
    public static class PracticalMethods
    {
        private static void CalculateFMax()
        {
            PracticalData.FMax = double.Parse(FindExperimentWithUcResR1().F);
        }

        private static void CalculateQ1R1()
        {
            PracticalData.Q1R1 = double.Parse(FindExperimentWithUcResR1().Uc) / 5;
        }

        private static void CalculateQ2R2()
        {
            PracticalData.Q2R2 = double.Parse(FindExperimentWithUcResR2().Uc) / 5;
        }

        private static void CalculateΩrR1()
        {
            PracticalData.ΩrR1 = double.Parse(FindExperimentWithUrResR1().Ω);
        }

        private static void CalculateΩcR1()
        {
            PracticalData.ΩcR1 = double.Parse(FindExperimentWithUcResR1().Ω);
        }

        private static void CalculateΩlR1()
        {
            PracticalData.ΩlR1 = double.Parse(FindExperimentWithUlResR1().Ω);
        }

        private static void CalculateΩrR3()
        {
            PracticalData.ΩrR3 = double.Parse(FindExperimentWithUrResR2().Ω);
        }

        private static void CalculateΩcR3()
        {
            PracticalData.ΩcR3 = double.Parse(FindExperimentWithUcResR2().Ω);
        }

        private static void CalculateΩlR3()
        {
            PracticalData.ΩlR3 = double.Parse(FindExperimentWithUlResR2().Ω);
        }

        public static void AllPracticalCommands()
        {
            CalculateFMax();
            CalculateQ1R1();
            CalculateQ2R2();
            CalculateΩrR1();
            CalculateΩcR1();
            CalculateΩlR1();
            CalculateΩrR3();
            CalculateΩcR3();
            CalculateΩlR3();
        }

        private static Experiment FindExperimentWithUcResR1()
        {
            Experiment result = null;
            var ucResult = double.MinValue;
            foreach (var mappingResult in DataController.GetFirstData())
            {
                if (double.Parse(mappingResult.Result.Uc) >= ucResult)
                {
                    ucResult = double.Parse(mappingResult.Result.Uc);
                    result = mappingResult.Result;
                }
            }
            return result;
        }

        private static Experiment FindExperimentWithUlResR1()
        {
            Experiment result = null;
            var ulResult = double.MinValue;
            foreach (var mappingResult in DataController.GetFirstData())
            {
                if (double.Parse(mappingResult.Result.Ul) >= ulResult)
                {
                    ulResult = double.Parse(mappingResult.Result.Ul);
                    result = mappingResult.Result;
                }
            }
            return result;
        }

        private static Experiment FindExperimentWithUrResR1()
        {
            Experiment result = null;
            var urResult = double.MinValue;
            foreach (var mappingResult in DataController.GetFirstData())
            {
                if (double.Parse(mappingResult.Result.Ur) >= urResult)
                {
                    urResult = double.Parse(mappingResult.Result.Ur);
                    result = mappingResult.Result;
                }
            }
            return result;
        }

        private static Experiment FindExperimentWithUcResR2()
        {
            Experiment result = null;
            var ucResult = double.MinValue;
            foreach (var mappingResult in DataController.GetSecondData())
            {
                if (double.Parse(mappingResult.Result.Uc) >= ucResult)
                {
                    ucResult = double.Parse(mappingResult.Result.Uc);
                    result = mappingResult.Result;
                }
            }
            return result;
        }

        private static Experiment FindExperimentWithUlResR2()
        {
            Experiment result = null;
            var ulResult = double.MinValue;
            foreach (var mappingResult in DataController.GetSecondData())
            {
                if (double.Parse(mappingResult.Result.Ul) >= ulResult)
                {
                    ulResult = double.Parse(mappingResult.Result.Ul);
                    result = mappingResult.Result;
                }
            }
            return result;
        }

        private static Experiment FindExperimentWithUrResR2()
        {
            Experiment result = null;
            var urResult = double.MinValue;
            foreach (var mappingResult in DataController.GetSecondData())
            {
                if (double.Parse(mappingResult.Result.Ur) >= urResult)
                {
                    urResult = double.Parse(mappingResult.Result.Ur);
                    result = mappingResult.Result;
                }
            }
            return result;
        }
    }
}