using System;
using System.Collections.Generic;
using System.Text;
namespace The_Landers
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Displaylbl1 = new Label();
            lblLevelNumber = new Label();
            SuspendLayout();
            // 
            // Displaylbl1
            // 
            Displaylbl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Displaylbl1.BackColor = Color.FromArgb(128, 128, 255);
            Displaylbl1.BorderStyle = BorderStyle.Fixed3D;
            Displaylbl1.Location = new Point(-1, 33);
            Displaylbl1.Name = "Displaylbl1";
            Displaylbl1.Size = new Size(801, 418);
            Displaylbl1.TabIndex = 0;
            Displaylbl1.TextAlign = ContentAlignment.MiddleCenter;
            Displaylbl1.Click += Displaylbl1_Click;
            // 
            // lblLevelNumber
            // 
            lblLevelNumber.BackColor = Color.LightBlue;
            lblLevelNumber.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblLevelNumber.Location = new Point(-1, -1);
            lblLevelNumber.Name = "lblLevelNumber";
            lblLevelNumber.Size = new Size(801, 34);
            lblLevelNumber.TabIndex = 1;
            lblLevelNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblLevelNumber);
            Controls.Add(Displaylbl1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Label Displaylbl1;
        private Label lblLevelNumber;
    }
}
