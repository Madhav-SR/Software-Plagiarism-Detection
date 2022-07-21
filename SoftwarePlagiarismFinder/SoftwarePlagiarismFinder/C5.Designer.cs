namespace SoftwarePlagiarismFinder
{
    partial class C5
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
            this.label13 = new System.Windows.Forms.Label();
            this.cmdCompare = new System.Windows.Forms.Button();
            this.sha1 = new System.Windows.Forms.RichTextBox();
            this.sha2 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.fuzzy2 = new System.Windows.Forms.RichTextBox();
            this.fuzzy1 = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Light", 22.75F);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(99)))));
            this.label13.Location = new System.Drawing.Point(1, -4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(523, 42);
            this.label13.TabIndex = 40;
            this.label13.Text = "Compare Birthmark.. (Hashing Method)";
            // 
            // cmdCompare
            // 
            this.cmdCompare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(169)))), ((int)(((byte)(171)))));
            this.cmdCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCompare.ForeColor = System.Drawing.Color.White;
            this.cmdCompare.Location = new System.Drawing.Point(12, 50);
            this.cmdCompare.Name = "cmdCompare";
            this.cmdCompare.Size = new System.Drawing.Size(586, 29);
            this.cmdCompare.TabIndex = 41;
            this.cmdCompare.Text = "Create Hash Value";
            this.cmdCompare.UseVisualStyleBackColor = false;
            this.cmdCompare.Click += new System.EventHandler(this.cmdCompare_Click);
            // 
            // sha1
            // 
            this.sha1.Location = new System.Drawing.Point(12, 145);
            this.sha1.Name = "sha1";
            this.sha1.Size = new System.Drawing.Size(285, 110);
            this.sha1.TabIndex = 42;
            this.sha1.Text = "";
            // 
            // sha2
            // 
            this.sha2.Location = new System.Drawing.Point(313, 145);
            this.sha2.Name = "sha2";
            this.sha2.Size = new System.Drawing.Size(285, 110);
            this.sha2.TabIndex = 43;
            this.sha2.Text = "";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(169)))), ((int)(((byte)(171)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(12, 469);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(586, 29);
            this.button2.TabIndex = 45;
            this.button2.Text = "Next";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fuzzy2
            // 
            this.fuzzy2.Location = new System.Drawing.Point(313, 340);
            this.fuzzy2.Name = "fuzzy2";
            this.fuzzy2.Size = new System.Drawing.Size(285, 110);
            this.fuzzy2.TabIndex = 47;
            this.fuzzy2.Text = "";
            // 
            // fuzzy1
            // 
            this.fuzzy1.Location = new System.Drawing.Point(12, 340);
            this.fuzzy1.Name = "fuzzy1";
            this.fuzzy1.Size = new System.Drawing.Size(285, 110);
            this.fuzzy1.TabIndex = 46;
            this.fuzzy1.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Light", 14.75F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(99)))));
            this.label9.Location = new System.Drawing.Point(187, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(264, 28);
            this.label9.TabIndex = 48;
            this.label9.Text = "Cryptographic Hash Functions";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "MD5 Hash value (Birthmark of first project)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "MD5 Hash value (Birthmark of second project)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Fuzzy Hash value (Birthmark of second project)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Fuzzy Hash value (Birthmark of first project)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Light", 14.75F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(99)))));
            this.label5.Location = new System.Drawing.Point(187, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(305, 28);
            this.label5.TabIndex = 53;
            this.label5.Text = "Non Cryptographic Hash Functions";
            // 
            // C5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(619, 512);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.fuzzy2);
            this.Controls.Add(this.fuzzy1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.sha2);
            this.Controls.Add(this.sha1);
            this.Controls.Add(this.cmdCompare);
            this.Controls.Add(this.label13);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "C5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "C5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button cmdCompare;
        private System.Windows.Forms.RichTextBox sha1;
        private System.Windows.Forms.RichTextBox sha2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox fuzzy2;
        private System.Windows.Forms.RichTextBox fuzzy1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}