namespace AuraLightning
{
    partial class GameDetails
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblValueMPH = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblValueKM = new System.Windows.Forms.Label();
            this.lblMPH = new System.Windows.Forms.Label();
            this.lblKM = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tmrDBUpdate = new System.Windows.Forms.Timer(this.components);
            this.tmrUsageUpdate = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblValueMPH
            // 
            this.lblValueMPH.AutoSize = true;
            this.lblValueMPH.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueMPH.Location = new System.Drawing.Point(67, 45);
            this.lblValueMPH.Name = "lblValueMPH";
            this.lblValueMPH.Size = new System.Drawing.Size(24, 28);
            this.lblValueMPH.TabIndex = 1;
            this.lblValueMPH.Text = "0";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.DarkRed;
            this.progressBar1.Location = new System.Drawing.Point(6, 19);
            this.progressBar1.Maximum = 453;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(260, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // lblValueKM
            // 
            this.lblValueKM.AutoSize = true;
            this.lblValueKM.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueKM.Location = new System.Drawing.Point(67, 73);
            this.lblValueKM.Name = "lblValueKM";
            this.lblValueKM.Size = new System.Drawing.Size(24, 28);
            this.lblValueKM.TabIndex = 3;
            this.lblValueKM.Text = "0";
            // 
            // lblMPH
            // 
            this.lblMPH.AutoSize = true;
            this.lblMPH.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMPH.Location = new System.Drawing.Point(6, 45);
            this.lblMPH.Name = "lblMPH";
            this.lblMPH.Size = new System.Drawing.Size(55, 28);
            this.lblMPH.TabIndex = 7;
            this.lblMPH.Text = "MPH";
            // 
            // lblKM
            // 
            this.lblKM.AutoSize = true;
            this.lblKM.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKM.Location = new System.Drawing.Point(6, 73);
            this.lblKM.Name = "lblKM";
            this.lblKM.Size = new System.Drawing.Size(42, 28);
            this.lblKM.TabIndex = 8;
            this.lblKM.Text = "KM";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.lblKM);
            this.groupBox1.Controls.Add(this.lblValueMPH);
            this.groupBox1.Controls.Add(this.lblMPH);
            this.groupBox1.Controls.Add(this.lblValueKM);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 111);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(166, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tmrDBUpdate
            // 
            this.tmrDBUpdate.Interval = 5000;
            this.tmrDBUpdate.Tick += new System.EventHandler(this.tmrDBUpdate_Tick);
            // 
            // tmrUsageUpdate
            // 
            this.tmrUsageUpdate.Interval = 1000;
           
            // 
            // GameDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 131);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "GameDetails";
            this.Text = "Aura Lightning Need For Speed - Most Wanted";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblValueMPH;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblValueKM;
        private System.Windows.Forms.Label lblMPH;
        private System.Windows.Forms.Label lblKM;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer tmrDBUpdate;
        private System.Windows.Forms.Timer tmrUsageUpdate;
    }
}

