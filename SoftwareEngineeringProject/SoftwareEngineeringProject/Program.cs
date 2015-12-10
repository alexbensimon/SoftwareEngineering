using System;
using System.Windows.Forms;

namespace SoftwareEngineeringProject
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new MainWindow());
        }
    }
}
