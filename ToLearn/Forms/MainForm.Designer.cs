namespace ToLearn
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
            flashcardsButton.Location = new Point(0, 0);
            flashcardsButton.Name = "flashcardsButton";
            flashcardsButton.Size = new Size(75, 23);
            flashcardsButton.TabIndex = 0;
            flashcardsButton.Text = "Flashcards";
            flashcardsButton.UseVisualStyleBackColor = true;
            // 
            // conjugationTrainingButton
            // 
            conjugationTrainingButton.Location = new Point(8, 8);
            conjugationTrainingButton.Name = "conjugationTrainingButton";
            conjugationTrainingButton.Size = new Size(75, 23);
            conjugationTrainingButton.TabIndex = 1;
            conjugationTrainingButton.Text = "Conjugation training";
            conjugationTrainingButton.UseVisualStyleBackColor = true;
            // 
            // accountButton
            // 
            accountButton.Location = new Point(16, 16);
            accountButton.Name = "accountButton";
            accountButton.Size = new Size(75, 23);
            accountButton.TabIndex = 2;
            accountButton.Text = "Account";
            accountButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(24, 24);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(75, 23);
            exitButton.TabIndex = 3;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 450);
            Controls.Add(exitButton);
            Controls.Add(accountButton);
            Controls.Add(conjugationTrainingButton);
            Controls.Add(flashcardsButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button flashcardsButton;
        private Button conjugationTrainingButton;
        private Button accountButton;
        private Button exitButton;
    }
}
