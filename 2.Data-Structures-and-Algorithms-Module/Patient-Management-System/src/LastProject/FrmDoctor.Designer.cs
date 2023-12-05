namespace LastProject
{
    partial class FrmDoctor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDoctor));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPaitentEnterance = new System.Windows.Forms.Button();
            this.lboxNormal = new System.Windows.Forms.ListBox();
            this.lboxEmergency = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(150, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "لیست بیماران معمولی";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(541, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "لیست بیماران اورژانسی";
            // 
            // btnPaitentEnterance
            // 
            this.btnPaitentEnterance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaitentEnterance.ForeColor = System.Drawing.Color.DarkViolet;
            this.btnPaitentEnterance.Location = new System.Drawing.Point(293, 396);
            this.btnPaitentEnterance.Name = "btnPaitentEnterance";
            this.btnPaitentEnterance.Size = new System.Drawing.Size(215, 42);
            this.btnPaitentEnterance.TabIndex = 13;
            this.btnPaitentEnterance.Text = "ورود بیمار";
            this.btnPaitentEnterance.UseVisualStyleBackColor = true;
            this.btnPaitentEnterance.Click += new System.EventHandler(this.btnPaitentEnterance_Click);
            // 
            // lboxNormal
            // 
            this.lboxNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lboxNormal.FormattingEnabled = true;
            this.lboxNormal.ItemHeight = 18;
            this.lboxNormal.Location = new System.Drawing.Point(60, 152);
            this.lboxNormal.Name = "lboxNormal";
            this.lboxNormal.Size = new System.Drawing.Size(300, 220);
            this.lboxNormal.TabIndex = 14;
            // 
            // lboxEmergency
            // 
            this.lboxEmergency.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lboxEmergency.FormattingEnabled = true;
            this.lboxEmergency.ItemHeight = 18;
            this.lboxEmergency.Location = new System.Drawing.Point(443, 152);
            this.lboxEmergency.Name = "lboxEmergency";
            this.lboxEmergency.Size = new System.Drawing.Size(300, 220);
            this.lboxEmergency.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(727, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "کاربر : ";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(699, 26);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 16);
            this.lblUsername.TabIndex = 16;
            // 
            // FrmDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkViolet;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lboxNormal);
            this.Controls.Add(this.lboxEmergency);
            this.Controls.Add(this.btnPaitentEnterance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDoctor";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "پذیرش بیمار";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDoctor_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDoctor_FormClosed);
            this.Load += new System.EventHandler(this.FrmDoctor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPaitentEnterance;
        private System.Windows.Forms.ListBox lboxNormal;
        private System.Windows.Forms.ListBox lboxEmergency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsername;
    }
}