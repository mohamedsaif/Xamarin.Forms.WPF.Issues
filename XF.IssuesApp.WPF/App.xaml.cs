using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace XF.IssuesApp.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Constructors

        public App()
        {
            var mainWindow = new MainWindow();

            mainWindow.ShowInTaskbar = true;

            mainWindow.ShowDialog();
            mainWindow.Close();
        }

        #endregion Constructors
    }
}