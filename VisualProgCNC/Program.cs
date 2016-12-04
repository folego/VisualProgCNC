using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Fiori.Windows.VisualProgCNC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmPrincipal());

            // Apagar todos os diretórios temporários
            string [] _diretorios = Directory.GetDirectories(Application.StartupPath);

            foreach (string _diretorio in _diretorios)
            {
                if (_diretorio.Substring(_diretorio.Length - 3, 3) == "tmp")
                {
                    try
                    {
                        Directory.Delete(_diretorio, true);
                    }
                    catch (IOException)
                    {
                    }
                }
            }
        }
    }
}