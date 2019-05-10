namespace Opdrag_4C_ITRW316
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
            this.kbkRecording = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFileSelect
            // 
            this.btnFileSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.SpinButton;
            this.btnFileSelect.Location = new System.Drawing.Point(91, 101);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(163, 27);
            this.btnFileSelect.TabIndex = 0;
            this.btnFileSelect.Text = "Select File to write to ";
            this.btnFileSelect.UseVisualStyleBackColor = true;
            this.btnFileSelect.Click += new System.EventHandler(this.btnFileSelect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please Select a File to write to and then \r\n    hit Ctrl+Shift+R to start recordi" +
    "ng";
            // 
            // kbkRecording
            // 
            this.kbkRecording.AutoSize = true;
            this.kbkRecording.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbkRecording.ForeColor = System.Drawing.SystemColors.Highlight;
            this.kbkRecording.Location = new System.Drawing.Point(27, 137);
            this.kbkRecording.Name = "kbkRecording";
            this.kbkRecording.Size = new System.Drawing.Size(129, 20);
            this.kbkRecording.TabIndex = 2;
            this.kbkRecording.Text = "Not Recording ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 183);
            this.Controls.Add(this.kbkRecording);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFileSelect);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label kbkRecording;
    }
}

