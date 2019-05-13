using Hotkeys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Open.WinKeyboardHook;

namespace Opdrag_4C_ITRW316
{
    public partial class Form1 : Form
    {
        private GlobalHotkey ghkStartStop;
        private List<GlobalHotkey> ghkNormalList = new List<GlobalHotkey>();

        public string pathName = "";
        public bool recording = false;
        int counter = 0;

        public Form1()
        {
            InitializeComponent();

            ghkStartStop = new GlobalHotkey(Constants.CTRL + Constants.SHIFT, Keys.R, this);

            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.A, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.B, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.C, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.D, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.E, this));

            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.F, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.G, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.H, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.I, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.J, this));

            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.K, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.L, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.M, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.N, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.O, this));

            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.P, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.Q, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.R, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.S, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.T, this));

            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.U, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.V, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.W, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.X, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.Y, this));
            ghkNormalList.Add(new GlobalHotkey(Constants.NOMOD, Keys.Z, this));

            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y - 10);
                    break;
                case Keys.Right:
                    Cursor.Position = new Point(Cursor.Position.X + 10, Cursor.Position.Y);
                    break;
                case Keys.Down:
                    Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + 10);
                    break;
                case Keys.Left:
                    Cursor.Position = new Point(Cursor.Position.X - 10, Cursor.Position.Y);
                    break;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            OpenfileChooser();
            Focus();  
        }

        public void OpenfileChooser()
        {
            OpenFileDialog fdg = new OpenFileDialog();
            fdg.ShowDialog();
            pathName = fdg.FileName;
            MessageBox.Show(pathName);
        }

        private void Hotkey_KeyDown(object sender, KeyEventArgs e)
        {
            if (recording)
            {
                while (String.IsNullOrEmpty(pathName))
                    OpenfileChooser();

                using (Stream str = new FileStream(pathName, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(str))
                    {
                        if (!(e.KeyCode == Keys.Control || e.KeyCode == Keys.Shift))
                        {
                            writer.Write(e.KeyCode.ToString().ToLower());
                        }
                        /*
                        else if (Key.Shift && e.Key != Keys.HanjaMode)
                        {
                            writer.Write(e.Key.ToString().ToUpper());
                        }
                        */
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(pathName))
            {
                using (Stream str = new FileStream(pathName, FileMode.Create, FileAccess.ReadWrite))
                { }
            }
            else
            {
                MessageBox.Show("No file has been selected.");
            }
        }

        void hook_KeyPressed(object sender, KeyEventArgs e)
        {
            counter++;

            if (counter % 2 == 1)
            {
                lblRecording.ForeColor = Color.Red;
                lblRecording.Text = "Recording";
                recording = true;
                Focus();
            }
            else
            {
                lblRecording.ForeColor = Color.Blue;
                lblRecording.Text = "Not Recording";
                recording = false;
            }

            Focus();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
