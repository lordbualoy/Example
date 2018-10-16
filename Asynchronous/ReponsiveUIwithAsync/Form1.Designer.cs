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
            this.synch = new System.Windows.Forms.Button();
            this.asynch = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // synch
            // 
            this.synch.Location = new System.Drawing.Point(-1, 1);
            this.synch.Name = "synch";
            this.synch.Size = new System.Drawing.Size(75, 23);
            this.synch.TabIndex = 0;
            this.synch.Text = "sync";
            this.synch.UseVisualStyleBackColor = true;
            this.synch.Click += new System.EventHandler(this.synch_Click);
            // 
            // asynch
            // 
            this.asynch.Location = new System.Drawing.Point(80, 1);
            this.asynch.Name = "asynch";
            this.asynch.Size = new System.Drawing.Size(75, 23);
            this.asynch.TabIndex = 1;
            this.asynch.Text = "async";
            this.asynch.UseVisualStyleBackColor = true;
            this.asynch.Click += new System.EventHandler(this.asynch_Click);
            // 
            // output
            // 
            this.output.AutoSize = true;
            this.output.Location = new System.Drawing.Point(45, 27);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(62, 13);
            this.output.TabIndex = 2;
            this.output.Text = "placeholder";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(156, 45);
            this.Controls.Add(this.output);
            this.Controls.Add(this.asynch);
            this.Controls.Add(this.synch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button synch;
        private System.Windows.Forms.Button asynch;
        private System.Windows.Forms.Label output;
    }
}

