using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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


namespace Opdrag4C
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string pathName;
        public bool recording = false;
        int counter = 0;
        private LowLevelKeyboardListener _listener;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _listener = new LowLevelKeyboardListener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;

            _listener.HookKeyboard();

            Microsoft.Win32.OpenFileDialog dlg= new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();
            pathName = dlg.FileName;
        }

        public void _listener_OnKeyPressed(Object sender, KeyPressedArgs e)
        {
            if ((e.KeyPressed== Key.LeftCtrl)&& (e.KeyPressed == Key.LeftShift)&& (e.KeyPressed == Key.R))
            {
                if (recording)
                {
                    recording = false;
                }
                else
                {
                    recording = true;
                }
               
            }


            if (recording)
            {
                using (Stream str = new FileStream(pathName, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(str))
                    {
                        if (!(e.KeyPressed == Key.LeftCtrl || e.KeyPressed == Key.LeftShift))
                        {
                            writer.Write(e.KeyPressed.ToString().ToLower());
                        }
                        else if (e.KeyPressed==Key.LeftShift && e.KeyPressed != Key.HanjaMode)
                        {
                            if (e.KeyPressed != Key.LeftShift)
                                writer.Write(e.KeyPressed.ToString().ToUpper());
                        }
                    }
                }
            }
        }
    }
}
