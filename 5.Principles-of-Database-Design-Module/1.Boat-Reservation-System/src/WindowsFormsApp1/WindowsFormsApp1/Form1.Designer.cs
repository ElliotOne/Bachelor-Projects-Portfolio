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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnFrmBoat = new System.Windows.Forms.Button();
            this.btnFrmSailor = new System.Windows.Forms.Button();
            this.btnFrmReserve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFrmBoat
            // 
            this.btnFrmBoat.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnFrmBoat.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnFrmBoat.FlatAppearance.BorderSize = 5;
            this.btnFrmBoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFrmBoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFrmBoat.ForeColor = System.Drawing.Color.White;
            this.btnFrmBoat.Location = new System.Drawing.Point(541, 193);
            this.btnFrmBoat.Name = "btnFrmBoat";
            this.btnFrmBoat.Size = new System.Drawing.Size(120, 50);
            this.btnFrmBoat.TabIndex = 0;
            this.btnFrmBoat.Text = "Boats";
            this.btnFrmBoat.UseVisualStyleBackColor = false;
            this.btnFrmBoat.Click += new System.EventHandler(this.btnFrmBoat_Click);
            // 
            // btnFrmSailor
            // 
            this.btnFrmSailor.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnFrmSailor.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnFrmSailor.FlatAppearance.BorderSize = 5;
            this.btnFrmSailor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFrmSailor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFrmSailor.ForeColor = System.Drawing.Color.White;
            this.btnFrmSailor.Location = new System.Drawing.Point(541, 249);
            this.btnFrmSailor.Name = "btnFrmSailor";
            this.btnFrmSailor.Size = new System.Drawing.Size(120, 50);
            this.btnFrmSailor.TabIndex = 0;
            this.btnFrmSailor.Text = "Sailors";
            this.btnFrmSailor.UseVisualStyleBackColor = false;
            this.btnFrmSailor.Click += new System.EventHandler(this.btnFrmSailor_Click);
            // 
            // btnFrmReserve
            // 
            this.btnFrmReserve.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnFrmReserve.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnFrmReserve.FlatAppearance.BorderSize = 5;
            this.btnFrmReserve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFrmReserve.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFrmReserve.ForeColor = System.Drawing.Color.White;
            this.btnFrmReserve.Location = new System.Drawing.Point(541, 305);
            this.btnFrmReserve.Name = "btnFrmReserve";
            this.btnFrmReserve.Size = new System.Drawing.Size(120, 50);
            this.btnFrmReserve.TabIndex = 0;
            this.btnFrmReserve.Text = "Rerseves";
            this.btnFrmReserve.UseVisualStyleBackColor = false;
            this.btnFrmReserve.Click += new System.EventHandler(this.btnFrmReserve_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(673, 378);
            this.Controls.Add(this.btnFrmReserve);
            this.Controls.Add(this.btnFrmSailor);
            this.Controls.Add(this.btnFrmBoat);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boat Managaer System";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFrmBoat;
        private System.Windows.Forms.Button btnFrmSailor;
        private System.Windows.Forms.Button btnFrmReserve;
    }
}

