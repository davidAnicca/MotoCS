using System.ComponentModel;

namespace Motocliclisti
{
    partial class EntryParticipant
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.teamChoice = new System.Windows.Forms.ComboBox();
            this.CapacityChoice = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nume";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(28, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Echipa";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Capacitate";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(106, 6);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(109, 22);
            this.nameText.TabIndex = 3;
            // 
            // teamChoice
            // 
            this.teamChoice.FormattingEnabled = true;
            this.teamChoice.Location = new System.Drawing.Point(106, 34);
            this.teamChoice.Name = "teamChoice";
            this.teamChoice.Size = new System.Drawing.Size(109, 24);
            this.teamChoice.TabIndex = 4;
            // 
            // CapacityChoice
            // 
            this.CapacityChoice.FormattingEnabled = true;
            this.CapacityChoice.Location = new System.Drawing.Point(106, 60);
            this.CapacityChoice.Name = "CapacityChoice";
            this.CapacityChoice.Size = new System.Drawing.Size(109, 24);
            this.CapacityChoice.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "Înscrie";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EntryParticipant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 146);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CapacityChoice);
            this.Controls.Add(this.teamChoice);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EntryParticipant";
            this.Text = "EntryParticipant";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.ComboBox teamChoice;
        private System.Windows.Forms.ComboBox CapacityChoice;
        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}