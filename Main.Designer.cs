using System.ComponentModel;

namespace Motocliclisti
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.probes = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.teamText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.partic = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // probes
            // 
            this.probes.FormattingEnabled = true;
            this.probes.ItemHeight = 16;
            this.probes.Location = new System.Drawing.Point(36, 78);
            this.probes.Name = "probes";
            this.probes.Size = new System.Drawing.Size(285, 324);
            this.probes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(36, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Curse";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(474, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Caută";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // teamText
            // 
            this.teamText.Location = new System.Drawing.Point(408, 78);
            this.teamText.Name = "teamText";
            this.teamText.Size = new System.Drawing.Size(168, 22);
            this.teamText.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(592, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Caută";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // partic
            // 
            this.partic.FormattingEnabled = true;
            this.partic.ItemHeight = 16;
            this.partic.Location = new System.Drawing.Point(408, 114);
            this.partic.Name = "partic";
            this.partic.Size = new System.Drawing.Size(285, 292);
            this.partic.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(408, 412);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 32);
            this.button2.TabIndex = 6;
            this.button2.Text = "Înscrie";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 505);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.partic);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.teamText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.probes);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox teamText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox partic;

        private System.Windows.Forms.ListBox probes;
        private System.Windows.Forms.Label label1;

        #endregion
    }
}