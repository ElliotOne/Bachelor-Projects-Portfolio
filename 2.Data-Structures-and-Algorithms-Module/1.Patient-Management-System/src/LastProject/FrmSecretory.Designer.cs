namespace LastProject
{
    partial class FrmSecretory
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSecretory));
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.radEmergency = new System.Windows.Forms.RadioButton();
            this.radNormal = new System.Windows.Forms.RadioButton();
            this.radEmergency2 = new System.Windows.Forms.RadioButton();
            this.radEmergency1 = new System.Windows.Forms.RadioButton();
            this.gpState = new System.Windows.Forms.GroupBox();
            this.gpEmergencyType = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDoctorsList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lboxEmergency = new System.Windows.Forms.ListBox();
            this.lboxNormal = new System.Windows.Forms.ListBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gpState.SuspendLayout();
            this.gpEmergencyType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFirstname
            // 
            this.txtFirstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstname.Location = new System.Drawing.Point(476, 53);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFirstname.Size = new System.Drawing.Size(220, 24);
            this.txtFirstname.TabIndex = 0;
            // 
            // txtLastname
            // 
            this.txtLastname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastname.Location = new System.Drawing.Point(476, 83);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLastname.Size = new System.Drawing.Size(220, 24);
            this.txtLastname.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.DarkViolet;
            this.btnAdd.Location = new System.Drawing.Point(481, 367);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(215, 42);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "اضافه";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // radEmergency
            // 
            this.radEmergency.AutoSize = true;
            this.radEmergency.Location = new System.Drawing.Point(97, 32);
            this.radEmergency.Name = "radEmergency";
            this.radEmergency.Size = new System.Drawing.Size(70, 17);
            this.radEmergency.TabIndex = 5;
            this.radEmergency.TabStop = true;
            this.radEmergency.Text = "اورژانسی";
            this.radEmergency.UseVisualStyleBackColor = true;
            this.radEmergency.CheckedChanged += new System.EventHandler(this.radEmergency_CheckedChanged);
            // 
            // radNormal
            // 
            this.radNormal.AutoSize = true;
            this.radNormal.Location = new System.Drawing.Point(6, 32);
            this.radNormal.Name = "radNormal";
            this.radNormal.Size = new System.Drawing.Size(60, 17);
            this.radNormal.TabIndex = 5;
            this.radNormal.TabStop = true;
            this.radNormal.Text = "معمولی";
            this.radNormal.UseVisualStyleBackColor = true;
            this.radNormal.CheckedChanged += new System.EventHandler(this.radNormal_CheckedChanged);
            // 
            // radEmergency2
            // 
            this.radEmergency2.AutoSize = true;
            this.radEmergency2.Location = new System.Drawing.Point(15, 28);
            this.radEmergency2.Name = "radEmergency2";
            this.radEmergency2.Size = new System.Drawing.Size(50, 17);
            this.radEmergency2.TabIndex = 5;
            this.radEmergency2.TabStop = true;
            this.radEmergency2.Text = "خفیف";
            this.radEmergency2.UseVisualStyleBackColor = true;
            // 
            // radEmergency1
            // 
            this.radEmergency1.AutoSize = true;
            this.radEmergency1.Location = new System.Drawing.Point(116, 28);
            this.radEmergency1.Name = "radEmergency1";
            this.radEmergency1.Size = new System.Drawing.Size(48, 17);
            this.radEmergency1.TabIndex = 5;
            this.radEmergency1.TabStop = true;
            this.radEmergency1.Text = "شدید";
            this.radEmergency1.UseVisualStyleBackColor = true;
            // 
            // gpState
            // 
            this.gpState.Controls.Add(this.radNormal);
            this.gpState.Controls.Add(this.radEmergency);
            this.gpState.ForeColor = System.Drawing.Color.White;
            this.gpState.Location = new System.Drawing.Point(476, 167);
            this.gpState.Name = "gpState";
            this.gpState.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gpState.Size = new System.Drawing.Size(220, 60);
            this.gpState.TabIndex = 6;
            this.gpState.TabStop = false;
            this.gpState.Text = "وضعیت";
            // 
            // gpEmergencyType
            // 
            this.gpEmergencyType.Controls.Add(this.radEmergency2);
            this.gpEmergencyType.Controls.Add(this.radEmergency1);
            this.gpEmergencyType.ForeColor = System.Drawing.Color.White;
            this.gpEmergencyType.Location = new System.Drawing.Point(476, 233);
            this.gpEmergencyType.Name = "gpEmergencyType";
            this.gpEmergencyType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gpEmergencyType.Size = new System.Drawing.Size(220, 60);
            this.gpEmergencyType.TabIndex = 7;
            this.gpEmergencyType.TabStop = false;
            this.gpEmergencyType.Text = "نوع اورژانسی";
            this.gpEmergencyType.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(767, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "نام";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(720, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "نام خانوادگی";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(272, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "لیست بیماران اورژانسی";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(67, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "لیست بیماران معمولی";
            // 
            // cmbDoctorsList
            // 
            this.cmbDoctorsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoctorsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDoctorsList.FormattingEnabled = true;
            this.cmbDoctorsList.Location = new System.Drawing.Point(476, 116);
            this.cmbDoctorsList.Name = "cmbDoctorsList";
            this.cmbDoctorsList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbDoctorsList.Size = new System.Drawing.Size(220, 26);
            this.cmbDoctorsList.TabIndex = 9;
            this.cmbDoctorsList.SelectedIndexChanged += new System.EventHandler(this.cmbDoctorsList_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(715, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "انتخاب پزشک";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lboxEmergency
            // 
            this.lboxEmergency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lboxEmergency.FormattingEnabled = true;
            this.lboxEmergency.ItemHeight = 16;
            this.lboxEmergency.Location = new System.Drawing.Point(246, 122);
            this.lboxEmergency.Name = "lboxEmergency";
            this.lboxEmergency.Size = new System.Drawing.Size(190, 308);
            this.lboxEmergency.TabIndex = 10;
            // 
            // lboxNormal
            // 
            this.lboxNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lboxNormal.FormattingEnabled = true;
            this.lboxNormal.ItemHeight = 16;
            this.lboxNormal.Location = new System.Drawing.Point(25, 122);
            this.lboxNormal.Name = "lboxNormal";
            this.lboxNormal.Size = new System.Drawing.Size(190, 308);
            this.lboxNormal.TabIndex = 10;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(118, 18);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 16);
            this.lblUsername.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(151, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "کاربر : ";
            // 
            // FrmSecretory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkViolet;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lboxNormal);
            this.Controls.Add(this.lboxEmergency);
            this.Controls.Add(this.cmbDoctorsList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gpEmergencyType);
            this.Controls.Add(this.gpState);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtLastname);
            this.Controls.Add(this.txtFirstname);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSecretory";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ورود اطلاعات بیماران";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSecretory_FormClosed);
            this.Load += new System.EventHandler(this.FrmSecretory_Load);
            this.gpState.ResumeLayout(false);
            this.gpState.PerformLayout();
            this.gpEmergencyType.ResumeLayout(false);
            this.gpEmergencyType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RadioButton radEmergency;
        private System.Windows.Forms.RadioButton radNormal;
        private System.Windows.Forms.RadioButton radEmergency2;
        private System.Windows.Forms.RadioButton radEmergency1;
        private System.Windows.Forms.GroupBox gpState;
        private System.Windows.Forms.GroupBox gpEmergencyType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDoctorsList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ListBox lboxEmergency;
        private System.Windows.Forms.ListBox lboxNormal;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label6;
    }
}

