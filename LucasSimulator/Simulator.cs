
using System;
using System.Collections.Generic;

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

        private List<double> gList;
        private List<double> gStarList;
        private List<double> dList;
        // TODO : make struct for init params
        public Simulator(double lambdaOne, double lambdaTwo,
            double lambdaStarOne, double lambdaStarTwo,
            double gOne, double gTwo,
            double gStarOne, double gStarTwo,
            double nominalExchange, double forwardPremium,
            double forwardPayoff, double riskPremium,
            double theta, double gamma)
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
            this.theta = theta;
            //
            CalculatePossibleStateValues();
        }

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
        }
    }
}
