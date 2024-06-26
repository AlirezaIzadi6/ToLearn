﻿namespace ToLearn.Forms
{
    partial class MainForm
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
            flashcardsButton = new Button();
            conjugationTrainingButton = new Button();
            accountButton = new Button();
            exitButton = new Button();
            SuspendLayout();
            // 
            // flashcardsButton
            // 
            flashcardsButton.Enabled = false;
            flashcardsButton.Location = new Point(0, 0);
            flashcardsButton.Name = "flashcardsButton";
            flashcardsButton.Size = new Size(75, 23);
            flashcardsButton.TabIndex = 0;
            flashcardsButton.Tag = "Flashcards";
            flashcardsButton.Text = "Flashcards";
            flashcardsButton.UseVisualStyleBackColor = true;
            flashcardsButton.Click += flashcardsButton_Click;
            // 
            // conjugationTrainingButton
            // 
            conjugationTrainingButton.Enabled = false;
            conjugationTrainingButton.Location = new Point(8, 8);
            conjugationTrainingButton.Name = "conjugationTrainingButton";
            conjugationTrainingButton.Size = new Size(75, 23);
            conjugationTrainingButton.TabIndex = 1;
            conjugationTrainingButton.Tag = "ConjugationTraining";
            conjugationTrainingButton.Text = "Conjugation training";
            conjugationTrainingButton.UseVisualStyleBackColor = true;
            conjugationTrainingButton.Click += conjugationTrainingButton_Click;
            // 
            // accountButton
            // 
            accountButton.Location = new Point(16, 16);
            accountButton.Name = "accountButton";
            accountButton.Size = new Size(75, 23);
            accountButton.TabIndex = 2;
            accountButton.Tag = "Account";
            accountButton.Text = "Account";
            accountButton.UseVisualStyleBackColor = true;
            accountButton.Click += accountButton_Click;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(24, 24);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(75, 23);
            exitButton.TabIndex = 3;
            exitButton.Tag = "Exit";
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 450);
            Controls.Add(exitButton);
            Controls.Add(accountButton);
            Controls.Add(conjugationTrainingButton);
            Controls.Add(flashcardsButton);
            Name = "MainForm";
            Text = "To Learn";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button flashcardsButton;
        private Button conjugationTrainingButton;
        private Button accountButton;
        private Button exitButton;
    }
}
