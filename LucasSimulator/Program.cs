using System;
using System.Windows.Forms;
using CenterSpace.NMath.Core;
using LucasSimulator;

namespace MacroShockSimulation
{
    class Program
    {
        [STAThread]
        static int Main(string[] args)
        {
            //NMathConfiguration.LicenseKey = "2DB877FF4336CDB";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new XtraForm1());
            return 0;
        }
    }
}