﻿namespace Opdrag_4C_ITRW316
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFileSelect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecording = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFileSelect
            // 
            this.btnFileSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.SpinButton;
            this.btnFileSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileSelect.Location = new System.Drawing.Point(14, 70);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(163, 27);
            this.btnFileSelect.TabIndex = 0;
            this.btnFileSelect.Text = "Select File";
            this.btnFileSelect.UseVisualStyleBackColor = true;
            this.btnFileSelect.Click += new System.EventHandler(this.btnFileSelect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "1. Select a File to write to\r\n2. Press Ctrl+Shift+R to start recording your key s" +
    "trokes\r\n3. Press Ctrl+Shift+R to stop recording";
            // 
            // lblRecording
            // 
            this.lblRecording.AutoSize = true;
            this.lblRecording.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecording.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRecording.Location = new System.Drawing.Point(122, 100);
            this.lblRecording.Name = "lblRecording";
            this.lblRecording.Size = new System.Drawing.Size(115, 20);
            this.lblRecording.TabIndex = 2;
            this.lblRecording.Text = "Not Recording ";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(178, 70);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(163, 27);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear Text File";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 131);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblRecording);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFileSelect);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Key Hooking";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecording;
        private System.Windows.Forms.Button btnClear;
    }
}

