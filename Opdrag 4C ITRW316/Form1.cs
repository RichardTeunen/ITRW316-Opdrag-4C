﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opdrag_4C_ITRW316
{
    public partial class Form1 : Form
    {
        public string pathName = "";
        public bool recording = false;
        public Form1()
        {
            InitializeComponent();
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (recording == false)
            {
                if (e.Control && e.Shift && e.KeyCode == Keys.R)
                {
                    lblRecording.ForeColor = Color.Red;
                    lblRecording.Text = "Recording";
                    recording = true;
                }
            }
            else if (recording)
            {
                while (String.IsNullOrEmpty(pathName))
                    OpenfileChooser();

                using (Stream str = new FileStream(pathName, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(str))
                    {
                        if (e.Control && e.Shift && e.KeyCode == Keys.R)
                        {
                            lblRecording.ForeColor = Color.Blue;
                            lblRecording.Text = "Not Recording";
                            recording = false;
                        }
                        else if (!e.Control && !e.Shift)
                        {
                            writer.Write(e.KeyCode.ToString().ToLower());
                        }
                        else if (e.Shift && e.KeyCode != Keys.HanjaMode)
                        {
                            writer.Write(e.KeyCode.ToString().ToUpper());
                        }       
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
    }
}
