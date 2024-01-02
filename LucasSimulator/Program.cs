using System;
using System.Windows.Forms;
using LucasSimulator;

namespace MacroShockSimulation
{
    class Program
    {
        [STAThread]
        static int Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new XtraForm1());
            return 0;
        }
    }
}