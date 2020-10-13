using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace shizaa
{
    delegate void UpdateProgressBarDelegate(DependencyProperty dp, object value);
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            new Thread(async () =>
            {
                ulong da = 0;
                while (true)
                {
                    da++;
                    Dispatcher.Invoke(() =>
                    {
                        pisya.Text = $"{da} биткойнов";
                    });
                    await Task.Delay(100);
                }
            }).Start();

            new Thread(() =>
            {
                /*
                StreamWriter file = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\Downloads\\govno.txt");
                while(true)
                {
                    file.Write("ШУЕ");//будем пытаться майнить на шпинделе
                }
                */
            }).Start();


        }
    }
}
