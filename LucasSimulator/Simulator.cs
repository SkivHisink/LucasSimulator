
using System;
using System.Collections.Generic;
using System.ComponentModel;
using CenterSpace.NMath.Core;

namespace LucasSimulator
{
    internal class Simulator
    {
        private double lambdaOne;
        private double lambdaTwo;
        private double lambdaStarOne;
        private double lambdaStarTwo;
        private double gOne;
        private double gTwo;
        private double gStarOne;
        private double gStarTwo;
        private double nominalExchange;
        private double forwardPremium;
        private double forwardPayoff;
        private double riskPremium;

        private double theta;
        private double gamma;
        private double beta;

        private double[,] transitionMatrix;

        private List<double> gList;
        private List<double> gStarList;
        private List<double> dList;
        private List<double> bList;
        private List<double> bStarList;
        private List<double> riskList;

        public Simulator()
        {

        }
        // TODO : make struct for init params
        public Simulator(double lambdaOne, double lambdaTwo,
            double lambdaStarOne, double lambdaStarTwo,
            double gOne, double gTwo,
            double gStarOne, double gStarTwo,
            double nominalExchange, double forwardPremium,
            double forwardPayoff, double riskPremium, double beta,
            double theta, double gamma, double[,] transitionMatrix)
        {
            this.lambdaOne = lambdaOne;
            this.lambdaTwo = lambdaTwo;
            this.lambdaStarOne = lambdaStarOne;
            this.lambdaStarTwo = lambdaStarTwo;
            this.gOne = gOne;
            this.gTwo = gTwo;
            this.gStarOne = gStarOne;
            this.gStarTwo = gStarTwo;
            this.nominalExchange = nominalExchange;
            this.forwardPremium = forwardPremium;
            this.forwardPayoff = forwardPayoff;
            this.riskPremium = riskPremium;
            this.beta = beta;
            this.gamma = gamma;
            this.theta = theta;
            this.transitionMatrix = transitionMatrix;
            //
            CalculatePossibleStateValues();
            //
        }


        /// <summary>
        /// Calculation of possible states
        /// </summary>
        private void CalculatePossibleStateValues()
        {
            gList = new List<double>
            {
                Math.Pow(Math.Pow(gOne, theta) * Math.Pow(gStarOne, 1 - theta), 1 - gamma) / lambdaOne,
                Math.Pow(Math.Pow(gOne, theta) * Math.Pow(gStarTwo, (1 - theta)), (1 - gamma)) / lambdaOne,
                Math.Pow(Math.Pow(gTwo, theta) * Math.Pow(gStarOne, (1 - theta)), (1 - gamma)) / lambdaOne,
                Math.Pow(Math.Pow(gTwo, theta) * Math.Pow(gStarTwo, (1 - theta)), (1 - gamma)) / lambdaOne,
                Math.Pow(Math.Pow(gOne, theta) * Math.Pow(gStarOne, (1 - theta)), (1 - gamma)) / lambdaOne,
                Math.Pow(Math.Pow(gOne, theta) * Math.Pow(gStarTwo, (1 - theta)), (1 - gamma)) / lambdaOne,
                Math.Pow(Math.Pow(gTwo, theta) * Math.Pow(gStarOne, (1 - theta)), (1 - gamma)) / lambdaOne,
                Math.Pow(Math.Pow(gTwo, theta) * Math.Pow(gStarTwo, (1 - theta)), (1 - gamma)) / lambdaOne,
                Math.Pow(Math.Pow(gOne, theta) * Math.Pow(gStarOne, (1 - theta)), (1 - gamma)) / lambdaTwo,
                Math.Pow(Math.Pow(gOne, theta) * Math.Pow(gStarTwo, (1 - theta)), (1 - gamma)) / lambdaTwo,
                Math.Pow(Math.Pow(gTwo, theta) * Math.Pow(gStarOne, (1 - theta)), (1 - gamma)) / lambdaTwo,
                Math.Pow(Math.Pow(gTwo, theta) * Math.Pow(gStarTwo, (1 - theta)), (1 - gamma)) / lambdaTwo,
                Math.Pow(Math.Pow(gOne, theta) * Math.Pow(gStarOne, (1 - theta)), (1 - gamma)) / lambdaTwo,
                Math.Pow(Math.Pow(gOne, theta) * Math.Pow(gStarTwo, (1 - theta)), (1 - gamma)) / lambdaTwo,
                Math.Pow(Math.Pow(gTwo, theta) * Math.Pow(gStarOne, (1 - theta)), (1 - gamma)) / lambdaTwo,
                Math.Pow(Math.Pow(gTwo, theta) * Math.Pow(gStarTwo, (1 - theta)), (1 - gamma)) / lambdaTwo
            };
            gStarList = new List<double>
            {
                Math.Pow(Math.Pow(gOne, theta) * Math.Pow(gStarOne, (1 - theta)), (1 - gamma)) / lambdaStarOne,
                Math.Pow(Math.Pow(gOne, theta) * Math.Pow(gStarTwo, (1 - theta)), (1 - gamma)) / lambdaStarOne,
                Math.Pow(Math.Pow(gTwo, theta) * Math.Pow(gStarOne, (1 - theta)), (1 - gamma)) / lambdaStarOne,
                Math.Pow(Math.Pow(gTwo, theta) * Math.Pow(gStarTwo, (1 - theta)), (1 - gamma)) / lambdaStarOne,
                Math.Pow(Math.Pow(gOne, theta) * Math.Pow(gStarOne, (1 - theta)), (1 - gamma)) / lambdaStarTwo,
                Math.Pow(Math.Pow(gOne, theta) * Math.Pow(gStarTwo, (1 - theta)), (1 - gamma)) / lambdaStarTwo,
                Math.Pow(Math.Pow(gTwo, theta) * Math.Pow(gStarOne, (1 - theta)), (1 - gamma)) / lambdaStarTwo,
                Math.Pow(Math.Pow(gTwo, theta) * Math.Pow(gStarTwo, (1 - theta)), (1 - gamma)) / lambdaStarTwo,
                Math.Pow(Math.Pow(gOne, theta) * Math.Pow(gStarOne, (1 - theta)), (1 - gamma)) / lambdaStarOne,
                Math.Pow(Math.Pow(gOne, theta) * Math.Pow(gStarTwo, (1 - theta)), (1 - gamma)) / lambdaStarOne,
                Math.Pow(Math.Pow(gTwo, theta) * Math.Pow(gStarOne, (1 - theta)), (1 - gamma)) / lambdaStarOne,
                Math.Pow(Math.Pow(gTwo, theta) * Math.Pow(gStarTwo, (1 - theta)), (1 - gamma)) / lambdaStarOne,
                Math.Pow(Math.Pow(gOne, theta) * Math.Pow(gStarOne, (1 - theta)), (1 - gamma)) / lambdaStarTwo,
                Math.Pow(Math.Pow(gOne, theta) * Math.Pow(gStarTwo, (1 - theta)), (1 - gamma)) / lambdaStarTwo,
                Math.Pow(Math.Pow(gTwo, theta) * Math.Pow(gStarOne, (1 - theta)), (1 - gamma)) / lambdaStarTwo,
                Math.Pow(Math.Pow(gTwo, theta) * Math.Pow(gStarTwo, (1 - theta)), (1 - gamma)) / lambdaStarTwo
            };
            dList = new List<double>
            {
                lambdaOne / lambdaStarOne,
                lambdaOne / lambdaStarOne,
                lambdaOne / lambdaStarOne,
                lambdaOne / lambdaStarOne,
                lambdaOne / lambdaStarTwo,
                lambdaOne / lambdaStarTwo,
                lambdaOne / lambdaStarTwo,
                lambdaOne / lambdaStarTwo,
                lambdaTwo / lambdaStarOne,
                lambdaTwo / lambdaStarOne,
                lambdaTwo / lambdaStarOne,
                lambdaTwo / lambdaStarOne,
                lambdaTwo / lambdaStarTwo,
                lambdaTwo / lambdaStarTwo,
                lambdaTwo / lambdaStarTwo,
                lambdaTwo / lambdaStarTwo
            };
            bList = new List<double>();
            bStarList = new List<double>();
            riskList = new List<double>();
            for (int i = 0; i < 16; i++)
            {
                bList.Add(0.0);
                bStarList.Add(0.0);
                riskList.Add(0.0);
                for (int j = 0; j < 16; j++)
                {
                    bList[i] += transitionMatrix[i, j] * gList[j];
                    bStarList[i] += transitionMatrix[i, j] * gStarList[j];
                    riskList[i] += transitionMatrix[i, j] * dList[j];
                }

                bList[i] *= beta;
                bStarList[i] *= beta;
                riskList[i] -= bStarList[i] / bList[i];
            }
        }

        public List<SimulationStepResult> Simulate(int t)
        {
            var result = new List<SimulationStepResult>();
            // Initial Conditions
            result.Add(new SimulationStepResult
            {
                Id = 0,
                RandValue = -1,
                D = 0,
                B = 0,
                BStar = 0,
                St = 1,
                StDevide = nominalExchange,
                Ft = 1,
                FtDevide = forwardPremium,
                FtMinusStDevide = forwardPayoff,
                EtFtMinusStDevide = riskPremium,
                NominalInterestRateNext = 0,
                NominalInterestRateNextStar = 0,
                NominalRelation = 0,
                CoveredInterestParitet = false
            });
            int seed = 2;
            Random rnd = new Random(seed);
            for (int i = 1; i < t; i++)
            {
                var stepResult = new SimulationStepResult();
                stepResult.Id = i;
                // Generating Random Value for getting random state
                stepResult.RandValue = rnd.Next(0, 16);
                int indx = stepResult.RandValue;
                // Random states
                stepResult.D = dList[indx];
                stepResult.B = bList[indx];
                stepResult.BStar = bStarList[indx];
                stepResult.Risk = riskList[indx];
                // Calculating necessary variable
                // From page 122 Mark Chapter 4 "The Lucas Model"
                stepResult.StDevide = (1.0 - theta) * stepResult.D / theta;
                stepResult.St = stepResult.StDevide * result[i - 1].St;
                stepResult.Ft = stepResult.StDevide * stepResult.BStar / stepResult.B;
                stepResult.FtDevide = stepResult.Ft / stepResult.StDevide;
                stepResult.FtMinusStDevide = stepResult.BStar / stepResult.B - stepResult.StDevide;
                stepResult.EtFtMinusStDevide = stepResult.Risk;
                stepResult.NominalInterestRateNext = 1.0 / stepResult.B;
                stepResult.NominalInterestRateNextStar = 1.0 / stepResult.BStar;
                stepResult.NominalRelation =
                    stepResult.NominalInterestRateNext / stepResult.NominalInterestRateNextStar;
                stepResult.CoveredInterestParitet = (stepResult.FtDevide - stepResult.NominalRelation < 1e-3);
                //
                result.Add(stepResult);
            }
            return result;
        }

        public (List<Populaster>, List<Populaster>) CalculatePriceDividendMatricies()
        {
            var result = new List<Populaster>();
            var resultStar = new List<Populaster>();
            var sum_table = new double[16, 16];
            // Find sum table
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    for (int n = 0; n < j + 1; n++)
                    {
                        sum_table[i, j] += transitionMatrix[i, n];
                    }
                }
            }
            // Get values for each state 
            // TODO : Add ability to use simulation result by searching necessary values except calculating it
            var ftMinusStDevideList = new List<double>();
            var ftDevideList = new List<double>();
            var stDevideList = new List<double>();
            var etStDevideList = new List<double>();
            var etFtMinusStDevideList = new List<double>();
            var lambdaGList = new List<double>();
            var lambdaGStarList = new List<double>();
            for (int i = 0; i < 16; i++)
            {
                ftDevideList.Add(bStarList[i] / bList[i]);
                etStDevideList.Add(riskList[i] + ftDevideList[i]);
                stDevideList.Add(dList[i]);
                ftMinusStDevideList.Add(ftDevideList[i] - etStDevideList[i]);
                etFtMinusStDevideList.Add(ftMinusStDevideList[i] - stDevideList[i]);
                if (i < 8)
                {
                    lambdaGList.Add(gList[i] * lambdaOne);
                    if (i < 4)
                    {
                        lambdaGStarList.Add(gStarList[i] * lambdaStarOne);
                    }
                    else
                    {
                        lambdaGStarList.Add(gStarList[i] * lambdaStarTwo);
                    }
                }
                else
                {
                    lambdaGList.Add(gList[i] * lambdaTwo);
                    if (i < 12)
                    {
                        lambdaGStarList.Add(gStarList[i] * lambdaStarOne);
                    }
                    else
                    {
                        lambdaGStarList.Add(gStarList[i] * lambdaStarTwo);
                    }
                }
            }
            DoubleMatrix resultMatrix = new DoubleMatrix(16, 16);
            DoubleMatrix resultStarMatrix = new DoubleMatrix(16, 16);
            DoubleMatrix eyeMatrix = new DoubleMatrix(16, 16);
            for (int i = 0; i < 16; i++)
            {
                eyeMatrix[i, i] = 1;
            }

            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    resultMatrix[i, j] = transitionMatrix[i, j] * lambdaGList[i] * beta;
                    resultStarMatrix[i, j] = transitionMatrix[i, j] * lambdaGStarList[i] * beta;
                }
            }

            resultMatrix = eyeMatrix - resultMatrix;
            resultStarMatrix = eyeMatrix - resultStarMatrix;
            resultMatrix = NMathFunctions.Inverse(resultMatrix);
            resultStarMatrix = NMathFunctions.Inverse(resultStarMatrix);
            for (int i = 0; i < 16; i++)
            {
                result.Add(new Populaster
                (
                    i + 1,
                    resultMatrix[i, 0],
                    resultMatrix[i, 1],
                    resultMatrix[i, 2],
                    resultMatrix[i, 3],
                    resultMatrix[i, 4],
                    resultMatrix[i, 5],
                    resultMatrix[i, 6],
                    resultMatrix[i, 7],
                    resultMatrix[i, 8],
                    resultMatrix[i, 9],
                    resultMatrix[i, 10],
                    resultMatrix[i, 11],
                    resultMatrix[i, 12],
                    resultMatrix[i, 13],
                    resultMatrix[i, 14],
                    resultMatrix[i, 15]
                ));
                resultStar.Add(new Populaster
                (
                    i + 1,
                    resultStarMatrix[i, 0],
                    resultStarMatrix[i, 1],
                    resultStarMatrix[i, 2],
                    resultStarMatrix[i, 3],
                    resultStarMatrix[i, 4],
                    resultStarMatrix[i, 5],
                    resultStarMatrix[i, 6],
                    resultStarMatrix[i, 7],
                    resultStarMatrix[i, 8],
                    resultStarMatrix[i, 9],
                    resultStarMatrix[i, 10],
                    resultStarMatrix[i, 11],
                    resultStarMatrix[i, 12],
                    resultStarMatrix[i, 13],
                    resultStarMatrix[i, 14],
                    resultStarMatrix[i, 15]
                ));
            }
            return (result, resultStar);
        }
    }

    public class SimulationStepResult
    {
        [DisplayName("id")]
        public int Id { get; set; }
        [DisplayName("Random")]
        public int RandValue { get; set; }
        [DisplayName("d")]
        public double D { get; set; }
        [DisplayName("b")]
        public double B { get; set; }
        [DisplayName("b*")]
        public double BStar { get; set; }
        [DisplayName("Risk premium")]
        public double Risk { get; set; }
        [DisplayName("S_t")]
        public double St { get; set; }
        [DisplayName("S_(t+1)/S_t")]
        public double StDevide { get; set; }
        [DisplayName("F_t")]
        public double Ft { get; set; }
        [DisplayName("F_t/S_t")]
        public double FtDevide { get; set; }
        [DisplayName("(F_t-S_(t+1))/S_t")]
        public double FtMinusStDevide { get; set; }
        [DisplayName("E_t[(F_t-S_(t+1))/S_t]")]
        public double EtFtMinusStDevide { get; set; }
        [DisplayName("Nominal interest rate 1+i")]
        public double NominalInterestRateNext { get; set; }
        [DisplayName("Nominal interest rate 1+i*")]
        public double NominalInterestRateNextStar { get; set; }
        [DisplayName("Rate relation")]
        public double NominalRelation { get; set; }
        [DisplayName("CIP")]
        public bool CoveredInterestParitet { get; set; }
    }
}
