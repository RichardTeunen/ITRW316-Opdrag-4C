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
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Opdrag4C
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string pathName;
        public bool recording = false;
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

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();
            pathName = dlg.FileName;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
        }

        public void _listener_OnKeyPressed(Object sender, KeyPressedArgs e)
        {
            /* if (Keyboard.GetKeyStates(Key.LeftCtrl) == KeyStates.Down && Keyboard.GetKeyStates(Key.LeftShift) == KeyStates.Down 
                 && e.KeyPressed == Key.R)*/
            //if(e.KeyPressed == Key.PageUp&& e.KeyPressed== Key.PageDown)
            if ((Keyboard.GetKeyStates(Key.PageUp) == KeyStates.Down && e.KeyPressed==Key.PageDown) || (Keyboard.GetKeyStates(Key.PageDown) == KeyStates.Down && e.KeyPressed == Key.PageUp))
            {
                if (recording)
                {
                    System.Windows.Forms.MessageBox.Show("Recording halted");
                    recording = false;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Recording");
                    recording = true;
                }                  
            }

            int posX = System.Windows.Forms.Cursor.Position.X,
                posY = System.Windows.Forms.Cursor.Position.Y;

            switch (e.KeyPressed)
            {
                case Key.Left:
                    System.Windows.Forms.Cursor.Position = new System.Drawing.Point(posX - 10, posY);
                    break;
                case Key.Right:
                    System.Windows.Forms.Cursor.Position = new System.Drawing.Point(posX + 10, posY);
                    break;
                case Key.Up:
                    System.Windows.Forms.Cursor.Position = new System.Drawing.Point(posX, posY - 10);
                    break;
                case Key.Down:
                    System.Windows.Forms.Cursor.Position = new System.Drawing.Point(posX, posY + 10);
                    break;
                default:
                    break;
            }
            if (recording)
            {
                using (Stream str = new FileStream(pathName, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(str))
                    {
                        if (!(e.KeyPressed == Key.LeftCtrl || Keyboard.GetKeyStates(Key.LeftShift) == KeyStates.Down || Keyboard.GetKeyStates(Key.RightShift) == KeyStates.Down))
                        {
                            writer.Write(e.KeyPressed.ToString().ToLower() + " ");
                        }
                        else if (Keyboard.GetKeyStates(Key.LeftShift) == KeyStates.Down && e.KeyPressed != Key.HanjaMode)
                        {
                            if (e.KeyPressed != Key.RightShift || e.KeyPressed != Key.LeftShift)
                                writer.Write(e.KeyPressed.ToString().ToUpper() +" ");//Will caps the key that you enter into the text file
                        }
                    }
                }

               
            }
        }
    }
}
