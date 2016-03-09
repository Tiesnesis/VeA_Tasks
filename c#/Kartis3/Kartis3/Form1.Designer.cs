namespace Kartis3
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.jaunaSpeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izietToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Move = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jaunaSpeleToolStripMenuItem,
            this.izietToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(961, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // jaunaSpeleToolStripMenuItem
            // 
            this.jaunaSpeleToolStripMenuItem.Name = "jaunaSpeleToolStripMenuItem";
            this.jaunaSpeleToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.jaunaSpeleToolStripMenuItem.Text = "Jauna Spele";
            this.jaunaSpeleToolStripMenuItem.Click += new System.EventHandler(this.jaunaSpeleToolStripMenuItem_Click);
            // 
            // izietToolStripMenuItem
            // 
            this.izietToolStripMenuItem.Name = "izietToolStripMenuItem";
            this.izietToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.izietToolStripMenuItem.Text = "Iziet";
            this.izietToolStripMenuItem.Click += new System.EventHandler(this.izietToolStripMenuItem_Click);
            // 
            // Move
            // 
            this.Move.Location = new System.Drawing.Point(734, 355);
            this.Move.Name = "Move";
            this.Move.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Move.Size = new System.Drawing.Size(75, 23);
            this.Move.TabIndex = 1;
            this.Move.Text = "Pacelt";
            this.Move.UseVisualStyleBackColor = true;
            this.Move.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(848, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Sakt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(848, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 756);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Move);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem jaunaSpeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izietToolStripMenuItem;
        private System.Windows.Forms.Button Move;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

