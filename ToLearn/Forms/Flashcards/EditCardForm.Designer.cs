namespace ToLearn.Forms.Flashcards
{
    partial class EditCardForm
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
            saveButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // questionTextBox
            // 
            questionTextBox.AccessibleName = "Question";
            questionTextBox.Location = new Point(0, 0);
            questionTextBox.Multiline = true;
            questionTextBox.Name = "questionTextBox";
            questionTextBox.Size = new Size(300, 23);
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
            descriptionTextBox.AccessibleName = "Description (optional)";
            descriptionTextBox.Location = new Point(16, 16);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(300, 23);
            descriptionTextBox.TabIndex = 2;
            descriptionTextBox.Tag = "Description";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(24, 24);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 3;
            saveButton.Tag = "Save";
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(32, 32);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 4;
            cancelButton.Tag = "Cancel";
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // EditCardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 450);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(descriptionTextBox);
            Controls.Add(answerTextBox);
            Controls.Add(questionTextBox);
            Name = "EditCardForm";
            Text = "Edit card";
            Load += EditCardForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox questionTextBox;
        private TextBox answerTextBox;
        private TextBox descriptionTextBox;
        private Button saveButton;
        private Button cancelButton;
    }
}