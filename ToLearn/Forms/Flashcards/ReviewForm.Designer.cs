namespace ToLearn.Forms.Flashcards
{
    partial class ReviewForm
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
            questionTextBox = new TextBox();
            answerTextBox = new TextBox();
            descriptionTextBox = new TextBox();
            checkButton = new Button();
            showAnswerButton = new Button();
            difficultCardButton = new Button();
            skipForNowButton = new Button();
            closeButton = new Button();
            SuspendLayout();
            // 
            // questionTextBox
            // 
            questionTextBox.AccessibleName = "Question";
            questionTextBox.Location = new Point(0, 0);
            questionTextBox.Multiline = true;
            questionTextBox.Name = "questionTextBox";
            questionTextBox.ReadOnly = true;
            questionTextBox.Size = new Size(500, 23);
            questionTextBox.TabIndex = 0;
            questionTextBox.Tag = "Question";
            // 
            // answerTextBox
            // 
            answerTextBox.AccessibleName = "Answer";
            answerTextBox.Location = new Point(8, 8);
            answerTextBox.Name = "answerTextBox";
            answerTextBox.Size = new Size(100, 23);
            answerTextBox.TabIndex = 1;
            answerTextBox.Tag = "Answer";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.AccessibleName = "Description";
            descriptionTextBox.Enabled = false;
            descriptionTextBox.Location = new Point(16, 16);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.ReadOnly = true;
            descriptionTextBox.Size = new Size(500, 23);
            descriptionTextBox.TabIndex = 2;
            descriptionTextBox.Tag = "Description";
            // 
            // checkButton
            // 
            checkButton.Location = new Point(24, 24);
            checkButton.Name = "checkButton";
            checkButton.Size = new Size(75, 23);
            checkButton.TabIndex = 3;
            checkButton.Tag = "Check";
            checkButton.Text = "Check";
            checkButton.UseVisualStyleBackColor = true;
            checkButton.Click += checkButton_Click;
            // 
            // showAnswerButton
            // 
            showAnswerButton.Location = new Point(32, 32);
            showAnswerButton.Name = "showAnswerButton";
            showAnswerButton.Size = new Size(75, 23);
            showAnswerButton.TabIndex = 4;
            showAnswerButton.Tag = "ShowAnswer";
            showAnswerButton.Text = "Show answer";
            showAnswerButton.UseVisualStyleBackColor = true;
            showAnswerButton.Click += showAnswerButton_Click;
            // 
            // difficultCardButton
            // 
            difficultCardButton.Location = new Point(40, 40);
            difficultCardButton.Name = "difficultCardButton";
            difficultCardButton.Size = new Size(75, 23);
            difficultCardButton.TabIndex = 5;
            difficultCardButton.Tag = "DifficultCard";
            difficultCardButton.Text = "Difficult card";
            difficultCardButton.UseVisualStyleBackColor = true;
            difficultCardButton.Click += difficultCardButton_Click;
            // 
            // skipForNowButton
            // 
            skipForNowButton.Location = new Point(48, 48);
            skipForNowButton.Name = "skipForNowButton";
            skipForNowButton.Size = new Size(75, 23);
            skipForNowButton.TabIndex = 6;
            skipForNowButton.Tag = "SkipForNow";
            skipForNowButton.Text = "Skip for now";
            skipForNowButton.UseVisualStyleBackColor = true;
            skipForNowButton.Click += skipForNowButton_Click;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(0, 0);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 23);
            closeButton.TabIndex = 7;
            closeButton.Tag = "Close";
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // ReviewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 450);
            Controls.Add(closeButton);
            Controls.Add(skipForNowButton);
            Controls.Add(difficultCardButton);
            Controls.Add(showAnswerButton);
            Controls.Add(checkButton);
            Controls.Add(descriptionTextBox);
            Controls.Add(answerTextBox);
            Controls.Add(questionTextBox);
            Name = "ReviewForm";
            Text = "Review";
            Load += ReviewForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox questionTextBox;
        private TextBox answerTextBox;
        private TextBox descriptionTextBox;
        private Button checkButton;
        private Button showAnswerButton;
        private Button difficultCardButton;
        private Button skipForNowButton;
        private Button closeButton;
    }
}