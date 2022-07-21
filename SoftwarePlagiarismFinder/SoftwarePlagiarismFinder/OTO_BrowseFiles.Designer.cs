namespace SoftwarePlagiarismFinder
{
    partial class OTO_BrowseFiles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>

       
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
       private System.ComponentModel.Container components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

     
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSlow = new System.Windows.Forms.RadioButton();
            this.rbMedium = new System.Windows.Forms.RadioButton();
            this.rbFast = new System.Windows.Forms.RadioButton();
            this.chkBinary = new System.Windows.Forms.CheckBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdDestination = new System.Windows.Forms.Button();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.cmdSource = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCompare = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSlow);
            this.groupBox1.Controls.Add(this.rbMedium);
            this.groupBox1.Controls.Add(this.rbFast);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.groupBox1.Location = new System.Drawing.Point(179, 166);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 51);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Diff Level";
            // 
            // rbSlow
            // 
            this.rbSlow.Location = new System.Drawing.Point(180, 18);
            this.rbSlow.Name = "rbSlow";
            this.rbSlow.Size = new System.Drawing.Size(94, 24);
            this.rbSlow.TabIndex = 2;
            this.rbSlow.Text = "Slow/Best";
            // 
            // rbMedium
            // 
            this.rbMedium.Location = new System.Drawing.Point(89, 18);
            this.rbMedium.Name = "rbMedium";
            this.rbMedium.Size = new System.Drawing.Size(85, 24);
            this.rbMedium.TabIndex = 1;
            this.rbMedium.Text = "Medium";
            // 
            // rbFast
            // 
            this.rbFast.Checked = true;
            this.rbFast.Location = new System.Drawing.Point(10, 18);
            this.rbFast.Name = "rbFast";
            this.rbFast.Size = new System.Drawing.Size(58, 24);
            this.rbFast.TabIndex = 0;
            this.rbFast.TabStop = true;
            this.rbFast.Text = "Fast";
            // 
            // chkBinary
            // 
            this.chkBinary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.chkBinary.Location = new System.Drawing.Point(192, 229);
            this.chkBinary.Name = "chkBinary";
            this.chkBinary.Size = new System.Drawing.Size(93, 27);
            this.chkBinary.TabIndex = 17;
            this.chkBinary.Text = "Binary Diff";
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(169)))), ((int)(((byte)(171)))));
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cmdClose.ForeColor = System.Drawing.Color.White;
            this.cmdClose.Location = new System.Drawing.Point(380, 229);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(79, 28);
            this.cmdClose.TabIndex = 19;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDestination
            // 
            this.cmdDestination.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(169)))), ((int)(((byte)(171)))));
            this.cmdDestination.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cmdDestination.ForeColor = System.Drawing.Color.White;
            this.cmdDestination.Location = new System.Drawing.Point(431, 134);
            this.cmdDestination.Name = "cmdDestination";
            this.cmdDestination.Size = new System.Drawing.Size(28, 28);
            this.cmdDestination.TabIndex = 15;
            this.cmdDestination.Text = "...";
            this.cmdDestination.UseVisualStyleBackColor = false;
            this.cmdDestination.Click += new System.EventHandler(this.cmdDestination_Click);
            // 
            // txtDestination
            // 
            this.txtDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtDestination.Location = new System.Drawing.Point(181, 139);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(244, 21);
            this.txtDestination.TabIndex = 14;
            // 
            // txtSource
            // 
            this.txtSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtSource.Location = new System.Drawing.Point(181, 89);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(244, 21);
            this.txtSource.TabIndex = 11;
            // 
            // cmdSource
            // 
            this.cmdSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(169)))), ((int)(((byte)(171)))));
            this.cmdSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cmdSource.ForeColor = System.Drawing.Color.White;
            this.cmdSource.Location = new System.Drawing.Point(431, 81);
            this.cmdSource.Name = "cmdSource";
            this.cmdSource.Size = new System.Drawing.Size(28, 28);
            this.cmdSource.TabIndex = 12;
            this.cmdSource.Text = "...";
            this.cmdSource.UseVisualStyleBackColor = false;
            this.cmdSource.Click += new System.EventHandler(this.cmdSource_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.Location = new System.Drawing.Point(178, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Destination:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(178, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Source:";
            // 
            // cmdCompare
            // 
            this.cmdCompare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(169)))), ((int)(((byte)(171)))));
            this.cmdCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cmdCompare.ForeColor = System.Drawing.Color.White;
            this.cmdCompare.Location = new System.Drawing.Point(301, 229);
            this.cmdCompare.Name = "cmdCompare";
            this.cmdCompare.Size = new System.Drawing.Size(79, 28);
            this.cmdCompare.TabIndex = 18;
            this.cmdCompare.Text = "Compare";
            this.cmdCompare.UseVisualStyleBackColor = false;
            this.cmdCompare.Click += new System.EventHandler(this.cmdCompare_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 24.75F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(99)))));
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 45);
            this.label3.TabIndex = 20;
            this.label3.Text = "Browse Files..";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SoftwarePlagiarismFinder.Properties.Resources.iconfinder_document_search_48758;
            this.pictureBox1.Location = new System.Drawing.Point(14, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // OTO_BrowseFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(526, 282);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkBinary);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDestination);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.cmdSource);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCompare);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OTO_BrowseFiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OTO_BrowseFiles";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSlow;
        private System.Windows.Forms.RadioButton rbMedium;
        private System.Windows.Forms.RadioButton rbFast;
        private System.Windows.Forms.CheckBox chkBinary;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdDestination;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Button cmdSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdCompare;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}