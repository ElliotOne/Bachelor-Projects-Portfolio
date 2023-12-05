namespace WindowsFormsApp1
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
            this.rchInput = new System.Windows.Forms.RichTextBox();
            this.rchResult = new System.Windows.Forms.RichTextBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnGetFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // rchInput
            // 
            this.rchInput.Location = new System.Drawing.Point(12, 66);
            this.rchInput.Name = "rchInput";
            this.rchInput.Size = new System.Drawing.Size(347, 372);
            this.rchInput.TabIndex = 0;
            this.rchInput.Text = "";
            // 
            // rchResult
            // 
            this.rchResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rchResult.Location = new System.Drawing.Point(365, 66);
            this.rchResult.Name = "rchResult";
            this.rchResult.Size = new System.Drawing.Size(347, 372);
            this.rchResult.TabIndex = 0;
            this.rchResult.Text = "";
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(365, 28);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(346, 32);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "اسکن";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.BtnScan_Click);
            // 
            // btnGetFile
            // 
            this.btnGetFile.Location = new System.Drawing.Point(12, 28);
            this.btnGetFile.Name = "btnGetFile";
            this.btnGetFile.Size = new System.Drawing.Size(347, 32);
            this.btnGetFile.TabIndex = 1;
            this.btnGetFile.Text = "خواندن از فایل";
            this.btnGetFile.UseVisualStyleBackColor = true;
            this.btnGetFile.Click += new System.EventHandler(this.BtnGetFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 450);
            this.Controls.Add(this.btnGetFile);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.rchResult);
            this.Controls.Add(this.rchInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchInput;
        private System.Windows.Forms.RichTextBox rchResult;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnGetFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

