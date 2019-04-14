namespace AuraLightning
{
    partial class NonGameMenu
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rbOff = new System.Windows.Forms.RadioButton();
            this.rbParty = new System.Windows.Forms.RadioButton();
            this.rbCloud = new System.Windows.Forms.RadioButton();
            this.rbBandW = new System.Windows.Forms.RadioButton();
            this.rbRandom = new System.Windows.Forms.RadioButton();
            this.rbRainbow = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.rbOff);
            this.groupBox1.Controls.Add(this.rbParty);
            this.groupBox1.Controls.Add(this.rbCloud);
            this.groupBox1.Controls.Add(this.rbBandW);
            this.groupBox1.Controls.Add(this.rbRandom);
            this.groupBox1.Controls.Add(this.rbRainbow);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 192);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lightning Modes";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(6, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "CHANGE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbOff
            // 
            this.rbOff.AutoSize = true;
            this.rbOff.Location = new System.Drawing.Point(6, 134);
            this.rbOff.Name = "rbOff";
            this.rbOff.Size = new System.Drawing.Size(39, 17);
            this.rbOff.TabIndex = 6;
            this.rbOff.TabStop = true;
            this.rbOff.Text = "Off";
            this.rbOff.UseVisualStyleBackColor = true;
            this.rbOff.CheckedChanged += new System.EventHandler(this.rbOff_CheckedChanged);
            // 
            // rbParty
            // 
            this.rbParty.AutoSize = true;
            this.rbParty.Location = new System.Drawing.Point(6, 111);
            this.rbParty.Name = "rbParty";
            this.rbParty.Size = new System.Drawing.Size(80, 17);
            this.rbParty.TabIndex = 4;
            this.rbParty.TabStop = true;
            this.rbParty.Text = "Party colors";
            this.rbParty.UseVisualStyleBackColor = true;
            this.rbParty.CheckedChanged += new System.EventHandler(this.rbParty_CheckedChanged);
            // 
            // rbCloud
            // 
            this.rbCloud.AutoSize = true;
            this.rbCloud.Location = new System.Drawing.Point(6, 88);
            this.rbCloud.Name = "rbCloud";
            this.rbCloud.Size = new System.Drawing.Size(84, 17);
            this.rbCloud.TabIndex = 3;
            this.rbCloud.TabStop = true;
            this.rbCloud.Text = "Cloud Colors";
            this.rbCloud.UseVisualStyleBackColor = true;
            this.rbCloud.CheckedChanged += new System.EventHandler(this.rbCloud_CheckedChanged);
            // 
            // rbBandW
            // 
            this.rbBandW.AutoSize = true;
            this.rbBandW.Location = new System.Drawing.Point(6, 65);
            this.rbBandW.Name = "rbBandW";
            this.rbBandW.Size = new System.Drawing.Size(115, 17);
            this.rbBandW.TabIndex = 2;
            this.rbBandW.TabStop = true;
            this.rbBandW.Text = "Black/White Stripe";
            this.rbBandW.UseVisualStyleBackColor = true;
            this.rbBandW.CheckedChanged += new System.EventHandler(this.rbBandW_CheckedChanged);
            // 
            // rbRandom
            // 
            this.rbRandom.AutoSize = true;
            this.rbRandom.Location = new System.Drawing.Point(6, 42);
            this.rbRandom.Name = "rbRandom";
            this.rbRandom.Size = new System.Drawing.Size(97, 17);
            this.rbRandom.TabIndex = 1;
            this.rbRandom.TabStop = true;
            this.rbRandom.Text = "Random Colors";
            this.rbRandom.UseVisualStyleBackColor = true;
            this.rbRandom.CheckedChanged += new System.EventHandler(this.rbRandom_CheckedChanged);
            // 
            // rbRainbow
            // 
            this.rbRainbow.AutoSize = true;
            this.rbRainbow.Location = new System.Drawing.Point(6, 19);
            this.rbRainbow.Name = "rbRainbow";
            this.rbRainbow.Size = new System.Drawing.Size(70, 17);
            this.rbRainbow.TabIndex = 0;
            this.rbRainbow.TabStop = true;
            this.rbRainbow.Text = "Rainbow ";
            this.rbRainbow.UseVisualStyleBackColor = true;
            this.rbRainbow.CheckedChanged += new System.EventHandler(this.rbRainbow_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            this.label1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // NonGameMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(149, 208);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NonGameMenu";
            this.Text = "This is the Chill mode setting menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NonGameMenu_FormClosing);
            this.Load += new System.EventHandler(this.NonGameMenu_Load);
            
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbParty;
        private System.Windows.Forms.RadioButton rbCloud;
        private System.Windows.Forms.RadioButton rbBandW;
        private System.Windows.Forms.RadioButton rbRandom;
        private System.Windows.Forms.RadioButton rbRainbow;
        private System.Windows.Forms.RadioButton rbOff;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
    }
}