﻿using System;
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
            NativeMethods.SetCursorPos(300, 300);
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

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };

        public static Point GetMousePosition()
        {
            Win32Point w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }

        public partial class NativeMethods
        {
            [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "SetCursorPos")]
            [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
            public static extern bool SetCursorPos(int X, int Y);
        }

        public void _listener_OnKeyPressed(Object sender, KeyPressedArgs e)
        {
            if ((e.KeyPressed == Key.LeftCtrl) && (e.KeyPressed == Key.LeftShift) && (e.KeyPressed == Key.R))
            {
                if (recording)
                    recording = false;
                else
                    recording = true;
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
                        else if (e.KeyPressed == Key.LeftShift && e.KeyPressed != Key.HanjaMode)
                        {
                            if (e.KeyPressed != Key.LeftShift)
                                writer.Write(e.KeyPressed.ToString().ToUpper());
                        }
                    }
                }

                Point mousePos = MainWindow.GetMousePosition();

                switch (e.KeyPressed)
                {
                    
                    case Key.Left:
                        NativeMethods.SetCursorPos((int) mousePos.X - 10, (int) mousePos.Y);
                        break;
                    case Key.Right:
                        NativeMethods.SetCursorPos((int) mousePos.X + 10, (int) mousePos.Y);
                        break;
                    case Key.Up:
                        NativeMethods.SetCursorPos((int) mousePos.X, (int) mousePos.Y + 10);
                        break;
                    case Key.Down:
                        NativeMethods.SetCursorPos((int) mousePos.X, (int) mousePos.Y - 10);
                        break;
                    default: 
                        break;
                }
            }
        }
    }
}
