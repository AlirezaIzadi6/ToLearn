namespace ToLearn.Forms.Flashcards
{
    partial class LearnForm
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
            previousButton = new Button();
            nextButton = new Button();
            finishButton = new Button();
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
            answerTextBox.ReadOnly = true;
            answerTextBox.Size = new Size(100, 23);
            answerTextBox.TabIndex = 1;
            answerTextBox.Tag = "Answer";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.AccessibleName = "Description";
            descriptionTextBox.Location = new Point(16, 16);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.ReadOnly = true;
            descriptionTextBox.Size = new Size(500, 23);
            descriptionTextBox.TabIndex = 2;
            descriptionTextBox.Tag = "Description";
            // 
            // previousButton
            // 
            previousButton.Location = new Point(24, 24);
            previousButton.Name = "previousButton";
            previousButton.Size = new Size(75, 23);
            previousButton.TabIndex = 3;
            previousButton.Tag = "Previous";
            previousButton.Text = "Previous";
            previousButton.UseVisualStyleBackColor = true;
            previousButton.Click += previousButton_Click;
            // 
            // nextButton
            // 
            nextButton.Location = new Point(32, 32);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(75, 23);
            nextButton.TabIndex = 4;
            nextButton.Tag = "Next";
            nextButton.Text = "Next";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // finishButton
            // 
            finishButton.Location = new Point(40, 40);
            finishButton.Name = "finishButton";
            finishButton.Size = new Size(75, 23);
            finishButton.TabIndex = 5;
            finishButton.Tag = "Finish";
            finishButton.Text = "Finish";
            finishButton.UseVisualStyleBackColor = true;
            finishButton.Click += finishButton_Click;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(48, 48);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 23);
            closeButton.TabIndex = 6;
            closeButton.Tag = "Close";
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // LearnForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 450);
            Controls.Add(closeButton);
            Controls.Add(finishButton);
            Controls.Add(nextButton);
            Controls.Add(previousButton);
            Controls.Add(descriptionTextBox);
            Controls.Add(answerTextBox);
            Controls.Add(questionTextBox);
            Name = "LearnForm";
            Text = "Learn";
            Load += LearnForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox questionTextBox;
        private TextBox answerTextBox;
        private TextBox descriptionTextBox;
        private Button previousButton;
        private Button nextButton;
        private Button finishButton;
        private Button closeButton;
    }
}